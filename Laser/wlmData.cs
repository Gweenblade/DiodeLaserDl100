using System.Runtime.InteropServices;

// a namespace with a "WLM" class covering the header of the wlmData.dll since headers, includes and macros are not supported by C#
namespace wlmData
{
    unsafe public class WLM
    {

        // ***********  Functions for general usage  ****************************
        [DllImport("wlmData.dll")]  public static extern long   Instantiate(long RFC, long Mode, long P1, long P2) ;
        //	void __stdcall CallbackProc(long Mode, long IntVal, double DblVal) ;
        //	void __stdcall CallbackProcEx(long Ver, long Mode, long IntVal, double DblVal, long Res1) ;
        [DllImport("wlmData.dll")]  public static extern long   WaitForWLMEvent(long *Mode, long *IntVal, double *DblVal) ;
        [DllImport("wlmData.dll")]  public static extern long   WaitForWLMEventEx(long* Ver, long *Mode, long *IntVal, double *DblVal, long *Res1);
        [DllImport("wlmData.dll")]  public static extern long   ControlWLM(long Action, long App, long Ver) ;
    	[DllImport("wlmData.dll")]  public static extern long   ControlWLMEx(long Action, long App, long Ver, long Ex1, long Ex2) ;
    	[DllImport("wlmData.dll")]  public static extern long   SetMeasurementDelayMethod(long Mode, long Delay) ;
    	[DllImport("wlmData.dll")]  public static extern long   SetWLMPriority(long PPC, long Res1, long Res2) ;
    	[DllImport("wlmData.dll")]  public static extern long   PresetWLMIndex(long Ver) ;

    	[DllImport("wlmData.dll")]  public static extern long   GetWLMVersion(long Ver) ;
    	[DllImport("wlmData.dll")]  public static extern long   GetWLMIndex(long Ver) ;
    	[DllImport("wlmData.dll")]  public static extern long   GetWLMCount(long V) ;


        // ***********  General Get... & Set...-functions  **********************
        [DllImport("wlmData.dll")]  public static extern double GetWavelength(double WL);
        [DllImport("wlmData.dll")]  public static extern double GetWavelength2(double WL2);
        [DllImport("wlmData.dll")]  public static extern double GetWavelengthNum(long num, double WL) ;
        [DllImport("wlmData.dll")]  public static extern double GetCalWavelength(long ba, double WL) ;
        [DllImport("wlmData.dll")]  public static extern double GetFrequency(double F);
        [DllImport("wlmData.dll")]  public static extern double GetFrequency2(double F2);
        [DllImport("wlmData.dll")]  public static extern double GetFrequencyNum(long num, double F) ;
        [DllImport("wlmData.dll")]  public static extern double GetDistance(double D) ;
        [DllImport("wlmData.dll")]  public static extern double GetAnalogIn(double AI) ;
	    [DllImport("wlmData.dll")]  public static extern double GetTemperature(double T) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetTemperature(double T) ;

	    [DllImport("wlmData.dll")]  public static extern ushort GetResultMode(ushort RM) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetResultMode(ushort RM) ;
	    [DllImport("wlmData.dll")]  public static extern ushort GetRange(ushort R) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetRange(ushort R) ;
	    [DllImport("wlmData.dll")]  public static extern ushort GetPulseMode(ushort PM) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetPulseMode(ushort PM) ;
	    [DllImport("wlmData.dll")]  public static extern ushort GetWideMode(ushort WM) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetWideMode(ushort WM) ;

	    [DllImport("wlmData.dll")]  public static extern long   GetDisplayMode(long DM) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetDisplayMode(long DM) ;
	    [DllImport("wlmData.dll")]  public static extern bool   GetFastMode(bool FM) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetFastMode(bool FM) ;

	    [DllImport("wlmData.dll")]  public static extern long   GetSwitcherMode(long SM) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetSwitcherMode(long SM) ;
	    [DllImport("wlmData.dll")]  public static extern long   GetSwitcherChannel(long CH) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetSwitcherChannel(long CH) ;
	    [DllImport("wlmData.dll")]  public static extern long   GetSwitcherSignalStates(long Signal, long *Use, long *Show) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetSwitcherSignalStates(long Signal, long Use, long Show) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetSwitcherSignal(long Signal, long Use, long Show) ;

