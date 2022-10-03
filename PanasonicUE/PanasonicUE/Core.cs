using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using Crestron.SimplSharp;
using Crestron.SimplSharp.Net.Http; // Access Crestron HTTP

namespace PanasonicUE
{
    public class Core
    {
        // Delegates 

        #region Scene
        public delegate void SceneFileDelegate(ushort value);

        public SceneFileDelegate OnSceneFileChange { get; set; }

        public CameraCmd SceneFile;
        #endregion

        #region System
        public delegate void PowerStatusDelegate(ushort value);
        public delegate void ModelDelegate(SimplSharpString value);
        public delegate void TitleDelegate(SimplSharpString value);
        public delegate void FormatDelegate(SimplSharpString value);
        public delegate void FrequencyDelegate(SimplSharpString value);
        public delegate void USBModeDelegate(ushort value);
        public delegate void USBAutoActiveDelegate(ushort value);
        public delegate void USBAutoStandbyDelegate(ushort value);

        public PowerStatusDelegate OnPowerStatusChange { get; set; }
        public ModelDelegate OnModelChange { get; set; }
        public TitleDelegate OnTitleChange { get; set; }
        public FormatDelegate OnFormatChange { get; set; }
        public FrequencyDelegate OnFrequencyChange { get; set; }
        public USBModeDelegate OnUSBModeChange { get; set; }
        public USBAutoActiveDelegate OnUSBAutoActiveChange { get; set; }
        public USBAutoStandbyDelegate OnUSBAutoStandbyChange { get; set; }

        public CameraCmd ModelNumber;
        public CameraCmd SystemVer;
        public PTZCmd SoftwareVer;
        public PTZCmd Power;
        public PTZCmd ResolutionControl;
        public CameraCmd CameraTitle;
        #endregion

        #region Lens
        public delegate void FocusModeDelegate(ushort data);
        public delegate void DigitalFocusModeDelegate(ushort data);
        public delegate void AFSensitivityDelegate(ushort data);
        public delegate void DigitalZoomDelegate(ushort data);
        public delegate void iZoomDelegate(ushort data);
        public delegate void MaxDigitalZoomDelegate(ushort data);
        public delegate void DigitalExtenderDelegate(SimplSharpString data);
        public delegate void ZoomScaleDelegate(ushort data);
        public delegate void DigitalZoomMagnificationDelegate(ushort data);
        public delegate void OISDelegate(ushort data);
        public delegate void ZoomSpeedChangeDelegate(ushort data);
        public delegate void ZoomPositionControlDelegate(ushort data);
        public delegate void FocusPositionControlDelegate(ushort data);
        public delegate void IrisPositionControlDelegate(ushort data);
        public delegate void IrisFNumberDelegate(SimplSharpString data);
        public delegate void ZoomModeDelegate(ushort data);

        public FocusModeDelegate OnFocusModeChange { get; set; }
        public DigitalFocusModeDelegate OnDigitalFocusModeChange { get; set; }
        public AFSensitivityDelegate OnAFSensitivityChange { get; set; }
        public DigitalZoomDelegate OnDigitalZoomChange { get; set; }
        public iZoomDelegate OnIZoomChange { get; set; }    // Not Used
        public MaxDigitalZoomDelegate OnMaxDigitalZoomChange { get; set; }
        public DigitalExtenderDelegate OnDigitalExtenderChange { get; set; }
        public ZoomScaleDelegate OnZoomScaleChange { get; set; }
        public DigitalZoomMagnificationDelegate OnDigitalZoomMagnificationChange { get; set; }
        public OISDelegate OnOISChange { get; set; }
        public ZoomSpeedChangeDelegate OnZoomSpeedUpdateChange { get; set; }
        public ZoomPositionControlDelegate OnZoomPositionControlChange { get; set; }
        public FocusPositionControlDelegate OnFocusPositionControlChange { get; set; }
        public IrisPositionControlDelegate OnIrisPositionControlChange { get; set; }
        public IrisFNumberDelegate OnIrisFNumberChange { get; set; }
        public ZoomModeDelegate OnZoomModeChange { get; set; }

        CameraCmd FocusMode;
        CameraCmd AFSensitivity;
        CameraCmd DigitalZoom;
        CameraCmd iZoom;
        CameraCmd MaxDigitalZoom;
        CameraCmd DigitalExtender;
        CameraCmd ZoomScale;
        CameraCmd DigitalZoomMagnification;
        CameraCmd OIS;
        PTZCmd ZoomSpeedControl;
        PTZCmd ZoomPositionControl;
        PTZCmd FocusSpeedControl;
        PTZCmd FocusPositionControl;
        PTZCmd IrisPositionControl;
        CameraCmd PushAutoFocus;
        CameraCmd TouchAutoFocus;
        PTZCmd IrisControl;
        CameraCmd IrisFollow;
        PTZCmd LensPositionInfo;
        PTZCmd LensPositionInfoControl;
        CameraCmd IrisFNum;
        PTZCmd ZoomPosition;
        PTZCmd FocusPosition;
        PTZCmd IrisPosition;
        #endregion

        #region Brightness
        public delegate void PictureLevelDelegate(ushort value);
        public delegate void IrisModeDelegate(ushort value);
        public delegate void AutoIrisSpeedDelegate(ushort value);
        public delegate void AutoIrisWindowDelegate(ushort value);
        public delegate void ShutterModeDelegate(SimplSharpString value);
        public delegate void StepValueDelegate(SimplSharpString value);
        public delegate void SynchroValueDelegate(SimplSharpString value);
        public delegate void IrisLimitDelegate(ushort value);
        public delegate void ELCLimitDelegate(SimplSharpString value);
        public delegate void GainDelegate(SimplSharpString value);
        public delegate void SuperGainDelegate(ushort value);
        public delegate void AGCMaxGainDelegate(SimplSharpString value);
        public delegate void FramMixDelegate(SimplSharpString value);
        public delegate void AutoFMixMaxDelegate(SimplSharpString value);
        public delegate void BacklightCompDelegate(ushort value);
        public delegate void SpotlightCompDelegate(ushort value);
        public delegate void FlickerSupressionDelegate(ushort value);

        public PictureLevelDelegate OnPictureLevelChange { get; set; }
        public IrisModeDelegate OnIrisModeChange { get; set; }
        public AutoIrisSpeedDelegate OnAutoIrisSpeedChange { get; set; }
        public AutoIrisWindowDelegate OnAutoIrisWindowChange { get; set; }
        public ShutterModeDelegate OnShutterModeChange { get; set; }
        public StepValueDelegate OnStepValueChange { get; set; }
        public SynchroValueDelegate OnSynchroValueChange { get; set; }
        public IrisLimitDelegate OnIrisLimitChange { get; set; }
        public ELCLimitDelegate OnELCLimitChange { get; set; }
        public GainDelegate OnGainChange { get; set; }
        public SuperGainDelegate OnSuperGainChange { get; set; }
        public AGCMaxGainDelegate OnAGCMaxGainChange { get; set; }
        public FramMixDelegate OnFramMixChange { get; set; }
        public AutoFMixMaxDelegate OnAutoFMixMaxChange { get; set; }
        public BacklightCompDelegate OnBacklightCompChange { get; set; }
        public SpotlightCompDelegate OnSpotlightCompChange { get; set; }
        public FlickerSupressionDelegate OnFlickerSupressionChange { get; set; }

        CameraCmd PictureLevel;
        CameraCmd IrisMode;
        CameraCmd AutoIrisSpeed;
        CameraCmd AutoIrisWindow;
        CameraCmd ShutterMode;
        CameraCmd StepVal;
        CameraCmd SynchroVal;
        CameraCmd IrisLimit;
        CameraCmd ELCLimit;
        CameraCmd Gain;
        #endregion

        #region Picture

        public delegate void WhiteBalanceModeDelegate(SimplSharpString value);
        public delegate void ColorTempDelegate(ushort data1, SimplSharpString data2);
        public delegate void RGainDelegate(ushort value);
        public delegate void BGainDelegate(ushort value);
        public delegate void AWBColorTempDelegate(ushort data1, SimplSharpString data2);
        public delegate void AWBGainOffsetDelegate(ushort value);
        public delegate void ATWTargetRGainDelegate(short value);
        public delegate void ATWTargetBGainDelegate(short value);
        public delegate void ChromaPhaseDelegate(short value);
        public delegate void MasterPedestalDelegate(short value);
        public delegate void DetailCoringDelegate(ushort value);
        public delegate void GammaDelegate(SimplSharpString value);
        public delegate void ATWSpeedDelegate(ushort value);
        public delegate void MasterDetailDelegate(short value);

        public WhiteBalanceModeDelegate OnWhiteBalanceModeChange { get; set; }
        public ColorTempDelegate OnColorTempChange { get; set; }
        public RGainDelegate OnRGainChange { get; set; }
        public BGainDelegate OnBGainChange { get; set; }
        public AWBColorTempDelegate OnAWBColorTempChange { get; set; }
        public AWBGainOffsetDelegate OnAWBGainOffsetChange { get; set; }
        public ATWTargetRGainDelegate OnATWTargetRGainChange { get; set; }
        public ATWTargetBGainDelegate OnATWTargetBGainChange { get; set; }
        public ChromaPhaseDelegate OnChromaPhaseChange { get; set; }
        public MasterPedestalDelegate OnMasterPedestalChange { get; set; }
        public DetailCoringDelegate OnDetailCoringChange { get; set; }
        public GammaDelegate OnGammaChange { get; set; }
        public ATWSpeedDelegate OnATWSpeedChange { get; set; }
        public MasterDetailDelegate OnMasterDetailChange { get; set; }

        CameraCmd WhiteBalanceMode;
        CameraCmd AWB;
        CameraCmd ABB;

        #endregion

        #region Matrix

        public delegate void AdaptiveMatrixDelegate(ushort value);

        public AdaptiveMatrixDelegate OnAdaptiveMatrixChange { get; set; }


        #endregion

        #region Presets
        public delegate void PresetSpeedUnitDelegate(ushort data);
        public delegate void PresetSpeedTableDelegate(ushort data);
        public delegate void PresetSpeedDelegate(ushort data);
        public delegate void PresetThumbnailUpdateDelegate(ushort data);
        public delegate void PresetNameDelegate(ushort data);
        public delegate void RequestLatestRecallPresetDelegate(ushort data);
        public delegate void SavePresetNameDelegate(ushort data, SimplSharpString name);
        public delegate void PresetNameCounterDelegate(ushort data1, ushort data2);
        public delegate void PresetIrisDelegate(ushort data);
        public delegate void PresetShutterDelegate(ushort data);
        public delegate void FreezeDuringPresetDelegate(ushort data);
        public delegate void PresetNameStringDelegate(ushort number, SimplSharpString name);
        public delegate void PresetImageStringDelegate(ushort number, SimplSharpString name);
        public delegate void PresetUpdateDelegate(ushort number, ushort value);

        public PresetSpeedUnitDelegate OnPresetSpeedUnitChange { get; set; }
        public PresetSpeedTableDelegate OnPresetSpeedTableChange { get; set; }
        public PresetSpeedDelegate OnPresetSpeedChange { get; set; }
        public PresetThumbnailUpdateDelegate OnPresetThumbnailUpdateChange { get; set; }
        public PresetNameDelegate OnPresetNameChange { get; set; }
        public RequestLatestRecallPresetDelegate OnRequestLatestRecallPresetChange { get; set; }
        public SavePresetNameDelegate OnSavePresetNameChange { get; set; }
        public PresetNameCounterDelegate OnPresetNameCounterChange { get; set; }
        public PresetIrisDelegate OnPresetIrisChange { get; set; }
        public PresetShutterDelegate OnPresetShutterChange { get; set; }
        public FreezeDuringPresetDelegate OnFreezeDuringPresetChange { get; set; }
        public PresetNameStringDelegate OnPresetNameStringChange { get; set; }
        public PresetImageStringDelegate OnPresetImageStringChange { get; set; }
        public PresetUpdateDelegate OnPresetUpdateChange { get; set; } 

