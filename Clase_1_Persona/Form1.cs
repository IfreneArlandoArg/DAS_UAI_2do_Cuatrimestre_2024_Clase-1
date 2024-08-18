using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase_1_Persona
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Enlazar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        void Mostrar(DataGridView dtgv, Object pO) 
        {
          dtgvPersonas.DataSource = null;
          dtgvPersonas.DataSource = pO;
        }

        void Enlazar() 
        {
            Mostrar(dtgvPersonas, Persona.Listar());
        }

        void LimpiarTextBox() 
        { 
          txtNombre.Text = string.Empty;
          txtApellido.Text = string.Empty;
          txtEdad.Text = string.Empty;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                Persona.DarAlta(txtNombre.Text, txtApellido.Text, int.Parse(txtEdad.Text));
                Enlazar();

                LimpiarTextBox();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                Persona pPersona = dtgvPersonas.SelectedRows[0].DataBoundItem as Persona;

                Persona.DarBaja(pPersona);
                Enlazar();

                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Persona pPersona = dtgvPersonas.SelectedRows[0].DataBoundItem as Persona;

             

                Persona.Modificar(pPersona, txtNombre.Text, txtApellido.Text, int.Parse(txtEdad.Text));
                Enlazar();

                LimpiarTextBox();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dtgvPersonas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if(dtgvPersonas.SelectedRows.Count > 0) 
                {
                    if (rbModificacion.Checked) 
                    {
                        Persona pPersona = dtgvPersonas.SelectedRows[0].DataBoundItem as Persona;
                        txtNombre.Text = pPersona.Nombre;
                        txtApellido.Text = pPersona.Apellido;
                        txtEdad.Text = pPersona.Edad.ToString();
                    }
                    else 
                    {
                        LimpiarTextBox();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
