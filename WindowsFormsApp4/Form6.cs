using Cairo;
using GLib;
using Gst.Base;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisioForge.Libs.TagLib.Jpeg;

namespace WindowsFormsApp4
{
    public partial class Form6 : Form
    {
        
        public Form6()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "authorizationDataSet2.Service_rendered". При необходимости она может быть перемещена или удалена.
            this.service_renderedTableAdapter.Fill(this.authorizationDataSet2.Service_rendered);

        }

        private void service_renderedBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.service_renderedBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.authorizationDataSet2);

        }

    }
}
      
    

