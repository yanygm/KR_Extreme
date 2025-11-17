using KartRider.IO;
using System;
using System.Diagnostics;

namespace Extreme;

public class KartSpec
{
	public byte[] OriginalSpec { get; set; } = null;

	public byte[] AvailableSpec { get; set; } = null;

	public float AirFriction { get; set; }

	public float AnimalBoosterTime { get; set; }

	public float antiCollideBalance { get; set; }

	public float BackwardAccelForce { get; set; }

	public byte BikeRearWheel { get; set; }

	public float BoostAccelFactor { get; set; }

	public float BoostAccelFactorOnlyItem { get; set; }

	public float chargeBoostBySpeed { get; set; }

	public float CornerDrawFactor { get; set; }

	public float draftMulAccelFactor { get; set; }

	public int draftTick { get; set; }

	public float DragFactor { get; set; }

	public float driftBoostMulAccelFactor { get; set; }

	public int driftBoostTick { get; set; }

	public float DriftEscapeForce { get; set; }

	public float DriftGaguePreservePercent { get; set; }

	public float DriftLeanFactor { get; set; }

	public float DriftMaxGauge { get; set; }

	public float DriftSlipFactor { get; set; }

	public float DriftTriggerFactor { get; set; }

	public float DriftTriggerTime { get; set; }

	public float ForwardAccelForce { get; set; }

	public float FrontGripFactor { get; set; }

	public float GripBrakeForce { get; set; }

	public float ItemBoosterTime { get; set; }

	public byte ItemSlotCapacity { get; set; }

	public float Mass { get; set; }

	public float MaxSteerAngle { get; set; }

	public byte motorcycleType { get; set; }

	public float NormalBoosterTime { get; set; }

	public float RearGripFactor { get; set; }

	public float SlipBrakeForce { get; set; }

	public byte SpecialSlotCapacity { get; set; }

	public byte SpeedSlotCapacity { get; set; }

	public float StartBoosterTimeItem { get; set; }

	public float StartBoosterTimeSpeed { get; set; }

	public float StartForwardAccelForceItem { get; set; }

	public float StartForwardAccelForceSpeed { get; set; }

	public float SteerConstraint { get; set; }

	public float SteerLeanFactor { get; set; }

	public float SuperBoosterTime { get; set; }

	public float TeamBoosterTime { get; set; }

	public float TransAccelFactor { get; set; }

	public byte UseExtendedAfterBooster { get; set; }

	public byte UseTransformBooster { get; set; }

	public byte dualBoosterSetAuto { get; set; }

	public int dualBoosterTickMin { get; set; }

	public int dualBoosterTickMax { get; set; }

	public float dualMulAccelFactor { get; set; }

	public float dualTransLowSpeed { get; set; }

	public byte PartsEngineLock { get; set; }

	public byte PartsWheelLock { get; set; }

	public byte PartsSteeringLock { get; set; }

	public byte PartsBoosterLock { get; set; }

	public byte PartsCoatingLock { get; set; }

	public byte PartsTailLampLock { get; set; }

	public float chargeInstAccelGaugeByBoost { get; set; }

	public float chargeInstAccelGaugeByGrip { get; set; }

	public float chargeInstAccelGaugeByWall { get; set; }

	public float instAccelFactor { get; set; }

	public int instAccelGaugeCooldownTime { get; set; }

	public float instAccelGaugeLength { get; set; }

	public float instAccelGaugeMinUsable { get; set; }

	public float instAccelGaugeMinVelBound { get; set; }

	public float instAccelGaugeMinVelLoss { get; set; }

	public byte useExtendedAfterBoosterMore { get; set; }

	public int wallCollGaugeCooldownTime { get; set; }

	public float wallCollGaugeMaxVelLoss { get; set; }

	public float wallCollGaugeMinVelBound { get; set; }

	public float wallCollGaugeMinVelLoss { get; set; }

	public float modelMaxX { get; set; }

	public float modelMaxY { get; set; }

