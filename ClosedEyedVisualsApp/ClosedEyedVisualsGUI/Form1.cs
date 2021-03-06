﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using ClosedEyedVisualsApp;
using tessnet2;
//using System.Threading;

namespace ClosedEyedVisualsGUI
{
    public partial class Form1 : Form
    {
        public Form1 form = null;
       
        
        private Int32 timeStampStart;
        private int timeStampEnd;
        private int totalProcessingTime;
        //private bool DeviceExist = false;
        //private FilterInfoCollection videoDevices;
        //private VideoCaptureDevice videoSource = null;
        //private bool captureFromDeviceActive;
        private bool videoSourceInitialized_Global;
        private int videoProperty_ResolutionId = 2; //0 = 720p, 1= 800x600, 2=640x480
        private Bitmap cameraImage_Global;
        public InputDataHandler formData = new InputDataHandler();
        //private BackgroundWorker camImageUpdateThread;
        private PointGreyFlyCapture PGRCamHandler = new PointGreyFlyCapture();
        //private AutoResetEvent camImageUpdateThreadExited = new AutoResetEvent(false);
        private VideoSourceHandler videoSrcHandler = new VideoSourceHandler();


        public Form1()
        {
            InitializeComponent();
            form = this;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        //// get the devices name
        //private void getCamList()
        //{
        //    try
        //    {
        //        videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        //        comboBox_VideoDevicesList.Items.Clear();
        //        if (videoDevices.Count == 0)
        //            throw new ApplicationException();

        //        DeviceExist = true;
        //        foreach (FilterInfo device in videoDevices)
        //        {
        //            comboBox_VideoDevicesList.Items.Add(device.Name);
        //        }
        //        comboBox_VideoDevicesList.SelectedIndex = 0; //make dafault to first cam
        //    }
        //    catch (ApplicationException)
        //    {
        //        DeviceExist = false;
        //        comboBox_VideoDevicesList.Items.Add("No capture device on your system");
        //    }
        //}

        //refresh button
        private void button_RefreshVideoDeviceList_Click(object sender, EventArgs e)
        {
            //getCamList();
            videoSrcHandler.GetCamList();
            comboBox_VideoDevicesList.Items.Clear();

            if (videoSrcHandler.videoDevices.Count==0)
            {
                comboBox_VideoDevicesList.Items.Add("No capture device on your system");
            }
            
            foreach (FilterInfo device in videoSrcHandler.videoDevices)
            {
                comboBox_VideoDevicesList.Items.Add(device.Name);
            }
            comboBox_VideoDevicesList.SelectedIndex = 0; //make dafault to first cam 


        }

        //Start Capturing from Camera
        private void button_StartImageSource_Click(object sender, EventArgs e)
        {
            if (button_StartImageSource.Text == "Start")
            {                
                if (videoSrcHandler.DeviceExist)
                {


                    videoProperty_ResolutionId = Int32.Parse(textBox_VideoMode.Text);  // Read VideoMode from form
                    videoSrcHandler.StartCapturing(comboBox_VideoDevicesList.SelectedIndex, videoProperty_ResolutionId);
                    textBox_CameraInfo.AppendText("VideoResolution:" + videoSrcHandler.videoSource.VideoCapabilities[videoProperty_ResolutionId].FrameSize.ToString());
                    textBox_CameraInfo.AppendText("VideoFrameRate:" + videoSrcHandler.videoSource.VideoCapabilities[videoProperty_ResolutionId].AverageFrameRate.ToString());
                    textBox_CameraInfo.Refresh();
                    label_ImageSourceStatus.Text = "Device running...";
                    button_StartImageSource.Text = "Stop";
                    timer_Runtime.Enabled = true;
                    videoSourceInitialized_Global = videoSrcHandler.videoSourceInitialized;
                    //StartImageUpdateThread();
                }
                else
                {
                    label_ImageSourceStatus.Text = "Error: No Device selected.";
                    label_ImageSourceStatus.Refresh();
                }
            }
            else
            {
                if (videoSourceInitialized_Global)
                {
                    timer_Runtime.Enabled = false;
                    videoSrcHandler.CloseVideoSource();
                    label_ImageSourceStatus.Text = "Device stopped.";
                    button_StartImageSource.Text = "Start";
                    videoSourceInitialized_Global = false;
                }
            }
        }



        //prevent sudden close while device is running
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            videoSrcHandler.CloseVideoSource();
            videoSourceInitialized_Global = false;
        }
        
