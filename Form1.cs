using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace printlabelqr
{
    public partial class Form1 : Form
    {
        public int ilableLx;//打印模板类型，目前这里仅一个模板
        public string OldActPrn;
        // static BarTender.Application btApp = null;
        LabelManager2.ApplicationClass labApp = null;
        LabelManager2.Document doc = null;
        public Form1()
        {
            InitializeComponent();

            
            dateTimePicker_del.MinDate = DateTime.Now.AddDays(1);
            tb_ver.GotFocus += new EventHandler(tb_ver_GotFocus);
            tb_wo.GotFocus += new EventHandler(tb_wo_GotFocus);
            tb_item.GotFocus += new EventHandler(tb_item_GotFocus);
            tb_no.GotFocus += new EventHandler(tb_no_GotFocus);
            tb_weight.GotFocus += new EventHandler(tb_weight_GotFocus);
            tb_mon.GotFocus += new EventHandler(tb_mon_GotFocus);
            tb_bak.GotFocus += new EventHandler(tb_bak_GotFocus);

            int i;
            string pkInstalledPrinters;
            using (PrintDocument pd = new PrintDocument())
            {
                for (i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)  //开始遍历
                {
                    pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];  //取得名称
                    cmbPrinterList.Items.Add(pkInstalledPrinters);               //加入ComboBox
                    if (pd.PrinterSettings.IsDefaultPrinter)                     //判断是否为默认打印机
                    {
                        OldActPrn = pd.PrinterSettings.PrinterName;              //保存名称，后面要用
                        cmbPrinterList.Text = pd.PrinterSettings.PrinterName;    //显示默认打印机名称
                    }
                }
            }

                inival();
        }

        void inival()
        {
            string str1 = Process.GetCurrentProcess().MainModule.FileName;//可获得当前执行的exe的文件名。
            Console.WriteLine(str1);
            if (File.Exists(str1 + ".config"))
            {
                string[] strPart_no = ConfigurationManager.AppSettings["part_no"].Split(';');
                string[] strVer = ConfigurationManager.AppSettings["ep"].Split(';');
                string[] strSup = ConfigurationManager.AppSettings["supplier"].Split(';');
                foreach (var item in strPart_no)
                {
                    if (!tb_PartNO.Items.Contains(item)) tb_PartNO.Items.Add(item);
                    tb_PartNO.SelectedIndex = 0;
                }
                foreach (var item in strVer)
                {
                    if (!tb_ep.Items.Contains(item)) tb_ep.Items.Add(item);
                    tb_ep.SelectedIndex = 0;
                }
                foreach (var item in strSup)
                {
                    if (!tb_ven.Items.Contains(item)) tb_ven.Items.Add(item);
                    tb_ven.SelectedIndex = 0;
                }
            }
            else { MessageBox.Show(str1 + ".config，配置文件不存在", "提示！"); };
            tb_PartNO.SelectedIndex = -1;
            tb_spec.Text = "";
            tb_ver.Text = "";
            tb_wo.Text = "";
            tb_item.Text = "";
            tb_no.Value = 0;
            tb_weight.Value = 0;
            tb_mon.Value = dateTimePicker_del.Value.Month;
            tb_bak.Text = "";
            btnOK.Enabled = true;
            tb_printNum.Value = 1;
            tb_PartNO.Focus();
        }

        //BarTender.Application btApp;
       // BarTender.Format btFormat;
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmbPrinterList.Text == "") { { MessageBox.Show("未選擇打印機！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); cmbPrinterList.Focus(); return; } }
            if (tb_PartNO.Text.Trim() == "") { MessageBox.Show("料件編號未選擇", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_PartNO.Focus(); return; }
            if (tb_ver.Text.Trim() == "") { MessageBox.Show("版本不能爲空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_ver.Focus(); return; }
            if (tb_wo.Text.Trim() == "") { MessageBox.Show("訂單號不能爲空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_wo.Focus(); return; }
            if (datePickFrom.Text.Trim() == "") { MessageBox.Show("生產時間不能爲空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); datePickFrom.Focus(); return; }
            if (tb_item.Text.Trim() == "") { MessageBox.Show("項次不能爲空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_item.Focus(); return; }
            if (tb_no.Text.Trim() == ""|| tb_no.Value==0) { MessageBox.Show("數量不能為0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_no.Focus(); return; }
            if (tb_weight.Text.Trim() == ""||tb_weight.Value==0) { MessageBox.Show("重量不能爲0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_weight.Focus(); return; }
            if (dateTimePicker_del.Text.Trim() == "") { MessageBox.Show("交貨日期不能爲空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); dateTimePicker_del.Focus(); return; }


            //btApp = getBarTender();
            ////檢查是否有安裝BarTend
            //if (btApp == null)
            //{
            //    MessageBox.Show("列印前請先安裝BarTender!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //列印前請先安裝BarTender!
            //    return;
            //}
            //檢查bartender是否與LincenseServer連線
            //else if (!btApp.LicenseServer.IsConnected)
            //{
            //    MessageBox.Show("請確認Bartender版本與License Server是否連線!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //請確認Bartender版本與License Server是否連線!
            //    return;
            //}




            string startupPath = System.Windows.Forms.Application.StartupPath;
            string labFileName = startupPath+ "\\lide.Lab";
            string CodeSoftName = startupPath + "\\Interop.LabelManager2.dll";

            try
            {
                if (!File.Exists(CodeSoftName))
                {
                    MessageBox.Show("沒有找到dll：" + startupPath + "\\Interop.LabelManager2.dll,請聯系系統管理員", "溫馨提示");
                    return;
                }
                if (!File.Exists(labFileName))
                {
                    MessageBox.Show("沒有找到標簽模板文件："+ startupPath+"\\lide.Lab,請聯系系統管理員", "溫馨提示");
                    return;
                }
                btnOK.Enabled = false;
                //btFormat = btApp.Formats.Open(startupPath + @"\lide", false, OldActPrn);
                //btFormat.PrintSetup.IdenticalCopiesOfLabel = Convert.ToInt32(tb_printNum.Value);  //设置同序列打印的份数
                //btFormat.PrintSetup.NumberSerializedLabels =1 ;  //设置需要打印的序列数
                //btFormat.SetNamedSubStringValue("tb_PartNO", this.tb_PartNO.Text); //向bartender模板传递变量
                //btFormat.SetNamedSubStringValue("tb_ver", this.tb_ver.Text);//版本
                //btFormat.SetNamedSubStringValue("tb_env", this.tb_ep.Text);//環保
                //btFormat.SetNamedSubStringValue("tb_spec", this.tb_spec.Text);//規格
                //btFormat.SetNamedSubStringValue("tb_wo", this.tb_wo.Text);//工單
                //btFormat.SetNamedSubStringValue("tb_dev", this.tb_dev.Text);//幾臺
                //btFormat.SetNamedSubStringValue("tb_data", this.datePickFrom.Value.ToString("yyyy/MM/dd"));//生產日期
                //btFormat.SetNamedSubStringValue("tb_item", this.tb_item.Text);//項次
                //btFormat.SetNamedSubStringValue("tb_no", this.tb_no.Text);//數量
                //btFormat.SetNamedSubStringValue("tb_unit", this.tb_unit.Text);//單位
                //btFormat.SetNamedSubStringValue("tb_ven", this.tb_ven.Text);//供应商
                //btFormat.SetNamedSubStringValue("tb_ven2", ConfigurationManager.AppSettings[this.tb_ven.Text]);//二维码上的供應商
                //btFormat.SetNamedSubStringValue("tb_weight", this.tb_weight.Text);//毛重
                //btFormat.SetNamedSubStringValue("tb_del_data", this.dateTimePicker_del.Value.ToString("yyyy/MM/dd"));//交貨日期
                //btFormat.SetNamedSubStringValue("tb_org", this.tb_org.Text);//生產地方
                //btFormat.SetNamedSubStringValue("tb_bak", this.tb_bak.Text);//備注
                //btFormat.SetNamedSubStringValue("tb_mon", this.tb_mon.Text);//月份

                //btFormat.PrintOut(false, false); //第二个false设置打印时是否跳出打印属性
                //btFormat.Close(BarTender.BtSaveOptions.btSaveChanges); //退出时是否保存标签

                for (int i = 0; i < Convert.ToInt32(tb_printNum.Value); i++)
                {
                    labApp = new LabelManager2.ApplicationClass();
                    labApp.Documents.Open(startupPath + @"\lide.Lab", false);// 调用设计好的label文件
                    doc = labApp.ActiveDocument;
                    doc.Printer.SwitchTo(OldActPrn);

                    string strMon = "";
                    if (int.Parse(tb_mon.Value.ToString()) < 10)
                    {
                        strMon = "0" + int.Parse(tb_mon.Value.ToString());
                    }
                    else
                    {
                        strMon = tb_mon.Value.ToString();
                    }


                    doc.Variables.FormVariables.Item("tb_PartNO").Value = tb_PartNO.Text.Trim(); //给参数传值
                    doc.Variables.FormVariables.Item("tb_ver").Value = tb_ver.Text.Trim();
                    doc.Variables.FormVariables.Item("tb_env").Value = tb_ep.Text.Trim();
                    doc.Variables.FormVariables.Item("tb_spec").Value = tb_spec.Text.Trim();
                    doc.Variables.FormVariables.Item("tb_wo").Value = tb_wo.Text.Trim();
                    doc.Variables.FormVariables.Item("tb_dev").Value = tb_dev.Text.Trim();
                    doc.Variables.FormVariables.Item("tb_data").Value = datePickFrom.Value.ToString("yyyy'/'MM'/'dd");
                    doc.Variables.FormVariables.Item("tb_item").Value = tb_item.Text.Trim();
                    doc.Variables.FormVariables.Item("tb_no").Value = tb_no.Text.Trim();
                    doc.Variables.FormVariables.Item("tb_unit").Value = tb_unit.Text.Trim();
                    doc.Variables.FormVariables.Item("tb_ven").Value = tb_ven.Text.Trim();
                    doc.Variables.FormVariables.Item("tb_ven2").Value = ConfigurationManager.AppSettings[this.tb_ven.Text]; //二维码上的供應商A
                    doc.Variables.FormVariables.Item("tb_weight").Value = tb_weight.Text.Trim();
                    doc.Variables.FormVariables.Item("tb_del_data").Value = dateTimePicker_del.Value.ToString("yyyy'/'MM'/'dd");
                    doc.Variables.FormVariables.Item("tb_org").Value = tb_org.Text.Trim();
                    doc.Variables.FormVariables.Item("tb_bak").Value = tb_bak.Text.Trim();
                    doc.Variables.FormVariables.Item("tb_mon").Value = strMon;

                    doc.PrintDocument(1);                             //打印a
                    if (labApp != null)
                    {
                        labApp.Documents.CloseAll(true);
                        labApp.Quit();//退出
                        labApp = null;
                        doc = null;
                    }
                }
                btnOK.Enabled = true;
                //inival();
            }
            catch (Exception ex)
            {
                MessageBox.Show("出錯啦，原因如下：\n\r" + ex.Message, "出錯啦");
                btnOK.Enabled = true;
            }
            finally
            {
                if (labApp != null)
                {
                    labApp.Documents.CloseAll(true);
                    labApp.Quit();//退出
                    labApp = null;
                    doc = null;
                }
                btnOK.Enabled = true;
                GC.Collect(0);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
           // if(btApp != null) btApp.Quit(BarTender.BtSaveOptions.btSaveChanges);//界面退出时同步退出bartender进程
            this.Owner.Show();
        }

        private void tb_PartNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tb_PartNO.Text.Trim().Equals("0055-UCB4-100R"))
            //{
            //    tb_spec.Text = "Type C 3.1 Female H=0.1(蛟龍5號）-TOP Contact";
            //}
            //else if(tb_PartNO.Text.Trim().Equals("0055-UCB4-200R")) 
            //{
            //    tb_spec.Text = "Type C 3.1 Female H=0.1(蛟龍5號）-BTM Contact";
            //}
            tb_spec.Text = ConfigurationManager.AppSettings[tb_PartNO.Text];
            tb_ver.Focus();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)  // 按下的是回车键
            {
                foreach (Control c in this.Controls)
                {               
                    if (c is System.Windows.Forms.TextBox)  // 当前控件是文权本框控件
                    {                      
                        keyData = Keys.Tab;
                    }
                }
                keyData = Keys.Tab;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void tb_ver_Click(object sender, EventArgs e)   { tb_ver.SelectAll(); }


        void tb_ver_GotFocus(object sender, EventArgs e)   {   //tb_ver.SelectAll(); 
        }
        void tb_wo_GotFocus(object sender, EventArgs e) { //tb_wo.SelectAll(); 
        }
        void tb_item_GotFocus(object sender, EventArgs e) {// tb_item.SelectAll(); 
        }
        void tb_no_GotFocus(object sender, EventArgs e) { tb_no.Select(0, tb_no.Value.ToString().Length); }
        void tb_weight_GotFocus(object sender, EventArgs e) { tb_weight.Select(0, tb_weight.Value.ToString().Length+3); }
        void tb_mon_GotFocus(object sender, EventArgs e) { tb_mon.Select(0, tb_mon.Value.ToString().Length); }
        void tb_bak_GotFocus(object sender, EventArgs e) {// tb_bak.SelectAll(); 
        }

        private void tb_wo_Click(object sender, EventArgs e)
        {
            //tb_wo.SelectAll();
        }

        private void tb_item_Click(object sender, EventArgs e)
        {
           // tb_item.SelectAll();
        }

        private void tb_no_Click(object sender, EventArgs e)
        {
            tb_no.Select(0, tb_no.Value.ToString().Length);
        }

        private void tb_weight_Click(object sender, EventArgs e)
        {
            tb_weight.Select(0, tb_weight.Value.ToString().Length + 3);
        }

        private void tb_mon_Click(object sender, EventArgs e)
        {
            tb_mon.Select(0, tb_mon.Value.ToString().Length);
        }

        private void tb_bak_Click(object sender, EventArgs e)
        {
            //tb_bak.SelectAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            inival();
        }

        private void dateTimePicker_del_ValueChanged(object sender, EventArgs e)
        {
            tb_mon.Value = dateTimePicker_del.Value.Month;           
        }

        private void cmbPrinterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            OldActPrn = cmbPrinterList.Text;
        }
        //public static BarTender.Application getBarTender()
        //{
        //    if (btApp == null)
        //    {
        //        try
        //        {
        //            btApp = new BarTender.Application();
        //        }
        //        catch
        //        {
        //            if (btApp != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp);
        //        }
        //    }
        //    else
        //    {
        //        Process[] processes = Process.GetProcessesByName("bartend");
        //        if (processes.Count() > 0)
        //        {
        //            object obj = Marshal.GetActiveObject("BarTender.Application");
        //            btApp = obj as BarTender.Application;
        //        }
        //        else
        //        {
        //            //如果bartend意外的被關閉 偵測不到 則重新new一個起來
        //            //不然會出現ex 印表機伺服器偵測錯誤訊息
        //            try
        //            {
        //                btApp = new BarTender.Application();
        //            }
        //            catch
        //            {
        //                if (btApp != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp);
        //            }
        //        }
        //    }
        //    return btApp;
        //}

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Owner.Hide();
        }
    }
}
