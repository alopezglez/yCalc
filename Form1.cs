using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yCalc
{
    public partial class Form1 : Form
    {
        bool hayComa = false;       // para que en pantalla no aparezca un numero con dos comas o más Ej: "2,,345" o "2,34,56"
                                    // cuando el usuario presiona la coma esta variable se establece en True, y hasta que la
                                    // cifra en pantalla cambie no se cambia a False

        double ultimaCifra = 0;     // En el momento que se presiona un operador, la cifra en pantalla se guarda aquí para
                                    // recordarla y poder operar con ella

        double preResultado = 0;    // guarda el resultado preeliminar de las operaciones realizadas hasta el momento.

        string operador = "";       // Guarda el tipo de operador seleccionado

        public Form1()
        {
            InitializeComponent();
        }


        //Este evento captura cuando el usuario pulsa una tecla siempre que
        //el formulario tenga el foco.
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Primero comprobamos que la ltecla presionada se corresponda con las teclas numéricas,
            //operadores y punto.
            //
            // ASCii del 48 al 57   =>  Números del 0 al 9 respectivamente.
            // ASCii 42,43,45,47    =>  Operadores *,+,-,/ respectivamente.
            // ASCii 46,44          =>  . y , respectivamente.

            if (e.KeyChar == 13)
            {
                btResultado.Focus();
                btResultado.PerformClick();
                return;

            }

            if (e.KeyChar == 127)
            {
                btDel.Focus();
                btDel.PerformClick();
                return;

            }

            if (e.KeyChar >= 42 && e.KeyChar <= 57)
            {

                switch (e.KeyChar)
                {
                    case (char)44:
                    case (char)46:
                        btPunto.Focus();
                        btPunto.PerformClick();
                        break;

                    case (char)42:
                        btMulti.Focus();
                        btMulti.PerformClick();
                        break;

                    case (char)43:
                        btSuma.Focus();
                        btSuma.PerformClick();
                        break;

                    case (char)45:
                        btResta.Focus();
                        btResta.PerformClick();
                        break;

                    case (char)47:
                        btDiv.Focus();
                        btDiv.PerformClick();
                        break;

                    case (char)48:
                        button10.Focus();
                        button10.PerformClick();
                        break;

                    case (char)49:
                        button1.Focus();
                        button1.PerformClick();
                        break;

                    case (char)50:
                        button2.Focus();
                        button2.PerformClick();
                        break;

                    case (char)51:
                        button3.Focus();
                        button3.PerformClick();
                        break;

                    case (char)52:
                        button4.Focus();
                        button4.PerformClick();
                        break;

                    case (char)53:
                        button5.Focus();
                        button5.PerformClick();
                        break;

                    case (char)54:
                        button6.Focus();
                        button6.PerformClick();
                        break;

                    case (char)55:
                        button7.Focus();
                        button7.PerformClick();
                        break;

                    case (char)56:
                        button8.Focus();
                        button8.PerformClick();
                        break;

                    case (char)57:
                        button9.Focus();
                        button9.PerformClick();
                        break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addNumero(1);
        }

        private void addNumero(int numero)
        {
            //Añade números a la cifra en pantalla pero como máximo 12 incluyendo decimales

            switch (numero) {

                case 10:
                    bool e = lblScreen.Text.Contains(",");

                    if (e == false)
                    {
                        e = lblScreen.Text.Contains(".");

                        if (e == false)
                        {
                            if (lblScreen.Text.Length  < 10)
                            {
                                lblScreen.Text += ",";
                            }
                        }
                    }

                    break;

                default:
                    if (lblScreen.Text.Length < 12)
                    {
                        if (numero == 0)
                        {
                            if (lblScreen.Text == "0")
                            {
                                return;//Si en pantalla hay un 0 entonces no hace nada.
                            }
                        }

                        if (lblScreen.Text == "0")
                        {
                            lblScreen.Text = numero.ToString();
                        }
                        else
                        {
                            lblScreen.Text += numero.ToString();
                        }
                    }
                    break;

            }
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            //Borra variables y contenido en pantalla
            hayComa = false;
            ultimaCifra = 0;
            preResultado = 0;

            lblScreen.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addNumero(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addNumero(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addNumero(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            addNumero(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            addNumero(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            addNumero(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            addNumero(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            addNumero(9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            addNumero(0);
        }

        private void btPunto_Click(object sender, EventArgs e)
        {
            addNumero(10); // Paso un 10 indicando internamente que se ha pulsado una coma
        }
    }
}
