using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace jogo_da_forca
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        string palavraInformada = "";
        string acertosDaPalavra = "";
        int totalErros = 0;
        string letraerrada1 = "";
        string letraerrada2 = "";
        string letraerrada3 = "";
        string letraerrada4 = "";
        string letraerrada5 = "";
        string letraerrada6 = "";


        /// <summary>
        /// Ao clicar no botão Jogar
        /// </summary>
        private void IniciarJogo(object sender, RoutedEventArgs e)
        {
           foreach (char i in txtPalavra.Text.ToString())
            {
                palavraInformada += i;
                acertosDaPalavra += "_";
               
            }

            txtPalavra.MaxLength = 1;

            btnJogar.Visibility = Visibility.Hidden;
            btnInserirLetra.Visibility = Visibility.Visible;

            txtFrase.Text = "";
            txtFrase.Text = acertosDaPalavra;
            txtPalavra.Text = "";
            

        }

        /// <summary>
        /// Ao clicar no botão Inserir
        /// </summary>
        private void InserirLetra(object sender, RoutedEventArgs e)
        {
            if (txtPalavra.Text != "" && txtPalavra.Text != " ")
            {
                txtFrase.Text = "";
                bool achouLetra = false;
                string acertoTemporario = "";
                for (int i = 0; i < palavraInformada.Length; i++)
                {
                    if (txtPalavra.Text == palavraInformada[i].ToString())
                    {
                        txtFrase.Text += $"{txtPalavra.Text}";
                        acertoTemporario += txtPalavra.Text;
                        achouLetra = true;
                    }
                    else
                    {
                        txtFrase.Text += $"{acertosDaPalavra[i]}";
                        acertoTemporario += acertosDaPalavra[i];
                    }

                }
                acertosDaPalavra = acertoTemporario;
                if (achouLetra == false)
                {
                    totalErros += 1;
                    CalculaErros();
                }
                txtPalavra.Text = "";
                VerificaVitoria();

            }
        }

        /// <summary>
        /// Ao clicar no botão Reiniciar
        /// </summary>
         

        /// <summary>
        /// Ao clicar no botão Sair
        /// </summary>
        private void SairDaAplicacao(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Os três métodos abaixo eu extrai da solução original, você pode partir deles ou criar os próprios.
        private void CalculaErros()
        {
            if (totalErros == 1)
            {
                txtCabeca.Visibility = Visibility.Visible;
                letraerrada1 = txtPalavra.Text;
                txtLetrasErradas.Text += txtPalavra.Text + ", ";
            }

            if (totalErros == 2)
            {
                if (txtPalavra.Text != letraerrada1 && txtPalavra.Text != letraerrada3 && txtPalavra.Text != letraerrada4 && txtPalavra.Text != letraerrada5 && txtPalavra.Text != letraerrada6)
                {
                    txtCorpo.Visibility = Visibility.Visible;
                    letraerrada2 = txtPalavra.Text;
                    txtLetrasErradas.Text += txtPalavra.Text + ", ";
                    totalErros = 2;
                }
                else
                {
                    totalErros = 1;
                }
            }

            if (totalErros == 3 && txtPalavra.Text != letraerrada1 && txtPalavra.Text != letraerrada2 && txtPalavra.Text != letraerrada4 && txtPalavra.Text != letraerrada5 && txtPalavra.Text != letraerrada6)
            {
                if (txtPalavra.Text != letraerrada1 && txtPalavra.Text != letraerrada3 && txtPalavra.Text != letraerrada4 && txtPalavra.Text != letraerrada5 && txtPalavra.Text != letraerrada6)
                {
                    txtBracoDireito.Visibility = Visibility.Visible;
                    letraerrada3 = txtPalavra.Text;
                    txtLetrasErradas.Text += txtPalavra.Text + ", ";
                    totalErros = 3;
                }
                else
                {
                    totalErros = 2;
                }
            }

            if (totalErros == 4 && txtPalavra.Text != letraerrada1 && txtPalavra.Text != letraerrada2 && txtPalavra.Text != letraerrada3 && txtPalavra.Text != letraerrada5 && txtPalavra.Text != letraerrada6)
            {
                if (txtPalavra.Text != letraerrada1 && txtPalavra.Text != letraerrada3 && txtPalavra.Text != letraerrada4 && txtPalavra.Text != letraerrada5 && txtPalavra.Text != letraerrada6)
                {
                    txtBracoEsquerdo.Visibility = Visibility.Visible;
                    letraerrada4 = txtPalavra.Text;
                    txtLetrasErradas.Text += txtPalavra.Text + ", ";
                    totalErros = 4;
                }
                else
                {
                    totalErros = 3;
                }
            }

            if (totalErros == 5 && txtPalavra.Text != letraerrada1 && txtPalavra.Text != letraerrada2 && txtPalavra.Text != letraerrada3 && txtPalavra.Text != letraerrada4 && txtPalavra.Text != letraerrada6)
            {
                if (txtPalavra.Text != letraerrada1 && txtPalavra.Text != letraerrada3 && txtPalavra.Text != letraerrada4 && txtPalavra.Text != letraerrada5 && txtPalavra.Text != letraerrada6)
                {
                    txtPernaDireita.Visibility = Visibility.Visible;
                    letraerrada5 = txtPalavra.Text;
                    txtLetrasErradas.Text += txtPalavra.Text + ", ";
                    totalErros = 5;
                }
                else
                {
                    totalErros = 4;
                }
            }

            if (totalErros == 6 && txtPalavra.Text != letraerrada1 && txtPalavra.Text != letraerrada2 && txtPalavra.Text != letraerrada3 && txtPalavra.Text != letraerrada4 && txtPalavra.Text != letraerrada5)
            {
                if (txtPalavra.Text != letraerrada1 && txtPalavra.Text != letraerrada3 && txtPalavra.Text != letraerrada4 && txtPalavra.Text != letraerrada5 && txtPalavra.Text != letraerrada6)
                {
                    txtPernaEsquerda.Visibility = Visibility.Visible;
                    letraerrada6 = txtPalavra.Text;
                    txtLetrasErradas.Text += txtPalavra.Text + ", ";
                    totalErros = 6;
                }
                else
                {
                    totalErros = 5;
                }
            }

            if (totalErros == 7 && txtPalavra.Text != letraerrada1 && txtPalavra.Text != letraerrada2 && txtPalavra.Text != letraerrada3 && txtPalavra.Text != letraerrada4 && txtPalavra.Text != letraerrada5 && txtPalavra.Text != letraerrada6)
            {
                if (txtPalavra.Text != letraerrada1 && txtPalavra.Text != letraerrada3 && txtPalavra.Text != letraerrada4 && txtPalavra.Text != letraerrada5 && txtPalavra.Text != letraerrada6)
                {
                    txtLetrasErradas.Text += txtPalavra.Text;
                    totalErros = 7;

                    MessageBox.Show("Você perdeu!", "Game Over!", MessageBoxButton.OK, MessageBoxImage.Error);
                    btnInserirLetra.Visibility = Visibility.Hidden;
                    txtPalavra.Text = "";
                    VerificaVitoria();

                    Reiniciar();

                }

                else
                {
                    totalErros = 6;
                }

            }

        }

        private void VerificaVitoria()
        {

            if (acertosDaPalavra == palavraInformada)
            {
                acertosDaPalavra = "";
                MessageBox.Show("Você Ganhou!", "Parabéns!", MessageBoxButton.OK, MessageBoxImage.Information);
                btnInserirLetra.Visibility = Visibility.Hidden;

                Reiniciar();
            }
            
        }

        

        private void Reiniciar()
        {
            MainWindow frmMainWindow = new MainWindow();
            frmMainWindow.Show();
            Close();
        }
        
    }
}