using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;

namespace ClosedEyedVisualsApp
{
    public class VideoSourceHandler
    {
        //private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource = null;
        public bool deviceAvailable = false;

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


    }
}
