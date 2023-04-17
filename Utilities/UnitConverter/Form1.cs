using System.Drawing.Text;

namespace UnitConverter
{
    public partial class Form1 : Form
    {
        private ConverterService converter = new ConverterService();

        public Form1()
        {

            InitializeComponent();

            cmbType.DataSource = Enum.GetValues(typeof(TypeEnum));
            /*Se llama al método Enum.GetValues(typeof(TypeEnum)) para obtener los valores del enum TypeEnum y se asignan a la propiedad DataSource del objeto cmbType.

        La propiedad DataSource es una propiedad de los controles ComboBox que permite establecer una fuente de datos para los elementos que se mostrarán en el control. En este caso, se establece como fuente de datos los valores del enum TypeEnum.

        Al establecer los valores del enum TypeEnum como fuente de datos del control cmbType, se muestran automáticamente los nombres de los elementos del enum como opciones seleccionables dentro del control.

        En resumen, este bloque de código anterior inicializa el formulario y establece el enum TypeEnum como fuente de datos para el control cmbType, permitiendo que el usuario seleccione uno de sus elementos dentro del control.*/

            cmbType.DropDownStyle = ComboBoxStyle.DropDownList; //Con esto hacemos que el combobox no sea editable

            lstFrom.DataSource = Enum.GetValues(typeof(MassEnum));
            lstTo.DataSource = Enum.GetValues(typeof(MassEnum)); //Estos 2 son para mostrar un valor por defecto cuando se abra la app, en este caso el primero entre los enumerados que es Mass.


        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var type = (TypeEnum)cmbType.SelectedItem;
            /*cmbType.SelectedItem: obtiene el elemento actualmente seleccionado en el ComboBox cmbType.
            *(TypeEnum): realiza un casting del objeto seleccionado al tipo enumerado TypeEnum.
            *type: almacena el resultado de la conversión en una variable llamada type.
            En resumen, esta línea de código convierte el elemento seleccionado en un ComboBox en un valor del tipo enumerado TypeEnum y lo almacena en una variable llamada type. Esto es útil cuando se necesita trabajar con valores enumerados en lugar de valores de cadena o enteros.
            No es posible utilizar valores enumerados sin realizar un casting. En C#, los valores enumerados son valores enteros y no tienen ninguna asociación directa con el tipo enumerado. Por lo tanto, es necesario realizar un casting para convertir el valor entero en el valor del tipo enumerado correspondiente. Con el tipo enumerado establecido, podemos acceder a sus elementos como se ve en el switch siguiente:*/

            switch (type)
            {
                case TypeEnum.Mass:
                    lstFrom.DataSource = Enum.GetValues(typeof(MassEnum));
                    lstTo.DataSource = Enum.GetValues(typeof(MassEnum));
                    break;
                case TypeEnum.Temperature:
                    lstFrom.DataSource = Enum.GetValues(typeof(TemperatureEnum));
                    lstTo.DataSource = Enum.GetValues(typeof(TemperatureEnum));
                    break;
                case TypeEnum.Time:
                    lstFrom.DataSource = Enum.GetValues(typeof(TimeEnum));
                    lstTo.DataSource = Enum.GetValues(typeof(TimeEnum));
                    break;
                default:
                    break;
            }


        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (lstFrom.SelectedItem != null && lstTo.SelectedItem != null)
            { //Este if es solo para eliminar el aviso de null. Lo que contiene es lo que importa, que es enviar los valores al método que está dentro de la clase converterservice para gestionar la conversión allá.

                if (cmbType.SelectedItem.ToString() == "Mass")
                {
                    txtConvertedAmount.Text = converter.ConvertMassUnit((MassEnum)lstFrom.SelectedItem, (MassEnum)lstTo.SelectedItem, double.Parse(txtAmount.Text)).ToString("N2");
                    //Una vez se gestione, regresará el result, que en este caso yo se lo asigno al texto del textbox txtConvertedAmount y así mostrar el resultado convertido.
                }

                else if (cmbType.SelectedItem.ToString() == "Temperature")
                {
                    txtConvertedAmount.Text = converter.ConvertTemperatureUnit((TemperatureEnum)lstFrom.SelectedItem, (TemperatureEnum)lstTo.SelectedItem, double.Parse(txtAmount.Text)).ToString("N2");
                }

                else if (cmbType.SelectedItem.ToString() == "Time")
                {
                    txtConvertedAmount.Text = converter.ConvertTimeUnit((TimeEnum)lstFrom.SelectedItem, (TimeEnum)lstTo.SelectedItem, double.Parse(txtAmount.Text)).ToString("N2");
                }
            }
        }
    }
}