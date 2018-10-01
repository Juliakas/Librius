using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;

namespace MyLibrarian.Forms
{
    public partial class RecogniseFaceWindow : Form
    {
        private readonly IFaceServiceClient faceServiceClient = new FaceServiceClient("4b6ae37dff0042b991b9a8af80e7e46b", "https://westeurope.api.cognitive.microsoft.com/face/v1.0");

        string _imagePath = "";
        string _groupId = "";

        public RecogniseFaceWindow()
        {
            InitializeComponent();
        }



        private void createGroupButton_Click(object sender, EventArgs e)
        {

        }


    }
}
