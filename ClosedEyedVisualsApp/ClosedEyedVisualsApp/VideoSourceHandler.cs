using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using System.Drawing;

namespace ClosedEyedVisualsApp
{
    public class VideoSourceHandler
    {
        public VideoCaptureDevice videoSource;
        public bool deviceAvailable = false;
        public FilterInfoCollection videoDevices;
        public bool DeviceExist = false;
        public Bitmap cameraImage;
        public bool videoSourceInitialized;
        private int videoProperty_ResolutionId;

        public FilterInfoCollection GetAvailableVideoDeviceList() {
            FilterInfoCollection videoDevices;
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count == 0)
                {
                    throw new ApplicationException();
                }
                else {
                    deviceAvailable = true;

                }
            }
            catch (ApplicationException)
            {
                deviceAvailable = false;
                videoDevices = null;
                throw new ClosedEyedVisuals_Exception("Failed to find video input devices");
            }

            return videoDevices;
        }

        // get the devices name
        public void GetCamList()
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                DeviceExist = true;

            }
            catch (ApplicationException)
            {
                DeviceExist = false;
                System.Console.WriteLine("No capture device on your system");
            }
        }

        //eventhandler if new frame is ready
        private void Video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            cameraImage = (Bitmap)eventArgs.Frame.Clone();
            //do processing here
            

        }

        public void StartCapturing(int deviceId, int mode)
        {
            videoSource = new VideoCaptureDevice(videoDevices[deviceId].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(Video_NewFrame);
            CloseVideoSource();

            videoProperty_ResolutionId = mode; // Read VideoMode 
            if (videoProperty_ResolutionId >= videoSource.VideoCapabilities.Length)
            {
                videoProperty_ResolutionId = 0;
                Console.WriteLine("VideoMode not available, using default");
            }
            videoSource.VideoResolution = videoSource.VideoCapabilities[videoProperty_ResolutionId];
            Console.WriteLine("VideoResolution:" + videoSource.VideoCapabilities[videoProperty_ResolutionId].FrameSize.ToString());
            Console.WriteLine("VideoFrameRate:" + videoSource.VideoCapabilities[videoProperty_ResolutionId].AverageFrameRate.ToString());
            
            videoSource.Start();
            videoSourceInitialized = true;
        }

        //close the device safely
        public void CloseVideoSource()
        {
            if (!(videoSource == null))
                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource = null;
                    //videoSourceInitialized = false;
                }
            videoSourceInitialized = false;
        }

    }
}
