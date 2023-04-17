namespace MathFlashCards
{
    public partial class Form1 : Form
    {
        private int _number1, _number2;
        private Random _random;
        private OperationEnum _operation;
        private int _result;

        public Form1()
        {
            InitializeComponent();
            _random = new Random();
            InitScreen();
        }

        private void InitScreen()
        {
            lblWrongRight.Text = string.Empty;
            lblSelect.Visible = true;

            lblPlayAgain.Visible = false;

            lblOption1.Visible = true;
            lblOption2.Visible = true;
            lblOption3.Visible = true;
            lblOption4.Visible = true;
            lblOption5.Visible = true;
            lblOption6.Visible = true;

            SetNumbers();
            SetOperation();
            SetAnswers();
        }

        private void SetNumbers()
        {
            _number1 = _random.Next(1, 20);
            _number2 = _random.Next(1, 20);

            lblNumber1.Text = _number1.ToString();
            lblNumber2.Text = _number2.ToString();

        }
        private void SetOperation()
        {
            var enumValues = Enum.GetValues(typeof(OperationEnum)); 

            _operation = (OperationEnum)enumValues.GetValue(_random.Next(enumValues.Length));
            lblOperation.Text = _operation.GetSymbol();
        }
        private void SetAnswers()
        {
            _result = _operation.GetResult(_number1, _number2);

            var values = new List<int>
            {
                _result + 1, _result + 2, _result, _result - 1, _result - 2, _result - 3
            };

            var options = new List<int> { 1, 2, 3, 4, 5, 6 }; 
            for (int i = 0; i < 6; i++)
            {
                var randomLabel = options[_random.Next(0, options.Count())]; 
                var randomValue = values[_random.Next(0, values.Count())];
                SetOption(randomLabel, randomValue);

                values.Remove(randomValue);
                options.Remove(randomLabel); 
            }
        }
        private void SetOption(int randomLabel, int randomValue)
        {
            switch (randomLabel)
            { 
                case 1:
                    lblOption1.Text = randomValue.ToString();
                    break;
                case 2:
                    lblOption2.Text = randomValue.ToString();
                    break;
                case 3:
                    lblOption3.Text = randomValue.ToString();
                    break;
                case 4:
                    lblOption4.Text = randomValue.ToString();
                    break;
                case 5:
                    lblOption5.Text = randomValue.ToString();
                    break;
                case 6:
                    lblOption6.Text = randomValue.ToString();
                    break;

                default:
                    break;
            }
        }
        private void lblOption_Click(object sender, EventArgs e)
        {
            if (sender is not Label)
                return; 

            var selectedValue = int.Parse(((Label)sender).Text); 

            if (selectedValue == _result)
            {
                lblWrongRight.Text = "Correct";
                lblWrongRight.ForeColor = Color.Green;

                lblPlayAgain.Visible = true;
                lblSelect.Visible = false; 
            }
            else
            {
                lblWrongRight.Text = "Wrong";
                lblWrongRight.ForeColor = Color.Red;

                ((Label)sender).Visible = false; 
            }
            
        }
        private void lblPlayAgain_Click(object sender, EventArgs e)
        {
            InitScreen();
        }
    }
}