using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadCSV
{
    public partial class Sql_Conn_frm : Form
    {
        public Sql_Conn_frm()
        {
            InitializeComponent();

            ReadIni();
        }

        [DllImport("KERNEL32.DLL")] 
        private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);
        [DllImport("KERNEL32.DLL")] 
        private static extern uint GetPrivateProfileInt(string lpAppName, string lpKeyName, int nDefault, string lpFileName);
        [DllImport("kernel32.dll")] 
        static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        
        //string[,] iniValue = new string[2, 3];

        // Read
        public void ReadIni()
        {
            var curDir = Directory.GetCurrentDirectory();
            System.IO.StreamReader file = new System.IO.StreamReader(curDir + "/sql_config.ini");
            string line;
            Dictionary<string, string> configData = new Dictionary<string, string>();

            while ((line = file.ReadLine()) != null)
            {
                string[] data = line.Split(':');
                configData.Add(data[0].Trim(), data[1].Trim());
            }

            textBox1.Text = configData["Data Source"];
            textBox2.Text = configData["Initial Catalog"];
            textBox3.Text = configData["USER ID"];
            textBox4.Text = configData["Password"];
            
        }

        // Write
        private void save_btn_Click(object sender, EventArgs e)
        {

            // index err
           /*setIni("Data Source", "Data Source", textBox1.Text, "/sql_config.ini");
           setIni("Initial Catalog", "Initial Catalog", textBox1.Text, "/sql_config.ini");
           setIni("USER ID", "USER ID", textBox1.Text, "/sql_config.ini");
           setIni("Password", "Password", textBox1.Text, "/sql_config.ini");
*/



            var curDir = Directory.GetCurrentDirectory();
            System.IO.StreamWriter file = new System.IO.StreamWriter(curDir + "/sql_config.ini");
            string pathFile = file.ToString();

            Dictionary<string, string> configData = new Dictionary<string, string>();

            string[] lines = { "Data Source :" + textBox1.Text,
                               "Initial Catalog :" + textBox2.Text,
                               "USER ID :" + textBox3.Text,
                               "Password :" + textBox4.Text};

            File.WriteAllLines(Path.Combine(pathFile, "sql_config.ini"), lines);

            this.Close();
        }

/*
      
        private Boolean setIni(string IpAppName, string IpKeyName, string IpValue, string filePath)
        {
            try
            {
                string inifile = "/sql_config.ini"; //Path + File 
                WritePrivateProfileString(IpAppName, IpKeyName, IpValue, inifile); 
                return true; 
             } 
            catch (Exception ex) 
             { 
                    Console.WriteLine(ex.ToString()); return false; 
             }
            
        }*/



    }

}
