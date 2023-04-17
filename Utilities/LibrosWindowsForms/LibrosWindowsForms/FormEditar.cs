using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrosWindowsForms
{
    public partial class FormEditar : Form
    {
        public string titulo
        {
            get { return tbTitulo.Text; }
            set { tbTitulo.Text = value; }
        }

        public string autor
        {
            get { return tbAutor.Text; }
            set { tbAutor.Text = value; }
        }

        public string paginas
        {
            get { return tbPaginas.Text; }
            set { tbPaginas.Text = value; }
        }

        public string ubicacion
        {
            get { return tbUbicacion.Text; }
            set { tbUbicacion.Text = value; }
        }

        public void Limpiar()
        {
            titulo = autor = paginas = ubicacion = "";
        }

        public FormEditar()
        {
            InitializeComponent();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
