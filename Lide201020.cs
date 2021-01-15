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
    public partial class Lide201020 : Form
    {
        string[] strS_PN;
        public string OldActPrn;
        LabelManager2.ApplicationClass labApp = null;
        LabelManager2.Document doc = null;
        public Lide201020()
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


        void tb_QTY_GotFocus(object sender, EventArgs e) { tb_QTY.Select(0, tb_QTY.Value.ToString().Length + 3); }


        void inival()
        {

            string str1 = Process.GetCurrentProcess().MainModule.FileName;//可获得当前执行的exe的文件名。


            Console.WriteLine(str1);

            cb_cusPN.Items.Clear();
            tb_ep.Items.Clear();

            if (File.Exists(str1 + ".config"))
            {
               string str_supplier20201020 = ConfigurationManager.AppSettings["supplier20201020"];
                tb_supName.Text = str_supplier20201020;
                string[] strCusPN = ConfigurationManager.AppSettings["part_no"].Split(';');
                string[] strVer = ConfigurationManager.AppSettings["ep2"].Split(';');

                foreach (var item in strCusPN)
                {
                    if (!cb_cusPN.Items.Contains(item)) cb_cusPN.Items.Add(item);
                    cb_cusPN.SelectedIndex = 0;
                }
                foreach (var item in strVer)
                {
                    if (!tb_ep.Items.Contains(item)) tb_ep.Items.Add(item);
                    tb_ep.SelectedIndex = 0;
                }

            }
            else { MessageBox.Show(str1 + ".config，配置文件不存在", "提示！"); };

            cb_cusPN.SelectedIndex = -1;
            
            tb_ep.SelectedIndex = -1;           
            
            tb_Lide_Rev.Text = "";
            tb_LOT_NO.Text = "";
            tb_remark.Text = "";

            tb_QTY.Value = 0;
            tb_printNum.Value = 1;
            

            cb_cusPN.Focus();
        }

        private void cb_S_PN_SelectedIndexChanged(object sender, EventArgs e)
        {

            //string strS = item.Substring(0, item.IndexOf(","));
            //if (cb_S_PN.Text == strS)
            //{
            //    tb_C_PN.Text=item.Substring(item.IndexOf(",")+1);
            //}
            

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmbPrinterList.Text == "") { { MessageBox.Show("未選擇打印機！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); cmbPrinterList.Focus(); return; } }
            if (cb_cusPN.Text.Trim() == "") { MessageBox.Show("廠商簡稱未選擇", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); cb_cusPN.Focus(); return; }
            if (tb_spec.Text.Trim() == "") { MessageBox.Show("spec不能爲空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_spec.Focus(); return; }

            if (tb_supName.Text.Trim() == "") { MessageBox.Show("立德料號未選擇", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_supName.Focus(); return; }
            if (tb_ep.Text.Trim() == "") { MessageBox.Show("環保特性未選擇", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_ep.Focus(); return; }
           
            if (tb_Lide_Rev.Text.Trim() == "") { MessageBox.Show("立德版本版本不能爲空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_Lide_Rev.Focus(); return; }
            if (tb_LOT_NO.Text.Trim() == "") { MessageBox.Show("LOT_NO不能爲空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_LOT_NO.Focus(); return; }
           
            
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
                    labApp.Documents.Open(startupPath + @"\lide201020.Lab", false);// 调用设计好的label文件。
                    doc = labApp.ActiveDocument;
                    doc.Printer.SwitchTo(OldActPrn);

                    if (tb_ep.Text.Trim() == "HF")
                    {

                        doc.Variables.FormVariables.Item("HF").Value = tb_ep.Text.Trim();
                        doc.Variables.FormVariables.Item("ROHS").Value = "";
                    }
                    else
                    {

                        doc.Variables.FormVariables.Item("ROHS").Value = tb_ep.Text.Trim();
                        doc.Variables.FormVariables.Item("HF").Value = "";
                    }
                    doc.Variables.FormVariables.Item("S_N").Value = tb_supName.Text.Trim(); //给参数传值 

                    doc.Variables.FormVariables.Item("C_PN").Value = cb_cusPN.Text.Trim();
                    doc.Variables.FormVariables.Item("SPEC").Value = tb_spec.Text.Trim();

                    doc.Variables.FormVariables.Item("R_LIDE").Value = tb_Lide_Rev.Text.Trim();
                    doc.Variables.FormVariables.Item("L_N").Value = tb_LOT_NO.Text.Trim();
                    //doc.Variables.FormVariables.Item("DT").Value = dateTimePicker_del.Value.ToString("yy'/'MM'/'dd");
                    doc.Variables.FormVariables.Item("DT").Value = datePickFrom.Value.ToString("yyMMdd");
                    doc.Variables.FormVariables.Item("DT2").Value = dateTimePicker_del.Value.ToString("yyMMdd");

                    doc.Variables.FormVariables.Item("QTY").Value = tb_QTY.Text.Trim();
                    doc.Variables.FormVariables.Item("QTY2").Value = Convert.ToInt32(tb_QTY.Text.Trim()).ToString("0000000");
                    doc.Variables.FormVariables.Item("UNIT").Value = tb_unit.Text.Trim();
                    doc.Variables.FormVariables.Item("REMARK").Value = tb_remark.Text.Trim();
                    doc.Variables.FormVariables.Item("S_ID").Value = ConfigurationManager.AppSettings[this.tb_supName.Text]; //二维码上的供應商a
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

        private void Lide201020_Load(object sender, EventArgs e)
        {
            this.Owner.Hide();
        }

        private void Lide201020_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void cb_cusPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_spec = ConfigurationManager.AppSettings[cb_cusPN.Text];
            tb_spec.Text = str_spec;
        }
    }
}
