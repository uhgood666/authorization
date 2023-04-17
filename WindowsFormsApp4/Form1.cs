﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        Database database = new Database();
        private DateTime t1;
        private DateTime t2;

        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Maximum = 59;
            numericUpDown1.Minimum = 0;

            numericUpDown1.TabStop = false;

            numericUpDown2.Maximum = 59;
            numericUpDown2.Minimum = 0;
            numericUpDown2.TabStop = false;

            button1.Enabled = false;
            StartPosition = FormStartPosition.CenterScreen;
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t2 = t2.AddSeconds(-1);

            if (t2.Minute < 9)
                label3.Text = "0" + t2.Minute.ToString() + ":";
            else
                label3.Text = t2.Minute.ToString() + ":";
            if (t2.Second < 9)
                label3.Text += "0" + t2.Second.ToString();
            else
                label3.Text += t2.Second.ToString();

            if (Equals(t1, t2))
            {
                timer1.Enabled = false;
                DialogResult result = MessageBox.Show(Owner, "Заданный интервал времени истёк", "Таймер", MessageBoxButtons.OK, MessageBoxIcon.Information);

                button1.Text = "Пуск";
                groupBox1.Enabled = true;
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;

            string querystring = $"insert into Laboratory_services(Service) values('{name}')";
            SqlCommand command = new SqlCommand(querystring, database.GetConnection());

            database.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                Form3 frm3 = new Form3();
                frm3.Show();
                Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                t1 = new DateTime(DateTime.Now.Year,
                    DateTime.Now.Month, DateTime.Now.Day);
                t2 = t1.AddMinutes((double)numericUpDown1.Value);
                t2 = t2.AddSeconds((double)numericUpDown2.Value);

                groupBox1.Enabled = false;
                button1.Text = "Стоп";

                if (t2.Minute < 9)
                    label3.Text = "0" + t2.Minute.ToString() + ":";
                else
                    label3.Text = t2.Minute.ToString() + ":";
                if (t2.Second < 9)
                    label3.Text += "0" + t2.Second.ToString();
                else
                    label3.Text += t2.Second.ToString();

                timer1.Interval = 1000;
                timer1.Enabled = true;
                groupBox1.Visible = false;
            }
            else
            {
                timer1.Enabled = false;
                button1.Text = "Пуск";
                groupBox1.Enabled = true;
                numericUpDown1.Value = t2.Minute;
                numericUpDown2.Value = t2.Second;
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if ((numericUpDown1.Value == 0) &&
                (numericUpDown2.Value == 0))
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
