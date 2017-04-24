using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        MySqlConnection mySqlConnection;
        MySqlDataAdapter mySqlDataAdapter;
        MySqlCommandBuilder mySqlCommandBuilder;
        DataTable dataTable;
        BindingSource bindingSource;
        bool IsAsc=false;
        bool isDesc=false;
        int n1 = 1;
        int n2 = 3;
        string query = "SELECT * FROM contact LIMIT 1,3";
        private void button1_Click(object sender, EventArgs e)
        {
            F1();
        }

        private void F1()
        {
            mySqlConnection = new MySqlConnection(
                   "SERVER=localhost;" +
                   "DATABASE=numbers;" +
                   "UID=root;" +
                   "PASSWORD=;");

            mySqlConnection.Open();



            mySqlDataAdapter = new MySqlDataAdapter(query, mySqlConnection);
            mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter);

            mySqlDataAdapter.UpdateCommand = mySqlCommandBuilder.GetUpdateCommand();
            mySqlDataAdapter.DeleteCommand = mySqlCommandBuilder.GetDeleteCommand();
            mySqlDataAdapter.InsertCommand = mySqlCommandBuilder.GetInsertCommand();

            dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);

            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            dataGridView1.DataSource = bindingSource;
            bindingNavigator1.BindingSource = bindingSource;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mySqlDataAdapter.Update(dataTable);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            F1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string pages = n1.ToString() + "," + n2.ToString();
            query = "SELECT * FROM `contact` ORDER BY `contact`.`date` ASC LIMIT " + pages;
            F1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string pages = n1.ToString() + "," + n2.ToString();
            query = "SELECT * FROM `contact` ORDER BY `contact`.`date` DESC LIMIT " + pages;
            F1();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string word;
            string column;
            string pages = n1.ToString() + "," + n2.ToString();
            word = textBox1.Text;
            column = comboBox1.Text;
            if (column=="")
            {
                column = "name";
            }
            query = "SELECT * FROM `contact` WHERE `"+column +"`  LIKE '%" + word + "%' LIMIT " + pages;
            F1();
        }
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            mySqlDataAdapter.Update(dataTable);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            mySqlDataAdapter.Update(dataTable);
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            n1 = n1 + 3;
            n2 = n2 + 3;
            string pages = n1.ToString() + "," + n2.ToString();
            query = "SELECT * FROM contact LIMIT "+pages;
            F1();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            n1 = n1 - 3;
            n2 = n2 - 3;
            
            if (n1<1)
            {
                n1 = 1;
            }
            if (n1==1)
            {
                n2 = 3;
            }
            string pages = n1.ToString() + "," + n2.ToString();
            query = "SELECT * FROM contact LIMIT " + pages;
            F1();
        }
    }
}
