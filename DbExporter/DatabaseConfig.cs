using System;
using System.Xml;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace DbExporter
{
    class DatabaseConfig
    {
        private XmlDocument configDoc;
        private ArrayList[] configs;
        private int index;
        private string msgTitle;
        private int DATABASES;

        public DatabaseConfig()
        {
            msgTitle = "Database configuration";

            configDoc = new XmlDocument();
            configs = new ArrayList[] { new ArrayList(), new ArrayList() };
            index = -1;

            try
            {
                configDoc.Load("databases.xml");

                XmlElement root = configDoc.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("/configuration/database");

                DATABASES = 2;

                int i = 0;
                foreach (XmlNode node in nodes)
                {
                    try
                    {
                        configs[i].Add(node["type"].InnerText);
                        configs[i].Add(node["host"].InnerText);
                        configs[i].Add(Convert.ToInt16(node["port"].InnerText));
                        configs[i].Add(Convert.ToBoolean(node["auth"].InnerText));
                        configs[i].Add(node["user"].InnerText);
                        configs[i].Add(node["pass"].InnerText);
                        i++;
                    }
                    catch (FormatException fe)
                    {
                        MessageBox.Show(fe.Message, msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("Could not find databases.xml\nUse of database import and export tools will fail.", msgTitle, MessageBoxButtons.OK, 
                MessageBoxIcon.Warning);
                Application.Exit();
                /*
                Index = 0;
                Type = "MongoDB";
                Host = "localhost";
                Port = 27017;
                Auth = false;
                Username = "none";
                Password = "none";
                Index = 1;
                Type = "MySQL";
                Host = "localhost";
                Port = 3306;
                Auth = true;
                Username = "root";
                Password = "toor";
                */
                //writeDatabaseConfigXML(); # Buggy for some reason; disable for now #
            }    
        }

        private void initializeEmpty()
        {
            for(int i = 0; i < DATABASES; i++)
            {
                configs[i] = new ArrayList() { "", "", 0, false, "", "" };
            }
        }

        private void writeDatabaseConfigXML()
        {
            XmlNode root = configDoc.CreateElement("configuration");
            configDoc.AppendChild(root);

            for(int i = 0; i < DATABASES; i++)
            {
                Index = i;
                XmlNode dbNode = configDoc.CreateElement("database");
                root.AppendChild(dbNode);

                XmlNode type = configDoc.CreateElement("type");
                type.InnerText = Type;
                dbNode.AppendChild(type);

                XmlNode host = configDoc.CreateElement("host");
                host.InnerText = Host;
                dbNode.AppendChild(host);

                XmlNode port = configDoc.CreateElement("port");
                port.InnerText = Port.ToString();
                dbNode.AppendChild(port);

                XmlNode auth = configDoc.CreateElement("auth");
                auth.InnerText = Auth.ToString();
                dbNode.AppendChild(auth);

                XmlNode user = configDoc.CreateElement("user");
                user.InnerText = Username;
                dbNode.AppendChild(user);

                XmlNode pass = configDoc.CreateElement("pass");
                pass.InnerText = Password;
                dbNode.AppendChild(pass);
            }   
            configDoc.Save("databases.xml");
        }

        public int Index
        {
            get { return index;  }
            set { index = value; }
        }

        public string Type
        {
            get { return configs[index][0].ToString(); }
            set { configs[index][0] = value; }
        }

        public string Host
        {
            get { return configs[index][1].ToString(); }
            set { configs[index][1] = value; }
        }

        public int Port
        {
            get { return Convert.ToInt16(configs[index][2]);  }
            set { configs[index][2] = value; }
        }

        public bool Auth
        {
            get { return Convert.ToBoolean(configs[index][3]); }
            set { configs[index][3] = value; }
        }

        public string Username
        {
            get { return configs[index][4].ToString(); }
            set { configs[index][4] = value; }
        }

        public string Password
        {
            get { return configs[index][5].ToString(); }
            set { configs[index][5] = value; }
        }
    }
}
