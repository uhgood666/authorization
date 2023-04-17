using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "authorizationDataSet.Patient_data". При необходимости она может быть перемещена или удалена.
            this.patient_dataTableAdapter.Fill(this.authorizationDataSet.Patient_data);

        }

        private void patient_dataBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.patient_dataBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.authorizationDataSet);

        }

       

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            Hide();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            patient_dataBindingSource.Filter = "Id=\'" + toolStripTextBox1.Text + "\'";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            patient_dataBindingSource.Filter = null;
        }
    }
}