	    [DllImport("wlmData.dll")]  public static extern long   GetAutoCalMode(long ACM) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetAutoCalMode(long ACM) ;
	    [DllImport("wlmData.dll")]  public static extern long   GetAutoCalSetting(long ACS, long *val, long Res1, long *Res2) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetAutoCalSetting(long ACS, long val, long Res1, long Res2) ;

	    [DllImport("wlmData.dll")]  public static extern long   GetChannelsCount(long C) ;

	    [DllImport("wlmData.dll")]  public static extern ushort GetOperationState(ushort Op) ;
	    [DllImport("wlmData.dll")]  public static extern long   Operation(ushort Op) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetOperationFile(char *lpFile) ;
	    [DllImport("wlmData.dll")]  public static extern long   Calibration(long Type, long Unit, double Value, long Channel) ;
	    [DllImport("wlmData.dll")]  public static extern long   RaiseMeasurementEvent(long Mode) ;
	    [DllImport("wlmData.dll")]  public static extern long   TriggerMeasurement(long Action) ;

	    [DllImport("wlmData.dll")]  public static extern bool   GetLinkState(bool LS) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetLinkState(bool LS) ;
	    [DllImport("wlmData.dll")]  public static extern void   LinkSettingsDlg() ;

	    [DllImport("wlmData.dll")]  public static extern long   GetPatternItemSize(long Index) ;
	    [DllImport("wlmData.dll")]  public static extern long   GetPatternItemCount(long Index) ;
	    [DllImport("wlmData.dll")]  public static extern long   GetPattern(long Index) ;
	    [DllImport("wlmData.dll")]  public static extern long   GetPatternNum(long Chn, long Index) ;
	    [DllImport("wlmData.dll")]  public static extern long   GetPatternData(long Index, ulong PArray) ;
        [DllImport("wlmData.dll")]  public static extern long   GetPatternDataNum(long Chn, long Index, ulong PArray);
	    [DllImport("wlmData.dll")]  public static extern long   SetPattern(long Index, long iEnable) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetPatternData(long Index, ulong PArray) ;

	    [DllImport("wlmData.dll")]  public static extern bool   GetAnalysisMode(bool AM) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetAnalysisMode(bool AM) ;
	    [DllImport("wlmData.dll")]  public static extern long   GetAnalysisItemSize(long Index) ;
	    [DllImport("wlmData.dll")]  public static extern long   GetAnalysisItemCount(long Index) ;
	    [DllImport("wlmData.dll")]  public static extern long   GetAnalysis(long Index) ;
	    [DllImport("wlmData.dll")]  public static extern long   GetAnalysisData(long Index, ulong PArray) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetAnalysis(long Index, long iEnable) ;
	    [DllImport("wlmData.dll")]  public static extern double GetLinewidth(long Index, double LW) ;

	    [DllImport("wlmData.dll")]  public static extern long   GetMinPeak(long M1) ;
	    [DllImport("wlmData.dll")]  public static extern long   GetMinPeak2(long M2) ;
	    [DllImport("wlmData.dll")]  public static extern long   GetMaxPeak(long X1) ;
	    [DllImport("wlmData.dll")]  public static extern long   GetMaxPeak2(long X2) ;
	    [DllImport("wlmData.dll")]  public static extern long   GetAvgPeak(long A1) ;
	    [DllImport("wlmData.dll")]  public static extern long   GetAvgPeak2(long A2) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetAvgPeak(long PA) ;

