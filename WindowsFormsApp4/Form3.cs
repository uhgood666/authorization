using BarcodeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisioForge.Libs.ZXing;

namespace WindowsFormsApp4
{
    public partial class Form3 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2COPSCL;Initial Catalog=authorization;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        public Form3()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Barcode barcode = new Barcode();
            Color foreColor = Color.Black;
            Color backColor = Color.Transparent;
            Image img = barcode.Encode(TYPE.UPCA, textBox2.Text, foreColor, backColor, (int)(pictureBox1.Width * 0.8), (int)(pictureBox1.Height * 0.8));
            pictureBox1.Image = img;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Form4 fm4 = new Form4();
            fm4.Txt = this.textBox2.Text;
            fm4.ShowDialog();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

       
        private void button4_Click(object sender, EventArgs e)
        {
           if (pictureBox1.Image == null)
            
                return;
                using(SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "PNG|*.png"})
                {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    pictureBox1.Image.Save(saveFileDialog.FileName);   
                }
            SaveFileDialog saveFile1 = new SaveFileDialog();
            saveFile1.DefaultExt = "*.txt";
            saveFile1.Filter = "Text files|*.txt";
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                saveFile1.FileName.Length > 0)
            {
                using (StreamWriter sw = new StreamWriter(saveFile1.FileName, true))
                {
                    sw.WriteLine(textBox2.Text);
                    sw.Close();
                }
            }
        }   
    }
    }

