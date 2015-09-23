namespace Bitter {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageMarkets = new System.Windows.Forms.TabPage();
            this.dataGridViewMarkets = new System.Windows.Forms.DataGridView();
            this.tabPageWallets = new System.Windows.Forms.TabPage();
            this.tabPageOrders = new System.Windows.Forms.TabPage();
            this.dataGridViewWallets = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageMarkets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMarkets)).BeginInit();
            this.tabPageWallets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWallets)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.loginToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewKeyToolStripMenuItem,
            this.accountsToolStripMenuItem});
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // addNewKeyToolStripMenuItem
            // 
            this.addNewKeyToolStripMenuItem.Name = "addNewKeyToolStripMenuItem";
            this.addNewKeyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addNewKeyToolStripMenuItem.Text = "Add new key";
            this.addNewKeyToolStripMenuItem.Click += new System.EventHandler(this.addNewKeyToolStripMenuItem_Click);
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.accountsToolStripMenuItem.Text = "Accounts";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageMarkets);
            this.tabControlMain.Controls.Add(this.tabPageWallets);
            this.tabControlMain.Controls.Add(this.tabPageOrders);
            this.tabControlMain.Location = new System.Drawing.Point(12, 27);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(760, 518);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabPageMarkets
            // 
            this.tabPageMarkets.Controls.Add(this.dataGridViewMarkets);
            this.tabPageMarkets.Location = new System.Drawing.Point(4, 22);
            this.tabPageMarkets.Name = "tabPageMarkets";
            this.tabPageMarkets.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMarkets.Size = new System.Drawing.Size(752, 492);
            this.tabPageMarkets.TabIndex = 2;
            this.tabPageMarkets.Text = "Markets";
            this.tabPageMarkets.UseVisualStyleBackColor = true;
            // 
            // dataGridViewMarkets
            // 
            this.dataGridViewMarkets.AllowUserToAddRows = false;
            this.dataGridViewMarkets.AllowUserToDeleteRows = false;
            this.dataGridViewMarkets.AllowUserToOrderColumns = true;
            this.dataGridViewMarkets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMarkets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMarkets.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewMarkets.Name = "dataGridViewMarkets";
            this.dataGridViewMarkets.ReadOnly = true;
            this.dataGridViewMarkets.Size = new System.Drawing.Size(746, 486);
            this.dataGridViewMarkets.TabIndex = 0;
            // 
            // tabPageWallets
            // 
            this.tabPageWallets.Controls.Add(this.dataGridViewWallets);
            this.tabPageWallets.Location = new System.Drawing.Point(4, 22);
            this.tabPageWallets.Name = "tabPageWallets";
            this.tabPageWallets.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWallets.Size = new System.Drawing.Size(752, 492);
            this.tabPageWallets.TabIndex = 0;
            this.tabPageWallets.Text = "Wallets";
            this.tabPageWallets.UseVisualStyleBackColor = true;
            // 
            // tabPageOrders
            // 
            this.tabPageOrders.Location = new System.Drawing.Point(4, 22);
            this.tabPageOrders.Name = "tabPageOrders";
            this.tabPageOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOrders.Size = new System.Drawing.Size(752, 492);
            this.tabPageOrders.TabIndex = 1;
            this.tabPageOrders.Text = "Orders";
            this.tabPageOrders.UseVisualStyleBackColor = true;
            // 
            // dataGridViewWallets
            // 
            this.dataGridViewWallets.AllowUserToAddRows = false;
            this.dataGridViewWallets.AllowUserToDeleteRows = false;
            this.dataGridViewWallets.AllowUserToOrderColumns = true;
            this.dataGridViewWallets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWallets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWallets.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewWallets.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewWallets.Name = "dataGridViewWallets";
            this.dataGridViewWallets.ReadOnly = true;
            this.dataGridViewWallets.Size = new System.Drawing.Size(746, 486);
            this.dataGridViewWallets.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 557);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Project BITTER";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageMarkets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMarkets)).EndInit();
            this.tabPageWallets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWallets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageWallets;
        private System.Windows.Forms.TabPage tabPageOrders;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewMarkets;
        private System.Windows.Forms.TabPage tabPageMarkets;
        private System.Windows.Forms.DataGridView dataGridViewWallets;
    }
}