        public delegate void ErrorInfoEventBlueprint(object o, ErrorInfoEventArgs e);

        public event ErrorInfoEventBlueprint OnErrorInfo = delegate { };

        public static Dictionary<ushort, ushort> errorInfoDict;

        CameraCmd PresetSpeedUnit;
        PTZCmd PresetSpeedTable;
        PTZCmd PresetSpeed;
        CameraCmd PresetThumbnailUpdate;
        CameraCmd PresetName;
        PTZCmd RecallPreset;
        PTZCmd SavePreset;
        PTZCmd DeletePreset;
        PTZCmd PresetEntryConfirmation;
        PTZCmd RequestLatestRecallPreset;
        CameraCmd SavePresetName;
        CameraCmd DeletePresetName;
        CameraCmd DeleteAllPresetNames;
        CameraCmd UpdatePresetThumbnails;
        CameraCmd DeletePresetThumbnail;
        CameraCmd DeleteAllPresetThumbnails;
        CameraCmd PresetNameCounter;
        #endregion

        #region PTZ
        public delegate void InstallPositionDelegate(ushort data);
        public delegate void PanTiltSpeedModeDelegate(ushort data);
        public delegate void SpeedWithZoomPosDelegate(ushort data);
        public delegate void FocusAdjustWithPTZDelegate(ushort data);
        public delegate void PrivacyModeDelegate(ushort data);
        public delegate void PowerOnPositionDelegate(ushort data);
        public delegate void PowerOnPresetNumberDelegate(ushort data);
        public delegate void LimitationControlDelegate(ushort direction, ushort value);
        public delegate void PresetDExtenderDelegate(ushort data);
        public delegate void PresetScopeDelegate(ushort data);
        public delegate void PresetZoomModeDelegate(ushort data);
        public delegate void PanTiltAbsolutePositionDelegate(ushort data1, ushort data2);

        public InstallPositionDelegate OnInstallPositionChange { get; set; }
        public PanTiltSpeedModeDelegate OnPanTiltSpeedModeChange { get; set; }
        public SpeedWithZoomPosDelegate OnSpeedWithZoomPosChange { get; set; }
        public FocusAdjustWithPTZDelegate OnFocusAdjustWithPTZChange { get; set; }
        public PrivacyModeDelegate OnPrivacyModeChange { get; set; }
        public PowerOnPositionDelegate OnPowerOnPositionChange { get; set; }
        public PowerOnPresetNumberDelegate OnPowerOnPresetNumberChange { get; set; }
        public LimitationControlDelegate OnLimitationControlChange { get; set; }
        public PresetDExtenderDelegate OnPresetDExtenderChange { get; set; }
        public PresetScopeDelegate OnPresetScopeChange { get; set; }
        public PresetZoomModeDelegate OnPresetZoomModeChange { get; set; }
        public PanTiltAbsolutePositionDelegate OnPanTiltAbsolutePositionChange { get; set; }

        PTZCmd InstallPosition;
        CameraCmd PTSpeedMode;
        PTZCmd SpeedWithZoomPos;
        CameraCmd FocusAdjustWithPTZ;
        CameraCmd PrivacyMode;
        CameraCmd PowerOnPosition;
        CameraCmd PowerOnPresetNumber;
        PTZCmd PanSpeed;
        PTZCmd TiltSpeed;
        PTZCmd PanTiltSpeed;
        PTZCmd AbsolutePosControl;
        PTZCmd RelativePosControl;
        PTZCmd AbsolutePosControlWithSpeed;
        PTZCmd RelativePosControlWithSpeed;
        PTZCmd LimitationControl;
        PTZCmd LimitationControlToggle;
        #endregion

        #region Output
        public delegate void ColorbarDelegate(ushort data);
        public delegate void TallyEnableDelegate(ushort data);
        public delegate void CamRTallyControlDelegate(ushort data);
        public delegate void PTZRTallyControlDelegate(ushort data);
        public delegate void GTallyControlDelegate(ushort data);

        public ColorbarDelegate OnColorbarChange { get; set; }
        public TallyEnableDelegate OnTallyEnableChange { get; set; }
        public CamRTallyControlDelegate OnCamRTallyControlChange { get; set; }
        public PTZRTallyControlDelegate OnPTZRTallyControlChange { get; set; }
        public GTallyControlDelegate OnGTallyControlChange { get; set; }
        #endregion

        #region OSD
        public delegate void MenuStatusDelegate(ushort data);

        public MenuStatusDelegate OnMenuStatusChange { get; set; }
        #endregion

        #region Remote Controller
        public delegate void OperationLockStatusDelegate(ushort data1, SimplSharpString data2);

        public OperationLockStatusDelegate OnOperationLockStatusChange { get; set; }
        #endregion

        #region Maintenance
        public delegate void ErrorInformationDelegate(ushort data);
        public delegate void ErrorVerboseDelegate(ushort data);
        public delegate void LatestErrorInfoDelegate(SimplSharpString data);

        public ErrorInformationDelegate OnErrorInformationChange { get; set; }
        public ErrorVerboseDelegate OnErrorVerboseChange { get; set; }
        public LatestErrorInfoDelegate OnLatestErrorInfoChange { get; set; }
        #endregion

        #region Update

        PTZCmd UpdatePTV;

        #endregion

        HttpClient httpClient;

        private static CrestronQueue<string> commandQueue;
        private static CrestronQueue<string> responseQueue;
        private CTimer commandQueueTimer;
        private CTimer responseQueueTimer;
        private CTimer pollQueueTimer;

        Camera myCamera;

        public static string IPAddress;
        public static ushort Debug;

        public void Initialise(SimplSharpString ipAddress, ushort debug)
        {
            IPAddress = ipAddress.ToString();
            Debug = debug;
            httpClient = new HttpClient();
            myCamera = new Camera();

            commandQueue = new CrestronQueue<string>();
            responseQueue = new CrestronQueue<string>();
            commandQueueTimer = new CTimer(CommandQueueDequeue, null, 0, 50);
            responseQueueTimer = new CTimer(ResponseQueueDequeue, null, 0, 50);
            pollQueueTimer = new CTimer(PollEnqueue, null, 0, 3000);

            errorInfoDict = new Dictionary<ushort, ushort>() { };

            // Scene

            SceneFile = new CameraCmd("XSF:","QSF","OSF:");

            // System

            ModelNumber = new CameraCmd("", "QID", "OID:");
            SystemVer = new CameraCmd("", "QSV", "OSV:");
            SoftwareVer = new PTZCmd("", "#QSV", "qSV");
            Power = new PTZCmd("#O", "#O", "p");
            ResolutionControl = new PTZCmd("#RZL", "#RZL", "rZL");
            CameraTitle = new CameraCmd("OSJ:5C:", "QSJ:5C", "OSJ:5C:");

            // Lens

            FocusMode = new CameraCmd("OAF:", "QAF", "OAF:");
            AFSensitivity = new CameraCmd("OSJ:D8:", "QSJ:D8", "OSJ:D8:");
            DigitalZoom = new CameraCmd("OSE:70:", "QSE:70", "OSE:70:");
            iZoom = new CameraCmd("OSD:B3:", "QSD:B3", "OSD:B3:");
            MaxDigitalZoom = new CameraCmd("OSE:7A:", "QSE:7A", "OSE:7A:");
            DigitalExtender = new CameraCmd("OSJ:4E:", "QSJ:4E", "OSJ:4E:");
            ZoomScale = new CameraCmd("", "QSJ:3D", "OSJ:3D:");
            DigitalZoomMagnification = new CameraCmd("OSE:76:", "QSE:76", "OSE:76:");
            OIS = new CameraCmd("OIS:", "QIS", "OIS:");
            ZoomSpeedControl = new PTZCmd("#Z", "", "zS");
            ZoomPositionControl = new PTZCmd("#AXZ", "#AXZ", "axz");
            FocusSpeedControl = new PTZCmd("#F", "", "fS");
            FocusPositionControl = new PTZCmd("#AXF", "#AXF", "axf");
            PushAutoFocus = new CameraCmd("OSE:69:", "", "OSE:69:");
            TouchAutoFocus = new CameraCmd("OSJ:28:", "", "OSJ:28:");
            IrisPositionControl = new PTZCmd("#AXI", "#AXI", "axi");
            IrisControl = new PTZCmd("#I", "#I", "iC");
            IrisFollow = new CameraCmd("", "QSD:4F", "OSD:4F");
            LensPositionInfo = new PTZCmd("", "#LPI", "lPI");
            LensPositionInfoControl = new PTZCmd("#LPC", "#LPC", "lPC");
            IrisFNum = new CameraCmd("", "QIF", "OIF");
            ZoomPosition = new PTZCmd("", "#GZ", "gz");
            FocusPosition = new PTZCmd("", "#GF", "gf");
            IrisPosition = new PTZCmd("", "#GI", "gi");

            // Brightness

            PictureLevel = new CameraCmd("OSD:48:", "QSD:48", "OSD:48:");
            IrisMode = new CameraCmd("ORS:", "QRS", "ORS:");
            AutoIrisSpeed = new CameraCmd("OSJ:01:", "QSJ:01", "OSJ:01:");
            AutoIrisWindow = new CameraCmd("OSJ:02:", "QSJ:02", "OSJ:02:");
            ShutterMode = new CameraCmd("OSJ:03:", "QSJ:03", "OSJ:03:");
            StepVal = new CameraCmd("OSJ:06:", "QSJ:06", "OSJ:06:");
            SynchroVal = new CameraCmd("OSJ:09:", "QSJ:09", "OSJ:09:");
            IrisLimit = new CameraCmd("OSJ:90:", "QSJ:90", "OSJ:90:");
            ELCLimit = new CameraCmd("OSD:BF:","QSD:BF","OSD:BF:");
            Gain = new CameraCmd("OGU:","QGU","OGU:");

            // Picture

            WhiteBalanceMode = new CameraCmd("OAW:", "QAW", "OAW:");
            AWB = new CameraCmd("OWS","","");
            ABB = new CameraCmd("OWS","","");

            // Presets

            PresetSpeedUnit = new CameraCmd("OSJ:29:", "QSJ:29", "OSJ:29:");
            PresetSpeedTable = new PTZCmd("#PST", "PST", "pST");
            PresetSpeed = new PTZCmd("#UPVS", "#UPVS", "uPVS");
            PresetThumbnailUpdate = new CameraCmd("OSJ:2B:", "QSJ:2B", "OSJ:2B:");
            PresetName = new CameraCmd("OSE:7C:", "QSE:7C", "OSE:7C:");
            RecallPreset = new PTZCmd("#R", "", "s");
            SavePreset = new PTZCmd("#M", "", "s");
            DeletePreset = new PTZCmd("#C", "", "s");
            PresetEntryConfirmation = new PTZCmd("", "#PE", "pE");
            RequestLatestRecallPreset = new PTZCmd("", "#S", "s");
            SavePresetName = new CameraCmd("OSJ:35:", "QSJ:35:", "OSJ:35:");
            DeletePresetName = new CameraCmd("OSJ:36:", "", "OSJ:36:");
            DeleteAllPresetNames = new CameraCmd("OSJ:37:", "", "OSJ:37:");
            UpdatePresetThumbnails = new CameraCmd("OSJ:39:", "", "OSJ:39:");
            DeletePresetThumbnail = new CameraCmd("OSJ:3A:", "", "OSJ:3A:");
            DeleteAllPresetThumbnails = new CameraCmd("OSJ:3B:", "", "OSJ:3B:");
            PresetNameCounter = new CameraCmd("", "QSJ:3C:", "QSJ:3C:");

            // PTZ

            InstallPosition = new PTZCmd("#INS", "#INS", "iNS");
            PTSpeedMode = new CameraCmd("OSJ:2D:", "QSJ:2D", "OSJ:2D:");
            SpeedWithZoomPos = new PTZCmd("#SWZ", "#SWZ", "sWZ");
            FocusAdjustWithPTZ = new CameraCmd("OAZ:", "QAZ", "OAZ:");
            PrivacyMode = new CameraCmd("OSJ:A7:", "QSJ:A7", "OSJ:A7:");
            PowerOnPosition = new CameraCmd("OSJ:45:", "QSJ:45", "OSJ:45:");
            PowerOnPresetNumber = new CameraCmd("OSJ:46:", "QSJ:46", "OSJ:46:");
            PanSpeed = new PTZCmd("#P", "", "pS");
            TiltSpeed = new PTZCmd("#T", "", "tS");
            PanTiltSpeed = new PTZCmd("#PTS", "", "pTS");
            AbsolutePosControl = new PTZCmd("#APC", "", "aPC");
            RelativePosControl = new PTZCmd("#RPC", "", "rPC");
            AbsolutePosControlWithSpeed = new PTZCmd("#APS", "", "aPS");
            RelativePosControlWithSpeed = new PTZCmd("#RPS", "", "rPS");
            LimitationControl = new PTZCmd("#LC", "", "lC");
            LimitationControlToggle = new PTZCmd("#L", "", "l");

            // Update Cmd

            UpdatePTV = new PTZCmd("","#PTV","pTV");

            Update();

            if (Debug == 1) CrestronConsole.PrintLine("\n Core: Initialized");
        }

