Imports System.Collections.Generic
Imports  System.ComponentModel
Imports  System.Data
Imports  System.Data.SqlClient
Imports  System.Data.OleDb
Imports System.Drawing
Imports System.Linq
Imports  System.Text
Imports  System.Windows.Forms

Namespace EsISCS

    public partial class frmGestioneSquadre : Form



        Public frmGestioneSquadre()

            InitializeComponent()


        private void btnPrimo_Click(object sender, EventArgs e)

            squadreBindingSource.MoveFirst()



        private void Form1_Load(object sender, EventArgs e)

            // TODO: This line of code loads data into the 'campionatoDataSet.Squadre' table. You can move, or remove it, as needed.
            Me.squadreTableAdapter.Fill(this.campionatoDataSet1.Squadre)



        private void btnUltimo_Click(object sender, EventArgs e)

            squadreBindingSource.MoveLast()



        private void btnPrecedente_Click(object sender, EventArgs e)

            squadreBindingSource.MovePrevious()
            if (squadreBindingSource.Count < 0)

                squadreBindingSource.Position = 0



        private void btnSuccessivo_Click(object sender, EventArgs e)

            squadreBindingSource.MoveNext()
            if (squadreBindingSource.Position > (squadreBindingSource.Count - 1))
                squadreBindingSource.Position = squadreBindingSource.Count - 1



        private void Form1_Load_1(object sender, EventArgs e)

            // TODO: This line of code loads data into the 'campionatoDataSet.Squadre' table. You can move, or remove it, as needed.
            this.squadreTableAdapter1.Fill(this.campionatoDataSet.Squadre)

            this.squadreTableAdapter.Fill(this.campionatoDataSet1.Squadre)
        Dim stringaConnessione As String

            stringaConnessione = "Provider.Microsoft.Jet.Oledb.4.0; password = 'admin'; data source = '@C:\EsISCS\Campionato.mdb'"
        Dim con As OleDbConnection
        Dim letturaDati As OleDbCommand
        Dim scorriDati As New OledbDataReader
        Dim diffReti As Integer
        Dim differenzaReti As datagridviewTextBoxColumn
            con = new OleDbConnection(stringaConnessione)
            con.Open()
            letturaDati = new OleDbCommand("Select * from Squadre", con)
            scorriDati = letturaDati.ExecuteReader(CommandBehavior.SingleResult)







            Do While scorriDati.Read
                diffReti = scorriDati.Item("GolFatti") - scorriDati.Item("GolSubiti")
                scorriDati.Item("DifferenzaReti") = diffReti
                differenzaReti = diffReti



            Loop

 this.campionatoDataSet1.Squadre = scorriDati
 this.squadreTableAdapter.Update(this.campionatoDataSet1.Squadre)


            con.Close()



    End Class
End Namespace