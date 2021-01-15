namespace printlabelqr
{
    partial class SUPPLIES
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbSuppliesID = new System.Windows.Forms.TextBox();
            this.btnADD = new System.Windows.Forms.Button();
            this.btnDEL = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnQiut = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSUPPLIES_NAME = new System.Windows.Forms.TextBox();
            this.tb_SUPPLIES_ID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "查詢條件:";
            // 
            // tbSuppliesID
            // 
            this.tbSuppliesID.Location = new System.Drawing.Point(77, 21);
            this.tbSuppliesID.Name = "tbSuppliesID";
            this.tbSuppliesID.Size = new System.Drawing.Size(111, 21);
            this.tbSuppliesID.TabIndex = 1;
            // 
            // btnADD
            // 
            this.btnADD.Location = new System.Drawing.Point(336, 21);
            this.btnADD.Name = "btnADD";
            this.btnADD.Size = new System.Drawing.Size(75, 23);
            this.btnADD.TabIndex = 2;
            this.btnADD.Text = "新增資料";
            this.btnADD.UseVisualStyleBackColor = true;
            this.btnADD.Click += new System.EventHandler(this.btnADD_Click);
            // 
            // btnDEL
            // 
            this.btnDEL.Location = new System.Drawing.Point(496, 76);
            this.btnDEL.Name = "btnDEL";
            this.btnDEL.Size = new System.Drawing.Size(75, 23);
            this.btnDEL.TabIndex = 3;
            this.btnDEL.Text = "刪除資料";
            this.btnDEL.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(496, 32);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "修改資料";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnQiut
            // 
            this.btnQiut.Location = new System.Drawing.Point(600, 21);
            this.btnQiut.Name = "btnQiut";
            this.btnQiut.Size = new System.Drawing.Size(75, 23);
            this.btnQiut.TabIndex = 5;
            this.btnQiut.Text = "退出";
            this.btnQiut.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(663, 239);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbSUPPLIES_NAME);
            this.groupBox1.Controls.Add(this.tb_SUPPLIES_ID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnDEL);
            this.groupBox1.Location = new System.Drawing.Point(12, 317);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 138);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "資料设定";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "供應商名稱:";
            // 
            // tbSUPPLIES_NAME
            // 
            this.tbSUPPLIES_NAME.Location = new System.Drawing.Point(263, 75);
            this.tbSUPPLIES_NAME.Name = "tbSUPPLIES_NAME";
            this.tbSUPPLIES_NAME.Size = new System.Drawing.Size(166, 21);
            this.tbSUPPLIES_NAME.TabIndex = 2;
            // 
            // tb_SUPPLIES_ID
            // 
            this.tb_SUPPLIES_ID.Location = new System.Drawing.Point(263, 33);
            this.tb_SUPPLIES_ID.Name = "tb_SUPPLIES_ID";
            this.tb_SUPPLIES_ID.Size = new System.Drawing.Size(166, 21);
            this.tb_SUPPLIES_ID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "供应商ID:";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(208, 21);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Text = "查詢";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // SUPPLIES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 465);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnQiut);
            this.Controls.Add(this.btnADD);
            this.Controls.Add(this.tbSuppliesID);
            this.Controls.Add(this.label1);
            this.Name = "SUPPLIES";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SUPPLIES";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSuppliesID;
        private System.Windows.Forms.Button btnADD;
        private System.Windows.Forms.Button btnDEL;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnQiut;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSUPPLIES_NAME;
        private System.Windows.Forms.TextBox tb_SUPPLIES_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnQuery;
    }
}