using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Projeto
{
    public partial class Form2 : Form
    {
        string file_users = "acessos.txt";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            utilizador user = new utilizador();

            if((textBox1.Text == "" || textBox2.Text == ""))
            {
                MessageBox.Show("Não foram preenchidos todos os campos");
            }
            if ((textBox3.Text != textBox4.Text) || (textBox3.Text == ""))
            {
                MessageBox.Show("A password não corresponde");
                return;
            }
            user.nome = textBox1.Text;
            user.password = textBox3.Text;
            user.email = textBox2.Text;
            user.tipo = "user";
            status1.Text = "Conta criada com sucesso";

            StreamWriter sw;
            if (File.Exists(file_users))
            {
                sw = File.AppendText(file_users);

            }
            else
            {
                sw = File.CreateText(file_users);
            }
            sw.WriteLine(user.nome + ";" + user.password + ";" + user.email + ";" + user.tipo);
            sw.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
