using System;
using System.Runtime.InteropServices;

namespace KartRider.Common.Utilities;

public static class NativeMethods
{
    public static bool IsAmd64 => Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE").ToLower() == "amd64";

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern int AllocConsole();

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern int FreeConsole();
}