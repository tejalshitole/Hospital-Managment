using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Hospital_Managment
{
        
    public partial class Form2 : Form
    {
        string cs = "", q;
        MySqlConnection c1;
        MySqlDataReader d;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable t,dt;
        public Form2()
        {
            InitializeComponent();
        }
        public void showdata()
        {
            c1.Open();
            try
            {
                q = "select * from patients_informations";
                da = new MySqlDataAdapter(q, c1);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView3.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured" + ex);
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            cs = "server=localhost; database = hospital_management; uid = root; pwd = root";
            c1 = new MySqlConnection(cs);
            MessageBox.Show("Database connected successfully");
            c1.Open();
            try
            {
                q = "Select * from doctors_information";
                da = new MySqlDataAdapter(q, c1);
                t = new DataTable();
                da.Fill(t);
                dataGridView1.DataSource = t;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data Insert Exception:" + ex);
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();
            }
            c1.Open();
            try
            {
                q = "Select * from patients_informations";
                da = new MySqlDataAdapter(q, c1);
                t = new DataTable();
                da.Fill(t);
                dataGridView2.DataSource = t;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data Insert Exception:" + ex);
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();
            }
            c1.Open();
            try
            {
                q = "Select * from Doctor_Report";
                da = new MySqlDataAdapter(q, c1);
                t = new DataTable();
                da.Fill(t);
                dataGridView3.DataSource = t;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data Insert Exception:" + ex);
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();
            }

        }
        
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            showdata();   
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