	    [DllImport("wlmData.dll")]  public static extern long   GetAmplitudeNum(long num, long Index, long A) ;
	    [DllImport("wlmData.dll")]  public static extern double GetIntensityNum(long num, double I) ;
	    [DllImport("wlmData.dll")]  public static extern double GetPowerNum(long num, double P) ;


// ***********  Deviation (Laser Control) and PID-functions  ************
	    [DllImport("wlmData.dll")]  public static extern bool   GetDeviationMode(bool DM) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetDeviationMode(bool DM) ;
	    [DllImport("wlmData.dll")]  public static extern double GetDeviationReference(double DR) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetDeviationReference(double DR) ;
	    [DllImport("wlmData.dll")]  public static extern long   GetDeviationSensitivity(long DS) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetDeviationSensitivity(long DS) ;
	    [DllImport("wlmData.dll")]  public static extern double GetDeviationSignal(double DS) ;
	    [DllImport("wlmData.dll")]  public static extern double GetDeviationSignalNum(long Port, double DS) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetDeviationSignal(double DS) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetDeviationSignalNum(long Port, double DS) ;
	    [DllImport("wlmData.dll")]  public static extern double RaiseDeviationSignal(long iType, double dSignal) ;

	    [DllImport("wlmData.dll")]  public static extern long   GetPIDCourse(char *PIDC) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetPIDCourse(char *PIDC) ;
	    [DllImport("wlmData.dll")]  public static extern long   GetPIDCourseNum(long Port, char *PIDC) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetPIDCourseNum(long Port, char *PIDC) ;
	    [DllImport("wlmData.dll")]  public static extern long   GetPIDSetting(long PS, long Port, long *iSet, double *dSet) ;
	    [DllImport("wlmData.dll")]  public static extern long   SetPIDSetting(long PS, long Port, long iSet, double dSet) ;
	    [DllImport("wlmData.dll")]  public static extern long   ClearPIDHistory(long Port) ;


// ***********  Other...-functions  *************************************
	    [DllImport("wlmData.dll")]  public static extern double ConvertUnit(double Val, long uFrom, long uTo) ;
	    [DllImport("wlmData.dll")]  public static extern double ConvertDeltaUnit(double Base, double Delta, long uBase, long uFrom, long uTo) ;


// ***********  Constants  **********************************************

        // Instantiating Constants for 'RFC' parameter
        public const int cInstCheckForWLM = -1;
        public const int cInstResetCalc = 0;
        public const int cInstReturnMode = cInstResetCalc;
        public const int cInstNotification = 1;
        public const int cInstCopyPattern = 2;
        public const int cInstCopyAnalysis = cInstCopyPattern;
        public const int cInstControlWLM = 3;
        public const int cInstControlDelay = 4;
        public const int cInstControlPriority = 5;

        // Notification Constants for 'Mode' parameter
        public const int cNotifyInstallCallback = 0;
        public const int cNotifyRemoveCallback = 1;
        public const int cNotifyInstallWaitEvent = 2;
        public const int cNotifyRemoveWaitEvent = 3;
        public const int cNotifyInstallCallbackEx = 4;
        public const int cNotifyInstallWaitEventEx = 5;

        // ResultError Constants of Set...-functions
        public const int ResERR_NoErr = 0;
        public const int ResERR_WlmMissing = -1;
        public const int ResERR_CouldNotSet = -2;
        public const int ResERR_ParmOutOfRange = -3;
        public const int ResERR_WlmOutOfResources = -4;
        public const int ResERR_WlmInternalError = -5;
        public const int ResERR_NotAvailable = -6;
        public const int ResERR_WlmBusy = -7;
        public const int ResERR_NotInMeasurementMode = -8;
        public const int ResERR_OnlyInMeasurementMode = -9;
        public const int ResERR_ChannelNotAvailable = -10;
        public const int ResERR_ChannelTemporarilyNotAvailable = -11;
        public const int ResERR_CalOptionNotAvailable = -12;
        public const int ResERR_CalWavelengthOutOfRange = -13;
        public const int ResERR_BadCalibrationSignal = -14;
        public const int ResERR_UnitNotAvailable = -15;

