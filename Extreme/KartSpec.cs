using KartRider.IO;
using System;

namespace Extreme;

public class KartSpec
{
	public float AirFriction { get; set; }

	public float AnimalBoosterTime { get; set; }

	public float antiCollideBalance { get; set; }

	public float BackwardAccelForce { get; set; }

	public bool BikeRearWheel { get; set; }

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

	public bool motorcycleType { get; set; }

	public float NormalBoosterTime { get; set; }

	public byte[] OriginalSpec { get; set; } = null;


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

	public bool UseExtendedAfterBooster { get; set; }

	public bool UseTransformBooster { get; set; }

	public bool dualBoosterSetAuto { get; set; }

	public int dualBoosterTickMin { get; set; }

	public int dualBoosterTickMax { get; set; }

	public float dualMulAccelFactor { get; set; }

	public float dualTransLowSpeed { get; set; }

	public bool PartsEngineLock { get; set; }

	public bool PartsWheelLock { get; set; }

	public bool PartsSteeringLock { get; set; }

	public bool PartsBoosterLock { get; set; }

	public bool PartsCoatingLock { get; set; }

	public bool PartsTailLampLock { get; set; }

	public float chargeInstAccelGaugeByBoost { get; set; }

	public float chargeInstAccelGaugeByGrip { get; set; }

	public float chargeInstAccelGaugeByWall { get; set; }

	public float instAccelFactor { get; set; }

	public int instAccelGaugeCooldownTime { get; set; }

	public float instAccelGaugeLength { get; set; }

	public float instAccelGaugeMinUsable { get; set; }

	public float instAccelGaugeMinVelBound { get; set; }

	public float instAccelGaugeMinVelLoss { get; set; }

	public bool useExtendedAfterBoosterMore { get; set; }

	public int wallCollGaugeCooldownTime { get; set; }

	public float wallCollGaugeMaxVelLoss { get; set; }

	public float wallCollGaugeMinVelBound { get; set; }

	public float wallCollGaugeMinVelLoss { get; set; }

	public float modelMaxX { get; set; }

	public float modelMaxY { get; set; }

	public void Decode(InPacket iPacket)
	{
		int position = ((PacketBase)iPacket).Position;
		draftMulAccelFactor = iPacket.ReadEncodedFloat();
		draftTick = iPacket.ReadEncodedInt();
		driftBoostMulAccelFactor = iPacket.ReadEncodedFloat();
		driftBoostTick = iPacket.ReadEncodedInt();
		chargeBoostBySpeed = iPacket.ReadEncodedFloat();
		SpeedSlotCapacity = iPacket.ReadEncodedByte();
		ItemSlotCapacity = iPacket.ReadEncodedByte();
		SpecialSlotCapacity = iPacket.ReadEncodedByte();
		UseTransformBooster = iPacket.ReadEncodedByte() == 1;
		motorcycleType = iPacket.ReadEncodedByte() == 1;
		BikeRearWheel = iPacket.ReadEncodedByte() == 1;
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
		UseExtendedAfterBooster = iPacket.ReadEncodedByte() == 1;
		BoostAccelFactorOnlyItem = iPacket.ReadEncodedFloat();
		antiCollideBalance = iPacket.ReadEncodedFloat();
		dualBoosterSetAuto = iPacket.ReadEncodedByte() == 1;
		dualBoosterTickMin = iPacket.ReadEncodedInt();
		dualBoosterTickMax = iPacket.ReadEncodedInt();
		dualMulAccelFactor = iPacket.ReadEncodedFloat();
		dualTransLowSpeed = iPacket.ReadEncodedFloat();
		PartsEngineLock = iPacket.ReadEncodedByte() == 1;
		PartsWheelLock = iPacket.ReadEncodedByte() == 1;
		PartsSteeringLock = iPacket.ReadEncodedByte() == 1;
		PartsBoosterLock = iPacket.ReadEncodedByte() == 1;
		PartsCoatingLock = iPacket.ReadEncodedByte() == 1;
		PartsTailLampLock = iPacket.ReadEncodedByte() == 1;
		chargeInstAccelGaugeByBoost = iPacket.ReadEncodedFloat();
		chargeInstAccelGaugeByGrip = iPacket.ReadEncodedFloat();
		chargeInstAccelGaugeByWall = iPacket.ReadEncodedFloat();
		instAccelFactor = iPacket.ReadEncodedFloat();
		instAccelGaugeCooldownTime = iPacket.ReadEncodedInt();
		instAccelGaugeLength = iPacket.ReadEncodedFloat();
		instAccelGaugeMinUsable = iPacket.ReadEncodedFloat();
		instAccelGaugeMinVelBound = iPacket.ReadEncodedFloat();
		instAccelGaugeMinVelLoss = iPacket.ReadEncodedFloat();
		useExtendedAfterBoosterMore = iPacket.ReadEncodedByte() == 1;
		wallCollGaugeCooldownTime = iPacket.ReadEncodedInt();
		wallCollGaugeMaxVelLoss = iPacket.ReadEncodedFloat();
		wallCollGaugeMinVelBound = iPacket.ReadEncodedFloat();
		wallCollGaugeMinVelLoss = iPacket.ReadEncodedFloat();
		modelMaxX = iPacket.ReadEncodedFloat();
		modelMaxY = iPacket.ReadEncodedFloat();
		int num = ((PacketBase)iPacket).Position - position;
		((PacketBase)iPacket).Position = position;
		OriginalSpec = iPacket.ReadBytes(num);
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
	}

