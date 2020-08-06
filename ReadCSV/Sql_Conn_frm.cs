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

        // Read
        public void ReadIni()
        {
            var curDir = Directory.GetCurrentDirectory();
            Dictionary<string, string> configData = new Dictionary<string, string>();
            using (System.IO.StreamReader file = new System.IO.StreamReader(curDir + "/sql_config.ini")) 
            {
                string line;
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

        }

        public async Task CopyFilesAsync(StreamReader Source, StreamWriter Destinaion)
        {
            char[] buffer = new char[0x1000];
            int numRead;
            while ((numRead = await Source.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                await Destinaion.WriteAsync(buffer, 0, numRead);
            }
        }

        // Write
        private void save_btn_Click(object sender, EventArgs e)
        {

            try
            {
                var curDir = Directory.GetCurrentDirectory();
                System.IO.StreamWriter file = new System.IO.StreamWriter(curDir + "/sql_config.ini");
                //string line;
                Dictionary<string, string> configData = new Dictionary<string, string>();

                configData.Add("Data Source", textBox1.Text.ToString());
                configData.Add("Initial Catalog", textBox2.Text.ToString());
                                
                foreach ( var entry in configData)
                {
                    file.WriteLine("{0} : {1}", entry.Key, entry.Value);
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Close();
        }


    }

}
