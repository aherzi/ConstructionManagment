namespace ConstructionAppClient
{
    partial class SiteEntryForm
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
            this.txtSiteName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.numOwnerId = new System.Windows.Forms.NumericUpDown();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.numContractorId = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.btnPhases = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numOwnerId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContractorId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Site name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Owner ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Contractor ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Start date";
            // 
            // txtSiteName
            // 
            this.txtSiteName.Location = new System.Drawing.Point(160, 17);
            this.txtSiteName.Name = "txtSiteName";
            this.txtSiteName.Size = new System.Drawing.Size(207, 31);
            this.txtSiteName.TabIndex = 5;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(160, 52);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(207, 31);
            this.txtAddress.TabIndex = 6;
            // 
            // numOwnerId
            // 
            this.numOwnerId.Location = new System.Drawing.Point(160, 87);
            this.numOwnerId.Name = "numOwnerId";
            this.numOwnerId.Size = new System.Drawing.Size(120, 31);
            this.numOwnerId.TabIndex = 7;
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(160, 157);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 31);
            this.dtpStart.TabIndex = 8;
            // 
            // numContractorId
            // 
            this.numContractorId.Location = new System.Drawing.Point(160, 122);
            this.numContractorId.Name = "numContractorId";
            this.numContractorId.Size = new System.Drawing.Size(120, 31);
            this.numContractorId.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(160, 195);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 42);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(25, 286);
            this.grid.Name = "grid";
            this.grid.RowHeadersWidth = 82;
            this.grid.RowTemplate.Height = 33;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(824, 362);
            this.grid.TabIndex = 11;
            // 
            // btnPhases
            // 
            this.btnPhases.Location = new System.Drawing.Point(280, 195);
            this.btnPhases.Name = "btnPhases";
            this.btnPhases.Size = new System.Drawing.Size(184, 42);
            this.btnPhases.TabIndex = 12;
            this.btnPhases.Text = "Manage Phases";
            this.btnPhases.UseVisualStyleBackColor = true;
            // 
            // btnDashboard
            // 
            this.btnDashboard.Location = new System.Drawing.Point(536, 195);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(152, 42);
            this.btnDashboard.TabIndex = 13;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = true;
            // 
            // SiteEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 677);
            this.Controls.Add(this.btnDashboard);
            this.Controls.Add(this.btnPhases);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numContractorId);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.numOwnerId);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtSiteName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "SiteEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Construction Sites";
            this.Load += new System.EventHandler(this.SiteEntryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numOwnerId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContractorId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSiteName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.NumericUpDown numOwnerId;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.NumericUpDown numContractorId;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnPhases;
        private System.Windows.Forms.Button btnDashboard;
    }
}