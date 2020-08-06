using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
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
        }

        // Read
        public async void ReadIni(object sender, EventArgs e)
        {
            /*
                        try
                        {
                            using (var sr = new StreamReader("/sql_config.ini"))
                            {
                                // 선언 불가
                                ResultBlock.Text = await sr.ReadToEndAsync();
                            }
                        }*/
            try
            {
                var curDir = Directory.GetCurrentDirectory();
                System.IO.StreamReader file = new System.IO.StreamReader(curDir + "/sql_config.ini");
                // ResultBlock.Text = await sr.ReadToEndAsync(); // 비동기식 예외 처리
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
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        /*// Read
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
            
        }*/

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

            //Dictionary<string, string> configData = new Dictionary<string, string>();

            /*string[] lines = { "Data Source :" + textBox1.Text.ToString(),
                               "Initial Catalog :" + textBox2.Text.ToString(),
                               "USER ID :" + textBox3.Text.ToString(),
                               "Password :" + textBox4.Text.ToString() };*/
            string lines = "Data Source :" + textBox1.Text.ToString()
                            + Environment.NewLine +
                           "Initial Catalog :" + textBox2.Text.ToString()
                            + Environment.NewLine + 
                           "USER ID :" + textBox3.Text.ToString()
                            + Environment.NewLine + 
                           "Password :" + textBox4.Text.ToString() ;

            File.AppendAllText(Path.Combine(pathFile, "sql_config.ini"), lines);
            //File.WriteAllLines();

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
