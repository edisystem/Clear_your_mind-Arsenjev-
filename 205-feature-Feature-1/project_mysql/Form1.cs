using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_mysql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


      const  string serverName = "192.168.0.200"; // Адрес сервера (для локальной базы пишите "localhost")
      const string userName = "student"; // Имя пользователя
      const string dbName = "bd5k"; //Имя базы данных
      const string port = "3306"; // Порт для подключения
      const string password = "student"; // Пароль для подключения
      const string connStr = "server=" + serverName +
                ";user=" + userName +
                ";database=" + dbName +
                ";port=" + port +
                ";password=" + password + ";";
        

        private void button1_Click(object sender, EventArgs e)
        {
                        /*           MySqlConnection conn = new MySqlConnection(connStr);
                       conn.Open();
                       string sql = "SELECT * FROM table1"; // Строка запроса
                       MySqlScript script = new MySqlScript(conn, sql);
                       int count = script.Execute();
                       richTextBox1.Text += ("Executed " + count + " statement(s).");
                       richTextBox1.Text += ("Delimiter: " + script.Delimiter);
                       */

            string sql = "SELECT * FROM vopr"; // Строка запроса
            MySqlConnection connection = new MySqlConnection(connStr);
            MySqlCommand sqlCom = new MySqlCommand(sql, connection);
            connection.Open();
            sqlCom.ExecuteNonQuery();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCom);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            var myData = dt.Select();
            for (int i = 0; i < myData.Length; i++)
            {
                for (int j = 0; j < myData[i].ItemArray.Length; j++)
                    richTextBox1.Text += myData[i].ItemArray[j] + "; ";
                richTextBox1.Text += "\n";
            }
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO vopr (id, vopr, o1, o2, o3, o4, tip, otv) VALUES (\"pitajus\", \"wpisat\", \"chto-to\", \"adekwatnoe\", \"dsf\", \"aswef\", \"1\", \"1\");"; // Строка запроса
            MySqlConnection connection = new MySqlConnection(connStr);
            MySqlCommand sqlCom = new MySqlCommand(sql, connection);
            connection.Open();
            sqlCom.ExecuteNonQuery();
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM `vopr` ORDER BY `id` DESC LIMIT 10 "; // Строка запроса
            MySqlConnection connection = new MySqlConnection(connStr);
            MySqlCommand sqlCom = new MySqlCommand(sql, connection);
            connection.Open();
            sqlCom.ExecuteNonQuery();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCom);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
           
            richTextBox1.Clear();
            
            var myData = dt.Select();
            for (int i = 0; i < myData.Length; i++)
            {
                for (int j = 0; j < myData[i].ItemArray.Length; j++)
                    richTextBox1.Text += myData[i].ItemArray[j] + "; ";
                richTextBox1.Text += DateTime.Now+"\n";
            }
            connection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string vopr = textBox1.Text;
            string o1 = textBox2.Text;
            string o2 = textBox3.Text;
            string o3 = textBox4.Text;
            string o4 = textBox5.Text;
            string tip = textBox6.Text;
            string otv = textBox7.Text;


            string sql = "INSERT INTO vopr (vopr, o1, o2, o3, o4, tip, otv) VALUES ('" + vopr + "', '" + o1 + "', '" + o2 + "', '" + o3 + "', '" + o4 + "', '" + tip + "', '" + otv + "')"; // Строка запроса
            MySqlConnection connection = new MySqlConnection(connStr);
            MySqlCommand sqlCom = new MySqlCommand(sql, connection);
            connection.Open();
            sqlCom.ExecuteNonQuery();

            button3.PerformClick();

            connection.Close();
        }
    }
}
