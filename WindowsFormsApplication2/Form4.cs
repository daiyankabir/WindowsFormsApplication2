using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = DataAccess.LoadData("select * from UserInfo where UserName='" + txtUN.Text +
                                               "' and Password='" + txtPassword.Text + "'");

            if (dt.Rows.Count != 1)
            {
                MessageBox.Show("Invalid Username or Password");
                return;
            }

            string type = dt.Rows[0]["Type"].ToString();

            if (type == "Admin")
            {
                Form3 f3 = new Form3();
                f3.Show();
                this.Hide();
            }
            else if (type == "Manager")
            {
                Form2 f3 = new Form2();
                f3.Show();
                this.Hide();
            }
        }
    }
}
