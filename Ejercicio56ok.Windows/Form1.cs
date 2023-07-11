using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio56ok.Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int CantidadIngresada = 0, CantidadSuperior15 = 0;
        double PromedioTemperaturas = 0;

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                var celsius = double.Parse(txtCelsius.Text);
                if (celsius != 0)
                {

                }
                CantidadIngresada++;
                PromedioTemperaturas += celsius;
                if (celsius > 15)
                {
                    CantidadSuperior15++;
                }
                DataGridViewRow r = ConstruirFila();//obtengo la fila en blanco
                SetearFila(r, celsius);
                AgregarFila(r);

                MostrarInfoDatosIngresados();


                InicializarControles();
            }
            else
            {
                BloquearControles();
                MessageBox.Show("Proceso finalizado");
            }
        }
    
            private void MostrarInfoDatosIngresados()
            {
                txtCantTemperaturas.Text = CantidadIngresada.ToString();
                txtSuperiores15.Text = CantidadSuperior15.ToString();
                txtPromedio.Text = PromedioTemperaturas.ToString();
            }

            private void InicializarControles()
            {
                txtCelsius.Clear();
                txtCelsius.Focus();
            }

            private void AgregarFila(DataGridViewRow r)
            {
                dgvDatos.Rows.Add(r);
            }

            private void SetearFila(DataGridViewRow r, double celsius)
            {
                r.Cells[ColCelsius.Index].Value = celsius;
                r.Cells[ColFah.Index].Value = ConvertirCelsiusFah(celsius);
                r.Cells[ColReaumur.Index].Value = ConvertirCelsiusReaumur(celsius);

            }

            private DataGridViewRow ConstruirFila()
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvDatos);
                return r;
            }

            private void BloquearControles()
            {
                txtCelsius.Enabled=false;
                btnOK.Enabled=false;    
                btnCancelar.Enabled=false;
            }

            private bool ValidarDatos()
            {
                bool esValido = true;
                errorProvider1.Clear();
                if (!double.TryParse(txtCelsius.Text, out double temp))
                {
                    ;
                    esValido = false;
                    errorProvider1.SetError(txtCelsius, "Temperatura mal ingresada");
                }
                else if (!(temp >= -80 && temp <= 80))
                {
                    esValido = false;
                    errorProvider1.SetError(txtCelsius, "Temperatura fuera de rango permitido (-80. 80)");
                }
                return esValido;
            }

            private double ConvertirCelsiusReaumur(double celsius)
            {
                return 0.8 * celsius;
            }

            private double ConvertirCelsiusFah(double celsius)
            {
                return 1.8 * celsius + 32;
            }
        }
    } 

