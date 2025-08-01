using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            persona.Nombre = txtnombre.Text;
            persona.Edad = Convert.ToInt32(txtedad.Text);
            persona.Telefono = txttelefono.Text;


                if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells["id"].Value != null)
                {
                    int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
                    if (id != null)
                    {
                        persona.id = id;
                        int result = PersonaDAL.Modificar(persona);

                        if (result > 0)
                        {
                            MessageBox.Show("Se Modifico correctamente");
                        }
                        else
                        {
                            MessageBox.Show("Error al Modificar");
                        }

                            Limpiar();
                    }
                
                }
                else
                {
                    int result = PersonaDAL.AgregarPersona(persona);

                    if (result > 0)
                    {
                        MessageBox.Show("Se Registro correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Error al Registrar");
                    }

                }
                    Limpiar();
                    refrescarpantalla(); 
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            refrescarpantalla();
        }

        public void refrescarpantalla() 
        {
            dataGridView1.DataSource = PersonaDAL.Presentar();
        }

        public void Limpiar()
        {
            txtid.Text = "";
            txtnombre.Text = "";
            txtedad.Text = "";
            txttelefono.Text = "";
            dataGridView1.CurrentCell = null;


        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txtid.Text = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            txtnombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
            txtedad.Text = dataGridView1.CurrentRow.Cells["edad"].Value.ToString();
            txttelefono.Text = dataGridView1.CurrentRow.Cells["telefono"].Value.ToString();
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
            int resultado = PersonaDAL.Eliminar(id);

            if (resultado > 0)
            {
                MessageBox.Show("Se elimino correctamente");
            }
            else
            {
                MessageBox.Show("Error al eliminar");
            }
            Limpiar();
            refrescarpantalla();
           
        }
    }
}
