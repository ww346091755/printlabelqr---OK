using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace printlabelqr
{
    public partial class LideSPA : Form
    {
        string[] strS_PN;
        public string OldActPrn;
        LabelManager2.ApplicationClass labApp = null;
        LabelManager2.Document doc = null;
        public LideSPA()
        {
            InitializeComponent();

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

            tb_NW.GotFocus += new EventHandler(tb_NW_GotFocus);
            tb_GW.GotFocus += new EventHandler(tb_GW_GotFocus);
            tb_QTY.GotFocus += new EventHandler(tb_QTY_GotFocus);
            try
            {
                inival();
            }
            catch (Exception ex)
            {
                MessageBox.Show("出錯啦，原因如下：\n\r" + ex.Message, "出錯啦!");
            }
            Console.WriteLine(dateTimePicker_del.Value.ToString("yy-MM-dd"));
        }

        void tb_NW_GotFocus(object sender, EventArgs e) { tb_NW.Select(0, tb_NW.Value.ToString().Length + 3); }
        void tb_GW_GotFocus(object sender, EventArgs e) { tb_GW.Select(0, tb_GW.Value.ToString().Length + 3); }
        void tb_QTY_GotFocus(object sender, EventArgs e) { tb_QTY.Select(0, tb_QTY.Value.ToString().Length+3); }


        void inival()
        {

            string str1 = Process.GetCurrentProcess().MainModule.FileName;//可获得当前执行的exe的文件名。

            
            Console.WriteLine(str1);
            cb_S_PN.Items.Clear();
            cb_SN.Items.Clear();
            tb_ep.Items.Clear();

            if (File.Exists(str1 + ".config"))
            {
                strS_PN = ConfigurationManager.AppSettings["supplier_pn"].Split(';');
                string[] strSup = ConfigurationManager.AppSettings["supplier"].Split(';');
                string[] strVer = ConfigurationManager.AppSettings["ep2"].Split(';');
                foreach (var item in strS_PN)
                {
                    if (!cb_S_PN.Items.Contains(item)) cb_S_PN.Items.Add(item);
                    cb_S_PN.SelectedIndex = 0;
                }
                foreach (var item in strSup)
                {
                    if (!cb_SN.Items.Contains(item)) cb_SN.Items.Add(item);
                    cb_SN.SelectedIndex = 0;
                }
                foreach (var item in strVer)
                {
                    if (!tb_ep.Items.Contains(item)) tb_ep.Items.Add(item);
                    tb_ep.SelectedIndex = 0;
                }

            }
            else { MessageBox.Show(str1 + ".config，配置文件不存在", "提示！"); };

            cb_SN.SelectedIndex = -1;
            cb_S_PN.SelectedIndex = -1;
            tb_ep.SelectedIndex = -1;
            tb_C_PN.Text = "";
            tb_cs_Rev.Text = "";
            tb_Lide_Rev.Text = "";
            tb_LOT_NO.Text = "";
            tb_NW.Value = 0;
            tb_GW.Value = 0;
            tb_QTY.Value = 0;
            tb_printNum.Value = 1;

            cb_SN.Focus();
        }

        private void cb_S_PN_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                //string strS = item.Substring(0, item.IndexOf(","));
                //if (cb_S_PN.Text == strS)
                //{
                //    tb_C_PN.Text=item.Substring(item.IndexOf(",")+1);
                //}
                tb_C_PN.Text = ConfigurationManager.AppSettings[cb_S_PN.Text];
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmbPrinterList.Text == "") { { MessageBox.Show("未選擇打印機！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); cmbPrinterList.Focus(); return; } }
            if (cb_SN.Text.Trim() == "") { MessageBox.Show("廠商簡稱未選擇", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); cb_SN.Focus(); return; }

            if (cb_S_PN.Text.Trim() == "") { MessageBox.Show("廠商料號未選擇", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); cb_S_PN.Focus(); return; }
            if (tb_C_PN.Text.Trim() == "") { MessageBox.Show("立德料號未選擇", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_C_PN.Focus(); return; }
            if (tb_ep.Text.Trim() == "") { MessageBox.Show("環保特性未選擇", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_ep.Focus(); return; }
            if (tb_cs_Rev.Text.Trim() == "") { MessageBox.Show("廠商版本版本不能爲空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_cs_Rev.Focus(); return; }
            if (tb_Lide_Rev.Text.Trim() == "") { MessageBox.Show("立德版本版本不能爲空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_Lide_Rev.Focus(); return; }
            if (tb_LOT_NO.Text.Trim() == "") { MessageBox.Show("LOT_NO不能爲空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_LOT_NO.Focus(); return; }
            if (tb_NW.Text.Trim() == "" || tb_NW.Value == 0) { MessageBox.Show("净重不能爲0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_NW.Focus(); return; }
            if (tb_GW.Text.Trim() == "" || tb_GW.Value == 0) { MessageBox.Show("毛重不能爲0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_GW.Focus(); return; }
            if (tb_QTY.Text.Trim() == "" || tb_QTY.Value == 0) { MessageBox.Show("數量不能爲0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_QTY.Focus(); return; }


            string startupPath = System.Windows.Forms.Application.StartupPath;
            string labFileName = startupPath + "\\lideSPA.Lab";
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
                    MessageBox.Show("沒有找到標簽模板文件：" + startupPath + "\\lideSPA.Lab,請聯系系統管理員", "溫馨提示");
                    return;
                }
                btnOK.Enabled = false;             

                for (int i = 0; i < Convert.ToInt32(tb_printNum.Value); i++)
                {
                    labApp = new LabelManager2.ApplicationClass();
                    labApp.Documents.Open(startupPath + @"\lideSPA.Lab", false);// 调用设计好的label文件
                    doc = labApp.ActiveDocument;
                    doc.Printer.SwitchTo(OldActPrn);

                    if (tb_ep.Text.Trim()=="HF")
                    {
                        
                        doc.Variables.FormVariables.Item("HF").Value = tb_ep.Text.Trim();
                        doc.Variables.FormVariables.Item("ROHS").Value = "";
                    }
                    else
                    {
                      
                        doc.Variables.FormVariables.Item("ROHS").Value = tb_ep.Text.Trim();
                        doc.Variables.FormVariables.Item("HF").Value = "";
                    }
                    doc.Variables.FormVariables.Item("S_N").Value = cb_SN.Text.Trim(); //给参数传值
                    doc.Variables.FormVariables.Item("S_PN").Value = cb_S_PN.Text.Trim();
                    doc.Variables.FormVariables.Item("C_PN").Value = tb_C_PN.Text.Trim();
                    doc.Variables.FormVariables.Item("R_FK").Value = tb_cs_Rev.Text.Trim();
                    doc.Variables.FormVariables.Item("R_LIDE").Value = tb_Lide_Rev.Text.Trim();
                    doc.Variables.FormVariables.Item("L_N").Value = tb_LOT_NO.Text.Trim();
                    doc.Variables.FormVariables.Item("DT").Value = dateTimePicker_del.Value.ToString("yy'/'MM'/'dd");            
                    doc.Variables.FormVariables.Item("DT2").Value = dateTimePicker_del.Value.ToString("yyMMdd");
                    doc.Variables.FormVariables.Item("NW").Value = tb_NW.Text.Trim();
                    doc.Variables.FormVariables.Item("GW").Value = tb_GW.Text.Trim();
                    doc.Variables.FormVariables.Item("QTY").Value = tb_QTY.Text.Trim();
                    doc.Variables.FormVariables.Item("QTY2").Value = Convert.ToInt32(tb_QTY.Text.Trim()).ToString("0000000");
                    doc.Variables.FormVariables.Item("UNIT").Value = tb_unit.Text.Trim();                    
                    doc.Variables.FormVariables.Item("S_ID").Value = ConfigurationManager.AppSettings[this.cb_SN.Text]; //二维码上的供應商a
                    //int strWidth = doc.DocObjects.Barcodes.Item("Barcode1(2)").
                    //Console.WriteLine(strWidth);
                    
                     // doc.Variables.
                     // doc.Variables.FreeVariables.Item("Text25").Value = "1";


                     doc.PrintDocument(1);                             //打印
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

        private void cmbPrinterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            OldActPrn = cmbPrinterList.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            inival();
        }

        private void LideSPA_Load(object sender, EventArgs e)
        {
            this.Owner.Hide();
        }

        private void LideSPA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

    }
}
