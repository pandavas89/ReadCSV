using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadCSV
{
    public partial class Biostar_Single : Form
    {
        public Biostar_Single()
        {
            InitializeComponent();
            IndexValue();
        }
        public void IndexValue()
        {
            ID_TB.AppendText("11");
            NameTB.AppendText("HongGilDong");
            GroupTB.AppendText("M");
            //  YYYY-mm-ddTHH:MM 형식으로 전달받는다.
            startTime.AppendText("2020-08-11T09:00");
            endTime.AppendText("2020-09-01T09:00");
        }

        MainForm MF = new MainForm();


    }
}
