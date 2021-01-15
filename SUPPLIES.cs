using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace printlabelqr
{
    public partial class SUPPLIES : Form
    {
        private DAO dao = new DAO();
        DataTable dt = new DataTable();
        public SUPPLIES()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string strSuppliesID = tbSuppliesID.Text.Trim();
            if (strSuppliesID != "")
            {
                if (dt != null && dt.Rows.Count != 0) dt.Clear();
                string strmessag=dao.get_supplies(strSuppliesID,ref dt);
                if (strmessag == "OK")
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].HeaderText = "供應商ID";
                    dataGridView1.Columns[1].HeaderText = "供應商名稱";
                    dataGridView1.Columns[2].HeaderText = "狀態";
                }
                else
                {
                    MessageBox.Show(strmessag, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
          //  if (dataGridView1.Rows.Count == 0) return;
               // tb_SUPPLIES_ID.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
           // tbSUPPLIES_NAME.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//设置为整行被选中码
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            string strID = tb_SUPPLIES_ID.Text.Trim();
            string strName = tbSUPPLIES_NAME.Text.Trim();

            if (strID != ""&& strName != "")
            {
                string strMessage = dao.add_supplies("add","","",strID, strName);
                if (strMessage == "OK")
                {
                    MessageBox.Show("新增成功！", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(strMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("供應商ID和供應商名字不能為空！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0) return;
            string strID_old = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string strName_old = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string strID = tb_SUPPLIES_ID.Text.Trim();
            string strName = tbSUPPLIES_NAME.Text.Trim();
            if (strID != "" && strName != "")
            {
                string strMessage = dao.add_supplies("update", strID_old, strName_old,strID, strName);
                if (strMessage == "OK")
                {
                    MessageBox.Show("修改成功！", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(strMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("供應商ID和供應商名字不能為空！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
