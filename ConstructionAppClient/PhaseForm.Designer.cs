namespace ConstructionAppClient
{
    partial class PhaseForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSite = new System.Windows.Forms.ComboBox();
            this.cmbStage = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dtpPlannedStart = new System.Windows.Forms.DateTimePicker();
            this.dtpPlannedEnd = new System.Windows.Forms.DateTimePicker();
            this.numPercent = new System.Windows.Forms.NumericUpDown();
            this.btnAddPhase = new System.Windows.Forms.Button();
            this.btnUpdatePhase = new System.Windows.Forms.Button();
            this.gridPhases = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.numPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPhases)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Site";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Stage";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Planned Start";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Planned end";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "% complete";
            // 
            // cmbSite
            // 
            this.cmbSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSite.FormattingEnabled = true;
            this.cmbSite.Location = new System.Drawing.Point(168, 17);
            this.cmbSite.Name = "cmbSite";
            this.cmbSite.Size = new System.Drawing.Size(239, 33);
            this.cmbSite.TabIndex = 6;
            // 
            // cmbStage
            // 
            this.cmbStage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStage.FormattingEnabled = true;
            this.cmbStage.Location = new System.Drawing.Point(168, 52);
            this.cmbStage.Name = "cmbStage";
            this.cmbStage.Size = new System.Drawing.Size(239, 33);
            this.cmbStage.TabIndex = 7;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(168, 87);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(239, 60);
            this.txtDescription.TabIndex = 8;
            // 
            // dtpPlannedStart
            // 
            this.dtpPlannedStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPlannedStart.Location = new System.Drawing.Point(168, 150);
            this.dtpPlannedStart.Name = "dtpPlannedStart";
            this.dtpPlannedStart.Size = new System.Drawing.Size(239, 31);
            this.dtpPlannedStart.TabIndex = 9;
            // 
            // dtpPlannedEnd
            // 
            this.dtpPlannedEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPlannedEnd.Location = new System.Drawing.Point(168, 185);
            this.dtpPlannedEnd.Name = "dtpPlannedEnd";
            this.dtpPlannedEnd.Size = new System.Drawing.Size(239, 31);
            this.dtpPlannedEnd.TabIndex = 10;
            // 
            // numPercent
            // 
            this.numPercent.Location = new System.Drawing.Point(168, 216);
            this.numPercent.Name = "numPercent";
            this.numPercent.Size = new System.Drawing.Size(239, 31);
            this.numPercent.TabIndex = 11;
            // 
            // btnAddPhase
            // 
            this.btnAddPhase.Location = new System.Drawing.Point(140, 260);
            this.btnAddPhase.Name = "btnAddPhase";
            this.btnAddPhase.Size = new System.Drawing.Size(120, 44);
            this.btnAddPhase.TabIndex = 12;
            this.btnAddPhase.Text = "Add Phase";
            this.btnAddPhase.UseVisualStyleBackColor = true;
            // 
            // btnUpdatePhase
            // 
            this.btnUpdatePhase.Location = new System.Drawing.Point(270, 260);
            this.btnUpdatePhase.Name = "btnUpdatePhase";
            this.btnUpdatePhase.Size = new System.Drawing.Size(140, 44);
            this.btnUpdatePhase.TabIndex = 13;
            this.btnUpdatePhase.Text = "Update Selected";
            this.btnUpdatePhase.UseVisualStyleBackColor = true;
            // 
            // gridPhases
            // 
            this.gridPhases.AllowUserToAddRows = false;
            this.gridPhases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPhases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPhases.Location = new System.Drawing.Point(25, 336);
            this.gridPhases.MultiSelect = false;
            this.gridPhases.Name = "gridPhases";
            this.gridPhases.ReadOnly = true;
            this.gridPhases.RowHeadersWidth = 82;
            this.gridPhases.RowTemplate.Height = 33;
            this.gridPhases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPhases.Size = new System.Drawing.Size(896, 371);
            this.gridPhases.TabIndex = 14;
            // 
            // PhaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 731);
            this.Controls.Add(this.gridPhases);
            this.Controls.Add(this.btnUpdatePhase);
            this.Controls.Add(this.btnAddPhase);
            this.Controls.Add(this.numPercent);
            this.Controls.Add(this.dtpPlannedEnd);
            this.Controls.Add(this.dtpPlannedStart);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.cmbStage);
            this.Controls.Add(this.cmbSite);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PhaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Phases";
            ((System.ComponentModel.ISupportInitialize)(this.numPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPhases)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSite;
        private System.Windows.Forms.ComboBox cmbStage;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DateTimePicker dtpPlannedStart;
        private System.Windows.Forms.DateTimePicker dtpPlannedEnd;
        private System.Windows.Forms.NumericUpDown numPercent;
        private System.Windows.Forms.Button btnAddPhase;
        private System.Windows.Forms.Button btnUpdatePhase;
        private System.Windows.Forms.DataGridView gridPhases;
    }
}