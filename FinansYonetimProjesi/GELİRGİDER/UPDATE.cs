using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinansYonetimProjesi.GelirGider
{
    public partial class UPDATE : Form
    {
        public static int id = 0;
        public UPDATE()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public void gelir()
        {


            string sorgu = "select Income.Id,Income.Amount as IncomeAmount,Income.Description, Income.Date,Income.IsStatus as Status from Income where IsDelete=0";

            SqlDataAdapter sqlData = new SqlDataAdapter(sorgu, bgl.baglanti());

            DataTable dt = new DataTable();
            sqlData.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;

            bgl.baglanti().Close();
        }
        public void gider()
        {


            string sorgu = "select Expense.Id,Expense.Amount as ExpenseAmount,Expense.Description, Expense.Date,Expense.IsStatus as Status from Expense where IsDelete=0";

            SqlDataAdapter sqlData = new SqlDataAdapter(sorgu, bgl.baglanti());

            DataTable dt = new DataTable();
            sqlData.Fill(dt);

            dataGridView2.DataSource = dt;
            dataGridView2.Columns[0].Visible = false;

            bgl.baglanti().Close();
        }
        private void UPDATE_Load(object sender, EventArgs e)
        {
            gelir();
            gider();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker2.Value = Convert.ToDateTime(dataGridView2.CurrentRow.Cells[3].Value.ToString());
            richTextBox2.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
        }

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());

            SqlCommand sql = new SqlCommand("EditExpense", bgl.baglanti());
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.Add("Id", SqlDbType.Int).Value = id;
            sql.Parameters.Add("Amount", SqlDbType.Float).Value = textBox4.Text;
            sql.Parameters.Add("Date", SqlDbType.Date).Value = dateTimePicker2.Value;
            sql.Parameters.Add("Description", SqlDbType.Text).Value = richTextBox2.Text;

            var returnValue = sql.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnValue.Direction = ParameterDirection.ReturnValue;
            sql.ExecuteNonQuery();



            int result = Convert.ToInt32(returnValue.Value);

            if (result == 1)
            {
                MessageBox.Show("Expense Edited Successful");
                gider();
            }
            else
            {
                MessageBox.Show("Not Found Expense");
            }

            bgl.baglanti().Close();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            SqlCommand sql = new SqlCommand("EditIncome", bgl.baglanti());
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.Add("Id", SqlDbType.Int).Value = id;
            sql.Parameters.Add("Amount", SqlDbType.Float).Value = textBox3.Text;
            sql.Parameters.Add("Date", SqlDbType.Date).Value = dateTimePicker1.Value;
            sql.Parameters.Add("Description", SqlDbType.Text).Value = richTextBox1.Text;

            var returnValue = sql.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnValue.Direction = ParameterDirection.ReturnValue;
            sql.ExecuteNonQuery();


            int result = Convert.ToInt32(returnValue.Value);

            if (result == 1)
            {
                MessageBox.Show("Income Edited Successful");
                gelir();
            }
            else
            {
                MessageBox.Show("Not Found Income");
            }

            bgl.baglanti().Close();

        }
    }
}
