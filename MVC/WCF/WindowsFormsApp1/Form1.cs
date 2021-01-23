using System;
using System.Windows.Forms;
using ServiceReferenceCustomerMoayad1;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ServiceClient srv = new ServiceClient();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = srv.GetAllCustomerAsync();
        }
    }
}
