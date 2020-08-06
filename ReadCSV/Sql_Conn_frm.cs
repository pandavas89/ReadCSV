﻿using System;
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

        static async Task Main()
        {
            await ReadAndDisplayFilesAsync();
        }

        static async Task ReadAndDisplayFilesAsync()
        {
            String filename = "sql_config.ini";
            Char[] buffer;

            using (var sr = new StreamReader(filename))
            {
                buffer = new Char[(int)sr.BaseStream.Length];
                await sr.ReadAsync(buffer, 0, (int)sr.BaseStream.Length);
            }

            Console.WriteLine(new String(buffer));
        }


        // Read
        public void ReadIni(object sender, EventArgs e)
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
            //textBox3.Text = configData["USER ID"];
            //textBox4.Text = configData["Password"];

            Show();

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


            //File.AppendText(Path.Combine(pathFile, "sql_config.ini"), configData);
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
