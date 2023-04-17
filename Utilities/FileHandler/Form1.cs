namespace FileHandler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateSystemDrives();
        }

        private void PopulateSystemDrives()
        {
            try
            {
                var drives = Directory.GetLogicalDrives();
                foreach (var drive in drives)
                {
                    cboSystemDriver.Items.Add(drive);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboSystemDriver_SelectedIndexChanged(object sender, EventArgs e) //Esto sucederá, en este caso, cada vez que se cambia el índice del combo box(o en otras palabras, cuando se selecciona el mismo u otro disco en el desplegable)
        {
            try
            {
                var disk = cboSystemDriver.SelectedItem.ToString(); //Lo que sea que se seleccione del desplegable del combo box, se guardará en la variable disk. 
                DriveInfo diskInfo = new DriveInfo(disk); //En esta clase estará toda la información que necesito del archivo, que es la info a continuación.
                var driveDetails = $@"
                    Drive: {disk} drive:
                    Total Size {diskInfo.TotalSize}
                    Free space available: {diskInfo.AvailableFreeSpace}
                    Format: {diskInfo.DriveFormat}
                    Type: {diskInfo.DriveType}
                    ";

                txtSystemDetails.Text = driveDetails; //Se agregará el texto anterior al text box que puse en el programa y así dicho textbox mostrará toda la información del disco.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateDirectory_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNewDirectory.Text))
                    throw new Exception("Please, enter a path for the directory.");

                if (!Directory.Exists(txtNewDirectory.Text))
                {
                    Directory.CreateDirectory(txtNewDirectory.Text);
                    MessageBox.Show("Directory Created");
                }
                else
                {
                    MessageBox.Show("Please, enter the full path of the new directory.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateSubdirectory_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNewDirectory.Text))
                    throw new Exception("Make sure you have included a directory path on New Directory above.");
                if (string.IsNullOrEmpty(txtNewSubdirectory.Text))
                    throw new Exception("Make sure you have included a path for the new Subdirectory.");

                var directoryPath = txtNewDirectory.Text;
                var subdirInfo = new DirectoryInfo(directoryPath); //Con estas 2 líneas anteriores obtenemos toda la info de txtNewdirectory que usaremos a continuación para crear un subdirectorio en él
                subdirInfo.CreateSubdirectory(txtNewSubdirectory.Text);
                MessageBox.Show("Subdirectory has been created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            /*Aquí están los pasos que realiza el bloque código anterior:

                Verifica si el cuadro de texto "Nuevo Directorio" está vacío o no. Si está vacío, lanza una excepción con un mensaje de error.

                Verifica si el cuadro de texto "Nuevo Subdirectorio" está vacío o no. Si está vacío, lanza una excepción con un mensaje de error.

                Obtiene el texto del cuadro de texto "Nuevo Directorio" y lo asigna a la variable "directoryPath".

                Crea una instancia de la clase DirectoryInfo con el valor de "directoryPath" y la asigna a la variable "subdirInfo".

                Usa el método "CreateSubdirectory" de "subdirInfo" para crear un nuevo subdirectorio con el nombre especificado en el cuadro de texto "Nuevo Subdirectorio".

                Muestra un mensaje de confirmación en un cuadro de diálogo de mensaje si el subdirectorio se ha creado correctamente.

                Si se produce una excepción durante el proceso, se captura en el bloque catch y se muestra un mensaje de error en un cuadro de diálogo de mensaje.*/
        }

        private void btnShowDirectoryFiles_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNewDirectory.Text))
                    throw new Exception("Make sure you have included a directory path on New Directory above.");



                var directory = txtNewDirectory.Text;
                var directoryInfo = new DirectoryInfo(directory);

                if (!directoryInfo.Exists)
                    throw new Exception("Directory doesn't exist.");



                var subDirectories = directoryInfo.GetDirectories();
                foreach (var subdir in subDirectories)
                {
                    if (!cboDirectoryFiles.Items.Contains(subdir.Name))
                        cboDirectoryFiles.Items.Add(subdir.Name);
                }

                var files = directoryInfo.GetFiles("*");
                foreach (var file in files)
                {
                    if (!cboDirectoryFiles.Items.Contains(file.Name))
                        cboDirectoryFiles.Items.Add(file.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCopyDirectory_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCopyDirectorySource.Text) || string.IsNullOrEmpty(txtCopyDirectoryDestination.Text))
                    throw new Exception("Source and destination fields should have values");

                var sourceDirectory = new DirectoryInfo(txtCopyDirectorySource.Text);
                var destinationDirectory = new DirectoryInfo(txtCopyDirectoryDestination.Text);

                CopyDirectory(sourceDirectory, destinationDirectory);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void CopyDirectory(DirectoryInfo sourceDirectory, DirectoryInfo destinationDirectory)
        {
            try
            {
                if (!sourceDirectory.Exists)
                    throw new Exception("Source directory doesn't exist");

                if (!destinationDirectory.Exists) //Si no existe, lo crea
                    destinationDirectory.Create();

                var files = sourceDirectory.GetFiles();
                foreach (var file in files)
                {
                    file.CopyTo(Path.Combine(destinationDirectory.FullName, file.Name)); //Copyto usa un string así que para convertir destinationDirectory.FullName y file.Name ambos a un solo string, se juntan con path combine. Entonces si el directorio era "D:\15 Proyecto C Sharp\Proyecto4 Propio\Directorio Practica\NewDirectory" ahora será "D:\15 Proyecto C Sharp\Proyecto4 Propio\Directorio Practica\NewDirectory\Test1.txt". Así que a esta nueva dirección combinada, se le aplica el copyto.


                    //Copiar subdirectorios
                    var directories = sourceDirectory.GetDirectories();
                    foreach (var directory in directories)
                    {
                        string destination = (Path.Combine(destinationDirectory.FullName, directory.Name)); //Obtenemos la dirección/directorio de destino y lo asignamos a una variable destination
                        CopyDirectory(directory, new DirectoryInfo(destination)); //Recursividad. Se llama de manera recursiva a la función CopyDirectory, pasando el subdirectorio fuente como el nuevo directorio fuente y la nueva instancia de DirectoryInfo como el nuevo directorio de destino. Esto se repite hasta que se hayan copiado todos los archivos y subdirectorios en el árbol de directorios. Entonces, en esta recursividad, en lugar de utilizar el sourceDirectory, el cual era el directorio original, se utiliza a cambio este directory nuevo, el cual es el directorio nuevo encontrado después de hacer este nuevo recorrido foreach a cada elemento del directorio original. De esta manera se va "profundizando" hasta recorrer todas las carpetas y se copie todo.
                                                                                  //En resumen, la recursividad permite que la función CopyDirectory llame a sí misma de forma repetida y procese subdirectorios dentro de subdirectorios hasta que todos los archivos y subdirectorios hayan sido copiados en el directorio de destino.
                    }

                    MessageBox.Show("Directory copied successfully");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            /*Este anterior código define un método llamado CopyDirectory que copia un directorio completo (y sus subdirectorios) de una ubicación de origen a una ubicación de destino. A continuación se detalla lo que hace paso a paso:

                    -Comprueba si la carpeta de origen existe utilizando sourceDirectory.Exists.
                    -Si la carpeta de destino no existe, la crea usando destinationDirectory.Create().
                    -Obtener todos los archivos de la carpeta de origen usando sourceDirectory.GetFiles().
                    -Copia cada archivo de la carpeta de origen a la carpeta de destino utilizando el método CopyTo del objeto FileInfo y Path.Combine para unir el directorio de destino con el nombre del archivo.
                    -Obtener todos los subdirectorios de la carpeta de origen utilizando sourceDirectory.GetDirectories().
                    -Para cada subdirectorio, crea una nueva carpeta en la carpeta de destino utilizando new DirectoryInfo(destination) y luego llama recursivamente a CopyDirectory para copiar todo el contenido de ese subdirectorio en la carpeta de destino correspondiente.
                    -Se muestra un mensaje indicando que la copia de directorio se ha completado con éxito.
                    -Si se produce una excepción durante el proceso de copia, se arroja una excepción para ser manejada en otro lugar.*/
        }

        private void btnNewFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNewFile.Text))
                    throw new Exception("Make sure you have included a path for the New File");
                if (!File.Exists(txtNewFile.Text))
                {
                    File.Create(txtNewFile.Text);
                    MessageBox.Show("File Created");
                }
                else
                {
                    MessageBox.Show("Please enter the full path for the new file");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtSelectedFile.Text = openFileDialog1.FileName;

                    txtRenameFile.Text = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRenameFile_Click(object sender, EventArgs e)
        {
            try
            {
                var source = txtSelectedFile.Text;
                var destination = txtRenameFile.Text;

                var sourceFileInfo = new FileInfo(source);
                if (sourceFileInfo.Exists)
                {
                    sourceFileInfo.MoveTo(destination);
                    MessageBox.Show("The file has been renamed.");
                }
                else
                {
                    MessageBox.Show("Error when trying to rename the file. Is the path correct?");
                    //Rename en un nivel fundamental (código de bajo nivel) es básicamente copiar un archivo existente, pegarlo con el nuevo nombre, y eliminar el anterior. Por eso usamos MoveTo para renombrar.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label10_Click(object sender, EventArgs e) //No usar este evento. Hay que eliminarlo pero demora su tiempo buscando todas las referencias así que lo dejé aquí por ahora.
        {

        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSelectedFile.Text))
                    throw new Exception("Make sure you have selected a file...");
                if (!File.Exists(txtSelectedFile.Text))
                    throw new Exception("Selected file doesn't exist...");

                FileStream fs = new FileStream(txtSelectedFile.Text, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(txtWrite.Text);
                sw.Flush();
                fs.Close();
                MessageBox.Show("New content has been successfully written.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSelectedFile.Text))
                    throw new Exception("Make sure you have selected a file...");
                if (!File.Exists(txtSelectedFile.Text))
                    throw new Exception("Selected file doesn't exist...");

                FileStream fs = new FileStream(txtSelectedFile.Text, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                txtRead.Text = sr.ReadToEnd();
                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSelectedFile.Text))
                    throw new Exception("Make sure you have selected a file...");
                if (!File.Exists(txtSelectedFile.Text))
                    throw new Exception("Selected file doesn't exist...");

                FileStream fs = new FileStream(txtSelectedFile.Text, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                var content = sr.ReadToEnd();

                int i = content.IndexOf(txtFind.Text.Trim(), 0);

                if (i > -1)
                    MessageBox.Show("The string is present in the file.");
                else
                    MessageBox.Show("The string is not present in the file.");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            /*Aquí está el detalle de lo que hace cada línea del bloque código anterior:

                El evento se activa cuando el usuario hace clic en el botón "Find".
                El código entra en el bloque "try-catch" para manejar cualquier excepción que pueda ocurrir.
                Se crea una instancia de la clase "FileStream" con el nombre "fs" que abre el archivo seleccionado por el usuario en modo de lectura.
                Se crea una instancia de la clase "StreamReader" con el nombre "sr" que lee el contenido del archivo "fs".
                Se llama al método "ReadToEnd()" en el objeto "sr" para leer todo el contenido del archivo y almacenarlo en una variable "content".
                Se llama al método "IndexOf()" en la variable "content" para buscar la cadena de texto especificada por el usuario en el archivo. El segundo parámetro de "IndexOf()" especifica desde dónde comenzar la búsqueda en el archivo.
                Si la cadena de texto se encuentra en el archivo, el valor devuelto por "IndexOf()" será mayor que -1. En este caso, se muestra un mensaje de diálogo que indica que la cadena de texto está presente en el archivo.
                Si la cadena de texto no se encuentra en el archivo, el valor devuelto por "IndexOf()" será -1. En este caso, se muestra un mensaje de diálogo que indica que la cadena de texto no está presente en el archivo.
                Si ocurre alguna excepción en el bloque "try-catch", se muestra un mensaje de diálogo que indica el tipo de excepción que ocurrió.*/
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSelectedFile.Text))
                    throw new Exception("Make sure you have selected a file...");
                if (!File.Exists(txtSelectedFile.Text))
                    throw new Exception("Selected file doesn't exist...");

                var path = txtSelectedFile.Text;
                var sw = File.AppendText(path); //Agregará texto el texto que yo escriba en el cuadro de texto de update, al texto que ya había en el archivo de texto original (que abrí con open). 
                sw.WriteLine(txtUpdate.Text);
                sw.Close();
                MessageBox.Show("File contents appended successfully");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
