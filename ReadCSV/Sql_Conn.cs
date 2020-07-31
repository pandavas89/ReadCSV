using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadCSV
{
    class Sql_Conn
    {


        // SQL_DB User ID Password
        string strConn = "Data Source=DEV-SA-PC;Initial Catalog=STUDY_ROOM;"
                            + "User ID=sa;Password=jack3081$$;";

        SqlConnection Conn = new SqlConnection();

        public void Open()
        {

            if (Conn.State == System.Data.ConnectionState.Closed)
            {
                Conn.ConnectionString = strConn;

                try
                {
                    //MessageBox.Show("DB Open!");
                    Conn.Open(); // 

                }
                catch (InvalidCastException e)
                {
                    MessageBox.Show(e.Message, "DB Error!");
                }
            }
        }

        public System.Data.ConnectionState State()
        {
            return Conn.State;
        }

        // 연결 닫음
        public void Close()
        {
            Conn.Close();
        }

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


        public void AddData(List<string> d_name, List<string> d_pno, List<string> d_mf) //string[] f_name, string[] f_pno, string[] f_mf
        {
            //
            string queryString = " INSERT INTO T_USER";
            queryString += " (NAME ";
            queryString += " ,PNO ";
            queryString += " ,MF) ";
            queryString += " VALUES ";

            for (int i = 0; i < d_name.Count; i++)
            {
                queryString += String.Format(" ('" + "{0}" + "','" + "{1}" + "','" + "{2}" + "'),", d_name[i], d_pno[i], d_mf[i]);
            }

            queryString = queryString.Substring(0, queryString.Length - 1);

            MessageBox.Show(queryString);

            /*queryString += " ('" + PNOtext + "'";
            queryString += " ,'" + NAMEtext + "'";
            queryString += " ,'" + FMCB + "')";*/


            ECom(queryString);

            MessageBox.Show("사용자 정보가 추가되었습니다.!");

        }
    }
}