        // Mode Constants for Callback-Export and WaitForWLMEvent-function
        public const int cmiResultMode = 1;
        public const int cmiRange = 2;
        public const int cmiPulseMode = 3;
        public const int cmiWideMode = 4;
        public const int cmiFastMode = 5;
        public const int cmiExposureMode = 6;
        public const int cmiExposureValue1 = 7;
        public const int cmiExposureValue2 = 8;
        public const int cmiDelay = 9;
        public const int cmiShift = 10;
        public const int cmiShift2 = 11;
        public const int cmiReduced = 12;
        public const int cmiReduce = cmiReduced;
        public const int cmiScale = 13;
        public const int cmiTemperature = 14;
        public const int cmiLink = 15;
        public const int cmiOperation = 16;
        public const int cmiDisplayMode = 17;
        public const int cmiPattern1a = 18;
        public const int cmiPattern1b = 19;
        public const int cmiPattern2a = 20;
        public const int cmiPattern2b = 21;
        public const int cmiMin1 = 22;
        public const int cmiMax1 = 23;
        public const int cmiMin2 = 24;
        public const int cmiMax2 = 25;
        public const int cmiNowTick = 26;
        public const int cmiCallback = 27;
        public const int cmiFrequency1 = 28;
        public const int cmiFrequency2 = 29;
        public const int cmiDLLDetach = 30;
        public const int cmiVersion = 31;
        public const int cmiAnalysisMode = 32;
        public const int cmiDeviationMode = 33;
        public const int cmiDeviationReference = 34;
        public const int cmiDeviationSensitivity = 35;
        public const int cmiAppearance = 36;
        public const int cmiAutoCalMode = 37;
        public const int cmiWavelength1 = 42;
        public const int cmiWavelength2 = 43;
        public const int cmiLinewidth = 44;
        public const int cmiLinkDlg = 56;
        public const int cmiAnalysis = 57;
        public const int cmiAnalogIn = 66;
        public const int cmiAnalogOut = 67;
        public const int cmiDistance = 69;
        public const int cmiWavelength3 = 90;
        public const int cmiWavelength4 = 91;
        public const int cmiWavelength5 = 92;
        public const int cmiWavelength6 = 93;
        public const int cmiWavelength7 = 94;
        public const int cmiWavelength8 = 95;
        public const int cmiVersion0 = cmiVersion;
        public const int cmiVersion1 = 96;
        public const int cmiDLLAttach = 121;
        public const int cmiSwitcherSignal = 123;
        public const int cmiSwitcherMode = 124;
        public const int cmiExposureValue11 = cmiExposureValue1;
        public const int cmiExposureValue12 = 125;
        public const int cmiExposureValue13 = 126;
        public const int cmiExposureValue14 = 127;
        public const int cmiExposureValue15 = 128;
        public const int cmiExposureValue16 = 129;
        public const int cmiExposureValue17 = 130;
        public const int cmiExposureValue18 = 131;
        public const int cmiExposureValue21 = cmiExposureValue2;
        public const int cmiExposureValue22 = 132;
        public const int cmiExposureValue23 = 133;
        public const int cmiExposureValue24 = 134;
        public const int cmiExposureValue25 = 135;
        public const int cmiExposureValue26 = 136;
        public const int cmiExposureValue27 = 137;
        public const int cmiExposureValue28 = 138;
        public const int cmiPatternAverage = 139;
        public const int cmiPatternAvg1 = 140;
        public const int cmiPatternAvg2 = 141;
        public const int cmiAnalogOut1 = cmiAnalogOut;
        public const int cmiAnalogOut2 = 142;
        public const int cmiMin11 = cmiMin1;
        public const int cmiMin12 = 146;
        public const int cmiMin13 = 147;
        public const int cmiMin14 = 148;
        public const int cmiMin15 = 149;
        public const int cmiMin16 = 150;
        public const int cmiMin17 = 151;
        public const int cmiMin18 = 152;
        public const int cmiMin21 = cmiMin2;
        public const int cmiMin22 = 153;
        public const int cmiMin23 = 154;
        public const int cmiMin24 = 155;
        public const int cmiMin25 = 156;
        public const int cmiMin26 = 157;
        public const int cmiMin27 = 158;
        public const int cmiMin28 = 159;
        public const int cmiMax11 = cmiMax1;
        public const int cmiMax12 = 160;
        public const int cmiMax13 = 161;
        public const int cmiMax14 = 162;
        public const int cmiMax15 = 163;
        public const int cmiMax16 = 164;
        public const int cmiMax17 = 165;
        public const int cmiMax18 = 166;
        public const int cmiMax21 = cmiMax2;
        public const int cmiMax22 = 167;
        public const int cmiMax23 = 168;
        public const int cmiMax24 = 169;
        public const int cmiMax25 = 170;
        public const int cmiMax26 = 171;
        public const int cmiMax27 = 172;
        public const int cmiMax28 = 173;
        public const int cmiAvg11 = cmiPatternAvg1;
        public const int cmiAvg12 = 174;
        public const int cmiAvg13 = 175;
        public const int cmiAvg14 = 176;
        public const int cmiAvg15 = 177;
        public const int cmiAvg16 = 178;
        public const int cmiAvg17 = 179;
        public const int cmiAvg18 = 180;
        public const int cmiAvg21 = cmiPatternAvg2;
        public const int cmiAvg22 = 181;
        public const int cmiAvg23 = 182;
        public const int cmiAvg24 = 183;
        public const int cmiAvg25 = 184;
        public const int cmiAvg26 = 185;
        public const int cmiAvg27 = 186;
        public const int cmiAvg28 = 187;
        public const int cmiPatternAnalysisWritten = 202;
        public const int cmiSwitcherChannel = 203;
        public const int cmiAnalogOut3 = 237;
        public const int cmiAnalogOut4 = 238;
        public const int cmiAnalogOut5 = 239;
        public const int cmiAnalogOut6 = 240;
        public const int cmiAnalogOut7 = 241;
        public const int cmiAnalogOut8 = 242;
        public const int cmiIntensity = 251;
        public const int cmiPower = 267;
        public const int cmiPIDCourse = 1030;
        public const int cmiPIDUseT = 1031;
        public const int cmiPID_T = 1033;
        public const int cmiPID_P = 1034;
        public const int cmiPID_I = 1035;
        public const int cmiPID_D = 1036;
        public const int cmiDeviationSensitivityDim = 1040;
        public const int cmiDeviationSensitivityFactor = 1037;
        public const int cmiDeviationPolarity = 1038;
        public const int cmiDeviationSensitivityEx = 1039;
        public const int cmiDeviationUnit = 1041;
        public const int cmiPIDConstdt = 1059;
        public const int cmiPID_dt = 1060;
        public const int cmiPID_AutoClearHistory = 1061;
        public const int cmiAutoCalPeriod = 1120;
        public const int cmiAutoCalUnit = 1121;
        public const int cmiServerInitialized = 1124;

