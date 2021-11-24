using System;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace InventoryManagementSystem
{
    public partial class manageUsers : Form
    {
        public manageUsers()
        {
            InitializeComponent();
        }


        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        StringBuilder errorMessages = new StringBuilder();
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\laven\Documents\InventorManagement.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            try
            {
                Con.Open();
                string Myquery = "select * from userTable";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                UsersGV.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into userTable values('"+unameTable.Text+"','"+fullNameTable.Text+"','"+passwordTable.Text+"','"+phoneTable.Text+"')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Added Successfully");
                Con.Close();
                populate();
            }
            catch
            {

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void UsersGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Console.WriteLine(UsersGV.SelectedRows.Count);
            //unameTable.Text = UsersGV.SelectedRows[0].Cells[0].Value.ToString();
            //fullNameTable.Text = UsersGV.SelectedRows[0].Cells[1].Value.ToString();
            //passwordTable.Text = UsersGV.SelectedRows[0].Cells[2].Value.ToString();
            //phoneTable.Text = UsersGV.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void manageUsers_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(phoneTable.Text == "")
            {
                MessageBox.Show("Enter user's phone number");
            }
            else
            {
                Con.Open();
                string myQuery = "delete from userTable where phone = '"+phoneTable.Text+"'";
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
                SqlCommand cmd = new SqlCommand("update userTable set uName = '"+unameTable.Text+"',fName='"+fullNameTable.Text+"',password='"+passwordTable.Text+"' where phone='"+phoneTable.Text+"'", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Edited Successfully");
                Con.Close();
                populate();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
