using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.SchemaProvider;
using LinqToDB.DataProvider;

namespace CH.CodeGenerator
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// 获取选中TextEditorControl
        /// </summary>
        private TextEditorControl ActiveEditor
        {
            get
            {
                if (fileTabs.TabPages.Count == 0) return null;
                return fileTabs.SelectedTab.Controls.OfType<TextEditorControl>().FirstOrDefault();
            }
        }
        private void RemoveTextEditor(TextEditorControl editor)
        {
            ((TabControl)editor.Parent.Parent).Controls.Remove(editor.Parent);
        }




        private TextEditorControl AddNewTextEditor(string title)
        {
            var tab = new TabPage(title);

            var editor = new TextEditorControl();
            editor.Dock = System.Windows.Forms.DockStyle.Fill;
            editor.IsReadOnly = false;
            editor.Document.DocumentChanged +=
                new DocumentEventHandler((sender, e) => { });

            tab.Enter +=
                new EventHandler((sender, e) =>
                {
                    var page = ((TabPage)sender);

                    page.BeginInvoke(new Action<TabPage>(p => p.Controls[0].Focus()), page);
                });
            tab.Controls.Add(editor);
            fileTabs.Controls.Add(tab);

            return editor;
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            chklstbx_Tables.Items.Clear();

            //List<Student> lst = new List<Student>() { new Student() { Id = "1", Name = "测试1" }, new Student() { Id = "2", Name = "测试2" } }; 

            //chklstbx_Tables.DataSource = lst;

            //chklstbx_Tables.DisplayMember = "Name";

            //chklstbx_Tables.ValueMember = "Id";

        }

        private void btnGenerator_Click(object sender, EventArgs e)
        {


        }

        private void ToolStripMenuItem_open_Click(object sender, EventArgs e)
        {


            using (var openFile = new OpenFileDialog())
            {
                openFile.Filter = "C#文件|*.cs|所有文件|*.*";
                if (openFile.ShowDialog() == DialogResult.OK)
                {

                    var editor = AddNewTextEditor(openFile.FileName);

                    editor.LoadFile(openFile.FileName);
                }
            }


        }

        private void btnGenerator_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(ActiveEditor.Parent.ToString());
        }

        private void ToolStripMenuItem_save_Click(object sender, EventArgs e)
        {

            if (ActiveEditor != null)
            {
                TextEditorControl editor = ActiveEditor;

                editor.SaveFile(editor.FileName);
            }

        }

        private void ToolStripMenuItem_close_Click(object sender, EventArgs e)
        {
            if (ActiveEditor != null)
            {
                TextEditorControl editor = ActiveEditor;
                ((TabControl)editor.Parent.Parent).Controls.Remove(editor.Parent);
            }
        }

        private void ToolStripMenuItem_saveAs_Click(object sender, EventArgs e)
        {
            if (ActiveEditor != null)
            {
                TextEditorControl editor = ActiveEditor;

                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "C#文件|*.cs|所有文件|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        editor.SaveFile(saveFileDialog.FileName);
                    }
                }
            }
        }

        public class Student
        {
            public string Id { get; set; }

            public string Name { get; set; }
        }

        /// <summary>
        /// 设置连接字符串
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_settings_Click(object sender, EventArgs e)
        {

        }

        private void loadDataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new frmSetting((con) =>
            {

                try
                {

                    //加载表
                    LoadDataBaseTable(con);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }))
            {
                frm.ShowDialog();
            }
        }


        private void LoadDataBaseTable(ConnectionStr con)
        {

            IDataProvider provider = GetDataProvider(con.Provider);
            using (var db = new DataConnection(provider, con.Value))
            {

                var sp = db.DataProvider.GetSchemaProvider();
                var schema = sp.GetSchema(db);  
                var tables = schema.Tables;

                SetDataSource(tables);
                

            }

            //DataContext db = new DataContext(lin, constr);

        }

        private LinqToDB.DataProvider.IDataProvider GetDataProvider(DataProvider provider)
        {

            switch(provider)
            {
                case DataProvider.Oracle:

                    return new LinqToDB.DataProvider.Oracle.OracleDataProvider("OracleManaged");

                case DataProvider.Sqlserver2000:

                    return new LinqToDB.DataProvider.SqlServer.SqlServerDataProvider("SqlServer", LinqToDB.DataProvider.SqlServer.SqlServerVersion.v2000);

                case DataProvider.Sqlserver2005:

                    return new LinqToDB.DataProvider.SqlServer.SqlServerDataProvider("SqlServer", LinqToDB.DataProvider.SqlServer.SqlServerVersion.v2005);

                case DataProvider.Sqlserver2008:

                    return new LinqToDB.DataProvider.SqlServer.SqlServerDataProvider("SqlServer", LinqToDB.DataProvider.SqlServer.SqlServerVersion.v2008);

                case DataProvider.Sqlserver2010:

                    return new LinqToDB.DataProvider.SqlServer.SqlServerDataProvider("SqlServer", LinqToDB.DataProvider.SqlServer.SqlServerVersion.v2012);

                case DataProvider.MySql: 

                    return new LinqToDB.DataProvider.MySql.MySqlDataProvider();

                case DataProvider.Access:

                    return new LinqToDB.DataProvider.Access.AccessDataProvider();

                case DataProvider.Sqlite:

                    return new LinqToDB.DataProvider.SQLite.SQLiteDataProvider();

                default:

               return null;
            }

        }

        private void SetDataSource(List<LinqToDB.SchemaProvider.TableSchema> source)
        {
            chklstbx_Tables.DataSource = source;
            chklstbx_Tables.DisplayMember = "TableName";
            chklstbx_Tables.ValueMember = "ID";

        }

        private void ToolStripMenuItem_execute_Click(object sender, EventArgs e)
        {

             

        }
    }
}
