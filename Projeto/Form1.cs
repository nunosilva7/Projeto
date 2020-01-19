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
    public partial class Form1 : Form
    {
        string file_users = "acessos.txt";
        utilizador user = new utilizador();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            opcao1.Visible = false;
            


        }
        public bool user_existe()
        {
            if (File.Exists(file_users))
            {
                StreamReader sr = File.OpenText(file_users);
                string linha = "";
                while ((linha = sr.ReadLine()) != null)
                {
                    string[] campos = linha.Split(';');
                    if ((campos[0] == textBox1.Text) && (campos[1] == textBox2.Text))
                    {
                        
                        user.nome = textBox1.Text;
                        user.password = textBox2.Text;
                        user.email = campos[2];
                        user.tipo = campos[3];
                        return true;
                    }
                }
                sr.Close();
                return false;
            }
            else
                return false;


        }
        public bool user_admin()
        {
            if (File.Exists(file_users))
            {
                StreamReader sr = File.OpenText(file_users);
                string linha = "";
                while ((linha = sr.ReadLine()) != null)
                {
                    string[] campos = linha.Split(';');
                    if ((campos[0] == textBox1.Text) && (campos[3] == "admin"))
                    {
                        return true;

                    }

                }
                sr.Close();
                return false;

            }
            else
                return false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f2 = new Form2();
            f2.Show();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            if (user_existe())
            {

                status2.Text = "Bem-vindo " + user.nome;
                panel1.Visible = false;   

               
                panel2.Visible = true;
                panel2.Location = new Point(400, 50);

                label3.Text = user.nome;

                status1.Enabled = true;
                opcao1.Visible = true;

                






            }
            else
            {
                status2.Text = "User ou password não correspondem";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            button2.Visible = false;

            panel1.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";

            opcao1.Visible = false;
            status2.Text = "";
        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            status1.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            opcao1.Visible = false;
            
        }

        private void opcao1_Click(object sender, EventArgs e)
        {
            variaveis.CurrentForm = Form.ActiveForm;
            this.Hide();
            
            if(user_admin())
            {
                Form3 f3 = new Form3();
                f3.Show();
                f3.setPanel3Visible(true);
                f3.setPanel4Visible(true);
            }
            else
            {
                Form3 f3 = new Form3();
                f3.Show();
            }


           
        }

        private void opcao3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
    
