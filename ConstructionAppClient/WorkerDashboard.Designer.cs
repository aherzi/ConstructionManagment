namespace ConstructionAppClient
{
    partial class WorkerDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlPages = new System.Windows.Forms.Panel();
            this.pnlSubmitUpdates = new System.Windows.Forms.Panel();
            this.lblSubmitUpdatesTitle = new System.Windows.Forms.Label();
            this.lblSubmitUpdatesSubtitle = new System.Windows.Forms.Label();
            this.lblUpdateSite = new System.Windows.Forms.Label();
            this.cboxUpdateSite = new System.Windows.Forms.ComboBox();
            this.lblUpdateDescription = new System.Windows.Forms.Label();
            this.txtUpdateDescription = new System.Windows.Forms.TextBox();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.tblSummary = new System.Windows.Forms.TableLayoutPanel();
            this.pnlAssignedSites = new System.Windows.Forms.Panel();
            this.lblAssignedSitesValue = new System.Windows.Forms.Label();
            this.lblAssignedSites = new System.Windows.Forms.Label();
            this.pnlPendingUpdates = new System.Windows.Forms.Panel();
            this.lblPendingUpdatesValue = new System.Windows.Forms.Label();
            this.lblPendingUpdates = new System.Windows.Forms.Label();
            this.pnlActiveTasks = new System.Windows.Forms.Panel();
            this.lblActiveTasksValue = new System.Windows.Forms.Label();
            this.lblActiveTasks = new System.Windows.Forms.Label();
            this.pnlCompletedTasks = new System.Windows.Forms.Panel();
            this.lblCompletedTasksValue = new System.Windows.Forms.Label();
            this.lblCompletedTasks = new System.Windows.Forms.Label();
            this.lblAssignments = new System.Windows.Forms.Label();
            this.btnSubmitProgressUpdate = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentPhase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSelectionHint = new System.Windows.Forms.Label();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.pnlMyUpdates = new System.Windows.Forms.Panel();
            this.lblMyUpdatesTitle = new System.Windows.Forms.Label();
            this.lblMyUpdatesSubtitle = new System.Windows.Forms.Label();
            this.dgvMyUpdates = new System.Windows.Forms.DataGridView();
            this.colUpdateSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdateDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdateStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblUpdateHistoryAvailability = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblPortal = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnSubmitUpdates = new System.Windows.Forms.Button();
            this.btnMyUpdates = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.lblUploadPicture = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnUpload = new System.Windows.Forms.Button();
            this.lblConstructionPhase = new System.Windows.Forms.Label();
            this.cboxPhases = new System.Windows.Forms.ComboBox();
            this.btnSubmitUpdate = new System.Windows.Forms.Button();
            this.pboxPhoto = new System.Windows.Forms.PictureBox();
            this.pnlPages.SuspendLayout();
            this.pnlSubmitUpdates.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.tblSummary.SuspendLayout();
            this.pnlAssignedSites.SuspendLayout();
            this.pnlPendingUpdates.SuspendLayout();
            this.pnlActiveTasks.SuspendLayout();
            this.pnlCompletedTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlMyUpdates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyUpdates)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPages
            // 
            this.pnlPages.Controls.Add(this.pnlSubmitUpdates);
            this.pnlPages.Controls.Add(this.pnlContent);
            this.pnlPages.Controls.Add(this.pnlMyUpdates);
            this.pnlPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPages.Location = new System.Drawing.Point(244, 72);
            this.pnlPages.Name = "pnlPages";
            this.pnlPages.Size = new System.Drawing.Size(936, 833);
            this.pnlPages.TabIndex = 0;
            // 
            // pnlSubmitUpdates
            // 
            this.pnlSubmitUpdates.AutoScroll = true;
            this.pnlSubmitUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pnlSubmitUpdates.Controls.Add(this.pboxPhoto);
            this.pnlSubmitUpdates.Controls.Add(this.btnSubmitUpdate);
            this.pnlSubmitUpdates.Controls.Add(this.cboxPhases);
            this.pnlSubmitUpdates.Controls.Add(this.lblConstructionPhase);
            this.pnlSubmitUpdates.Controls.Add(this.btnUpload);
            this.pnlSubmitUpdates.Controls.Add(this.lblUploadPicture);
            this.pnlSubmitUpdates.Controls.Add(this.lblSubmitUpdatesTitle);
            this.pnlSubmitUpdates.Controls.Add(this.lblSubmitUpdatesSubtitle);
            this.pnlSubmitUpdates.Controls.Add(this.lblUpdateSite);
            this.pnlSubmitUpdates.Controls.Add(this.cboxUpdateSite);
            this.pnlSubmitUpdates.Controls.Add(this.lblUpdateDescription);
            this.pnlSubmitUpdates.Controls.Add(this.txtUpdateDescription);
            this.pnlSubmitUpdates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubmitUpdates.Location = new System.Drawing.Point(0, 0);
            this.pnlSubmitUpdates.Name = "pnlSubmitUpdates";
            this.pnlSubmitUpdates.Size = new System.Drawing.Size(936, 833);
            this.pnlSubmitUpdates.TabIndex = 1;
            this.pnlSubmitUpdates.Visible = false;
            // 
            // lblSubmitUpdatesTitle
            // 
            this.lblSubmitUpdatesTitle.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblSubmitUpdatesTitle.Location = new System.Drawing.Point(22, 8);
            this.lblSubmitUpdatesTitle.Name = "lblSubmitUpdatesTitle";
            this.lblSubmitUpdatesTitle.Size = new System.Drawing.Size(820, 42);
            this.lblSubmitUpdatesTitle.TabIndex = 0;
            this.lblSubmitUpdatesTitle.Text = "Submit Updates";
            // 
            // lblSubmitUpdatesSubtitle
            // 
            this.lblSubmitUpdatesSubtitle.Location = new System.Drawing.Point(23, 69);
            this.lblSubmitUpdatesSubtitle.Name = "lblSubmitUpdatesSubtitle";
            this.lblSubmitUpdatesSubtitle.Size = new System.Drawing.Size(820, 32);
            this.lblSubmitUpdatesSubtitle.TabIndex = 1;
            this.lblSubmitUpdatesSubtitle.Text = "Choose an assigned site and draft your progress update.";
            // 
            // lblUpdateSite
            // 
            this.lblUpdateSite.Location = new System.Drawing.Point(28, 112);
            this.lblUpdateSite.Name = "lblUpdateSite";
            this.lblUpdateSite.Size = new System.Drawing.Size(300, 28);
            this.lblUpdateSite.TabIndex = 2;
            this.lblUpdateSite.Text = "Assigned Site";
            // 
            // cboxUpdateSite
            // 
            this.cboxUpdateSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxUpdateSite.DisplayMember = "SiteName";
            this.cboxUpdateSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxUpdateSite.Enabled = false;
            this.cboxUpdateSite.Location = new System.Drawing.Point(28, 145);
            this.cboxUpdateSite.Name = "cboxUpdateSite";
            this.cboxUpdateSite.Size = new System.Drawing.Size(820, 36);
            this.cboxUpdateSite.TabIndex = 0;
            this.cboxUpdateSite.ValueMember = "SiteId";
            // 
            // lblUpdateDescription
            // 
            this.lblUpdateDescription.Location = new System.Drawing.Point(18, 569);
            this.lblUpdateDescription.Name = "lblUpdateDescription";
            this.lblUpdateDescription.Size = new System.Drawing.Size(400, 28);
            this.lblUpdateDescription.TabIndex = 3;
            this.lblUpdateDescription.Text = "Progress Description";
            // 
            // txtUpdateDescription
            // 
            this.txtUpdateDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpdateDescription.Location = new System.Drawing.Point(22, 612);
            this.txtUpdateDescription.Multiline = true;
            this.txtUpdateDescription.Name = "txtUpdateDescription";
            this.txtUpdateDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUpdateDescription.Size = new System.Drawing.Size(820, 108);
            this.txtUpdateDescription.TabIndex = 1;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pnlContent.Controls.Add(this.lblTitle);
            this.pnlContent.Controls.Add(this.lblSubtitle);
            this.pnlContent.Controls.Add(this.tblSummary);
            this.pnlContent.Controls.Add(this.lblAssignments);
            this.pnlContent.Controls.Add(this.btnSubmitProgressUpdate);
            this.pnlContent.Controls.Add(this.dataGridView1);
            this.pnlContent.Controls.Add(this.lblSelectionHint);
            this.pnlContent.Controls.Add(this.btnUpdateStatus);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(936, 833);
            this.pnlContent.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(28, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(740, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Welcome, Worker";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.lblSubtitle.Location = new System.Drawing.Point(30, 68);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(870, 24);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Keep track of your assigned sites and share your progress.";
            // 
            // tblSummary
            // 
            this.tblSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblSummary.ColumnCount = 2;
            this.tblSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSummary.Controls.Add(this.pnlAssignedSites, 0, 0);
            this.tblSummary.Controls.Add(this.pnlPendingUpdates, 1, 0);
            this.tblSummary.Controls.Add(this.pnlActiveTasks, 0, 1);
            this.tblSummary.Controls.Add(this.pnlCompletedTasks, 1, 1);
            this.tblSummary.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tblSummary.Location = new System.Drawing.Point(22, 104);
            this.tblSummary.Name = "tblSummary";
            this.tblSummary.RowCount = 2;
            this.tblSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSummary.Size = new System.Drawing.Size(892, 192);
            this.tblSummary.TabIndex = 2;
            // 
            // pnlAssignedSites
            // 
            this.pnlAssignedSites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlAssignedSites.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAssignedSites.Controls.Add(this.lblAssignedSitesValue);
            this.pnlAssignedSites.Controls.Add(this.lblAssignedSites);
            this.pnlAssignedSites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAssignedSites.Location = new System.Drawing.Point(6, 6);
            this.pnlAssignedSites.Margin = new System.Windows.Forms.Padding(6);
            this.pnlAssignedSites.Name = "pnlAssignedSites";
            this.pnlAssignedSites.Size = new System.Drawing.Size(434, 84);
            this.pnlAssignedSites.TabIndex = 0;
            // 
            // lblAssignedSitesValue
            // 
            this.lblAssignedSitesValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAssignedSitesValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblAssignedSitesValue.Location = new System.Drawing.Point(14, 9);
            this.lblAssignedSitesValue.Name = "lblAssignedSitesValue";
            this.lblAssignedSitesValue.Size = new System.Drawing.Size(368, 34);
            this.lblAssignedSitesValue.TabIndex = 0;
            this.lblAssignedSitesValue.Text = "—";
            // 
            // lblAssignedSites
            // 
            this.lblAssignedSites.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAssignedSites.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAssignedSites.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblAssignedSites.Location = new System.Drawing.Point(16, 48);
            this.lblAssignedSites.Name = "lblAssignedSites";
            this.lblAssignedSites.Size = new System.Drawing.Size(368, 22);
            this.lblAssignedSites.TabIndex = 1;
            this.lblAssignedSites.Text = "Assigned Sites";
            // 
            // pnlPendingUpdates
            // 
            this.pnlPendingUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlPendingUpdates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPendingUpdates.Controls.Add(this.lblPendingUpdatesValue);
            this.pnlPendingUpdates.Controls.Add(this.lblPendingUpdates);
            this.pnlPendingUpdates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPendingUpdates.Location = new System.Drawing.Point(452, 6);
            this.pnlPendingUpdates.Margin = new System.Windows.Forms.Padding(6);
            this.pnlPendingUpdates.Name = "pnlPendingUpdates";
            this.pnlPendingUpdates.Size = new System.Drawing.Size(434, 84);
            this.pnlPendingUpdates.TabIndex = 1;
            // 
            // lblPendingUpdatesValue
            // 
            this.lblPendingUpdatesValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPendingUpdatesValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblPendingUpdatesValue.Location = new System.Drawing.Point(14, 9);
            this.lblPendingUpdatesValue.Name = "lblPendingUpdatesValue";
            this.lblPendingUpdatesValue.Size = new System.Drawing.Size(368, 34);
            this.lblPendingUpdatesValue.TabIndex = 0;
            this.lblPendingUpdatesValue.Text = "—";
            // 
            // lblPendingUpdates
            // 
            this.lblPendingUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPendingUpdates.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPendingUpdates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblPendingUpdates.Location = new System.Drawing.Point(16, 48);
            this.lblPendingUpdates.Name = "lblPendingUpdates";
            this.lblPendingUpdates.Size = new System.Drawing.Size(368, 22);
            this.lblPendingUpdates.TabIndex = 1;
            this.lblPendingUpdates.Text = "Pending Updates";
            // 
            // pnlActiveTasks
            // 
            this.pnlActiveTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlActiveTasks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlActiveTasks.Controls.Add(this.lblActiveTasksValue);
            this.pnlActiveTasks.Controls.Add(this.lblActiveTasks);
            this.pnlActiveTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActiveTasks.Location = new System.Drawing.Point(6, 102);
            this.pnlActiveTasks.Margin = new System.Windows.Forms.Padding(6);
            this.pnlActiveTasks.Name = "pnlActiveTasks";
            this.pnlActiveTasks.Size = new System.Drawing.Size(434, 84);
            this.pnlActiveTasks.TabIndex = 2;
            // 
            // lblActiveTasksValue
            // 
            this.lblActiveTasksValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActiveTasksValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblActiveTasksValue.Location = new System.Drawing.Point(14, 9);
            this.lblActiveTasksValue.Name = "lblActiveTasksValue";
            this.lblActiveTasksValue.Size = new System.Drawing.Size(368, 34);
            this.lblActiveTasksValue.TabIndex = 0;
            this.lblActiveTasksValue.Text = "—";
            // 
            // lblActiveTasks
            // 
            this.lblActiveTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActiveTasks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblActiveTasks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblActiveTasks.Location = new System.Drawing.Point(16, 48);
            this.lblActiveTasks.Name = "lblActiveTasks";
            this.lblActiveTasks.Size = new System.Drawing.Size(368, 22);
            this.lblActiveTasks.TabIndex = 1;
            this.lblActiveTasks.Text = "Tasks in Progress";
            // 
            // pnlCompletedTasks
            // 
            this.pnlCompletedTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlCompletedTasks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCompletedTasks.Controls.Add(this.lblCompletedTasksValue);
            this.pnlCompletedTasks.Controls.Add(this.lblCompletedTasks);
            this.pnlCompletedTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCompletedTasks.Location = new System.Drawing.Point(452, 102);
            this.pnlCompletedTasks.Margin = new System.Windows.Forms.Padding(6);
            this.pnlCompletedTasks.Name = "pnlCompletedTasks";
            this.pnlCompletedTasks.Size = new System.Drawing.Size(434, 84);
            this.pnlCompletedTasks.TabIndex = 3;
            // 
            // lblCompletedTasksValue
            // 
            this.lblCompletedTasksValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCompletedTasksValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCompletedTasksValue.Location = new System.Drawing.Point(14, 9);
            this.lblCompletedTasksValue.Name = "lblCompletedTasksValue";
            this.lblCompletedTasksValue.Size = new System.Drawing.Size(368, 34);
            this.lblCompletedTasksValue.TabIndex = 0;
            this.lblCompletedTasksValue.Text = "—";
            // 
            // lblCompletedTasks
            // 
            this.lblCompletedTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCompletedTasks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCompletedTasks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblCompletedTasks.Location = new System.Drawing.Point(16, 48);
            this.lblCompletedTasks.Name = "lblCompletedTasks";
            this.lblCompletedTasks.Size = new System.Drawing.Size(368, 22);
            this.lblCompletedTasks.TabIndex = 1;
            this.lblCompletedTasks.Text = "Completed Tasks";
            // 
            // lblAssignments
            // 
            this.lblAssignments.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAssignments.Location = new System.Drawing.Point(28, 316);
            this.lblAssignments.Name = "lblAssignments";
            this.lblAssignments.Size = new System.Drawing.Size(610, 32);
            this.lblAssignments.TabIndex = 3;
            this.lblAssignments.Text = "My Sites";
            // 
            // btnSubmitProgressUpdate
            // 
            this.btnSubmitProgressUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmitProgressUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSubmitProgressUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmitProgressUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnSubmitProgressUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitProgressUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubmitProgressUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnSubmitProgressUpdate.Location = new System.Drawing.Point(726, 310);
            this.btnSubmitProgressUpdate.Name = "btnSubmitProgressUpdate";
            this.btnSubmitProgressUpdate.Size = new System.Drawing.Size(182, 38);
            this.btnSubmitProgressUpdate.TabIndex = 0;
            this.btnSubmitProgressUpdate.Text = "Submit Progress Update";
            this.btnSubmitProgressUpdate.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeight = 42;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.CurrentPhase,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.dataGridView1.Location = new System.Drawing.Point(28, 362);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 38;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(880, 351);
            this.dataGridView1.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 12F;
            this.Column1.HeaderText = "Site ID";
            this.Column1.MinimumWidth = 70;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 30F;
            this.Column2.HeaderText = "Site Name";
            this.Column2.MinimumWidth = 70;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // CurrentPhase
            // 
            this.CurrentPhase.FillWeight = 26F;
            this.CurrentPhase.HeaderText = "Phase / Task";
            this.CurrentPhase.MinimumWidth = 70;
            this.CurrentPhase.Name = "CurrentPhase";
            this.CurrentPhase.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 16F;
            this.Column3.HeaderText = "Progress";
            this.Column3.MinimumWidth = 70;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 20F;
            this.Column4.HeaderText = "Status";
            this.Column4.MinimumWidth = 70;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // lblSelectionHint
            // 
            this.lblSelectionHint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectionHint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSelectionHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.lblSelectionHint.Location = new System.Drawing.Point(28, 723);
            this.lblSelectionHint.Name = "lblSelectionHint";
            this.lblSelectionHint.Size = new System.Drawing.Size(880, 22);
            this.lblSelectionHint.TabIndex = 4;
            this.lblSelectionHint.Text = "Select an assignment before submitting or checking an update.";
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btnUpdateStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateStatus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnUpdateStatus.FlatAppearance.BorderSize = 0;
            this.btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdateStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnUpdateStatus.Location = new System.Drawing.Point(28, 759);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(880, 46);
            this.btnUpdateStatus.TabIndex = 2;
            this.btnUpdateStatus.Text = "View Update Status";
            this.btnUpdateStatus.UseVisualStyleBackColor = false;
            // 
            // pnlMyUpdates
            // 
            this.pnlMyUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pnlMyUpdates.Controls.Add(this.lblMyUpdatesTitle);
            this.pnlMyUpdates.Controls.Add(this.lblMyUpdatesSubtitle);
            this.pnlMyUpdates.Controls.Add(this.dgvMyUpdates);
            this.pnlMyUpdates.Controls.Add(this.lblUpdateHistoryAvailability);
            this.pnlMyUpdates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMyUpdates.Location = new System.Drawing.Point(0, 0);
            this.pnlMyUpdates.Name = "pnlMyUpdates";
            this.pnlMyUpdates.Size = new System.Drawing.Size(936, 833);
            this.pnlMyUpdates.TabIndex = 2;
            this.pnlMyUpdates.Visible = false;
            // 
            // lblMyUpdatesTitle
            // 
            this.lblMyUpdatesTitle.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblMyUpdatesTitle.Location = new System.Drawing.Point(28, 26);
            this.lblMyUpdatesTitle.Name = "lblMyUpdatesTitle";
            this.lblMyUpdatesTitle.Size = new System.Drawing.Size(820, 42);
            this.lblMyUpdatesTitle.TabIndex = 0;
            this.lblMyUpdatesTitle.Text = "My Updates";
            // 
            // lblMyUpdatesSubtitle
            // 
            this.lblMyUpdatesSubtitle.Location = new System.Drawing.Point(28, 80);
            this.lblMyUpdatesSubtitle.Name = "lblMyUpdatesSubtitle";
            this.lblMyUpdatesSubtitle.Size = new System.Drawing.Size(820, 32);
            this.lblMyUpdatesSubtitle.TabIndex = 1;
            this.lblMyUpdatesSubtitle.Text = "Your progress updates and contractor review status.";
            // 
            // dgvMyUpdates
            // 
            this.dgvMyUpdates.AllowUserToAddRows = false;
            this.dgvMyUpdates.AllowUserToDeleteRows = false;
            this.dgvMyUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMyUpdates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMyUpdates.BackgroundColor = System.Drawing.Color.White;
            this.dgvMyUpdates.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMyUpdates.ColumnHeadersHeight = 34;
            this.dgvMyUpdates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUpdateSite,
            this.colUpdateDescription,
            this.colUpdateDate,
            this.colUpdateStatus});
            this.dgvMyUpdates.Location = new System.Drawing.Point(28, 132);
            this.dgvMyUpdates.MultiSelect = false;
            this.dgvMyUpdates.Name = "dgvMyUpdates";
            this.dgvMyUpdates.ReadOnly = true;
            this.dgvMyUpdates.RowHeadersVisible = false;
            this.dgvMyUpdates.RowHeadersWidth = 62;
            this.dgvMyUpdates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMyUpdates.Size = new System.Drawing.Size(820, 535);
            this.dgvMyUpdates.TabIndex = 2;
            // 
            // colUpdateSite
            // 
            this.colUpdateSite.HeaderText = "Site";
            this.colUpdateSite.MinimumWidth = 8;
            this.colUpdateSite.Name = "colUpdateSite";
            this.colUpdateSite.ReadOnly = true;
            // 
            // colUpdateDescription
            // 
            this.colUpdateDescription.FillWeight = 180F;
            this.colUpdateDescription.HeaderText = "Description";
            this.colUpdateDescription.MinimumWidth = 8;
            this.colUpdateDescription.Name = "colUpdateDescription";
            this.colUpdateDescription.ReadOnly = true;
            // 
            // colUpdateDate
            // 
            this.colUpdateDate.HeaderText = "Date Submitted";
            this.colUpdateDate.MinimumWidth = 8;
            this.colUpdateDate.Name = "colUpdateDate";
            this.colUpdateDate.ReadOnly = true;
            // 
            // colUpdateStatus
            // 
            this.colUpdateStatus.HeaderText = "Status";
            this.colUpdateStatus.MinimumWidth = 8;
            this.colUpdateStatus.Name = "colUpdateStatus";
            this.colUpdateStatus.ReadOnly = true;
            // 
            // lblUpdateHistoryAvailability
            // 
            this.lblUpdateHistoryAvailability.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpdateHistoryAvailability.Location = new System.Drawing.Point(28, 693);
            this.lblUpdateHistoryAvailability.Name = "lblUpdateHistoryAvailability";
            this.lblUpdateHistoryAvailability.Size = new System.Drawing.Size(820, 40);
            this.lblUpdateHistoryAvailability.TabIndex = 3;
            this.lblUpdateHistoryAvailability.Text = "Update history is not available yet.";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlHeader.Controls.Add(this.lblBrand);
            this.pnlHeader.Controls.Add(this.lblPortal);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1180, 72);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblBrand
            // 
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblBrand.Location = new System.Drawing.Point(28, 21);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(370, 32);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "Construction Manager";
            // 
            // lblPortal
            // 
            this.lblPortal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPortal.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblPortal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblPortal.Location = new System.Drawing.Point(928, 26);
            this.lblPortal.Name = "lblPortal";
            this.lblPortal.Size = new System.Drawing.Size(224, 25);
            this.lblPortal.TabIndex = 1;
            this.lblPortal.Text = "Worker Portal";
            this.lblPortal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlSidebar.Controls.Add(this.btnDashboard);
            this.pnlSidebar.Controls.Add(this.btnSubmitUpdates);
            this.pnlSidebar.Controls.Add(this.btnMyUpdates);
            this.pnlSidebar.Controls.Add(this.btnLogOut);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 72);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(244, 833);
            this.pnlSidebar.TabIndex = 1;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnDashboard.Location = new System.Drawing.Point(16, 22);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(212, 46);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            // 
            // btnSubmitUpdates
            // 
            this.btnSubmitUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSubmitUpdates.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmitUpdates.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnSubmitUpdates.FlatAppearance.BorderSize = 0;
            this.btnSubmitUpdates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitUpdates.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubmitUpdates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnSubmitUpdates.Location = new System.Drawing.Point(16, 78);
            this.btnSubmitUpdates.Name = "btnSubmitUpdates";
            this.btnSubmitUpdates.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnSubmitUpdates.Size = new System.Drawing.Size(212, 46);
            this.btnSubmitUpdates.TabIndex = 1;
            this.btnSubmitUpdates.Text = "Submit Updates";
            this.btnSubmitUpdates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubmitUpdates.UseVisualStyleBackColor = false;
            // 
            // btnMyUpdates
            // 
            this.btnMyUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnMyUpdates.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMyUpdates.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnMyUpdates.FlatAppearance.BorderSize = 0;
            this.btnMyUpdates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyUpdates.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMyUpdates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnMyUpdates.Location = new System.Drawing.Point(16, 134);
            this.btnMyUpdates.Name = "btnMyUpdates";
            this.btnMyUpdates.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnMyUpdates.Size = new System.Drawing.Size(212, 46);
            this.btnMyUpdates.TabIndex = 2;
            this.btnMyUpdates.Text = "My Updates";
            this.btnMyUpdates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyUpdates.UseVisualStyleBackColor = false;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogOut.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnLogOut.Location = new System.Drawing.Point(16, 765);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnLogOut.Size = new System.Drawing.Size(212, 44);
            this.btnLogOut.TabIndex = 3;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // lblUploadPicture
            // 
            this.lblUploadPicture.Location = new System.Drawing.Point(23, 296);
            this.lblUploadPicture.Name = "lblUploadPicture";
            this.lblUploadPicture.Size = new System.Drawing.Size(400, 28);
            this.lblUploadPicture.TabIndex = 4;
            this.lblUploadPicture.Text = "Upload Picture";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(22, 341);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(290, 83);
            this.btnUpload.TabIndex = 5;
            this.btnUpload.Text = "Upload Construction Photo";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // lblConstructionPhase
            // 
            this.lblConstructionPhase.Location = new System.Drawing.Point(23, 200);
            this.lblConstructionPhase.Name = "lblConstructionPhase";
            this.lblConstructionPhase.Size = new System.Drawing.Size(400, 28);
            this.lblConstructionPhase.TabIndex = 6;
            this.lblConstructionPhase.Text = "Construction Phase";
            // 
            // cboxPhases
            // 
            this.cboxPhases.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxPhases.DisplayMember = "SiteName";
            this.cboxPhases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxPhases.Enabled = false;
            this.cboxPhases.Location = new System.Drawing.Point(23, 241);
            this.cboxPhases.Name = "cboxPhases";
            this.cboxPhases.Size = new System.Drawing.Size(820, 36);
            this.cboxPhases.TabIndex = 7;
            this.cboxPhases.ValueMember = "SiteId";
            // 
            // btnSubmitUpdate
            // 
            this.btnSubmitUpdate.Location = new System.Drawing.Point(138, 748);
            this.btnSubmitUpdate.Name = "btnSubmitUpdate";
            this.btnSubmitUpdate.Size = new System.Drawing.Size(582, 66);
            this.btnSubmitUpdate.TabIndex = 8;
            this.btnSubmitUpdate.Text = "Submit Update";
            this.btnSubmitUpdate.UseVisualStyleBackColor = true;
            this.btnSubmitUpdate.Click += new System.EventHandler(this.btnSubmitUpdate_Click);
            // 
            // pboxPhoto
            // 
            this.pboxPhoto.Location = new System.Drawing.Point(343, 299);
            this.pboxPhoto.Name = "pboxPhoto";
            this.pboxPhoto.Size = new System.Drawing.Size(482, 267);
            this.pboxPhoto.TabIndex = 9;
            this.pboxPhoto.TabStop = false;
            // 
            // WorkerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1180, 905);
            this.Controls.Add(this.pnlPages);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.MinimumSize = new System.Drawing.Size(1040, 720);
            this.Name = "WorkerDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Construction Manager | Worker Dashboard";
            this.pnlPages.ResumeLayout(false);
            this.pnlSubmitUpdates.ResumeLayout(false);
            this.pnlSubmitUpdates.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.tblSummary.ResumeLayout(false);
            this.pnlAssignedSites.ResumeLayout(false);
            this.pnlPendingUpdates.ResumeLayout(false);
            this.pnlActiveTasks.ResumeLayout(false);
            this.pnlCompletedTasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlMyUpdates.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyUpdates)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPages;
        private System.Windows.Forms.Panel pnlSubmitUpdates;
        private System.Windows.Forms.Panel pnlMyUpdates;
        private System.Windows.Forms.Label lblSubmitUpdatesTitle;
        private System.Windows.Forms.Label lblSubmitUpdatesSubtitle;
        private System.Windows.Forms.Label lblUpdateSite;
        private System.Windows.Forms.ComboBox cboxUpdateSite;
        private System.Windows.Forms.Label lblUpdateDescription;
        private System.Windows.Forms.TextBox txtUpdateDescription;
        private System.Windows.Forms.Label lblMyUpdatesTitle;
        private System.Windows.Forms.Label lblMyUpdatesSubtitle;
        private System.Windows.Forms.DataGridView dgvMyUpdates;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpdateSite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpdateDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpdateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpdateStatus;
        private System.Windows.Forms.Label lblUpdateHistoryAvailability;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblPortal;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnSubmitUpdates;
        private System.Windows.Forms.Button btnMyUpdates;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.TableLayoutPanel tblSummary;
        private System.Windows.Forms.Panel pnlAssignedSites;
        private System.Windows.Forms.Label lblAssignedSitesValue;
        private System.Windows.Forms.Label lblAssignedSites;
        private System.Windows.Forms.Panel pnlPendingUpdates;
        private System.Windows.Forms.Label lblPendingUpdatesValue;
        private System.Windows.Forms.Label lblPendingUpdates;
        private System.Windows.Forms.Panel pnlActiveTasks;
        private System.Windows.Forms.Label lblActiveTasksValue;
        private System.Windows.Forms.Label lblActiveTasks;
        private System.Windows.Forms.Panel pnlCompletedTasks;
        private System.Windows.Forms.Label lblCompletedTasksValue;
        private System.Windows.Forms.Label lblCompletedTasks;
        private System.Windows.Forms.Label lblAssignments;
        private System.Windows.Forms.Button btnSubmitProgressUpdate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentPhase;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label lblSelectionHint;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Label lblUploadPicture;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cboxPhases;
        private System.Windows.Forms.Label lblConstructionPhase;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnSubmitUpdate;
        private System.Windows.Forms.PictureBox pboxPhoto;
    }
}
