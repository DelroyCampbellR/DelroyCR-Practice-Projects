namespace WhatTimeIsIn
{
    public partial class Form1 : Form
    {
        private int totalSeconds1 = 70;
        private int totalSeconds2 = 130;
        private int totalSeconds3 = 180;
        private int seconds;
        private bool timeIsUp = false;
        private bool timeIsUp2 = false;
        private bool timeIsUp3 = false;

        int minutesCrono = 0;
        int secondsCrono = 0;
        int hoursCrono = 0;

        private TimeZoneService _timeZoneService;
        public Form1()
        {
            InitializeComponent();
            _timeZoneService = new TimeZoneService();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime1.Text = DateTime.Now.ToString("HH:mm");
            lblSecond1.Text = DateTime.Now.ToString("ss");
            lblDate1.Text = DateTime.Now.ToString("MMM dd yyyy");
            lblDay1.Text = DateTime.Now.ToString("dddd");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer4.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //var inTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"); //"DateTime Zones C#" para buscar info de timezones en la documentación de microsoft en google.
            //var easternDate = TimeZoneInfo.ConvertTime(DateTime.Now, inTimeZone); //Convertimos mi hora local a la hora de eastern standard time.

            //Los ids son cambiantes pero hay algunas listas que podrían servir, como en esta web: https://stackoverflow.com/questions/7908343/list-of-timezone-ids-for-use-with-findtimezonebyid-in-c
            //Los anteriores fueron comentados porque ahora usaremos una nueva clase (TimeZoneService) para gestionarlos y así evitar repetir código.

            var localDate = _timeZoneService.GetCurrentDateByTimeZone("Eastern Standard Time");

            lblTime2.Text = localDate.ToString("HH:mm");
            lblSecond2.Text = localDate.ToString("ss");
            lblDate2.Text = localDate.ToString("MMM dd yyyy");
            lblDay2.Text = localDate.ToString("dddd");
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //var inTimeZone = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");
            //var beijingDate = TimeZoneInfo.ConvertTime(DateTime.Now, inTimeZone);

            var localDate = _timeZoneService.GetCurrentDateByTimeZone("China Standard Time");

            lblTime3.Text = localDate.ToString("HH:mm");
            lblSecond3.Text = localDate.ToString("ss");
            lblDate3.Text = localDate.ToString("MMM dd yyyy");
            lblDay3.Text = localDate.ToString("dddd");
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            //var inTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            //var tokyoDate = TimeZoneInfo.ConvertTime(DateTime.Now, inTimeZone);

            var localDate = _timeZoneService.GetCurrentDateByTimeZone("Tokyo Standard Time");

            lblTime4.Text = localDate.ToString("HH:mm");
            lblSecond4.Text = localDate.ToString("ss");
            lblDate4.Text = localDate.ToString("MMM dd yyyy");
            lblDay4.Text = localDate.ToString("dddd");
        }

        private void btnStart1_Click(object sender, EventArgs e)
        {
            lblTemp1.ForeColor = Color.White;
            timer5.Interval = 1000;
            timer5.Start();
            seconds = totalSeconds1;
        }

        private void btnStart2_Click(object sender, EventArgs e)
        {
            lblTemp2.ForeColor = Color.White;
            timer6.Interval = 1000;
            timer6.Start();
            seconds = totalSeconds2;
        }

        private void btnStart3_Click(object sender, EventArgs e)
        {
            lblTemp3.ForeColor = Color.White;
            timer7.Interval = 1000;
            timer7.Start();
            seconds = totalSeconds3;
        }

        private void timer5_Tick(object sender, EventArgs e)
        {

            if (totalSeconds1 <= 0)
            {
                timer5.Stop();
                if (!timeIsUp)
                {
                    //MessageBox.Show(this, "Time's up!", "Timer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.TopMost = true;
                    timeIsUp = true;
                    totalSeconds1 = 70;
                    lblTemp1.Text = "1:10";
                    lblTemp1.ForeColor = Color.Red;
                }
            }
            else
            {
                totalSeconds1--;
                int minutes = totalSeconds1 / 60;
                int seconds = totalSeconds1 % 60;
                lblTemp1.Text = string.Format("{0}:{1:00}", minutes, seconds);
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (totalSeconds2 <= 0)
            {
                timer6.Stop();
                if (!timeIsUp2)
                {
                    //MessageBox.Show(this, "Time's up!", "Timer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.TopMost = true;
                    timeIsUp2 = true;
                    totalSeconds1 = 130;
                    lblTemp2.Text = "2:10";
                    lblTemp2.ForeColor = Color.Red;
                }
            }
            else
            {
                totalSeconds2--;
                int minutes = totalSeconds2 / 60;
                int seconds = totalSeconds2 % 60;
                lblTemp2.Text = string.Format("{0}:{1:00}", minutes, seconds);
            }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            if (totalSeconds3 <= 0)
            {
                timer7.Stop();
                if (!timeIsUp3)
                {
                    //MessageBox.Show(this, "Time's up!", "Timer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.TopMost = true;
                    timeIsUp3 = true;
                    totalSeconds3 = 180;
                    lblTemp3.Text = "3:00";
                    lblTemp3.ForeColor = Color.Red;
                }
            }
            else
            {
                totalSeconds3--;
                int minutes = totalSeconds3 / 60;
                int seconds = totalSeconds3 % 60;
                lblTemp3.Text = string.Format("{0}:{1:00}", minutes, seconds);
            }
        }

        private void btnStart4_Click(object sender, EventArgs e)
        {
            if (timer8.Enabled)
            {
                timer8.Enabled = false;
                btnStart4.Text = "Start!";
            }
            else
            {
                timer8.Enabled = true;
                btnStart4.Text = "Stop!";
            }
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            secondsCrono++;
            if (secondsCrono == 60)
            {
                minutesCrono++;
                secondsCrono = 0;
                //Incrementa los segundos en 1 y comprueba si los segundos han alcanzado los 60. Si es así, reinicia los segundos a cero y aumenta los minutos en 1. Luego, actualiza una etiqueta en el formulario con los minutos y segundos actuales.
            }
            if (minutesCrono == 60)
            {
                hoursCrono++;
                minutesCrono = 0;
            }

            lblCrono1.Text = hoursCrono.ToString("00") + ":" + minutesCrono.ToString("00") + ":" + secondsCrono.ToString("00");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            secondsCrono = 0;
            minutesCrono = 0;
            hoursCrono = 0;

            lblCrono1.Text = "00:00:00";
        }
    }
}