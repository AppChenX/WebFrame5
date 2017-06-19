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
    public partial class frmSetting : Form
    {
        private SerializerXML<ConnectionStrs> ser = null;
        public frmSetting()
        {
            InitializeComponent();

            ser = new SerializerXML<ConnectionStrs>("config.xml");

            //绑定数据

            var cons = ser.GetObj();

            if (cons != null)
            {
                var lst = cons.ConnectionStrList;
                if (lst != null)
                {
                    SetDataSource(lst);
                    //chklstbox_constr.DataSource = lst;
                    //chklstbox_constr.DisplayMember = "Id";
                    //chklstbox_constr.ValueMember = "Name";
                }
            }
        }




        /// <summary>
        /// 从XML中加载连接字符串
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSetting_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 绑定数据源
        /// </summary>
        /// <param name="lst"></param>
        private void SetDataSource(object lst)
        {
            chklstbox_constr.DataSource = lst;
            chklstbox_constr.DisplayMember = "Name";
            chklstbox_constr.ValueMember = "ID";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            using (var frm = new frmConnection(EditType.New, m =>
            {

                SetDataSource(m.ConnectionStrList);

            }))
            {

                frm.ShowDialog();
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            //获取当前选择的数据

            if (chklstbox_constr.SelectedItem != null)
            {
                var con = chklstbox_constr.SelectedItem as ConnectionStr;

                using (var frm = new frmConnection(EditType.Edit, con, m =>
                {

                    SetDataSource(m.ConnectionStrList);

                }))
                {

                    frm.ShowDialog();
                }
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (chklstbox_constr.SelectedItem != null)
            {

                var item = chklstbox_constr.SelectedItem;

                var con = item as ConnectionStr;

                var cons = ser.GetObj();

                var lst = cons.ConnectionStrList;

                cons.ConnectionStrList.Remove(lst.Where(m => m.Id == con.Id).FirstOrDefault());

                ///重新绑定
                SetDataSource(lst);

                ser.Save(cons);

                //chklstbox_constr.Items.Remove(item);

            }
        }
    }
}
