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
using CH.Common.Utility;
using RazorEngine.Templating;
using RazorEngine.Configuration;
namespace CH.CodeGenerator
{
    public partial class frmMain : Form
    {

        IniFile iniFile = new IniFile(Constant.iniFileName);

        SerializerXML<ConnectionStrs> ser = new SerializerXML<ConnectionStrs>(Constant.xmlFileName);
        private List<TableSchema> ts = null;
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




        private TextEditorControl AddNewTextEditor(string title,string path)
        {

          var  exitsTabs= fileTabs.TabPages.OfType<TabPage>().Where(m => m.Tag.ToString() == path).FirstOrDefault();

            if(exitsTabs!=null)
            {
                fileTabs.TabPages.Remove(exitsTabs);
            }

            var tab = new TabPage(title);
            tab.Tag = path;
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

            chklstbx_Tables.Items.Clear();
            ///加载数据
            ///
            txtFilter.TextChanged += TxtFilter_TextChanged;


        }

        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
           
            if(ts!=null)
            { 
                var source = ts.Where(m => m.TableName.Contains(txtFilter.Text.Trim())).ToList(); 
                SetDataSource(source);
            }

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            //string path = iniFile.GetString("Template", "file", "");

            //if(System.IO.File.Exists(path))
            //{
            //    var editor = AddNewTextEditor(path);

            //    editor.LoadFile(path);
            //}

           
        } 
       

        private void ToolStripMenuItem_open_Click(object sender, EventArgs e)
        {


            using (var openFile = new OpenFileDialog())
            {
                openFile.Filter = "C#文件|*.cs|所有文件|*.*";
                if (openFile.ShowDialog() == DialogResult.OK)
                {

                    string path = openFile.FileName;

                    string file= path.Split(new string[] { "\\"},StringSplitOptions.None).ToList().Last();

                    var editor = AddNewTextEditor(file,path);

                    editor.LoadFile(openFile.FileName);
                }
            }


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
         
     
        /// <summary>
        /// 设置连接字符串
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_settings_Click(object sender, EventArgs e)
        {
            using (var frm = new frmTemplate())
            {

                frm.ShowDialog();
            }
        }

        private void loadDataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

      

        private void LoadDataBaseTable(ConnectionStr con)
        { 
            if (con == null) return;
            IDataProvider provider = con.Provider.GetDataProvider();

            try
            {
                using (var db = new DataConnection(provider, con.Value))
                {

                    var sp = db.DataProvider.GetSchemaProvider();
                   
                    var schema = sp.GetSchema(db);


                    using (BackgroundWorker bk = new BackgroundWorker())
                    {

                        bk.DoWork += (a, b) =>
                        {

                            ts= schema.Tables;
                            b.Result = ts;


                        };
                        bk.RunWorkerCompleted += (c, d) =>
                        {

                            if (d.Result != null)
                            { 
                                SetDataSource(d.Result);
                            }
                        };
                        bk.RunWorkerAsync();
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ts = null;
            }

            

        }

      

        private void SetDataSource(object source)
        {
            chklstbx_Tables.DataSource = source;
            chklstbx_Tables.DisplayMember = "TableName";
            chklstbx_Tables.ValueMember = "ID";

        }

        private void ToolStripMenuItem_execute_Click(object sender, EventArgs e)
        {


            try
            {
                string path = iniFile.GetString(Constant.ini_Section_name, Constant.ini_Section_templateFile, "");

                string outDir = iniFile.GetString(Constant.ini_Section_name, Constant.ini_Section_outDirectory, "");

                string spaceName= iniFile.GetString(Constant.ini_Section_name, Constant.ini_Section_spaceName, "");

                if (string.IsNullOrEmpty(spaceName))
                {
                    MessageBox.Show("实体命名空间不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!File.Exists(path))
                {
                    MessageBox.Show("模板文件不存在!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(outDir))
                {
                    outDir = string.Format(@"{0}\{1}", Application.StartupPath, "GeneratorCode");/*Path.Combine(Application.StartupPath,"/GeneratorCode");*/

                    if (!Directory.Exists(outDir))
                    {
                        Directory.CreateDirectory(outDir);
                    }
                }
                //获取选中的表

                var tables = chklstbx_Tables.CheckedItems.OfType<TableSchema>().ToList();


                if (tables.Count == 0) return;

                GeneraterCodeAuto(spaceName, outDir, path, tables, m => {


                    //string path = openFile.FileName;

                    //string file = path.Split(new string[] { "\\" }, StringSplitOptions.None).ToList().Last();
                    var editor = AddNewTextEditor(m.Split(new string[] { "\\" }, StringSplitOptions.None).ToList().Last(), m);

                    editor.LoadFile(m);
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="outDir">输出目录</param>
        /// <param name="fileName">模板名称</param>
        /// <param name="tables"></param>
        /// <param name="generatorComplete">生成完成后</param>
        private void GeneraterCodeAuto(string spaceName, string outDir,string fileName,List<TableSchema> tables,Action<string> generatorComplete)
        {
            string index = System.IO.File.ReadAllText(fileName, System.Text.Encoding.UTF8);
            var config = new TemplateServiceConfiguration();
            config.BaseTemplateType = typeof(CustomTemplateBase<>);
            //config.Debug = true;
            using (var service = RazorEngineService.Create(config))
            {

                foreach(var table in tables)
                {
                    string result = service.RunCompile(index, string.Empty, null, new { Table = table, SpaceName=spaceName });

                    string rsFile = string.Format("{0}.cs",Path.Combine(outDir,string.Format("{0}.generated",table.TableName.ToPascal().ToLower())));
                    WriteFile(rsFile, result);
                    generatorComplete(rsFile);
                } 

            }
        }

        private void WriteFile(string fileName,string result)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(result);
                }

            }
        }

        private void ToolStripMenuItem_connectionStr_Click(object sender, EventArgs e)
        {
            using (var frm = new frmSetting((m) =>
            {
                //LoadDataBaseTable(m);

            }))
            {
                frm.ShowDialog();
            }
        }

        private void ToolStripMenuItem_loadTables_Click(object sender, EventArgs e)
        {
            var cons = ser.GetObj();

            if (cons != null)
            {
                var database = cons.ConnectionStrList.Where(m => m.Checked).FirstOrDefault();
                
                if(database!=null)
                {
                    LoadDataBaseTable(database);
                }
                else {

                    MessageBox.Show("请选择一个默认的数据库连接", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
              
            }
            //var cons= ser.GetObj();

            //if(cons!=null)
            //{
            //    var cons_lst = cons.ConnectionStrList;

            //    if(cons_lst!=null)
            //    {
            //        var con = cons_lst.Where(m => m.Checked).FirstOrDefault();

            //        if(con!=null)
            //        {
            //            LoadDataBaseTable(con);
            //        }
            //    } 

            //}


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if(chklstbx_Tables.Items.Count>0)
            {
                 
               for(int i=0;i<chklstbx_Tables.Items.Count;i++)
                {
                    chklstbx_Tables.SetItemChecked(i, false);
                }

            }
        }
    }
}
