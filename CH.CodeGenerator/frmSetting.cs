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
        private SerializerXML<ConnectionStrs> ser = new SerializerXML<ConnectionStrs>(Constant.xmlFileName);
        public frmSetting()
        {
            InitializeComponent();

            chklstbox_constr.ItemCheck += Chklstbox_constr_ItemCheck;
             

            //绑定数据

            var cons = ser.GetObj();

            if (cons != null)
            {
                var lst = cons.ConnectionStrList;
                if (lst != null)
                {
                    SetDataSource(lst); 
                }
            }
        }
        private Action<ConnectionStr> OkHandler;
        public frmSetting(Action<ConnectionStr> OkHandler) :this()
        {
            this.OkHandler = OkHandler;
        }


        /// <summary>
        /// 设置只能单选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Chklstbox_constr_ItemCheck(object sender, ItemCheckEventArgs e)
        {
             

            for (int i = 0; i < chklstbox_constr.CheckedIndices.Count; i++)
            {
                if (chklstbox_constr.CheckedIndices[i] != e.Index)
                {
                    chklstbox_constr.SetItemChecked(chklstbox_constr.CheckedIndices[i], false);
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

            //选择中

            foreach(var item in lst as IList<ConnectionStr>)
            {

               if(item.Checked)
                {
                    chklstbox_constr.SetItemChecked(chklstbox_constr.Items.IndexOf(item), true);
                }

            }
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

        private void btnOk_Click(object sender, EventArgs e)
        {

            var ccount= chklstbox_constr.CheckedItems.Count;
             
            if (ccount == 1)
            {
                var cons = ser.GetObj();

                var item = chklstbox_constr.CheckedItems[0] as ConnectionStr;

                ConnectionStr rs = null;

                cons.ConnectionStrList.ForEach(m =>
                {

                    if (m.Id == item.Id)
                    {
                        rs = m;
                        m.Checked = true;
                    }
                    else
                        m.Checked = false;
                });

                ser.Save(cons);

                OkHandler(rs);

                this.DialogResult = DialogResult.OK;
            }

            else
            {
                MessageBox.Show("选择一个连接字符串", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              
            }
            
            //设置选中




        }
    }
}