        public void Update()
        {
            OnZoomSpeedUpdateChange(Convert.ToUInt16(ConvertRange(1, 49, 0, 65535, myCamera.zoomSpeed)));
            Enqueue("/live/camdata.html");
        }

        public void OnUpdatePTZFI()
        {
            UpdatePTV.SendRequest("");
        }

        public int lastPreset;

        public void PollEnqueue(object o)
        {
            if (commandQueue.IsEmpty)
            {
                string data = String.Format("/cgi-bin/aw_cam?cmd=QSJ:35:{0}&res=1", lastPreset.ToString("D2"));
                Enqueue(data);
            }
        }

        public void Dispose()
        {
            httpClient.Dispose();
            commandQueue.Dispose();
            commandQueueTimer.Stop();
            commandQueueTimer.Dispose();
            responseQueueTimer.Stop();
            responseQueueTimer.Dispose();
            pollQueueTimer.Stop();
            pollQueueTimer.Dispose();

            if (Debug == 1) CrestronConsole.PrintLine("\n Core: Disposed");
        }

        #region SendCommands

        private void CommandQueueDequeue(object o)
        {
            try
            {
                if (!commandQueue.IsEmpty)
                {
                    var data = commandQueue.TryToDequeue();

                    if (Debug == 1) CrestronConsole.PrintLine("\n Core: Command sent: " + data);

                    GetRequest(data);
                }
            }
            catch (Exception e)
            {
                if (Debug == 1) CrestronConsole.PrintLine("\n Core: CommandQueueDequeue: Exception: " + e.Message);
            }
        }

        public void GetRequest(string getRequestURL)
        {
            HttpClientRequest httpRequest = new HttpClientRequest(); // Create the request

            httpClient.KeepAlive = false; // Don't keep the connection alive

            httpRequest.Url.Parse(getRequestURL);
            httpRequest.Encoding = Encoding.UTF8; // Set the encoding type
            httpRequest.RequestType = RequestType.Get; // Set request type
            httpRequest.FinalizeHeader();   // Finalize header - may not be needed as included in S+

            try
            {
                httpClient.DispatchAsync(httpRequest, OnHttpClientResponseCallback);
                if (Debug == 1) CrestronConsole.PrintLine("\n Core: GetRequest: " + httpRequest.ContentString);
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("\n Core: GetRequest: Exception: " + e.Message);
            }
        }

        #endregion

        public void OnHttpClientResponseCallback(HttpClientResponse fromCamera, HTTP_CALLBACK_ERROR error)
        {
            try
            {
                if (fromCamera.ContentLength > 0 && (fromCamera.ContentString.Contains("\r\n") || fromCamera.ContentString.Contains("\n")))
                {
                    Regex regex = new Regex("\n");
                    string[] substrings = regex.Split(fromCamera.ContentString);
                    foreach (string match in substrings)
                    {
                        responseQueue.Enqueue(match);
                    }
                }

                else if (fromCamera.ContentLength > 0)
                {
                    responseQueue.Enqueue(fromCamera.ContentString + "\r\n");
                }
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("\n Core: OnHttpClientResponseCallback: Exception: " + e.Message);
            }
        }

        #region Parsing

        StringBuilder RxData = new StringBuilder();
        bool busy = false;
        int Pos = -1;

        private void ResponseQueueDequeue(object o)
        {
            try
            {
                if (!responseQueue.IsEmpty)
                {

                    string tmpString = responseQueue.TryToDequeue(); // removes string from queue, blocks until an item is queued

                    RxData.Append(tmpString); //Append received data to the COM buffer

                    if (!busy && RxData.Length > 0 && (RxData.ToString().Contains("\r\n") || (RxData.ToString().Contains("\r"))))
                    {
                        busy = true;

                        while (RxData.ToString().Contains("\r\n") || RxData.ToString().Contains("\r"))
                        {
                            Pos = RxData.ToString().IndexOf("\r");

                            var data = RxData.ToString().Substring(0, Pos + 1);
                            var garbage = RxData.Remove(0, Pos + 1); // remove data from COM buffer

                            ParseInternalResponse(data);
                        }

                        busy = false;
                    }
                }
            }
            catch (Exception e)
            {
                busy = false;
                if (Debug == 1) CrestronConsole.PrintLine("\n Core: ResponseQueueDequeue: Exception: " + e.Message);
            }
        }

        private void ParseInternalResponse(string returnString)
        {
            try
            {
                returnString = Regex.Replace(returnString, @"\p{C}+", string.Empty);

                if (returnString.Length > 0)
                {
                    if (Debug == 1) CrestronConsole.PrintLine("\n Panasonic: Core: ParseInternalResponse: {0}", returnString);

                    string pattern = ":";
                    string[] substrings;


                    if (returnString.Contains("pTV"))
                    {
                        myCamera.pan = Int16.Parse(returnString.Substring(3, 4), NumberStyles.HexNumber);
                        myCamera.tilt = Int16.Parse(returnString.Substring(7, 4), NumberStyles.HexNumber);
                        myCamera.zoom = Int16.Parse(returnString.Substring(11, 3), NumberStyles.HexNumber);
                        myCamera.focus = Int16.Parse(returnString.Substring(14, 3), NumberStyles.HexNumber);
                        myCamera.iris = Int16.Parse(returnString.Substring(17, 3), NumberStyles.HexNumber);

                        OnZoomPositionControlChange(Convert.ToUInt16(ConvertRange(1365, 4095, 0, 65535, myCamera.zoom))); // For Touchscreen);
                        OnFocusPositionControlChange(Convert.ToUInt16(ConvertRange(1365, 4095, 0, 65535, myCamera.focus)));
                        OnIrisPositionControlChange(Convert.ToUInt16(ConvertRange(1365, 4095, 0, 65535, myCamera.iris)));
                    }

                    else if (returnString.Contains("zS") || returnString.Contains("fS") || returnString.Contains("iC"))
                    {
                        OnUpdatePTZFI();    
                    }

                    else if (returnString.Contains("p1")) // Power On
                    {
                        OnPowerStatusChange(1);
                        myCamera.power = true;
                    }

                    else if (returnString.Contains("p0")) // Power Off
                    {
                        OnPowerStatusChange(0);
                        myCamera.power = false;
                    }

                    else if (returnString.Contains(ModelNumber.Response())) // Model Number
                    {
                        string modelNumber = returnString.Substring(4);

                        if (myCamera.modelNumber != modelNumber)
                        {
                            OnModelChange(modelNumber);

                            if (modelNumber == "AW-UE40")
                            {
                                myCamera.isUE40 = true;
                                myCamera.isUE50 = false;
                                myCamera.isUE80 = false;
                                myCamera.isHE40 = false;
                                myCamera.isHE130 = false;
                            }

                            else if (modelNumber == "AW-UE50")
                            {
                                myCamera.isUE40 = false;
                                myCamera.isUE50 = true;
                                myCamera.isUE80 = false;
                                myCamera.isHE40 = false;
                                myCamera.isHE130 = false;
                            }

                            else if (modelNumber == "AW-UE80")
                            {
                                myCamera.isUE40 = false;
                                myCamera.isUE50 = false;
                                myCamera.isUE80 = true;
                                myCamera.isHE40 = false;
                                myCamera.isHE130 = false;
                            }

                            else if (modelNumber == "AW-HE40")
                            {
                                myCamera.isUE40 = false;
                                myCamera.isUE50 = false;
                                myCamera.isUE80 = false;
                                myCamera.isHE40 = true;
                                myCamera.isHE130 = false;
                            }

                            else if (modelNumber == "AW-HE130")
                            {
                                myCamera.isUE40 = false;
                                myCamera.isUE50 = false;
                                myCamera.isUE80 = false;
                                myCamera.isHE40 = false;
                                myCamera.isHE130 = true;
                            }

                            else
                            {
                                if (Debug == 1) CrestronConsole.PrintLine("\n Panasonic: Core: ModelNumber: {0} not recognised", modelNumber);
                            }
                        }
                    }

                    else if (returnString.Contains("CGI_TIME:")) // Not Sure?
                    {
                        if (Debug == 1) CrestronConsole.PrintLine("\n Panasonic: Core: ParseInternalResponse: {0}", returnString);
                    }

                    else if (returnString.Contains("OSA:")) // Format
                    {
                        substrings = Regex.Split(returnString, pattern);

                        if (substrings[1] == "87")
                        {
                            byte formatByte = Convert.ToByte(substrings[2], 16);

                            if (myCamera.format != formatByte)
                            {

                                switch (formatByte)
                                {
                                    case 0x01:
                                        OnFormatChange("720/59.94p");
                                        break;
                                    case 0x02:
                                        OnFormatChange("720/50p");
                                        break;
                                    case 0x04:
                                        OnFormatChange("1080/59.94i");
                                        break;
                                    case 0x05:
                                        OnFormatChange("1080/50i");
                                        break;
                                    case 0x07:
                                        OnFormatChange("1080/29.97psF");
                                        break;
                                    case 0x08:
                                        OnFormatChange("1080/25psF");
                                        break;
                                    case 0x0A:
                                        OnFormatChange("1080/23.98psF");
                                        break;
                                    case 0x10:
                                        OnFormatChange("1080/59.94p");
                                        break;
                                    case 0x11:
                                        OnFormatChange("1080/50p");
                                        break;
                                    case 0x14:
                                        OnFormatChange("1080/29.97p");
                                        break;
                                    case 0x15:
                                        OnFormatChange("1080/25p");
                                        break;
                                    case 0x16:
                                        OnFormatChange("1080/23.98p");
                                        break;
                                    case 0x17:
                                        OnFormatChange("2160/29.97p");
                                        break;
                                    case 0x18:
                                        OnFormatChange("2160/25p");
                                        break;
                                    case 0x19:
                                        OnFormatChange("2160/59.94p");
                                        break;
                                    case 0x1A:
                                        OnFormatChange("2160/50p");
                                        break;
                                    case 0x1B:
                                        OnFormatChange("2160/23.98p");
                                        break;
                                    case 0x21:
                                        OnFormatChange("2160/24p");
                                        break;
                                    case 0x22:
                                        OnFormatChange("1080/24p");
                                        break;
                                    case 0x23:
                                        OnFormatChange("1080/23.98p");
                                        break;
                                    default:
                                        OnFormatChange("Unknown");
                                        break;
                                }
                            }
                        }

                        else if (substrings[1] == "30") // Master Detail
                        {
                            short data1 = Convert.ToInt16(substrings[2], 16);

                            data1 -= 128; // Apply Offset

                            OnMasterDetailChange(data1);
                        }

                        else if (substrings[1] == "40") // Skin Detail
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Skin Detail: " + substrings[2]);
                        }

                        else if (substrings[1] == "65") // Fram Mix
                        {
                            switch (Convert.ToByte(substrings[2], 16))
                            {
                                case 0x01:
                                    OnFramMixChange("Off");
                                    break;
                                case 0x06:
                                    OnFramMixChange("+6dB");
                                    break;
                                case 0x0C:
                                    OnFramMixChange("+12dB");
                                    break;
                                case 0x12:
                                    OnFramMixChange("+18dB");
                                    break;
                                case 0x18:
                                    OnFramMixChange("+24dB");
                                    break;
                                case 0x80:
                                    OnFramMixChange("Auto");
                                    break;
                                default:
                                    OnFramMixChange("Unknown");
                                    break;
                            }
                        }

                        else if (substrings[1] == "2A") // White Clip Level
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: White Clip Level: " + substrings[2]);
                        }

                        else if (substrings[1] == "2D") // Knee Mode
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Knee Mode: " + substrings[2]);
                        }

                        else if (substrings[1] == "2E") // White Clip
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: White Clip: " + substrings[2]);
                        }

