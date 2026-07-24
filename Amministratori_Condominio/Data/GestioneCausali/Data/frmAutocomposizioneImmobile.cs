using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Amministratori
{
    public partial class frmAutocomposizioneImmobile : Form
    {
        private int m_IdCondominio;

        public frmAutocomposizioneImmobile(int idCondominio)
        {
            InitializeComponent();

            m_IdCondominio = idCondominio;
        }

        private void frmAutocomposizioneImmobile_Load(
            object sender,
            EventArgs e)
        {
            InizializzaMaschera();

            CaricaDatiCondominio();
        }

        private void InizializzaMaschera()
        {
            txtCodice.Text = GeneraCodiceUnita();

            txtDescrizione.Text = "";
            txtIndirizzo.Text = "";
            txtComune.Text = "";
            txtCAP.Text = "";
            txtCodiceFiscale.Text = "";
        }

        private string ConnectionString
        {
            get
            {
                return
                    @"Data Source=.\SQLEXPRESS;
                    Initial Catalog=Amministratori_Condominio;
                    Integrated Security=True";
            }
        }

        private string GeneraCodiceUnita()
        {
            SqlConnection cn =
                new SqlConnection(ConnectionString);

            string sql =
                "SELECT ISNULL(MAX(IdUnita),0)+1 FROM UnitaImmobiliari";

            SqlCommand cmd =
                new SqlCommand(sql, cn);

            cn.Open();

            int progressivo =
                Convert.ToInt32(
                    cmd.ExecuteScalar());

            cn.Close();

            return "IMM" +
                   progressivo.ToString("00000");
        }

        private void CaricaDatiCondominio()
        {
            SqlConnection cn =
                new SqlConnection(ConnectionString);

            string sql =
            @"SELECT
                Nome,
                Indirizzo,
                Citta,
                CAP,
                CodiceCondominio
            FROM Condomini
            WHERE IdCondominio=@IdCondominio";

            SqlCommand cmd =
                new SqlCommand(sql, cn);

            cmd.Parameters.AddWithValue(
                "@IdCondominio",
                m_IdCondominio);

            cn.Open();

            SqlDataReader dr =
                cmd.ExecuteReader();

            if (dr.Read())
            {
                txtDescrizione.Text =
                    dr["Nome"].ToString();

                txtIndirizzo.Text =
                    dr["Indirizzo"].ToString();

                txtComune.Text =
                    dr["Citta"].ToString();

                txtCAP.Text =
                    dr["CAP"].ToString();
            }

            dr.Close();
            cn.Close();
        }

        private bool ControllaDati()
        {
            if(txtDescrizione.Text.Trim()=="")
            {
                MessageBox.Show(
                    "Inserire la descrizione.",
                    "Controllo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDescrizione.Focus();

                return false;
            }

            if(txtIndirizzo.Text.Trim()=="")
            {
                MessageBox.Show(
                    "Inserire l'indirizzo.",
                    "Controllo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtIndirizzo.Focus();

                return false;
            }

            return true;
        }

        private void SalvaImmobile()
        {
            SqlConnection cn =
                new SqlConnection(ConnectionString);

            string sql =
            @"INSERT INTO UnitaImmobiliari
            (
                IdCondominio,
                Interno,
                Scala,
                Piano,
                Superficie,
                Note
            )
            VALUES
            (
                @IdCondominio,
                @Interno,
                @Scala,
                @Piano,
                @Superficie,
                @Note
            )";

            SqlCommand cmd =
                new SqlCommand(sql, cn);

            cmd.Parameters.AddWithValue(
                "@IdCondominio",
                m_IdCondominio);

            cmd.Parameters.AddWithValue(
                "@Interno",
                txtCodice.Text);

            cmd.Parameters.AddWithValue(
                "@Scala",
                "");

            cmd.Parameters.AddWithValue(
                "@Piano",
                "");

            cmd.Parameters.AddWithValue(
                "@Superficie",
                0);

            cmd.Parameters.AddWithValue(
                "@Note",
                txtDescrizione.Text);

            cn.Open();

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        private void btnFine_Click(
            object sender,
            EventArgs e)
        {
            if (!ControllaDati())
                return;

            try
            {
                SalvaImmobile();

                MessageBox.Show(
                    "Immobile creato correttamente.",
                    "Conferma",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;

                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Errore",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnAbbandona_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }

        private void btnIndietro_Click(
            object sender,
            EventArgs e)
        {
            tabWizard.SelectedIndex =
                tabWizard.SelectedIndex - 1;
        }

        private void btnAvanti_Click(
            object sender,
            EventArgs e)
        {
            tabWizard.SelectedIndex =
                tabWizard.SelectedIndex + 1;
        }
    }
}
