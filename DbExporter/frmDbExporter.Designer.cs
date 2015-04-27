namespace DbExporter
{
    partial class frmDbExporter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDbExporter));
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ccsv2mongoCSVToMongoDBJSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.csql2mongoSQLToMongoDBJSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmongo2sqlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmongo2csvMongoDBJSONToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ccsv2sqlCSVToSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.csql2csvSQLToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setSeparatorsseparatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBDefineDatabaseOrSchemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iSOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLNoCommentsnnocommentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mongoDBNoMongoTypesdateoidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mongoDBOutputJSONAsArrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblInfo = new System.Windows.Forms.Label();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.btnInput = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.grpOutput = new System.Windows.Forms.GroupBox();
            this.btnOutput = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.grpConsole = new System.Windows.Forms.GroupBox();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnConvert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.grpOutput.SuspendLayout();
            this.grpConsole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.SynchronizingObject = this;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(403, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputFileToolStripMenuItem,
            this.outputFileToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // inputFileToolStripMenuItem
            // 
            this.inputFileToolStripMenuItem.Name = "inputFileToolStripMenuItem";
            this.inputFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.inputFileToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.inputFileToolStripMenuItem.Text = "&Input...";
            this.inputFileToolStripMenuItem.Click += new System.EventHandler(this.inputFileToolStripMenuItem_Click);
            // 
            // outputFileToolStripMenuItem
            // 
            this.outputFileToolStripMenuItem.Name = "outputFileToolStripMenuItem";
            this.outputFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.outputFileToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.outputFileToolStripMenuItem.Text = "&Output...";
            this.outputFileToolStripMenuItem.Click += new System.EventHandler(this.outputFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ccsv2mongoCSVToMongoDBJSONToolStripMenuItem,
            this.csql2mongoSQLToMongoDBJSONToolStripMenuItem,
            this.cmongo2sqlToolStripMenuItem,
            this.cmongo2csvMongoDBJSONToCSVToolStripMenuItem,
            this.ccsv2sqlCSVToSQLToolStripMenuItem,
            this.csql2csvSQLToCSVToolStripMenuItem});
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.toolToolStripMenuItem.Text = "&Tool";
            // 
            // ccsv2mongoCSVToMongoDBJSONToolStripMenuItem
            // 
            this.ccsv2mongoCSVToMongoDBJSONToolStripMenuItem.Checked = true;
            this.ccsv2mongoCSVToMongoDBJSONToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ccsv2mongoCSVToMongoDBJSONToolStripMenuItem.Name = "ccsv2mongoCSVToMongoDBJSONToolStripMenuItem";
            this.ccsv2mongoCSVToMongoDBJSONToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.ccsv2mongoCSVToMongoDBJSONToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            this.ccsv2mongoCSVToMongoDBJSONToolStripMenuItem.Text = "ccsv2mongo (CSV to MongoDB JSON)";
            this.ccsv2mongoCSVToMongoDBJSONToolStripMenuItem.Click += new System.EventHandler(this.ccsv2mongoCSVToMongoDBJSONToolStripMenuItem_Click);
            // 
            // csql2mongoSQLToMongoDBJSONToolStripMenuItem
            // 
            this.csql2mongoSQLToMongoDBJSONToolStripMenuItem.Name = "csql2mongoSQLToMongoDBJSONToolStripMenuItem";
            this.csql2mongoSQLToMongoDBJSONToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.csql2mongoSQLToMongoDBJSONToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            this.csql2mongoSQLToMongoDBJSONToolStripMenuItem.Text = "csql2mongo (SQL to MongoDB JSON)";
            this.csql2mongoSQLToMongoDBJSONToolStripMenuItem.Click += new System.EventHandler(this.csql2mongoSQLToMongoDBJSONToolStripMenuItem_Click);
            // 
            // cmongo2sqlToolStripMenuItem
            // 
            this.cmongo2sqlToolStripMenuItem.Name = "cmongo2sqlToolStripMenuItem";
            this.cmongo2sqlToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.cmongo2sqlToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            this.cmongo2sqlToolStripMenuItem.Text = "cmongo2sql (MongoDB JSON to SQL)";
            this.cmongo2sqlToolStripMenuItem.Click += new System.EventHandler(this.cmongo2sqlToolStripMenuItem_Click);
            // 
            // cmongo2csvMongoDBJSONToCSVToolStripMenuItem
            // 
            this.cmongo2csvMongoDBJSONToCSVToolStripMenuItem.Name = "cmongo2csvMongoDBJSONToCSVToolStripMenuItem";
            this.cmongo2csvMongoDBJSONToCSVToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.cmongo2csvMongoDBJSONToCSVToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            this.cmongo2csvMongoDBJSONToCSVToolStripMenuItem.Text = "cmongo2csv (MongoDB JSON to CSV)";
            this.cmongo2csvMongoDBJSONToCSVToolStripMenuItem.Click += new System.EventHandler(this.cmongo2csvMongoDBJSONToCSVToolStripMenuItem_Click);
            // 
            // ccsv2sqlCSVToSQLToolStripMenuItem
            // 
            this.ccsv2sqlCSVToSQLToolStripMenuItem.Name = "ccsv2sqlCSVToSQLToolStripMenuItem";
            this.ccsv2sqlCSVToSQLToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
            this.ccsv2sqlCSVToSQLToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            this.ccsv2sqlCSVToSQLToolStripMenuItem.Text = "ccsv2sql (CSV to SQL)";
            this.ccsv2sqlCSVToSQLToolStripMenuItem.Click += new System.EventHandler(this.ccsv2sqlCSVToSQLToolStripMenuItem_Click);
            // 
            // csql2csvSQLToCSVToolStripMenuItem
            // 
            this.csql2csvSQLToCSVToolStripMenuItem.Name = "csql2csvSQLToCSVToolStripMenuItem";
            this.csql2csvSQLToCSVToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D6)));
            this.csql2csvSQLToCSVToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            this.csql2csvSQLToCSVToolStripMenuItem.Text = "csql2csv (SQL to CSV)";
            this.csql2csvSQLToCSVToolStripMenuItem.Click += new System.EventHandler(this.csql2csvSQLToCSVToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setSeparatorsseparatorToolStripMenuItem,
            this.dBDefineDatabaseOrSchemaToolStripMenuItem,
            this.iSOToolStripMenuItem,
            this.sQLNoCommentsnnocommentsToolStripMenuItem,
            this.mongoDBNoMongoTypesdateoidToolStripMenuItem,
            this.mongoDBOutputJSONAsArrayToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "O&ptions";
            // 
            // setSeparatorsseparatorToolStripMenuItem
            // 
            this.setSeparatorsseparatorToolStripMenuItem.Name = "setSeparatorsseparatorToolStripMenuItem";
            this.setSeparatorsseparatorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.setSeparatorsseparatorToolStripMenuItem.Size = new System.Drawing.Size(441, 22);
            this.setSeparatorsseparatorToolStripMenuItem.Text = "CSV: Set &separator (-s, --separator)";
            this.setSeparatorsseparatorToolStripMenuItem.Click += new System.EventHandler(this.setSeparatorsseparatorToolStripMenuItem_Click);
            // 
            // dBDefineDatabaseOrSchemaToolStripMenuItem
            // 
            this.dBDefineDatabaseOrSchemaToolStripMenuItem.Enabled = false;
            this.dBDefineDatabaseOrSchemaToolStripMenuItem.Name = "dBDefineDatabaseOrSchemaToolStripMenuItem";
            this.dBDefineDatabaseOrSchemaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.dBDefineDatabaseOrSchemaToolStripMenuItem.Size = new System.Drawing.Size(441, 22);
            this.dBDefineDatabaseOrSchemaToolStripMenuItem.Text = "SQL: Define &database or schema (-d, --db) ";
            this.dBDefineDatabaseOrSchemaToolStripMenuItem.Click += new System.EventHandler(this.dBDefineDatabaseOrSchemaToolStripMenuItem_Click);
            // 
            // iSOToolStripMenuItem
            // 
            this.iSOToolStripMenuItem.Enabled = false;
            this.iSOToolStripMenuItem.Name = "iSOToolStripMenuItem";
            this.iSOToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.iSOToolStripMenuItem.Size = new System.Drawing.Size(441, 22);
            this.iSOToolStripMenuItem.Text = "ISO 8601: Use &Z Timezone (-t, --tz)";
            this.iSOToolStripMenuItem.Click += new System.EventHandler(this.iSOToolStripMenuItem_Click);
            // 
            // sQLNoCommentsnnocommentsToolStripMenuItem
            // 
            this.sQLNoCommentsnnocommentsToolStripMenuItem.Enabled = false;
            this.sQLNoCommentsnnocommentsToolStripMenuItem.Name = "sQLNoCommentsnnocommentsToolStripMenuItem";
            this.sQLNoCommentsnnocommentsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.sQLNoCommentsnnocommentsToolStripMenuItem.Size = new System.Drawing.Size(441, 22);
            this.sQLNoCommentsnnocommentsToolStripMenuItem.Text = "SQL: &No comments (-n, --no-comments)";
            this.sQLNoCommentsnnocommentsToolStripMenuItem.Click += new System.EventHandler(this.sQLNoCommentsnnocommentsToolStripMenuItem_Click);
            // 
            // mongoDBNoMongoTypesdateoidToolStripMenuItem
            // 
            this.mongoDBNoMongoTypesdateoidToolStripMenuItem.Name = "mongoDBNoMongoTypesdateoidToolStripMenuItem";
            this.mongoDBNoMongoTypesdateoidToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.T)));
            this.mongoDBNoMongoTypesdateoidToolStripMenuItem.Size = new System.Drawing.Size(441, 22);
            this.mongoDBNoMongoTypesdateoidToolStripMenuItem.Text = "MongoDB: No $date or $oid &Types (-n, --no-mongo-types)";
            this.mongoDBNoMongoTypesdateoidToolStripMenuItem.Click += new System.EventHandler(this.mongoDBNoMongoTypesdateoidToolStripMenuItem_Click);
            // 
            // mongoDBOutputJSONAsArrayToolStripMenuItem
            // 
            this.mongoDBOutputJSONAsArrayToolStripMenuItem.Name = "mongoDBOutputJSONAsArrayToolStripMenuItem";
            this.mongoDBOutputJSONAsArrayToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.mongoDBOutputJSONAsArrayToolStripMenuItem.Size = new System.Drawing.Size(441, 22);
            this.mongoDBOutputJSONAsArrayToolStripMenuItem.Text = "MongoDB: Output JSON as &Array (-a, --array)";
            this.mongoDBOutputJSONAsArrayToolStripMenuItem.Click += new System.EventHandler(this.mongoDBOutputJSONAsArrayToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.aboutToolStripMenuItem.Text = "&About DbExporter...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(23, 99);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(228, 13);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "Convert a CSV file to a MongoDB JSON dump.";
            this.lblInfo.Click += new System.EventHandler(this.label1_Click);
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.btnInput);
            this.grpInput.Controls.Add(this.txtInput);
            this.grpInput.Location = new System.Drawing.Point(26, 130);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(352, 75);
            this.grpInput.TabIndex = 3;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Input CSV";
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(287, 29);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(52, 20);
            this.btnInput.TabIndex = 1;
            this.btnInput.Text = "...";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(6, 30);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(275, 20);
            this.txtInput.TabIndex = 0;
            // 
            // grpOutput
            // 
            this.grpOutput.Controls.Add(this.btnOutput);
            this.grpOutput.Controls.Add(this.txtOutput);
            this.grpOutput.Location = new System.Drawing.Point(26, 228);
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.Size = new System.Drawing.Size(352, 75);
            this.grpOutput.TabIndex = 4;
            this.grpOutput.TabStop = false;
            this.grpOutput.Text = "Output MongoDB JSON";
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(287, 29);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(52, 20);
            this.btnOutput.TabIndex = 1;
            this.btnOutput.Text = "...";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(6, 30);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(275, 20);
            this.txtOutput.TabIndex = 0;
            // 
            // grpConsole
            // 
            this.grpConsole.Controls.Add(this.txtConsole);
            this.grpConsole.Location = new System.Drawing.Point(26, 318);
            this.grpConsole.Name = "grpConsole";
            this.grpConsole.Size = new System.Drawing.Size(352, 142);
            this.grpConsole.TabIndex = 5;
            this.grpConsole.TabStop = false;
            this.grpConsole.Text = "Conversion output:";
            // 
            // txtConsole
            // 
            this.txtConsole.Enabled = false;
            this.txtConsole.Location = new System.Drawing.Point(6, 20);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(340, 116);
            this.txtConsole.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(354, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "CSV files|*.csv";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "MongoDB JSON dumps|*.json";
            // 
            // btnConvert
            // 
            this.btnConvert.Enabled = false;
            this.btnConvert.Location = new System.Drawing.Point(26, 466);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(352, 44);
            this.btnConvert.TabIndex = 7;
            this.btnConvert.Text = "Convert CSV to MongoDB JSON...";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // frmDbExporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 529);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grpConsole);
            this.Controls.Add(this.grpOutput);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "frmDbExporter";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "DbExporter";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpOutput.ResumeLayout(false);
            this.grpOutput.PerformLayout();
            this.grpConsole.ResumeLayout(false);
            this.grpConsole.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.FileSystemWatcher fileSystemWatcher;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ccsv2mongoCSVToMongoDBJSONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ccsv2sqlCSVToSQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem csql2csvSQLToCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem csql2mongoSQLToMongoDBJSONToolStripMenuItem;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.GroupBox grpOutput;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.GroupBox grpConsole;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmongo2sqlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setSeparatorsseparatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iSOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQLNoCommentsnnocommentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmongo2csvMongoDBJSONToCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBDefineDatabaseOrSchemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mongoDBNoMongoTypesdateoidToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mongoDBOutputJSONAsArrayToolStripMenuItem;
    }
}