                        else if (substrings[1] == "6A") // Gamma
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Gamma: " + substrings[2]);
                        }

                        else
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Panasonic: System: OnDataReceived: Value not found");
                        }
                    }

                    else if (returnString.Contains("TITLE:")) // Title ASCII
                    {
                        string title = returnString.Substring(6);

                        if (myCamera.title != title)
                        {
                            myCamera.title = title;
                            OnTitleChange(title);
                        }
                    }

                    else if (returnString.Contains("OSF:")) // SceneFile - Responose from Poll
                    {
                        UInt16 scene = ushort.Parse(returnString.Substring(4));

                        if (myCamera.scene != scene)
                        {
                            myCamera.scene = scene;
                            OnSceneFileChange(scene);
                        }
                    }

                    else if (returnString.Contains("XSF:")) // Scene Response from Command
                    {
                        UInt16 scene = ushort.Parse(returnString.Substring(4));

                        scene -= 1;

                        if (myCamera.scene != scene)
                        {
                            myCamera.scene = scene;
                            OnSceneFileChange(scene);
                        }
                    }

                    else if (returnString.Contains("OSD:"))
                    {
                        substrings = Regex.Split(returnString, pattern);

                        if (substrings[1] == "48") // Picture Level
                        {
                            int decValue = ConvertRange(00, 100, 0, 65535, Convert.ToInt16(substrings[2], 16));
 
                            OnPictureLevelChange(Convert.ToUInt16(decValue));
                        }

                        else if (substrings[1] == "B0") // Chroma Level
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Chroma Level: " + substrings[2]);
                        }

                        else if (substrings[1] == "BF")
                        {
                            string data = returnString.Substring(7, 1);
                            ushort decValue = Convert.ToUInt16(data);

                            switch (decValue)
                            {
                                case 2:
                                    OnELCLimitChange("1/100");
                                    break;
                                case 3:
                                    OnELCLimitChange("1/120");
                                    break;
                                case 4:
                                    OnELCLimitChange("1/250");
                                    break;
                                case 5:
                                    OnELCLimitChange("1/500");
                                    break;
                                case 6:
                                    OnELCLimitChange("1/1000");
                                    break;
                                case 7:
                                    OnELCLimitChange("1/2000");
                                    break;
                            }
                        }

                        else if (substrings[1] == "69") // AGC Max Gain
                        {
                            switch (Convert.ToByte(returnString.Substring(8, 2), 16))
                            {
                                case 0x01:
                                    OnAGCMaxGainChange("6dB");
                                    break;
                                case 0x02:
                                    OnAGCMaxGainChange("12dB");
                                    break;
                                case 0x03:
                                    OnAGCMaxGainChange("18dB");
                                    break;
                                case 0x04:
                                    OnAGCMaxGainChange("24dB");
                                    break;
                                case 0x05:
                                    OnAGCMaxGainChange("30dB");
                                    break;
                                case 0x06:
                                    OnAGCMaxGainChange("36dB");
                                    break;
                            }
                        }

                        else if (substrings[1] == "A1") // V Detail Level
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: V Detail Level: " + substrings[2]);
                        }

                        else if (substrings[1] == "A3") // Skin Detail Effect
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Skin Detail Effect: " + substrings[2]);
                        }

                        else if (substrings[1] == "A4") // Matrix R-G
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Matrix R-G: " + substrings[2]);
                        }

                        else if (substrings[1] == "A5") // Matrix R-B
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Matrix R-B: " + substrings[2]);
                        }

                        else if (substrings[1] == "A6") // Matrix G-R
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Matrix G-R: " + substrings[2]);
                        }

                        else if (substrings[1] == "A7") // Matrix G-B
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Matrix G-B: " + substrings[2]);
                        }

                        else if (substrings[1] == "A8") // Matrix B-R
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Matrix B-R: " + substrings[2]);
                        }

                        else if (substrings[1] == "A9") // Matrix B-G
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Matrix B-G: " + substrings[2]);
                        }

                        else if (substrings[1] == "3A") // DNR
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: DNR: " + substrings[2]);
                        }

                        else if (substrings[1] == "80") // Color Correction B_Mg Saturation
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction B_Mg Saturation: " + substrings[2]);
                        }

                        else if (substrings[1] == "81") // Color Correction B_Mg Phase
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction B_Mg Phase: " + substrings[2]);
                        }

                        else if (substrings[1] == "82") // Color Correction Mg Saturation
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction Mg Saturation: " + substrings[2]);
                        }

                        else if (substrings[1] == "83") // Color Correction Mg Phase
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction Mg Phase: " + substrings[2]);
                        }

                        else if (substrings[1] == "84") // Color Correction R_Mg Saturation
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction R_Mg Saturation: " + substrings[2]);
                        }

                        else if (substrings[1] == "85") // Color Correction R_Mg Phase
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction R_Mg Phase: " + substrings[2]);
                        }

                        else if (substrings[1] == "86") // Color Correction R Saturation
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction R Saturation: " + substrings[2]);
                        }

                        else if (substrings[1] == "87") // Color Correction R Phase
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction R Phase: " + substrings[2]);
                        }

                        else if (substrings[1] == "88") // Color Correction R_YI Saturation
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction R_YI Saturation: " + substrings[2]);
                        }

                        else if (substrings[1] == "89") // Color Correction R_YI Phase
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction R_YI Phase: " + substrings[2]);
                        }

                        else if (substrings[1] == "8A") // Color Correction YI Saturation
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction YI Saturation: " + substrings[2]);
                        }

                        else if (substrings[1] == "8B") // Color Correction YI Phase
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction YI Phase: " + substrings[2]);
                        }

                        else if (substrings[1] == "8C") // Color Correction YI_G Saturation
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction YI_G Saturation: " + substrings[2]);
                        }

                        else if (substrings[1] == "8D") // Color Correction YI_G Phase
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction YI_G Phase: " + substrings[2]);
                        }

                        else if (substrings[1] == "8E") // Color Correction G Saturation
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction G Saturation: " + substrings[2]);
                        }

                        else if (substrings[1] == "8F") // Color Correction G Phase
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction G Phase: " + substrings[2]);
                        }

                        else if (substrings[1] == "90") // Color Correction G_Cy Saturation
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction G_Cy Saturation: " + substrings[2]);
                        }

                        else if (substrings[1] == "91") // Color Correction G_Cy Phase
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction G_Cy Phase: " + substrings[2]);
                        }

                        else if (substrings[1] == "92") // Color Correction Cy Saturation
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction Cy Saturation: " + substrings[2]);
                        }

                        else if (substrings[1] == "93") // Color Correction Cy Phase
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction Cy Phase: " + substrings[2]);
                        }

                        else if (substrings[1] == "94") // Color Correction Cy_B Saturation
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction Cy_B Saturation: " + substrings[2]);
                        }

                        else if (substrings[1] == "95") // Color Correction Cy_B Phase
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction Cy_B Phase: " + substrings[2]);
                        }

                        else if (substrings[1] == "96") // Color Correction B Saturation
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction B Saturation: " + substrings[2]);
                        }

                        else if (substrings[1] == "97") // Color Correction B Phase
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction B Phase: " + substrings[2]);
                        }

                        else if (substrings[1] == "9A") // Color Correction Mg_R_R Saturation
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction Mg_R_R Saturation: " + substrings[2]);
                        }

                        else if (substrings[1] == "9B") // Color Correction Mg_R_R Phase
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction Mg_R_R Phase: " + substrings[2]);
                        }

                        else if (substrings[1] == "9C") // Color Correction R_R_YI Saturation
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction R_R_YI Saturation: " + substrings[2]);
                        }

                        else if (substrings[1] == "9D") // Color Correction R_R_YI Phase
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction R_R_YI Phase: " + substrings[2]);
                        }

                        else if (substrings[1] == "9E") // Color Correction R_YI_YI Saturation
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction R_YI_YI Saturation: " + substrings[2]);
                        }

                        else if (substrings[1] == "9F") // Color Correction R_YI_YI Phase
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction R_YI_YI Phase: " + substrings[2]);
                        }

                        else if (substrings[1] == "B3") // i.Zoom
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: i.Zoom: " + substrings[2]);
                        }

                        else if (substrings[1] == "4F") // Iris Follow
                        {
                            Int16 data = Int16.Parse(substrings[2], NumberStyles.HexNumber);

                            if (myCamera.iris != data)
                            {
                                myCamera.irisFollow = data;
                            }

                        }
                    }

                    else if (returnString.Contains("ORS:")) // Iris Mode (0 - Manual / 1 - Auto)
                    {
                        string data = returnString.Substring(4, 1);
                        ushort decValue = ushort.Parse(data);

                        if ((decValue >= 0 || decValue <= 1))
                        {
                            OnIrisModeChange(decValue);
                        }
                    }

                    else if (returnString.Contains("OSJ:"))
                    {

                        substrings = Regex.Split(returnString, pattern);

                        if (substrings[1] == "01") // Auto Iris Speed (0 - Slow / 1 - Normal / 2 - Fast)
                        {
                            ushort data1 = Convert.ToUInt16(substrings[2], 16);

                            if ((data1 >= 0 || data1 <= 2))
                            {
                                OnAutoIrisSpeedChange(data1);
                            }
                        }

                        else if (substrings[1] == "02") // Auto Iris Window (0 - Normal1 / 1 - Normal2 / 2 - Center)
                        {
                            ushort data1 = Convert.ToUInt16(substrings[2], 16); ;

                            if ((data1 >= 0 || data1 <= 2))
                            {
                                OnAutoIrisWindowChange(data1);
                            }
                        }

                        else if (substrings[1] == "03") // Shutter Mode (0 - Off / 1 - Step / 2 - Synchro / 3 - ELC)
                        {
                            ushort data1 = Convert.ToUInt16(substrings[2], 16);

                            if ((data1 >= 0 || data1 <= 3))
                            {
                                myCamera.ShutterMode = data1;

                                switch (data1)
                                {
                                    case 0:
                                        OnShutterModeChange("Off");
                                        break;
                                    case 1:
                                        OnShutterModeChange("Step");
                                        break;
                                    case 2:
                                        OnShutterModeChange("Synchro");
                                        break;
                                    case 3:
                                        OnShutterModeChange("ELC");
                                        break;
                                }
                            }
                        }

                        else if (substrings[1] == "06") // Step Val (0001h - 2710h = 1/1 - 1/100000)
                        {
                            ushort data1 = Convert.ToUInt16(substrings[2], 16);

                            if ((data1 >= 1 || data1 <= 10000))
                            {
                                OnStepValueChange(data1.ToString());
                            }
                        }

                        else if (substrings[1] == "09") // Synchro Val (00000h - 186A0h = 0.0Hz - 10000.00Hz)
                        {
                            UInt32 data1 = Convert.ToUInt32(substrings[2], 16);

                            if ((data1 >= 0 || data1 <= 100000))
                            {
                                OnSynchroValueChange(string.Format("{0}.{1}", (data1 / 10), (data1 % 10)));
                            }
                        }

                        else if (substrings[1] == "29") // Preset Speed Unit
                        {
                            OnPresetSpeedUnitChange(ushort.Parse(substrings[2]));
                        }

                        else if (substrings[1] == "90") // Iris Limit (0 - Off / 1 - On)
                        {
                            ushort data1 = Convert.ToUInt16(substrings[2], 16);

                            if ((data1 >= 0 || data1 <= 1))
                            {
                                OnIrisLimitChange(data1);
                            }
                        }

                        else if (substrings[1] == "3D") // Zoom Scale
                        {
                            Int16 data = Convert.ToInt16(substrings[2]);

                            if (myCamera.zoom != data)
                            {
                                myCamera.zoom = data;
                            }
                        }

                        else if (substrings[1] == "5C") // Title Hex
                        {
                            // Hex to ASCII conversion > send to delegate. Probably not required
                        }

                        else if (substrings[1] == "D0") // Spotlight Comp
                        {
                            string data = substrings[2];
                            OnSpotlightCompChange(ushort.Parse(data));
                        }

                        else if (substrings[1] == "D1") // Flicker Supression
                        {
                            string data = substrings[2];
                            OnFlickerSupressionChange(ushort.Parse(data));
                        }

                        else if (substrings[1] == "35") // Preset Name
                        {
                            ushort presetNumber = Convert.ToUInt16(substrings[2]);
                            string presetName = substrings[3];

                            if (Debug == 1) CrestronConsole.PrintLine("{0} : {1}", presetNumber, presetName);

                            OnPresetNameStringChange(presetNumber, presetName);
                        }

                        else if (substrings[1] == "40") // Operation Lock Status
                        {
                            string data1 = substrings[2];
                            string data2 = substrings[3];

                            OnOperationLockStatusChange(ushort.Parse(data1), data2);
                        }

                        else if (substrings[1] == "4A") // AWB Color Temperature
                        {
                            ushort data1 = Convert.ToUInt16(substrings[2], 16);
                            string data2 = "";

                            switch (Convert.ToByte(substrings[3], 16))
                            {
                                case 0x00:
                                    data2 = "Valid";
                                    break;
                                case 0x01:
                                    data2 = "Under";
                                    break;
                                case 0x02:
                                    data2 = "Over";
                                    break;
                            }

                            OnAWBColorTempChange(data1, data2);
                        }

                        else if (substrings[1] == "0B") // Chroma Phase
                        {
                            short data1 = Convert.ToInt16(substrings[2], 16);

                            data1 -= 128; // Apply Offset

                            OnChromaPhaseChange(data1);
                        }

                        else if (substrings[1] == "0C") // AWB Gain Offset
                        {
                            ushort data1 = Convert.ToUInt16(substrings[2], 16);

                            OnAWBGainOffsetChange(data1);
                        }

                        else if (substrings[1] == "0D") // ATW Target R
                        {
                            short data1 = Convert.ToInt16(substrings[2], 16);

                            data1 -= 128; // Apply offset

                            OnATWTargetRGainChange(data1);
                        }

                        else if (substrings[1] == "0E") // ATW Target B
                        {
                            short data1 = Convert.ToInt16(substrings[2], 16);

                            data1 -= 128; // Apply offset

                            OnATWTargetBGainChange(data1);
                        }

                        else if (substrings[1] == "0F") // Detail Master Pedestal
                        {
                            short data1 = Convert.ToInt16(substrings[2], 16);

                            OnMasterPedestalChange(data1);
                        }

                        else if (substrings[1] == "12") // Detail Coring
                        {
                            ushort data1 = Convert.ToUInt16(substrings[2], 16);

                            OnDetailCoringChange(data1);
                        }

                        else if (substrings[1] == "1C") // Color Correction Yl_Yl_G Saturation
                        {
                            short data1 = Convert.ToInt16(substrings[2], 16);

                            data1 -= 128; // Apply Offset

                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction Yl_Yl_G Saturation: " + data1);
                        }

                        else if (substrings[1] == "1D") // Color Correction Yl_Yl_G Phase
                        {
                            short data1 = Convert.ToInt16(substrings[2], 16);

                            data1 -= 128; // Apply Offset

                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Color Correction Yl_Yl_G Phase: " + data1);
                        }

                        else if (substrings[1] == "D3") // USB Mode
                        {
                            ushort data1 = Convert.ToUInt16(substrings[2], 16);

                            OnUSBModeChange(data1);
                        }

                        else if (substrings[1] == "D4") // USB Auto Active
                        {
                            ushort data1 = Convert.ToUInt16(substrings[2], 16);

                            OnUSBAutoActiveChange(data1);
                        }

                        else if (substrings[1] == "D7") // Gamma Mode
                        {
                            short data1 = Convert.ToInt16(substrings[2], 16);

                            switch (data1)
                            {
                                case 0:
                                    OnGammaChange("HD");
                                    break;
                                case 1:
                                    OnGammaChange("Normal");
                                    break;
                                case 2:
                                    OnGammaChange("Cinema 1");
                                    break;
                                case 3:
                                    OnGammaChange("Cinema 2");
                                    break;
                                case 4:
                                    OnGammaChange("Still Like");
                                    break;
                                default:
                                    OnGammaChange("Unknown");
                                    break;
                            }
                        }

                        else if (substrings[1] == "D8") // AF Sensitivity
                        {
                            ushort data1 = Convert.ToUInt16(substrings[2], 16);

                            OnAFSensitivityChange(data1);
                        }

                        else if (substrings[1] == "4E") // Digital Extender
                        {
                            short data1 = Convert.ToInt16(substrings[2], 16);

                            switch (data1)
                            {
                                case 0:
                                    OnDigitalExtenderChange("Off");
                                    break;
                                case 1:
                                    OnDigitalExtenderChange("x1.4");
                                    break;
                                case 2:
                                    OnDigitalExtenderChange("x2.0");
                                    break;
                                default:
                                    OnDigitalExtenderChange("Unknown");
                                    break;
                            }
                        }

                        else if (substrings[1] == "4F") // Adaptive Matrix
                        {
                            ushort data1 = Convert.ToUInt16(substrings[2], 16);

                            OnAdaptiveMatrixChange(data1);
                        }

                        else if (substrings[1] == "DC") // USB Auto Standby
                        {
                            ushort data1 = Convert.ToUInt16(substrings[2], 16);

                            OnUSBAutoStandbyChange(data1);
                        }

                        else if (substrings[1] == "2B") // Preset Thumbnail Update
                        {
                            ushort data1 = Convert.ToUInt16(substrings[2], 16);

                            OnPresetThumbnailUpdateChange(data1);
                        }

                        else if (substrings[1] == "2C") // Preset Name Hold Reset
                        {
                            ushort data1 = Convert.ToUInt16(substrings[2], 16);

                            OnPresetNameChange(data1);
                        }

                        else if (substrings[1] == "2D") // Pan/Tilt Speed Mode
                        {
                            ushort data1 = Convert.ToUInt16(substrings[2]);

                            OnPanTiltSpeedModeChange(data1);
                        }

                        else if (substrings[1] == "5B") // Preset Iris
                        {
                            ushort data1 = Convert.ToUInt16(substrings[2], 16);

                            OnPresetIrisChange(data1);
                        }

                        else if (substrings[1] == "D5") // Preset Shutter
                        {
                            ushort data1 = Convert.ToUInt16(substrings[2], 16);

                            OnPresetShutterChange(data1);
                        }

                        else if (substrings[1] == "2D") // Pan Tilt Speed Mode
                        {
                            ushort data1 = Convert.ToUInt16(substrings[2], 16);

                            OnPanTiltSpeedModeChange(data1);
                        }

                        else if (substrings[1] == "A7") // Pan Tilt Speed Mode
                        {
                            ushort data1 = Convert.ToUInt16(substrings[2], 16);

                            OnPrivacyModeChange(data1);
                        }
                    }

                    else if (returnString.Contains("rER")) // Latest Error Information 
                    {
                        string message = "";

                        switch (Convert.ToByte(returnString.Substring(3, 2), 16))
                        {
                            case 0x00:
                                message = "No Error";
                                break;
                            case 0x03:
                                message = "Motor Driver Error";
                                break;
                            case 0x21:
                                message = "System Error";
                                break;
                            case 0x22:
                                message = "Spec Limit Over";
                                break;
                            case 0x24:
                                message = "NET Life-monitoring Error";
                                break;
                            case 0x25:
                                message = "BE Life-monitoring Error";
                                break;
                            case 0x29:
                                message = "CAM Life-monitoring Error";
                                break;
                            case 0x31:
                                message = "Fan1 Error";
                                break;
                            case 0x33:
                                message = "High Temp";
                                break;
                            case 0x36:
                                message = "Low Temp";
                                break;
                            case 0x40:
                                message = "Temp Sensor Error";
                                break;
                            case 0x41:
                                message = "Lens Initialize Error";
                                break;
                            case 0x42:
                                message = "PT. Initialize Error";
                                break;
                            case 0x43:
                                message = "PoE++ Software auth.";
                                break;
                            case 0x45:
                                message = "PoE+ Software auth.";
                                break;
                            case 0x47:
                                message = "USB Streaming Error";
                                break;
                            case 0x50:
                                message = "MR Level Error";
                                break;
                            case 0x52:
                                message = "MR Offset Error";
                                break;
                            case 0x57:
                                message = "Gyro Error";
                                break;
                            case 0x58:
                                message = "PT. Initialize Error";
                                break;
                            default:
                                message = "Unknown";
                                break;
                        }

                        OnLatestErrorInfoChange(message);
                    }

                    else if (returnString.Contains("OGU:"))
                    {
                        substrings = Regex.Split(returnString, pattern);

                        string data = substrings[1];
                        ushort decValue = Convert.ToUInt16(data, 16);
                        string dataToReturn;

                        decValue -= 8;

                        myCamera.Gain = decValue;

                        if (decValue >= 42)
                        {
                            dataToReturn = "AGC On";
                        }

                        else
                        {
                            dataToReturn = String.Format("{0}dB", decValue.ToString());
                        }

                        OnGainChange(dataToReturn);
                    }



                    else if (returnString.Contains(PresetEntryConfirmation.Response())) // Preset Entry Confirmation
                    {
                        UInt32 presetBank = UInt32.Parse(returnString.Substring(2, 2));
                        string newValue = returnString.Substring(4, 10); //0000000000h
                        BitArray presets = ConvertHexToBitArray(newValue);

                        ushort counter = 0;


                        if (presetBank == 0)
                        {
                            counter = 1;
                        }

                        else if (presetBank == 1)
                        {
                            counter = 41;
                        }

                        else if (presetBank == 2)
                        {
                            counter = 81;
                        }

                        foreach (var preset in presets)
                        {
                            if (counter >= 1 && counter <= 100) // Original 1 to 99
                            {
                                OnPresetUpdateChange(counter, Convert.ToUInt16(preset));
                            }

                            counter++;
                        }
                    }

                    else if (returnString.Contains("pST")) // Preset Speed Table
                    {
                        OnPresetSpeedTableChange(Convert.ToUInt16(returnString.Substring(3, 1))); // (0 - slow / 2 - Fast)
                    }

                    else if (returnString.Contains("OSI:"))
                    {
                        substrings = Regex.Split(returnString, pattern);

                        if (substrings[1] == "20") // Colour Temperature
                        {
                            ushort data1 = Convert.ToUInt16(substrings[2].Substring(5), 16);
                            string data2 = "";

                            switch (Convert.ToByte(substrings[3], 16))
                            {
                                case 0x00:
                                    data2 = "Valid";
                                    break;
                                case 0x01:
                                    data2 = "Under";
                                    break;
                                case 0x02:
                                    data2 = "Over";
                                    break;
                            }

                            OnColorTempChange(data1, data2);
                        }

                        else if (substrings[1] == "25") // ATW Speed
                        {
                            string data = (substrings[2]);

                            OnATWSpeedChange(ushort.Parse(data)); // (0 - Normal / 1 - Slow / 2 - Fast)
                        }

                        else if (substrings[1] == "28") // Super Gain
                        {
                            string data = (substrings[2]);

                            OnSuperGainChange(ushort.Parse(data)); // (0 - Off / 1 - On)

                            //myCamera.Supergain = Convert.ToBoolean(data);
                        }

                        else if (substrings[1] == "46") // Error Information
                        {
                            string newValue = substrings[2].Substring(7,2); // 00000010h
                            myCamera.ErrorBitArray = ConvertHexToBitArray(newValue);

                            /*BitArray errors = ConvertHexToBitArray(newValue);

                            ushort counter = 0;

                            foreach (var error in errors)
                            {
                                errorInfoDict.Add(counter, Convert.ToUInt16(error));
                                counter++;
                            }

                            RaiseErrorInfoEvent();*/
                        }
                    }

                    else if (returnString.Contains("OSE:"))
                    {
                        substrings = Regex.Split(returnString, pattern);

                        if (substrings[1] == "31") // Matrix Type
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Matrix Type: " + substrings[2]);
                        }

                        else if (substrings[1] == "33") // DRS
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: DRS: " + substrings[2]);
                        }

                        else if (substrings[1] == "70") // Digital Zoom
                        {
                            OnDigitalZoomChange(Convert.ToUInt16(substrings[2]));
                        }

                        else if (substrings[1] == "71") // Preset scope
                        {
                            OnPresetScopeChange(Convert.ToUInt16(substrings[2]));
                        }

                        else if (substrings[1] == "73") // Backlight Comp
                        {
                            OnBacklightCompChange(Convert.ToUInt16(substrings[2]));
                        }

                        else if (substrings[1] == "74") // Auto F Mix Max Gain
                        {
                            string data = substrings[2].Substring(2);

                            switch (Convert.ToByte(data, 16))
                            {
                                case 0x01:
                                    OnFramMixChange("Off");
                                    break;
                                case 0x06:
                                    OnFramMixChange("+6dB");
                                    break;
                                case 0x0C:
                                    OnFramMixChange("+12dB");
                                    break;
                                case 0x12:
                                    OnFramMixChange("+18dB");
                                    break;
                                case 0x18:
                                    OnFramMixChange("+24dB");
                                    break;
                                case 0x80:
                                    OnFramMixChange("Auto");
                                    break;
                            }
                        }

                        else if (substrings[1] == "76") // Digital Zoom Magnification
                        {
                            Int16 data = Convert.ToInt16(substrings[2]);

                            if (myCamera.digitalZoom != data)
                            {
                                myCamera.digitalZoom = data;
                                OnDigitalZoomMagnificationChange(Convert.ToUInt16(data));
                            }
                        }

                        else if (substrings[1] == "77") // Frequency
                        {
                            ushort data = Convert.ToUInt16(substrings[2]);

                            switch (data)
                            {
                                case 0:
                                    OnFrequencyChange("59.94Hz");
                                    break;
                                case 1:
                                    OnFrequencyChange("50.00Hz");
                                    break;
                                case 2:
                                    OnFrequencyChange("24Hz");
                                    break;
                                case 3:
                                    OnFrequencyChange("23.98Hz");
                                    break;
                                default:
                                    OnFrequencyChange("Unknown");
                                    break;
                            }
                        }

                        else if (substrings[1] == "7A") // Max Digital Zoom
                        {
                            OnMaxDigitalZoomChange(Convert.ToUInt16(substrings[2]));
                        }

                        else if (substrings[1] == "7C") // Preset D Extender
                        {
                            OnPresetDExtenderChange(Convert.ToUInt16(substrings[2]));
                        }

                        else if (substrings[1] == "7D") // Preset Zoom Mode
                        {
                            OnPresetZoomModeChange(Convert.ToUInt16(substrings[2]));
                        }
                    }

                    else if (returnString.Contains("OAW:")) // White Balance
                    {
                        string data = returnString.Substring(4, 1);
                        ushort decValue = Convert.ToUInt16(data);

                        myCamera.WhiteBalanceMode = decValue;

                        switch (decValue)
                        {
                            case 0:
                                OnWhiteBalanceModeChange("ATW");
                                myCamera.WhiteBalanceMode = 0;
                                break;
                            case 1:
                                OnWhiteBalanceModeChange("AWC A");
                                myCamera.WhiteBalanceMode = 1;
                                break;
                            case 2:
                                OnWhiteBalanceModeChange("AWC B");
                                myCamera.WhiteBalanceMode = 2;
                                break;
                            case 3:
                                OnWhiteBalanceModeChange("---");
                                myCamera.WhiteBalanceMode = 3;
                                break;
                            case 4:
                                OnWhiteBalanceModeChange("3200K");
                                myCamera.WhiteBalanceMode = 4;
                                break;
                            case 5:
                                OnWhiteBalanceModeChange("5600K");
                                myCamera.WhiteBalanceMode = 5;
                                break;
                            case 9:
                                OnWhiteBalanceModeChange("VAR");
                                myCamera.WhiteBalanceMode = 9;
                                break;
                        }
                    }

                    else if (returnString.Contains("OSG:"))
                    {
                        substrings = Regex.Split(returnString, pattern);

                        if (substrings[1] == "39") // R Gain
                        {
                            ushort data1 = Convert.ToUInt16(substrings[2], 16);

                            OnRGainChange(data1);
                        }

                        if (substrings[1] == "3A") // B Gain
                        {
                            ushort data1 = Convert.ToUInt16(substrings[2], 16);

                            OnBGainChange(data1);
                        }

                    }

                    else if (returnString.Contains("ODT:")) // Detail
                    {
                        if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Detail: " + returnString);
                    }

                    else if (returnString.Contains("OAF:")) // Focus Mode - Cam
                    {
                        OnFocusModeChange(Convert.ToUInt16(returnString.Substring(4, 1))); // (0 - Manual / 1 - Auto)

                    }

                    else if (returnString.Contains("d10")) // Focus Mode - PTZ
                    {
                        OnDigitalFocusModeChange(Convert.ToUInt16(returnString.Substring(2, 1))); // (0 - Manual / 1 - Auto)
                    }

                    else if (returnString.Contains("d11")) // Focus Mode - PTZ
                    {
                        OnDigitalFocusModeChange(Convert.ToUInt16(returnString.Substring(2, 1))); // (0 - Manual / 1 - Auto)
                    }

                    else if (returnString.Contains("OIS:")) // OIS
                    {
                        if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: OIS: " + returnString.Substring(4, 1));
                    }

                    else if (returnString.Contains("axz")) // Zoom Position Control
                    {
                        myCamera.zoom = Convert.ToInt16(returnString.Substring(3, 3), 16);
                        ushort scaledData = Convert.ToUInt16(ConvertRange(1365, 4095, 0, 65535, myCamera.zoom)); // For Touchscreen

                        OnZoomPositionControlChange(scaledData);
                    }

                    else if (returnString.Contains("axf")) // Focus Position Control
                    {
                        myCamera.focus = Convert.ToInt16(returnString.Substring(3, 3), 16);
                        ushort scaledData = Convert.ToUInt16(ConvertRange(1365, 4095, 0, 65535, myCamera.focus)); // For Touchscreen

                        OnFocusPositionControlChange(scaledData);
                    }

                    else if (returnString.Contains("axi")) // Iris Position Control
                    {
                        myCamera.iris = Convert.ToInt16(returnString.Substring(3, 3), 16); // For myCamera.Iris
                        ushort scaledData = Convert.ToUInt16(ConvertRange(1365, 4095, 0, 65535, myCamera.iris)); // For Touchscreen

                        OnIrisPositionControlChange(scaledData);
                    }

                    else if (returnString.Contains("OIF:")) // Iris F Number
                    {
                        substrings = Regex.Split(returnString, pattern);

                        ushort data1 = Convert.ToUInt16(substrings[1], 16);
                        string stringData = string.Format("F{0}.{1}", data1.ToString().Substring(0, 1), data1.ToString().Substring(1, 1));

                        OnIrisFNumberChange(stringData);
                    }

                    else if (returnString.Contains("OBR:")) // Iris F Number
                    {
                        ushort data1 = Convert.ToUInt16(returnString.Substring(4, 1), 16);

                        OnColorbarChange(data1);
                    }

                    else if (returnString.Contains("tAE")) // Tally Enable
                    {
                        ushort data1 = Convert.ToUInt16(returnString.Substring(3, 1), 16);

                        OnTallyEnableChange(data1);
                    }

                    else if (returnString.Contains("TLR:")) // R-Tally Control - Cam
                    {
                        ushort data1 = Convert.ToUInt16(returnString.Substring(4, 1), 16);

                        OnCamRTallyControlChange(data1);
                    }

                    else if (returnString.Contains("dA")) // R-Tally Control - PTZ
                    {
                        ushort data1 = Convert.ToUInt16(returnString.Substring(2, 1), 16);

                        OnPTZRTallyControlChange(data1);
                    }

                    else if (returnString.Contains("TLG:")) // G-Tally Control - PTZ
                    {
                        ushort data1 = Convert.ToUInt16(returnString.Substring(4, 1), 16);

                        OnGTallyControlChange(data1);
                    }

                    else if (returnString.Contains("tAA")) // Tally Information
                    {
                        if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: Tally Information: " + returnString);
                    }

                    else if (returnString.Contains("iNS0")) // InstallPosition Desktop
                    {
                        OnInstallPositionChange(0);
                    }

                    else if (returnString.Contains("iNS1")) // InstallPosition Hanging
                    {
                        OnInstallPositionChange(1);
                    }

                    else if (returnString.Contains("sWZ0")) // Speed with Zoom Position Off
                    {
                        OnSpeedWithZoomPosChange(0);
                    }

                    else if (returnString.Contains("sWZ1")) // Speed with Zoom Position On
                    {
                        OnSpeedWithZoomPosChange(1);
                    }

                    else if (returnString.Contains("OAZ:")) // Focus Adjust with PTZ
                    {
                        ushort data1 = Convert.ToUInt16(returnString.Substring(4, 1));

                        OnFocusAdjustWithPTZChange(data1);
                    }

                    else if (returnString.Contains("lC")) // Limitation Control 
                    {
                        ushort direction = Convert.ToUInt16(returnString.Substring(2, 1), 16);
                        ushort value = Convert.ToUInt16(returnString.Substring(3, 1), 16);

                        OnLimitationControlChange(direction, value);
                    }

                    else if (returnString.Contains("uPVS")) // Preset Speed 
                    {
                        ushort data = Convert.ToUInt16(returnString.Substring(4, 1), 16);

                        OnPresetSpeedChange(data);
                    }

                    else if (returnString.Contains("pRF")) // Freeze During Preset 
                    {
                        ushort data = Convert.ToUInt16(returnString.Substring(3, 1), 16);

                        OnFreezeDuringPresetChange(data);
                    }

                    else if (returnString.Contains("OUS:")) // Menu Status
                    {
                        ushort data = Convert.ToUInt16(returnString.Substring(4, 1), 16);

                        OnMenuStatusChange(data);
                    }

                    else if (returnString.Contains("OER:")) // Error Information
                    {
                        ushort data = Convert.ToUInt16(returnString.Substring(4, 1));

                        OnErrorInformationChange(data);
                    }

                    

                    else if (returnString.Contains("aPC")) // Pan Tilt Absolute Position 
                    {
                        ushort panData = Convert.ToUInt16(returnString.Substring(3, 4), 16);
                        ushort tiltData = Convert.ToUInt16(returnString.Substring(7, 4), 16);

                        OnPanTiltAbsolutePositionChange(panData, tiltData);
                    }

                    else if (returnString.Contains("d3")) // Alternative Iris Mode
                    {
                        // 
                    }

                    else if (returnString.Contains("d1")) // Alternative Focus Mode
                    {
                        
                    }

                    else if ((returnString.Length == 2) || (returnString.Length == 3) && (returnString.Substring(0, 1) == "s")) // Preset Changed
                    {
                        ushort presetNumber = Convert.ToUInt16(returnString.Substring(1));
                        lastPreset = presetNumber;

                        if (presetNumber >= 0 && presetNumber <= 39)
                        {
                            PresetEntryConfirmation.SendRequest("00");
                        }

                        else if (presetNumber >= 40 && presetNumber <= 79)
                        {
                            PresetEntryConfirmation.SendRequest("01");
                        }

                        else if (presetNumber >= 80 && presetNumber <= 119)
                        {
                            PresetEntryConfirmation.SendRequest("02");
                        }

                        else
                        {
                            if (Debug == 1) CrestronConsole.PrintLine("Preset Changed: Value not recognised");
                        }

                    }

                    else
                    {
                        if (Debug == 1) CrestronConsole.PrintLine("\n** Core: returnString not handled: {0} **", returnString);
                    }
                }
            }
            
            catch (Exception e)
            {
                if (Debug == 1) CrestronConsole.PrintLine("\n Core: ParseInternalResponse: {0}:{1}:{2}", e.Message, e.StackTrace, e.InnerException);
            }
        }


        #endregion

        public static void Enqueue(string cmd)
        {
            string data = "http://" + IPAddress + cmd;

            if (!commandQueue.Contains(data))
            {
                commandQueue.Enqueue(data);
            }
        }

        public void RaiseErrorInfoEvent()
        {

            ErrorInfoEventArgs args = new ErrorInfoEventArgs();

            args.dictLength = (ushort)errorInfoDict.Count;
            args.errorNum = new ushort[args.dictLength];
            args.errorValue = new ushort[args.dictLength];

            int i = 0;

            foreach (KeyValuePair<ushort, ushort> entry in errorInfoDict)
            {
                args.errorNum[i] = entry.Key;
                args.errorValue[i] = entry.Value;
                i++;
            }

            OnErrorInfo(this, args);
        }

        public static BitArray ConvertHexToBitArray(string hexData)
        {
            if (hexData == null)
                return null; // or do something else, throw, ...

            BitArray ba = new BitArray(4 * hexData.Length);
            for (int i = 0; i < hexData.Length; i++)
            {
                byte b = byte.Parse(hexData[i].ToString(), NumberStyles.HexNumber);
                for (int j = 0; j < 4; j++)
                {
                    ba.Set(i * 4 + j, (b & (1 << (3 - j))) != 0);
                }
            }

            // Reverse Order BitArray

            int length = ba.Length;
            int mid = (length / 2);

            for (int i = 0; i < mid; i++)
            {
                bool bit = ba[i];
                ba[i] = ba[length - i - 1];
                ba[length - i - 1] = bit;
            }  

            return ba;
        }
        
        #region Commands

        // Scene

        public void OnSceneFile(ushort value)
        {
            SceneFile.SendControl(value.ToString());
        }

        // System
        public void OnPower(ushort value)
        {
            Power.SendControl(value.ToString());
        }

        // Lens

        public void OnFocusMode(ushort value)
        {
            FocusMode.SendControl(value.ToString());
        }

        public void OnAFSensitivity(ushort value)
        {
            AFSensitivity.SendControl(value.ToString());
        }

        public void OnDigitalZoom(ushort value)
        {
            DigitalZoom.SendControl(value.ToString());
        }

        public void OnIZoom(ushort value)
        {
            iZoom.SendControl(value.ToString());
        }

        public void OnMaxDigitalZoom(ushort value)
        {
            MaxDigitalZoom.SendControl(value.ToString());
        }

        public void OnDigitalExtender(ushort value)
        {
            DigitalExtender.SendControl(value.ToString());
        }

        public void OnZoomScale()
        {
            ZoomScale.SendRequest("");
        }

        public void OnDigitalZoomMagnification(ushort value)
        {
            DigitalZoomMagnification.SendControl(value.ToString());
        }

        public void OnOIS(ushort value)
        {
            OIS.SendControl(value.ToString());
        }

        public void OnZoomSpeedControl(ushort value)
        {
            Int16 zoom = 50;

            if (value == 1)
            {
                zoom += myCamera.zoomSpeed;
            }

            else if (value == 2)
            {
                zoom -= myCamera.zoomSpeed;
            }

            else if (value == 0)
            {
                zoom = 50;
            }

            ZoomSpeedControl.SendControl(zoom.ToString("D2"));
        }

        public void OnZoomSpeedChange(ushort value)
        {
            myCamera.zoomSpeed = Convert.ToInt16(ConvertRange(0, 65535, 01, 49, value));
            OnZoomSpeedUpdateChange(Convert.ToUInt16(ConvertRange(1, 49, 0, 65535, myCamera.zoomSpeed)));
        }

        public void OnZoomPositionControl(ushort value)
        {
            int scaledValue = ConvertRange(0,65535,1365, 4095, value);
            ZoomPositionControl.SendControl(scaledValue.ToString("X3"));
        }

        public void OnFocusSpeedControl(ushort value)
        {
            FocusSpeedControl.SendControl(value.ToString("D2"));
        }

        public void OnFocusPositionControl(ushort value)
        {
            int scaledValue = ConvertRange(0, 65535, 1365, 4095, value);
            FocusPositionControl.SendControl(scaledValue.ToString("X3"));
        }

        public void OnPushAF(ushort value)
        {
            PushAutoFocus.SendControl(value.ToString());
        }

        public void OnTouchAF(ushort hPosVal, ushort vPosVal)
        {
            int hPosScaled = ConvertRange(0, 65535, 0, 100, hPosVal);
            int vPosScaled = ConvertRange(0, 65535, 0, 100, vPosVal);

            int vPosInverted = reverseNumber(vPosScaled, 0, 100);

            TouchAutoFocus.SendControl(string.Format("{0}:{1}", hPosScaled.ToString("X2"), vPosInverted.ToString("X2")));
        }

        public void OnIrisPositionControl(ushort value)
        {
            int scaledValue = ConvertRange(0, 65535, 1365, 4095, value);
            IrisPositionControl.SendControl(scaledValue.ToString("X3"));
        }

        public void OnIrisMode(ushort value)
        {
            IrisMode.SendControl(value.ToString());
        }

        public void OnAutoIrisSpeed(ushort value)
        {
            AutoIrisSpeed.SendControl(value.ToString());
        }

        public void OnAutoIrisWindow(ushort value)
        {
            AutoIrisWindow.SendControl(value.ToString()); 
        }


        public void OnIrisControl(ushort value)
        {
            double currentValue = Math.Round(ConvertRangeDouble(1365, 4095, 01, 99, myCamera.iris));

            if (value == 1)
            {
                if (currentValue <= 98)
                {
                    currentValue += 1;
                }
            }

            else if (value == 0)
            {
                if (currentValue >= 2)
                {
                    currentValue -= 1;
                }
            }

            else
            {
                // Not Used
            }

            IrisControl.SendControl(currentValue.ToString());
            IrisFNum.SendRequest("");
        }

        public void OnIrisFollow()
        {
            IrisFollow.SendRequest("");
        }

        public void OnLensPositionInfo()
        {
            LensPositionInfo.SendRequest("");
        }

        public void OnLensPositionInfoControl(ushort value)
        {
            LensPositionInfoControl.SendControl(value.ToString());
        }

        public void OnRequestIrisFNum()
        {
            IrisFNum.SendRequest("");
        }

        public void OnRequestZoomPos()
        {
            ZoomPosition.SendRequest("");
        }

        public void OnRequestFocusPos()
        {
            FocusPosition.SendRequest("");
        }

        public void OnRequestIrisPos()
        {
            IrisPosition.SendRequest("");
        }

        // Brightness

        public void OnPictureLevel(ushort value)
        {
            int currentValue = ConvertRange(0, 65535, 0, 100, value);
            PictureLevel.SendControl(currentValue.ToString("X2"));
        }

        public void OnIrisLimit(ushort value)
        {
            IrisLimit.SendControl(value.ToString());
        }

        public void OnGainInc()
        {
            if (myCamera.Supergain)
            {
                if ((myCamera.Gain) >= 0 && (myCamera.Gain) <= 41)
                {
                    myCamera.Gain += 1;
                    int valueToSend = myCamera.Gain + 8;
                    Gain.SendControl(valueToSend.ToString("X2"));
                }

                else if (myCamera.Gain > 42)
                {
                    myCamera.Gain = 120;
                    int valueToSend = myCamera.Gain + 8;
                    Gain.SendControl(valueToSend.ToString("X2"));
                }
            }

            else 
            {
                if ((myCamera.Gain) >= 0 && (myCamera.Gain) <= 35)
                {
                    myCamera.Gain += 1;
                    int valueToSend = myCamera.Gain + 8;
                    Gain.SendControl(valueToSend.ToString("X2"));
                }

                else if (myCamera.Gain > 35)
                {
                    myCamera.Gain = 120;
                    int valueToSend = myCamera.Gain + 8;
                    Gain.SendControl(valueToSend.ToString("X2"));
                }
            }
        }

        public void OnGainDec()
        {
            if (myCamera.Supergain)
            {
                if ((myCamera.Gain) >= 1 && (myCamera.Gain) <= 42)
                {
                    myCamera.Gain -= 1;
                    int valueToSend = myCamera.Gain + 8;
                    Gain.SendControl(valueToSend.ToString("X2"));
                }

                else if (myCamera.Gain == 120)
                {
                    myCamera.Gain = 42;
                    int valueToSend = myCamera.Gain + 8;
                    Gain.SendControl(valueToSend.ToString("X2"));
                }
            }

            else
            {
                if ((myCamera.Gain) >= 1 && (myCamera.Gain) <= 36)
                {
                    myCamera.Gain -= 1;
                    int valueToSend = myCamera.Gain + 8;
                    Gain.SendControl(valueToSend.ToString("X2"));
                }

                else if (myCamera.Gain == 120)
                {
                    myCamera.Gain = 36;
                    int valueToSend = myCamera.Gain + 8;
                    Gain.SendControl(valueToSend.ToString("X2"));
                }
            }
        }

        public void OnShutterInc()
        {
            if ((myCamera.ShutterMode) >= 0 && (myCamera.ShutterMode) <= 2)
            {
                myCamera.ShutterMode += 1;
                ShutterMode.SendControl(myCamera.ShutterMode.ToString());
            }       
        }

        public void OnShutterDec()
        {
            if ((myCamera.ShutterMode) >= 1 && (myCamera.ShutterMode) <= 3)
            {
                myCamera.ShutterMode -= 1;
                ShutterMode.SendControl(myCamera.ShutterMode.ToString());
            }  
        }

        // Picture

        public void OnWhiteBalanceModeInc()
        {
            int WBIndex = Array.IndexOf(myCamera.WhiteBalanceArray, myCamera.WhiteBalanceMode);

            if (WBIndex >= 0 && WBIndex < 9)
            {
                WhiteBalanceMode.SendControl(myCamera.WhiteBalanceArray[WBIndex + 1].ToString());       
            }
            
            else
            {
                if (Debug == 1) CrestronConsole.PrintLine("\n Core: OnWhiteBalanceModeInc: Value out of Range"); 
            }
        }

        public void OnWhiteBalanceModeDec()
        {
            int WBIndex = Array.IndexOf(myCamera.WhiteBalanceArray, myCamera.WhiteBalanceMode);

            if (WBIndex >= 0 && WBIndex < 9)
            {
                WhiteBalanceMode.SendControl(myCamera.WhiteBalanceArray[WBIndex - 1].ToString());
            }

            else
            {
                if (Debug == 1) CrestronConsole.PrintLine("\n Core: OnWhiteBalanceModeDec: Value out of Range");
            }
        }

        public void OnAWB()
        {
            AWB.SendControl("");
        }

        public void OnABB()
        {
            AWB.SendControl("");
        }

        // Presets

        public void OnPresetSpeedUnit(ushort value)
        {
            if ((value == 0) || (value == 1))
            {
                PresetSpeedUnit.SendControl(value.ToString());
            }
            else
            {
                if (Debug == 1) CrestronConsole.PrintLine("\n Core: OnPresetSpeedUnit: Value out of Range"); 
            }
        }

        public void OnPresetSpeedTable(ushort value)
        {
            if ((value == 0) || (value == 2))
            {
                PresetSpeedTable.SendControl(value.ToString());
            }
            else
            {
                if (Debug == 1) CrestronConsole.PrintLine("\n Core: OnPresetSpeedTable: Value out of Range");
            }
        }

        public void OnPresetSpeed(ushort value)
        {
            if ((value >= 0) || (value <= 999))
            {
                PresetSpeed.SendControl(value.ToString("D3"));
            }
            else
            {
                if (Debug == 1) CrestronConsole.PrintLine("\n Core: OnPresetSpeed: Value out of Range");
            }
        }

        public void OnPresetThumbnailUpdate(ushort value)
        {
            if ((value == 0) || (value == 1))
            {
                PresetThumbnailUpdate.SendControl(value.ToString());
            }
            else
            {
                if (Debug == 1) CrestronConsole.PrintLine("\n Core: OnPresetThumbnailUpdate: Value out of Range");
            }
        }

        public void OnPresetName(ushort value)
        {
            if ((value == 0) || (value == 1))
            {
                PresetName.SendControl(value.ToString());
            }
            else
            {
                if (Debug == 1) CrestronConsole.PrintLine("\n Core: OnPresetName: Value out of Range");
            }
        }

        public void OnRecallPresetMemory(ushort value)
        {
            value -= 1;

            if ((value >= 0) || (value <= 99))
            {
                RecallPreset.SendControl(value.ToString("D2"));
            }
            else
            {
                if (Debug == 1) CrestronConsole.PrintLine("\n Core: OnRecallPresetMemory: Value out of Range");
            }
        }

        public void OnSavePresetMemory(ushort value)
        {
            value -= 1;

            if ((value >= 0) || (value <= 99))
            {
                SavePreset.SendControl(value.ToString("D2"));
            }
            else
            {
                if (Debug == 1) CrestronConsole.PrintLine("\n Core: OnSavePresetMemory: Value out of Range");
            }

            UpdatePresetThumbnails.SendControl(value.ToString("D2"));
            SavePresetName.SendRequest(value.ToString("D2"));
        }

        public void OnDeletePresetMemory(ushort value)
        {
            value -= 1;

            if ((value >= 0) || (value <= 99))
            {
                DeletePreset.SendControl(value.ToString("D2"));
            }
            else
            {
                if (Debug == 1) CrestronConsole.PrintLine("\n Core: OnDeletePresetMemory: Value out of Range");
            }
           
            UpdatePresetThumbnails.SendControl(value.ToString("D2"));
            SavePresetName.SendRequest(value.ToString("D2"));
        }

        public void OnPresetEntryConf()
        {
            PresetEntryConfirmation.SendRequest("");
        }

        public void OnRequestLatestRecallPreset()
        {
            RequestLatestRecallPreset.SendRequest("");
        }

        public void OnSavePresetName(ushort value, SimplSharpString name)
        {
            value -= 1;

            if ((value >= 0) || (value <= 99))
            {
                string namePadded = name.ToString();
                SavePresetName.SendControl(string.Format("{0}:{1}", value.ToString("D2"), namePadded.PadRight(15)));
            }
            else
            {
                if (Debug == 1) CrestronConsole.PrintLine("\n Core: OnSavePresetName: Value out of Range");
            }
        }

        public void OnGetPresetName(ushort presetBank)
        {
            Int16 presetBankMaxValue = Convert.ToInt16(((presetBank) * 9) - 1);
            Int16 presetBankMinValue = Convert.ToInt16((presetBankMaxValue) - 8);

            for (int i = presetBankMinValue; i <= presetBankMaxValue; i++)
            {
                if (i > 100)
                {
                    break;
                }
                else
                {
                    SavePresetName.SendRequest(i.ToString("D2"));
                }
            }
        }
        
        public void OnDeletePresetName(ushort value)
        {
            value -= 1;

            if ((value >= 0) || (value <= 99))
            {
                DeletePresetName.SendControl(value.ToString("D2"));
            }
            else
            {
                if (Debug == 1) CrestronConsole.PrintLine("\n Core: OnDeletePresetName: Value out of Range");
            }
        }

        public void OnDeleteAllPresetNames()
        {
            DeleteAllPresetNames.SendControl("");
        }

        public void OnUpdatePresetThumbnail(ushort value)
        {
            value -= 1;

            if ((value >= 0) || (value <= 99))
            {
                UpdatePresetThumbnails.SendControl(value.ToString("D2"));
            }
            else
            {
                if (Debug == 1) CrestronConsole.PrintLine("\n Core: OnUpdatePresetThumbnail: Value out of Range");
            }
        }

        public void OnDeletePresetThumbnail(ushort value)
        {
            value -= 1;

            if ((value >= 0) || (value <= 99))
            {
                DeletePresetThumbnail.SendControl(value.ToString("D2"));
            }
            else
            {
                if (Debug == 1) CrestronConsole.PrintLine("\n Core: OnDeletePresetThumbnail: Value out of Range");
            }
        }

        public void OnDeleteAllPresetThumbnails()
        {
            DeleteAllPresetThumbnails.SendControl("");
        }

        public void OnPresetNameCounter(ushort value)
        {
            PresetNameCounter.SendRequest(value.ToString());
        }

        // PTZ

        public void OnInstallPosition(ushort value)
        {
            InstallPosition.SendControl(value.ToString());
        }

        public void OnPTSpeedMode(ushort value)
        {
            PTSpeedMode.SendControl(value.ToString());
        }

        public void OnSpeedWithZoomPosition(ushort value)
        {
            SpeedWithZoomPos.SendControl(value.ToString());
        }

        public void OnFocusAdjustWithPTZ(ushort value)
        {
            FocusAdjustWithPTZ.SendControl(value.ToString());
        }

        public void OnPrivacyMode(ushort value)
        {
            PrivacyMode.SendControl(value.ToString());
        }

        public void OnPowerOnPosition(ushort value)
        {
            PowerOnPosition.SendControl(value.ToString());
        }

        public void OnPowerOnPresetNumber(ushort value)
        {
            PowerOnPresetNumber.SendControl(value.ToString());
        }

        public void OnPanSpeedControl(ushort value)
        {
            PanSpeed.SendControl(value.ToString("D2"));
        }

        public void OnTiltSpeedControl(ushort value)
        {
            TiltSpeed.SendControl(value.ToString("D2"));
        }

        public void OnPanTiltSpeedControl(ushort panPos, ushort tiltPos)
        {
            int oldRange = (65535 - 0);
            int newRange = (99 - 01);
            int newPanPos = (((panPos - 0) * newRange) / oldRange) + 01;
            int newTiltPos = (((tiltPos - 0) * newRange) / oldRange) + 01;

            PanTiltSpeed.SendControl(string.Format("{0}{1}", newPanPos.ToString("D2"), newTiltPos.ToString("D2")));
        }

        public void OnPanTiltAbsolutePosition(ushort panPos, ushort tiltPos)
        {
            AbsolutePosControl.SendControl(string.Format("{0}{1}", panPos.ToString("X4"), tiltPos.ToString("X4")));
        }

        public void OnPanTiltRelativePosition(ushort xPos, ushort yPos, ushort resolution)
        {
            decimal ratio = 16 / 9m;

            Int16 xCanvas = Convert.ToInt16(resolution);
            Int16 yCanvas = Convert.ToInt16(resolution / ratio);

            double xScaled = ConvertRange(0, 65535, 0, xCanvas, xPos);
            double yScaled = ConvertRange(0, 65535, 0, yCanvas, yPos);

            int yReversed = reverseNumber(Convert.ToInt16(yScaled), 0, yCanvas);

            Core.Enqueue(string.Format("/cgi-bin/center_click?x={0}&y={1}&oz={2}&dz={3}&position={4}&resolution={5}", xScaled, yReversed, myCamera.zoom.ToString("X3"), myCamera.digitalZoom, Convert.ToInt16(myCamera.position).ToString(), resolution));
        }

        public void OnPanTiltAbsolutePositionWithSpeed(ushort panPos, ushort tiltPos, ushort presetSpeed, ushort presetTable)
        {
            AbsolutePosControlWithSpeed.SendControl(string.Format("{0}{1}{2}{3}", panPos, tiltPos, presetSpeed, presetTable));
        }

        public void OnPanTiltRelativePositionWithSpeed(ushort panPos, ushort tiltPos, ushort presetSpeed, ushort presetTable)
        {
            RelativePosControlWithSpeed.SendControl(string.Format("{0}{1}{2}{3}", panPos, tiltPos, presetSpeed, presetTable));
        }

        public void OnLimitationControl(ushort direction, ushort set)
        {
            LimitationControl.SendControl(string.Format("{0}{1}", direction, set));
        }

        public void OnLimitationControlTog(ushort direction, ushort set)
        {
            LimitationControlToggle.SendControl(string.Format("{0}{1}", direction, set));
        }

        #endregion

        public static int ConvertRange(int originalStart, int originalEnd, int newStart, int newEnd, int value)
        {
            double scale = (double)(newEnd - newStart) / (originalEnd - originalStart);
            return (int)(newStart + ((value - originalStart) * scale));
        }

        public static double ConvertRangeDouble(int originalStart, int originalEnd, int newStart, int newEnd, int value)
        {
            double scale = (double)(newEnd - newStart) / (originalEnd - originalStart);
            return (double)(newStart + ((value - originalStart) * scale));
        }

        public int reverseNumber(int num, int min, int max)
        {
            return (max + min) - num;
        }
    }


    public class PresetNumberEventArgs : EventArgs
    {
        public ushort dictLength;
        public ushort[] presetNum;
        public ushort[] presetValue;

        public PresetNumberEventArgs() { }
    }

    public class ErrorInfoEventArgs : EventArgs
    {
        public ushort dictLength;
        public ushort[] errorNum;
        public ushort[] errorValue;

        public ErrorInfoEventArgs() { }

    }
}
