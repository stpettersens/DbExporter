using System;
using System.Collections;
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
        private bool saveCopy;
        private string separator;
        private string database;
        private string mongoExported;
        private string mySqlExported;
        private frmAbout frmAbout;
        private frmLogWindow frmLogWindow;
        private DatabaseConfig databaseConfig;
        private ModuleLoader moduleLoader;
        private const string version = "1.0";

        public frmDbExporter()
        {
            InitializeComponent();
            disableOptionalFeatures();
            tool = new string[] 
            { 
                "ccsv2mongo.exe", "csql2mongo.exe", "cmongo2sql.exe", "cmongo2csv.exe", 
                "ccsv2sql.exe", "csql2csv.exe", "mongoimport.exe", "mysql.exe"
            };
            arguments = new string[,] 
            { 
                { "-l", "-f", "-o", "-s ,", "", "", "", "" },
                { "-l", "-f", "-o", "", "",  "", "", ""},
                { "-l", "-f", "-o", "", "", "", "", "" },
                { "-l", "-f", "-o", "-s ,", "", "", "", ""},
                { "-l", "-f", "-o", "-s ,", "", "", "", ""},
                { "-l", "-f", "-o", "-s ,", "", "", "", ""},
                { "", "", "", "", "", "", "", ""},
                { "", "", "", "", "", "", "", ""}
            };
            separator = ",";
            database = "";
            mongoExported = "";
            selected = 0;
            frmAbout = new frmAbout();
            frmLogWindow = new frmLogWindow();
            databaseConfig = new DatabaseConfig();
            moduleLoader = new ModuleLoader();
            saveCopy = false;
            if(moduleLoader.ModulesEnabled) enableOptionalFeatures();
        }


        private void onFileChanged(object sender, FileSystemEventArgs e) 
        {
            MessageBox.Show("File was created!");
        }

        private void disableOptionalFeatures()
        {
            databaseToolStripMenuItem.Visible = false;
            mongoimportImportMongoDBJSONToMongoDBServerToolStripMenuItem.Visible = false;
            sqlImportIntoMySQLToolStripMenuItem.Visible = false;
            exportFromMySQLToolStripMenuItem.Visible = false;
            ExportMongoDBToolStripMenuItem.Visible = false;
            toolStripSeparator2.Visible = false;

            saveInputAsToolStripMenuItem.Visible = false; // !
        }

        private void enableOptionalFeatures()
        {
            moduleLoader.Index = 0;
            if(moduleLoader.Name == "mongoexport" && moduleLoader.Enabled)
            {
                databaseToolStripMenuItem.Visible = true;
                databaseToolStripMenuItem.Enabled = true;
                ExportMongoDBToolStripMenuItem.Visible = true;
            }
            moduleLoader.Index = 1;
            if(moduleLoader.Name == "mongoimport" && moduleLoader.Enabled)
            {
                toolStripSeparator2.Visible = true;
                mongoimportImportMongoDBJSONToMongoDBServerToolStripMenuItem.Visible = true;
                mongoimportImportMongoDBJSONToMongoDBServerToolStripMenuItem.Enabled = true;
            }
            moduleLoader.Index = 2;
            if(moduleLoader.Name == "mysqldump" && moduleLoader.Enabled)
            {
                databaseToolStripMenuItem.Visible = true;
                databaseToolStripMenuItem.Enabled = true;
                exportFromMySQLToolStripMenuItem.Visible = true;
            }
            moduleLoader.Index = 3;
            if(moduleLoader.Name == "mysql" && moduleLoader.Enabled)
            {
                toolStripSeparator2.Visible = true;
                sqlImportIntoMySQLToolStripMenuItem.Visible = true;
                sqlImportIntoMySQLToolStripMenuItem.Enabled = true;
            }
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
            exportFromMySQLToolStripMenuItem.Enabled = false;
            ExportMongoDBToolStripMenuItem.Enabled = false;
            mongoimportImportMongoDBJSONToMongoDBServerToolStripMenuItem.Checked = false;
            sqlImportIntoMySQLToolStripMenuItem.Checked = false;
            btnOutput.Enabled = true;
            grpConsole.Text = "Conversion output:";
            txtInput.Clear();
            txtOutput.Clear();
            txtConsole.Clear();
        }

        private void checkExists()
        {
            if (inputExists && selected != 6) btnConvert.Enabled = true;
            else btnConvert.Enabled = false;
        }

        private void writeFile(string file, ArrayList lines)
        {
            StreamWriter sw = new StreamWriter(file);
            foreach(string line in lines)
            {
                sw.WriteLine(line);
            }
            sw.Close();
        }

        private ArrayList readFile(string file)
        {
            StreamReader sr = new StreamReader(file);
            ArrayList lines = new ArrayList();
            while(!sr.EndOfStream)
            {
                lines.Add(sr.ReadLine());
            }
            sr.Close();
            return lines;
        }

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
            if (result == DialogResult.OK)
            {
                outputFile = saveFileDialog.FileName;
                txtOutput.Text = outputFile;
                checkExists();
                if (saveCopy)
                {
                    ArrayList lines = readFile(inputFile);
                    writeFile(outputFile, lines);
                    txtOutput.Text = "";
                    saveCopy = false;
                }
            }
        }

        private void saveInputAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = openFileDialog.Filter;
            saveFileDialog.Title = "Save Input As";
            saveCopy = true;
            btnOutput_Click(sender, e);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if(selected < 6)
            {
                arguments[selected, 1] = "-f " + inputFile;
                arguments[selected, 2] = "-o " + outputFile;
            }
            else if(selected == 6)
            {         
                string[] d = txtOutput.Text.Split(':');
                databaseConfig.Index = 0;
                arguments[selected, 1] = "-h " + databaseConfig.Host;
                arguments[selected, 2] = "-p " + databaseConfig.Port; 
                if(databaseConfig.Auth)
                {
                    arguments[selected, 3] = "-u " + databaseConfig.Username;
                    arguments[selected, 4] = "-p " + databaseConfig.Password;
                }
                arguments[selected, 5] = "-d " + d[0];
                arguments[selected, 6] = "-c " + d[1];
                arguments[selected, 7] = "/file:" + inputFile;
            }
            else
            {
                databaseConfig.Index = 1;
                arguments[selected, 1] = "-h " + databaseConfig.Host;
                arguments[selected, 2] = "-P " + databaseConfig.Port;
                arguments[selected, 3] = "-u " + databaseConfig.Username;
                arguments[selected, 4] = "-p" + databaseConfig.Password;
                arguments[selected, 5] = txtOutput.Text;
                arguments[selected, 6] = "";
                arguments[selected, 7] = "";
            }
            string[] args = new string[] 
            { 
                arguments[selected, 0], 
                arguments[selected, 1],
                arguments[selected, 2],
                arguments[selected, 3],
                arguments[selected, 4],
                arguments[selected, 5],
                arguments[selected, 6],
                arguments[selected, 7]
            };
            bool redirectIn = false;
            if (tool[selected] == "mysql.exe") redirectIn = true;
            Process proc = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = tool[selected],
                    Arguments = String.Join(" ", args),
                    UseShellExecute = false,
                    RedirectStandardInput = redirectIn,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
            exitToolStripMenuItem.Enabled = false;
            proc.Start();
            if (tool[selected] == "mysql.exe")
            {
                ArrayList lines = readFile(inputFile);
                foreach (string line in lines)
                {
                    proc.StandardInput.WriteLine(line);
                }
                proc.StandardInput.WriteLine("QUIT");
            }
            txtConsole.Clear();
            if(selected != 7)
            {
                while (!proc.StandardOutput.EndOfStream)
                {
                    txtConsole.AppendText(proc.StandardOutput.ReadLine() + "\n");
                }
            }
            if(selected == 6 || selected == 7)
            {
                while (!proc.StandardError.EndOfStream)
                {
                    txtConsole.AppendText(proc.StandardError.ReadLine() + "\n");
                }
                
            }
            exitToolStripMenuItem.Enabled = true;
            frmLogWindow.logEvent(tool[selected] + " " + proc.StartInfo.Arguments);
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
            exportFromMySQLToolStripMenuItem.Enabled = true;
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
            ExportMongoDBToolStripMenuItem.Enabled = true;
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
            ExportMongoDBToolStripMenuItem.Enabled = true;
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
            exportFromMySQLToolStripMenuItem.Enabled = true;
            btnConvert.Enabled = false;
        }

        private void mongoimportImportMongoDBJSONToMongoDBServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selected = 6;
            uncheckAll();
            lblInfo.Text = "Import a MongoDB JSON dump into a MongoDB server.";
            grpInput.Text = "Input MongoDB JSON";
            grpOutput.Text = "Destination database:collection";
            btnConvert.Text = "Import MongoDB JSON into MongoDB";
            openFileDialog.Filter = "MongoDB JSON dumps|*.json";
            btnOutput.Enabled = false;
            grpConsole.Text = "Importation output:";
            mongoimportImportMongoDBJSONToMongoDBServerToolStripMenuItem.Checked = true;
            ExportMongoDBToolStripMenuItem.Enabled = true;
            btnConvert.Enabled = false;
        }

        private void sqlImportIntoMySQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selected = 7;
            uncheckAll();
            lblInfo.Text = "Import a SQL dump into a MySQL server.";
            grpInput.Text = "Input SQL";
            grpOutput.Text = "Destination schema";
            btnConvert.Text = "Import SQL into MySQL";
            openFileDialog.Filter = "SQL dumps|*.sql";
            btnOutput.Enabled = false;
            sqlImportIntoMySQLToolStripMenuItem.Checked = true;
            exportFromMySQLToolStripMenuItem.Enabled = true;
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
            if (mongoDBOutputJSONAsArrayToolStripMenuItem.Checked)
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

        private void ExportFromMongoDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] d = new string[] { "", "" } ;
            string[] mongo = new string[] { "", "", "", "", "", "", "" };
            mongoExported = Interaction.InputBox("Enter MongoDB database and collection\n(e.g. mydb:collection):", "Export from MongoDB", mongoExported);

            try
            {
                d = mongoExported.Split(':');
                databaseConfig.Index = 0;
                mongo[0] = "-h " + databaseConfig.Host;
                mongo[1] = "-p " + databaseConfig.Port; 
                if(databaseConfig.Auth)
                {
                    mongo[2] = "-u " + databaseConfig.Username;
                    mongo[3] = "-p " + databaseConfig.Password;
                }
                mongo[4] = "-d " + d[0];
                mongo[5] = "-c " + d[1];
                mongo[6] = "/out:_exported.json";

                Process proc = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        FileName = "mongoexport.exe",
                        Arguments = String.Join(" ", mongo),
                        UseShellExecute = false,
                        RedirectStandardOutput = false,
                        CreateNoWindow = true
                    }
                };
                proc.Start();
                frmLogWindow.logEvent("mongoexport.exe " + proc.StartInfo.Arguments);
                txtInput.Text = "_exported.json";
                inputFile = txtInput.Text;
                inputExists = true;
                btnConvert.Enabled = true;
            }
            catch(Exception ex)
            {   
                if(ex.Message == "Index was outside the bounds of the array.")
                {
                    MessageBox.Show("You must delimit database from collection with :", "Export from MongoDB");
                }
            }
        }

        private void exportFromMySQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] d = new string[] { "", "" };
            string[] mySql = new string[] { "", "", "", "", "", "" };
            mySqlExported = Interaction.InputBox("Enter MySQL schema and table\n(e.g. myschema:table):",
            "Export from MySQL", mySqlExported);

            try
            {
                d = mySqlExported.Split(':');
                databaseConfig.Index = 1;
                mySql[0] = "-h " + databaseConfig.Host;
                mySql[1] = "-P " + databaseConfig.Port;
                mySql[2] = "-u " + databaseConfig.Username;
                mySql[3] = "-p" + databaseConfig.Password;
                mySql[4] = d[0];
                mySql[5] = d[1];

                Process proc = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        FileName = "mysqldump.exe",
                        Arguments = String.Join(" ", mySql),
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };
                proc.Start();
                ArrayList lines = new ArrayList();
                while (!proc.StandardOutput.EndOfStream)
                {
                    lines.Add(proc.StandardOutput.ReadLine());
                }
                writeFile("_exported.sql", lines);
                frmLogWindow.logEvent("mysqldump.exe " + proc.StartInfo.Arguments);
                txtInput.Text = "_exported.sql";
                inputFile = txtInput.Text;
                inputExists = true;
                btnConvert.Enabled = true;
            }
            catch(Exception ex)
            {
                if(ex.Message == "Index was outside the bounds of the array.")
                {
                    MessageBox.Show("You must delimit database from collection with :", "Export from MySQL");
                }
            }
        }

        private void logWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogWindow.ShowDialog();
        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {
            if (selected == 6)
            {
                if (txtOutput.Text.Length > 0 && txtOutput.Text.Contains(":"))
                {
                    btnConvert.Enabled = true;
                }
                else
                {
                    btnConvert.Enabled = false;
                }
            }
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            if (txtInput.Text.Length > 0 && txtOutput.Text.Length > 0)
            {
                btnConvert.Enabled = true;
            }
            else
            {
                btnConvert.Enabled = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fileSystemWatcher.EnableRaisingEvents = false;
            this.Close();
        }

        private void frmDbExporter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(File.Exists("_exported.json"))
            {
                File.Delete("_exported.json");
            }
            if(File.Exists("_exported.sql"))
            {
                File.Delete("_exported.sql");
            }
        }
    }
}
