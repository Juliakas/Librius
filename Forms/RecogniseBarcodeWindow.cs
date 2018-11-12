using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLibrarian.Data;
using MyLibrarian.Detection;

namespace MyLibrarian.Forms
{
    public partial class RecogniseBarcodeWindow : Form
    {
        Webcam webcam;

        public RecogniseBarcodeWindow()
        {
            InitializeComponent();
            webcam = new Webcam(pictureBox1);
            webcam.cameraStart();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            webcam.takePicture();
            BarcodeScanning.Scan(pictureBox1.Image);
            webcam.takePicture();
        }
    }
}
