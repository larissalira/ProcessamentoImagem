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
                comboBox2.Items.Add("Prewitt");
                comboBox2.Items.Add("Alto Reforço");
                comboBox2.Items.Add("Sobel");
                comboBox2.Items.Add("Gradiente");
                comboBox2.Items.Add("Gradiente Cruzado");
                comboBox2.Items.Add("Negativo");
                comboBox2.Items.Add("Gamma");
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

        private void btn_aplicar_Click(object sender, EventArgs e)
        {
            if(_imagemCarregada == null)
            {
                MessageBox.Show("Por favor selecione uma imagem!");
            }
            if (comboBoxOpcoes.Text.Equals("Filtros"))
            {
                filtros();
            }
            else if (comboBoxOpcoes.Text.Equals("Operações Numéricas"))
            {
                opNumericas();
            }
            else if (comboBoxOpcoes.Text.Equals("Gato de Arnold"))
            {
                gatoArnold();
            }
            else if (comboBoxOpcoes.Text.Equals("Histograma"))
            {
                histograma();
            }
            else if (comboBoxOpcoes.Text.Equals("Operações Geométricas"))
            {
                opGeometricas();
            }
            else
            {
                MessageBox.Show("Por favor selecione uma opção!");
            }
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text.Equals("Alto Reforço")){
                inputPanel2.Visible = true;
                label3.Text = "A: ";
                MessageBox.Show("A>=1\nUtilize ',' para números decimais!");

            }
            else if (comboBox2.Text.Equals("Gamma")){
                inputPanel2.Visible = true;
                label3.Text = "Gamma: ";
                MessageBox.Show("0<=Gamma<=1 \nUse ',' para números decimais!");
            }
            else if (comboBox2.Text.Equals("Logaritmo"))
            {
                inputPanel2.Visible = true;
                label3.Text = "Constante: ";
                MessageBox.Show("Utilize ',' para números decimais!");
            }
            else
            {
                inputPanel1.Visible = false;
                inputPanel2.Visible = false;
            }
        }

        private void filtros()
        {
            GerenciamentoFiltros gerFiltros = new GerenciamentoFiltros();


            string op = comboBox2.Text;
            switch (op)
            {
                case "Média":
                    pictureResultado.Image = (Image)gerFiltros.FiltroMedia(_imagemCarregada).Clone();
                    pictureResultado.Update();
                    break;
                case "Mediana":
                    pictureResultado.Image = (Image)gerFiltros.FiltroMediana(_imagemCarregada).Clone();
                    pictureResultado.Update();
                    break;
                case "Passa Alta":
                    pictureResultado.Image = (Image)gerFiltros.FiltroPassaAlta(_imagemCarregada).Clone();
                    pictureResultado.Update();
                    break;
                case "Prewitt":
                    pictureResultado.Image = (Image)gerFiltros.FiltroPrewitt(_imagemCarregada).Clone();
                    pictureResultado.Update();
                    break;
                case "Alto Reforço":
                    if (textBox3.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor preencha o valor de A");
                    }
                    else
                    {
                        double a = Convert.ToDouble(textBox3.Text);
                        pictureResultado.Image = (Image)gerFiltros.FiltroAltoReforco(_imagemCarregada, a).Clone();
                        pictureResultado.Update();
                    }
                    break;
                case "Sobel":
                    pictureResultado.Image = (Image)gerFiltros.FiltroSobel(_imagemCarregada).Clone();
                    pictureResultado.Update();
                    break;
                case "Gradiente":
                    pictureResultado.Image = (Image)gerFiltros.FiltroGradiente(_imagemCarregada).Clone();
                    pictureResultado.Update();
                    break;
                case "Gradiente Cruzado":
                    pictureResultado.Image = (Image)gerFiltros.FiltroGradienteCruzado(_imagemCarregada).Clone();
                    pictureResultado.Update();
                    break;
                case "Negativo":
                    pictureResultado.Image = (Image)gerFiltros.FiltroNegativo(_imagemCarregada).Clone();
                    pictureResultado.Update();
                    break;
                case "Gamma":
                    if (textBox3.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor preencha o valor de Gamma");
                    }
                    else
                    {
                        double gamma = Convert.ToDouble(textBox3.Text);
                        pictureResultado.Image = (Image)gerFiltros.FiltroGama(_imagemCarregada, gamma).Clone();
                        pictureResultado.Update();
                    }
                    break;
                case "Logaritmo":
                    if (textBox3.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor preencha o valor da Constante");
                    }
                    else
                    {
                        double c = Convert.ToDouble(textBox3.Text);
                        pictureResultado.Image = (Image)gerFiltros.FiltroLogaritmo(_imagemCarregada, c).Clone();
                        pictureResultado.Update();
                    }
                    break;
                default:
                    MessageBox.Show("Por favor selecione o filtro que deseja utilizar!");
                    break;

            }
        }

        private void opNumericas()
        {
            string op = comboBox2.Text;
            switch (op)
            {
                case "Soma":

                    break;
                case "Subtração":

                    break;
                case "Multiplicação":

                    break;
                case "Divisão":

                    break;
                case "AND":

                    break;
                case "OR":

                    break;
                case "XOR":

                    break;
                default:
                    MessageBox.Show("Por favor selecione a operação que deseja fazer!");
                    break;


            }
        }

        private void opGeometricas()
        {
            string op = comboBox2.Text;
            switch (op)
            {
                case "Escala":

                    break;
                case "Rotação":

                    break;
                case "Cisalhamento":

                    break;
                case "Reflexão":

                    break;
                case "Translação":

                    break;

                default:
                    MessageBox.Show("Por favor selecione a operação que deseja fazer!");
                    break;

            }
        }

        private void gatoArnold()
        {

        }

        private void histograma()
        {

        }
    }
}
