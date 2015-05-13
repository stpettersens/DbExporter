using System;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Collections;

namespace DbExporter
{
    class ModuleLoader
    {
        private XmlDocument modulesDoc;
        private ArrayList[] modules;
        private int index;
        private string msgTitle;
        private int MODULES;
        private bool enabled;

        public ModuleLoader()
        {
            msgTitle = "Modules configuration";

            modulesDoc = new XmlDocument();
            modules = new ArrayList[] { new ArrayList(), new ArrayList(), new ArrayList(), new ArrayList() };
            ModulesEnabled = true;
            Index = 0;

            try
            {
                modulesDoc.Load("modules.xml");

                XmlElement root = modulesDoc.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("/configuration/module");

                MODULES = 2;

                int i = 0;
                foreach (XmlNode node in nodes)
                {
                    try
                    {
                        //MessageBox.Show(node["name"].InnerText);
                        //MessageBox.Show(node["enabled"].InnerText);
                        modules[i].Add(node["name"].InnerText);
                        modules[i].Add(Convert.ToBoolean(node["enabled"].InnerText));
                        //MessageBox.Show(i.ToString());
                        i++;

                    }
                    catch (FormatException fe)
                    {
                        MessageBox.Show(fe.Message, msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                ModulesEnabled = false;
            }
        }

        private void initializeEmpty()
        {
            for(int i = 0; i < MODULES; i++)
            {
                modules[i] = new ArrayList() { 0, 0 };
            }
        }

        public bool ModulesEnabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public string Name
        {
            get { return modules[index][0].ToString(); }
            set { modules[index][0] = value; }
        }

        public bool Enabled
        {
            get { return Convert.ToBoolean(modules[index][1]); }
            set { modules[index][1] = value; }
        }

    }
}   
