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
    public partial class Form1 : Form
    {
        string cs = "", q;
        int i;
        MySqlConnection c1;
        MySqlCommand cmd;
        MySqlDataReader d,d1;
        MySqlDataAdapter da;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cs = "server=localhost; database = hospital_management; uid = root; pwd = root";
            c1 = new MySqlConnection(cs);
            MessageBox.Show("Database connected successfully");
            loadID();

            c1.Open();
            try
            {
                q = "select D_code from doctors_information";
                cmd = new MySqlCommand(q, c1);
                d = cmd.ExecuteReader();
                while (d.Read())
                {
                    comboBox1.Items.Add(d["D_code"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex);
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();
            }
            
        }
        void loadID()
        {
            c1.Open();
            try
            {
                q = "select max(p_no) from patients_informations";
                cmd = new MySqlCommand(q, c1);
                int u = Convert.ToInt32(cmd.ExecuteScalar());
                textBox4.Text = (u + 1).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex);
                textBox4.Text = "1";
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();
            }
            c1.Open();
            try
            {

            }
            catch (Exception ex)
            {
               MessageBox.Show("Exception" + ex);
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();
            }

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                //q="Select D_Code from Doctor_Report";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //q1 = "Select  p_no from Doctor_Report";
        }
        void doctor()
        {
            q = "insert into doctor_report values(@dcode,@p_no,@date,@disease,@remark)";
            cmd = new MySqlCommand(q, c1);
            cmd.Parameters.AddWithValue("@dcode", comboBox1.Text);
            cmd.Parameters.AddWithValue("@p_no", textBox4.Text);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@disease", textBox2.Text);
            cmd.Parameters.AddWithValue("@remark", textBox3.Text);
            int r = cmd.ExecuteNonQuery();
            if (r > 0)
                MessageBox.Show("Data added successfully");
            else
                MessageBox.Show("Data not admitted");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c1.Open();
            try
            {
                q = "insert into patients_informations values(@p_no,@p_name)";
                cmd = new MySqlCommand(q, c1); 
                cmd.Parameters.AddWithValue("@p_no", textBox4.Text);
                cmd.Parameters.AddWithValue("@p_name", textBox1.Text);
                
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    doctor();
                    MessageBox.Show("Patient admitted successfully");
                }
                else
                    MessageBox.Show("Patient does not admitted");

            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Exception" + ex);
               
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                {
                    c1.Close();
                    loadID();
                }
                
            }
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearall();
        }
        void clearall()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            c1.Open();
            try
            {
                q = "select D_name from doctors_information where D_code=" + comboBox1.Text;
                cmd = new MySqlCommand(q, c1);
                String dname = Convert.ToString(cmd.ExecuteScalar());
                textBox5.Text = dname;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex);
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 t = new Form2();
            t.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
