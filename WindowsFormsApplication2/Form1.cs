using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = DataAccess.LoadData("select * from Department");
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = DataAccess.LoadData("select * from Department where Name like '%" + textBox1.Text + "%'");
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "";

            if (txtID.Text == "")
            {
                query = "insert into Department(Name) values('" + txtName.Text + "')";
                button4.PerformClick();
            }
            else
            {
                query = "update Department set Name='" + txtName.Text + "' where ID=" + txtID.Text + "";
            }

            int row = DataAccess.ExecuteQuery(query);
            if (row > 0)
            {
                MessageBox.Show("Inserted");
                button1.PerformClick();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = DataAccess.LoadData("select * from Department");
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex==-1)
                return;

            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtID.Text = txtName.Text = "";
            dataGridView1.ClearSelection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Please Select A Row First");
                return;
            }

            int row = DataAccess.ExecuteQuery("delete from department where ID=" + txtID.Text + "");
            if (row > 0)
            {
                MessageBox.Show("Deleted");
                button1.PerformClick();
                button4.PerformClick();
            }
        }

        
    }
}
