using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using ClosedEyedVisualsApp;
using tessnet2;


namespace ClosedEyedVisualsGUI
{
    public partial class Form1 : Form
    {
        private Int32 timeStampStart;
        private int timeStampEnd;
        private int totalProcessingTime;
        private bool DeviceExist = false;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource = null;
        private bool captureFromDeviceActive;
        private bool videoSourceInitialized;
        private int videoProperty_ResolutionId = 2; //0 = 720p, 1= 800x600, 2=640x480
        private Bitmap CameraImage;
        public InputDataHandler formData = new InputDataHandler();

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        // get the devices name
        private void getCamList()
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                comboBox_VideoDevicesList.Items.Clear();
                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                DeviceExist = true;
                foreach (FilterInfo device in videoDevices)
                {
                    comboBox_VideoDevicesList.Items.Add(device.Name);
                }
                comboBox_VideoDevicesList.SelectedIndex = 0; //make dafault to first cam
            }
            catch (ApplicationException)
            {
                DeviceExist = false;
                comboBox_VideoDevicesList.Items.Add("No capture device on your system");
            }
        }

        //refresh button
        private void button_RefreshVideoDeviceList_Click(object sender, EventArgs e)
        {
            getCamList();
        }

        //Start Capturing from Camera
        private void button_StartImageSource_Click(object sender, EventArgs e)
        {
            if (button_StartImageSource.Text == "Start")
            {                
                if (DeviceExist)
                {
                   
                    videoSource = new VideoCaptureDevice(videoDevices[comboBox_VideoDevicesList.SelectedIndex].MonikerString);
                    videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                    CloseVideoSource();

                    videoProperty_ResolutionId = Int32.Parse(textBox_VideoMode.Text);  // Read VideoMode from form
                    if (videoProperty_ResolutionId >= videoSource.VideoCapabilities.Length)
                    {
                        videoProperty_ResolutionId = 0;
                        MessageBox.Show("VideoMode not available, using default");
                    }
                    videoSource.VideoResolution = videoSource.VideoCapabilities[videoProperty_ResolutionId];
                    textBox_CameraInfo.AppendText("VideoResolution:" + videoSource.VideoCapabilities[videoProperty_ResolutionId].FrameSize.ToString());
                    textBox_CameraInfo.AppendText("VideoFrameRate:" + videoSource.VideoCapabilities[videoProperty_ResolutionId].AverageFrameRate.ToString());
                    textBox_CameraInfo.Refresh();
                    
                    videoSource.Start();
                    label_ImageSourceStatus.Text = "Device running...";
                    button_StartImageSource.Text = "Stop";
                    timer_Runtime.Enabled = true;
                    videoSourceInitialized = true;
                }
                else
                {
                    label_ImageSourceStatus.Text = "Error: No Device selected.";
                    label_ImageSourceStatus.Refresh();
                }
            }
            else
            {
                //if (videoSource.IsRunning)
                if (videoSourceInitialized)
                {
                    timer_Runtime.Enabled = false;
                    CloseVideoSource();
                    label_ImageSourceStatus.Text = "Device stopped.";
                    button_StartImageSource.Text = "Start";
                }
            }
        }

        //eventhandler if new frame is ready
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            CameraImage = (Bitmap)eventArgs.Frame.Clone();
            //do processing here
            pictureBox_ImageSource.Image = CameraImage;

        }

        //close the device safely
        private void CloseVideoSource()
        {
            if (!(videoSource == null))
                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource = null;
                    videoSourceInitialized = false;
                }
        }

        //prevent sudden close while device is running
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseVideoSource();
        }


        private void SetFormData() {

            try
            {
                if (videoSourceInitialized)
                {
                    formData.SourceImage = CameraImage;
                    textBox_CameraInfo.AppendText("ImageSource Webcam..");
                    textBox_CameraInfo.Refresh();
                }
                else {
                    //Program.sourceImageAddress = textBox_SourceImage.Text;
                    formData.SourceImage = (Bitmap)Bitmap.FromFile(textBox_SourceImage.Text);
                    label_ResultOutput.Text = "ImageSource src.jpg..";
                    label_ResultOutput.Refresh();
                }

                formData.TemplateImage = (Bitmap)Bitmap.FromFile(textBox_TemplateImage.Text);
                formData.RoiWidth = Int32.Parse(textBox_RoiWidth.Text);
                formData.RoiHeight = Int32.Parse(textBox_RoiHeight.Text);
                formData.RoiPointX = Int32.Parse(textBox_PointX.Text);
                formData.RoiPointY = Int32.Parse(textBox_PointY.Text);
                formData.PyramidLevels = Int32.Parse(textBox_PyramidLevels.Text);
                formData.Threshold = float.Parse(textBox_Treshold.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Error in setting formData");
                //throw;
            }
        }

        //Matching Functions
        private void button_ExhaustiveMatchingInROI_Click(object sender, EventArgs e)
        {
            SetFormData();
            
            label_ResultOutput.Text = "Processing ....";
            label_ResultOutput.Refresh();
            timeStampStart = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            TemplateDetection templateDetectionObj = new TemplateDetection(formData);
            TemplateMatchingResults result = templateDetectionObj.FindTemplateInROI();
            
            if (result.MatchFound){
                label_ResultOutput.Text = "Match Found";
            }
            else {
                label_ResultOutput.Text = "Match Not found";
            }
            label_ResultOutput.Refresh();

            timeStampEnd = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            totalProcessingTime = timeStampEnd - timeStampStart;
            label_ProcessingTimeOutput.Text = totalProcessingTime.ToString();
            label_ProcessingTimeOutput.Refresh();

            label_SimilarityOutput.Text = result.SimilarityMax.ToString();
            label_SimilarityOutput.Refresh();

        }

        private void button_ExhaustiveMatching_Click(object sender, EventArgs e)
        {

            SetFormData();

            label_ResultOutput.Text = "Processing ....";
            label_ResultOutput.Refresh();
            timeStampStart = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            TemplateDetection templateDetectionObj = new TemplateDetection(formData);
            TemplateMatchingResults result = templateDetectionObj.FindTemplateInImageExhaustively();
            
            if (result.MatchFound){
                label_ResultOutput.Text = "Match Found";
            }
            else {
                label_ResultOutput.Text = "Match Not found";
            }

            label_ResultOutput.Refresh();

            timeStampEnd = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            totalProcessingTime = timeStampEnd - timeStampStart;
            label_ProcessingTimeOutput.Text = totalProcessingTime.ToString();
            label_ProcessingTimeOutput.Refresh();

            label_SimilarityOutput.Text = result.SimilarityMax.ToString();
            label_SimilarityOutput.Refresh();
        }

        private void timer_Runtime_Tick(object sender, EventArgs e)
        {
            label_ImageSourceStatus.Text = "Device running... " + videoSource.FramesReceived.ToString() + " FPS";
            label_ImageSourceStatus.Refresh();
        }

        private void button_TakeSnapshot_Click(object sender, EventArgs e)
        {
            if (videoSourceInitialized)
            {
                if (pictureBox_ImageSource.Image != null)
                {
                    Bitmap varBmp = new Bitmap(pictureBox_ImageSource.Image);
                    varBmp.Save("SnapShot.bmp", ImageFormat.Bmp);
                    varBmp.Dispose();
                    varBmp = null;
                }
                else {
                    MessageBox.Show("Null Exception");
                }
            }
            else {
                textBox_CameraInfo.AppendText("VideoSource not initialized");
                textBox_CameraInfo.Refresh();
            }
        }

        private void button_StartOCR_Click(object sender, EventArgs e)
        {
            Bitmap image = CameraImage;
            var ocrObj = new ClosedEyeVisualsOCR();
            var results = ocrObj.GetTextFromImage(image);

            foreach (Word word in results) {
                Console.WriteLine("{0} : {1}", word.Confidence, word.Text);
                textBox_OcrResult.AppendText("Confidence:" + word.Confidence.ToString() +", Text: "+word.Text +"\n");
                textBox_OcrResult.Refresh();
            }


        }
    }
}
