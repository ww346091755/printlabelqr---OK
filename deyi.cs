using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace printlabelqr
{
    public partial class deyi : Form
    {
        private DAO dao = new DAO();
        DataTable dt = new DataTable();
       // static BarTender.Application btApp = null;
       // BarTender.Format btFormat;
        public string OldActPrn;
        public string strSUPPLIES_ID;
        string strRegex = "[a-zA-Z]((([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3})-(((0[13578]|1[02])-(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)-(0[1-9]|[12][0-9]|30))|(02-(0[1-9]|[1][0-9]|2[0-8]))))|((([0-9]{2})(0[48]|[2468][048]|[13579][26])|((0[48]|[2468][048]|[3579][26])00))-02-29))[0-9][0-9][0-9]$";
        LabelManager2.ApplicationClass labApp = null;
        LabelManager2.Document doc = null;

        public deyi()
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
           
        }

        public void inival()
        {
            init_basic_data();
            cb_PartNO.Items.Clear();
             tb_Part_Name.Text = "";
            tb_supperID.Text = "";
             tb_Spec.Text = "";
             tb_Band.Text = "";
             tb_Material.Text = "";
             tb_buy_no.Text = "";
             tb_buy_item.Text = "";
             tb_lot_no.Text = "";
             tb_ep_no.Text = "";
             tb_Verifier.Text = "";
             tb_wo.Text = "";
            tb_sum.Value =0 ;
            tb_bak.Text = "";
             tb_Unit.Text = "";
            tb_printNum.Value = 1;
            datePickFrom.Value = DateTime.Today;
            getLastEPNO();
            cb_Supplier.Focus();

        }
        public void init_basic_data()
        {
            if(dt!=null&&dt.Rows.Count!=0) dt.Clear();
            cb_Supplier.Items.Clear();
           string strMessage= dao.get_data(ref dt);
            if (strMessage != "") { MessageBox.Show(strMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            DataView dv = dt.DefaultView;
            DataTable DistTable = dv.ToTable(true, "SUPPLIES_ID","SUPPLIES_NAME");//去除重复。
            for (int i = 0; i < DistTable.Rows.Count; i++)
            {
                cb_Supplier.Items.Add(DistTable.Rows[i]["SUPPLIES_NAME"].ToString());
            }
            cb_Supplier.SelectedIndex = -1;
        }

        private void cb_Supplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Supplier.Text == "") return;
            tb_Part_Name.Text = "";
            tb_Spec.Text = "";
            tb_Band.Text = "";
            tb_Material.Text = "";
            tb_Unit.Text = "";
            cb_PartNO.Items.Clear();
           DataRow[] drList= dt.Select("SUPPLIES_NAME='" + cb_Supplier.Text+"'");
            foreach (DataRow dr in drList)
            {
                strSUPPLIES_ID = dr["SUPPLIES_ID"].ToString();
                tb_supperID.Text = strSUPPLIES_ID;
                cb_PartNO.Items.Add(dr["PART_NO"]);
            }
        }

        private void cb_PartNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_PartNO.Text == "") return;
            DataRow[] drList = dt.Select("PART_NO='" + cb_PartNO.Text + "'");
            foreach (DataRow dr in drList)
            {
                tb_Part_Name.Text=dr["PART_NAME"].ToString();
                tb_Spec.Text = dr["SPEC"].ToString();
                tb_Band.Text = dr["BAND"].ToString();
                tb_Material.Text = dr["MATERIAL"].ToString();
                tb_Unit.Text = dr["UNIT"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string StrSupplier = cb_Supplier.Text;
            string StrPart_NO = cb_PartNO.Text;
            string StrPart_Name = tb_Part_Name.Text;
            string StrSpec = tb_Spec.Text;
            string strBand = tb_Band.Text;
            string StrMaterial = tb_Material.Text;
            string StrProd_Data = datePickFrom.Value.ToString("yyyy'-'MM'-'dd");
            Console.WriteLine(StrProd_Data);
            string StrBuy_NO = tb_buy_no.Text.Trim();
            string StrBuy_Item = tb_buy_item.Text.Trim();
            string StrLot_NO = tb_lot_no.Text.Trim();
            string StrEP_NO = tb_ep_no.Text.Trim();
            string StrVerifier = tb_Verifier.Text.Trim();
            string StrWO_NO = tb_wo.Text.Trim();
            string StrSum = tb_sum.Text;
            string StrBak = tb_bak.Text.Trim();
            string StrUnit = tb_Unit.Text.Trim();

            if (cmbPrinterList.Text == "") { { MessageBox.Show("未選擇打印機！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); cmbPrinterList.Focus(); return; } }
            if (StrSupplier == "") { MessageBox.Show("供應商未選擇", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); cb_Supplier.Focus(); return; }
            if (StrPart_NO == "") { MessageBox.Show("料號不能爲空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); cb_PartNO.Focus(); return; }
            if (StrBuy_NO == "") { MessageBox.Show("采購單號不能爲空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_buy_no.Focus(); return; }
            if (StrBuy_Item == "") { MessageBox.Show("采購項次不能爲空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_buy_item.Focus(); return; }
            if (StrLot_NO == "") { MessageBox.Show("製造批號不能爲空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_lot_no.Focus(); return; }
            if (StrEP_NO == "") { MessageBox.Show("電鍍批號不能爲空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_ep_no.Focus(); return; }
            if (StrWO_NO == "") { MessageBox.Show("工單不能爲空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_wo.Focus(); return; }
            if (StrSum == "" || tb_sum.Value == 0) { MessageBox.Show("數量不能爲空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_sum.Focus(); return; }
            if (StrVerifier == "") { MessageBox.Show("檢驗員不能爲空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_Verifier.Focus(); return; }




            // btApp = getBarTender();
            //檢查是否有安裝BarTend
            //if (btApp == null)
            //{
            //    MessageBox.Show("列印前請先安裝BarTender!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //列印前請先安裝BarTender!
            //    return;
            //}          
            //檢查btw文件是否存在
            string startupPath = System.Windows.Forms.Application.StartupPath;
            string labFileName = startupPath + "\\deyi.Lab";
            string OracleName = startupPath + "\\Oracle.ManagedDataAccess.dll";
            string CodeSoftName = startupPath + "\\Interop.LabelManager2.dll";

            try
            {
                if (!File.Exists(OracleName))
                {
                    MessageBox.Show("沒有找到dll文件：" + startupPath + "\\Oracle.ManagedDataAccess.dll ,請聯系系統管理員", "溫馨提示");
                    return;
                }
                if (!File.Exists(CodeSoftName))
                {
                    MessageBox.Show("沒有找到dll：" + startupPath + "\\Interop.LabelManager2.dll,請聯系系統管理員", "溫馨提示");
                    return;
                }
                if (!File.Exists(labFileName))
                {
                    MessageBox.Show("沒有找到標簽模板文件：" + startupPath + "\\deyi.Lab,請聯系系統管理員", "溫馨提示");
                    return;
                }

                if (!Regex.IsMatch(StrEP_NO, strRegex))
                {
                    MessageBox.Show("電鍍批號格式不正確！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int itempEP = Convert.ToInt32(StrEP_NO.Substring(11));
                if (itempEP == 0) { return; };
                if ((Convert.ToInt32(tb_printNum.Value) + itempEP) >= 1000)
                {
                    MessageBox.Show("電鍍批號流水碼加打印數量不可超過999", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string strConnResult = dao.ConnTo();//連接mysql數據庫。
                if (strConnResult == "success")
                {
                    string strGet_ep_sum = dao.get_ep_sum(StrEP_NO);
                    if (strGet_ep_sum == "NO")
                    {
                        MessageBox.Show("電鍍批號已存在,請重新輸入。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (strGet_ep_sum.Contains("NG"))
                    {
                        MessageBox.Show(strGet_ep_sum, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    
                    List<SnDataVO> list = new List<SnDataVO>();
                    for (int i = 0; i < Convert.ToInt32(tb_printNum.Value); i++)
                    {
                        if (i != 0) 
                        {
                            if((itempEP + i) < 1000)
                            {
                                StrEP_NO = StrEP_NO.Substring(0, 11) + (itempEP + i).ToString("000");
                            }
                            else
                            {
                                //MessageBox.Show("电镀批号流水码已达999，已用尽！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            
                        }                      
                        strGet_ep_sum = dao.get_ep_sum(StrEP_NO);
                        if (strGet_ep_sum == "NO")
                        {
                            continue;
                        }
                        else if (strGet_ep_sum.Contains("NG"))
                        {
                            MessageBox.Show(strGet_ep_sum, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        string strSERIAL_NO = "";
                        string strGet_serial_noResult = dao.get_serial_no(StrProd_Data);
                        string strStrProd_Data2 = datePickFrom.Value.ToString("yyMMdd");
                        if (strGet_serial_noResult == "")
                        {
                            strSERIAL_NO = "A-" + strSUPPLIES_ID + "-" + strStrProd_Data2 + "-" + "00001";//如果SN_DATA中是空的。
                        }
                        else if (strGet_serial_noResult.Substring(0, 2) == "NG")
                        {
                            MessageBox.Show(strGet_serial_noResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            //如果SN_DATA中不是空的。
                            int iLenght = strGet_serial_noResult.Length;
                            strSERIAL_NO = "A-" + strSUPPLIES_ID + "-" + strStrProd_Data2 + "-" + (Convert.ToInt32(strGet_serial_noResult.Substring(iLenght-5)) + 1).ToString("00000");
                        }

                        string strResurt = dao.Insert_sn_data(strSERIAL_NO, StrEP_NO, strSUPPLIES_ID, StrLot_NO, StrProd_Data, StrWO_NO, StrSum, StrUnit, StrSupplier, StrPart_NO, StrPart_Name, strBand, StrSpec, StrMaterial, StrBuy_NO, StrBuy_Item, StrVerifier, StrBak);
                        if (strResurt == "Duplicate")
                        {
                            continue;
                        }
                        else if (strResurt.Contains("NG"))
                        {
                            MessageBox.Show(strResurt, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        SnDataVO sndatavo = new SnDataVO();
                        sndatavo.SERIAL_NO = strSERIAL_NO;
                        sndatavo.EP_NO = StrEP_NO;
                        sndatavo.SUPPLYER_ID = strSUPPLIES_ID;
                        sndatavo.LOT_NO = StrLot_NO;
                        sndatavo.PROD_DATE = StrProd_Data;
                        sndatavo.WO_NO = StrWO_NO;
                        sndatavo.QTY = StrSum;
                        sndatavo.UNIT = StrUnit;
                        sndatavo.SUPPLYER = StrSupplier;
                        sndatavo.PART_NO = StrPart_NO;
                        sndatavo.PART_NAME = StrPart_Name;
                        sndatavo.BAND = strBand;
                        sndatavo.SPEC = StrSpec;
                        sndatavo.MATERIAL = StrMaterial;
                        sndatavo.BUY_NO = StrBuy_NO;
                        sndatavo.BUY_ENTRY = StrBuy_Item;
                        sndatavo.VERIFIER = StrVerifier;
                        sndatavo.REMARK = StrBak;
                        list.Add(sndatavo);
                    }

                   // btFormat = btApp.Formats.Open(startupPath + @"\deyi", false, OldActPrn);
                    DateTime dateTime = DateTime.Parse(StrProd_Data);
                    string strYY = dateTime.Year.ToString();
                    int intMonth = dateTime.Month;
                    double doubleM = (double)intMonth / 3.0;
                    string strQuarter = Math.Ceiling(doubleM).ToString();

                    button1.Enabled = false;
                    foreach (SnDataVO vo in list)
                    {
                        labApp = new LabelManager2.ApplicationClass();
                        labApp.Documents.Open(startupPath+@"\deyi.Lab", false);// 调用设计好的label文件
                        doc = labApp.ActiveDocument;
                        doc.Printer.SwitchTo(OldActPrn);

                        doc.Variables.FormVariables.Item("StrSerial_NO").Value = vo.SERIAL_NO; //序号
                        doc.Variables.FormVariables.Item("StrEP_NO").Value = vo.EP_NO; //供应商
                        doc.Variables.FormVariables.Item("StrSupplier").Value = vo.SUPPLYER; //供应商
                        doc.Variables.FormVariables.Item("StrPart_NO").Value = vo.PART_NO;//料号
                        doc.Variables.FormVariables.Item("StrPart_Name").Value = vo.PART_NAME;//品名
                        doc.Variables.FormVariables.Item("StrSpec").Value = vo.SPEC;//規格
                        doc.Variables.FormVariables.Item("strBand").Value = vo.BAND;//带别
                        doc.Variables.FormVariables.Item("StrMaterial").Value = vo.MATERIAL;//材质
                        doc.Variables.FormVariables.Item("StrProd_Data").Value = vo.PROD_DATE;//制造日期
                        doc.Variables.FormVariables.Item("StrProd_Data2").Value = datePickFrom.Value.ToString("yyMMdd");//二维码上的制造日期
                        doc.Variables.FormVariables.Item("StrBuy_NO").Value = vo.BUY_NO;//采购单号
                        doc.Variables.FormVariables.Item("StrBuy_Item").Value = vo.BUY_ENTRY;//采购项次
                        doc.Variables.FormVariables.Item("StrLot_NO").Value = vo.LOT_NO;//制造批号
                        doc.Variables.FormVariables.Item("StrEP_NO").Value = vo.EP_NO;//电镀批号
                        doc.Variables.FormVariables.Item("StrVerifier").Value = vo.VERIFIER;//检验员
                        doc.Variables.FormVariables.Item("StrWO_NO").Value = vo.WO_NO;//工单
                        doc.Variables.FormVariables.Item("StrSum").Value = vo.QTY;//数量
                        doc.Variables.FormVariables.Item("StrUnit").Value = vo.UNIT;//单位
                        doc.Variables.FormVariables.Item("StrBak").Value = StrBak;//备注
                        doc.Variables.FormVariables.Item("StrYY").Value = strYY;//年strQuarter
                        doc.Variables.FormVariables.Item("strQuarter").Value = strQuarter;

                        doc.PrintDocument(1);                             //打印
                        if (labApp != null)
                        {
                            labApp.Documents.CloseAll(true);
                            labApp.Quit();//退出
                            labApp = null;
                            doc = null;
                        }
                        //btFormat.PrintSetup.IdenticalCopiesOfLabel = 1;  //设置同序列打印的份数
                        //btFormat.PrintSetup.NumberSerializedLabels = 1;  //设置需要打印的序列数
                        //btFormat.SetNamedSubStringValue("StrSerial_NO", vo.SERIAL_NO); //序号
                        //btFormat.SetNamedSubStringValue("StrEP_NO", vo.EP_NO); //供应商
                        //btFormat.SetNamedSubStringValue("StrSupplier", vo.SUPPLYER); //供应商
                        //btFormat.SetNamedSubStringValue("StrPart_NO", vo.PART_NO);//料号
                        //btFormat.SetNamedSubStringValue("StrPart_Name", vo.PART_NAME);//品名
                        //btFormat.SetNamedSubStringValue("StrSpec", vo.SPEC);//規格
                        //btFormat.SetNamedSubStringValue("strBand", vo.BAND);//带别
                        //btFormat.SetNamedSubStringValue("StrMaterial", vo.MATERIAL);//材质
                        //btFormat.SetNamedSubStringValue("StrProd_Data", vo.PROD_DATE);//制造日期
                        //btFormat.SetNamedSubStringValue("StrBuy_NO", vo.BUY_NO);//采购单号
                        //btFormat.SetNamedSubStringValue("StrBuy_Item", vo.BUY_ENTRY);//采购项次
                        //btFormat.SetNamedSubStringValue("StrLot_NO", vo.LOT_NO);//制造批号
                        //btFormat.SetNamedSubStringValue("StrEP_NO", vo.EP_NO);//电镀批号
                        //btFormat.SetNamedSubStringValue("StrVerifier", vo.VERIFIER);//检验员
                        //btFormat.SetNamedSubStringValue("StrWO_NO", vo.WO_NO);//工单
                        //btFormat.SetNamedSubStringValue("StrSum", vo.QTY);//数量
                        //btFormat.SetNamedSubStringValue("StrUnit", vo.UNIT);//单位
                        //btFormat.SetNamedSubStringValue("StrBak", StrBak);//备注
                        //btFormat.SetNamedSubStringValue("StrYY", strYY);//年strQuarter
                        //btFormat.SetNamedSubStringValue("strQuarter", strQuarter);
                        //btFormat.PrintOut(false, false); //第二个false设置打印时是否跳出打印属性
                    }
                    //btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges); //退出时是否保存标签
                }
                else
                {
                    MessageBox.Show("数据库连接错误!" + strConnResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                getLastEPNO();
                button1.Enabled = true;
                //inival();
            }
            catch (Exception ex)
            {
                MessageBox.Show("出錯啦，原因如下：\n\r" + ex.Message, "出錯啦");
                button1.Enabled = true;
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
                button1.Enabled = true;
                dao.Close();
                GC.Collect(0);

            }
        }

        //public static BarTender.Application getBarTender()
        //{
        //    if (btApp == null)
        //    {
        //        try
        //        {
        //            btApp = new BarTender.Application();
        //        }
        //        catch(Exception ex)
        //        {
        //            if (btApp != null) 
        //            {
        //                System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp); 
        //            }
        //            Console.WriteLine(ex.Message);
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
        private void deyi_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (btApp != null) btApp.Quit(BarTender.BtSaveOptions.btSaveChanges);//界面退出时同步退出bartender进程
            this.Owner.Show();
        }

        private void deyi_Shown(object sender, EventArgs e)
        {
            string startupPath = System.Windows.Forms.Application.StartupPath;
            string labFileName = startupPath + "\\Oracle.ManagedDataAccess.dll";
            if (!File.Exists(labFileName))
            {
                MessageBox.Show("沒有找到dll文件 ：" + startupPath + "\\Oracle.ManagedDataAccess.dll,請聯系系統管理員", "溫馨提示");
                return;
            }
            datePickFrom.Value = DateTime.Today;
            init_basic_data();
        }

        private void deyi_Load(object sender, EventArgs e)
        {
            this.Owner.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            inival();
        }

        private void cmbPrinterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            OldActPrn = cmbPrinterList.Text;
        }

        private void datePickFrom_ValueChanged(object sender, EventArgs e)
        {
            getLastEPNO();


        }
        private void getLastEPNO()
        {
            string StrProd_Data = datePickFrom.Value.ToString("yyyy'-'MM'-'dd");
            string strMessage = dao.get_last_epNO(StrProd_Data);
            if (strMessage.Substring(0, 2) == "NG")
            {
                MessageBox.Show(strMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                label20.Text = strMessage;
            }
        }
    }
}