	public void Encode(OutPacket oPacket, bool encodeOriginal)
	{
		if (!encodeOriginal)
		{
			if (Program.KartSpec)
			{
				string s;
				if (KartSpecDialog.draftMulAccelFactor)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_draftMulAccelFactor.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_draftMulAccelFactor.Text = draftMulAccelFactor.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.draftTick)
				{
					oPacket.WriteEncInt(int.Parse(Program.KartSpecDlg.tx_draftTick.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_draftTick.Text = draftTick.ToString() ?? "");
					oPacket.WriteEncInt(int.Parse(s));
				}
				if (KartSpecDialog.driftBoostMulAccelFactor)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_driftBoostMulAccelFactor.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_driftBoostMulAccelFactor.Text = driftBoostMulAccelFactor.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.driftBoostTick)
				{
					oPacket.WriteEncInt(int.Parse(Program.KartSpecDlg.tx_driftBoostTick.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_driftBoostTick.Text = driftBoostTick.ToString() ?? "");
					oPacket.WriteEncInt(int.Parse(s));
				}
				if (KartSpecDialog.chargeBoostBySpeed)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_chargeBoostBySpeed.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_chargeBoostBySpeed.Text = chargeBoostBySpeed.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.SpeedSlotCapacity)
				{
					oPacket.WriteEncByte(byte.Parse(Program.KartSpecDlg.tx_SpeedSlotCapacity.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_SpeedSlotCapacity.Text = SpeedSlotCapacity.ToString() ?? "");
					oPacket.WriteEncByte(byte.Parse(s));
				}
				if (KartSpecDialog.ItemSlotCapacity)
				{
					oPacket.WriteEncByte(byte.Parse(Program.KartSpecDlg.tx_ItemSlotCapacity.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_ItemSlotCapacity.Text = ItemSlotCapacity.ToString() ?? "");
					oPacket.WriteEncByte(byte.Parse(s));
				}
				if (KartSpecDialog.SpecialSlotCapacity)
				{
					oPacket.WriteEncByte(byte.Parse(Program.KartSpecDlg.tx_SpecialSlotCapacity.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_SpecialSlotCapacity.Text = SpecialSlotCapacity.ToString() ?? "");
					oPacket.WriteEncByte(byte.Parse(s));
				}
				if (KartSpecDialog.UseTransformBooster)
				{
					oPacket.WriteEncByte(byte.Parse(Program.KartSpecDlg.tx_UseTransformBooster.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_UseTransformBooster.Text = (UseTransformBooster ? 1 : 0).ToString() ?? "");
					oPacket.WriteEncByte(byte.Parse(s));
				}
				if (KartSpecDialog.motorcycleType)
				{
					oPacket.WriteEncByte(byte.Parse(Program.KartSpecDlg.tx_motorcycleType.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_motorcycleType.Text = (motorcycleType ? 1 : 0).ToString() ?? "");
					oPacket.WriteEncByte(byte.Parse(s));
				}
				if (KartSpecDialog.BikeRearWheel)
				{
					oPacket.WriteEncByte(byte.Parse(Program.KartSpecDlg.tx_BikeRearWheel.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_BikeRearWheel.Text = (BikeRearWheel ? 1 : 0).ToString() ?? "");
					oPacket.WriteEncByte(byte.Parse(s));
				}
				if (KartSpecDialog.Mass)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_Mass.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_Mass.Text = Mass.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.AirFriction)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_AirFriction.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_AirFriction.Text = AirFriction.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.DragFactor)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_DragFactor.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_DragFactor.Text = DragFactor.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.ForwardAccelForce)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_ForwardAccelForce.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_ForwardAccelForce.Text = ForwardAccelForce.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.BackwardAccelForce)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_BackwardAccelForce.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_BackwardAccelForce.Text = BackwardAccelForce.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.GripBrakeForce)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_GripBrakeForce.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_GripBrakeForce.Text = GripBrakeForce.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.SlipBrakeForce)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_SlipBrakeForce.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_SlipBrakeForce.Text = SlipBrakeForce.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.MaxSteerAngle)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_MaxSteerAngle.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_MaxSteerAngle.Text = MaxSteerAngle.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.SteerConstraint)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_SteerConstraint.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_SteerConstraint.Text = SteerConstraint.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.FrontGripFactor)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_FrontGripFactor.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_FrontGripFactor.Text = FrontGripFactor.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.RearGripFactor)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_RearGripFactor.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_RearGripFactor.Text = RearGripFactor.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.DriftTriggerFactor)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_DriftTriggerFactor.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_DriftTriggerFactor.Text = DriftTriggerFactor.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.DriftTriggerTime)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_DriftTriggerTime.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_DriftTriggerTime.Text = DriftTriggerTime.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.DriftSlipFactor)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_DriftSlipFactor.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_DriftSlipFactor.Text = DriftSlipFactor.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.DriftEscapeForce)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_DriftEscapeForce.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_DriftEscapeForce.Text = DriftEscapeForce.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.CornerDrawFactor)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_CornerDrawFactor.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_CornerDrawFactor.Text = CornerDrawFactor.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.DriftLeanFactor)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_DriftLeanFactor.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_DriftLeanFactor.Text = DriftLeanFactor.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.SteerLeanFactor)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_SteerLeanFactor.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_SteerLeanFactor.Text = SteerLeanFactor.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.DriftMaxGauge)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_DriftMaxGauge.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_DriftMaxGauge.Text = DriftMaxGauge.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.NormalBoosterTime)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_NormalBoosterTime.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_NormalBoosterTime.Text = NormalBoosterTime.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.ItemBoosterTime)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_ItemBoosterTime.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_ItemBoosterTime.Text = ItemBoosterTime.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.TeamBoosterTime)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_TeamBoosterTime.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_TeamBoosterTime.Text = TeamBoosterTime.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.AnimalBoosterTime)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_AnimalBoosterTime.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_AnimalBoosterTime.Text = AnimalBoosterTime.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.SuperBoosterTime)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_SuperBoosterTime.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_SuperBoosterTime.Text = SuperBoosterTime.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.TransAccelFactor)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_TransAccelFactor.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_TransAccelFactor.Text = TransAccelFactor.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.BoostAccelFactor)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_BoostAccelFactor.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_BoostAccelFactor.Text = BoostAccelFactor.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.StartBoosterTimeItem)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_StartBoosterTimeItem.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_StartBoosterTimeItem.Text = StartBoosterTimeItem.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.StartBoosterTimeSpeed)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_StartBoosterTimeSpeed.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_StartBoosterTimeSpeed.Text = StartBoosterTimeSpeed.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.StartForwardAccelForceItem)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_StartForwardAccelForceItem.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_StartForwardAccelForceItem.Text = StartForwardAccelForceItem.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.StartForwardAccelForceSpeed)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_StartForwardAccelForceSpeed.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_StartForwardAccelForceSpeed.Text = StartForwardAccelForceSpeed.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.DriftGaguePreservePercent)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_DriftGaguePreservePercent.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_DriftGaguePreservePercent.Text = DriftGaguePreservePercent.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.UseExtendedAfterBooster)
				{
					oPacket.WriteEncByte(byte.Parse(Program.KartSpecDlg.tx_UseExtendedAfterBooster.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_UseExtendedAfterBooster.Text = (UseExtendedAfterBooster ? 1 : 0).ToString() ?? "");
					oPacket.WriteEncByte(byte.Parse(s));
				}
				if (KartSpecDialog.BoostAccelFactorOnlyItem)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_BoostAccelFactorOnlyItem.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_BoostAccelFactorOnlyItem.Text = BoostAccelFactorOnlyItem.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.antiCollideBalance)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_antiCollideBalance.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_antiCollideBalance.Text = antiCollideBalance.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				oPacket.WriteEncByte((byte)(dualBoosterSetAuto ? 1u : 0u));
				if (KartSpecDialog.dualBoosterTickMin)
				{
					oPacket.WriteEncInt(int.Parse(Program.KartSpecDlg.tx_dualBoosterTickMin.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_dualBoosterTickMin.Text = dualBoosterTickMin.ToString() ?? "");
					oPacket.WriteEncInt(int.Parse(s));
				}
				if (KartSpecDialog.dualBoosterTickMax)
				{
					oPacket.WriteEncInt(int.Parse(Program.KartSpecDlg.tx_dualBoosterTickMax.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_dualBoosterTickMax.Text = dualBoosterTickMax.ToString() ?? "");
					oPacket.WriteEncInt(int.Parse(s));
				}
				if (KartSpecDialog.dualMulAccelFactor)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_dualMulAccelFactor.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_dualMulAccelFactor.Text = dualMulAccelFactor.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.dualTransLowSpeed)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_dualTransLowSpeed.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_dualTransLowSpeed.Text = dualTransLowSpeed.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				oPacket.WriteEncByte((byte)(PartsEngineLock ? 1u : 0u));
				oPacket.WriteEncByte((byte)(PartsWheelLock ? 1u : 0u));
				oPacket.WriteEncByte((byte)(PartsSteeringLock ? 1u : 0u));
				oPacket.WriteEncByte((byte)(PartsBoosterLock ? 1u : 0u));
				oPacket.WriteEncByte((byte)(PartsCoatingLock ? 1u : 0u));
				oPacket.WriteEncByte((byte)(PartsTailLampLock ? 1u : 0u));
				if (KartSpecDialog.chargeInstAccelGaugeByBoost)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_chargeInstAccelGaugeByBoost.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_chargeInstAccelGaugeByBoost.Text = chargeInstAccelGaugeByBoost.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.chargeInstAccelGaugeByGrip)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_chargeInstAccelGaugeByGrip.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_chargeInstAccelGaugeByGrip.Text = chargeInstAccelGaugeByGrip.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.chargeInstAccelGaugeByWall)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_chargeInstAccelGaugeByWall.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_chargeInstAccelGaugeByWall.Text = chargeInstAccelGaugeByWall.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.instAccelFactor)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_instAccelFactor.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_instAccelFactor.Text = instAccelFactor.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.instAccelGaugeCooldownTime)
				{
					oPacket.WriteEncInt(int.Parse(Program.KartSpecDlg.tx_instAccelGaugeCooldownTime.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_instAccelGaugeCooldownTime.Text = instAccelGaugeCooldownTime.ToString() ?? "");
					oPacket.WriteEncInt(int.Parse(s));
				}
				if (KartSpecDialog.instAccelGaugeLength)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_instAccelGaugeLength.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_instAccelGaugeLength.Text = instAccelGaugeLength.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.instAccelGaugeMinUsable)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_instAccelGaugeMinUsable.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_instAccelGaugeMinUsable.Text = instAccelGaugeMinUsable.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.instAccelGaugeMinVelBound)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_instAccelGaugeMinVelBound.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_instAccelGaugeMinVelBound.Text = instAccelGaugeMinVelBound.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.instAccelGaugeMinVelLoss)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_instAccelGaugeMinVelLoss.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_instAccelGaugeMinVelLoss.Text = instAccelGaugeMinVelLoss.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.useExtendedAfterBoosterMore)
				{
					oPacket.WriteEncByte(byte.Parse(Program.KartSpecDlg.tx_useExtendedAfterBoosterMore.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_useExtendedAfterBoosterMore.Text = (useExtendedAfterBoosterMore ? 1 : 0).ToString() ?? "");
					oPacket.WriteEncByte(byte.Parse(s));
				}
				if (KartSpecDialog.wallCollGaugeCooldownTime)
				{
					oPacket.WriteEncInt(int.Parse(Program.KartSpecDlg.tx_wallCollGaugeCooldownTime.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_wallCollGaugeCooldownTime.Text = wallCollGaugeCooldownTime.ToString() ?? "");
					oPacket.WriteEncInt(int.Parse(s));
				}
				if (KartSpecDialog.wallCollGaugeMaxVelLoss)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_wallCollGaugeMaxVelLoss.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_wallCollGaugeMaxVelLoss.Text = wallCollGaugeMaxVelLoss.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.wallCollGaugeMinVelBound)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_wallCollGaugeMinVelBound.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_wallCollGaugeMinVelBound.Text = wallCollGaugeMinVelBound.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.wallCollGaugeMinVelLoss)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_wallCollGaugeMinVelLoss.Text));
					return;
				}
				else
				{
					s = (Program.KartSpecDlg.tx_wallCollGaugeMinVelLoss.Text = wallCollGaugeMinVelLoss.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.modelMaxX)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_modelMaxX.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_modelMaxX.Text = modelMaxX.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
				if (KartSpecDialog.modelMaxY)
				{
					oPacket.WriteEncFloat(float.Parse(Program.KartSpecDlg.tx_modelMaxY.Text));
				}
				else
				{
					s = (Program.KartSpecDlg.tx_modelMaxY.Text = modelMaxY.ToString() ?? "");
					oPacket.WriteEncFloat(float.Parse(s));
				}
			}
			else
			{
				oPacket.WriteEncFloat(draftMulAccelFactor);
				oPacket.WriteEncInt(draftTick);
				oPacket.WriteEncFloat(driftBoostMulAccelFactor);
				oPacket.WriteEncInt(driftBoostTick);
				oPacket.WriteEncFloat(chargeBoostBySpeed);
				oPacket.WriteEncByte(SpeedSlotCapacity);
				oPacket.WriteEncByte(ItemSlotCapacity);
				oPacket.WriteEncByte(SpecialSlotCapacity);
				oPacket.WriteEncByte((byte)(UseTransformBooster ? 1u : 0u));
				oPacket.WriteEncByte((byte)(motorcycleType ? 1u : 0u));
				oPacket.WriteEncByte((byte)(BikeRearWheel ? 1u : 0u));
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
				oPacket.WriteEncByte((byte)(UseExtendedAfterBooster ? 1u : 0u));
				oPacket.WriteEncFloat(BoostAccelFactorOnlyItem);
				oPacket.WriteEncFloat(antiCollideBalance);
				oPacket.WriteEncByte((byte)(dualBoosterSetAuto ? 1u : 0u));
				oPacket.WriteEncInt(dualBoosterTickMin);
				oPacket.WriteEncInt(dualBoosterTickMax);
				oPacket.WriteEncFloat(dualMulAccelFactor);
				oPacket.WriteEncFloat(dualTransLowSpeed);
				oPacket.WriteEncByte((byte)(PartsEngineLock ? 1u : 0u));
				oPacket.WriteEncByte((byte)(PartsWheelLock ? 1u : 0u));
				oPacket.WriteEncByte((byte)(PartsSteeringLock ? 1u : 0u));
				oPacket.WriteEncByte((byte)(PartsBoosterLock ? 1u : 0u));
				oPacket.WriteEncByte((byte)(PartsCoatingLock ? 1u : 0u));
				oPacket.WriteEncByte((byte)(PartsTailLampLock ? 1u : 0u));
				oPacket.WriteEncFloat(chargeInstAccelGaugeByBoost);
				oPacket.WriteEncFloat(chargeInstAccelGaugeByGrip);
				oPacket.WriteEncFloat(chargeInstAccelGaugeByWall);
				oPacket.WriteEncFloat(instAccelFactor);
				oPacket.WriteEncInt(instAccelGaugeCooldownTime);
				oPacket.WriteEncFloat(instAccelGaugeLength);
				oPacket.WriteEncFloat(instAccelGaugeMinUsable);
				oPacket.WriteEncFloat(instAccelGaugeMinVelBound);
				oPacket.WriteEncFloat(instAccelGaugeMinVelLoss);
				oPacket.WriteEncByte((byte)(useExtendedAfterBoosterMore ? 1u : 0u));
				oPacket.WriteEncInt(wallCollGaugeCooldownTime);
				oPacket.WriteEncFloat(wallCollGaugeMaxVelLoss);
				oPacket.WriteEncFloat(wallCollGaugeMinVelBound);
				oPacket.WriteEncFloat(wallCollGaugeMinVelLoss);
				oPacket.WriteEncFloat(modelMaxX);
				oPacket.WriteEncFloat(modelMaxY);
			}
		}
		else
		{
			oPacket.WriteBytes(OriginalSpec);
		}
	}
}
