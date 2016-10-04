using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessamentoImg.Control;
using ProcessamentoImg.Model;

namespace ProcessamentoImg
{
    public partial class Form1 : Form
    {
        Imagem _imagemCarregada = null;

        public Form1()
        {
            InitializeComponent();
        }



        private void comboBoxOpcoes_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxOpcoes.Text.Equals("Filtros"))
            {
                flowPanel2.Visible = false;
                btn_carregarImg2.Visible = false;
                comboBox2.Visible = true;
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Média");
                comboBox2.Items.Add("Mediana");
                comboBox2.Items.Add("Passa Alta");
                comboBox2.Items.Add("Passa Baixa");
                comboBox2.Items.Add("Alto Reforço");
                comboBox2.Items.Add("Sobel");
                comboBox2.Items.Add("Gradiente");
                comboBox2.Items.Add("Gradiente Cruzado");
                comboBox2.Items.Add("Negativo");
                comboBox2.Items.Add("Gama");
                comboBox2.Items.Add("Logaritmo");
                
            }
            else if (comboBoxOpcoes.Text.Equals("Operações Numéricas"))
            {
                flowPanel2.Visible = true;
                btn_carregarImg2.Visible = true;
                comboBox2.Visible = true;
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Soma");
                comboBox2.Items.Add("Subtração");
                comboBox2.Items.Add("Multiplicação");
                comboBox2.Items.Add("Divisão");
                comboBox2.Items.Add("AND");
                comboBox2.Items.Add("OR");
                comboBox2.Items.Add("XOR");
            }
            else if (comboBoxOpcoes.Text.Equals("Gato de Arnold"))
            {
                flowPanel2.Visible = false;
                btn_carregarImg2.Visible = false;
                comboBox2.Visible = false;
            }
            else if (comboBoxOpcoes.Text.Equals("Histograma"))
            {
                flowPanel2.Visible = false;
                btn_carregarImg2.Visible = false;
                comboBox2.Visible = false;
            }
            else if (comboBoxOpcoes.Text.Equals("Operações Geométricas"))
            {
                flowPanel2.Visible = false;
                comboBox2.Visible = true;
                btn_carregarImg2.Visible = false;
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Escala");
                comboBox2.Items.Add("Rotação");
                comboBox2.Items.Add("Cisalhamento");
                comboBox2.Items.Add("Reflexão");
                comboBox2.Items.Add("Translação");

            }
        }

        private void btn_carregarImg1_Click(object sender, EventArgs e)
        {
            DialogResult userResult = openFileDialog1.ShowDialog();
            if (userResult == DialogResult.OK)
            {
                LeitorImagem pgmReader = new LeitorImagem(openFileDialog1.FileName);
                pictureBox1.Image = (Image)pgmReader.ConverterParaBitmap().Clone();
                _imagemCarregada = pgmReader.imagemCarregada;
                pictureBox1.Update();
            }
        }

        private void btn_carregarImg2_Click(object sender, EventArgs e)
        {
            DialogResult userResult = openFileDialog2.ShowDialog();
            if (userResult == DialogResult.OK)
            {
                LeitorImagem pgmReader = new LeitorImagem(openFileDialog2.FileName);
                pictureBox2.Image = (Image)pgmReader.ConverterParaBitmap().Clone();
                _imagemCarregada = pgmReader.imagemCarregada;
                pictureBox2.Update();
            }
        }

       
    }
}
