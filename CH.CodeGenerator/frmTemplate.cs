using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CH.Common.Utility;

namespace CH.CodeGenerator
{
    public partial class frmTemplate : Form
    {
        IniFile iniFile = new IniFile("Settings.ini");
        public frmTemplate()
        {
            InitializeComponent();

            string path= iniFile.GetString("Template", "file","");

            string dir= iniFile.GetString("Template", "outdir", "");
            txtPath.Text = path;
            txtoutDir.Text = dir;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            using (var openFile = new OpenFileDialog())
            {
                openFile.Filter = "C#文件|*.cs|所有文件|*.*";
                if (openFile.ShowDialog() == DialogResult.OK)
                {

                    txtPath.Text = openFile.FileName;
                    //var editor = AddNewTextEditor(openFile.FileName);

                    //editor.LoadFile(openFile.FileName);
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
           

            //Write a int32 value
            iniFile.WriteValue("Template", "file", txtPath.Text);
            iniFile.WriteValue("Template", "outdir", txtoutDir.Text);
            this.DialogResult = DialogResult.OK;
        }

        private void frmTemplate_Load(object sender, EventArgs e)
        {

        }

        private void btnDir_Click(object sender, EventArgs e)
        {

            using (var fld = new FolderBrowserDialog())
            { 
                if(fld.ShowDialog()==DialogResult.OK)
                {
                    txtoutDir.Text=fld.SelectedPath;
                  

                }
            }
        }
    }
}