        private void SetFormData() {

            try
            {
                if (videoSourceInitialized_Global)
                {
                    formData.SourceImage = cameraImage_Global;
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

        // This timer willl update the picture box with webcam image, set the timer update value in the settings menu. 
        private void timer_Runtime_Tick(object sender, EventArgs e)
        {
            // check which source is initialized PGRFlyCap or webCam
            if (videoSrcHandler.videoSourceInitialized)
            {
                cameraImage_Global = videoSrcHandler.cameraImage;   //webcam image
                label_ImageSourceStatus.Text = "Device running... " + videoSrcHandler.videoSource.FramesReceived.ToString() + " FPS";
                label_ImageSourceStatus.Refresh();
            }
            else {
                cameraImage_Global = PGRCamHandler.m_processedImage.bitmap;  // PGRCam image
            }
            pictureBox_ImageSource.Image = cameraImage_Global;
            pictureBox_ImageSource.Refresh();

        }

        private void button_TakeSnapshot_Click(object sender, EventArgs e)
        {
            if (videoSourceInitialized_Global)
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
            Bitmap image;
            if (videoSourceInitialized_Global)
            {
                image = cameraImage_Global;
            }
            else { 
                image = (Bitmap)Bitmap.FromFile(textBox_OcrImage.Text);
            }


            var ocrObj = new ClosedEyeVisualsOCR();
            var results = ocrObj.GetTextFromImage(image);

            foreach (Word word in results) {
                Console.WriteLine("{0} : {1}", word.Confidence, word.Text);
                textBox_OcrResult.AppendText("Confidence:" + word.Confidence.ToString() +", Text: "+word.Text +"\n");
                textBox_OcrResult.Refresh();
            }


        }


        //Init PointGreyCam
        private void button_startPointGreyCam_Click(object sender, EventArgs e)
        {

            if (button_startPointGreyCam.Text == "StartPointGreyCam")
            {
                try
                {
                    videoSourceInitialized_Global = true;
                    PGRCamHandler.StartPGRCam();
                    //using the timer function to update PGRCamImage to picturebox instead of manual thread handling in this class.
                    //  StartImageUpdateThread();
                    timer_Runtime.Enabled = true;   // this timer will update the image from PGRCam to picture box
                    button_startPointGreyCam.Text = "StopPGRCam";
                    button_startPointGreyCam.Refresh();

                }
                catch (Exception exceptionPGRCamHandling)
                {

                    System.Console.WriteLine("Exception occured while initializing PGRCam:" + exceptionPGRCamHandling.ToString());
                } 
            }

            else
            {
                timer_Runtime.Enabled = false;
                videoSourceInitialized_Global = false;
                PGRCamHandler.StopPGRCam();
                //camImageUpdateThreadExited.Set();
                //camImageUpdateThread.Dispose();
                button_startPointGreyCam.Text = "StartPointGreyCam";
                button_startPointGreyCam.Refresh();

            }

        }

        ////Thread to update UI and CamImage
        //private void StartImageUpdateThread()
        //{
        //    camImageUpdateThread =  new BackgroundWorker();
        //    camImageUpdateThread.ProgressChanged += new ProgressChangedEventHandler(camImageUpdateThreadProgressChanged);
        //    camImageUpdateThread.DoWork += new DoWorkEventHandler(camImageUpdateThread_DoWork);
        //    camImageUpdateThread.WorkerReportsProgress = true;
        //    camImageUpdateThread.RunWorkerAsync();
            
        //}

        //private void camImageUpdateThreadProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    cameraImage_Global = PGRCamHandler.m_processedImage.bitmap;
        //    pictureBox_ImageSource.Image = PGRCamHandler.m_processedImage.bitmap;
        //    pictureBox_ImageSource.Refresh();
        //    //tmpImage.Dispose();
        //}

        //private void camImageUpdateThread_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    BackgroundWorker worker = sender as BackgroundWorker;

        //    while (videoSourceInitialized_Global)
        //    {

        //        cameraImage_Global = PGRCamHandler.m_processedImage.bitmap;
        //        worker.ReportProgress(0);
        //        Thread.Sleep(13);  // 13 milliseconds is the least value you could provide, to keep the GUI responsive.
        //    }
        //    if (videoSourceInitialized_Global == false)
        //    {
        //        camImageUpdateThreadExited.Set();
        //    }
        //}


    }

    


}
