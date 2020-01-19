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
    public partial class Form3 : Form
    {
        string file_cate = @"categorias.txt";
        string file_ite = @"itenerarios.txt";
        static int foto_numero = 1;
        static int i = -1;




        public void setPanel3Visible(bool flag)
        {
            this.panel3.Visible = flag;

        }
        public void setPanel4Visible(bool flag)
        {
            this.panel4.Visible = flag;

        }

        public Form3()
        {
            InitializeComponent();
            Categorias.Items.AddRange(File.ReadAllLines(file_cate));




        }


        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Recente";
            if (File.Exists(file_ite))
            {
                var dados = File.ReadAllLines(file_ite).Reverse();
                int lin = 0;
                foreach (string linha in dados)
                {
                    string[] campos = linha.Split(';');

                    dataGridView1.Rows.Add(1);
                    dataGridView1[0, lin].Value = campos[0];   
                    dataGridView1[1, lin].Value = campos[1];    
                    dataGridView1[2, lin].Value = campos[2];    
                    dataGridView1[3, lin].Value = campos[3];    


                    lin++;
                }
            }
            


        }
              
               
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {





        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Categorias.Items.Add(textBox1.Text);


            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(file_cate);
            for (int i = 0; i < Categorias.Items.Count; i++)
            {
                sw.WriteLine(Categorias.Items[i].ToString());
            }
            sw.Close();
        }
       


        private void panel3_Paint(object sender, PaintEventArgs e)
        {


        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            while (Categorias.CheckedItems.Count > 0)
            {
                Categorias.Items.RemoveAt(Categorias.CheckedIndices[0]);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            listBox3.Items.Clear();
            if ((comboBox1.Text == "Recente") && Categorias.CheckedItems.Count == 0)
            {
                if (File.Exists(file_ite))
                {
                    var dados = File.ReadAllLines(file_ite).Reverse();
                    int lin = 0;
                    foreach (string linha in dados)
                    {
                        string[] campos = linha.Split(';');

                        dataGridView1.Rows.Add(1);
                        dataGridView1[0, lin].Value = campos[0];
                        dataGridView1[1, lin].Value = campos[1];
                        dataGridView1[2, lin].Value = campos[2];
                        dataGridView1[3, lin].Value = campos[3];


                        lin++;
                    }
                }
            }
            
            
            if ((comboBox1.Text == "Recente") && Categorias.CheckedItems.Count >0)
            {
                dataGridView1.Rows.Clear();
                foreach (string s in Categorias.CheckedItems)
                {
                    listBox3.Items.Add(s);
                }
                if (File.Exists(file_ite))
                {
                    var dados = File.ReadAllLines(file_ite).Reverse();
                    int lin = 0;
                   
                    foreach (string linha in dados)
                    {
                        
                        string[] campos = linha.Split(';');
                       
                            
                            if (!listBox3.Items.Contains(campos[3]))
                            {
                                continue;
                            }
                           
                        

                        dataGridView1.Rows.Add(1);
                        dataGridView1[0, lin].Value = campos[0];
                        dataGridView1[1, lin].Value = campos[1];
                        dataGridView1[2, lin].Value = campos[2];
                        dataGridView1[3, lin].Value = campos[3];


                        lin++;

                    }




                }
            }
        }   


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)

        {
            
            StreamWriter sw;
            if (File.Exists(file_ite))
            {
                sw = File.AppendText(file_ite);

            }
            else
            {
                sw = File.CreateText(file_ite);
            }
            
            sw.WriteLine(textBox3.Text + ";" + textBox4.Text + ";" + textBox5.Text + ";" + textBox6.Text);
            sw.Close();


            string fileName = textBox5.Text + ".txt";
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine();
            }
         




        }


        //row.Cells["Column3"].Value.ToString()
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            imageList1 = new ImageList();

            // Set the ImageSize property to a larger size 
            // (the default is 16 x 16).
            imageList1.ImageSize = new Size(112, 112);

            listBox1.Items.Clear();
            if (e.RowIndex >=0)
            {   
                
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string pasta = row.Cells["Column3"].Value.ToString()+ ".txt";
                StreamReader sr;
                if (File.Exists(pasta))
                {
                    sr = File.OpenText(pasta);
                    string linha = "";
                    while ((linha = sr.ReadLine()) != null)
                    {
                        
                        listBox1.Items.Add(linha);

                    }
                    sr.Close();
                   
                }
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                if (listBox1.Items.Count >0)
                {
                    string[] arr = new string[listBox1.Items.Count];
                    
                    for(int j = 0; j<listBox1.Items.Count; j++)
                    {
                        arr[j] = listBox1.Items[j].ToString();
                    // adiciona à imagelist
                        try
                        {
                            imageList1.Images.Add(foto_numero.ToString("##"), Image.FromFile(arr[j] + ".jpg"));
                            pictureBox1.Image = Image.FromFile(arr[j] + ".jpg");
                            // OU:
                            pictureBox1.Image = new Bitmap(arr[j] + ".jpg");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Não existe ficheiros disponiveis");
                        }

                        foto_numero++;
                        i++;

                        //le_comentarios_foto(openFileDialog1.SafeFileName);

                    }




                }
                else
                {
                    MessageBox.Show("pasta não existe");
                }
                

                        
            }

            
            int num = listBox1.Items.Count;
            for (int i = 0; i < num; i++)
            {
                


            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
                    
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        { 
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string file = textBox7.Text + ".txt";
            StreamWriter sw;
            if (File.Exists(file))
            {
                
                sw = File.AppendText(file);
                File.WriteAllText(file, String.Empty);
                sw.WriteLine(textBox8.Text);
                sw.Close();
            }
            else
            {
                
               MessageBox.Show("pasta não existe");

            }
            
            

}

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                // pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                pictureBox1.Image = imageList1.Images[0];
            }
            catch (Exception)
            {
                MessageBox.Show("Não existe ficheiros");
            }


        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (i > 0)
                {
                    i--;
                }

                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = imageList1.Images[i];

                //le_comentarios_foto(listBox2.Items[i].ToString());
            }
            catch(Exception)
            {
                MessageBox.Show("Não existe ficheiros");
            }


        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (i < imageList1.Images.Count - 1)   // o array começa em 0...
                {
                    i++;

                }

                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = imageList1.Images[i];
            }
            catch(Exception)
            {
                MessageBox.Show("Não existe ficheiros");
            }
           
            
                
                    
            
            
            
            
            
            
            //le_comentarios_foto(listBox2.Items[i].ToString());
        }


        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                //   pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                int n = imageList1.Images.Count;
                pictureBox1.Image = imageList1.Images[n - 1];
            }
            catch (Exception)
            {
                MessageBox.Show("Não existe ficheiros");
            }
        }
            void le_comentarios_foto(string ficheiro)
            {
                int pos = ficheiro.IndexOf('.');
                ficheiro = ficheiro.Substring(0, pos) + ".txt";
                listBox2.Items.Clear();
                //String ficheiro = fotoName;  // o nome do ficheiro é o nome da foto
                if (File.Exists(ficheiro))
                {
                    string[] comments = File.ReadAllLines(ficheiro);
                    foreach (string linha in comments)
                    {
                        listBox2.Items.Add(linha);
                    }
                }
            }
            void save_coments_foto(string ficheiro)
            {
                // MessageBox.Show(ficheiro);
                int pos = ficheiro.IndexOf('.');
                ficheiro = ficheiro.Substring(0, pos) + ".txt";

                StreamWriter sw = File.CreateText(ficheiro);
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    sw.WriteLine(listBox2.Items[i]);
                }

                sw.Close();

            }

            private void button12_Click(object sender, EventArgs e)
            {
                int pos = listBox2.SelectedIndex;   // linha selecionada
                                                    //MessageBox.Show(pos.ToString());
                string comment = label3.Text + "|" + DateTime.Now.ToString("yyyy-MM-dd") + ":" + textBox9.Text;
                if (pos == -1)  // não selecionei nada
                    listBox2.Items.Add(comment);
                else
                {
                    comment = "   " + comment;
                    listBox2.Items.Insert(pos + 1, comment);
                }


                save_coments_foto(listBox2.Items[i].ToString());
            }

            private void textBox9_TextChanged(object sender, EventArgs e)
            {

            }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }  }   