        // WLM Control Mode Constants
        public const int cCtrlWLMShow = 0x01;
        public const int cCtrlWLMHide = 0x02;
        public const int cCtrlWLMExit = 0x03;
        public const int cCtrlWLMWait = 0x10;
        public const int cCtrlWLMStartSilent = 0x20;
        public const int cCtrlWLMSilent = 0x40;

        // Operation Mode Constants (for "Operation" and "GetOperationState" functions)
        public const int cStop = 0x00;
        public const int cAdjustment = 0x01;
        public const int cMeasurement = 0x02;

        // Base Operation Constants (To be used exclusively, only one of this list at a time,
        // but still can be combined with "Measurement Action Addition Constants". See below.)
        public const int cCtrlStopAll = cStop;
        public const int cCtrlStartAdjustment = cAdjustment;
        public const int cCtrlStartMeasurement = cMeasurement;
        public const int cCtrlStartRecord = 0x04;
        public const int cCtrlStartReplay = 0x08;
        public const int cCtrlStoreArray = 0x10;
        public const int cCtrlLoadArray = 0x20;

        // Additional Operation Flag Constants (combine with "Base Operation Constants" above.)
        public const int cCtrlDontOverwrite = 0x0000;
        public const int cCtrlOverwrite = 0x1000;  // don't combine with cCtrlFileDialog
        public const int cCtrlFileGiven = 0x0000;
        public const int cCtrlFileDialog = 0x2000; // don't combine with cCtrlOverwrite and cCtrlFileASCII
        public const int cCtrlFileBinary = 0x0000; // *.smr, *.ltr
        public const int cCtrlFileASCII = 0x4000;  // *.smx, *.ltx, don't combine with cCtrlFileDialog

        // Measurement Control Mode Constants
        public const int cCtrlMeasDelayRemove = 0;
        public const int cCtrlMeasDelayGenerally = 1;
        public const int cCtrlMeasDelayOnce = 2;
        public const int cCtrlMeasDelayDenyUntil = 3;
        public const int cCtrlMeasDelayIdleOnce = 4;
        public const int cCtrlMeasDelayIdleEach = 5;
        public const int cCtrlMeasDelayDefault = 6;

