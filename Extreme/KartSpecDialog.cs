using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Extreme;

public class KartSpecDialog : Form
{
	public static bool draftMulAccelFactor;

	public static bool draftTick;

	public static bool driftBoostMulAccelFactor;

	public static bool driftBoostTick;

	public static bool chargeBoostBySpeed;

	public static bool SpeedSlotCapacity;

	public static bool ItemSlotCapacity;

	public static bool SpecialSlotCapacity;

	public static bool UseTransformBooster;

	public static bool motorcycleType;

	public static bool BikeRearWheel;

	public static bool Mass;

	public static bool AirFriction;

	public static bool DragFactor;

	public static bool ForwardAccelForce;

	public static bool BackwardAccelForce;

	public static bool GripBrakeForce;

	public static bool SlipBrakeForce;

	public static bool MaxSteerAngle;

	public static bool SteerConstraint;

	public static bool FrontGripFactor;

	public static bool RearGripFactor;

	public static bool DriftTriggerFactor;

	public static bool DriftTriggerTime;

	public static bool DriftSlipFactor;

	public static bool DriftEscapeForce;

	public static bool CornerDrawFactor;

	public static bool DriftLeanFactor;

	public static bool SteerLeanFactor;

	public static bool DriftMaxGauge;

	public static bool NormalBoosterTime;

	public static bool ItemBoosterTime;

	public static bool TeamBoosterTime;

	public static bool AnimalBoosterTime;

	public static bool SuperBoosterTime;

	public static bool TransAccelFactor;

	public static bool BoostAccelFactor;

	public static bool StartBoosterTimeItem;

	public static bool StartBoosterTimeSpeed;

	public static bool StartForwardAccelForceItem;

	public static bool StartForwardAccelForceSpeed;

	public static bool DriftGaguePreservePercent;

	public static bool UseExtendedAfterBooster;

	public static bool BoostAccelFactorOnlyItem;

	public static bool antiCollideBalance;

	public static bool dualBoosterSetAuto;

	public static bool dualBoosterTickMin;

	public static bool dualBoosterTickMax;

	public static bool dualMulAccelFactor;

	public static bool dualTransLowSpeed;

	public static bool PartsEngineLock;

	public static bool PartsSteeringLock;

	public static bool PartsWheelLock;

	public static bool PartsBoosterLock;

	public static bool PartsCoatingLock;

	public static bool PartsTailLampLock;

	public static bool chargeInstAccelGaugeByBoost;

	public static bool chargeInstAccelGaugeByGrip;

	public static bool chargeInstAccelGaugeByWall;

	public static bool instAccelFactor;

	public static bool instAccelGaugeCooldownTime;

	public static bool instAccelGaugeLength;

	public static bool instAccelGaugeMinUsable;

	public static bool instAccelGaugeMinVelBound;

	public static bool instAccelGaugeMinVelLoss;

	public static bool useExtendedAfterBoosterMore;

	public static bool wallCollGaugeCooldownTime;

	public static bool wallCollGaugeMaxVelLoss;

	public static bool wallCollGaugeMinVelBound;

	public static bool wallCollGaugeMinVelLoss;

	public static bool modelMaxX;

	public static bool modelMaxY;

	private IContainer components = null;

	private CheckBox checkBox_draftMulAccelFactor;

	public TextBox tx_draftMulAccelFactor;

	public TextBox tx_draftTick;

	private CheckBox checkBox_draftTick;

	public TextBox tx_driftBoostMulAccelFactor;

	private CheckBox checkBox_driftBoostMulAccelFactor;

	public TextBox tx_SpeedSlotCapacity;

	private CheckBox checkBox_SpeedSlotCapacity;

	public TextBox tx_chargeBoostBySpeed;

	private CheckBox checkBox_chargeBoostBySpeed;

	public TextBox tx_driftBoostTick;

	private CheckBox checkBox_driftBoostTick;

	public TextBox tx_UseTransformBooster;

	private CheckBox checkBox_UseTransformBooster;

	public TextBox tx_SpecialSlotCapacity;

	private CheckBox checkBox_SpecialSlotCapacity;

	public TextBox tx_ItemSlotCapacity;

	private CheckBox checkBox_ItemSlotCapacity;

	public TextBox tx_Mass;

	private CheckBox checkBox_Mass;

	public TextBox tx_BikeRearWheel;

	private CheckBox checkBox_BikeRearWheel;

	public TextBox tx_motorcycleType;

	private CheckBox checkBox_motorcycleType;

	public TextBox tx_ForwardAccelForce;

	private CheckBox checkBox_ForwardAccelForce;

	public TextBox tx_DragFactor;

	private CheckBox checkBox_DragFactor;

	public TextBox tx_AirFriction;

	private CheckBox checkBox_AirFriction;

	public TextBox tx_SlipBrakeForce;

	private CheckBox checkBox_SlipBrakeForce;

	public TextBox tx_GripBrakeForce;

	private CheckBox checkBox_GripBrakeForce;

	public TextBox tx_BackwardAccelForce;

	private CheckBox checkBox_BackwardAccelForce;

	public TextBox tx_TransAccelFactor;

	private CheckBox checkBox_TransAccelFactor;

	public TextBox tx_SuperBoosterTime;

	private CheckBox checkBox_SuperBoosterTime;

	public TextBox tx_AnimalBoosterTime;

	private CheckBox checkBox_AnimalBoosterTime;

	public TextBox tx_TeamBoosterTime;

	private CheckBox checkBox_TeamBoosterTime;

	public TextBox tx_ItemBoosterTime;

	private CheckBox checkBox_ItemBoosterTime;

	public TextBox tx_NormalBoosterTime;

	private CheckBox checkBox_NormalBoosterTime;

	public TextBox tx_DriftMaxGauge;

	private CheckBox checkBox_DriftMaxGauge;

	public TextBox tx_SteerLeanFactor;

	private CheckBox checkBox_SteerLeanFactor;

	public TextBox tx_DriftLeanFactor;

	private CheckBox checkBox_DriftLeanFactor;

	public TextBox tx_CornerDrawFactor;

	private CheckBox checkBox_CornerDrawFactor;

	public TextBox tx_DriftEscapeForce;

	private CheckBox checkBox_DriftEscapeForce;

	public TextBox tx_DriftSlipFactor;

	private CheckBox checkBox_DriftSlipFactor;

	public TextBox tx_DriftTriggerTime;

	private CheckBox checkBox_DriftTriggerTime;

	public TextBox tx_DriftTriggerFactor;

	private CheckBox checkBox_DriftTriggerFactor;

	public TextBox tx_RearGripFactor;

	private CheckBox checkBox_RearGripFactor;

	public TextBox tx_FrontGripFactor;

	private CheckBox checkBox_FrontGripFactor;

	public TextBox tx_SteerConstraint;

	private CheckBox checkBox_SteerConstraint;

	public TextBox tx_MaxSteerAngle;

	private CheckBox checkBox_MaxSteerAngle;

	public TextBox tx_dualTransLowSpeed;

	private CheckBox checkBox_dualTransLowSpeed;

	public TextBox tx_dualMulAccelFactor;

	private CheckBox checkBox_dualMulAccelFactor;

	public TextBox tx_dualBoosterTickMax;

	private CheckBox checkBox_dualBoosterTickMax;

	public TextBox tx_dualBoosterTickMin;

	private CheckBox checkBox_dualBoosterTickMin;

	public TextBox tx_antiCollideBalance;

	private CheckBox checkBox_antiCollideBalance;

	public TextBox tx_BoostAccelFactorOnlyItem;

	private CheckBox checkBox_BoostAccelFactorOnlyItem;

	public TextBox tx_UseExtendedAfterBooster;

	private CheckBox checkBox_UseExtendedAfterBooster;

	public TextBox tx_DriftGaguePreservePercent;

	private CheckBox checkBox_DriftGaguePreservePercent;

	public TextBox tx_StartForwardAccelForceSpeed;

	private CheckBox checkBox_StartForwardAccelForceSpeed;

	public TextBox tx_StartForwardAccelForceItem;

	private CheckBox checkBox_StartForwardAccelForceItem;

	public TextBox tx_StartBoosterTimeSpeed;

	private CheckBox checkBox_StartBoosterTimeSpeed;

	public TextBox tx_StartBoosterTimeItem;

	private CheckBox checkBox_StartBoosterTimeItem;

	public TextBox tx_BoostAccelFactor;

	private CheckBox checkBox_BoostAccelFactor;

	private CheckBox checkBox_useExtendedAfterBoosterMore;

	public TextBox tx_useExtendedAfterBoosterMore;

	private CheckBox checkBox_chargeInstAccelGaugeByGrip;

	private CheckBox checkBox_chargeInstAccelGaugeByBoost;

	private CheckBox checkBox_chargeInstAccelGaugeByWall;

	private CheckBox checkBox_instAccelFactor;

	private CheckBox checkBox_instAccelGaugeLength;

	private CheckBox checkBox_wallCollGaugeCooldownTime;

	private CheckBox checkBox_wallCollGaugeMinVelBound;

	private CheckBox checkBox_wallCollGaugeMinVelLoss;

	private CheckBox checkBox_wallCollGaugeMaxVelLoss;

	public TextBox tx_chargeInstAccelGaugeByGrip;

	public TextBox tx_chargeInstAccelGaugeByBoost;

	public TextBox tx_chargeInstAccelGaugeByWall;

	public TextBox tx_instAccelFactor;

	public TextBox tx_instAccelGaugeLength;

	public TextBox tx_wallCollGaugeCooldownTime;

	public TextBox tx_wallCollGaugeMinVelBound;

	public TextBox tx_wallCollGaugeMinVelLoss;

	public TextBox tx_wallCollGaugeMaxVelLoss;

	public TextBox tx_modelMaxX;

	public TextBox tx_modelMaxY;

	private CheckBox checkBox_instAccelGaugeMinUsable;

	public TextBox tx_instAccelGaugeMinUsable;

	private CheckBox checkBox_instAccelGaugeCooldownTime;

	private CheckBox checkBox_instAccelGaugeMinVelBound;

	private CheckBox checkBox_instAccelGaugeMinVelLoss;

	public TextBox tx_instAccelGaugeCooldownTime;

	public TextBox tx_instAccelGaugeMinVelBound;

	public TextBox tx_instAccelGaugeMinVelLoss;

	public KartSpecDialog()
	{
		InitializeComponent();
	}

	private void CheckBox_draftMulAccelFactor_CheckedChanged(object sender, EventArgs e)
	{
		draftMulAccelFactor = !draftMulAccelFactor;
	}

	private void CheckBox_draftTick_CheckedChanged(object sender, EventArgs e)
	{
		draftTick = !draftTick;
	}

	private void CheckBox_driftBoostMulAccelFactor_CheckedChanged(object sender, EventArgs e)
	{
		driftBoostMulAccelFactor = !driftBoostMulAccelFactor;
	}

	private void CheckBox_driftBoostTick_CheckedChanged(object sender, EventArgs e)
	{
		driftBoostTick = !driftBoostTick;
	}

	private void CheckBox_chargeBoostBySpeed_CheckedChanged(object sender, EventArgs e)
	{
		chargeBoostBySpeed = !chargeBoostBySpeed;
	}

	private void CheckBox_SpeedSlotCapacity_CheckedChanged(object sender, EventArgs e)
	{
		SpeedSlotCapacity = !SpeedSlotCapacity;
	}

	private void CheckBox_ItemSlotCapacity_CheckedChanged(object sender, EventArgs e)
	{
		ItemSlotCapacity = !ItemSlotCapacity;
	}

	private void CheckBox_SpecialSlotCapacity_CheckedChanged(object sender, EventArgs e)
	{
		SpecialSlotCapacity = !SpecialSlotCapacity;
	}

	private void CheckBox_UseTransformBooster_CheckedChanged(object sender, EventArgs e)
	{
		UseTransformBooster = !UseTransformBooster;
	}

	private void CheckBox_motorcycleType_CheckedChanged(object sender, EventArgs e)
	{
		motorcycleType = !motorcycleType;
	}

	private void CheckBox_BikeRearWheel_CheckedChanged(object sender, EventArgs e)
	{
		BikeRearWheel = !BikeRearWheel;
	}

	private void CheckBox_Mass_CheckedChanged(object sender, EventArgs e)
	{
		Mass = !Mass;
	}

	private void CheckBox_AirFriction_CheckedChanged(object sender, EventArgs e)
	{
		AirFriction = !AirFriction;
	}

	private void CheckBox_DragFactor_CheckedChanged(object sender, EventArgs e)
	{
		DragFactor = !DragFactor;
	}

	private void CheckBox_ForwardAccelForce_CheckedChanged(object sender, EventArgs e)
	{
		ForwardAccelForce = !ForwardAccelForce;
	}

	private void CheckBox_BackwardAccelForce_CheckedChanged(object sender, EventArgs e)
	{
		BackwardAccelForce = !BackwardAccelForce;
	}

	private void CheckBox_GripBrakeForce_CheckedChanged(object sender, EventArgs e)
	{
		GripBrakeForce = !GripBrakeForce;
	}

	private void CheckBox_SlipBrakeForce_CheckedChanged(object sender, EventArgs e)
	{
		SlipBrakeForce = !SlipBrakeForce;
	}

	private void CheckBox_MaxSteerAngle_CheckedChanged(object sender, EventArgs e)
	{
		MaxSteerAngle = !MaxSteerAngle;
	}

	private void CheckBox_SteerConstraint_CheckedChanged(object sender, EventArgs e)
	{
		SteerConstraint = !SteerConstraint;
	}

	private void CheckBox_FrontGripFactor_CheckedChanged(object sender, EventArgs e)
	{
		FrontGripFactor = !FrontGripFactor;
	}

	private void CheckBox_RearGripFactor_CheckedChanged(object sender, EventArgs e)
	{
		RearGripFactor = !RearGripFactor;
	}

