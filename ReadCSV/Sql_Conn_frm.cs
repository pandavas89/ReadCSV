using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
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

        // text save
        private Dictionary<string, string> configData = new Dictionary<string, string>();

        // Read
        public string ReadIni()
        {            
            string line;
            var curDir = Directory.GetCurrentDirectory();
            
            using (System.IO.StreamReader file = new System.IO.StreamReader(curDir + "/sql_config.ini")) 
            {
                
                while ((line = file.ReadLine()) != null)
                {
                    string[] data = line.Split(':');
                    configData.Add(data[0].Trim(), data[1].Trim());
                }
            }

            textBox1.Text = configData["Data Source"];
            textBox2.Text = configData["Initial Catalog"];
            //textBox3.Text = configData["USER ID"];
            //textBox4.Text = configData["Password"];

            return line;
        }

        // Write
        private void save_btn_Click(object sender, EventArgs e)
        {
            var curDir = Directory.GetCurrentDirectory();
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(curDir + "/sql_config.ini")) //
                {
                file.WriteLine("{0} : {1}", "Data Source", textBox1.Text.ToString());
                file.WriteLine("{0} : {1}", "Initial Catalog", textBox2.Text.ToString());
                file.WriteLine("{0} : {1}", "USER ID", configData["USER ID"]);
                file.WriteLine("{0} : {1}", "Password", configData["Password"]);
            }
            this.Close();
        }


    }

}
