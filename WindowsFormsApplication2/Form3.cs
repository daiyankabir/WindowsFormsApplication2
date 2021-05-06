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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataTable dt = DataAccess.LoadData("select Employee.*,Department.Name as 'DepartmentName' from Employee,Department where Employee.DepartmentID = Department.ID");
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
            button4.PerformClick();

            DataTable dt1 = DataAccess.LoadData("select * from Department");
            comboBox1.DataSource = dt1;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = DataAccess.LoadData("select Employee.*,Department.Name as 'DepartmentName' from Employee,Department where Employee.DepartmentID = Department.ID");
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
            button4.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "select Employee.*,Department.Name as 'DepartmentName' from Employee,Department where Employee.DepartmentID = Department.ID";
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                query += " and Employee.Name like '%" + textBox1.Text + "%'";
            }
            DataTable dt = DataAccess.LoadData(query);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
            button4.PerformClick();
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

            int row = DataAccess.ExecuteQuery("delete from Employee where ID=" + txtID.Text + "");
            if (row > 0)
            {
                MessageBox.Show("Deleted");
                button1.PerformClick();
                button4.PerformClick();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "";

            if (txtID.Text == "")
            {
                query = "insert into Employee(Name,DepartmentID) values('" + txtName.Text + "',"+comboBox1.SelectedValue+")";
            }
            else
            {
                query = "update Employee set Name='" + txtName.Text + "',DepartmentID="+comboBox1.SelectedValue+" where ID=" + txtID.Text + "";
            }

            int row = DataAccess.ExecuteQuery(query);
            if (row > 0)
            {
                MessageBox.Show("Operation Completed");
                button1.PerformClick();
                button4.PerformClick();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
