﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibrarian.Forms
{
    public partial class MainUserWindow : Form
    {
        public MainUserWindow(AuthWindow previousWindow, int userId)
        {
            InitializeComponent();
        }
    }
}
