using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrosWindowsForms
{
    public partial class Form1 : Form
    {
        List<libro> libros;
        FormEditar formEditar;

        public Form1()
        {
            InitializeComponent();
            formEditar = new FormEditar();
            libros = Cargar();
            RefrescarGrid(libros);
            this.MouseWheel += scrollZoom;
        }

        private List<libro> Cargar()
        {
            List<libro> libros = new List<libro>();

            if (!File.Exists("libros.txt"))
            {
                return libros;
            }

            try
            {
                StreamReader fichero = new StreamReader("libros.txt");
                int cantidad = Convert.ToInt32(fichero.ReadLine());
                for (int i = 0; i < cantidad; i++)
                {
                    libro l = new libro();
                    l.autor = fichero.ReadLine();
                    l.titulo = fichero.ReadLine();
                    l.paginas = Convert.ToInt32(fichero.ReadLine());
                    l.ubicacion = fichero.ReadLine();
                    string separador = fichero.ReadLine();
                    libros.Add(l);
                }
                fichero.Close();
            }
            catch (IOException)
            {
                Console.WriteLine("Error de lectura");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return libros;
        }

        private static void Guardar(List<libro> libros)
        {
            try
            {
                StreamWriter fichero = new StreamWriter("libros.txt");
                fichero.WriteLine(libros.Count);
                foreach (libro l in libros)
                {
                    fichero.WriteLine(l.autor);
                    fichero.WriteLine(l.titulo);
                    fichero.WriteLine(l.paginas);
                    fichero.WriteLine(l.ubicacion);
                    fichero.WriteLine();
                }
                fichero.Close();
            }
            catch (IOException)
            {
                Console.WriteLine("Error de escritura");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        private void btAnadir_Click(object sender, EventArgs e)
        {
            formEditar.Limpiar();
            DialogResult resultadoEdicion = formEditar.ShowDialog();
            if (resultadoEdicion != DialogResult.Cancel)
            {
                libro l = new libro();
                l.autor = formEditar.autor;
                l.titulo = formEditar.titulo;
                try
                {
                    l.paginas = Convert.ToInt32(formEditar.paginas);
                }
                catch (Exception)
                {
                    l.paginas = 0;
                }
                l.ubicacion = formEditar.ubicacion;

                libros.Add(l);
                RefrescarGrid(libros);
                Guardar(libros);
            }
        }

        private void RefrescarGrid(List<libro> libros)
        {
            dataGridView1.DataSource = typeof(libro); //Vacía primero el contenido de la lista libros
            dataGridView1.DataSource = libros; //La fuente de datos de datagrid va a ser lo que esté dentro de la lista libros
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("No ha seleccionada una fila", "Aviso");
            }
            else
            {
                int pos = dataGridView1.SelectedRows[0].Index;

                formEditar.autor = libros[pos].autor;
                formEditar.titulo = libros[pos].titulo;
                formEditar.paginas = "" + libros[pos].paginas;
                formEditar.ubicacion = libros[pos].ubicacion;

                DialogResult resultadoEdicion = formEditar.ShowDialog();
                if (resultadoEdicion != DialogResult.Cancel)
                {
                    libros[pos].autor = formEditar.autor;
                    libros[pos].titulo = formEditar.titulo;
                    try
                    {
                        libros[pos].paginas = Convert.ToInt32(formEditar.paginas);
                    }
                    catch (Exception)
                    {
                        libros[pos].paginas = 0;
                    }
                    libros[pos].ubicacion = formEditar.ubicacion;
                    RefrescarGrid(libros);
                    Guardar(libros);
                }

            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int pos = dataGridView1.CurrentRow.Index;

            libros[pos].autor = (string)dataGridView1.Rows[pos].Cells[0].Value;
            libros[pos].titulo = (string)dataGridView1.Rows[pos].Cells[1].Value;
            try
            {
                libros[pos].paginas = Convert.ToInt32(dataGridView1.Rows[pos].Cells[2].Value);
            }
            catch (Exception)
            {
                libros[pos].paginas = 0;
            }
            libros[pos].ubicacion = (string)dataGridView1.Rows[pos].Cells[3].Value;
            Guardar(libros);
        }

        private void btZoomMas_Click(object sender, EventArgs e)
        {
            int delta = 2;
            dataGridView1.Font = new Font(dataGridView1.Font.FontFamily,
                dataGridView1.Font.Size + delta);
        }

        private void btZoomMenos_Click(object sender, EventArgs e)
        {
            int delta = -2;
            dataGridView1.Font = new Font(dataGridView1.Font.FontFamily,
                dataGridView1.Font.Size + delta);
        }

        private void scrollZoom(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys != Keys.Control)
                return;
            float delta = (e.Delta > 0 ? 2f : -2f);
            dataGridView1.Font = new Font(dataGridView1.Font.FontFamily,
                dataGridView1.Font.Size + delta);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }



    // -----------------------------

    class libro : IComparable<libro>
    {
        public string autor { get; set; }
        public string titulo { get; set; }
        public int paginas { get; set; }
        public string ubicacion { get; set; }

        public int CompareTo(libro otro)
        {
            return String.Compare(this.titulo,
                    otro.titulo, true);
        }
    }


}