	private void CheckBox_DriftTriggerFactor_CheckedChanged(object sender, EventArgs e)
	{
		DriftTriggerFactor = !DriftTriggerFactor;
	}

	private void CheckBox_DriftTriggerTime_CheckedChanged(object sender, EventArgs e)
	{
		DriftTriggerTime = !DriftTriggerTime;
	}

	private void CheckBox_DriftSlipFactor_CheckedChanged(object sender, EventArgs e)
	{
		DriftSlipFactor = !DriftSlipFactor;
	}

	private void CheckBox_DriftEscapeForce_CheckedChanged(object sender, EventArgs e)
	{
		DriftEscapeForce = !DriftEscapeForce;
	}

	private void CheckBox_CornerDrawFactor_CheckedChanged(object sender, EventArgs e)
	{
		CornerDrawFactor = !CornerDrawFactor;
	}

	private void CheckBox_DriftLeanFactor_CheckedChanged(object sender, EventArgs e)
	{
		DriftLeanFactor = !DriftLeanFactor;
	}

	private void CheckBox_SteerLeanFactor_CheckedChanged(object sender, EventArgs e)
	{
		SteerLeanFactor = !SteerLeanFactor;
	}

	private void CheckBox_DriftMaxGauge_CheckedChanged(object sender, EventArgs e)
	{
		DriftMaxGauge = !DriftMaxGauge;
	}

	private void CheckBox_NormalBoosterTime_CheckedChanged(object sender, EventArgs e)
	{
		NormalBoosterTime = !NormalBoosterTime;
	}

	private void CheckBox_ItemBoosterTime_CheckedChanged(object sender, EventArgs e)
	{
		ItemBoosterTime = !ItemBoosterTime;
	}

	private void CheckBox_TeamBoosterTime_CheckedChanged(object sender, EventArgs e)
	{
		TeamBoosterTime = !TeamBoosterTime;
	}

	private void CheckBox_AnimalBoosterTime_CheckedChanged(object sender, EventArgs e)
	{
		AnimalBoosterTime = !AnimalBoosterTime;
	}

	private void CheckBox_SuperBoosterTime_CheckedChanged(object sender, EventArgs e)
	{
		SuperBoosterTime = !SuperBoosterTime;
	}

	private void CheckBox_TransAccelFactor_CheckedChanged(object sender, EventArgs e)
	{
		TransAccelFactor = !TransAccelFactor;
	}

	private void CheckBox_BoostAccelFactor_CheckedChanged(object sender, EventArgs e)
	{
		BoostAccelFactor = !BoostAccelFactor;
	}

	private void CheckBox_StartBoosterTimeItem_CheckedChanged(object sender, EventArgs e)
	{
		StartBoosterTimeItem = !StartBoosterTimeItem;
	}

	private void CheckBox_StartBoosterTimeSpeed_CheckedChanged(object sender, EventArgs e)
	{
		StartBoosterTimeSpeed = !StartBoosterTimeSpeed;
	}

	private void CheckBox_StartForwardAccelForceItem_CheckedChanged(object sender, EventArgs e)
	{
		StartForwardAccelForceItem = !StartForwardAccelForceItem;
	}

	private void CheckBox_StartForwardAccelForceSpeed_CheckedChanged(object sender, EventArgs e)
	{
		StartForwardAccelForceSpeed = !StartForwardAccelForceSpeed;
	}

	private void CheckBox_DriftGaguePreservePercent_CheckedChanged(object sender, EventArgs e)
	{
		DriftGaguePreservePercent = !DriftGaguePreservePercent;
	}

	private void CheckBox_UseExtendedAfterBooster_CheckedChanged(object sender, EventArgs e)
	{
		UseExtendedAfterBooster = !UseExtendedAfterBooster;
	}

	private void CheckBox_BoostAccelFactorOnlyItem_CheckedChanged(object sender, EventArgs e)
	{
		BoostAccelFactorOnlyItem = !BoostAccelFactorOnlyItem;
	}

	private void CheckBox_antiCollideBalance_CheckedChanged(object sender, EventArgs e)
	{
		antiCollideBalance = !antiCollideBalance;
	}

	private void CheckBox_dualBoosterTickMin_CheckedChanged(object sender, EventArgs e)
	{
		dualBoosterTickMin = !dualBoosterTickMin;
	}

	private void CheckBox_dualBoosterTickMax_CheckedChanged(object sender, EventArgs e)
	{
		dualBoosterTickMax = !dualBoosterTickMax;
	}

	private void CheckBox_dualMulAccelFactor_CheckedChanged(object sender, EventArgs e)
	{
		dualMulAccelFactor = !dualMulAccelFactor;
	}

	private void CheckBox_dualTransLowSpeed_CheckedChanged(object sender, EventArgs e)
	{
		dualTransLowSpeed = !dualTransLowSpeed;
	}

	private void checkBox_chargeInstAccelGaugeByBoost_CheckedChanged(object sender, EventArgs e)
	{
		chargeInstAccelGaugeByBoost = !chargeInstAccelGaugeByBoost;
	}

	private void checkBox_chargeInstAccelGaugeByGrip_CheckedChanged(object sender, EventArgs e)
	{
		chargeInstAccelGaugeByGrip = !chargeInstAccelGaugeByGrip;
	}

	private void checkBox_chargeInstAccelGaugeByWall_CheckedChanged(object sender, EventArgs e)
	{
		chargeInstAccelGaugeByWall = !chargeInstAccelGaugeByWall;
	}

	private void checkBox_instAccelFactor_CheckedChanged(object sender, EventArgs e)
	{
		instAccelFactor = !instAccelFactor;
	}

	private void checkBox_instAccelGaugeCooldownTime_CheckedChanged(object sender, EventArgs e)
	{
		instAccelGaugeCooldownTime = !instAccelGaugeCooldownTime;
	}

	private void checkBox_instAccelGaugeLength_CheckedChanged(object sender, EventArgs e)
	{
		instAccelGaugeLength = !instAccelGaugeLength;
	}

	private void checkBox_instAccelGaugeMinUsable_CheckedChanged(object sender, EventArgs e)
	{
		instAccelGaugeMinUsable = !instAccelGaugeMinUsable;
	}

	private void checkBox_instAccelGaugeMinVelBound_CheckedChanged(object sender, EventArgs e)
	{
		instAccelGaugeMinVelBound = !instAccelGaugeMinVelBound;
	}

	private void checkBox_instAccelGaugeMinVelLoss_CheckedChanged(object sender, EventArgs e)
	{
		instAccelGaugeMinVelLoss = !instAccelGaugeMinVelLoss;
	}

	private void checkBox_useExtendedAfterBoosterMore_CheckedChanged(object sender, EventArgs e)
	{
		useExtendedAfterBoosterMore = !useExtendedAfterBoosterMore;
	}

	private void checkBox_wallCollGaugeCooldownTime_CheckedChanged(object sender, EventArgs e)
	{
		wallCollGaugeCooldownTime = !wallCollGaugeCooldownTime;
	}

	private void checkBox_wallCollGaugeMaxVelLoss_CheckedChanged(object sender, EventArgs e)
	{
		wallCollGaugeMaxVelLoss = !wallCollGaugeMaxVelLoss;
	}

	private void checkBox_wallCollGaugeMinVelBound_CheckedChanged(object sender, EventArgs e)
	{
		wallCollGaugeMinVelBound = !wallCollGaugeMinVelBound;
	}

