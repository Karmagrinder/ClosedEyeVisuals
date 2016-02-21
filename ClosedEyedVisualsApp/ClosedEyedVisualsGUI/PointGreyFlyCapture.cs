using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyCapture2Managed;
using FlyCapture2Managed.Gui;
using System.ComponentModel;
using System.Threading;


namespace ClosedEyedVisualsGUI
{
    public class PointGreyFlyCapture
    {
        private ManagedCameraBase m_camera = null;
        private ManagedImage m_rawImage = new ManagedImage();
        public ManagedImage m_processedImage = new ManagedImage();
        private ManagedPGRGuid guidToUse = new ManagedPGRGuid();
        CameraSelectionDialog camSlnDlg = new CameraSelectionDialog();
        private bool m_grabImages;
        private BackgroundWorker m_grabThread;
        private AutoResetEvent m_grabThreadExited = new AutoResetEvent(false);

        public void StartPGRCam() {

            try {
                guidToUse.value0 = 3639281153;
                guidToUse.value1 = 3741026457;
                guidToUse.value2 = 2419196441;
                guidToUse.value3 = 2928867345;

                m_camera = new ManagedCamera();
                m_camera.Connect(guidToUse);
                m_camera.StartCapture();
                m_grabImages = true;
                StartGrabLoop();


            }
            catch (FC2Exception ex)
            {
                System.Console.WriteLine("Failed to load form successfully: " + ex.Message);

            }
        }

        private void StartGrabLoop()
        {
            m_grabThread = new BackgroundWorker();
            m_grabThread.ProgressChanged += new ProgressChangedEventHandler(UpdateUI);
            m_grabThread.DoWork += new DoWorkEventHandler(GrabLoop);
            m_grabThread.WorkerReportsProgress = true;
            m_grabThread.RunWorkerAsync();
        }

        private void GrabLoop(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while (m_grabImages)
            {
                try
                {
                    m_camera.RetrieveBuffer(m_rawImage);
                }
                catch (FC2Exception ex)
                {
                    System.Console.WriteLine("Error: " + ex.Message);
                    continue;
                }

                lock (this)
                {
                    m_rawImage.Convert(PixelFormat.PixelFormatBgr, m_processedImage);
                }

                worker.ReportProgress(0);
            }

            m_grabThreadExited.Set();
        }


        public void StopPGRCam() {
            try
            {
                m_camera.Disconnect();
                m_grabImages = false;
                m_grabThread.Dispose();
            }
            catch (FC2Exception ex)
            {
                System.Console.WriteLine("FC2Exception: "+ ex.ToString());

                // Nothing to do here
            }
            catch (NullReferenceException ex)
            {
                System.Console.WriteLine("NullReferenceException in StopPGR: " + ex.ToString());
                // Nothing to do here
            }
        }


        private void UpdateUI(object sender, ProgressChangedEventArgs e)
        {
            // NewPGRCamFrame(m_processedImage.bitmap);
        }
    }

}