	public int defaultExceedType { get; set; }
	public byte defaultEngineType { get; set; }
	public byte EngineType { get; set; }
	public byte defaultHandleType { get; set; }
	public byte HandleType { get; set; }
	public byte defaultWheelType { get; set; }
	public byte WheelType { get; set; }
	public byte defaultBoosterType { get; set; }
	public byte BoosterType { get; set; }
	public float chargeInstAccelGaugeByWallAdded { get; set; }
	public float chargeInstAccelGaugeByBoostAdded { get; set; }
	public int chargerSystemboosterUseCount { get; set; }
	public float chargerSystemUseTime { get; set; }
	public float chargeBoostBySpeedAdded { get; set; }
	public float driftGaugeFactor { get; set; }
	public float chargeAntiCollideBalance { get; set; }
	public float startItemTableId { get; set; }
	public float startItemId { get; set; }
    public byte PartsBoosterEffectLock { get; set; }

    public int Decode(InPacket iPacket)
	{
		int position = iPacket.Position;
		draftMulAccelFactor = iPacket.ReadEncodedFloat();
		draftTick = iPacket.ReadEncodedInt();
		driftBoostMulAccelFactor = iPacket.ReadEncodedFloat();
		driftBoostTick = iPacket.ReadEncodedInt();
		chargeBoostBySpeed = iPacket.ReadEncodedFloat();
		SpeedSlotCapacity = iPacket.ReadEncodedByte();
		ItemSlotCapacity = iPacket.ReadEncodedByte();
		SpecialSlotCapacity = iPacket.ReadEncodedByte();
		UseTransformBooster = iPacket.ReadEncodedByte();
		motorcycleType = iPacket.ReadEncodedByte();
		BikeRearWheel = iPacket.ReadEncodedByte();
		Mass = iPacket.ReadEncodedFloat();
		AirFriction = iPacket.ReadEncodedFloat();
		DragFactor = iPacket.ReadEncodedFloat();
		ForwardAccelForce = iPacket.ReadEncodedFloat();
		BackwardAccelForce = iPacket.ReadEncodedFloat();
		GripBrakeForce = iPacket.ReadEncodedFloat();
		SlipBrakeForce = iPacket.ReadEncodedFloat();
		MaxSteerAngle = iPacket.ReadEncodedFloat();
		SteerConstraint = iPacket.ReadEncodedFloat();
		FrontGripFactor = iPacket.ReadEncodedFloat();
		RearGripFactor = iPacket.ReadEncodedFloat();
		DriftTriggerFactor = iPacket.ReadEncodedFloat();
		DriftTriggerTime = iPacket.ReadEncodedFloat();
		DriftSlipFactor = iPacket.ReadEncodedFloat();
		DriftEscapeForce = iPacket.ReadEncodedFloat();
		CornerDrawFactor = iPacket.ReadEncodedFloat();
		DriftLeanFactor = iPacket.ReadEncodedFloat();
		SteerLeanFactor = iPacket.ReadEncodedFloat();
		DriftMaxGauge = iPacket.ReadEncodedFloat();
		NormalBoosterTime = iPacket.ReadEncodedFloat();
		ItemBoosterTime = iPacket.ReadEncodedFloat();
		TeamBoosterTime = iPacket.ReadEncodedFloat();
		AnimalBoosterTime = iPacket.ReadEncodedFloat();
		SuperBoosterTime = iPacket.ReadEncodedFloat();
		TransAccelFactor = iPacket.ReadEncodedFloat();
		BoostAccelFactor = iPacket.ReadEncodedFloat();
		StartBoosterTimeItem = iPacket.ReadEncodedFloat();
		StartBoosterTimeSpeed = iPacket.ReadEncodedFloat();
		StartForwardAccelForceItem = iPacket.ReadEncodedFloat();
		StartForwardAccelForceSpeed = iPacket.ReadEncodedFloat();
		DriftGaguePreservePercent = iPacket.ReadEncodedFloat();
		UseExtendedAfterBooster = iPacket.ReadEncodedByte();
		BoostAccelFactorOnlyItem = iPacket.ReadEncodedFloat();
		antiCollideBalance = iPacket.ReadEncodedFloat();
		dualBoosterSetAuto = iPacket.ReadEncodedByte();
		dualBoosterTickMin = iPacket.ReadEncodedInt();
		dualBoosterTickMax = iPacket.ReadEncodedInt();
		dualMulAccelFactor = iPacket.ReadEncodedFloat();
		dualTransLowSpeed = iPacket.ReadEncodedFloat();
		PartsEngineLock = iPacket.ReadEncodedByte();
		PartsWheelLock = iPacket.ReadEncodedByte();
		PartsSteeringLock = iPacket.ReadEncodedByte();
		PartsBoosterLock = iPacket.ReadEncodedByte();
		PartsCoatingLock = iPacket.ReadEncodedByte();
		PartsTailLampLock = iPacket.ReadEncodedByte();
		chargeInstAccelGaugeByBoost = iPacket.ReadEncodedFloat();
		chargeInstAccelGaugeByGrip = iPacket.ReadEncodedFloat();
		chargeInstAccelGaugeByWall = iPacket.ReadEncodedFloat();
		instAccelFactor = iPacket.ReadEncodedFloat();
		instAccelGaugeCooldownTime = iPacket.ReadEncodedInt();
		instAccelGaugeLength = iPacket.ReadEncodedFloat();
		instAccelGaugeMinUsable = iPacket.ReadEncodedFloat();
		instAccelGaugeMinVelBound = iPacket.ReadEncodedFloat();
		instAccelGaugeMinVelLoss = iPacket.ReadEncodedFloat();
		useExtendedAfterBoosterMore = iPacket.ReadEncodedByte();
		wallCollGaugeCooldownTime = iPacket.ReadEncodedInt();
		wallCollGaugeMaxVelLoss = iPacket.ReadEncodedFloat();
		wallCollGaugeMinVelBound = iPacket.ReadEncodedFloat();
		wallCollGaugeMinVelLoss = iPacket.ReadEncodedFloat();
		modelMaxX = iPacket.ReadEncodedFloat();
		modelMaxY = iPacket.ReadEncodedFloat();
		defaultExceedType = iPacket.ReadEncodedInt();
		defaultEngineType = iPacket.ReadEncodedByte();
		EngineType = iPacket.ReadEncodedByte();
		defaultHandleType = iPacket.ReadEncodedByte();
		HandleType = iPacket.ReadEncodedByte();
		defaultWheelType = iPacket.ReadEncodedByte();
		WheelType = iPacket.ReadEncodedByte();
		defaultBoosterType = iPacket.ReadEncodedByte();
		BoosterType = iPacket.ReadEncodedByte();
		chargeInstAccelGaugeByWallAdded = iPacket.ReadEncodedFloat();
		chargeInstAccelGaugeByBoostAdded = iPacket.ReadEncodedFloat();
		chargerSystemboosterUseCount = iPacket.ReadEncodedInt();
		chargerSystemUseTime = iPacket.ReadEncodedFloat();
		chargeBoostBySpeedAdded = iPacket.ReadEncodedFloat();
		driftGaugeFactor = iPacket.ReadEncodedFloat();
		chargeAntiCollideBalance = iPacket.ReadEncodedFloat();
		startItemTableId = iPacket.ReadEncodedFloat();
		startItemId = iPacket.ReadEncodedFloat();
		AvailableSpec = iPacket.ReadBytes(4);
        PartsBoosterEffectLock = iPacket.ReadEncodedByte();
        int endPosition = iPacket.Position;
		int specLength = iPacket.Position - position;
		iPacket.Position = position;
		OriginalSpec = iPacket.ReadBytes(specLength);
		Console.WriteLine("-------------------------------------------");
		Console.WriteLine("draftMulAccelFactor: " + draftMulAccelFactor);
		Console.WriteLine("draftTick: " + draftTick);
		Console.WriteLine("driftBoostMulAccelFactor: " + driftBoostMulAccelFactor);
		Console.WriteLine("driftBoostTick: " + driftBoostTick);
		Console.WriteLine("chargeBoostBySpeed: " + chargeBoostBySpeed);
		Console.WriteLine("SpeedSlotCapacity: " + SpeedSlotCapacity);
		Console.WriteLine("ItemSlotCapacity: " + ItemSlotCapacity);
		Console.WriteLine("SpecialSlotCapacity: " + SpecialSlotCapacity);
		Console.WriteLine("UseTransformBooster: " + UseTransformBooster);
		Console.WriteLine("motorcycleType: " + motorcycleType);
		Console.WriteLine("BikeRearWheel: " + BikeRearWheel);
		Console.WriteLine("Mass: " + Mass);
		Console.WriteLine("AirFriction: " + AirFriction);
		Console.WriteLine("DragFactor: " + DragFactor);
		Console.WriteLine("ForwardAccelForce: " + ForwardAccelForce);
		Console.WriteLine("BackwardAccelForce: " + BackwardAccelForce);
		Console.WriteLine("GripBrakeForce: " + GripBrakeForce);
		Console.WriteLine("SlipBrakeForce: " + SlipBrakeForce);
		Console.WriteLine("MaxSteerAngle: " + MaxSteerAngle);
		Console.WriteLine("SteerConstraint: " + SteerConstraint);
		Console.WriteLine("FrontGripFactor: " + FrontGripFactor);
		Console.WriteLine("RearGripFactor: " + RearGripFactor);
		Console.WriteLine("DriftTriggerFactor: " + DriftTriggerFactor);
		Console.WriteLine("DriftTriggerTime: " + DriftTriggerTime);
		Console.WriteLine("DriftSlipFactor: " + DriftSlipFactor);
		Console.WriteLine("DriftEscapeForce: " + DriftEscapeForce);
		Console.WriteLine("CornerDrawFactor: " + CornerDrawFactor);
		Console.WriteLine("DriftLeanFactor: " + DriftLeanFactor);
		Console.WriteLine("SteerLeanFactor: " + SteerLeanFactor);
		Console.WriteLine("DriftMaxGauge: " + DriftMaxGauge);
		Console.WriteLine("NormalBoosterTime: " + NormalBoosterTime);
		Console.WriteLine("ItemBoosterTime: " + ItemBoosterTime);
		Console.WriteLine("TeamBoosterTime: " + TeamBoosterTime);
		Console.WriteLine("AnimalBoosterTime: " + AnimalBoosterTime);
		Console.WriteLine("SuperBoosterTime: " + SuperBoosterTime);
		Console.WriteLine("TransAccelFactor: " + TransAccelFactor);
		Console.WriteLine("BoostAccelFactor: " + BoostAccelFactor);
		Console.WriteLine("StartBoosterTimeItem: " + StartBoosterTimeItem);
		Console.WriteLine("StartBoosterTimeSpeed: " + StartBoosterTimeSpeed);
		Console.WriteLine("StartForwardAccelForceItem: " + StartForwardAccelForceItem);
		Console.WriteLine("StartForwardAccelForceSpeed: " + StartForwardAccelForceSpeed);
		Console.WriteLine("DriftGaguePreservePercent: " + DriftGaguePreservePercent);
		Console.WriteLine("UseExtendedAfterBooster: " + UseExtendedAfterBooster);
		Console.WriteLine("BoostAccelFactorOnlyItem: " + BoostAccelFactorOnlyItem);
		Console.WriteLine("antiCollideBalance: " + antiCollideBalance);
		Console.WriteLine("dualBoosterSetAuto: " + dualBoosterSetAuto);
		Console.WriteLine("dualBoosterTickMin: " + dualBoosterTickMin);
		Console.WriteLine("dualBoosterTickMax: " + dualBoosterTickMax);
		Console.WriteLine("dualMulAccelFactor: " + dualMulAccelFactor);
		Console.WriteLine("dualTransLowSpeed: " + dualTransLowSpeed);
		Console.WriteLine("PartsEngineLock: " + PartsEngineLock);
		Console.WriteLine("PartsWheelLock: " + PartsWheelLock);
		Console.WriteLine("PartsSteeringLock: " + PartsSteeringLock);
		Console.WriteLine("PartsBoosterLock: " + PartsBoosterLock);
		Console.WriteLine("PartsCoatingLock: " + PartsCoatingLock);
		Console.WriteLine("PartsTailLampLock: " + PartsTailLampLock);
		Console.WriteLine("chargeInstAccelGaugeByBoost: " + chargeInstAccelGaugeByBoost);
		Console.WriteLine("chargeInstAccelGaugeByGrip: " + chargeInstAccelGaugeByGrip);
		Console.WriteLine("chargeInstAccelGaugeByWall: " + chargeInstAccelGaugeByWall);
		Console.WriteLine("instAccelFactor: " + instAccelFactor);
		Console.WriteLine("instAccelGaugeCooldownTime: " + instAccelGaugeCooldownTime);
		Console.WriteLine("instAccelGaugeLength: " + instAccelGaugeLength);
		Console.WriteLine("instAccelGaugeMinUsable: " + instAccelGaugeMinUsable);
		Console.WriteLine("instAccelGaugeMinVelBound: " + instAccelGaugeMinVelBound);
		Console.WriteLine("instAccelGaugeMinVelLoss: " + instAccelGaugeMinVelLoss);
		Console.WriteLine("useExtendedAfterBoosterMore: " + useExtendedAfterBoosterMore);
		Console.WriteLine("wallCollGaugeCooldownTime: " + wallCollGaugeCooldownTime);
		Console.WriteLine("wallCollGaugeMaxVelLoss: " + wallCollGaugeMaxVelLoss);
		Console.WriteLine("wallCollGaugeMinVelBound: " + wallCollGaugeMinVelBound);
		Console.WriteLine("wallCollGaugeMinVelLoss: " + wallCollGaugeMinVelLoss);
		Console.WriteLine("modelMaxX: " + modelMaxX);
		Console.WriteLine("modelMaxY: " + modelMaxY);
		Console.WriteLine("defaultExceedType: " + defaultExceedType);
		Console.WriteLine("defaultEngineType: " + defaultEngineType);
		Console.WriteLine("EngineType: " + EngineType);
		Console.WriteLine("defaultHandleType: " + defaultHandleType);
		Console.WriteLine("HandleType: " + HandleType);
		Console.WriteLine("defaultWheelType: " + defaultWheelType);
		Console.WriteLine("WheelType: " + WheelType);
		Console.WriteLine("defaultBoosterType: " + defaultBoosterType);
		Console.WriteLine("BoosterType: " + BoosterType);
		Console.WriteLine("chargeInstAccelGaugeByWallAdded: " + chargeInstAccelGaugeByWallAdded);
		Console.WriteLine("chargeInstAccelGaugeByBoostAdded: " + chargeInstAccelGaugeByBoostAdded);
		Console.WriteLine("chargerSystemboosterUseCount: " + chargerSystemboosterUseCount);
		Console.WriteLine("chargerSystemUseTime: " + chargerSystemUseTime);
		Console.WriteLine("chargeBoostBySpeedAdded: " + chargeBoostBySpeedAdded);
		Console.WriteLine("driftGaugeFactor: " + driftGaugeFactor);
		Console.WriteLine("chargeAntiCollideBalance: " + chargeAntiCollideBalance);
		Console.WriteLine("startItemTableId: " + startItemTableId);
		Console.WriteLine("startItemId: " + startItemId);
		Console.WriteLine("AvailableSpec: " + BitConverter.ToString(AvailableSpec).Replace("-", " "));
		Console.WriteLine("PartsBoosterEffectLock: " + PartsBoosterEffectLock);
		Console.WriteLine("-------------------------------------------");
		return endPosition;
	}

