namespace proyecto1DS4
{
    public partial class Form1 : Form
    {
        private Calculadora calculadora;
        private string operador;
        private double primerNumero;

        public Form1()
        {
            InitializeComponent();
            calculadora = new Calculadora();
        }

        private void btn0_Click(object sender, EventArgs e) => AgregarNumero("0");
        private void btn1_Click(object sender, EventArgs e) => AgregarNumero("1");
        private void btn2_Click(object sender, EventArgs e) => AgregarNumero("2");
        private void btn3_Click(object sender, EventArgs e) => AgregarNumero("3");
        private void btn4_Click(object sender, EventArgs e) => AgregarNumero("4");
        private void btn5_Click(object sender, EventArgs e) => AgregarNumero("5");
        private void btn6_Click(object sender, EventArgs e) => AgregarNumero("6");
        private void btn7_Click(object sender, EventArgs e) => AgregarNumero("7");
        private void btn8_Click(object sender, EventArgs e) => AgregarNumero("8");
        private void btn9_Click(object sender, EventArgs e) => AgregarNumero("9");

        private void btnSumar_Click(object sender, EventArgs e) => EstablecerOperador("+");
        private void btnRestar_Click(object sender, EventArgs e) => EstablecerOperador("-");
        private void btnMultiplicar_Click(object sender, EventArgs e) => EstablecerOperador("×");
        private void btnDividir_Click(object sender, EventArgs e) => EstablecerOperador("÷");
        private void btnCuadrado_Click(object sender, EventArgs e) => CalcularCuadrado();
        private void btnRaiz_Click(object sender, EventArgs e) => CalcularRaiz();
        private void btnNegativo_Click(object sender, EventArgs e) => CambiarSigno();
        private void btnDecimal_Click(object sender, EventArgs e) => AgregarNumero(".");
        private void btnCE_Click(object sender, EventArgs e) => BorrarUltimaEntrada();
        private void btnC_Click(object sender, EventArgs e) => txtResultado.Clear();
        private void btnCalcular_Click(object sender, EventArgs e) => RealizarCalculo();

        private void AgregarNumero(string numero)
        {
            txtResultado.Text += numero;
        }

        private void EstablecerOperador(string op)
        {
            if (double.TryParse(txtResultado.Text, out primerNumero))
            {
                operador = op;
                txtResultado.Text += " " + operador + " ";
            }
        }

        private void RealizarCalculo()
        {
            string[] partes = txtResultado.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (partes.Length == 3 && double.TryParse(partes[2], out double segundoNumero))
            {
                double resultado = 0;

                try
                {
                    switch (operador)
                    {
                        case "+":
                            resultado = calculadora.Sumar(primerNumero, segundoNumero);
                            break;
                        case "-":
                            resultado = calculadora.Restar(primerNumero, segundoNumero);
                            break;
                        case "×":
                            resultado = calculadora.Multiplicar(primerNumero, segundoNumero);
                            break;
                        case "÷":
                            resultado = calculadora.Dividir(primerNumero, segundoNumero);
                            break;
                    }

                    txtResultado.Text = resultado.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CalcularCuadrado()
        {
            if (double.TryParse(txtResultado.Text, out double numero))
            {
                double resultado = calculadora.Cuadrado(numero);
                txtResultado.Text = resultado.ToString();
            }
        }

        private void CalcularRaiz()
        {
            if (double.TryParse(txtResultado.Text, out double numero))
            {
                try
                {
                    double resultado = calculadora.Raiz(numero);
                    txtResultado.Text = resultado.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CambiarSigno()
        {
            if (double.TryParse(txtResultado.Text, out double numero))
            {
                numero = -numero;
                txtResultado.Text = numero.ToString();
            }
        }

        private void BorrarUltimaEntrada()
        {
            
            if (txtResultado.Text.Length > 0)
            {
                if (txtResultado.Text.EndsWith(" "))
                {
                    
                    txtResultado.Text = txtResultado.Text.Substring(0, txtResultado.Text.Length - 3);
                }
                else
                {
                    
                    txtResultado.Text = txtResultado.Text.Substring(0, txtResultado.Text.Length - 1);
                }
            }
        }
    }
}
