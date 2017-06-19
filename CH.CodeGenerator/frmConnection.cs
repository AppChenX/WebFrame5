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
    public partial class frmConnection : Form
    {

        private EditType editType { get; set; }
        private ConnectionStr con { get; set; }
        private Action<ConnectionStrs> okHandler { get; set; }
        SerializerXML<ConnectionStrs> ser = new SerializerXML<ConnectionStrs>("config.xml");

        public frmConnection()
        {
            InitializeComponent();
        }

        public frmConnection(EditType editType,Action<ConnectionStrs> okHandler) : this()
        {
            this.editType = editType;
            this.okHandler = okHandler;
        }

        public frmConnection(EditType editType,ConnectionStr con, Action<ConnectionStrs> okHandler) :this(editType, okHandler)
        {
            this.con = con;

            this.txtConStr.Text = con.Value;
            this.txtName.Text = con.Name;
        }

        /// <summary>
        /// 测试连接字符串
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 向XML文件中写数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntOk_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(txtConStr.Text.Trim())|| string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                return;
            }

            ConnectionStrs cons = null;
            cons = ser.GetObj();

            if(cons != null)
            {

                //判断是否为编辑
               if(editType==EditType.Edit)
                {

                   var con_old=  cons.ConnectionStrList.Where(m => m.Id == con.Id).FirstOrDefault();
                    con_old.Name = txtName.Text.Trim();
                    con_old.Value = txtConStr.Text.Trim();
                }
                else
                {
                    cons.ConnectionStrList.Add(new ConnectionStr() { Checked = false, Name = txtName.Text.Trim(), Value = txtConStr.Text.Trim(), Id = GenerateIntID().ToString() });
                }

                 
            

            }
            else
            {
                cons = new ConnectionStrs()
                {
                    ConnectionStrList = new List<ConnectionStr>() {

                        new ConnectionStr(){ Checked=false, Name=txtName.Text.Trim(), Value=txtConStr.Text.Trim(), Id=GenerateIntID().ToString()}
                    }
                };
               
            }
            ser.Save(cons);
            okHandler(cons);

            this.DialogResult = DialogResult.OK;

        }

        private long GenerateIntID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }



    }

    /// <summary>
    /// 编辑状态
    /// </summary>
    public enum EditType
    {
        New=0,

        Edit=1
    }
}
