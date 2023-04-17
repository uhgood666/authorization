using GLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp4
{
    public partial class Form4 : Form
    {
        Database dataBase = new Database();
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2COPSCL;Initial Catalog=authorization;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public string Txt
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public Form4()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string sql = "Select * From Laboratory_services, Patient_data";
            cmd = new SqlCommand(sql, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                if(!comboBox1.Items.Contains(dr["Service"].ToString()))
                    comboBox1.Items.Add(dr["Service"].ToString());
                if (!comboBox2.Items.Contains(dr["Price"].ToString()))
                    comboBox2.Items.Add(dr["Price"].ToString());
                if (!comboBox3.Items.Contains(dr["surname"].ToString()))
                    comboBox3.Items.Add(dr["surname"].ToString());
                if (!comboBox4.Items.Contains(dr["name"].ToString()))
                    comboBox4.Items.Add(dr["name"].ToString());
                if (!comboBox5.Items.Contains(dr["middle_name"].ToString()))
                    comboBox5.Items.Add(dr["middle_name"].ToString());
                
            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var surname = comboBox3.Text;
            var name = comboBox4.Text;
            var middleName = comboBox5.Text;
            var code = textBox2.Text;
            var service = comboBox1.Text;
            var price = comboBox2.Text;

            string querystring = $"insert into reservation(surname, name, middle_name, test_tube_code, service, price) values('{surname}','{name}','{middleName}','{code}','{service}','{price}')";
            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());


            dataBase.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Заказ оформлен");
            }
            dataBase.closeConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
            Hide();
        }

        
    }
}