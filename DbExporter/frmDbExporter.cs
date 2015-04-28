using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace DbExporter
{

    public partial class frmDbExporter : Form
    {
        private string[] tool;
        private string[,] arguments;
        private int selected;
        private string inputFile;
        private string outputFile;
        private bool inputExists;
        private string separator;
        private string database;
        private frmAbout frmAbout;
        private const string version = "1.0";

        public frmDbExporter()
        {
            InitializeComponent();
            tool = new string[] { "ccsv2mongo", "csql2mongo", "cmongo2sql", "cmongo2csv", "ccsv2sql", "csql2csv" };
            arguments = new string[,] 
            { 
                { "-l", "-f", "-o", "-s ,", "", "", "" },
                { "-l", "-f", "-o", "", "",  "", ""},
                { "-l", "-f", "-o", "", "", "", "" },
                { "-l", "-f", "-o", "-s ,", "", "", ""},
                { "-l", "-f", "-o", "-s ,", "", "", ""},
                { "-l", "-f", "-o", "-s ,", "", "", ""},
            };
            separator = ",";
            database = "";
            selected = 0;
            frmAbout = new frmAbout();
        }

        private void onFileChanged(object sender, FileSystemEventArgs e) 
        {
            MessageBox.Show("File was created!");
        }

        private void uncheckAll() 
        {
            ccsv2mongoCSVToMongoDBJSONToolStripMenuItem.Checked = false;
            csql2mongoSQLToMongoDBJSONToolStripMenuItem.Checked = false;
            cmongo2sqlToolStripMenuItem.Checked = false;
            cmongo2csvMongoDBJSONToCSVToolStripMenuItem.Checked = false;
            ccsv2sqlCSVToSQLToolStripMenuItem.Checked = false;
            csql2csvSQLToCSVToolStripMenuItem.Checked = false;
            setSeparatorsseparatorToolStripMenuItem.Enabled = false;
            iSOToolStripMenuItem.Enabled = false;
            iSOToolStripMenuItem.Checked = false;
            sQLNoCommentsnnocommentsToolStripMenuItem.Enabled = false;
            sQLNoCommentsnnocommentsToolStripMenuItem.Checked = false;
            dBDefineDatabaseOrSchemaToolStripMenuItem.Enabled = false;
            mongoDBNoMongoTypesdateoidToolStripMenuItem.Enabled = false;
            mongoDBNoMongoTypesdateoidToolStripMenuItem.Checked = false;
            mongoDBOutputJSONAsArrayToolStripMenuItem.Enabled = false;
            mongoDBOutputJSONAsArrayToolStripMenuItem.Checked = false;
            txtInput.Clear();
            txtOutput.Clear();
            txtConsole.Clear();
        }

        private void checkExists()
        {
            if (inputExists) btnConvert.Enabled = true;
            else btnConvert.Enabled= false;
        }

        private void label1_Click(object sender, EventArgs e) {}

        private void btnInput_Click(object sender, EventArgs e)
        { 
            DialogResult result = openFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                inputFile = openFileDialog.FileName;
                txtInput.Text = inputFile;
                if (File.Exists(inputFile)) inputExists = true;
                else inputExists = false;
                checkExists();
            }
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                outputFile = saveFileDialog.FileName;
                txtOutput.Text = outputFile;
                checkExists();
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            arguments[selected, 1] = "-f " + inputFile;
            arguments[selected, 2] = "-o " + outputFile;
            string[] args = new string[] 
            { 
                arguments[selected, 0], 
                arguments[selected, 1],
                arguments[selected, 2],
                arguments[selected, 3],
                arguments[selected, 4],
                arguments[selected, 5],
                arguments[selected, 6]
            };
            Process proc = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = tool[selected] + ".exe",
                    Arguments = String.Join(" ", args),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            exitToolStripMenuItem.Enabled = false;
            proc.Start();
            txtConsole.Clear();
            //txtConsole.AppendText(proc.StartInfo.Arguments);
            while (!proc.StandardOutput.EndOfStream)
            {
                txtConsole.AppendText(proc.StandardOutput.ReadLine() + "\n");
            }
            exitToolStripMenuItem.Enabled = true;
            /*fileSystemWatcher.Path = Path.GetDirectoryName(outputFile);
            fileSystemWatcher.Filter = Path.GetFileName(outputFile);
            fileSystemWatcher.NotifyFilter = NotifyFilters.FileName;
            fileSystemWatcher.Changed += new FileSystemEventHandler(onFileChanged);
            fileSystemWatcher.Created += new FileSystemEventHandler(onFileChanged);
            fileSystemWatcher.EnableRaisingEvents = true;*/
        }

        private void ccsv2mongoCSVToMongoDBJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selected = 0;
            uncheckAll();
            lblInfo.Text = "Convert a CSV file to a MongoDB JSON dump.";
            grpInput.Text = "Input CSV";
            grpOutput.Text = "Output MongoDB JSON";
            btnConvert.Text = "Convert CSV to MongoDB JSON...";
            openFileDialog.Filter = "CSV files|*.csv";
            saveFileDialog.Filter = "MongoDB JSON dumps|*.json";
            ccsv2mongoCSVToMongoDBJSONToolStripMenuItem.Checked = true;
            setSeparatorsseparatorToolStripMenuItem.Enabled = true;
            mongoDBNoMongoTypesdateoidToolStripMenuItem.Enabled = true;
            mongoDBOutputJSONAsArrayToolStripMenuItem.Enabled = true;
            btnConvert.Enabled = false;
        }

        private void csql2mongoSQLToMongoDBJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selected = 1;
            uncheckAll();
            lblInfo.Text = "Convert a SQL dump to a MongoDB JSON dump.";
            grpInput.Text = "Input SQL";
            grpOutput.Text = "Output MongoDB JSON";
            btnConvert.Text = "Convert SQL to MongoDB JSON...";
            openFileDialog.Filter = "SQL dumps|*.sql";
            saveFileDialog.Filter = "MongoDB JSON dumps|*.json";
            csql2mongoSQLToMongoDBJSONToolStripMenuItem.Checked = true;
            iSOToolStripMenuItem.Enabled = true;
            mongoDBNoMongoTypesdateoidToolStripMenuItem.Enabled = true;
            mongoDBOutputJSONAsArrayToolStripMenuItem.Enabled = true;
            btnConvert.Enabled = false;
        }

        private void cmongo2sqlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selected = 2;
            uncheckAll();
            lblInfo.Text = "Convert a MongoDB JSON dump to a SQL dump.";
            grpInput.Text = "Input MongoDB JSON";
            grpOutput.Text = "Output SQL";
            btnConvert.Text = "Convert MongoDB JSON to SQL...";
            openFileDialog.Filter = "MongoDB JSON dumps|*.json";
            saveFileDialog.Filter = "SQL dumps|*.sql";
            cmongo2sqlToolStripMenuItem.Checked = true;
            sQLNoCommentsnnocommentsToolStripMenuItem.Enabled = true;
            dBDefineDatabaseOrSchemaToolStripMenuItem.Enabled = true;
            btnConvert.Enabled = false;
        }

        private void cmongo2csvMongoDBJSONToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selected = 3;
            uncheckAll();
            lblInfo.Text = "Convert a MongoDB JSON dump to a CSV file.";
            grpInput.Text = "Input MongoDB JSON";
            grpOutput.Text = "Output CSV or TSV";
            btnConvert.Text = "Convert MongoDB JSON to CSV...";
            openFileDialog.Filter = "MongoDB JSON dumps|*.json";
            saveFileDialog.Filter = "CSV files|*.csv|TSV files|*.tsv";
            cmongo2csvMongoDBJSONToCSVToolStripMenuItem.Checked = true;
            setSeparatorsseparatorToolStripMenuItem.Enabled = true;
            btnConvert.Enabled = false;
        }

        private void ccsv2sqlCSVToSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selected = 4;
            uncheckAll();
            lblInfo.Text = "Convert a CSV file to a SQL dump.";
            grpInput.Text = "Input CSV";
            grpOutput.Text = "Output SQL";
            btnConvert.Text = "Convert CSV to SQL...";
            openFileDialog.Filter = "CSV files|*.csv";
            saveFileDialog.Filter = "SQL dumps|*.sql";
            ccsv2sqlCSVToSQLToolStripMenuItem.Checked = true;
            setSeparatorsseparatorToolStripMenuItem.Enabled = true;
            sQLNoCommentsnnocommentsToolStripMenuItem.Enabled = true;
            dBDefineDatabaseOrSchemaToolStripMenuItem.Enabled = true;
            btnConvert.Enabled = false;
        }

        private void csql2csvSQLToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selected = 5;
            uncheckAll();
            lblInfo.Text = "Convert a SQL dump to a CSV file.";
            grpInput.Text = "Input SQL";
            grpOutput.Text = "Output CSV or TSV";
            btnConvert.Text = "Convert SQL to CSV...";
            openFileDialog.Filter = "SQL dumps|*.sql";
            saveFileDialog.Filter = "CSV files|*.csv|TSV files|*.tsv";
            csql2csvSQLToCSVToolStripMenuItem.Checked = true;
            setSeparatorsseparatorToolStripMenuItem.Enabled = true;
            btnConvert.Enabled = false;
        }

        private void inputFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnInput_Click(sender, e);
        }

        private void outputFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnOutput_Click(sender, e);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout.ShowDialog();
        }

        private void setSeparatorsseparatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            separator = Interaction.InputBox("Enter separator character(s) for CSV:", "Set separator", separator);
            if (separator.Length > 0)
            {
                arguments[selected, 3] = "-s " + separator;
            }
            else
            {
                arguments[selected, 3] = "";
            }
        }

        private void iSOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iSOToolStripMenuItem.Checked)
            {
                arguments[selected, 4] = "";
                iSOToolStripMenuItem.Checked = false;
            }
            else
            {
                arguments[selected, 4] = "-t";
                iSOToolStripMenuItem.Checked = true;
            }     
        }

        private void sQLNoCommentsnnocommentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sQLNoCommentsnnocommentsToolStripMenuItem.Checked)
            {
                arguments[selected, 5] = "";
                sQLNoCommentsnnocommentsToolStripMenuItem.Checked = false;
            }
            else
            {
                arguments[selected, 5] = "-n";
                sQLNoCommentsnnocommentsToolStripMenuItem.Checked = true;
            }
        }

        private void dBDefineDatabaseOrSchemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.warn)
            {
                MessageBox.Show("Don't use this option for SQLite.", "Compatibility warning");
                Properties.Settings.Default.warn = false;
                Properties.Settings.Default.Save();
            }
            database = Interaction.InputBox("Enter database or schema name for SQL:", "Define database or schema", database);
            if (database.Length > 0)
            {
                arguments[selected, 4] = "-d " + database;
            }
            else
            {
                arguments[selected, 4] = "";
            }
        }

        private void mongoDBNoMongoTypesdateoidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(mongoDBNoMongoTypesdateoidToolStripMenuItem.Checked)
            {
                arguments[selected, 5] = "";
                mongoDBNoMongoTypesdateoidToolStripMenuItem.Checked = false;
            }
            else
            {
                arguments[selected, 5] = "-n";
                mongoDBNoMongoTypesdateoidToolStripMenuItem.Checked = true;
            }
        }

        private void mongoDBOutputJSONAsArrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(mongoDBOutputJSONAsArrayToolStripMenuItem.Checked)
            {
                arguments[selected, 6] = "";
                mongoDBOutputJSONAsArrayToolStripMenuItem.Checked = false;
            }
            else
            {
                arguments[selected, 6] = "-a";
                mongoDBOutputJSONAsArrayToolStripMenuItem.Checked = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fileSystemWatcher.EnableRaisingEvents = false;
            this.Close();
        }
    }
}
