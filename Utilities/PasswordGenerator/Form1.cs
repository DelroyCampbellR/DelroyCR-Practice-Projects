namespace PasswordGenerator
{
    public partial class Form1 : Form
    {
        Random _random = new Random(); //_ Variable global. Tambi�n se podr�a ponre el guion bajo a los siguientes strings que tambi�n son globales pero lo dejar� as� esta vez.
        static string upperCaseList = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static string lowerCaseList = "abcdefghijklmnopqrstuvwxyz";
        static string numericList = "0123456789";
        static string symbolsList = "!#$%&()*+,-./:;<=>?@[]^_{|}~";

        string allCharsList = string.Empty;

        public Form1()
        {
            InitializeComponent();
            txtPasswordLength.Text = "20";
        }

        private void BuildCharsList()
        {
            allCharsList = string.Empty; //Vaciamos la lista.

            if (chkIncludeLowercase.Checked)
                allCharsList += lowerCaseList;
            if (chkIncludeUppercase.Checked)
                allCharsList += upperCaseList;
            if (chkIncludeNumbers.Checked)
                allCharsList += numericList;
            if (chkIncludeSymbols.Checked)
                allCharsList += symbolsList;

            if (string.IsNullOrEmpty(allCharsList)) //Si en este punto el usuario no ha tildado alguna opci�n de los checkboxes, entonces que la lista cargada incluya todo.
            {
                allCharsList = lowerCaseList + upperCaseList + numericList + symbolsList;
            }
        }

        private string GeneratePassword(int length)
        {
            string newPassword = string.Empty;

            if (length < 6)
                throw new Exception("A strong password needs to have more than 6 characters.");

            for (int i = 0; i < length; i++)
            {
                newPassword += GetRandomChar();
            }

            return newPassword;
        }

        private string GetRandomChar()
        {
            return allCharsList.ToCharArray()[(int)Math.Floor(_random.NextDouble() * allCharsList.Length)].ToString();
            //Lo que hace este bloque de c�digo es:
            //Convertimos allcharslist que es un string, a una colecci�n o arreglo de chars usando toCharArray.
            //Genero un valor aleatorio, ese valor lo multiplico por la cantidad de caracteres en la lista completa (allCharsList), con Math.Floor me aseguro de que devuelva enteros (redondea), como a�n es double le hago un parse a int (int), y eso dar� el caracter aleatorio, que termino convirtiendo en string con Tostring().
        }

        private void btnGeneratePassword_Click(object sender, EventArgs e)
        {
            try
            {
                BuildCharsList();
                txtNewPassword.Text = GeneratePassword(int.Parse(txtPasswordLength.Text)); //Se hace un int.parse ya que esto es un string, pero el par�metro en el m�todo GeneratePassword es un int, as� que lo convertimos a int y se lo mandamos.
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtPasswordLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            /*Este bloque de c�digo se ejecuta cuando se presiona una tecla en el cuadro de texto "txtPasswordLength". A continuaci�n se muestra el desglose del c�digo:

            La funci�n "txtPasswordLength_KeyPress" se llama cada vez que se presiona una tecla en el cuadro de texto "txtPasswordLength".
            El par�metro "sender" se refiere al objeto que activ� el evento, que es el cuadro de texto "txtPasswordLength" en este caso.
            El par�metro "e" es un objeto "KeyPressEventArgs" que contiene informaci�n sobre la tecla que se presion�.
            La funci�n comprueba si la tecla presionada no es un car�cter de control, no es un d�gito y no es un punto.
            Si la tecla presionada no cumple con estas condiciones, se establece "e.Handled = true", lo que indica que el evento ya ha sido manejado y la tecla presionada no se procesar� en el cuadro de texto.*/

            //En resumen: Con este m�todo obligamos al usuario a escribir �nicamente n�meros.
        }
    }
}