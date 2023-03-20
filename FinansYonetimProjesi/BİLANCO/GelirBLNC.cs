using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinansYonetimProjesi.Bilanco
{
    public partial class GelirBLNC : Form
    {
        public GelirBLNC()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public void gelir()
        {


            string sorgu = "select Income.Amount as IncomeAmount,Income.Description, Income.Date from Income where IsDelete=0";

            SqlDataAdapter sqlData = new SqlDataAdapter(sorgu, bgl.baglanti());

            DataTable dt = new DataTable();
            sqlData.Fill(dt);

            dataGridView1.DataSource = dt;


            bgl.baglanti().Close();
        }
        
        private void GelirBLNC_Load(object sender, EventArgs e)
        {
            gelir();
        }

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

            label2.Text = result.ToString();
        }
    }
}
