using System;
using System.Data.SqlClient;

protected void btnSalva_Click(object sender, EventArgs e)
{
    using (SqlConnection cn = new SqlConnection(
        System.Configuration.ConfigurationManager
        .ConnectionStrings["POLO_FORMATIVO_REGIONE_PIEMONTE"]
        .ConnectionString))
    {
        SqlCommand cmd = new SqlCommand(@"
        INSERT INTO dbo.CORSI
        (
            titolo,
            descrizione,
            durata_ore,
            polo_id,
            Regioni_destinatarie_formazione,
            Tipologia_scuola,
            Macro_argomento,
            Destinatari,
            Area_DigCompEdu,
            Livello_ingresso,
            Programma,
            Formatori,
            Data_inizio_iscrizioni,
            Data_fine_iscrizioni
        )
        VALUES
        (
            @titolo,
            @descrizione,
            @durata_ore,
            @polo_id,
            @regioni,
            @tipologia_scuola,
            @macro_argomento,
            @destinatari,
            @area_digcompedu,
            @livello_ingresso,
            @programma,
            @formatori,
            @data_inizio_iscrizioni,
            @data_fine_iscrizioni
        )", cn);

        cmd.Parameters.AddWithValue("@titolo", txtTitolo.Text);
        cmd.Parameters.AddWithValue("@descrizione", txtDescrizione.Text);
        cmd.Parameters.AddWithValue("@durata_ore", int.Parse(txtDurataOre.Text));
        cmd.Parameters.AddWithValue("@polo_id", int.Parse(txtPoloId.Text));

        cmd.Parameters.AddWithValue("@regioni", txtRegioni.Text);
        cmd.Parameters.AddWithValue("@tipologia_scuola", txtTipologiaScuola.Text);
        cmd.Parameters.AddWithValue("@macro_argomento", txtMacroArgomento.Text);
        cmd.Parameters.AddWithValue("@destinatari", txtDestinatari.Text);

        cmd.Parameters.AddWithValue("@area_digcompedu", txtAreaDigCompEdu.Text);
        cmd.Parameters.AddWithValue("@livello_ingresso", txtLivelloIngresso.Text);

        cmd.Parameters.AddWithValue("@programma", txtProgramma.Text);
        cmd.Parameters.AddWithValue("@formatori", txtFormatori.Text);

        cmd.Parameters.AddWithValue("@data_inizio_iscrizioni",
            DateTime.Parse(txtDataInizioIscr.Text));

        cmd.Parameters.AddWithValue("@data_fine_iscrizioni",
            DateTime.Parse(txtDataFineIscr.Text));

        cn.Open();
        cmd.ExecuteNonQuery();
    }
}
