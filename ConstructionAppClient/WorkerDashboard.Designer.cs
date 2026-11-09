namespace ConstructionAppClient
{
    partial class WorkerDashboard
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSubmitProgressUpdate = new System.Windows.Forms.Button();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(28, 37);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(288, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Worker Dashboard";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(47, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(656, 265);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnSubmitProgressUpdate
            // 
            this.btnSubmitProgressUpdate.Location = new System.Drawing.Point(93, 438);
            this.btnSubmitProgressUpdate.Name = "btnSubmitProgressUpdate";
            this.btnSubmitProgressUpdate.Size = new System.Drawing.Size(188, 60);
            this.btnSubmitProgressUpdate.TabIndex = 2;
            this.btnSubmitProgressUpdate.Text = "Submit Progress Update";
            this.btnSubmitProgressUpdate.UseVisualStyleBackColor = true;
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Location = new System.Drawing.Point(438, 438);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(188, 60);
            this.btnUpdateStatus.TabIndex = 3;
            this.btnUpdateStatus.Text = "View Update Status";
            this.btnUpdateStatus.UseVisualStyleBackColor = true;
            // 
            // WorkerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 705);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.btnSubmitProgressUpdate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblTitle);
            this.Name = "WorkerDashboard";
            this.Text = "WorkerDashboard";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSubmitProgressUpdate;
        private System.Windows.Forms.Button btnUpdateStatus;
    }
}