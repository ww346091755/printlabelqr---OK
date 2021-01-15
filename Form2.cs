using KnightsWarriorAutoupdater;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace printlabelqr
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        void CheckUpdate()
        {

            #region check and download new version program
            bool bHasError = false;
            IAutoUpdater autoUpdater = new AutoUpdater();
            try
            {
                autoUpdater.Update();
            }
            catch (WebException exp)
            {
                MessageBox.Show("服務連接失敗，不更新！");
                bHasError = true;
            }
            catch (XmlException exp)
            {
                bHasError = true;
                MessageBox.Show("下載更新文件出錯，不更新！");
            }
            catch (NotSupportedException exp)
            {
                bHasError = true;
                MessageBox.Show("更新地址配置錯誤，不更新！");
            }
            catch (ArgumentException exp)
            {
                bHasError = true;
                MessageBox.Show("下載升級文件出錯，不更新！");
            }
            catch (Exception exp)
            {
                bHasError = true;
                MessageBox.Show("升級過程中出錯，不更新！");
            }
            finally
            {
                if (bHasError == true)
                {
                    try
                    {
                        autoUpdater.RollBack();
                    }
                    catch (Exception)
                    {
                        //Log the message to your file or database
                    }
                }
            }
            #endregion
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            //if (!File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + '\\' + "AutoUpdater.config"))
            //{
            //    //MessageBox.Show("AutoUpdater.config不存在，不執行更新作業！！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    XmlDocument xml = new XmlDocument();
            //    XmlDeclaration decl = xml.CreateXmlDeclaration("1.0", "utf-8", null);
            //    xml.AppendChild(decl);
            //    try
            //    {
            //        XmlElement rootEle = xml.CreateElement("Config");
            //        rootEle.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            //        rootEle.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
            //        xml.AppendChild(rootEle);
            //        XmlElement EnableEle = xml.CreateElement("Enabled");
            //        EnableEle.InnerText = "true";
            //        rootEle.AppendChild(EnableEle);
            //        XmlElement ServerUrlEle = xml.CreateElement("ServerUrl");
            //        ServerUrlEle.InnerText = "http://192.168.60.31:8050/AutoupdateService.xml";
            //        rootEle.AppendChild(ServerUrlEle);
            //        XmlElement UpdateFileListEle = xml.CreateElement("UpdateFileList");
            //        rootEle.AppendChild(UpdateFileListEle);
            //        XmlElement LocalFileEle = xml.CreateElement("LocalFile");
            //        LocalFileEle.SetAttribute("path", "printlabelqr.exe");
            //        LocalFileEle.SetAttribute("lastver", "1.0.0.0");
            //        LocalFileEle.SetAttribute("size", "100");
            //        UpdateFileListEle.AppendChild(LocalFileEle);
            //        xml.Save(System.AppDomain.CurrentDomain.BaseDirectory + '\\' + "AutoUpdater.config");
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("生成Config出錯,不更新:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;

            //    }
            //}
            //CheckUpdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deyi dy = new deyi();
            dy.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LideSPA ldSPA = new LideSPA();
            ldSPA.ShowDialog(this);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text =  System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Lide201020 lide201020 = new Lide201020();
            lide201020.ShowDialog(this);
        }
    }
}
