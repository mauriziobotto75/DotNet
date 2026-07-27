using System;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;

public class PdfSollecito
{
    public static void GeneraPDF(
        string fileName,
        string destinatario,
        string indirizzo,
        decimal importo,
        string testo)
    {
        Document doc =
            new Document(
                PageSize.A4,
                50,
                50,
                50,
                50);

        PdfWriter.GetInstance(
            doc,
            new FileStream(
                fileName,
                FileMode.Create));

        doc.Open();

        Font titolo =
            FontFactory.GetFont(
                FontFactory.HELVETICA_BOLD,
                12);

        Font normale =
            FontFactory.GetFont(
                FontFactory.HELVETICA,
                10);

        Paragraph p;

        p = new Paragraph(
            "RACCOMANDATA A/R",
            titolo);

        p.Alignment =
            Element.ALIGN_LEFT;

        doc.Add(p);

        doc.Add(
            new Paragraph(" "));

        p = new Paragraph(
            destinatario + "\n" +
            indirizzo,
            normale);

        p.Alignment =
            Element.ALIGN_RIGHT;

        doc.Add(p);

        doc.Add(
            new Paragraph(" "));

        p = new Paragraph(
            "Torino, " +
            DateTime.Today.ToString("dd/MM/yyyy"),
            normale);

        doc.Add(p);

        doc.Add(
            new Paragraph(" "));

        p = new Paragraph(
            "OGGETTO: SOLLECITO DI PAGAMENTO",
            titolo);

        doc.Add(p);

        doc.Add(
            new Paragraph(" "));

        p = new Paragraph(
            testo,
            normale);

        doc.Add(p);

        doc.Add(
            new Paragraph(" "));

        p = new Paragraph(
            "Importo da versare: Euro "
            + importo.ToString("N2"),
            titolo);

        doc.Add(p);

        doc.Add(
            new Paragraph(" "));

        p = new Paragraph(
            "Cordiali saluti.\n\n\n" +
            "L'Amministratore",
            normale);

        doc.Add(p);

        doc.Close();
    }
}