	private void checkBox_wallCollGaugeMinVelLoss_CheckedChanged(object sender, EventArgs e)
	{
		wallCollGaugeMinVelLoss = !wallCollGaugeMinVelLoss;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.checkBox_draftMulAccelFactor = new System.Windows.Forms.CheckBox();
		this.tx_draftMulAccelFactor = new System.Windows.Forms.TextBox();
		this.tx_draftTick = new System.Windows.Forms.TextBox();
		this.checkBox_draftTick = new System.Windows.Forms.CheckBox();
		this.tx_driftBoostMulAccelFactor = new System.Windows.Forms.TextBox();
		this.checkBox_driftBoostMulAccelFactor = new System.Windows.Forms.CheckBox();
		this.tx_SpeedSlotCapacity = new System.Windows.Forms.TextBox();
		this.checkBox_SpeedSlotCapacity = new System.Windows.Forms.CheckBox();
		this.tx_chargeBoostBySpeed = new System.Windows.Forms.TextBox();
		this.checkBox_chargeBoostBySpeed = new System.Windows.Forms.CheckBox();
		this.tx_driftBoostTick = new System.Windows.Forms.TextBox();
		this.checkBox_driftBoostTick = new System.Windows.Forms.CheckBox();
		this.tx_UseTransformBooster = new System.Windows.Forms.TextBox();
		this.checkBox_UseTransformBooster = new System.Windows.Forms.CheckBox();
		this.tx_SpecialSlotCapacity = new System.Windows.Forms.TextBox();
		this.checkBox_SpecialSlotCapacity = new System.Windows.Forms.CheckBox();
		this.tx_ItemSlotCapacity = new System.Windows.Forms.TextBox();
		this.checkBox_ItemSlotCapacity = new System.Windows.Forms.CheckBox();
		this.tx_Mass = new System.Windows.Forms.TextBox();
		this.checkBox_Mass = new System.Windows.Forms.CheckBox();
		this.tx_BikeRearWheel = new System.Windows.Forms.TextBox();
		this.checkBox_BikeRearWheel = new System.Windows.Forms.CheckBox();
		this.tx_motorcycleType = new System.Windows.Forms.TextBox();
		this.checkBox_motorcycleType = new System.Windows.Forms.CheckBox();
		this.tx_ForwardAccelForce = new System.Windows.Forms.TextBox();
		this.checkBox_ForwardAccelForce = new System.Windows.Forms.CheckBox();
		this.tx_DragFactor = new System.Windows.Forms.TextBox();
		this.checkBox_DragFactor = new System.Windows.Forms.CheckBox();
		this.tx_AirFriction = new System.Windows.Forms.TextBox();
		this.checkBox_AirFriction = new System.Windows.Forms.CheckBox();
		this.tx_SlipBrakeForce = new System.Windows.Forms.TextBox();
		this.checkBox_SlipBrakeForce = new System.Windows.Forms.CheckBox();
		this.tx_GripBrakeForce = new System.Windows.Forms.TextBox();
		this.checkBox_GripBrakeForce = new System.Windows.Forms.CheckBox();
		this.tx_BackwardAccelForce = new System.Windows.Forms.TextBox();
		this.checkBox_BackwardAccelForce = new System.Windows.Forms.CheckBox();
		this.tx_TransAccelFactor = new System.Windows.Forms.TextBox();
		this.checkBox_TransAccelFactor = new System.Windows.Forms.CheckBox();
		this.tx_SuperBoosterTime = new System.Windows.Forms.TextBox();
		this.checkBox_SuperBoosterTime = new System.Windows.Forms.CheckBox();
		this.tx_AnimalBoosterTime = new System.Windows.Forms.TextBox();
		this.checkBox_AnimalBoosterTime = new System.Windows.Forms.CheckBox();
		this.tx_TeamBoosterTime = new System.Windows.Forms.TextBox();
		this.checkBox_TeamBoosterTime = new System.Windows.Forms.CheckBox();
		this.tx_ItemBoosterTime = new System.Windows.Forms.TextBox();
		this.checkBox_ItemBoosterTime = new System.Windows.Forms.CheckBox();
		this.tx_NormalBoosterTime = new System.Windows.Forms.TextBox();
		this.checkBox_NormalBoosterTime = new System.Windows.Forms.CheckBox();
		this.tx_DriftMaxGauge = new System.Windows.Forms.TextBox();
		this.checkBox_DriftMaxGauge = new System.Windows.Forms.CheckBox();
		this.tx_SteerLeanFactor = new System.Windows.Forms.TextBox();
		this.checkBox_SteerLeanFactor = new System.Windows.Forms.CheckBox();
		this.tx_DriftLeanFactor = new System.Windows.Forms.TextBox();
		this.checkBox_DriftLeanFactor = new System.Windows.Forms.CheckBox();
		this.tx_CornerDrawFactor = new System.Windows.Forms.TextBox();
		this.checkBox_CornerDrawFactor = new System.Windows.Forms.CheckBox();
		this.tx_DriftEscapeForce = new System.Windows.Forms.TextBox();
		this.checkBox_DriftEscapeForce = new System.Windows.Forms.CheckBox();
		this.tx_DriftSlipFactor = new System.Windows.Forms.TextBox();
		this.checkBox_DriftSlipFactor = new System.Windows.Forms.CheckBox();
		this.tx_DriftTriggerTime = new System.Windows.Forms.TextBox();
		this.checkBox_DriftTriggerTime = new System.Windows.Forms.CheckBox();
		this.tx_DriftTriggerFactor = new System.Windows.Forms.TextBox();
		this.checkBox_DriftTriggerFactor = new System.Windows.Forms.CheckBox();
		this.tx_RearGripFactor = new System.Windows.Forms.TextBox();
		this.checkBox_RearGripFactor = new System.Windows.Forms.CheckBox();
		this.tx_FrontGripFactor = new System.Windows.Forms.TextBox();
		this.checkBox_FrontGripFactor = new System.Windows.Forms.CheckBox();
		this.tx_SteerConstraint = new System.Windows.Forms.TextBox();
		this.checkBox_SteerConstraint = new System.Windows.Forms.CheckBox();
		this.tx_MaxSteerAngle = new System.Windows.Forms.TextBox();
		this.checkBox_MaxSteerAngle = new System.Windows.Forms.CheckBox();
		this.tx_dualTransLowSpeed = new System.Windows.Forms.TextBox();
		this.checkBox_dualTransLowSpeed = new System.Windows.Forms.CheckBox();
		this.tx_dualMulAccelFactor = new System.Windows.Forms.TextBox();
		this.checkBox_dualMulAccelFactor = new System.Windows.Forms.CheckBox();
		this.tx_dualBoosterTickMax = new System.Windows.Forms.TextBox();
		this.checkBox_dualBoosterTickMax = new System.Windows.Forms.CheckBox();
		this.tx_dualBoosterTickMin = new System.Windows.Forms.TextBox();
		this.checkBox_dualBoosterTickMin = new System.Windows.Forms.CheckBox();
		this.tx_antiCollideBalance = new System.Windows.Forms.TextBox();
		this.checkBox_antiCollideBalance = new System.Windows.Forms.CheckBox();
		this.tx_BoostAccelFactorOnlyItem = new System.Windows.Forms.TextBox();
		this.checkBox_BoostAccelFactorOnlyItem = new System.Windows.Forms.CheckBox();
		this.tx_UseExtendedAfterBooster = new System.Windows.Forms.TextBox();
		this.checkBox_UseExtendedAfterBooster = new System.Windows.Forms.CheckBox();
		this.tx_DriftGaguePreservePercent = new System.Windows.Forms.TextBox();
		this.checkBox_DriftGaguePreservePercent = new System.Windows.Forms.CheckBox();
		this.tx_StartForwardAccelForceSpeed = new System.Windows.Forms.TextBox();
		this.checkBox_StartForwardAccelForceSpeed = new System.Windows.Forms.CheckBox();
		this.tx_StartForwardAccelForceItem = new System.Windows.Forms.TextBox();
		this.checkBox_StartForwardAccelForceItem = new System.Windows.Forms.CheckBox();
		this.tx_StartBoosterTimeSpeed = new System.Windows.Forms.TextBox();
		this.checkBox_StartBoosterTimeSpeed = new System.Windows.Forms.CheckBox();
		this.tx_StartBoosterTimeItem = new System.Windows.Forms.TextBox();
		this.checkBox_StartBoosterTimeItem = new System.Windows.Forms.CheckBox();
		this.tx_BoostAccelFactor = new System.Windows.Forms.TextBox();
		this.checkBox_BoostAccelFactor = new System.Windows.Forms.CheckBox();
		this.tx_useExtendedAfterBoosterMore = new System.Windows.Forms.TextBox();
		this.checkBox_useExtendedAfterBoosterMore = new System.Windows.Forms.CheckBox();
		this.checkBox_chargeInstAccelGaugeByGrip = new System.Windows.Forms.CheckBox();
		this.tx_chargeInstAccelGaugeByGrip = new System.Windows.Forms.TextBox();
		this.tx_chargeInstAccelGaugeByBoost = new System.Windows.Forms.TextBox();
		this.checkBox_chargeInstAccelGaugeByBoost = new System.Windows.Forms.CheckBox();
		this.tx_chargeInstAccelGaugeByWall = new System.Windows.Forms.TextBox();
		this.checkBox_chargeInstAccelGaugeByWall = new System.Windows.Forms.CheckBox();
		this.tx_instAccelFactor = new System.Windows.Forms.TextBox();
		this.checkBox_instAccelFactor = new System.Windows.Forms.CheckBox();
		this.tx_instAccelGaugeLength = new System.Windows.Forms.TextBox();
		this.checkBox_instAccelGaugeLength = new System.Windows.Forms.CheckBox();
		this.tx_wallCollGaugeCooldownTime = new System.Windows.Forms.TextBox();
		this.checkBox_wallCollGaugeCooldownTime = new System.Windows.Forms.CheckBox();
		this.tx_wallCollGaugeMinVelBound = new System.Windows.Forms.TextBox();
		this.checkBox_wallCollGaugeMinVelBound = new System.Windows.Forms.CheckBox();
		this.tx_wallCollGaugeMinVelLoss = new System.Windows.Forms.TextBox();
		this.checkBox_wallCollGaugeMinVelLoss = new System.Windows.Forms.CheckBox();
		this.tx_wallCollGaugeMaxVelLoss = new System.Windows.Forms.TextBox();
		this.checkBox_wallCollGaugeMaxVelLoss = new System.Windows.Forms.CheckBox();
		this.checkBox_instAccelGaugeMinUsable = new System.Windows.Forms.CheckBox();
		this.tx_instAccelGaugeMinUsable = new System.Windows.Forms.TextBox();
		this.checkBox_instAccelGaugeCooldownTime = new System.Windows.Forms.CheckBox();
		this.tx_instAccelGaugeCooldownTime = new System.Windows.Forms.TextBox();
		this.checkBox_instAccelGaugeMinVelBound = new System.Windows.Forms.CheckBox();
		this.checkBox_instAccelGaugeMinVelLoss = new System.Windows.Forms.CheckBox();
		this.tx_instAccelGaugeMinVelBound = new System.Windows.Forms.TextBox();
		this.tx_instAccelGaugeMinVelLoss = new System.Windows.Forms.TextBox();
		base.SuspendLayout();
		this.checkBox_draftMulAccelFactor.AutoSize = true;
		this.checkBox_draftMulAccelFactor.Location = new System.Drawing.Point(18, 15);
		this.checkBox_draftMulAccelFactor.Name = "checkBox_draftMulAccelFactor";
		this.checkBox_draftMulAccelFactor.Size = new System.Drawing.Size(137, 16);
		this.checkBox_draftMulAccelFactor.TabIndex = 0;
		this.checkBox_draftMulAccelFactor.Text = "DraftMulAccelFactor";
		this.checkBox_draftMulAccelFactor.UseVisualStyleBackColor = true;
		this.checkBox_draftMulAccelFactor.CheckedChanged += new System.EventHandler(CheckBox_draftMulAccelFactor_CheckedChanged);
		this.tx_draftMulAccelFactor.Location = new System.Drawing.Point(191, 13);
		this.tx_draftMulAccelFactor.Name = "tx_draftMulAccelFactor";
		this.tx_draftMulAccelFactor.Size = new System.Drawing.Size(100, 21);
		this.tx_draftMulAccelFactor.TabIndex = 1;
		this.tx_draftTick.Location = new System.Drawing.Point(191, 40);
		this.tx_draftTick.Name = "tx_draftTick";
		this.tx_draftTick.Size = new System.Drawing.Size(100, 21);
		this.tx_draftTick.TabIndex = 3;
		this.checkBox_draftTick.AutoSize = true;
		this.checkBox_draftTick.Location = new System.Drawing.Point(18, 42);
		this.checkBox_draftTick.Name = "checkBox_draftTick";
		this.checkBox_draftTick.Size = new System.Drawing.Size(73, 16);
		this.checkBox_draftTick.TabIndex = 2;
		this.checkBox_draftTick.Text = "DraftTick";
		this.checkBox_draftTick.UseVisualStyleBackColor = true;
		this.checkBox_draftTick.CheckedChanged += new System.EventHandler(CheckBox_draftTick_CheckedChanged);
		this.tx_driftBoostMulAccelFactor.Location = new System.Drawing.Point(191, 67);
		this.tx_driftBoostMulAccelFactor.Name = "tx_driftBoostMulAccelFactor";
		this.tx_driftBoostMulAccelFactor.Size = new System.Drawing.Size(100, 21);
		this.tx_driftBoostMulAccelFactor.TabIndex = 5;
		this.checkBox_driftBoostMulAccelFactor.AutoSize = true;
		this.checkBox_driftBoostMulAccelFactor.Location = new System.Drawing.Point(18, 69);
		this.checkBox_driftBoostMulAccelFactor.Name = "checkBox_driftBoostMulAccelFactor";
		this.checkBox_driftBoostMulAccelFactor.Size = new System.Drawing.Size(165, 16);
		this.checkBox_driftBoostMulAccelFactor.TabIndex = 4;
		this.checkBox_driftBoostMulAccelFactor.Text = "DriftBoostMulAccelFactor";
		this.checkBox_driftBoostMulAccelFactor.UseVisualStyleBackColor = true;
		this.checkBox_driftBoostMulAccelFactor.CheckedChanged += new System.EventHandler(CheckBox_driftBoostMulAccelFactor_CheckedChanged);
		this.tx_SpeedSlotCapacity.Location = new System.Drawing.Point(191, 148);
		this.tx_SpeedSlotCapacity.Name = "tx_SpeedSlotCapacity";
		this.tx_SpeedSlotCapacity.Size = new System.Drawing.Size(100, 21);
		this.tx_SpeedSlotCapacity.TabIndex = 11;
		this.checkBox_SpeedSlotCapacity.AutoSize = true;
		this.checkBox_SpeedSlotCapacity.Location = new System.Drawing.Point(18, 150);
		this.checkBox_SpeedSlotCapacity.Name = "checkBox_SpeedSlotCapacity";
		this.checkBox_SpeedSlotCapacity.Size = new System.Drawing.Size(131, 16);
		this.checkBox_SpeedSlotCapacity.TabIndex = 10;
		this.checkBox_SpeedSlotCapacity.Text = "SpeedSlotCapacity";
		this.checkBox_SpeedSlotCapacity.UseVisualStyleBackColor = true;
		this.checkBox_SpeedSlotCapacity.CheckedChanged += new System.EventHandler(CheckBox_SpeedSlotCapacity_CheckedChanged);
		this.tx_chargeBoostBySpeed.Location = new System.Drawing.Point(191, 121);
		this.tx_chargeBoostBySpeed.Name = "tx_chargeBoostBySpeed";
		this.tx_chargeBoostBySpeed.Size = new System.Drawing.Size(100, 21);
		this.tx_chargeBoostBySpeed.TabIndex = 9;
		this.checkBox_chargeBoostBySpeed.AutoSize = true;
		this.checkBox_chargeBoostBySpeed.Location = new System.Drawing.Point(18, 123);
		this.checkBox_chargeBoostBySpeed.Name = "checkBox_chargeBoostBySpeed";
		this.checkBox_chargeBoostBySpeed.Size = new System.Drawing.Size(148, 16);
		this.checkBox_chargeBoostBySpeed.TabIndex = 8;
		this.checkBox_chargeBoostBySpeed.Text = "ChargeBoostBySpeed";
		this.checkBox_chargeBoostBySpeed.UseVisualStyleBackColor = true;
		this.checkBox_chargeBoostBySpeed.CheckedChanged += new System.EventHandler(CheckBox_chargeBoostBySpeed_CheckedChanged);
		this.tx_driftBoostTick.Location = new System.Drawing.Point(191, 94);
		this.tx_driftBoostTick.Name = "tx_driftBoostTick";
		this.tx_driftBoostTick.Size = new System.Drawing.Size(100, 21);
		this.tx_driftBoostTick.TabIndex = 7;
		this.checkBox_driftBoostTick.AutoSize = true;
		this.checkBox_driftBoostTick.Location = new System.Drawing.Point(18, 96);
		this.checkBox_driftBoostTick.Name = "checkBox_driftBoostTick";
		this.checkBox_driftBoostTick.Size = new System.Drawing.Size(101, 16);
		this.checkBox_driftBoostTick.TabIndex = 6;
		this.checkBox_driftBoostTick.Text = "DriftBoostTick";
		this.checkBox_driftBoostTick.UseVisualStyleBackColor = true;
		this.checkBox_driftBoostTick.CheckedChanged += new System.EventHandler(CheckBox_driftBoostTick_CheckedChanged);
		this.tx_UseTransformBooster.Location = new System.Drawing.Point(191, 229);
		this.tx_UseTransformBooster.Name = "tx_UseTransformBooster";
		this.tx_UseTransformBooster.Size = new System.Drawing.Size(100, 21);
		this.tx_UseTransformBooster.TabIndex = 17;
		this.checkBox_UseTransformBooster.AutoSize = true;
		this.checkBox_UseTransformBooster.Location = new System.Drawing.Point(18, 231);
		this.checkBox_UseTransformBooster.Name = "checkBox_UseTransformBooster";
		this.checkBox_UseTransformBooster.Size = new System.Drawing.Size(147, 16);
		this.checkBox_UseTransformBooster.TabIndex = 16;
		this.checkBox_UseTransformBooster.Text = "UseTransformBooster";
		this.checkBox_UseTransformBooster.UseVisualStyleBackColor = true;
		this.checkBox_UseTransformBooster.CheckedChanged += new System.EventHandler(CheckBox_UseTransformBooster_CheckedChanged);
		this.tx_SpecialSlotCapacity.Location = new System.Drawing.Point(191, 202);
		this.tx_SpecialSlotCapacity.Name = "tx_SpecialSlotCapacity";
		this.tx_SpecialSlotCapacity.Size = new System.Drawing.Size(100, 21);
		this.tx_SpecialSlotCapacity.TabIndex = 15;
		this.checkBox_SpecialSlotCapacity.AutoSize = true;
		this.checkBox_SpecialSlotCapacity.Location = new System.Drawing.Point(18, 204);
		this.checkBox_SpecialSlotCapacity.Name = "checkBox_SpecialSlotCapacity";
		this.checkBox_SpecialSlotCapacity.Size = new System.Drawing.Size(137, 16);
		this.checkBox_SpecialSlotCapacity.TabIndex = 14;
		this.checkBox_SpecialSlotCapacity.Text = "SpecialSlotCapacity";
		this.checkBox_SpecialSlotCapacity.UseVisualStyleBackColor = true;
		this.checkBox_SpecialSlotCapacity.CheckedChanged += new System.EventHandler(CheckBox_SpecialSlotCapacity_CheckedChanged);
		this.tx_ItemSlotCapacity.Location = new System.Drawing.Point(191, 175);
		this.tx_ItemSlotCapacity.Name = "tx_ItemSlotCapacity";
		this.tx_ItemSlotCapacity.Size = new System.Drawing.Size(100, 21);
		this.tx_ItemSlotCapacity.TabIndex = 13;
		this.checkBox_ItemSlotCapacity.AutoSize = true;
		this.checkBox_ItemSlotCapacity.Location = new System.Drawing.Point(18, 177);
		this.checkBox_ItemSlotCapacity.Name = "checkBox_ItemSlotCapacity";
		this.checkBox_ItemSlotCapacity.Size = new System.Drawing.Size(119, 16);
		this.checkBox_ItemSlotCapacity.TabIndex = 12;
		this.checkBox_ItemSlotCapacity.Text = "ItemSlotCapacity";
		this.checkBox_ItemSlotCapacity.UseVisualStyleBackColor = true;
		this.checkBox_ItemSlotCapacity.CheckedChanged += new System.EventHandler(CheckBox_ItemSlotCapacity_CheckedChanged);
		this.tx_Mass.Location = new System.Drawing.Point(191, 310);
		this.tx_Mass.Name = "tx_Mass";
		this.tx_Mass.Size = new System.Drawing.Size(100, 21);
		this.tx_Mass.TabIndex = 23;
		this.checkBox_Mass.AutoSize = true;
		this.checkBox_Mass.Location = new System.Drawing.Point(18, 312);
		this.checkBox_Mass.Name = "checkBox_Mass";
		this.checkBox_Mass.Size = new System.Drawing.Size(56, 16);
		this.checkBox_Mass.TabIndex = 22;
		this.checkBox_Mass.Text = "Mass";
		this.checkBox_Mass.UseVisualStyleBackColor = true;
		this.checkBox_Mass.CheckedChanged += new System.EventHandler(CheckBox_Mass_CheckedChanged);
		this.tx_BikeRearWheel.Location = new System.Drawing.Point(191, 283);
		this.tx_BikeRearWheel.Name = "tx_BikeRearWheel";
		this.tx_BikeRearWheel.Size = new System.Drawing.Size(100, 21);
		this.tx_BikeRearWheel.TabIndex = 21;
		this.checkBox_BikeRearWheel.AutoSize = true;
		this.checkBox_BikeRearWheel.Location = new System.Drawing.Point(18, 285);
		this.checkBox_BikeRearWheel.Name = "checkBox_BikeRearWheel";
		this.checkBox_BikeRearWheel.Size = new System.Drawing.Size(108, 16);
		this.checkBox_BikeRearWheel.TabIndex = 20;
		this.checkBox_BikeRearWheel.Text = "BikeRearWheel";
		this.checkBox_BikeRearWheel.UseVisualStyleBackColor = true;
		this.checkBox_BikeRearWheel.CheckedChanged += new System.EventHandler(CheckBox_BikeRearWheel_CheckedChanged);
		this.tx_motorcycleType.Location = new System.Drawing.Point(191, 256);
		this.tx_motorcycleType.Name = "tx_motorcycleType";
		this.tx_motorcycleType.Size = new System.Drawing.Size(100, 21);
		this.tx_motorcycleType.TabIndex = 19;
		this.checkBox_motorcycleType.AutoSize = true;
		this.checkBox_motorcycleType.Location = new System.Drawing.Point(18, 258);
		this.checkBox_motorcycleType.Name = "checkBox_motorcycleType";
		this.checkBox_motorcycleType.Size = new System.Drawing.Size(116, 16);
		this.checkBox_motorcycleType.TabIndex = 18;
		this.checkBox_motorcycleType.Text = "MotorcycleType";
		this.checkBox_motorcycleType.UseVisualStyleBackColor = true;
		this.checkBox_motorcycleType.CheckedChanged += new System.EventHandler(CheckBox_motorcycleType_CheckedChanged);
		this.tx_ForwardAccelForce.Location = new System.Drawing.Point(191, 391);
		this.tx_ForwardAccelForce.Name = "tx_ForwardAccelForce";
		this.tx_ForwardAccelForce.Size = new System.Drawing.Size(100, 21);
		this.tx_ForwardAccelForce.TabIndex = 29;
		this.checkBox_ForwardAccelForce.AutoSize = true;
		this.checkBox_ForwardAccelForce.Location = new System.Drawing.Point(18, 393);
		this.checkBox_ForwardAccelForce.Name = "checkBox_ForwardAccelForce";
		this.checkBox_ForwardAccelForce.Size = new System.Drawing.Size(134, 16);
		this.checkBox_ForwardAccelForce.TabIndex = 28;
		this.checkBox_ForwardAccelForce.Text = "ForwardAccelForce";
		this.checkBox_ForwardAccelForce.UseVisualStyleBackColor = true;
		this.checkBox_ForwardAccelForce.CheckedChanged += new System.EventHandler(CheckBox_ForwardAccelForce_CheckedChanged);
		this.tx_DragFactor.Location = new System.Drawing.Point(191, 364);
		this.tx_DragFactor.Name = "tx_DragFactor";
		this.tx_DragFactor.Size = new System.Drawing.Size(100, 21);
		this.tx_DragFactor.TabIndex = 27;
		this.checkBox_DragFactor.AutoSize = true;
		this.checkBox_DragFactor.Location = new System.Drawing.Point(18, 366);
		this.checkBox_DragFactor.Name = "checkBox_DragFactor";
		this.checkBox_DragFactor.Size = new System.Drawing.Size(85, 16);
		this.checkBox_DragFactor.TabIndex = 26;
		this.checkBox_DragFactor.Text = "DragFactor";
		this.checkBox_DragFactor.UseVisualStyleBackColor = true;
		this.checkBox_DragFactor.CheckedChanged += new System.EventHandler(CheckBox_DragFactor_CheckedChanged);
		this.tx_AirFriction.Location = new System.Drawing.Point(191, 337);
		this.tx_AirFriction.Name = "tx_AirFriction";
		this.tx_AirFriction.Size = new System.Drawing.Size(100, 21);
		this.tx_AirFriction.TabIndex = 25;
		this.checkBox_AirFriction.AutoSize = true;
		this.checkBox_AirFriction.Location = new System.Drawing.Point(18, 339);
		this.checkBox_AirFriction.Name = "checkBox_AirFriction";
		this.checkBox_AirFriction.Size = new System.Drawing.Size(80, 16);
		this.checkBox_AirFriction.TabIndex = 24;
		this.checkBox_AirFriction.Text = "AirFriction";
		this.checkBox_AirFriction.UseVisualStyleBackColor = true;
		this.checkBox_AirFriction.CheckedChanged += new System.EventHandler(CheckBox_AirFriction_CheckedChanged);
		this.tx_SlipBrakeForce.Location = new System.Drawing.Point(191, 472);
		this.tx_SlipBrakeForce.Name = "tx_SlipBrakeForce";
		this.tx_SlipBrakeForce.Size = new System.Drawing.Size(100, 21);
		this.tx_SlipBrakeForce.TabIndex = 35;
		this.checkBox_SlipBrakeForce.AutoSize = true;
		this.checkBox_SlipBrakeForce.Location = new System.Drawing.Point(18, 474);
		this.checkBox_SlipBrakeForce.Name = "checkBox_SlipBrakeForce";
		this.checkBox_SlipBrakeForce.Size = new System.Drawing.Size(109, 16);
		this.checkBox_SlipBrakeForce.TabIndex = 34;
		this.checkBox_SlipBrakeForce.Text = "SlipBrakeForce";
		this.checkBox_SlipBrakeForce.UseVisualStyleBackColor = true;
		this.checkBox_SlipBrakeForce.CheckedChanged += new System.EventHandler(CheckBox_SlipBrakeForce_CheckedChanged);
		this.tx_GripBrakeForce.Location = new System.Drawing.Point(191, 445);
		this.tx_GripBrakeForce.Name = "tx_GripBrakeForce";
		this.tx_GripBrakeForce.Size = new System.Drawing.Size(100, 21);
		this.tx_GripBrakeForce.TabIndex = 33;
		this.checkBox_GripBrakeForce.AutoSize = true;
		this.checkBox_GripBrakeForce.Location = new System.Drawing.Point(18, 447);
		this.checkBox_GripBrakeForce.Name = "checkBox_GripBrakeForce";
		this.checkBox_GripBrakeForce.Size = new System.Drawing.Size(111, 16);
		this.checkBox_GripBrakeForce.TabIndex = 32;
		this.checkBox_GripBrakeForce.Text = "GripBrakeForce";
		this.checkBox_GripBrakeForce.UseVisualStyleBackColor = true;
		this.checkBox_GripBrakeForce.CheckedChanged += new System.EventHandler(CheckBox_GripBrakeForce_CheckedChanged);
		this.tx_BackwardAccelForce.Location = new System.Drawing.Point(191, 418);
		this.tx_BackwardAccelForce.Name = "tx_BackwardAccelForce";
		this.tx_BackwardAccelForce.Size = new System.Drawing.Size(100, 21);
		this.tx_BackwardAccelForce.TabIndex = 31;
		this.checkBox_BackwardAccelForce.AutoSize = true;
		this.checkBox_BackwardAccelForce.Location = new System.Drawing.Point(18, 420);
		this.checkBox_BackwardAccelForce.Name = "checkBox_BackwardAccelForce";
		this.checkBox_BackwardAccelForce.Size = new System.Drawing.Size(144, 16);
		this.checkBox_BackwardAccelForce.TabIndex = 30;
		this.checkBox_BackwardAccelForce.Text = "BackwardAccelForce";
		this.checkBox_BackwardAccelForce.UseVisualStyleBackColor = true;
		this.checkBox_BackwardAccelForce.CheckedChanged += new System.EventHandler(CheckBox_BackwardAccelForce_CheckedChanged);
		this.tx_TransAccelFactor.Location = new System.Drawing.Point(518, 391);
		this.tx_TransAccelFactor.Name = "tx_TransAccelFactor";
		this.tx_TransAccelFactor.Size = new System.Drawing.Size(100, 21);
		this.tx_TransAccelFactor.TabIndex = 71;
		this.checkBox_TransAccelFactor.AutoSize = true;
		this.checkBox_TransAccelFactor.Location = new System.Drawing.Point(321, 393);
		this.checkBox_TransAccelFactor.Name = "checkBox_TransAccelFactor";
		this.checkBox_TransAccelFactor.Size = new System.Drawing.Size(124, 16);
		this.checkBox_TransAccelFactor.TabIndex = 70;
		this.checkBox_TransAccelFactor.Text = "TransAccelFactor";
		this.checkBox_TransAccelFactor.UseVisualStyleBackColor = true;
		this.checkBox_TransAccelFactor.CheckedChanged += new System.EventHandler(CheckBox_TransAccelFactor_CheckedChanged);
		this.tx_SuperBoosterTime.Location = new System.Drawing.Point(518, 364);
		this.tx_SuperBoosterTime.Name = "tx_SuperBoosterTime";
		this.tx_SuperBoosterTime.Size = new System.Drawing.Size(100, 21);
		this.tx_SuperBoosterTime.TabIndex = 69;
		this.checkBox_SuperBoosterTime.AutoSize = true;
		this.checkBox_SuperBoosterTime.Location = new System.Drawing.Point(321, 366);
		this.checkBox_SuperBoosterTime.Name = "checkBox_SuperBoosterTime";
		this.checkBox_SuperBoosterTime.Size = new System.Drawing.Size(129, 16);
		this.checkBox_SuperBoosterTime.TabIndex = 68;
		this.checkBox_SuperBoosterTime.Text = "SuperBoosterTime";
		this.checkBox_SuperBoosterTime.UseVisualStyleBackColor = true;
		this.checkBox_SuperBoosterTime.CheckedChanged += new System.EventHandler(CheckBox_SuperBoosterTime_CheckedChanged);
		this.tx_AnimalBoosterTime.Location = new System.Drawing.Point(518, 337);
		this.tx_AnimalBoosterTime.Name = "tx_AnimalBoosterTime";
		this.tx_AnimalBoosterTime.Size = new System.Drawing.Size(100, 21);
		this.tx_AnimalBoosterTime.TabIndex = 67;
		this.checkBox_AnimalBoosterTime.AutoSize = true;
		this.checkBox_AnimalBoosterTime.Location = new System.Drawing.Point(321, 339);
		this.checkBox_AnimalBoosterTime.Name = "checkBox_AnimalBoosterTime";
		this.checkBox_AnimalBoosterTime.Size = new System.Drawing.Size(135, 16);
		this.checkBox_AnimalBoosterTime.TabIndex = 66;
		this.checkBox_AnimalBoosterTime.Text = "AnimalBoosterTime";
		this.checkBox_AnimalBoosterTime.UseVisualStyleBackColor = true;
		this.checkBox_AnimalBoosterTime.CheckedChanged += new System.EventHandler(CheckBox_AnimalBoosterTime_CheckedChanged);
		this.tx_TeamBoosterTime.Location = new System.Drawing.Point(518, 310);
		this.tx_TeamBoosterTime.Name = "tx_TeamBoosterTime";
		this.tx_TeamBoosterTime.Size = new System.Drawing.Size(100, 21);
		this.tx_TeamBoosterTime.TabIndex = 65;
		this.checkBox_TeamBoosterTime.AutoSize = true;
		this.checkBox_TeamBoosterTime.Location = new System.Drawing.Point(321, 312);
		this.checkBox_TeamBoosterTime.Name = "checkBox_TeamBoosterTime";
		this.checkBox_TeamBoosterTime.Size = new System.Drawing.Size(129, 16);
		this.checkBox_TeamBoosterTime.TabIndex = 64;
		this.checkBox_TeamBoosterTime.Text = "TeamBoosterTime";
		this.checkBox_TeamBoosterTime.UseVisualStyleBackColor = true;
		this.checkBox_TeamBoosterTime.CheckedChanged += new System.EventHandler(CheckBox_TeamBoosterTime_CheckedChanged);
		this.tx_ItemBoosterTime.Location = new System.Drawing.Point(518, 283);
		this.tx_ItemBoosterTime.Name = "tx_ItemBoosterTime";
		this.tx_ItemBoosterTime.Size = new System.Drawing.Size(100, 21);
		this.tx_ItemBoosterTime.TabIndex = 63;
		this.checkBox_ItemBoosterTime.AutoSize = true;
		this.checkBox_ItemBoosterTime.Location = new System.Drawing.Point(321, 285);
		this.checkBox_ItemBoosterTime.Name = "checkBox_ItemBoosterTime";
		this.checkBox_ItemBoosterTime.Size = new System.Drawing.Size(120, 16);
		this.checkBox_ItemBoosterTime.TabIndex = 62;
		this.checkBox_ItemBoosterTime.Text = "ItemBoosterTime";
		this.checkBox_ItemBoosterTime.UseVisualStyleBackColor = true;
		this.checkBox_ItemBoosterTime.CheckedChanged += new System.EventHandler(CheckBox_ItemBoosterTime_CheckedChanged);
		this.tx_NormalBoosterTime.Location = new System.Drawing.Point(518, 256);
		this.tx_NormalBoosterTime.Name = "tx_NormalBoosterTime";
		this.tx_NormalBoosterTime.Size = new System.Drawing.Size(100, 21);
		this.tx_NormalBoosterTime.TabIndex = 61;
		this.checkBox_NormalBoosterTime.AutoSize = true;
		this.checkBox_NormalBoosterTime.Location = new System.Drawing.Point(321, 258);
		this.checkBox_NormalBoosterTime.Name = "checkBox_NormalBoosterTime";
		this.checkBox_NormalBoosterTime.Size = new System.Drawing.Size(137, 16);
		this.checkBox_NormalBoosterTime.TabIndex = 60;
		this.checkBox_NormalBoosterTime.Text = "NormalBoosterTime";
		this.checkBox_NormalBoosterTime.UseVisualStyleBackColor = true;
		this.checkBox_NormalBoosterTime.CheckedChanged += new System.EventHandler(CheckBox_NormalBoosterTime_CheckedChanged);
		this.tx_DriftMaxGauge.Location = new System.Drawing.Point(518, 229);
		this.tx_DriftMaxGauge.Name = "tx_DriftMaxGauge";
		this.tx_DriftMaxGauge.Size = new System.Drawing.Size(100, 21);
		this.tx_DriftMaxGauge.TabIndex = 59;
		this.checkBox_DriftMaxGauge.AutoSize = true;
		this.checkBox_DriftMaxGauge.Location = new System.Drawing.Point(321, 231);
		this.checkBox_DriftMaxGauge.Name = "checkBox_DriftMaxGauge";
		this.checkBox_DriftMaxGauge.Size = new System.Drawing.Size(107, 16);
		this.checkBox_DriftMaxGauge.TabIndex = 58;
		this.checkBox_DriftMaxGauge.Text = "DriftMaxGauge";
		this.checkBox_DriftMaxGauge.UseVisualStyleBackColor = true;
		this.checkBox_DriftMaxGauge.CheckedChanged += new System.EventHandler(CheckBox_DriftMaxGauge_CheckedChanged);
		this.tx_SteerLeanFactor.Location = new System.Drawing.Point(518, 202);
		this.tx_SteerLeanFactor.Name = "tx_SteerLeanFactor";
		this.tx_SteerLeanFactor.Size = new System.Drawing.Size(100, 21);
		this.tx_SteerLeanFactor.TabIndex = 57;
		this.checkBox_SteerLeanFactor.AutoSize = true;
		this.checkBox_SteerLeanFactor.Location = new System.Drawing.Point(321, 204);
		this.checkBox_SteerLeanFactor.Name = "checkBox_SteerLeanFactor";
		this.checkBox_SteerLeanFactor.Size = new System.Drawing.Size(116, 16);
		this.checkBox_SteerLeanFactor.TabIndex = 56;
		this.checkBox_SteerLeanFactor.Text = "SteerLeanFactor";
		this.checkBox_SteerLeanFactor.UseVisualStyleBackColor = true;
		this.checkBox_SteerLeanFactor.CheckedChanged += new System.EventHandler(CheckBox_SteerLeanFactor_CheckedChanged);
		this.tx_DriftLeanFactor.Location = new System.Drawing.Point(518, 175);
		this.tx_DriftLeanFactor.Name = "tx_DriftLeanFactor";
		this.tx_DriftLeanFactor.Size = new System.Drawing.Size(100, 21);
		this.tx_DriftLeanFactor.TabIndex = 55;
		this.checkBox_DriftLeanFactor.AutoSize = true;
		this.checkBox_DriftLeanFactor.Location = new System.Drawing.Point(321, 177);
		this.checkBox_DriftLeanFactor.Name = "checkBox_DriftLeanFactor";
		this.checkBox_DriftLeanFactor.Size = new System.Drawing.Size(108, 16);
		this.checkBox_DriftLeanFactor.TabIndex = 54;
		this.checkBox_DriftLeanFactor.Text = "DriftLeanFactor";
		this.checkBox_DriftLeanFactor.UseVisualStyleBackColor = true;
		this.checkBox_DriftLeanFactor.CheckedChanged += new System.EventHandler(CheckBox_DriftLeanFactor_CheckedChanged);
		this.tx_CornerDrawFactor.Location = new System.Drawing.Point(518, 148);
		this.tx_CornerDrawFactor.Name = "tx_CornerDrawFactor";
		this.tx_CornerDrawFactor.Size = new System.Drawing.Size(100, 21);
		this.tx_CornerDrawFactor.TabIndex = 53;
		this.checkBox_CornerDrawFactor.AutoSize = true;
		this.checkBox_CornerDrawFactor.Location = new System.Drawing.Point(321, 150);
		this.checkBox_CornerDrawFactor.Name = "checkBox_CornerDrawFactor";
		this.checkBox_CornerDrawFactor.Size = new System.Drawing.Size(126, 16);
		this.checkBox_CornerDrawFactor.TabIndex = 52;
		this.checkBox_CornerDrawFactor.Text = "CornerDrawFactor";
		this.checkBox_CornerDrawFactor.UseVisualStyleBackColor = true;
		this.checkBox_CornerDrawFactor.CheckedChanged += new System.EventHandler(CheckBox_CornerDrawFactor_CheckedChanged);
		this.tx_DriftEscapeForce.Location = new System.Drawing.Point(518, 121);
		this.tx_DriftEscapeForce.Name = "tx_DriftEscapeForce";
		this.tx_DriftEscapeForce.Size = new System.Drawing.Size(100, 21);
		this.tx_DriftEscapeForce.TabIndex = 51;
		this.checkBox_DriftEscapeForce.AutoSize = true;
		this.checkBox_DriftEscapeForce.Location = new System.Drawing.Point(321, 123);
		this.checkBox_DriftEscapeForce.Name = "checkBox_DriftEscapeForce";
		this.checkBox_DriftEscapeForce.Size = new System.Drawing.Size(120, 16);
		this.checkBox_DriftEscapeForce.TabIndex = 50;
		this.checkBox_DriftEscapeForce.Text = "DriftEscapeForce";
		this.checkBox_DriftEscapeForce.UseVisualStyleBackColor = true;
		this.checkBox_DriftEscapeForce.CheckedChanged += new System.EventHandler(CheckBox_DriftEscapeForce_CheckedChanged);
		this.tx_DriftSlipFactor.Location = new System.Drawing.Point(518, 94);
		this.tx_DriftSlipFactor.Name = "tx_DriftSlipFactor";
		this.tx_DriftSlipFactor.Size = new System.Drawing.Size(100, 21);
		this.tx_DriftSlipFactor.TabIndex = 49;
		this.checkBox_DriftSlipFactor.AutoSize = true;
		this.checkBox_DriftSlipFactor.Location = new System.Drawing.Point(321, 96);
		this.checkBox_DriftSlipFactor.Name = "checkBox_DriftSlipFactor";
		this.checkBox_DriftSlipFactor.Size = new System.Drawing.Size(101, 16);
		this.checkBox_DriftSlipFactor.TabIndex = 48;
		this.checkBox_DriftSlipFactor.Text = "DriftSlipFactor";
		this.checkBox_DriftSlipFactor.UseVisualStyleBackColor = true;
		this.checkBox_DriftSlipFactor.CheckedChanged += new System.EventHandler(CheckBox_DriftSlipFactor_CheckedChanged);
		this.tx_DriftTriggerTime.Location = new System.Drawing.Point(518, 67);
		this.tx_DriftTriggerTime.Name = "tx_DriftTriggerTime";
		this.tx_DriftTriggerTime.Size = new System.Drawing.Size(100, 21);
		this.tx_DriftTriggerTime.TabIndex = 47;
		this.checkBox_DriftTriggerTime.AutoSize = true;
		this.checkBox_DriftTriggerTime.Location = new System.Drawing.Point(321, 69);
		this.checkBox_DriftTriggerTime.Name = "checkBox_DriftTriggerTime";
		this.checkBox_DriftTriggerTime.Size = new System.Drawing.Size(114, 16);
		this.checkBox_DriftTriggerTime.TabIndex = 46;
		this.checkBox_DriftTriggerTime.Text = "DriftTriggerTime";
		this.checkBox_DriftTriggerTime.UseVisualStyleBackColor = true;
		this.checkBox_DriftTriggerTime.CheckedChanged += new System.EventHandler(CheckBox_DriftTriggerTime_CheckedChanged);
		this.tx_DriftTriggerFactor.Location = new System.Drawing.Point(518, 40);
		this.tx_DriftTriggerFactor.Name = "tx_DriftTriggerFactor";
		this.tx_DriftTriggerFactor.Size = new System.Drawing.Size(100, 21);
		this.tx_DriftTriggerFactor.TabIndex = 45;
		this.checkBox_DriftTriggerFactor.AutoSize = true;
		this.checkBox_DriftTriggerFactor.Location = new System.Drawing.Point(321, 42);
		this.checkBox_DriftTriggerFactor.Name = "checkBox_DriftTriggerFactor";
		this.checkBox_DriftTriggerFactor.Size = new System.Drawing.Size(120, 16);
		this.checkBox_DriftTriggerFactor.TabIndex = 44;
		this.checkBox_DriftTriggerFactor.Text = "DriftTriggerFactor";
		this.checkBox_DriftTriggerFactor.UseVisualStyleBackColor = true;
		this.checkBox_DriftTriggerFactor.CheckedChanged += new System.EventHandler(CheckBox_DriftTriggerFactor_CheckedChanged);
		this.tx_RearGripFactor.Location = new System.Drawing.Point(518, 13);
		this.tx_RearGripFactor.Name = "tx_RearGripFactor";
		this.tx_RearGripFactor.Size = new System.Drawing.Size(100, 21);
		this.tx_RearGripFactor.TabIndex = 43;
		this.checkBox_RearGripFactor.AutoSize = true;
		this.checkBox_RearGripFactor.Location = new System.Drawing.Point(321, 15);
		this.checkBox_RearGripFactor.Name = "checkBox_RearGripFactor";
		this.checkBox_RearGripFactor.Size = new System.Drawing.Size(108, 16);
		this.checkBox_RearGripFactor.TabIndex = 42;
		this.checkBox_RearGripFactor.Text = "RearGripFactor";
		this.checkBox_RearGripFactor.UseVisualStyleBackColor = true;
		this.checkBox_RearGripFactor.CheckedChanged += new System.EventHandler(CheckBox_RearGripFactor_CheckedChanged);
		this.tx_FrontGripFactor.Location = new System.Drawing.Point(191, 553);
		this.tx_FrontGripFactor.Name = "tx_FrontGripFactor";
		this.tx_FrontGripFactor.Size = new System.Drawing.Size(100, 21);
		this.tx_FrontGripFactor.TabIndex = 41;
		this.checkBox_FrontGripFactor.AutoSize = true;
		this.checkBox_FrontGripFactor.Location = new System.Drawing.Point(18, 555);
		this.checkBox_FrontGripFactor.Name = "checkBox_FrontGripFactor";
		this.checkBox_FrontGripFactor.Size = new System.Drawing.Size(110, 16);
		this.checkBox_FrontGripFactor.TabIndex = 40;
		this.checkBox_FrontGripFactor.Text = "FrontGripFactor";
		this.checkBox_FrontGripFactor.UseVisualStyleBackColor = true;
		this.checkBox_FrontGripFactor.CheckedChanged += new System.EventHandler(CheckBox_FrontGripFactor_CheckedChanged);
		this.tx_SteerConstraint.Location = new System.Drawing.Point(191, 526);
		this.tx_SteerConstraint.Name = "tx_SteerConstraint";
		this.tx_SteerConstraint.Size = new System.Drawing.Size(100, 21);
		this.tx_SteerConstraint.TabIndex = 39;
		this.checkBox_SteerConstraint.AutoSize = true;
		this.checkBox_SteerConstraint.Location = new System.Drawing.Point(18, 528);
		this.checkBox_SteerConstraint.Name = "checkBox_SteerConstraint";
		this.checkBox_SteerConstraint.Size = new System.Drawing.Size(110, 16);
		this.checkBox_SteerConstraint.TabIndex = 38;
		this.checkBox_SteerConstraint.Text = "SteerConstraint";
		this.checkBox_SteerConstraint.UseVisualStyleBackColor = true;
		this.checkBox_SteerConstraint.CheckedChanged += new System.EventHandler(CheckBox_SteerConstraint_CheckedChanged);
		this.tx_MaxSteerAngle.Location = new System.Drawing.Point(191, 499);
		this.tx_MaxSteerAngle.Name = "tx_MaxSteerAngle";
		this.tx_MaxSteerAngle.Size = new System.Drawing.Size(100, 21);
		this.tx_MaxSteerAngle.TabIndex = 37;
		this.checkBox_MaxSteerAngle.AutoSize = true;
		this.checkBox_MaxSteerAngle.Location = new System.Drawing.Point(18, 501);
		this.checkBox_MaxSteerAngle.Name = "checkBox_MaxSteerAngle";
		this.checkBox_MaxSteerAngle.Size = new System.Drawing.Size(110, 16);
		this.checkBox_MaxSteerAngle.TabIndex = 36;
		this.checkBox_MaxSteerAngle.Text = "MaxSteerAngle";
		this.checkBox_MaxSteerAngle.UseVisualStyleBackColor = true;
		this.checkBox_MaxSteerAngle.CheckedChanged += new System.EventHandler(CheckBox_MaxSteerAngle_CheckedChanged);
		this.tx_dualTransLowSpeed.Location = new System.Drawing.Point(854, 175);
		this.tx_dualTransLowSpeed.Name = "tx_dualTransLowSpeed";
		this.tx_dualTransLowSpeed.Size = new System.Drawing.Size(100, 21);
		this.tx_dualTransLowSpeed.TabIndex = 99;
		this.checkBox_dualTransLowSpeed.AutoSize = true;
		this.checkBox_dualTransLowSpeed.Location = new System.Drawing.Point(648, 177);
		this.checkBox_dualTransLowSpeed.Name = "checkBox_dualTransLowSpeed";
		this.checkBox_dualTransLowSpeed.Size = new System.Drawing.Size(141, 16);
		this.checkBox_dualTransLowSpeed.TabIndex = 98;
		this.checkBox_dualTransLowSpeed.Text = "dualTransLowSpeed";
		this.checkBox_dualTransLowSpeed.UseVisualStyleBackColor = true;
		this.checkBox_dualTransLowSpeed.CheckedChanged += new System.EventHandler(CheckBox_dualTransLowSpeed_CheckedChanged);
		this.tx_dualMulAccelFactor.Location = new System.Drawing.Point(854, 148);
		this.tx_dualMulAccelFactor.Name = "tx_dualMulAccelFactor";
		this.tx_dualMulAccelFactor.Size = new System.Drawing.Size(100, 21);
		this.tx_dualMulAccelFactor.TabIndex = 97;
		this.checkBox_dualMulAccelFactor.AutoSize = true;
		this.checkBox_dualMulAccelFactor.Location = new System.Drawing.Point(648, 150);
		this.checkBox_dualMulAccelFactor.Name = "checkBox_dualMulAccelFactor";
		this.checkBox_dualMulAccelFactor.Size = new System.Drawing.Size(136, 16);
		this.checkBox_dualMulAccelFactor.TabIndex = 96;
		this.checkBox_dualMulAccelFactor.Text = "dualMulAccelFactor";
		this.checkBox_dualMulAccelFactor.UseVisualStyleBackColor = true;
		this.checkBox_dualMulAccelFactor.CheckedChanged += new System.EventHandler(CheckBox_dualMulAccelFactor_CheckedChanged);
		this.tx_dualBoosterTickMax.Location = new System.Drawing.Point(854, 121);
		this.tx_dualBoosterTickMax.Name = "tx_dualBoosterTickMax";
		this.tx_dualBoosterTickMax.Size = new System.Drawing.Size(100, 21);
		this.tx_dualBoosterTickMax.TabIndex = 95;
		this.checkBox_dualBoosterTickMax.AutoSize = true;
		this.checkBox_dualBoosterTickMax.Location = new System.Drawing.Point(648, 123);
		this.checkBox_dualBoosterTickMax.Name = "checkBox_dualBoosterTickMax";
		this.checkBox_dualBoosterTickMax.Size = new System.Drawing.Size(140, 16);
		this.checkBox_dualBoosterTickMax.TabIndex = 94;
		this.checkBox_dualBoosterTickMax.Text = "dualBoosterTickMax";
		this.checkBox_dualBoosterTickMax.UseVisualStyleBackColor = true;
		this.checkBox_dualBoosterTickMax.CheckedChanged += new System.EventHandler(CheckBox_dualBoosterTickMax_CheckedChanged);
		this.tx_dualBoosterTickMin.Location = new System.Drawing.Point(854, 94);
		this.tx_dualBoosterTickMin.Name = "tx_dualBoosterTickMin";
		this.tx_dualBoosterTickMin.Size = new System.Drawing.Size(100, 21);
		this.tx_dualBoosterTickMin.TabIndex = 93;
		this.checkBox_dualBoosterTickMin.AutoSize = true;
		this.checkBox_dualBoosterTickMin.Location = new System.Drawing.Point(648, 96);
		this.checkBox_dualBoosterTickMin.Name = "checkBox_dualBoosterTickMin";
		this.checkBox_dualBoosterTickMin.Size = new System.Drawing.Size(136, 16);
		this.checkBox_dualBoosterTickMin.TabIndex = 92;
		this.checkBox_dualBoosterTickMin.Text = "dualBoosterTickMin";
		this.checkBox_dualBoosterTickMin.UseVisualStyleBackColor = true;
		this.checkBox_dualBoosterTickMin.CheckedChanged += new System.EventHandler(CheckBox_dualBoosterTickMin_CheckedChanged);
		this.tx_antiCollideBalance.Location = new System.Drawing.Point(854, 67);
		this.tx_antiCollideBalance.Name = "tx_antiCollideBalance";
		this.tx_antiCollideBalance.Size = new System.Drawing.Size(100, 21);
		this.tx_antiCollideBalance.TabIndex = 89;
		this.checkBox_antiCollideBalance.AutoSize = true;
		this.checkBox_antiCollideBalance.Location = new System.Drawing.Point(648, 69);
		this.checkBox_antiCollideBalance.Name = "checkBox_antiCollideBalance";
		this.checkBox_antiCollideBalance.Size = new System.Drawing.Size(129, 16);
		this.checkBox_antiCollideBalance.TabIndex = 88;
		this.checkBox_antiCollideBalance.Text = "antiCollideBalance";
		this.checkBox_antiCollideBalance.UseVisualStyleBackColor = true;
		this.checkBox_antiCollideBalance.CheckedChanged += new System.EventHandler(CheckBox_antiCollideBalance_CheckedChanged);
		this.tx_BoostAccelFactorOnlyItem.Location = new System.Drawing.Point(854, 40);
		this.tx_BoostAccelFactorOnlyItem.Name = "tx_BoostAccelFactorOnlyItem";
		this.tx_BoostAccelFactorOnlyItem.Size = new System.Drawing.Size(100, 21);
		this.tx_BoostAccelFactorOnlyItem.TabIndex = 87;
		this.checkBox_BoostAccelFactorOnlyItem.AutoSize = true;
		this.checkBox_BoostAccelFactorOnlyItem.Location = new System.Drawing.Point(648, 42);
		this.checkBox_BoostAccelFactorOnlyItem.Name = "checkBox_BoostAccelFactorOnlyItem";
		this.checkBox_BoostAccelFactorOnlyItem.Size = new System.Drawing.Size(173, 16);
		this.checkBox_BoostAccelFactorOnlyItem.TabIndex = 86;
		this.checkBox_BoostAccelFactorOnlyItem.Text = "BoostAccelFactorOnlyItem";
		this.checkBox_BoostAccelFactorOnlyItem.UseVisualStyleBackColor = true;
		this.checkBox_BoostAccelFactorOnlyItem.CheckedChanged += new System.EventHandler(CheckBox_BoostAccelFactorOnlyItem_CheckedChanged);
		this.tx_UseExtendedAfterBooster.Location = new System.Drawing.Point(854, 13);
		this.tx_UseExtendedAfterBooster.Name = "tx_UseExtendedAfterBooster";
		this.tx_UseExtendedAfterBooster.Size = new System.Drawing.Size(100, 21);
		this.tx_UseExtendedAfterBooster.TabIndex = 85;
		this.checkBox_UseExtendedAfterBooster.AutoSize = true;
		this.checkBox_UseExtendedAfterBooster.Location = new System.Drawing.Point(648, 15);
		this.checkBox_UseExtendedAfterBooster.Name = "checkBox_UseExtendedAfterBooster";
		this.checkBox_UseExtendedAfterBooster.Size = new System.Drawing.Size(167, 16);
		this.checkBox_UseExtendedAfterBooster.TabIndex = 84;
		this.checkBox_UseExtendedAfterBooster.Text = "UseExtendedAfterBooster";
		this.checkBox_UseExtendedAfterBooster.UseVisualStyleBackColor = true;
		this.checkBox_UseExtendedAfterBooster.CheckedChanged += new System.EventHandler(CheckBox_UseExtendedAfterBooster_CheckedChanged);
		this.tx_DriftGaguePreservePercent.Location = new System.Drawing.Point(518, 553);
		this.tx_DriftGaguePreservePercent.Name = "tx_DriftGaguePreservePercent";
		this.tx_DriftGaguePreservePercent.Size = new System.Drawing.Size(100, 21);
		this.tx_DriftGaguePreservePercent.TabIndex = 83;
		this.checkBox_DriftGaguePreservePercent.AutoSize = true;
		this.checkBox_DriftGaguePreservePercent.Location = new System.Drawing.Point(321, 555);
		this.checkBox_DriftGaguePreservePercent.Name = "checkBox_DriftGaguePreservePercent";
		this.checkBox_DriftGaguePreservePercent.Size = new System.Drawing.Size(175, 16);
		this.checkBox_DriftGaguePreservePercent.TabIndex = 82;
		this.checkBox_DriftGaguePreservePercent.Text = "DriftGaguePreservePercent";
		this.checkBox_DriftGaguePreservePercent.UseVisualStyleBackColor = true;
		this.checkBox_DriftGaguePreservePercent.CheckedChanged += new System.EventHandler(CheckBox_DriftGaguePreservePercent_CheckedChanged);
		this.tx_StartForwardAccelForceSpeed.Location = new System.Drawing.Point(518, 526);
		this.tx_StartForwardAccelForceSpeed.Name = "tx_StartForwardAccelForceSpeed";
		this.tx_StartForwardAccelForceSpeed.Size = new System.Drawing.Size(100, 21);
		this.tx_StartForwardAccelForceSpeed.TabIndex = 81;
		this.checkBox_StartForwardAccelForceSpeed.AutoSize = true;
		this.checkBox_StartForwardAccelForceSpeed.Location = new System.Drawing.Point(321, 528);
		this.checkBox_StartForwardAccelForceSpeed.Name = "checkBox_StartForwardAccelForceSpeed";
		this.checkBox_StartForwardAccelForceSpeed.Size = new System.Drawing.Size(195, 16);
		this.checkBox_StartForwardAccelForceSpeed.TabIndex = 80;
		this.checkBox_StartForwardAccelForceSpeed.Text = "StartForwardAccelForceSpeed";
		this.checkBox_StartForwardAccelForceSpeed.UseVisualStyleBackColor = true;
		this.checkBox_StartForwardAccelForceSpeed.CheckedChanged += new System.EventHandler(CheckBox_StartForwardAccelForceSpeed_CheckedChanged);
		this.tx_StartForwardAccelForceItem.Location = new System.Drawing.Point(518, 499);
		this.tx_StartForwardAccelForceItem.Name = "tx_StartForwardAccelForceItem";
		this.tx_StartForwardAccelForceItem.Size = new System.Drawing.Size(100, 21);
		this.tx_StartForwardAccelForceItem.TabIndex = 79;
		this.checkBox_StartForwardAccelForceItem.AutoSize = true;
		this.checkBox_StartForwardAccelForceItem.Location = new System.Drawing.Point(321, 501);
		this.checkBox_StartForwardAccelForceItem.Name = "checkBox_StartForwardAccelForceItem";
		this.checkBox_StartForwardAccelForceItem.Size = new System.Drawing.Size(183, 16);
		this.checkBox_StartForwardAccelForceItem.TabIndex = 78;
		this.checkBox_StartForwardAccelForceItem.Text = "StartForwardAccelForceItem";
		this.checkBox_StartForwardAccelForceItem.UseVisualStyleBackColor = true;
		this.checkBox_StartForwardAccelForceItem.CheckedChanged += new System.EventHandler(CheckBox_StartForwardAccelForceItem_CheckedChanged);
		this.tx_StartBoosterTimeSpeed.Location = new System.Drawing.Point(518, 472);
		this.tx_StartBoosterTimeSpeed.Name = "tx_StartBoosterTimeSpeed";
		this.tx_StartBoosterTimeSpeed.Size = new System.Drawing.Size(100, 21);
		this.tx_StartBoosterTimeSpeed.TabIndex = 77;
		this.checkBox_StartBoosterTimeSpeed.AutoSize = true;
		this.checkBox_StartBoosterTimeSpeed.Location = new System.Drawing.Point(321, 474);
		this.checkBox_StartBoosterTimeSpeed.Name = "checkBox_StartBoosterTimeSpeed";
		this.checkBox_StartBoosterTimeSpeed.Size = new System.Drawing.Size(157, 16);
		this.checkBox_StartBoosterTimeSpeed.TabIndex = 76;
		this.checkBox_StartBoosterTimeSpeed.Text = "StartBoosterTimeSpeed";
		this.checkBox_StartBoosterTimeSpeed.UseVisualStyleBackColor = true;
		this.checkBox_StartBoosterTimeSpeed.CheckedChanged += new System.EventHandler(CheckBox_StartBoosterTimeSpeed_CheckedChanged);
		this.tx_StartBoosterTimeItem.Location = new System.Drawing.Point(518, 445);
		this.tx_StartBoosterTimeItem.Name = "tx_StartBoosterTimeItem";
		this.tx_StartBoosterTimeItem.Size = new System.Drawing.Size(100, 21);
		this.tx_StartBoosterTimeItem.TabIndex = 75;
		this.checkBox_StartBoosterTimeItem.AutoSize = true;
		this.checkBox_StartBoosterTimeItem.Location = new System.Drawing.Point(321, 447);
		this.checkBox_StartBoosterTimeItem.Name = "checkBox_StartBoosterTimeItem";
		this.checkBox_StartBoosterTimeItem.Size = new System.Drawing.Size(145, 16);
		this.checkBox_StartBoosterTimeItem.TabIndex = 74;
		this.checkBox_StartBoosterTimeItem.Text = "StartBoosterTimeItem";
		this.checkBox_StartBoosterTimeItem.UseVisualStyleBackColor = true;
		this.checkBox_StartBoosterTimeItem.CheckedChanged += new System.EventHandler(CheckBox_StartBoosterTimeItem_CheckedChanged);
		this.tx_BoostAccelFactor.Location = new System.Drawing.Point(518, 418);
		this.tx_BoostAccelFactor.Name = "tx_BoostAccelFactor";
		this.tx_BoostAccelFactor.Size = new System.Drawing.Size(100, 21);
		this.tx_BoostAccelFactor.TabIndex = 73;
		this.checkBox_BoostAccelFactor.AutoSize = true;
		this.checkBox_BoostAccelFactor.Location = new System.Drawing.Point(321, 420);
		this.checkBox_BoostAccelFactor.Name = "checkBox_BoostAccelFactor";
		this.checkBox_BoostAccelFactor.Size = new System.Drawing.Size(123, 16);
		this.checkBox_BoostAccelFactor.TabIndex = 72;
		this.checkBox_BoostAccelFactor.Text = "BoostAccelFactor";
		this.checkBox_BoostAccelFactor.UseVisualStyleBackColor = true;
		this.checkBox_BoostAccelFactor.CheckedChanged += new System.EventHandler(CheckBox_BoostAccelFactor_CheckedChanged);
		this.tx_useExtendedAfterBoosterMore.Location = new System.Drawing.Point(854, 445);
		this.tx_useExtendedAfterBoosterMore.Name = "tx_useExtendedAfterBoosterMore";
		this.tx_useExtendedAfterBoosterMore.Size = new System.Drawing.Size(100, 21);
		this.tx_useExtendedAfterBoosterMore.TabIndex = 127;
		this.checkBox_useExtendedAfterBoosterMore.AutoSize = true;
		this.checkBox_useExtendedAfterBoosterMore.Location = new System.Drawing.Point(648, 447);
		this.checkBox_useExtendedAfterBoosterMore.Name = "checkBox_useExtendedAfterBoosterMore";
		this.checkBox_useExtendedAfterBoosterMore.Size = new System.Drawing.Size(195, 16);
		this.checkBox_useExtendedAfterBoosterMore.TabIndex = 126;
		this.checkBox_useExtendedAfterBoosterMore.Text = "useExtendedAfterBoosterMore";
		this.checkBox_useExtendedAfterBoosterMore.UseVisualStyleBackColor = true;
		this.checkBox_useExtendedAfterBoosterMore.CheckedChanged += new System.EventHandler(checkBox_useExtendedAfterBoosterMore_CheckedChanged);
		this.checkBox_chargeInstAccelGaugeByGrip.AutoSize = true;
		this.checkBox_chargeInstAccelGaugeByGrip.Location = new System.Drawing.Point(648, 231);
		this.checkBox_chargeInstAccelGaugeByGrip.Name = "checkBox_chargeInstAccelGaugeByGrip";
		this.checkBox_chargeInstAccelGaugeByGrip.Size = new System.Drawing.Size(190, 16);
		this.checkBox_chargeInstAccelGaugeByGrip.TabIndex = 128;
		this.checkBox_chargeInstAccelGaugeByGrip.Text = "chargeInstAccelGaugeByGrip";
		this.checkBox_chargeInstAccelGaugeByGrip.UseVisualStyleBackColor = true;
		this.checkBox_chargeInstAccelGaugeByGrip.CheckedChanged += new System.EventHandler(checkBox_chargeInstAccelGaugeByGrip_CheckedChanged);
		this.tx_chargeInstAccelGaugeByGrip.Location = new System.Drawing.Point(854, 229);
		this.tx_chargeInstAccelGaugeByGrip.Name = "tx_chargeInstAccelGaugeByGrip";
		this.tx_chargeInstAccelGaugeByGrip.Size = new System.Drawing.Size(100, 21);
		this.tx_chargeInstAccelGaugeByGrip.TabIndex = 129;
		this.tx_chargeInstAccelGaugeByBoost.Location = new System.Drawing.Point(854, 202);
		this.tx_chargeInstAccelGaugeByBoost.Name = "tx_chargeInstAccelGaugeByBoost";
		this.tx_chargeInstAccelGaugeByBoost.Size = new System.Drawing.Size(100, 21);
		this.tx_chargeInstAccelGaugeByBoost.TabIndex = 131;
		this.checkBox_chargeInstAccelGaugeByBoost.AutoSize = true;
		this.checkBox_chargeInstAccelGaugeByBoost.Location = new System.Drawing.Point(648, 204);
		this.checkBox_chargeInstAccelGaugeByBoost.Name = "checkBox_chargeInstAccelGaugeByBoost";
		this.checkBox_chargeInstAccelGaugeByBoost.Size = new System.Drawing.Size(199, 16);
		this.checkBox_chargeInstAccelGaugeByBoost.TabIndex = 130;
		this.checkBox_chargeInstAccelGaugeByBoost.Text = "chargeInstAccelGaugeByBoost";
		this.checkBox_chargeInstAccelGaugeByBoost.UseVisualStyleBackColor = true;
		this.checkBox_chargeInstAccelGaugeByBoost.CheckedChanged += new System.EventHandler(checkBox_chargeInstAccelGaugeByBoost_CheckedChanged);
		this.tx_chargeInstAccelGaugeByWall.Location = new System.Drawing.Point(854, 256);
		this.tx_chargeInstAccelGaugeByWall.Name = "tx_chargeInstAccelGaugeByWall";
		this.tx_chargeInstAccelGaugeByWall.Size = new System.Drawing.Size(100, 21);
		this.tx_chargeInstAccelGaugeByWall.TabIndex = 133;
		this.checkBox_chargeInstAccelGaugeByWall.AutoSize = true;
		this.checkBox_chargeInstAccelGaugeByWall.Location = new System.Drawing.Point(648, 258);
		this.checkBox_chargeInstAccelGaugeByWall.Name = "checkBox_chargeInstAccelGaugeByWall";
		this.checkBox_chargeInstAccelGaugeByWall.Size = new System.Drawing.Size(190, 16);
		this.checkBox_chargeInstAccelGaugeByWall.TabIndex = 132;
		this.checkBox_chargeInstAccelGaugeByWall.Text = "chargeInstAccelGaugeByWall";
		this.checkBox_chargeInstAccelGaugeByWall.UseVisualStyleBackColor = true;
		this.checkBox_chargeInstAccelGaugeByWall.CheckedChanged += new System.EventHandler(checkBox_chargeInstAccelGaugeByWall_CheckedChanged);
		this.tx_instAccelFactor.Location = new System.Drawing.Point(854, 283);
		this.tx_instAccelFactor.Name = "tx_instAccelFactor";
		this.tx_instAccelFactor.Size = new System.Drawing.Size(100, 21);
		this.tx_instAccelFactor.TabIndex = 137;
		this.checkBox_instAccelFactor.AutoSize = true;
		this.checkBox_instAccelFactor.Location = new System.Drawing.Point(648, 285);
		this.checkBox_instAccelFactor.Name = "checkBox_instAccelFactor";
		this.checkBox_instAccelFactor.Size = new System.Drawing.Size(111, 16);
		this.checkBox_instAccelFactor.TabIndex = 136;
		this.checkBox_instAccelFactor.Text = "instAccelFactor";
		this.checkBox_instAccelFactor.UseVisualStyleBackColor = true;
		this.checkBox_instAccelFactor.CheckedChanged += new System.EventHandler(checkBox_instAccelFactor_CheckedChanged);
		this.tx_instAccelGaugeLength.Location = new System.Drawing.Point(854, 337);
		this.tx_instAccelGaugeLength.Name = "tx_instAccelGaugeLength";
		this.tx_instAccelGaugeLength.Size = new System.Drawing.Size(100, 21);
		this.tx_instAccelGaugeLength.TabIndex = 139;
		this.checkBox_instAccelGaugeLength.AutoSize = true;
		this.checkBox_instAccelGaugeLength.Location = new System.Drawing.Point(648, 339);
		this.checkBox_instAccelGaugeLength.Name = "checkBox_instAccelGaugeLength";
		this.checkBox_instAccelGaugeLength.Size = new System.Drawing.Size(151, 16);
		this.checkBox_instAccelGaugeLength.TabIndex = 138;
		this.checkBox_instAccelGaugeLength.Text = "instAccelGaugeLength";
		this.checkBox_instAccelGaugeLength.UseVisualStyleBackColor = true;
		this.checkBox_instAccelGaugeLength.CheckedChanged += new System.EventHandler(checkBox_instAccelGaugeLength_CheckedChanged);
		this.tx_wallCollGaugeCooldownTime.Location = new System.Drawing.Point(854, 472);
		this.tx_wallCollGaugeCooldownTime.Name = "tx_wallCollGaugeCooldownTime";
		this.tx_wallCollGaugeCooldownTime.Size = new System.Drawing.Size(100, 21);
		this.tx_wallCollGaugeCooldownTime.TabIndex = 145;
		this.checkBox_wallCollGaugeCooldownTime.AutoSize = true;
		this.checkBox_wallCollGaugeCooldownTime.Location = new System.Drawing.Point(648, 474);
		this.checkBox_wallCollGaugeCooldownTime.Name = "checkBox_wallCollGaugeCooldownTime";
		this.checkBox_wallCollGaugeCooldownTime.Size = new System.Drawing.Size(192, 16);
		this.checkBox_wallCollGaugeCooldownTime.TabIndex = 144;
		this.checkBox_wallCollGaugeCooldownTime.Text = "wallCollGaugeCooldownTime";
		this.checkBox_wallCollGaugeCooldownTime.UseVisualStyleBackColor = true;
		this.checkBox_wallCollGaugeCooldownTime.CheckedChanged += new System.EventHandler(checkBox_wallCollGaugeCooldownTime_CheckedChanged);
		this.tx_wallCollGaugeMinVelBound.Location = new System.Drawing.Point(854, 526);
		this.tx_wallCollGaugeMinVelBound.Name = "tx_wallCollGaugeMinVelBound";
		this.tx_wallCollGaugeMinVelBound.Size = new System.Drawing.Size(100, 21);
		this.tx_wallCollGaugeMinVelBound.TabIndex = 147;
		this.checkBox_wallCollGaugeMinVelBound.AutoSize = true;
		this.checkBox_wallCollGaugeMinVelBound.Location = new System.Drawing.Point(648, 528);
		this.checkBox_wallCollGaugeMinVelBound.Name = "checkBox_wallCollGaugeMinVelBound";
		this.checkBox_wallCollGaugeMinVelBound.Size = new System.Drawing.Size(181, 16);
		this.checkBox_wallCollGaugeMinVelBound.TabIndex = 146;
		this.checkBox_wallCollGaugeMinVelBound.Text = "wallCollGaugeMinVelBound";
		this.checkBox_wallCollGaugeMinVelBound.UseVisualStyleBackColor = true;
		this.checkBox_wallCollGaugeMinVelBound.CheckedChanged += new System.EventHandler(checkBox_wallCollGaugeMinVelBound_CheckedChanged);
		this.tx_wallCollGaugeMinVelLoss.Location = new System.Drawing.Point(854, 553);
		this.tx_wallCollGaugeMinVelLoss.Name = "tx_wallCollGaugeMinVelLoss";
		this.tx_wallCollGaugeMinVelLoss.Size = new System.Drawing.Size(100, 21);
		this.tx_wallCollGaugeMinVelLoss.TabIndex = 149;
		this.checkBox_wallCollGaugeMinVelLoss.AutoSize = true;
		this.checkBox_wallCollGaugeMinVelLoss.Location = new System.Drawing.Point(648, 555);
		this.checkBox_wallCollGaugeMinVelLoss.Name = "checkBox_wallCollGaugeMinVelLoss";
		this.checkBox_wallCollGaugeMinVelLoss.Size = new System.Drawing.Size(173, 16);
		this.checkBox_wallCollGaugeMinVelLoss.TabIndex = 148;
		this.checkBox_wallCollGaugeMinVelLoss.Text = "wallCollGaugeMinVelLoss";
		this.checkBox_wallCollGaugeMinVelLoss.UseVisualStyleBackColor = true;
		this.checkBox_wallCollGaugeMinVelLoss.CheckedChanged += new System.EventHandler(checkBox_wallCollGaugeMinVelLoss_CheckedChanged);
		this.tx_wallCollGaugeMaxVelLoss.Location = new System.Drawing.Point(854, 499);
		this.tx_wallCollGaugeMaxVelLoss.Name = "tx_wallCollGaugeMaxVelLoss";
		this.tx_wallCollGaugeMaxVelLoss.Size = new System.Drawing.Size(100, 21);
		this.tx_wallCollGaugeMaxVelLoss.TabIndex = 151;
		this.checkBox_wallCollGaugeMaxVelLoss.AutoSize = true;
		this.checkBox_wallCollGaugeMaxVelLoss.Location = new System.Drawing.Point(648, 501);
		this.checkBox_wallCollGaugeMaxVelLoss.Name = "checkBox_wallCollGaugeMaxVelLoss";
		this.checkBox_wallCollGaugeMaxVelLoss.Size = new System.Drawing.Size(177, 16);
		this.checkBox_wallCollGaugeMaxVelLoss.TabIndex = 150;
		this.checkBox_wallCollGaugeMaxVelLoss.Text = "wallCollGaugeMaxVelLoss";
		this.checkBox_wallCollGaugeMaxVelLoss.UseVisualStyleBackColor = true;
		this.checkBox_wallCollGaugeMaxVelLoss.CheckedChanged += new System.EventHandler(checkBox_wallCollGaugeMaxVelLoss_CheckedChanged);
		this.checkBox_instAccelGaugeMinUsable.AutoSize = true;
		this.checkBox_instAccelGaugeMinUsable.Location = new System.Drawing.Point(648, 366);
		this.checkBox_instAccelGaugeMinUsable.Name = "checkBox_instAccelGaugeMinUsable";
		this.checkBox_instAccelGaugeMinUsable.Size = new System.Drawing.Size(173, 16);
		this.checkBox_instAccelGaugeMinUsable.TabIndex = 152;
		this.checkBox_instAccelGaugeMinUsable.Text = "instAccelGaugeMinUsable";
		this.checkBox_instAccelGaugeMinUsable.UseVisualStyleBackColor = true;
		this.checkBox_instAccelGaugeMinUsable.CheckedChanged += new System.EventHandler(checkBox_instAccelGaugeMinUsable_CheckedChanged);
		this.tx_instAccelGaugeMinUsable.Location = new System.Drawing.Point(854, 364);
		this.tx_instAccelGaugeMinUsable.Name = "tx_instAccelGaugeMinUsable";
		this.tx_instAccelGaugeMinUsable.Size = new System.Drawing.Size(100, 21);
		this.tx_instAccelGaugeMinUsable.TabIndex = 153;
		this.checkBox_instAccelGaugeCooldownTime.AutoSize = true;
		this.checkBox_instAccelGaugeCooldownTime.Location = new System.Drawing.Point(648, 312);
		this.checkBox_instAccelGaugeCooldownTime.Name = "checkBox_instAccelGaugeCooldownTime";
		this.checkBox_instAccelGaugeCooldownTime.Size = new System.Drawing.Size(199, 16);
		this.checkBox_instAccelGaugeCooldownTime.TabIndex = 158;
		this.checkBox_instAccelGaugeCooldownTime.Text = "instAccelGaugeCooldownTime";
		this.checkBox_instAccelGaugeCooldownTime.UseVisualStyleBackColor = true;
		this.checkBox_instAccelGaugeCooldownTime.CheckedChanged += new System.EventHandler(checkBox_instAccelGaugeCooldownTime_CheckedChanged);
		this.tx_instAccelGaugeCooldownTime.Location = new System.Drawing.Point(854, 310);
		this.tx_instAccelGaugeCooldownTime.Name = "tx_instAccelGaugeCooldownTime";
		this.tx_instAccelGaugeCooldownTime.Size = new System.Drawing.Size(100, 21);
		this.tx_instAccelGaugeCooldownTime.TabIndex = 159;
		this.checkBox_instAccelGaugeMinVelBound.AutoSize = true;
		this.checkBox_instAccelGaugeMinVelBound.Location = new System.Drawing.Point(648, 393);
		this.checkBox_instAccelGaugeMinVelBound.Name = "checkBox_instAccelGaugeMinVelBound";
		this.checkBox_instAccelGaugeMinVelBound.Size = new System.Drawing.Size(188, 16);
		this.checkBox_instAccelGaugeMinVelBound.TabIndex = 160;
		this.checkBox_instAccelGaugeMinVelBound.Text = "instAccelGaugeMinVelBound";
		this.checkBox_instAccelGaugeMinVelBound.UseVisualStyleBackColor = true;
		this.checkBox_instAccelGaugeMinVelBound.CheckedChanged += new System.EventHandler(checkBox_instAccelGaugeMinVelBound_CheckedChanged);
		this.checkBox_instAccelGaugeMinVelLoss.AutoSize = true;
		this.checkBox_instAccelGaugeMinVelLoss.Location = new System.Drawing.Point(648, 420);
		this.checkBox_instAccelGaugeMinVelLoss.Name = "checkBox_instAccelGaugeMinVelLoss";
		this.checkBox_instAccelGaugeMinVelLoss.Size = new System.Drawing.Size(180, 16);
		this.checkBox_instAccelGaugeMinVelLoss.TabIndex = 161;
		this.checkBox_instAccelGaugeMinVelLoss.Text = "instAccelGaugeMinVelLoss";
		this.checkBox_instAccelGaugeMinVelLoss.UseVisualStyleBackColor = true;
		this.checkBox_instAccelGaugeMinVelLoss.CheckedChanged += new System.EventHandler(checkBox_instAccelGaugeMinVelLoss_CheckedChanged);
		this.tx_instAccelGaugeMinVelBound.Location = new System.Drawing.Point(854, 391);
		this.tx_instAccelGaugeMinVelBound.Name = "tx_instAccelGaugeMinVelBound";
		this.tx_instAccelGaugeMinVelBound.Size = new System.Drawing.Size(100, 21);
		this.tx_instAccelGaugeMinVelBound.TabIndex = 162;
		this.tx_instAccelGaugeMinVelLoss.Location = new System.Drawing.Point(854, 418);
		this.tx_instAccelGaugeMinVelLoss.Name = "tx_instAccelGaugeMinVelLoss";
		this.tx_instAccelGaugeMinVelLoss.Size = new System.Drawing.Size(100, 21);
		this.tx_instAccelGaugeMinVelLoss.TabIndex = 163;
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(974, 587);
		base.Controls.Add(this.tx_instAccelGaugeMinVelLoss);
		base.Controls.Add(this.tx_instAccelGaugeMinVelBound);
		base.Controls.Add(this.checkBox_instAccelGaugeMinVelLoss);
		base.Controls.Add(this.checkBox_instAccelGaugeMinVelBound);
		base.Controls.Add(this.tx_instAccelGaugeCooldownTime);
		base.Controls.Add(this.checkBox_instAccelGaugeCooldownTime);
		base.Controls.Add(this.tx_instAccelGaugeMinUsable);
		base.Controls.Add(this.checkBox_instAccelGaugeMinUsable);
		base.Controls.Add(this.tx_wallCollGaugeMaxVelLoss);
		base.Controls.Add(this.checkBox_wallCollGaugeMaxVelLoss);
		base.Controls.Add(this.tx_wallCollGaugeMinVelLoss);
		base.Controls.Add(this.checkBox_wallCollGaugeMinVelLoss);
		base.Controls.Add(this.tx_wallCollGaugeMinVelBound);
		base.Controls.Add(this.checkBox_wallCollGaugeMinVelBound);
		base.Controls.Add(this.tx_wallCollGaugeCooldownTime);
		base.Controls.Add(this.checkBox_wallCollGaugeCooldownTime);
		base.Controls.Add(this.tx_instAccelGaugeLength);
		base.Controls.Add(this.checkBox_instAccelGaugeLength);
		base.Controls.Add(this.tx_instAccelFactor);
		base.Controls.Add(this.checkBox_instAccelFactor);
		base.Controls.Add(this.tx_chargeInstAccelGaugeByWall);
		base.Controls.Add(this.checkBox_chargeInstAccelGaugeByWall);
		base.Controls.Add(this.tx_chargeInstAccelGaugeByBoost);
		base.Controls.Add(this.checkBox_chargeInstAccelGaugeByBoost);
		base.Controls.Add(this.tx_chargeInstAccelGaugeByGrip);
		base.Controls.Add(this.checkBox_chargeInstAccelGaugeByGrip);
		base.Controls.Add(this.tx_useExtendedAfterBoosterMore);
		base.Controls.Add(this.checkBox_useExtendedAfterBoosterMore);
		base.Controls.Add(this.tx_dualTransLowSpeed);
		base.Controls.Add(this.checkBox_dualTransLowSpeed);
		base.Controls.Add(this.tx_dualMulAccelFactor);
		base.Controls.Add(this.checkBox_dualMulAccelFactor);
		base.Controls.Add(this.tx_dualBoosterTickMax);
		base.Controls.Add(this.checkBox_dualBoosterTickMax);
		base.Controls.Add(this.tx_dualBoosterTickMin);
		base.Controls.Add(this.checkBox_dualBoosterTickMin);
		base.Controls.Add(this.tx_antiCollideBalance);
		base.Controls.Add(this.checkBox_antiCollideBalance);
		base.Controls.Add(this.tx_BoostAccelFactorOnlyItem);
		base.Controls.Add(this.checkBox_BoostAccelFactorOnlyItem);
		base.Controls.Add(this.tx_UseExtendedAfterBooster);
		base.Controls.Add(this.checkBox_UseExtendedAfterBooster);
		base.Controls.Add(this.tx_DriftGaguePreservePercent);
		base.Controls.Add(this.checkBox_DriftGaguePreservePercent);
		base.Controls.Add(this.tx_StartForwardAccelForceSpeed);
		base.Controls.Add(this.checkBox_StartForwardAccelForceSpeed);
		base.Controls.Add(this.tx_StartForwardAccelForceItem);
		base.Controls.Add(this.checkBox_StartForwardAccelForceItem);
		base.Controls.Add(this.tx_StartBoosterTimeSpeed);
		base.Controls.Add(this.checkBox_StartBoosterTimeSpeed);
		base.Controls.Add(this.tx_StartBoosterTimeItem);
		base.Controls.Add(this.checkBox_StartBoosterTimeItem);
		base.Controls.Add(this.tx_BoostAccelFactor);
		base.Controls.Add(this.checkBox_BoostAccelFactor);
		base.Controls.Add(this.tx_TransAccelFactor);
		base.Controls.Add(this.checkBox_TransAccelFactor);
		base.Controls.Add(this.tx_SuperBoosterTime);
		base.Controls.Add(this.checkBox_SuperBoosterTime);
		base.Controls.Add(this.tx_AnimalBoosterTime);
		base.Controls.Add(this.checkBox_AnimalBoosterTime);
		base.Controls.Add(this.tx_TeamBoosterTime);
		base.Controls.Add(this.checkBox_TeamBoosterTime);
		base.Controls.Add(this.tx_ItemBoosterTime);
		base.Controls.Add(this.checkBox_ItemBoosterTime);
		base.Controls.Add(this.tx_NormalBoosterTime);
		base.Controls.Add(this.checkBox_NormalBoosterTime);
		base.Controls.Add(this.tx_DriftMaxGauge);
		base.Controls.Add(this.checkBox_DriftMaxGauge);
		base.Controls.Add(this.tx_SteerLeanFactor);
		base.Controls.Add(this.checkBox_SteerLeanFactor);
		base.Controls.Add(this.tx_DriftLeanFactor);
		base.Controls.Add(this.checkBox_DriftLeanFactor);
		base.Controls.Add(this.tx_CornerDrawFactor);
		base.Controls.Add(this.checkBox_CornerDrawFactor);
		base.Controls.Add(this.tx_DriftEscapeForce);
		base.Controls.Add(this.checkBox_DriftEscapeForce);
		base.Controls.Add(this.tx_DriftSlipFactor);
		base.Controls.Add(this.checkBox_DriftSlipFactor);
		base.Controls.Add(this.tx_DriftTriggerTime);
		base.Controls.Add(this.checkBox_DriftTriggerTime);
		base.Controls.Add(this.tx_DriftTriggerFactor);
		base.Controls.Add(this.checkBox_DriftTriggerFactor);
		base.Controls.Add(this.tx_RearGripFactor);
		base.Controls.Add(this.checkBox_RearGripFactor);
		base.Controls.Add(this.tx_FrontGripFactor);
		base.Controls.Add(this.checkBox_FrontGripFactor);
		base.Controls.Add(this.tx_SteerConstraint);
		base.Controls.Add(this.checkBox_SteerConstraint);
		base.Controls.Add(this.tx_MaxSteerAngle);
		base.Controls.Add(this.checkBox_MaxSteerAngle);
		base.Controls.Add(this.tx_SlipBrakeForce);
		base.Controls.Add(this.checkBox_SlipBrakeForce);
		base.Controls.Add(this.tx_GripBrakeForce);
		base.Controls.Add(this.checkBox_GripBrakeForce);
		base.Controls.Add(this.tx_BackwardAccelForce);
		base.Controls.Add(this.checkBox_BackwardAccelForce);
		base.Controls.Add(this.tx_ForwardAccelForce);
		base.Controls.Add(this.checkBox_ForwardAccelForce);
		base.Controls.Add(this.tx_DragFactor);
		base.Controls.Add(this.checkBox_DragFactor);
		base.Controls.Add(this.tx_AirFriction);
		base.Controls.Add(this.checkBox_AirFriction);
		base.Controls.Add(this.tx_Mass);
		base.Controls.Add(this.checkBox_Mass);
		base.Controls.Add(this.tx_BikeRearWheel);
		base.Controls.Add(this.checkBox_BikeRearWheel);
		base.Controls.Add(this.tx_motorcycleType);
		base.Controls.Add(this.checkBox_motorcycleType);
		base.Controls.Add(this.tx_UseTransformBooster);
		base.Controls.Add(this.checkBox_UseTransformBooster);
		base.Controls.Add(this.tx_SpecialSlotCapacity);
		base.Controls.Add(this.checkBox_SpecialSlotCapacity);
		base.Controls.Add(this.tx_ItemSlotCapacity);
		base.Controls.Add(this.checkBox_ItemSlotCapacity);
		base.Controls.Add(this.tx_SpeedSlotCapacity);
		base.Controls.Add(this.checkBox_SpeedSlotCapacity);
		base.Controls.Add(this.tx_chargeBoostBySpeed);
		base.Controls.Add(this.checkBox_chargeBoostBySpeed);
		base.Controls.Add(this.tx_driftBoostTick);
		base.Controls.Add(this.checkBox_driftBoostTick);
		base.Controls.Add(this.tx_driftBoostMulAccelFactor);
		base.Controls.Add(this.checkBox_driftBoostMulAccelFactor);
		base.Controls.Add(this.tx_draftTick);
		base.Controls.Add(this.checkBox_draftTick);
		base.Controls.Add(this.tx_draftMulAccelFactor);
		base.Controls.Add(this.checkBox_draftMulAccelFactor);
		this.Font = new System.Drawing.Font("굴림", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.Name = "KartSpecDialog";
		this.Text = "KartSpec";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
