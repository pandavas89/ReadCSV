using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadCSV
{
    class Modify_strConn
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


        static string filePath = "/sql_config.ini";

        private string[,] ReadInIs()
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

            string[,] iniValue = new string[2, 3];

            iniValue[0, 0] = "Data Source";
            iniValue[0, 1] = "Initial Catalog";
            iniValue[0, 2] = "USER ID";
            iniValue[0, 3] = "Password";

            iniValue[1, 0] = configData["Data Source"];
            iniValue[1, 1] = configData["Initial Catalog"];
            iniValue[1, 2] = configData["USER ID"];
            iniValue[1, 3] = configData["Password"];

            return iniValue;
         }


        private void WriteIni(string[,] iniValue)
        {
            // WritePrivateProfileString(iniValue);
/*
            string docPath =
                Environment.GetFolderPath(Environment.SpecialFolder);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "/sql_config.ini")))*/



/*
            
            while ((line = file.WriteLine()) != null)
            {
                string[] data = line.Split(':');
                configData.Add(data[0].Trim(), data[1].Trim());
            }
*/






            /*var curDir = Directory.GetCurrentDirectory();
            System.IO.StreamReader file = new System.IO.StreamReader(curDir + "/sql_config.ini");
            string line;
            Dictionary<string, string> configData = new Dictionary<string, string>();

            while ((line = file.ReadLine()) != null)
            {
                string[] data = line.Split(':');
                configData.Add(data[0].Trim(), data[1].Trim());
            }
            strConn = "Data Source=" + configData["Data Source"] + ";";
            strConn = "Initial Catalog=" + configData["Initial Catalog"] + ";";
            strConn = "USER ID=" + configData["USER ID"] + ";";
            strConn = "Password" + configData["Password"] + ";";*/

            MessageBox.Show("수정되었습니다.");
        }




    }
}
