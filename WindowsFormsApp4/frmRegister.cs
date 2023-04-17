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

namespace WindowsFormsApp4
{
    public partial class frmRegister : Form
    {
        Database dataBase = new Database();

        public frmRegister()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            txtpassword2.PasswordChar = '.';
            pictureBox1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = txtUsername2.Text;
            var password = txtpassword2.Text;

            string querystring = $"insert into register(user_name, password_user) values('{login}', '{password}')";
            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());

            dataBase.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт успешно создан!");
                frmLogin frm_login = new frmLogin();
                this.Hide();
                frm_login.ShowDialog();
            }
            else
            {
                MessageBox.Show("Аккаунт не создан!");
            }
            dataBase.closeConnection();
        }
        private Boolean checkuser()
        {
            var loginUser = txtUsername2.Text;
            var passUser = txtpassword2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select id_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";
            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txtpassword2.UseSystemPasswordChar = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txtpassword2.UseSystemPasswordChar = true;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            txtUsername2.Text = "";
            txtpassword2.Text = "";
        }
    }
}
