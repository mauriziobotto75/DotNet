# FashionUP WebForms

Applicazione WebForms C# su .NET Framework 4.8, collocata in `FashionUP/` per lasciare invariati i progetti già presenti nel repository `DotNet`. Le funzionalità incluse sono articoli padre e varianti taglia/colore, clienti e fornitori, documenti di acquisto/vendita, giacenze, rettifiche inventariali, listini, barcode e statistiche di vendita.

## Installazione e avvio

1. In SQL Server Management Studio eseguire `Database/FashionUp.sql`. Lo script crea il database `FashionUp`, il deposito iniziale `MAIN` (ID `1`), tabelle, viste e stored procedure.
2. Aprire la cartella `FashionUP` in Visual Studio usando **File > Apri > Sito Web** e scegliere il runtime .NET Framework 4.8, quindi avviare con IIS Express.
3. Configurare la connection string `FashionUp` in `Web.config`. Il valore incluso usa `(localdb)\MSSQLLocalDB` per lo sviluppo locale. Per un server condiviso usare un account SQL dedicato con privilegi minimi; non inserire password personali nel repository.
4. Aprire l'applicazione e creare un articolo e le relative varianti. Nelle maschere per documenti, prezzi, rettifiche e barcode gli identificativi richiesti sono esposti nelle griglie.

Una vendita registrata scarica le scorte solo all'interno di una transazione SQL; giacenza insufficiente, registrazione duplicata e documento senza righe vengono rifiutati. Gli acquisti registrati incrementano la giacenza. Le bozze non movimentano il magazzino.

## Ambito

Questa è una base gestionale WebForms, non un ERP o un sistema fiscale completo. Non include IVA e contabilità, fatturazione elettronica/SDI, conversione automatica fra documenti, ruoli applicativi, stampa e pianificazione fabbisogni. Le varianti previste sono taglia e colore. Prima della pubblicazione su un server aziendale aggiungere autenticazione e autorizzazione applicativa e configurare HTTPS.
