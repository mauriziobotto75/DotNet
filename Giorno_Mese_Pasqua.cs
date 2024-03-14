namespace Giorno_Mese_Pasqua
{
    public partial class frmAnnoPasqua : Form
    {
        public frmAnnoPasqua()
        {
            InitializeComponent();
        }

        private void btnGiornoMesePasqua_Click(object sender, EventArgs z)
        {
            // In TextBox txtYear, insert the Year.
            int year = Convert.ToInt32(txtYear.Text);
            int a = year % 19;
            int b = year / 100;
            int c = year % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int j = c % 4;
            int k = (32 + 2 * e + 2 * i - h - j) % 7;
            int l = (a + 11 * h + 22 * k) / 451;
            int month = (h + k - 7 * l + 114) / 31;
            int day = ((h + k - 7 * l + 114) % 31) + 1;
            DateTime easter = new DateTime(year, month, day);   // This is the easter.
            MessageBox.Show("Giorno e mese della pasqua dell'anno " + txtYear.Text +  " " + easter);
        }
    }
}
