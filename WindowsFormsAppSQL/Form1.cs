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
        string query = "SELECT * FROM contact";
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
            query = "SELECT * FROM `contact` ORDER BY `contact`.`date` ASC";
            F1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM `contact` ORDER BY `contact`.`date` DESC";
            F1();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string word;
            string column;
            word = textBox1.Text;
            column = comboBox1.Text;
            if (column=="")
            {
                column = "name";
            }
            query = "SELECT * FROM `contact` WHERE `"+column +"`  LIKE '%" + word + "%'";
            F1();
        }
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
