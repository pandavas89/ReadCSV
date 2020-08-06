using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Text.RegularExpressions;
using System.Globalization;

namespace ReadCSV
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        public static Sql_Conn_frm Sql_Conn_Frm = new Sql_Conn_frm();

        private void Find_file_btn(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\";  // 경로 지정
            openFileDialog1.ShowDialog();
        }

        public void DB_btn(object sender, EventArgs e)
        {
            int totalLines = rawCsvTB.Lines.Count();
            int headerLines = (int)firstRowNUD.Value;
            int footerLines = (int)lastRowNUD.Value;
            string headerCheckText = String.Format("다음의 열이 헤더 칼럼으로 선택됩니다 : \n{0}", rawCsvTB.Lines[headerLines]);
            MessageBox.Show(headerCheckText);
            string footerTexts = "";
            for (int i = 0; i < footerLines; i++)
            {
                footerTexts += rawCsvTB.Lines[totalLines - footerLines + i];
            }
            string footerCheckText = String.Format("다음의 열은 데이터로 반영되지 않습니다 : \n{0}", footerTexts);
            MessageBox.Show(footerCheckText);

            var result = MessageBox.Show("이대로 데이터를 파싱합니까?", "확인", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes) 
            {
                for (int i = 0; i < totalLines; i++) 
                {
                    if (i == headerLines)
                    {
                        string[] headerData = Regex.Split(rawCsvTB.Lines[i], ",(?=(?:[^']*'[^']*')*[^']*$)");
                        int idx = 0;
                        foreach (string header in headerData)
                        {
                            DataGridViewColumn column = new DataGridViewTextBoxColumn();
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            column.HeaderText = header;
                            csvDGV.Columns.Add(column);
                            if (header.Contains("사용자"))
                            {
                                colName.Value = idx;
                            }
                            else if (header.Contains("폰"))
                            {
                                colPNo.Value = idx;
                            }
                            else if (header.Contains("좌석"))
                            {
                                colSeatAndSex.Value = idx;
                            }
                            idx += 1;
                        }
                    }
                    else if (i > headerLines && i < totalLines - footerLines) 
                    {
                        string[] contentData = rawCsvTB.Lines[i].Split(',');
                        csvDGV.Rows.Add(contentData);
                    }
                }
            }

            /*List<string> d_name = new List<string>();
            List<string> d_pno = new List<string>();
            List<string> d_mf = new List<string>();*/
            
            /*
            string pline = sr.ReadLine();
            string[] ldata = pline.Split(',');
            for (int i = 0; i < ldata.Length; i++)
            {
                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                column.HeaderText = ldata[i];
                csvDGV.Columns.Add(column);
            }

            // 첫 줄 예외
            int nameIdx = 0;
            int pNoIdx = 0;
            int sNoIdx = 0;
            for (int i = 0; i < ldata.Length; i++)
            {
                
            }
            //
            while (!sr.EndOfStream)
            {
                // 한 줄씩 읽어온다.
                string line = sr.ReadLine();
                // , 기준으로 분리
                string[] data = line.Split(',');
                // 출력   1 사용자이름, 4 전화번호, 7 좌석번호(성별)

                csvDGV.Rows.Add(data);
                //성별 분류
                string seatAndSex = data[sNoIdx];
                string seatNo = seatAndSex.Substring(5, seatAndSex.Length - 6);
                string sex = "F";

                if (seatAndSex.Substring(0, 2) == "남자")
                {
                    sex = "M";
                }

                d_name.Add(data[nameIdx]);
                d_pno.Add(data[pNoIdx].Substring(4, 9).Remove(4, 1));
                d_mf.Add(sex);
                string[] strs = new string[] { data[nameIdx], data[pNoIdx].Substring(4, 9).Remove(4, 1), sex, seatNo };
                userDataDGV.Rows.Add(strs);

            }
            var Sql_Conn = new Sql_Conn();
            Sql_Conn.AddData(d_name, d_pno, d_mf);
            */
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string file_path = openFileDialog1.FileName;
            StreamReader sr = new StreamReader(file_path);
            while (!sr.EndOfStream)
            {
                rawCsvTB.AppendText(sr.ReadLine());
                if (!sr.EndOfStream)
                {
                    rawCsvTB.AppendText(Environment.NewLine);
                }
            }
        }

        private void extractBtn_Click(object sender, EventArgs e)
        {
            int nameIdx = (int)colName.Value;
            int pNoIdx = (int)colPNo.Value;
            int seatAndSexIdx = (int)colSeatAndSex.Value;
            // 데이터 신규 추가용 row 한 개를 제외하고 센다
            int totalLines = csvDGV.Rows.Count - 1;
            for (int i = 0; i < totalLines; i++) 
            {
                var targetRow = csvDGV.Rows[i].Cells;
                string name = targetRow[nameIdx].Value.ToString();
                string pNo = targetRow[pNoIdx].Value.ToString();
                string pNoStr = pNo.Substring(4, 9).Remove(4, 1);
                string sex = "F";
                if (targetRow[seatAndSexIdx].Value.ToString().Contains("남자"))
                {
                    sex = "M";
                }
                string seatNo = Regex.Match(targetRow[seatAndSexIdx].Value.ToString(), @"\d+").Value;

                string[] strs = new string[] { name, pNoStr, sex, seatNo };
                userDataDGV.Rows.Add(strs);
            }
        }


        private void SqlConn_btn_click(object sender, EventArgs e)
        {
            Sql_Conn_frm newForm = new Sql_Conn_frm();
            newForm.ReadIni(sender, e);
            newForm.Show();
        }

    }
}
