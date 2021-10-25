
namespace NewUi.View
{
    partial class CreateOrChangeTestProgram
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
            this.btnResetModul = new System.Windows.Forms.Button();
            this.btnDelModul = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpModul = new System.Windows.Forms.Button();
            this.btnDownModul = new System.Windows.Forms.Button();
            this.gBoxModul = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rBtnCycleMin = new System.Windows.Forms.NumericUpDown();
            this.numUpDelayBetwenMesaureMin = new System.Windows.Forms.NumericUpDown();
            this.rBtnCycleHour = new System.Windows.Forms.NumericUpDown();
            this.numUpDelayBetwenMesaureSec = new System.Windows.Forms.NumericUpDown();
            this.rBtnCycle = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.numUpSetTemperature = new System.Windows.Forms.NumericUpDown();
            this.rBtnDelayBetwenMesaure = new System.Windows.Forms.RadioButton();
            this.rBtnParamMeasureVoltage = new System.Windows.Forms.RadioButton();
            this.rBtnSetTemperature = new System.Windows.Forms.RadioButton();
            this.rBtnSupplyOn = new System.Windows.Forms.RadioButton();
            this.rBtnContactCheck = new System.Windows.Forms.RadioButton();
            this.gBoxCreateOrChangeTestProgram = new System.Windows.Forms.GroupBox();
            this.gridModulList = new System.Windows.Forms.DataGridView();
            this.modul = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddModul = new System.Windows.Forms.Button();
            this.gBoxTestProgramList = new System.Windows.Forms.GroupBox();
            this.btnChangeTestProgram = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddTestProgram = new System.Windows.Forms.Button();
            this.btnDelTestProgram = new System.Windows.Forms.Button();
            this.rTbTestProgramList = new System.Windows.Forms.RichTextBox();
            this.rBtnSupplyOff = new System.Windows.Forms.RadioButton();
            this.gBoxModul.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnCycleMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDelayBetwenMesaureMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnCycleHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDelayBetwenMesaureSec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpSetTemperature)).BeginInit();
            this.gBoxCreateOrChangeTestProgram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridModulList)).BeginInit();
            this.gBoxTestProgramList.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnResetModul
            // 
            this.btnResetModul.Location = new System.Drawing.Point(88, 348);
            this.btnResetModul.Name = "btnResetModul";
            this.btnResetModul.Size = new System.Drawing.Size(70, 23);
            this.btnResetModul.TabIndex = 0;
            this.btnResetModul.Text = "Сбросить";
            this.btnResetModul.UseVisualStyleBackColor = true;
            // 
            // btnDelModul
            // 
            this.btnDelModul.Location = new System.Drawing.Point(169, 348);
            this.btnDelModul.Name = "btnDelModul";
            this.btnDelModul.Size = new System.Drawing.Size(70, 23);
            this.btnDelModul.TabIndex = 1;
            this.btnDelModul.Text = "Удалить";
            this.btnDelModul.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Набор модулей входящих в программу";
            // 
            // btnUpModul
            // 
            this.btnUpModul.Location = new System.Drawing.Point(245, 160);
            this.btnUpModul.Name = "btnUpModul";
            this.btnUpModul.Size = new System.Drawing.Size(22, 23);
            this.btnUpModul.TabIndex = 7;
            this.btnUpModul.Text = "↑";
            this.btnUpModul.UseVisualStyleBackColor = true;
            // 
            // btnDownModul
            // 
            this.btnDownModul.Location = new System.Drawing.Point(245, 189);
            this.btnDownModul.Name = "btnDownModul";
            this.btnDownModul.Size = new System.Drawing.Size(22, 23);
            this.btnDownModul.TabIndex = 8;
            this.btnDownModul.Text = "↓";
            this.btnDownModul.UseVisualStyleBackColor = true;
            // 
            // gBoxModul
            // 
            this.gBoxModul.Controls.Add(this.rBtnSupplyOff);
            this.gBoxModul.Controls.Add(this.label8);
            this.gBoxModul.Controls.Add(this.label7);
            this.gBoxModul.Controls.Add(this.label6);
            this.gBoxModul.Controls.Add(this.label5);
            this.gBoxModul.Controls.Add(this.rBtnCycleMin);
            this.gBoxModul.Controls.Add(this.numUpDelayBetwenMesaureMin);
            this.gBoxModul.Controls.Add(this.rBtnCycleHour);
            this.gBoxModul.Controls.Add(this.numUpDelayBetwenMesaureSec);
            this.gBoxModul.Controls.Add(this.rBtnCycle);
            this.gBoxModul.Controls.Add(this.label4);
            this.gBoxModul.Controls.Add(this.numUpSetTemperature);
            this.gBoxModul.Controls.Add(this.rBtnDelayBetwenMesaure);
            this.gBoxModul.Controls.Add(this.rBtnParamMeasureVoltage);
            this.gBoxModul.Controls.Add(this.rBtnSetTemperature);
            this.gBoxModul.Controls.Add(this.rBtnSupplyOn);
            this.gBoxModul.Controls.Add(this.rBtnContactCheck);
            this.gBoxModul.Location = new System.Drawing.Point(574, 12);
            this.gBoxModul.Name = "gBoxModul";
            this.gBoxModul.Size = new System.Drawing.Size(420, 380);
            this.gBoxModul.TabIndex = 10;
            this.gBoxModul.TabStop = false;
            this.gBoxModul.Text = "Модули";
            this.gBoxModul.Enter += new System.EventHandler(this.gBoxModul_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(384, 294);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 15);
            this.label8.TabIndex = 26;
            this.label8.Text = "Мин";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(288, 294);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 15);
            this.label7.TabIndex = 25;
            this.label7.Text = "Час";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(384, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 15);
            this.label6.TabIndex = 24;
            this.label6.Text = "Сек";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(285, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "Мин";
            // 
            // rBtnCycleMin
            // 
            this.rBtnCycleMin.Location = new System.Drawing.Point(323, 290);
            this.rBtnCycleMin.Name = "rBtnCycleMin";
            this.rBtnCycleMin.Size = new System.Drawing.Size(55, 23);
            this.rBtnCycleMin.TabIndex = 22;
            // 
            // numUpDelayBetwenMesaureMin
            // 
            this.numUpDelayBetwenMesaureMin.Location = new System.Drawing.Point(224, 240);
            this.numUpDelayBetwenMesaureMin.Name = "numUpDelayBetwenMesaureMin";
            this.numUpDelayBetwenMesaureMin.Size = new System.Drawing.Size(55, 23);
            this.numUpDelayBetwenMesaureMin.TabIndex = 21;
            // 
            // rBtnCycleHour
            // 
            this.rBtnCycleHour.Location = new System.Drawing.Point(224, 290);
            this.rBtnCycleHour.Name = "rBtnCycleHour";
            this.rBtnCycleHour.Size = new System.Drawing.Size(55, 23);
            this.rBtnCycleHour.TabIndex = 20;
            // 
            // numUpDelayBetwenMesaureSec
            // 
            this.numUpDelayBetwenMesaureSec.Location = new System.Drawing.Point(323, 240);
            this.numUpDelayBetwenMesaureSec.Name = "numUpDelayBetwenMesaureSec";
            this.numUpDelayBetwenMesaureSec.Size = new System.Drawing.Size(55, 23);
            this.numUpDelayBetwenMesaureSec.TabIndex = 18;
            // 
            // rBtnCycle
            // 
            this.rBtnCycle.AutoSize = true;
            this.rBtnCycle.Location = new System.Drawing.Point(21, 290);
            this.rBtnCycle.Name = "rBtnCycle";
            this.rBtnCycle.Size = new System.Drawing.Size(54, 19);
            this.rBtnCycle.TabIndex = 17;
            this.rBtnCycle.TabStop = true;
            this.rBtnCycle.Text = "Цикл";
            this.rBtnCycle.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(285, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "°C\t";
            // 
            // numUpSetTemperature
            // 
            this.numUpSetTemperature.Location = new System.Drawing.Point(224, 198);
            this.numUpSetTemperature.Name = "numUpSetTemperature";
            this.numUpSetTemperature.Size = new System.Drawing.Size(55, 23);
            this.numUpSetTemperature.TabIndex = 15;
            // 
            // rBtnDelayBetwenMesaure
            // 
            this.rBtnDelayBetwenMesaure.AutoSize = true;
            this.rBtnDelayBetwenMesaure.Location = new System.Drawing.Point(21, 240);
            this.rBtnDelayBetwenMesaure.Name = "rBtnDelayBetwenMesaure";
            this.rBtnDelayBetwenMesaure.Size = new System.Drawing.Size(196, 19);
            this.rBtnDelayBetwenMesaure.TabIndex = 14;
            this.rBtnDelayBetwenMesaure.TabStop = true;
            this.rBtnDelayBetwenMesaure.Text = "Задержка между измерениями";
            this.rBtnDelayBetwenMesaure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rBtnDelayBetwenMesaure.UseVisualStyleBackColor = true;
            // 
            // rBtnParamMeasureVoltage
            // 
            this.rBtnParamMeasureVoltage.AutoSize = true;
            this.rBtnParamMeasureVoltage.Location = new System.Drawing.Point(20, 151);
            this.rBtnParamMeasureVoltage.Name = "rBtnParamMeasureVoltage";
            this.rBtnParamMeasureVoltage.Size = new System.Drawing.Size(200, 19);
            this.rBtnParamMeasureVoltage.TabIndex = 13;
            this.rBtnParamMeasureVoltage.TabStop = true;
            this.rBtnParamMeasureVoltage.Text = "Замер параметров напряжения";
            this.rBtnParamMeasureVoltage.UseVisualStyleBackColor = true;
            // 
            // rBtnSetTemperature
            // 
            this.rBtnSetTemperature.AutoSize = true;
            this.rBtnSetTemperature.Location = new System.Drawing.Point(21, 198);
            this.rBtnSetTemperature.Name = "rBtnSetTemperature";
            this.rBtnSetTemperature.Size = new System.Drawing.Size(157, 19);
            this.rBtnSetTemperature.TabIndex = 12;
            this.rBtnSetTemperature.TabStop = true;
            this.rBtnSetTemperature.Text = "Установка температуры";
            this.rBtnSetTemperature.UseVisualStyleBackColor = true;
            // 
            // rBtnSupplyOn
            // 
            this.rBtnSupplyOn.AutoSize = true;
            this.rBtnSupplyOn.Location = new System.Drawing.Point(20, 77);
            this.rBtnSupplyOn.Name = "rBtnSupplyOn";
            this.rBtnSupplyOn.Size = new System.Drawing.Size(149, 19);
            this.rBtnSupplyOn.TabIndex = 11;
            this.rBtnSupplyOn.TabStop = true;
            this.rBtnSupplyOn.Text = "Включение источника";
            this.rBtnSupplyOn.UseVisualStyleBackColor = true;
            // 
            // rBtnContactCheck
            // 
            this.rBtnContactCheck.AutoSize = true;
            this.rBtnContactCheck.Location = new System.Drawing.Point(20, 41);
            this.rBtnContactCheck.Name = "rBtnContactCheck";
            this.rBtnContactCheck.Size = new System.Drawing.Size(177, 19);
            this.rBtnContactCheck.TabIndex = 10;
            this.rBtnContactCheck.TabStop = true;
            this.rBtnContactCheck.Text = "Проверка контактирования";
            this.rBtnContactCheck.UseVisualStyleBackColor = true;
            // 
            // gBoxCreateOrChangeTestProgram
            // 
            this.gBoxCreateOrChangeTestProgram.Controls.Add(this.gridModulList);
            this.gBoxCreateOrChangeTestProgram.Controls.Add(this.btnAddModul);
            this.gBoxCreateOrChangeTestProgram.Controls.Add(this.btnResetModul);
            this.gBoxCreateOrChangeTestProgram.Controls.Add(this.btnDelModul);
            this.gBoxCreateOrChangeTestProgram.Controls.Add(this.btnDownModul);
            this.gBoxCreateOrChangeTestProgram.Controls.Add(this.btnUpModul);
            this.gBoxCreateOrChangeTestProgram.Controls.Add(this.label2);
            this.gBoxCreateOrChangeTestProgram.Location = new System.Drawing.Point(293, 12);
            this.gBoxCreateOrChangeTestProgram.Name = "gBoxCreateOrChangeTestProgram";
            this.gBoxCreateOrChangeTestProgram.Size = new System.Drawing.Size(275, 380);
            this.gBoxCreateOrChangeTestProgram.TabIndex = 11;
            this.gBoxCreateOrChangeTestProgram.TabStop = false;
            this.gBoxCreateOrChangeTestProgram.Text = "Создание/изменение программы испытания";
            // 
            // gridModulList
            // 
            this.gridModulList.AllowUserToAddRows = false;
            this.gridModulList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridModulList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridModulList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.modul,
            this.unit});
            this.gridModulList.Location = new System.Drawing.Point(7, 54);
            this.gridModulList.Name = "gridModulList";
            this.gridModulList.ReadOnly = true;
            this.gridModulList.RowHeadersVisible = false;
            this.gridModulList.RowTemplate.Height = 25;
            this.gridModulList.Size = new System.Drawing.Size(232, 288);
            this.gridModulList.TabIndex = 10;
            // 
            // modul
            // 
            this.modul.HeaderText = "Модуль";
            this.modul.Name = "modul";
            this.modul.ReadOnly = true;
            // 
            // unit
            // 
            this.unit.HeaderText = "Ед. измерения";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            // 
            // btnAddModul
            // 
            this.btnAddModul.Location = new System.Drawing.Point(6, 348);
            this.btnAddModul.Name = "btnAddModul";
            this.btnAddModul.Size = new System.Drawing.Size(70, 23);
            this.btnAddModul.TabIndex = 9;
            this.btnAddModul.Text = "Добавить";
            this.btnAddModul.UseVisualStyleBackColor = true;
            this.btnAddModul.Click += new System.EventHandler(this.btnAddModul_Click);
            // 
            // gBoxTestProgramList
            // 
            this.gBoxTestProgramList.Controls.Add(this.btnChangeTestProgram);
            this.gBoxTestProgramList.Controls.Add(this.label1);
            this.gBoxTestProgramList.Controls.Add(this.btnAddTestProgram);
            this.gBoxTestProgramList.Controls.Add(this.btnDelTestProgram);
            this.gBoxTestProgramList.Controls.Add(this.rTbTestProgramList);
            this.gBoxTestProgramList.Location = new System.Drawing.Point(12, 12);
            this.gBoxTestProgramList.Name = "gBoxTestProgramList";
            this.gBoxTestProgramList.Size = new System.Drawing.Size(275, 380);
            this.gBoxTestProgramList.TabIndex = 13;
            this.gBoxTestProgramList.TabStop = false;
            this.gBoxTestProgramList.Text = "Выбор программы испытания";
            // 
            // btnChangeTestProgram
            // 
            this.btnChangeTestProgram.Location = new System.Drawing.Point(105, 348);
            this.btnChangeTestProgram.Name = "btnChangeTestProgram";
            this.btnChangeTestProgram.Size = new System.Drawing.Size(70, 23);
            this.btnChangeTestProgram.TabIndex = 13;
            this.btnChangeTestProgram.Text = "Изменить";
            this.btnChangeTestProgram.UseVisualStyleBackColor = true;
            this.btnChangeTestProgram.Click += new System.EventHandler(this.btnChangeTestProgram_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Набор программ испытаний";
            // 
            // btnAddTestProgram
            // 
            this.btnAddTestProgram.Location = new System.Drawing.Point(12, 348);
            this.btnAddTestProgram.Name = "btnAddTestProgram";
            this.btnAddTestProgram.Size = new System.Drawing.Size(70, 23);
            this.btnAddTestProgram.TabIndex = 12;
            this.btnAddTestProgram.Text = "Добавить";
            this.btnAddTestProgram.UseVisualStyleBackColor = true;
            this.btnAddTestProgram.Click += new System.EventHandler(this.btnAddTestProgram_Click);
            // 
            // btnDelTestProgram
            // 
            this.btnDelTestProgram.Location = new System.Drawing.Point(194, 348);
            this.btnDelTestProgram.Name = "btnDelTestProgram";
            this.btnDelTestProgram.Size = new System.Drawing.Size(70, 23);
            this.btnDelTestProgram.TabIndex = 11;
            this.btnDelTestProgram.Text = "Удалить";
            this.btnDelTestProgram.UseVisualStyleBackColor = true;
            // 
            // rTbTestProgramList
            // 
            this.rTbTestProgramList.Location = new System.Drawing.Point(12, 54);
            this.rTbTestProgramList.Name = "rTbTestProgramList";
            this.rTbTestProgramList.Size = new System.Drawing.Size(252, 288);
            this.rTbTestProgramList.TabIndex = 0;
            this.rTbTestProgramList.Text = "";
            // 
            // rBtnSupplyOff
            // 
            this.rBtnSupplyOff.AutoSize = true;
            this.rBtnSupplyOff.Location = new System.Drawing.Point(21, 115);
            this.rBtnSupplyOff.Name = "rBtnSupplyOff";
            this.rBtnSupplyOff.Size = new System.Drawing.Size(158, 19);
            this.rBtnSupplyOff.TabIndex = 27;
            this.rBtnSupplyOff.TabStop = true;
            this.rBtnSupplyOff.Text = "Выключение источника";
            this.rBtnSupplyOff.UseVisualStyleBackColor = true;
            // 
            // CreateOrChangeTestProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 396);
            this.Controls.Add(this.gBoxTestProgramList);
            this.Controls.Add(this.gBoxCreateOrChangeTestProgram);
            this.Controls.Add(this.gBoxModul);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateOrChangeTestProgram";
            this.Text = "CreateTestProgram";
            this.Load += new System.EventHandler(this.CreateTestProgram_Load);
            this.gBoxModul.ResumeLayout(false);
            this.gBoxModul.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnCycleMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDelayBetwenMesaureMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBtnCycleHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDelayBetwenMesaureSec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpSetTemperature)).EndInit();
            this.gBoxCreateOrChangeTestProgram.ResumeLayout(false);
            this.gBoxCreateOrChangeTestProgram.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridModulList)).EndInit();
            this.gBoxTestProgramList.ResumeLayout(false);
            this.gBoxTestProgramList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnResetModul;
        private System.Windows.Forms.Button btnDelModul;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpModul;
        private System.Windows.Forms.Button btnDownModul;
        private System.Windows.Forms.GroupBox gBoxModul;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown rBtnCycleMin;
        private System.Windows.Forms.NumericUpDown numUpDelayBetwenMesaureMin;
        private System.Windows.Forms.NumericUpDown rBtnCycleHour;
        private System.Windows.Forms.NumericUpDown numUpDelayBetwenMesaureSec;
        private System.Windows.Forms.RadioButton rBtnCycle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numUpSetTemperature;
        private System.Windows.Forms.RadioButton rBtnDelayBetwenMesaure;
        private System.Windows.Forms.RadioButton rBtnParamMeasureVoltage;
        private System.Windows.Forms.RadioButton rBtnSetTemperature;
        private System.Windows.Forms.RadioButton rBtnSupplyOn;
        private System.Windows.Forms.RadioButton rBtnContactCheck;
        private System.Windows.Forms.GroupBox gBoxCreateOrChangeTestProgram;
        private System.Windows.Forms.Button btnAddModul;
        private System.Windows.Forms.DataGridView gridModulList;
        private System.Windows.Forms.GroupBox gBoxTestProgramList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddTestProgram;
        private System.Windows.Forms.Button btnDelTestProgram;
        private System.Windows.Forms.RichTextBox rTbTestProgramList;
        private System.Windows.Forms.DataGridViewTextBoxColumn modul;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.Button btnChangeTestProgram;
        private System.Windows.Forms.RadioButton rBtnSupplyOff;
    }
}