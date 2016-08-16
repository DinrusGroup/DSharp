namespace DSharpIDE
{
    partial class Configurator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configurator));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.windowRadio = new System.Windows.Forms.RadioButton();
            this.consoleRadio = new System.Windows.Forms.RadioButton();
            this.newCfgLabel = new System.Windows.Forms.Label();
            this.newCfgText = new System.Windows.Forms.TextBox();
            this.versionCombo = new System.Windows.Forms.ComboBox();
            this.scIniText = new System.Windows.Forms.RichTextBox();
            this.updateConf = new System.Windows.Forms.Button();
            this.saveScIni = new System.Windows.Forms.Button();
            this.modeLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.versionParamLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lolGifPB = new System.Windows.Forms.PictureBox();
            this.closeBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lolGifPB)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.newCfgText);
            this.groupBox1.Controls.Add(this.versionCombo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.Color.Indigo;
            this.groupBox1.Location = new System.Drawing.Point(0, 276);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 243);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор Конфигурации";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox3.Controls.Add(this.radioButton4);
            this.groupBox3.Controls.Add(this.radioButton3);
            this.groupBox3.ForeColor = System.Drawing.Color.LightYellow;
            this.helpProvider1.SetHelpKeyword(this.groupBox3, "Библиотеки");
            this.helpProvider1.SetHelpString(this.groupBox3, "Использование всех библиотек (зарегистрированных) или только основной (применяетс" +
                    "я при компиляции dll).");
            this.groupBox3.Location = new System.Drawing.Point(137, 146);
            this.groupBox3.Name = "groupBox3";
            this.helpProvider1.SetShowHelp(this.groupBox3, true);
            this.groupBox3.Size = new System.Drawing.Size(197, 39);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Библиотеки";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(106, 15);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(83, 17);
            this.radioButton4.TabIndex = 2;
            this.radioButton4.Text = "Основная";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.versionRadio_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(24, 16);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(47, 17);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Все";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox2.Controls.Add(this.windowRadio);
            this.groupBox2.Controls.Add(this.consoleRadio);
            this.groupBox2.ForeColor = System.Drawing.Color.LavenderBlush;
            this.helpProvider1.SetHelpKeyword(this.groupBox2, "Режим");
            this.helpProvider1.SetHelpString(this.groupBox2, "Изменение режима между консольным и оконным.");
            this.groupBox2.Location = new System.Drawing.Point(12, 70);
            this.groupBox2.Name = "groupBox2";
            this.helpProvider1.SetShowHelp(this.groupBox2, true);
            this.groupBox2.Size = new System.Drawing.Size(197, 45);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Режим";
            // 
            // windowRadio
            // 
            this.windowRadio.AutoSize = true;
            this.windowRadio.Location = new System.Drawing.Point(106, 19);
            this.windowRadio.Name = "windowRadio";
            this.windowRadio.Size = new System.Drawing.Size(55, 17);
            this.windowRadio.TabIndex = 1;
            this.windowRadio.Text = "Окно";
            this.windowRadio.UseVisualStyleBackColor = true;
            this.windowRadio.CheckedChanged += new System.EventHandler(this.windowRadio_CheckedChanged);
            // 
            // consoleRadio
            // 
            this.consoleRadio.AutoSize = true;
            this.consoleRadio.Checked = true;
            this.consoleRadio.Location = new System.Drawing.Point(24, 19);
            this.consoleRadio.Name = "consoleRadio";
            this.helpProvider1.SetShowHelp(this.consoleRadio, true);
            this.consoleRadio.Size = new System.Drawing.Size(75, 17);
            this.consoleRadio.TabIndex = 0;
            this.consoleRadio.TabStop = true;
            this.consoleRadio.Text = "Консоль";
            this.consoleRadio.UseVisualStyleBackColor = true;
            this.consoleRadio.CheckedChanged += new System.EventHandler(this.consoleRadio_CheckedChanged);
            // 
            // newCfgLabel
            // 
            this.newCfgLabel.AutoSize = true;
            this.newCfgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newCfgLabel.ForeColor = System.Drawing.Color.Indigo;
            this.newCfgLabel.Location = new System.Drawing.Point(94, 522);
            this.newCfgLabel.Name = "newCfgLabel";
            this.newCfgLabel.Size = new System.Drawing.Size(0, 13);
            this.newCfgLabel.TabIndex = 7;
            this.newCfgLabel.Visible = false;
            // 
            // newCfgText
            // 
            this.newCfgText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newCfgText.ForeColor = System.Drawing.Color.Red;
            this.newCfgText.Location = new System.Drawing.Point(48, 217);
            this.newCfgText.Name = "newCfgText";
            this.newCfgText.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.newCfgText, true);
            this.newCfgText.Size = new System.Drawing.Size(256, 20);
            this.newCfgText.TabIndex = 6;
            this.newCfgText.TabStop = false;
            this.newCfgText.Text = "ДИНРУС КОНСОЛЬ ПОЛНАЯ";
            this.newCfgText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.newCfgText.Visible = false;
            this.newCfgText.WordWrap = false;
            this.newCfgText.TextChanged += new System.EventHandler(this.newCfgText_TextChanged);
            // 
            // versionCombo
            // 
            this.versionCombo.AutoCompleteCustomSource.AddRange(new string[] {
            "ДИНРУС",
            "РУЛАДА"});
            this.versionCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.versionCombo.ForeColor = System.Drawing.Color.Indigo;
            this.versionCombo.FormattingEnabled = true;
            this.helpProvider1.SetHelpKeyword(this.versionCombo, "Рантайм");
            this.helpProvider1.SetHelpString(this.versionCombo, "Обеспечивает выбор между несколькими вариантами рантайма для компилятора DMD.");
            this.versionCombo.Items.AddRange(new object[] {
            "ДИНРУС",
            "РУЛАДА1",
            "РУЛАДА2"});
            this.versionCombo.Location = new System.Drawing.Point(215, 19);
            this.versionCombo.Name = "versionCombo";
            this.helpProvider1.SetShowHelp(this.versionCombo, true);
            this.versionCombo.Size = new System.Drawing.Size(142, 21);
            this.versionCombo.Sorted = true;
            this.versionCombo.TabIndex = 0;
            this.versionCombo.Text = "ДИНРУС";
            this.versionCombo.SelectedValueChanged += new System.EventHandler(this.versionCombo_SelectedValueChanged);
            // 
            // scIniText
            // 
            this.scIniText.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.scIniText.DetectUrls = false;
            this.scIniText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scIniText.ForeColor = System.Drawing.Color.Indigo;
            this.helpProvider1.SetHelpKeyword(this.scIniText, "sc.ini");
            this.helpProvider1.SetHelpString(this.scIniText, "Отображает текст файла sc.ini, находящегося в папке компилятора. Задаёт пути импо" +
                    "рта и другие для компилятором DMD и DMC.");
            this.scIniText.HideSelection = false;
            this.scIniText.Location = new System.Drawing.Point(0, 5);
            this.scIniText.Name = "scIniText";
            this.scIniText.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.scIniText, true);
            this.scIniText.ShowSelectionMargin = true;
            this.scIniText.Size = new System.Drawing.Size(363, 208);
            this.scIniText.TabIndex = 10;
            this.scIniText.Text = "";
            this.scIniText.TextChanged += new System.EventHandler(this.scIniTextBox_TextChanged);
            // 
            // updateConf
            // 
            this.updateConf.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.updateConf.Enabled = false;
            this.updateConf.ForeColor = System.Drawing.SystemColors.Desktop;
            this.updateConf.Location = new System.Drawing.Point(99, 544);
            this.updateConf.Name = "updateConf";
            this.updateConf.Size = new System.Drawing.Size(147, 23);
            this.updateConf.TabIndex = 11;
            this.updateConf.Text = "Обновить конфигурацию";
            this.updateConf.UseVisualStyleBackColor = false;
            this.updateConf.Visible = false;
            this.updateConf.Click += new System.EventHandler(this.updateConf_Click);
            // 
            // saveScIni
            // 
            this.saveScIni.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.saveScIni.Enabled = false;
            this.saveScIni.ForeColor = System.Drawing.SystemColors.Desktop;
            this.saveScIni.Location = new System.Drawing.Point(99, 231);
            this.saveScIni.Name = "saveScIni";
            this.saveScIni.Size = new System.Drawing.Size(147, 23);
            this.saveScIni.TabIndex = 12;
            this.saveScIni.Text = "Сохранить sc.ini";
            this.saveScIni.UseVisualStyleBackColor = false;
            this.saveScIni.Visible = false;
            this.saveScIni.Click += new System.EventHandler(this.saveScIni_Click);
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.Location = new System.Drawing.Point(23, 43);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(60, 13);
            this.modeLabel.TabIndex = 13;
            this.modeLabel.Text = "КОНСОЛЬ";
            this.modeLabel.Visible = false;
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(23, 12);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(54, 13);
            this.versionLabel.TabIndex = 14;
            this.versionLabel.Text = "ДИНРУС";
            this.versionLabel.Visible = false;
            // 
            // versionParamLabel
            // 
            this.versionParamLabel.AutoSize = true;
            this.versionParamLabel.Location = new System.Drawing.Point(23, 89);
            this.versionParamLabel.Name = "versionParamLabel";
            this.versionParamLabel.Size = new System.Drawing.Size(54, 13);
            this.versionParamLabel.TabIndex = 15;
            this.versionParamLabel.Text = "ПОЛНАЯ";
            this.versionParamLabel.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DSharpIDE.Properties.Resources.dmlogo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 219);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(363, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(180, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "1. Укажите версию рантайма";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "2. Укажите подсистему Windows";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(134, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "3.Укажите включение библиотек";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(267, 219);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(67, 17);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "вручную";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lolGifPB
            // 
            this.lolGifPB.Image = ((System.Drawing.Image)(resources.GetObject("lolGifPB.Image")));
            this.lolGifPB.InitialImage = ((System.Drawing.Image)(resources.GetObject("lolGifPB.InitialImage")));
            this.lolGifPB.Location = new System.Drawing.Point(35, 233);
            this.lolGifPB.Name = "lolGifPB";
            this.lolGifPB.Size = new System.Drawing.Size(25, 21);
            this.lolGifPB.TabIndex = 13;
            this.lolGifPB.TabStop = false;
            this.lolGifPB.Visible = false;
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.closeBtn.ForeColor = System.Drawing.SystemColors.Desktop;
            this.closeBtn.Location = new System.Drawing.Point(99, 544);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(147, 23);
            this.closeBtn.TabIndex = 18;
            this.closeBtn.Text = "Закрыть";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Visible = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // Configurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(369, 570);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.lolGifPB);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.versionParamLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.newCfgLabel);
            this.Controls.Add(this.scIniText);
            this.Controls.Add(this.modeLabel);
            this.Controls.Add(this.saveScIni);
            this.Controls.Add(this.updateConf);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.helpProvider1.SetHelpKeyword(this, "Конфигурация");
            this.helpProvider1.SetHelpString(this, "Оконце установки конфигурации для компиляторов Си и Ди (изменением содержания фай" +
                    "ла sc.ini). Кроме того, автоматически происходит смена библиотек и файлов импорт" +
                    "а.");
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Configurator";
            this.helpProvider1.SetShowHelp(this, true);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Изменение параметров конфигурации Динрус";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Configurator_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.configuratorClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lolGifPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox versionCombo;
        private System.Windows.Forms.Label newCfgLabel;
        private System.Windows.Forms.TextBox newCfgText;
        private System.Windows.Forms.RichTextBox scIniText;
        private System.Windows.Forms.Button updateConf;
        private System.Windows.Forms.Button saveScIni;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton windowRadio;
        private System.Windows.Forms.RadioButton consoleRadio;
        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label versionParamLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox lolGifPB;
        private System.Windows.Forms.Button closeBtn;
    }
}