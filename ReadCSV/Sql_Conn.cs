﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadCSV
{
    class Sql_Conn
    {
        // SQL_DB User ID Password
        // textbox 입력으로 수정할 수 있도록 개선
        // 최종적으로는 MS SQL DB를 거치지 않고 바이오스타만으로 업데이트 처리 가능하도록
        /*string strConn = "Data Source=192.168.0.10;Initial Catalog=STUDY_ROOM;"
                            + "User ID=sa;Password=jack3081$$;";*/

        //
        //var Sql_Conn_frm = new Sql_Conn_frm();

        private string strConn = "";

        SqlConnection Conn = new SqlConnection();
           
        //
        public void SetConnection()
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
            strConn += "Data Source=" + configData["Data Source"] + "; ";
            strConn += "Initial Catalog=" + configData["Initial Catalog"] + "; ";
            strConn += "USER ID=" + configData["USER ID"] + "; ";
            strConn += "Password=" + configData["Password"] + "; ";
        }

        //
        public void Open()
        {            
            if (Conn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    SetConnection();
                    MessageBox.Show(strConn);
                    Conn.ConnectionString = strConn;
                    Conn.Open();//
                }
                catch (InvalidCastException e)
                {
                    MessageBox.Show(e.Message, "DB Error!");
                }
            }

        }

        //
        public System.Data.ConnectionState State()
        {
            return Conn.State;
        }

        // 연결 닫음
        public void Close()
        {
            Conn.Close();
        }

        //
        public SqlDataReader SCom(string QString)
        {
            Open();
            SqlCommand Command = new SqlCommand(QString, Conn);
            try
            {
                SqlDataReader reader = Command.ExecuteReader();
                return reader;
            }
            catch (InvalidCastException e)
            {
                MessageBox.Show(e.Message, "DB Error!");
                return null;
            }
        }

        //
        public int ECom(string QString)
        {
            int rint = 0;
            Open();
            SqlCommand command = new SqlCommand(QString, Conn);
            try
            {
                rint = command.ExecuteNonQuery();
            }
            catch (InvalidCastException e)
            {
                MessageBox.Show(e.Message, "DB Error !");
            }
            return rint;
        }


        // Add T_USER Data
        public void Add_T_USER_Data(List<string> d_name, List<string> d_pno, List<string> d_mf) //
        {
            //
            // IF NOT EXISTS THEN INSERT INTO ~ ELSE UPDATE
            string queryString = "";
            //for (int i = 0; i < d_name.Count; i++)

            for (int i = 0; i < d_name.Count; i++)
            {
                queryString += " IF NOT EXISTS ( ";
                queryString += " SELECT * ";
                queryString += " FROM T_USER ";
                queryString += String.Format(" WHERE PNO = '{0}') ", d_pno[i]);
                queryString += " BEGIN ";
                queryString += " INSERT INTO T_USER";
                queryString += " ( NAME, PNO, MF ) ";
                queryString += " VALUES ";
                queryString += String.Format(" ('{0}','{1}','{2}') ", d_name[i], d_pno[i], d_mf[i]);
                queryString += " END ";
                queryString += " ELSE ";
                queryString += " BEGIN ";
                queryString += " UPDATE T_USER ";
                queryString += String.Format(" SET NAME = '{0}', PNO = '{1}', MF = '{2}'", d_name[i], d_pno[i], d_mf[i]);
                queryString += String.Format(" WHERE PNO = '{0}'", d_pno[i]);
                queryString += " END ";
            }
            queryString = queryString.Substring(0, queryString.Length - 1);

            MessageBox.Show(queryString);
                      
            ECom(queryString);

            MessageBox.Show("사용자 정보가 추가되었습니다.!");

        }


        // Add T_USER Data
        public void Add_T_M_USING_Data(string d_yyyy, string d_mm, List<string> d_pno, List<string> d_sno) //
        {
            string queryString = "";
            //for (int i = 0; i < d_name.Count; i++)

            for (int i = 0; i < d_pno.Count; i++)
            {                
                queryString += " INSERT INTO T_M_USING ";
                queryString += " ( YYYY, MM, PNO, SNO, CNO ) ";
                queryString += " VALUES ";
                queryString += String.Format(" ('{0}','{1}','{2}','{3}','{4}') ", d_yyyy, d_mm, d_pno[i], d_sno[i], d_pno[i]);
               
            }
            queryString = queryString.Substring(0, queryString.Length - 1);

            MessageBox.Show(queryString);

            ECom(queryString);

            MessageBox.Show("사용자 정보가 추가되었습니다.!");

        }


    }
}
