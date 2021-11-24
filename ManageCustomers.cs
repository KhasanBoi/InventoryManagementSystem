using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class ManageCustomers : Form
    {
        public ManageCustomers()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\laven\Documents\InventorManagement.mdf;Integrated Security=True;Connect Timeout=30");


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into userTable values('" + customerId.Text + "','" + customerName.Text + "','" + customerPhone.Text + "','" + customerPhone.Text + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Added Successfully");
                Con.Close();
                populate();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void populate()
        {
            try
            {
                Con.Open();
                string Myquery = "select * from customTable";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                customersGV.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (customerId.Text == "")
            {
                MessageBox.Show("Enter user's phone number");
            }
            else
            {
                Con.Open();
                string myQuery = "delete from customTable where custID='"+customerId.Text+"'";
                SqlCommand cmd = new SqlCommand(myQuery, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Deleted Successfuly");
                Con.Close();
                populate();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("update customerTable set custID = '" + customerId.Text + "',custName='" + customerName.Text + "',custPhone='" + customerPhone.Text + "' where custID='" + customerId.Text + "'", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Edited Successfully");
                Con.Close();
                populate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
