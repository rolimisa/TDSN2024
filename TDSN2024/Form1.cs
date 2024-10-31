using System;
using System.Globalization;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using FormaCircunferencia;


namespace TDSN2024
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmbForma_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbForma.Text)
            {
                case "Circunferência":
                    ExibirRaio(true);
                    ExibirLado(false);
                    ExibirAltura(false);
                    ExibirBase(false);
                    ExibirHipotenusa(false);
                    ExibirTriangulo(false);
                    Limpa();
                    break;

                case "Quadrado":
                    ExibirRaio(false);
                    ExibirLado(true);
                    ExibirAltura(false);
                    ExibirBase(false);
                    ExibirHipotenusa(false);
                    ExibirTriangulo(false);
                    Limpa();
                    break;

                case "Triângulo":
                    ExibirRaio(false);
                    ExibirLado(false);
                    ExibirAltura(true);
                    ExibirBase(true);
                    ExibirHipotenusa(true);
                    ExibirTriangulo(true);
                    break;

                case "Retângulo":
                    ExibirRaio(false);
                    ExibirLado(false);
                    ExibirAltura(true);
                    ExibirBase(true);
                    ExibirHipotenusa(false);
                    ExibirTriangulo(false);
                    Limpa();
                    break;


                default:
                    break;
            }
        }

        private void cmbTriangulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTriangulo.Text)
            {
                case "Reto":
                    {
                        Altura();
                        ExibirRaio(false);
                        ExibirLado(false);
                        ExibirAltura(true);
                        ExibirBase(true);
                        ExibirHipotenusa(true);
                        Limpa();
                        break;
                    }
                case "Equilátero":
                    {
                        txtAltura.Visible = false;
                        txtAltura.Enabled = false;
                        AlturaEquilatero.Visible = false;
                        ExibirRaio(false);
                        ExibirLado(false);
                        ExibirAltura(false);
                        ExibirBase(true);
                        ExibirHipotenusa(false);
                        Limpa();
                        break;
                    }
                case "Isósceles":
                    {
                        Altura();
                        ExibirAltura(false);
                        ExibirRaio(false);
                        ExibirLado(true);
                        ExibirBase(true);
                        ExibirHipotenusa(true);
                        Limpa(); 
;                        break;
                    }
            }
        }

        private void Altura()
        {
            AlturaEquilatero.Visible = false;
            txtAltura.Enabled = true;
        }

        private void ExibirLado(bool visivel)
        {
            lblLado.Visible = txtLado.Visible = visivel;
        }

        private void ExibirRaio(bool visivel)
        {
            lblRaio.Visible = txtRaio.Visible = visivel;
        }

        private void ExibirBase(bool visivel)
        {
            lblBase.Visible = txtBase.Visible = visivel;
        }

        private void ExibirTriangulo(bool visivel)
        {
            cmbTriangulo.Visible = visivel;
            lblTriangulo.Visible = visivel;

        }

        private void ExibirAltura(bool visivel)
        {
            lblAltura.Visible = txtAltura.Visible = visivel;
        }

        private void ExibirHipotenusa(bool visivel)
        {
            txtHipotenusa.Visible = visivel;
            lblHipotenusa.Visible = visivel;
        }
        private void Limpa()
        {
            txtArea.Text = "";
            txtPerimetro.Text = "";
            txtHipotenusa.Text = "";
        }
        private void btnCriar_Click(object sender, EventArgs e)
        {
            if (txtBase.Text != "" && txtAltura.Text != "" || txtLado.Text != "" || txtRaio.Text != "" || cmbTriangulo.Text == "Equilátero" && txtBase.Text != "")
            {
                if (Regex.IsMatch(txtLado.Text, @"^\d+(,\d+)?$") || Regex.IsMatch(txtAltura.Text, @"^\d+(,\d+)?$") && Regex.IsMatch(txtBase.Text, @"^\d+(,\d+)?$") || cmbTriangulo.Text == "Equilátero" && Regex.IsMatch(txtBase.Text, @"^\d+(,\d+)?$") || Regex.IsMatch(txtRaio.Text, @"^\d+(,\d+)?$"))
                {

                    switch (cmbForma.Text)
                    {
                        case "Quadrado":
                            {
                                FormaGeometrica objeto;
                                objeto = new Quadrado() { Lado = Convert.ToDouble(txtLado.Text, new CultureInfo("pt-BR")) };
                                cmbObjetos.Items.Add(objeto);
                                txtLado.Clear();
                                break;
                            }

                        case "Circunferência":
                            {
                                FormaGeometrica objeto;
                                objeto = new Circunferencia()
                                {
                                    Raio = Convert.ToDouble(txtRaio.Text, new CultureInfo("pt-BR")),
                                };
                                cmbObjetos.Items.Add(objeto);
                                txtRaio.Clear();
                                break;
                            }
                        case "Retângulo":
                            {
                                FormaGeometrica objeto;
                                objeto = new Retangulo()
                                {
                                    Altura = Convert.ToDouble(txtAltura.Text, new CultureInfo("pt-BR")),
                                    Base = Convert.ToDouble(txtBase.Text, new CultureInfo("pt-BR"))
                                };
                                cmbObjetos.Items.Add(objeto);
                                txtAltura.Clear();
                                txtBase.Clear();
                                break;
                            }
                        
                           case "Triângulo":
                            {
                                if (cmbTriangulo.Text == "Reto")
                                {
                                    FormaGeometrica objeto;
                                    objeto = new TrianguloReto()
                                    {
                                        Base = Convert.ToDouble(txtBase.Text, new CultureInfo("pt-BR")),
                                        Altura = Convert.ToDouble(txtAltura.Text, new CultureInfo("pt-BR"))
                                    };
                                    cmbObjetos.Items.Add(objeto);
                                    txtBase.Clear();
                                    txtAltura.Clear();
                                }
                                else if (cmbTriangulo.Text == "Equilátero")
                                {
                                    FormaGeometrica objeto;
                                    objeto = new TrianguloEquilatero() { Base = Convert.ToDouble(txtBase.Text, new CultureInfo("pt-BR")) };
                                    cmbObjetos.Items.Add(objeto);
                                    txtBase.Clear();
                                }
                                else if (cmbTriangulo.Text == "Isósceles")
                                {
                                    FormaGeometrica objeto;
                                    objeto = new TrianguloIsosceles()
                                    {
                                        Base = Convert.ToDouble(txtBase.Text, new CultureInfo("pt-BR")),
                                        Lado = Convert.ToDouble(txtLado.Text, new CultureInfo("pt-BR"))
                                    };
                                    cmbObjetos.Items.Add(objeto);
                                    txtBase.Clear();
                                    txtLado.Clear();
                                }
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
                else { MessageBox.Show("Digite apenas números!"); }
            }
            else { MessageBox.Show("Insira um valor!"); }
        }


        private void cmbObjetos_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormaGeometrica objeto = cmbObjetos.SelectedItem as FormaGeometrica;
            txtArea.Text = objeto.CalcularArea().ToString();
            txtPerimetro.Text = objeto.CalcularPerimetro().ToString();

            if (cmbObjetos.Text.Contains("Reto") || cmbObjetos.Text.Contains("Isósceles") || cmbObjetos.Text.Contains("Equilátero"))
            {
                Triângulo objecto = cmbObjetos.SelectedItem as Triângulo;
                txtHipotenusa.Text = objecto.CalcularHipotenusa().ToString();
                AlturaEquilatero.Text = objecto.Altura.ToString();
            }
        }


        private void AtualizarAreaEPerimetro(FormaGeometrica objeto)
        {
            txtArea.Text = objeto.CalcularArea().ToString();
            txtPerimetro.Text = objeto.CalcularPerimetro().ToString();
        }

        private void AtualizarTriangulo(Triângulo triangulo)
        {
            txtHipotenusa.Text = triangulo.CalcularHipotenusa().ToString();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
