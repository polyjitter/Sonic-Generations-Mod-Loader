namespace SLWModLoader
{
    partial class EditPropertyFrm
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
            this.nameLbl = new System.Windows.Forms.Label();
            this.nameTxtbx = new System.Windows.Forms.TextBox();
            this.valueLbl = new System.Windows.Forms.Label();
            this.valueCombobx = new System.Windows.Forms.ComboBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.typeCombobx = new System.Windows.Forms.ComboBox();
            this.typeLbl = new System.Windows.Forms.Label();
            this.valueNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupCombobx = new System.Windows.Forms.ComboBox();
            this.groupLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.valueNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.nameLbl.Location = new System.Drawing.Point(8, 6);
            this.nameLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(39, 13);
            this.nameLbl.TabIndex = 0;
            this.nameLbl.Text = "Name:";
            // 
            // nameTxtbx
            // 
            this.nameTxtbx.Location = new System.Drawing.Point(49, 5);
            this.nameTxtbx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nameTxtbx.Name = "nameTxtbx";
            this.nameTxtbx.Size = new System.Drawing.Size(211, 20);
            this.nameTxtbx.TabIndex = 1;
            // 
            // valueLbl
            // 
            this.valueLbl.AutoSize = true;
            this.valueLbl.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.valueLbl.Location = new System.Drawing.Point(8, 104);
            this.valueLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.valueLbl.Name = "valueLbl";
            this.valueLbl.Size = new System.Drawing.Size(38, 13);
            this.valueLbl.TabIndex = 2;
            this.valueLbl.Text = "Value:";
            // 
            // valueCombobx
            // 
            this.valueCombobx.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.valueCombobx.FormattingEnabled = true;
            this.valueCombobx.Location = new System.Drawing.Point(49, 103);
            this.valueCombobx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.valueCombobx.Name = "valueCombobx";
            this.valueCombobx.Size = new System.Drawing.Size(211, 21);
            this.valueCombobx.TabIndex = 3;
            // 
            // okBtn
            // 
            this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.okBtn.Location = new System.Drawing.Point(196, 133);
            this.okBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(63, 23);
            this.okBtn.TabIndex = 4;
            this.okBtn.Text = "&OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // typeCombobx
            // 
            this.typeCombobx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeCombobx.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.typeCombobx.FormattingEnabled = true;
            this.typeCombobx.Items.AddRange(new object[] {
            "String",
            "Integer",
            "Boolean"});
            this.typeCombobx.Location = new System.Drawing.Point(49, 70);
            this.typeCombobx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.typeCombobx.Name = "typeCombobx";
            this.typeCombobx.Size = new System.Drawing.Size(211, 21);
            this.typeCombobx.TabIndex = 6;
            this.typeCombobx.SelectedIndexChanged += new System.EventHandler(this.typeCombobx_SelectedIndexChanged);
            // 
            // typeLbl
            // 
            this.typeLbl.AutoSize = true;
            this.typeLbl.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.typeLbl.Location = new System.Drawing.Point(8, 71);
            this.typeLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.typeLbl.Name = "typeLbl";
            this.typeLbl.Size = new System.Drawing.Size(32, 13);
            this.typeLbl.TabIndex = 5;
            this.typeLbl.Text = "Type:";
            // 
            // valueNumericUpDown
            // 
            this.valueNumericUpDown.Location = new System.Drawing.Point(49, 103);
            this.valueNumericUpDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.valueNumericUpDown.Name = "valueNumericUpDown";
            this.valueNumericUpDown.Size = new System.Drawing.Size(210, 20);
            this.valueNumericUpDown.TabIndex = 7;
            this.valueNumericUpDown.Visible = false;
            // 
            // groupCombobx
            // 
            this.groupCombobx.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupCombobx.FormattingEnabled = true;
            this.groupCombobx.Location = new System.Drawing.Point(49, 36);
            this.groupCombobx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupCombobx.Name = "groupCombobx";
            this.groupCombobx.Size = new System.Drawing.Size(211, 21);
            this.groupCombobx.TabIndex = 9;
            this.groupCombobx.Text = "Desc";
            // 
            // groupLbl
            // 
            this.groupLbl.AutoSize = true;
            this.groupLbl.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.groupLbl.Location = new System.Drawing.Point(8, 38);
            this.groupLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.groupLbl.Name = "groupLbl";
            this.groupLbl.Size = new System.Drawing.Size(43, 13);
            this.groupLbl.TabIndex = 8;
            this.groupLbl.Text = "Group:";
            // 
            // EditPropertyFrm
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(267, 164);
            this.Controls.Add(this.groupCombobx);
            this.Controls.Add(this.groupLbl);
            this.Controls.Add(this.valueNumericUpDown);
            this.Controls.Add(this.typeCombobx);
            this.Controls.Add(this.typeLbl);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.valueCombobx);
            this.Controls.Add(this.valueLbl);
            this.Controls.Add(this.nameTxtbx);
            this.Controls.Add(this.nameLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditPropertyFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sonic Generations Mod Loader";
            ((System.ComponentModel.ISupportInitialize)(this.valueNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Label valueLbl;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label typeLbl;
        public System.Windows.Forms.TextBox nameTxtbx;
        public System.Windows.Forms.ComboBox valueCombobx;
        public System.Windows.Forms.ComboBox typeCombobx;
        public System.Windows.Forms.NumericUpDown valueNumericUpDown;
        public System.Windows.Forms.ComboBox groupCombobx;
        private System.Windows.Forms.Label groupLbl;
    }
}