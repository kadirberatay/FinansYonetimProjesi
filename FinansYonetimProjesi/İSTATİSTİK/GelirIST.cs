using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinansYonetimProjesi.İSTATİSTİK
{
    public partial class GelirIST : Form
    {
        public GelirIST()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("IncomeBeetween", bgl.baglanti());
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("Giris", SqlDbType.Date).Value = dateTimePicker1.Value;
            sqlCommand.Parameters.Add("Cikis", SqlDbType.Date).Value = dateTimePicker2.Value;

            var ReturnValue = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Float);
            ReturnValue.Direction = ParameterDirection.ReturnValue;
            sqlCommand.ExecuteNonQuery();
            double result = Convert.ToDouble(ReturnValue.Value);
            bgl.baglanti().Close();

            //chart1. = result.ToString();

        }
    }
}
