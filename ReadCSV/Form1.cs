using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadCSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        public static String file_path = null;

        private void Find_file_btn(object sender, EventArgs e)
        {
            textBox1.Clear();

            openFileDialog1.InitialDirectory = "C:\\";  // 경로 지정

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file_path = openFileDialog1.FileName;   // 풀 경로를 불러와 저장

                textBox1.Text = file_path.Split('\\')[file_path.Split('\\').Length - 1];

            }

        }


        public void DB_btn(object sender, EventArgs e)
        {
            //string[,] keep = new string[0, 0];

            List<string> d_name = new List<string>();
            List<string> d_pno = new List<string>();
            List<string> d_mf = new List<string>();


            StreamReader sr = new StreamReader(file_path);

            string pline = sr.ReadLine();
            string[] ldata = pline.Split(',');

            // 첫 줄 예외
            int nameIdx = 0;
            int pNoIdx = 0;
            int sNoIdx = 0;
            for (int i = 0; i < ldata.Length; i++)
            {
                if (ldata[i] == "사용자이름")
                {
                    nameIdx = i;
                }
                else if (ldata[i] == "핸드폰번호")
                {
                    pNoIdx = i;
                }
                else if (ldata[i] == "좌석번호")
                {
                    sNoIdx = i;
                }
            }
            //
            while (!sr.EndOfStream)
            {
                // 한 줄씩 읽어온다.
                string line = sr.ReadLine();
                // , 기준으로 분리
                string[] data = line.Split(',');
                // 출력   1 사용자이름, 4 전화번호, 7 좌석번호(성별)
                //Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}", data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7]);

                //성별 분류
                string seatAndSex = data[sNoIdx];
                string sex = "F";

                if (seatAndSex.Substring(0, 2) == "남자")
                {
                    sex = "M";
                }

                // 좌석 번호
                //string sNo = seatAndSex.Split(' ')[1].Substring(0, seatAndSex.Split(' ')[1].Length - 1);

                //string[] input = new string[] { data[nameIdx], data[pNoIdx].Substring(4, 9).Remove(4, 1), sex }; 
                // 이름, 전화번호, 성별
                // 전화번호 5자리, - 지움 처리

                // 입력

                d_name.Add(data[nameIdx]);
                d_pno.Add(data[pNoIdx].Substring(4, 9).Remove(4, 1));
                d_mf.Add(sex);

            }
            //
            var Sql_Conn = new Sql_Conn();
            Sql_Conn.AddData(d_name, d_pno, d_mf);
            //
            MessageBox.Show("while done");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