	public void Encode(OutPacket oPacket, bool encodeOriginal)
	{
		if (!encodeOriginal)
		{
			oPacket.WriteEncFloat(draftMulAccelFactor);
			oPacket.WriteEncInt(draftTick);
			oPacket.WriteEncFloat(driftBoostMulAccelFactor);
			oPacket.WriteEncInt(driftBoostTick);
			oPacket.WriteEncFloat(chargeBoostBySpeed);
			oPacket.WriteEncByte(SpeedSlotCapacity);
			oPacket.WriteEncByte(ItemSlotCapacity);
			oPacket.WriteEncByte(SpecialSlotCapacity);
			oPacket.WriteEncByte(UseTransformBooster);
			oPacket.WriteEncByte(motorcycleType);
			oPacket.WriteEncByte(BikeRearWheel);
			oPacket.WriteEncFloat(Mass);
			oPacket.WriteEncFloat(AirFriction);
			oPacket.WriteEncFloat(DragFactor);
			oPacket.WriteEncFloat(ForwardAccelForce);
			oPacket.WriteEncFloat(BackwardAccelForce);
			oPacket.WriteEncFloat(GripBrakeForce);
			oPacket.WriteEncFloat(SlipBrakeForce);
			oPacket.WriteEncFloat(MaxSteerAngle);
			oPacket.WriteEncFloat(SteerConstraint);
			oPacket.WriteEncFloat(FrontGripFactor);
			oPacket.WriteEncFloat(RearGripFactor);
			oPacket.WriteEncFloat(DriftTriggerFactor);
			oPacket.WriteEncFloat(DriftTriggerTime);
			oPacket.WriteEncFloat(DriftSlipFactor);
			oPacket.WriteEncFloat(DriftEscapeForce);
			oPacket.WriteEncFloat(CornerDrawFactor);
			oPacket.WriteEncFloat(DriftLeanFactor);
			oPacket.WriteEncFloat(SteerLeanFactor);
			oPacket.WriteEncFloat(DriftMaxGauge);
			oPacket.WriteEncFloat(NormalBoosterTime);
			oPacket.WriteEncFloat(ItemBoosterTime);
			oPacket.WriteEncFloat(TeamBoosterTime);
			oPacket.WriteEncFloat(AnimalBoosterTime);
			oPacket.WriteEncFloat(SuperBoosterTime);
			oPacket.WriteEncFloat(TransAccelFactor);
			oPacket.WriteEncFloat(BoostAccelFactor);
			oPacket.WriteEncFloat(StartBoosterTimeItem);
			oPacket.WriteEncFloat(StartBoosterTimeSpeed);
			oPacket.WriteEncFloat(StartForwardAccelForceItem);
			oPacket.WriteEncFloat(StartForwardAccelForceSpeed);
			oPacket.WriteEncFloat(DriftGaguePreservePercent);
			oPacket.WriteEncByte(UseExtendedAfterBooster);
			oPacket.WriteEncFloat(BoostAccelFactorOnlyItem);
			oPacket.WriteEncFloat(antiCollideBalance);
			oPacket.WriteEncByte(dualBoosterSetAuto);
			oPacket.WriteEncInt(dualBoosterTickMin);
			oPacket.WriteEncInt(dualBoosterTickMax);
			oPacket.WriteEncFloat(dualMulAccelFactor);
			oPacket.WriteEncFloat(dualTransLowSpeed);
			oPacket.WriteEncByte(PartsEngineLock);
			oPacket.WriteEncByte(PartsWheelLock);
			oPacket.WriteEncByte(PartsSteeringLock);
			oPacket.WriteEncByte(PartsBoosterLock);
			oPacket.WriteEncByte(PartsCoatingLock);
			oPacket.WriteEncByte(PartsTailLampLock);
			oPacket.WriteEncFloat(chargeInstAccelGaugeByBoost);
			oPacket.WriteEncFloat(chargeInstAccelGaugeByGrip);
			oPacket.WriteEncFloat(chargeInstAccelGaugeByWall);
			oPacket.WriteEncFloat(instAccelFactor);
			oPacket.WriteEncInt(instAccelGaugeCooldownTime);
			oPacket.WriteEncFloat(instAccelGaugeLength);
			oPacket.WriteEncFloat(instAccelGaugeMinUsable);
			oPacket.WriteEncFloat(instAccelGaugeMinVelBound);
			oPacket.WriteEncFloat(instAccelGaugeMinVelLoss);
			oPacket.WriteEncByte(useExtendedAfterBoosterMore);
			oPacket.WriteEncInt(wallCollGaugeCooldownTime);
			oPacket.WriteEncFloat(wallCollGaugeMaxVelLoss);
			oPacket.WriteEncFloat(wallCollGaugeMinVelBound);
			oPacket.WriteEncFloat(wallCollGaugeMinVelLoss);
			oPacket.WriteEncFloat(modelMaxX);
			oPacket.WriteEncFloat(modelMaxY);
			oPacket.WriteEncInt(defaultExceedType);
			oPacket.WriteByte(defaultEngineType);
			oPacket.WriteByte(EngineType);
			oPacket.WriteByte(defaultHandleType);
			oPacket.WriteByte(HandleType);
			oPacket.WriteByte(defaultWheelType);
			oPacket.WriteByte(WheelType);
			oPacket.WriteByte(defaultBoosterType);
			oPacket.WriteByte(BoosterType);
			oPacket.WriteEncFloat(chargeInstAccelGaugeByWallAdded);
			oPacket.WriteEncFloat(chargeInstAccelGaugeByBoostAdded);
			oPacket.WriteEncInt(chargerSystemboosterUseCount);
			oPacket.WriteEncFloat(chargerSystemUseTime);
			oPacket.WriteEncFloat(chargeBoostBySpeedAdded);
			oPacket.WriteEncFloat(driftGaugeFactor);
			oPacket.WriteEncFloat(chargeAntiCollideBalance);
			oPacket.WriteEncFloat(startItemTableId);
			oPacket.WriteEncFloat(startItemId);
			oPacket.WriteBytes(AvailableSpec);
			oPacket.WriteEncByte(PartsBoosterEffectLock);
		}
		else
		{
			oPacket.WriteBytes(OriginalSpec);
		}
	}
}
