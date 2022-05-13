namespace DuelSys_inc
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.Dashboard = new System.Windows.Forms.TabPage();
            this.dgvTournaments = new System.Windows.Forms.DataGridView();
            this.Forms = new System.Windows.Forms.TabPage();
            this.lblId = new MaterialSkin.Controls.MaterialLabel();
            this.btnEditTournament = new MaterialSkin.Controls.MaterialButton();
            this.lbxTournaments = new System.Windows.Forms.ListBox();
            this.lblEndDate = new MaterialSkin.Controls.MaterialLabel();
            this.lblStartDate = new MaterialSkin.Controls.MaterialLabel();
            this.cbxTournamentSystem = new MaterialSkin.Controls.MaterialComboBox();
            this.cbxSport = new MaterialSkin.Controls.MaterialComboBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.tbxLocation = new MaterialSkin.Controls.MaterialTextBox();
            this.btnCreateTournament = new MaterialSkin.Controls.MaterialButton();
            this.materialSwitch1 = new MaterialSkin.Controls.MaterialSwitch();
            this.tbxDescription = new MaterialSkin.Controls.MaterialTextBox();
            this.Notification = new System.Windows.Forms.TabPage();
            this.Statistics = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.materialTabControl1.SuspendLayout();
            this.Dashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTournaments)).BeginInit();
            this.Forms.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.Dashboard);
            this.materialTabControl1.Controls.Add(this.Forms);
            this.materialTabControl1.Controls.Add(this.Notification);
            this.materialTabControl1.Controls.Add(this.Statistics);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.ImageList = this.imageList1;
            this.materialTabControl1.Location = new System.Drawing.Point(4, 99);
            this.materialTabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(1259, 711);
            this.materialTabControl1.TabIndex = 0;
            // 
            // Dashboard
            // 
            this.Dashboard.BackColor = System.Drawing.Color.Transparent;
            this.Dashboard.Controls.Add(this.dgvTournaments);
            this.Dashboard.ImageKey = "icons8-table-32.png";
            this.Dashboard.Location = new System.Drawing.Point(4, 39);
            this.Dashboard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Dashboard.Name = "Dashboard";
            this.Dashboard.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Dashboard.Size = new System.Drawing.Size(1251, 668);
            this.Dashboard.TabIndex = 0;
            this.Dashboard.Text = "Dashboard";
            // 
            // dgvTournaments
            // 
            this.dgvTournaments.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvTournaments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTournaments.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvTournaments.Location = new System.Drawing.Point(69, 340);
            this.dgvTournaments.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTournaments.Name = "dgvTournaments";
            this.dgvTournaments.RowHeadersWidth = 72;
            this.dgvTournaments.RowTemplate.Height = 37;
            this.dgvTournaments.Size = new System.Drawing.Size(1111, 300);
            this.dgvTournaments.TabIndex = 0;
            this.dgvTournaments.DoubleClick += new System.EventHandler(this.dgvTournaments_DoubleClick);
            // 
            // Forms
            // 
            this.Forms.Controls.Add(this.lblId);
            this.Forms.Controls.Add(this.btnEditTournament);
            this.Forms.Controls.Add(this.lbxTournaments);
            this.Forms.Controls.Add(this.lblEndDate);
            this.Forms.Controls.Add(this.lblStartDate);
            this.Forms.Controls.Add(this.cbxTournamentSystem);
            this.Forms.Controls.Add(this.cbxSport);
            this.Forms.Controls.Add(this.dtpEndDate);
            this.Forms.Controls.Add(this.dtpStartDate);
            this.Forms.Controls.Add(this.tbxLocation);
            this.Forms.Controls.Add(this.btnCreateTournament);
            this.Forms.Controls.Add(this.materialSwitch1);
            this.Forms.Controls.Add(this.tbxDescription);
            this.Forms.ImageKey = "icons8-goal-32.png";
            this.Forms.Location = new System.Drawing.Point(4, 39);
            this.Forms.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Forms.Name = "Forms";
            this.Forms.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Forms.Size = new System.Drawing.Size(1251, 668);
            this.Forms.TabIndex = 1;
            this.Forms.Text = "Tournaments";
            this.Forms.UseVisualStyleBackColor = true;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Depth = 0;
            this.lblId.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblId.Location = new System.Drawing.Point(47, 5);
            this.lblId.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(1, 0);
            this.lblId.TabIndex = 15;
            this.lblId.Visible = false;
            // 
            // btnEditTournament
            // 
            this.btnEditTournament.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditTournament.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEditTournament.Depth = 0;
            this.btnEditTournament.Enabled = false;
            this.btnEditTournament.HighEmphasis = true;
            this.btnEditTournament.Icon = null;
            this.btnEditTournament.Location = new System.Drawing.Point(266, 557);
            this.btnEditTournament.Margin = new System.Windows.Forms.Padding(5, 9, 5, 9);
            this.btnEditTournament.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEditTournament.Name = "btnEditTournament";
            this.btnEditTournament.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEditTournament.Size = new System.Drawing.Size(155, 36);
            this.btnEditTournament.TabIndex = 14;
            this.btnEditTournament.Tag = "0";
            this.btnEditTournament.Text = "Edit tournament";
            this.btnEditTournament.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEditTournament.UseAccentColor = false;
            this.btnEditTournament.UseVisualStyleBackColor = true;
            this.btnEditTournament.Click += new System.EventHandler(this.btnEditTournament_Click);
            // 
            // lbxTournaments
            // 
            this.lbxTournaments.FormattingEnabled = true;
            this.lbxTournaments.ItemHeight = 20;
            this.lbxTournaments.Location = new System.Drawing.Point(934, 38);
            this.lbxTournaments.Name = "lbxTournaments";
            this.lbxTournaments.Size = new System.Drawing.Size(241, 464);
            this.lbxTournaments.TabIndex = 13;
            this.lbxTournaments.DoubleClick += new System.EventHandler(this.lbxTournaments_DoubleClick);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Depth = 0;
            this.lblEndDate.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblEndDate.Location = new System.Drawing.Point(353, 250);
            this.lblEndDate.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(67, 19);
            this.lblEndDate.TabIndex = 12;
            this.lblEndDate.Text = "End date:";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Depth = 0;
            this.lblStartDate.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblStartDate.Location = new System.Drawing.Point(47, 250);
            this.lblStartDate.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(74, 19);
            this.lblStartDate.TabIndex = 11;
            this.lblStartDate.Text = "Start date:";
            // 
            // cbxTournamentSystem
            // 
            this.cbxTournamentSystem.AutoResize = false;
            this.cbxTournamentSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbxTournamentSystem.Depth = 0;
            this.cbxTournamentSystem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbxTournamentSystem.DropDownHeight = 174;
            this.cbxTournamentSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTournamentSystem.DropDownWidth = 121;
            this.cbxTournamentSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbxTournamentSystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbxTournamentSystem.FormattingEnabled = true;
            this.cbxTournamentSystem.Hint = "TournamentService system";
            this.cbxTournamentSystem.IntegralHeight = false;
            this.cbxTournamentSystem.ItemHeight = 43;
            this.cbxTournamentSystem.Location = new System.Drawing.Point(353, 366);
            this.cbxTournamentSystem.MaxDropDownItems = 4;
            this.cbxTournamentSystem.MouseState = MaterialSkin.MouseState.OUT;
            this.cbxTournamentSystem.Name = "cbxTournamentSystem";
            this.cbxTournamentSystem.Size = new System.Drawing.Size(250, 49);
            this.cbxTournamentSystem.StartIndex = 0;
            this.cbxTournamentSystem.TabIndex = 10;
            // 
            // cbxSport
            // 
            this.cbxSport.AutoResize = false;
            this.cbxSport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbxSport.Depth = 0;
            this.cbxSport.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbxSport.DropDownHeight = 174;
            this.cbxSport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSport.DropDownWidth = 121;
            this.cbxSport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbxSport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbxSport.FormattingEnabled = true;
            this.cbxSport.Hint = "Sport";
            this.cbxSport.IntegralHeight = false;
            this.cbxSport.ItemHeight = 43;
            this.cbxSport.Location = new System.Drawing.Point(47, 367);
            this.cbxSport.MaxDropDownItems = 4;
            this.cbxSport.MouseState = MaterialSkin.MouseState.OUT;
            this.cbxSport.Name = "cbxSport";
            this.cbxSport.Size = new System.Drawing.Size(250, 49);
            this.cbxSport.StartIndex = 0;
            this.cbxSport.TabIndex = 9;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CalendarMonthBackground = System.Drawing.SystemColors.WindowFrame;
            this.dtpEndDate.Location = new System.Drawing.Point(353, 290);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(250, 27);
            this.dtpEndDate.TabIndex = 8;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CalendarMonthBackground = System.Drawing.SystemColors.WindowFrame;
            this.dtpStartDate.Location = new System.Drawing.Point(47, 290);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(250, 27);
            this.dtpStartDate.TabIndex = 7;
            // 
            // tbxLocation
            // 
            this.tbxLocation.AnimateReadOnly = false;
            this.tbxLocation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxLocation.Depth = 0;
            this.tbxLocation.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbxLocation.Hint = "Location";
            this.tbxLocation.LeadingIcon = null;
            this.tbxLocation.Location = new System.Drawing.Point(47, 136);
            this.tbxLocation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxLocation.MaxLength = 50;
            this.tbxLocation.MouseState = MaterialSkin.MouseState.OUT;
            this.tbxLocation.Multiline = false;
            this.tbxLocation.Name = "tbxLocation";
            this.tbxLocation.Size = new System.Drawing.Size(556, 50);
            this.tbxLocation.TabIndex = 6;
            this.tbxLocation.Text = "";
            this.tbxLocation.TrailingIcon = null;
            // 
            // btnCreateTournament
            // 
            this.btnCreateTournament.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCreateTournament.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCreateTournament.Depth = 0;
            this.btnCreateTournament.HighEmphasis = true;
            this.btnCreateTournament.Icon = null;
            this.btnCreateTournament.Location = new System.Drawing.Point(47, 557);
            this.btnCreateTournament.Margin = new System.Windows.Forms.Padding(5, 9, 5, 9);
            this.btnCreateTournament.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCreateTournament.Name = "btnCreateTournament";
            this.btnCreateTournament.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCreateTournament.Size = new System.Drawing.Size(178, 36);
            this.btnCreateTournament.TabIndex = 5;
            this.btnCreateTournament.Tag = "0";
            this.btnCreateTournament.Text = "Create tournament";
            this.btnCreateTournament.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCreateTournament.UseAccentColor = false;
            this.btnCreateTournament.UseVisualStyleBackColor = true;
            this.btnCreateTournament.Click += new System.EventHandler(this.btnCreateTournament_Click);
            // 
            // materialSwitch1
            // 
            this.materialSwitch1.AutoSize = true;
            this.materialSwitch1.Depth = 0;
            this.materialSwitch1.Location = new System.Drawing.Point(47, 460);
            this.materialSwitch1.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSwitch1.Name = "materialSwitch1";
            this.materialSwitch1.Ripple = true;
            this.materialSwitch1.Size = new System.Drawing.Size(223, 37);
            this.materialSwitch1.TabIndex = 3;
            this.materialSwitch1.Text = "Auto generate schedule";
            this.materialSwitch1.UseVisualStyleBackColor = true;
            // 
            // tbxDescription
            // 
            this.tbxDescription.AnimateReadOnly = false;
            this.tbxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxDescription.Depth = 0;
            this.tbxDescription.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbxDescription.Hint = "Description";
            this.tbxDescription.LeadingIcon = null;
            this.tbxDescription.Location = new System.Drawing.Point(47, 38);
            this.tbxDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxDescription.MaxLength = 50;
            this.tbxDescription.MouseState = MaterialSkin.MouseState.OUT;
            this.tbxDescription.Multiline = false;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(556, 50);
            this.tbxDescription.TabIndex = 1;
            this.tbxDescription.Text = "";
            this.tbxDescription.TrailingIcon = null;
            // 
            // Notification
            // 
            this.Notification.ImageKey = "icons8-notification-32.png";
            this.Notification.Location = new System.Drawing.Point(4, 39);
            this.Notification.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Notification.Name = "Notification";
            this.Notification.Size = new System.Drawing.Size(1251, 668);
            this.Notification.TabIndex = 5;
            this.Notification.Text = "Notification";
            this.Notification.UseVisualStyleBackColor = true;
            // 
            // Statistics
            // 
            this.Statistics.ImageKey = "icons8-marketing-32.png";
            this.Statistics.Location = new System.Drawing.Point(4, 39);
            this.Statistics.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Statistics.Name = "Statistics";
            this.Statistics.Size = new System.Drawing.Size(1251, 668);
            this.Statistics.TabIndex = 7;
            this.Statistics.Text = "Statistics";
            this.Statistics.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-notification-32.png");
            this.imageList1.Images.SetKeyName(1, "icons8-typing-32.png");
            this.imageList1.Images.SetKeyName(2, "icons8-table-32.png");
            this.imageList1.Images.SetKeyName(3, "icons8-goal-32.png");
            this.imageList1.Images.SetKeyName(4, "icons8-line-chart-32.png");
            this.imageList1.Images.SetKeyName(5, "icons8-marketing-32.png");
            this.imageList1.Images.SetKeyName(6, "icons8-notification-32.png");
            this.imageList1.Images.SetKeyName(7, "icons8-typing-32.png");
            this.imageList1.Images.SetKeyName(8, "icons8-table-32.png");
            this.imageList1.Images.SetKeyName(9, "icons8-goal-32.png");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 815);
            this.Controls.Add(this.materialTabControl1);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(4, 99, 4, 5);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DualSys Inc.";
            this.materialTabControl1.ResumeLayout(false);
            this.Dashboard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTournaments)).EndInit();
            this.Forms.ResumeLayout(false);
            this.Forms.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage Dashboard;
        private System.Windows.Forms.TabPage Forms;
        private System.Windows.Forms.TabPage Notification;
        private System.Windows.Forms.TabPage Statistics;
        private System.Windows.Forms.ImageList imageList1;
        private MaterialSkin.Controls.MaterialButton btnCreateTournament;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch1;
        private MaterialSkin.Controls.MaterialTextBox tbxDescription;
        private MaterialSkin.Controls.MaterialTextBox tbxLocation;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private MaterialSkin.Controls.MaterialComboBox cbxTournamentSystem;
        private MaterialSkin.Controls.MaterialComboBox cbxSport;
        private MaterialSkin.Controls.MaterialLabel lblEndDate;
        private MaterialSkin.Controls.MaterialLabel lblStartDate;
        private DataGridView dgvTournaments;
        private ListBox lbxTournaments;
        private MaterialSkin.Controls.MaterialButton btnEditTournament;
        private MaterialSkin.Controls.MaterialLabel lblId;
    }
}

