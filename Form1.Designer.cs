namespace printlabelqr
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button2 = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tb_dev = new System.Windows.Forms.TextBox();
            this.tb_ver = new System.Windows.Forms.TextBox();
            this.lableSQPONO = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_env = new System.Windows.Forms.GroupBox();
            this.tb_ven = new System.Windows.Forms.ComboBox();
            this.tb_ep = new System.Windows.Forms.ComboBox();
            this.tb_printNum = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbPrinterList = new System.Windows.Forms.ComboBox();
            this.tb_mon = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.tb_no = new System.Windows.Forms.NumericUpDown();
            this.dateTimePicker_del = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.tb_weight = new System.Windows.Forms.NumericUpDown();
            this.datePickFrom = new System.Windows.Forms.DateTimePicker();
            this.tb_PartNO = new System.Windows.Forms.ComboBox();
            this.tb_bak = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tb_org = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_unit = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tb_item = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_wo = new System.Windows.Forms.TextBox();
            this.tb_spec = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tb_env.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_printNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_mon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_no)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_weight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(351, 515);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(59, 23);
            this.button2.TabIndex = 57;
            this.button2.Text = "清空";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(225, 515);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(52, 23);
            this.btnOK.TabIndex = 56;
            this.btnOK.Text = "打印";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tb_dev
            // 
            this.tb_dev.BackColor = System.Drawing.Color.Linen;
            this.tb_dev.Enabled = false;
            this.tb_dev.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_dev.Location = new System.Drawing.Point(444, 288);
            this.tb_dev.Name = "tb_dev";
            this.tb_dev.Size = new System.Drawing.Size(106, 26);
            this.tb_dev.TabIndex = 48;
            this.tb_dev.TabStop = false;
            // 
            // tb_ver
            // 
            this.tb_ver.BackColor = System.Drawing.Color.LemonChiffon;
            this.tb_ver.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_ver.Location = new System.Drawing.Point(106, 135);
            this.tb_ver.Name = "tb_ver";
            this.tb_ver.Size = new System.Drawing.Size(63, 26);
            this.tb_ver.TabIndex = 11;
            this.tb_ver.Click += new System.EventHandler(this.tb_ver_Click);
            // 
            // lableSQPONO
            // 
            this.lableSQPONO.AutoSize = true;
            this.lableSQPONO.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableSQPONO.Location = new System.Drawing.Point(18, 216);
            this.lableSQPONO.Name = "lableSQPONO";
            this.lableSQPONO.Size = new System.Drawing.Size(82, 19);
            this.lableSQPONO.TabIndex = 35;
            this.lableSQPONO.Text = "生產日期:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(347, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 19);
            this.label6.TabIndex = 34;
            this.label6.Text = "幾臺/設備:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 19);
            this.label5.TabIndex = 33;
            this.label5.Text = "訂單號:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 19);
            this.label4.TabIndex = 32;
            this.label4.Text = "品名/規格:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(351, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 19);
            this.label3.TabIndex = 31;
            this.label3.Text = "環保特性:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 19);
            this.label2.TabIndex = 30;
            this.label2.Text = "版本:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 19);
            this.label1.TabIndex = 29;
            this.label1.Text = "料件編號:";
            // 
            // tb_env
            // 
            this.tb_env.Controls.Add(this.tb_ven);
            this.tb_env.Controls.Add(this.tb_ep);
            this.tb_env.Controls.Add(this.tb_printNum);
            this.tb_env.Controls.Add(this.label19);
            this.tb_env.Controls.Add(this.label18);
            this.tb_env.Controls.Add(this.cmbPrinterList);
            this.tb_env.Controls.Add(this.tb_mon);
            this.tb_env.Controls.Add(this.label17);
            this.tb_env.Controls.Add(this.tb_no);
            this.tb_env.Controls.Add(this.dateTimePicker_del);
            this.tb_env.Controls.Add(this.label16);
            this.tb_env.Controls.Add(this.tb_weight);
            this.tb_env.Controls.Add(this.datePickFrom);
            this.tb_env.Controls.Add(this.tb_PartNO);
            this.tb_env.Controls.Add(this.tb_bak);
            this.tb_env.Controls.Add(this.label13);
            this.tb_env.Controls.Add(this.tb_org);
            this.tb_env.Controls.Add(this.label11);
            this.tb_env.Controls.Add(this.label12);
            this.tb_env.Controls.Add(this.label9);
            this.tb_env.Controls.Add(this.label10);
            this.tb_env.Controls.Add(this.tb_unit);
            this.tb_env.Controls.Add(this.label8);
            this.tb_env.Controls.Add(this.label14);
            this.tb_env.Controls.Add(this.tb_item);
            this.tb_env.Controls.Add(this.label7);
            this.tb_env.Controls.Add(this.tb_wo);
            this.tb_env.Controls.Add(this.tb_spec);
            this.tb_env.Controls.Add(this.button2);
            this.tb_env.Controls.Add(this.btnOK);
            this.tb_env.Controls.Add(this.tb_dev);
            this.tb_env.Controls.Add(this.tb_ver);
            this.tb_env.Controls.Add(this.lableSQPONO);
            this.tb_env.Controls.Add(this.label6);
            this.tb_env.Controls.Add(this.label5);
            this.tb_env.Controls.Add(this.label4);
            this.tb_env.Controls.Add(this.label3);
            this.tb_env.Controls.Add(this.label2);
            this.tb_env.Controls.Add(this.label1);
            this.tb_env.Location = new System.Drawing.Point(12, 72);
            this.tb_env.Name = "tb_env";
            this.tb_env.Size = new System.Drawing.Size(657, 556);
            this.tb_env.TabIndex = 32;
            this.tb_env.TabStop = false;
            // 
            // tb_ven
            // 
            this.tb_ven.BackColor = System.Drawing.Color.LemonChiffon;
            this.tb_ven.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tb_ven.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tb_ven.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_ven.FormattingEnabled = true;
            this.tb_ven.Location = new System.Drawing.Point(444, 136);
            this.tb_ven.Name = "tb_ven";
            this.tb_ven.Size = new System.Drawing.Size(156, 24);
            this.tb_ven.TabIndex = 87;
            this.tb_ven.TabStop = false;
            // 
            // tb_ep
            // 
            this.tb_ep.BackColor = System.Drawing.Color.LemonChiffon;
            this.tb_ep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tb_ep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tb_ep.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_ep.FormattingEnabled = true;
            this.tb_ep.Location = new System.Drawing.Point(444, 100);
            this.tb_ep.Name = "tb_ep";
            this.tb_ep.Size = new System.Drawing.Size(106, 24);
            this.tb_ep.TabIndex = 86;
            this.tb_ep.TabStop = false;
            // 
            // tb_printNum
            // 
            this.tb_printNum.BackColor = System.Drawing.Color.LemonChiffon;
            this.tb_printNum.Location = new System.Drawing.Point(106, 438);
            this.tb_printNum.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.tb_printNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tb_printNum.Name = "tb_printNum";
            this.tb_printNum.Size = new System.Drawing.Size(73, 21);
            this.tb_printNum.TabIndex = 84;
            this.tb_printNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(18, 440);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(82, 19);
            this.label19.TabIndex = 85;
            this.label19.Text = "打印数量:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(35, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 19);
            this.label18.TabIndex = 83;
            this.label18.Text = "打印機:";
            // 
            // cmbPrinterList
            // 
            this.cmbPrinterList.BackColor = System.Drawing.Color.LemonChiffon;
            this.cmbPrinterList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinterList.FormattingEnabled = true;
            this.cmbPrinterList.Location = new System.Drawing.Point(106, 23);
            this.cmbPrinterList.Name = "cmbPrinterList";
            this.cmbPrinterList.Size = new System.Drawing.Size(409, 20);
            this.cmbPrinterList.TabIndex = 82;
            this.cmbPrinterList.SelectedIndexChanged += new System.EventHandler(this.cmbPrinterList_SelectedIndexChanged);
            // 
            // tb_mon
            // 
            this.tb_mon.BackColor = System.Drawing.Color.LemonChiffon;
            this.tb_mon.Location = new System.Drawing.Point(106, 404);
            this.tb_mon.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.tb_mon.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tb_mon.Name = "tb_mon";
            this.tb_mon.Size = new System.Drawing.Size(73, 21);
            this.tb_mon.TabIndex = 18;
            this.tb_mon.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tb_mon.Click += new System.EventHandler(this.tb_mon_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(52, 405);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 19);
            this.label17.TabIndex = 81;
            this.label17.Text = "月份:";
            // 
            // tb_no
            // 
            this.tb_no.BackColor = System.Drawing.Color.LemonChiffon;
            this.tb_no.Location = new System.Drawing.Point(106, 294);
            this.tb_no.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.tb_no.Name = "tb_no";
            this.tb_no.Size = new System.Drawing.Size(106, 21);
            this.tb_no.TabIndex = 15;
            this.tb_no.Click += new System.EventHandler(this.tb_no_Click);
            // 
            // dateTimePicker_del
            // 
            this.dateTimePicker_del.Font = new System.Drawing.Font("宋体", 10F);
            this.dateTimePicker_del.Location = new System.Drawing.Point(106, 366);
            this.dateTimePicker_del.MinDate = new System.DateTime(2020, 5, 14, 0, 0, 0, 0);
            this.dateTimePicker_del.Name = "dateTimePicker_del";
            this.dateTimePicker_del.Size = new System.Drawing.Size(147, 23);
            this.dateTimePicker_del.TabIndex = 17;
            this.dateTimePicker_del.ValueChanged += new System.EventHandler(this.dateTimePicker_del_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(185, 335);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 12);
            this.label16.TabIndex = 80;
            this.label16.Text = "KG";
            // 
            // tb_weight
            // 
            this.tb_weight.BackColor = System.Drawing.Color.LemonChiffon;
            this.tb_weight.DecimalPlaces = 2;
            this.tb_weight.Location = new System.Drawing.Point(106, 331);
            this.tb_weight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.tb_weight.Name = "tb_weight";
            this.tb_weight.Size = new System.Drawing.Size(73, 21);
            this.tb_weight.TabIndex = 16;
            this.tb_weight.Click += new System.EventHandler(this.tb_weight_Click);
            // 
            // datePickFrom
            // 
            this.datePickFrom.Font = new System.Drawing.Font("宋体", 10F);
            this.datePickFrom.Location = new System.Drawing.Point(106, 214);
            this.datePickFrom.Name = "datePickFrom";
            this.datePickFrom.Size = new System.Drawing.Size(147, 23);
            this.datePickFrom.TabIndex = 13;
            // 
            // tb_PartNO
            // 
            this.tb_PartNO.BackColor = System.Drawing.Color.LemonChiffon;
            this.tb_PartNO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tb_PartNO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tb_PartNO.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_PartNO.FormattingEnabled = true;
            this.tb_PartNO.Location = new System.Drawing.Point(106, 99);
            this.tb_PartNO.Name = "tb_PartNO";
            this.tb_PartNO.Size = new System.Drawing.Size(168, 24);
            this.tb_PartNO.TabIndex = 10;
            this.tb_PartNO.SelectedIndexChanged += new System.EventHandler(this.tb_PartNO_SelectedIndexChanged);
            // 
            // tb_bak
            // 
            this.tb_bak.BackColor = System.Drawing.Color.LemonChiffon;
            this.tb_bak.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_bak.Location = new System.Drawing.Point(106, 473);
            this.tb_bak.Name = "tb_bak";
            this.tb_bak.Size = new System.Drawing.Size(364, 26);
            this.tb_bak.TabIndex = 19;
            this.tb_bak.Click += new System.EventHandler(this.tb_bak_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(52, 477);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 19);
            this.label13.TabIndex = 75;
            this.label13.Text = "備注:";
            // 
            // tb_org
            // 
            this.tb_org.BackColor = System.Drawing.Color.Linen;
            this.tb_org.Enabled = false;
            this.tb_org.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_org.Location = new System.Drawing.Point(444, 364);
            this.tb_org.Name = "tb_org";
            this.tb_org.Size = new System.Drawing.Size(106, 26);
            this.tb_org.TabIndex = 74;
            this.tb_org.TabStop = false;
            this.tb_org.Text = "東莞";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(368, 368);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 19);
            this.label11.TabIndex = 73;
            this.label11.Text = "原產地:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(18, 368);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 19);
            this.label12.TabIndex = 71;
            this.label12.Text = "交貨日期:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(52, 332);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 19);
            this.label9.TabIndex = 69;
            this.label9.Text = "毛重:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(368, 139);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 19);
            this.label10.TabIndex = 67;
            this.label10.Text = "供應商:";
            // 
            // tb_unit
            // 
            this.tb_unit.BackColor = System.Drawing.Color.Linen;
            this.tb_unit.Enabled = false;
            this.tb_unit.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_unit.Location = new System.Drawing.Point(444, 328);
            this.tb_unit.Name = "tb_unit";
            this.tb_unit.Size = new System.Drawing.Size(106, 26);
            this.tb_unit.TabIndex = 66;
            this.tb_unit.TabStop = false;
            this.tb_unit.Text = "PCS";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(385, 332);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 19);
            this.label8.TabIndex = 65;
            this.label8.Text = "單位:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(52, 295);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 19);
            this.label14.TabIndex = 63;
            this.label14.Text = "數量:";
            // 
            // tb_item
            // 
            this.tb_item.BackColor = System.Drawing.Color.LemonChiffon;
            this.tb_item.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_item.Location = new System.Drawing.Point(106, 251);
            this.tb_item.Name = "tb_item";
            this.tb_item.Size = new System.Drawing.Size(106, 26);
            this.tb_item.TabIndex = 14;
            this.tb_item.Click += new System.EventHandler(this.tb_item_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(52, 255);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 19);
            this.label7.TabIndex = 61;
            this.label7.Text = "項次:";
            // 
            // tb_wo
            // 
            this.tb_wo.BackColor = System.Drawing.Color.LemonChiffon;
            this.tb_wo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_wo.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_wo.Location = new System.Drawing.Point(106, 174);
            this.tb_wo.Name = "tb_wo";
            this.tb_wo.Size = new System.Drawing.Size(150, 26);
            this.tb_wo.TabIndex = 12;
            this.tb_wo.Click += new System.EventHandler(this.tb_wo_Click);
            // 
            // tb_spec
            // 
            this.tb_spec.BackColor = System.Drawing.Color.Linen;
            this.tb_spec.Enabled = false;
            this.tb_spec.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_spec.Location = new System.Drawing.Point(106, 60);
            this.tb_spec.Name = "tb_spec";
            this.tb_spec.Size = new System.Drawing.Size(496, 26);
            this.tb_spec.TabIndex = 59;
            this.tb_spec.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(281, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(345, 33);
            this.label15.TabIndex = 31;
            this.label15.Text = "東莞立德精密有限公司";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(34, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 58);
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 630);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tb_env);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "標簽打印V1.0.2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tb_env.ResumeLayout(false);
            this.tb_env.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_printNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_mon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_no)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_weight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tb_dev;
        private System.Windows.Forms.TextBox tb_ver;
        private System.Windows.Forms.Label lableSQPONO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox tb_env;
        private System.Windows.Forms.TextBox tb_bak;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tb_org;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_unit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tb_item;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_wo;
        private System.Windows.Forms.TextBox tb_spec;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox tb_PartNO;
        private System.Windows.Forms.DateTimePicker datePickFrom;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown tb_weight;
        private System.Windows.Forms.DateTimePicker dateTimePicker_del;
        private System.Windows.Forms.NumericUpDown tb_no;
        private System.Windows.Forms.NumericUpDown tb_mon;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbPrinterList;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown tb_printNum;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox tb_ep;
        private System.Windows.Forms.ComboBox tb_ven;
    }
}