        // Measurement Triggering Action Constants
        public const int cCtrlMeasurementContinue = 0;
        public const int cCtrlMeasurementInterrupt = 1;
        public const int cCtrlMeasurementTriggerPoll = 2;
        public const int cCtrlMeasurementTriggerSuccess = 3;

        // ExposureRange Constants
        public const int cExpoMin = 0;
        public const int cExpoMax = 1;
        public const int cExpo2Min = 2;
        public const int cExpo2Max = 3;

        // Amplitude Constants
        public const int cMin1 = 0;
        public const int cMin2 = 1;
        public const int cMax1 = 2;
        public const int cMax2 = 3;
        public const int cAvg1 = 4;
        public const int cAvg2 = 5;

        // Measurement Range Constants
        public const int cRange_250_410 = 4;
        public const int cRange_250_425 = 0;
        public const int cRange_300_410 = 3;
        public const int cRange_350_500 = 5;
        public const int cRange_400_725 = 1;
        public const int cRange_700_1100 = 2;
        public const int cRange_900_1500 = 6;
        public const int cRange_1100_1700 = 7;

        // Unit Constants for Get-/SetResultMode, GetLinewidth, Convert... and Calibration
        public const int cReturnWavelengthVac = 0;
        public const int cReturnWavelengthAir = 1;
        public const int cReturnFrequency = 2;
        public const int cReturnWavenumber = 3;
        public const int cReturnPhotonEnergy = 4;

        // Source Type Constants for Calibration
        public const int cHeNe633 = 0;
        public const int cHeNe1152 = 0;
        public const int cNeL = 1;
        public const int cOther = 2;
        public const int cFreeHeNe = 3;

        // Unit Constants for Autocalibration
        public const int cACOnceOnStart = 0;
        public const int cACMeasurements = 1;
        public const int cACDays = 2;
        public const int cACHours = 3;
        public const int cACMinutes = 4;

        // Pattern- and Analysis Constants
        public const int cPatternDisable = 0;
        public const int cPatternEnable = 1;
        public const int cAnalysisDisable = cPatternDisable;
        public const int cAnalysisEnable = cPatternEnable;

        public const int cSignal1Interferometers = 0;
        public const int cSignal1WideInterferometer = 1;
        public const int cSignal1Grating = 1;
        public const int cSignal2Interferometers = 2;
        public const int cSignal2WideInterferometer = 3;
        public const int cSignalAnalysis = 4;
        public const int cSignalAnalysisX = cSignalAnalysis;
        public const int cSignalAnalysisY = cSignalAnalysis + 1;

        // Return errorvalues of GetFrequency, GetWavelength and GetWLMVersion
        public const int ErrNoValue = 0;
        public const int ErrNoSignal = -1;
        public const int ErrNoPulse = -8;
        public const int ErrBadSignal = -2;
        public const int ErrLowSignal = -3;
        public const int ErrBigSignal = -4;
        public const int ErrWlmMissing = -5;
        public const int ErrNotAvailable = -6;
        public const int InfNothingChanged = -7;
        public const int ErrDiv0 = -13;
        public const int ErrOutOfRange = -14;
        public const int ErrUnitNotAvailable = -15;
        public const int ErrMaxErr = ErrUnitNotAvailable;

        // Return errorvalues of GetTemperature
        public const int ErrTemperature = -1000;
        public const int ErrTempNotMeasured = ErrTemperature + ErrNoValue;
        public const int ErrTempNotAvailable = ErrTemperature + ErrNotAvailable;
        public const int ErrTempWlmMissing = ErrTemperature + ErrWlmMissing;

        // Return errorvalues of GetDistance
        // real errorvalues are ErrDistance combined with those of GetWavelength
        public const int ErrDistance = -1000000000;
        public const int ErrDistanceNotAvailable = ErrDistance + ErrNotAvailable;
        public const int ErrDistanceWlmMissing = ErrDistance + ErrWlmMissing;

    }
}
