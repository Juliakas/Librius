using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibrarian.Data
{
    class Webcam
    {
        bool cameraIsRunning;

        FilterInfoCollection device;
        VideoCaptureDevice finalFrame;
        PictureBox pictureBox;

        public Webcam(PictureBox pictureBox)
        {
            cameraIsRunning = true;
            this.pictureBox = pictureBox;
        }



        public void cameraStart()
        {
            device = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            finalFrame = new VideoCaptureDevice(device[0].MonikerString);
            finalFrame.Start();
            finalFrame.NewFrame += new AForge.Video.NewFrameEventHandler(newFrame_event);
            FaceRecognition frecogn = new FaceRecognition();

        }

        public void newFrame_event(object send, NewFrameEventArgs e)
        {
            try
            {
                pictureBox.Image = (Image)e.Frame.Clone();
            }
            catch (Exception ex)
            {

            }

        }

        public bool isCameraRunning()
        {
            return cameraIsRunning;
        }

        public void takePicture()
        {
            if (cameraIsRunning)
            {
                cameraStop();
                cameraIsRunning = false;
            }
            else
            {
                cameraStart();
                cameraIsRunning = true;
            }

        }

        public void cameraStop()
        {
            finalFrame.Stop();
        }
    }
}
