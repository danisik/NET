﻿using DataLayer.Data;
using PresentationLayer.GUIElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Window
{
    public partial class GraphWindow : Form
    {
        private readonly DatabaseInterface databaseInterface;
        private String appName = "";
        private MainWindow mainWindow;

        public GraphWindow(MainWindow mainWindow)
        {
            InitializeComponent();

            this.databaseInterface = mainWindow.DatabaseInterface;
            this.Text = mainWindow.AppName + " - Grafy";
            this.appName = mainWindow.AppName;
            this.mainWindow = mainWindow;
        }

        private void btnReturnFromGraph_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
