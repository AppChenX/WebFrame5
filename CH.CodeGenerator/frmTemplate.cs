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
        IniFile iniFile = new IniFile(Constant.iniFileName);

        public frmTemplate()
        {
            InitializeComponent();

            string path= iniFile.GetString(Constant.ini_Section_name, Constant.ini_Section_templateFile, "");

            string dir= iniFile.GetString(Constant.ini_Section_name, Constant.ini_Section_outDirectory, "");
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
          
            if(string.IsNullOrEmpty(txtPath.Text))
            {
                MessageBox.Show("模板文件不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!System.IO.File.Exists(txtPath.Text.Trim()))
            {
                MessageBox.Show("不存在此文件模板", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!string.IsNullOrEmpty(txtoutDir.Text))
            {
                if(!System.IO.Directory.Exists(txtoutDir.Text.Trim()))
                {
                    MessageBox.Show("不存在此路径", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //Write a int32 value
            iniFile.WriteValue(Constant.ini_Section_name, Constant.ini_Section_templateFile, txtPath.Text);
            iniFile.WriteValue(Constant.ini_Section_name, Constant.ini_Section_outDirectory, txtoutDir.Text);
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
