﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ShujaTravelers
{
    public partial class Buses : Form
    {
        SqlConnection connection = new SqlConnection();
        public Buses()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            comboBox2.MaxLength = 10;
            textBox2.MaxLength = 20;
            textBox3.MaxLength = 20;
            textBox4.MaxLength = 3;
            connection.ConnectionString = "Data Source=ADMIN-PC\\SQLSERVER;Initial Catalog=dbShujaTravelers;Integrated Security=True";
            GetBNo();
            GetRID();
           
        }
        private void GetBNo()
        {
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select * from tblBuses";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader.GetValue(0));
            }
            connection.Close();

        }
       
        private void GetRID()
        {
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select * from tblRoutes";
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                comboBox1.Items.Add(reader.GetValue(0));
            }
            connection.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Route_button_Click(object sender, EventArgs e)
        {
            Routes Route = new Routes();
            Route.Show();
            Visible = false;
        }

        private void Ticketing_button_Click(object sender, EventArgs e)
        {
            Ticketng Ticketing = new Ticketng();
            Ticketing.Show();
            Visible = false;
        }

        private void Reset_button_Click(object sender, EventArgs e)
        {
            comboBox2.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            comboBox1.Text = " ";
        }

        private void Customer_button_Click(object sender, EventArgs e)
        {
            Customers Customer = new Customers();
            Customer.Show();
            Visible = false;
        }

        private void Submit_button_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Please Fill All the Fields");
            }
            else
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "insert into tblBuses(B_No,B_Model,Category,Capacity,R_ID) values('" + comboBox2.Text.ToUpper() + "','" + textBox2.Text.ToUpper() + "','" + textBox3.Text.ToUpper() + "','" + textBox4.Text.ToUpper() + "','" + comboBox1.Text.ToUpper() + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Data Has been Saved");
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Your Data is Saves" + ex);
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Route_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Capacity_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Category_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void BusModel_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void BusNumber_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Bus_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Special Characters can,t be part of Bus Model");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void Delete_button_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "delete from tblBuses where B_No='" + comboBox2.Text.ToUpper() + "'";
            command.ExecuteNonQuery();
            MessageBox.Show("Deleted");
            connection.Close();
        }

        private void BusNo_comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Special Characters can,t be part of Bus Number");
            }
        }

        private void BusNo_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
