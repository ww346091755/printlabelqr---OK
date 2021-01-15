/*****************************************************************
 * Copyright (C) Knights Warrior Corporation. All rights reserved.
 * 
 * Author:    •µÓ∆Ô ø£®Knights Warrior£© 
 * Email:    KnightsWarrior@msn.com
 * Website:  http://www.cnblogs.com/KnightsWarrior/       http://knightswarrior.blog.51cto.com/
 * Create Date:  5/8/2010 
 * Usage:
 *
 * RevisionHistory
 * Date         Author               Description
 * 
*****************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KnightsWarriorAutoupdater
{
    public partial class DownloadConfirm : Form
    {
        int i = 1;
        

        #region The private fields
        List<DownloadFileInfo> downloadFileList = null;
        #endregion

        #region The constructor of DownloadConfirm
        public DownloadConfirm(List<DownloadFileInfo> downloadfileList)
        {
            InitializeComponent();
            timer1.Enabled = true;
            downloadFileList = downloadfileList;
        }
        #endregion

        #region The private method
        private void OnLoad(object sender, EventArgs e)
        {
            int i = 0;
            foreach (DownloadFileInfo file in this.downloadFileList)
            {
                i++;
                ListViewItem item = new ListViewItem(i.ToString());
                item.SubItems.Add(file.FileName);
                item.SubItems.Add(file.LastVer);
                item.SubItems.Add(file.Size.ToString());
                listView1.Items.Add(item);
               

            }
            

            this.Activate();
            this.Focus();
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i >= 10)
            {
                timer1.Enabled = false;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                label1.Text = (Convert.ToInt32(label1.Text) - 1).ToString();
                i++;
            }
        }
    }
}