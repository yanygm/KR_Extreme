using System.Threading;

namespace KartRider.Common.Utilities;

public sealed class LockFreeQueue<T> where T : class
{
    private class SingleLinkNode
    {
        public SingleLinkNode Next;

        public T Item;
    }

    private SingleLinkNode mHead = null;

    private SingleLinkNode mTail = null;

    public T Next => (mHead.Next == null) ? null : mHead.Next.Item;

    public LockFreeQueue()
    {
        mHead = new SingleLinkNode();
        mTail = mHead;
    }

    private static bool CompareAndExchange(ref SingleLinkNode pLocation, SingleLinkNode pComparand, SingleLinkNode pNewValue)
    {
        return pComparand == Interlocked.CompareExchange(ref pLocation, pNewValue, pComparand);
    }

    public void Enqueue(T pItem)
    {
        SingleLinkNode singleLinkNode = null;
        SingleLinkNode singleLinkNode2 = new SingleLinkNode();
        singleLinkNode2.Item = pItem;
        bool flag = false;
        while (!flag)
        {
            singleLinkNode = mTail;
            SingleLinkNode next = singleLinkNode.Next;
            if (mTail == singleLinkNode)
            {
                if (next == null)
                {
                    flag = CompareAndExchange(ref mTail.Next, null, singleLinkNode2);
                }
                else
                {
                    CompareAndExchange(ref mTail, singleLinkNode, next);
                }
            }
        }

        CompareAndExchange(ref mTail, singleLinkNode, singleLinkNode2);
    }

    public bool Dequeue(out T pItem)
    {
        pItem = null;
        SingleLinkNode singleLinkNode = null;
        bool flag = false;
        while (!flag)
        {
            singleLinkNode = mHead;
            SingleLinkNode singleLinkNode2 = mTail;
            SingleLinkNode next = singleLinkNode.Next;
            if (singleLinkNode != mHead)
            {
                continue;
            }

            if (singleLinkNode == singleLinkNode2)
            {
                if (next == null)
                {
                    return false;
                }

                CompareAndExchange(ref mTail, singleLinkNode2, next);
            }
            else
            {
                pItem = next.Item;
                flag = CompareAndExchange(ref mHead, singleLinkNode, next);
            }
        }

        return true;
    }

    public T Dequeue()
    {
        Dequeue(out var pItem);
        return pItem;
    }
}