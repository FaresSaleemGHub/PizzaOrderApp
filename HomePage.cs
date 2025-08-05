using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOrderApp
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Form OrderPage = new OrderPage();
            OrderPage.Show();
            this.Hide();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            //Centralize Form Title
            lblTitleBar.Left = (this.Width - lblTitleBar.Width) / 2;

            //positioning the icon
            pictClose.Location = new Point(panelTopBar.Width - pictClose.Width - 10, 8);
        }

        private void pictClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictClose_MouseEnter(object sender, EventArgs e)
        {
            pictClose.BackColor = Color.Red;
        }

        private void pictClose_MouseLeave(object sender, EventArgs e)
        {
            pictClose.BackColor = Color.Wheat;
        }
    }
}
