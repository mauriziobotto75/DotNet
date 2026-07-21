using System;
using System.Collections.Generic;

namespace Amministratori_Condominio.Models
{
    /// <summary>
    /// Modello che rappresenta un Immobile/Condominio gestito dall'amministratore
    /// </summary>
    public class GestioneImmobile
    {
        public int IdCondominio { get; set; }
        public int IdAmministratore { get; set; }
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public string CAP { get; set; }
        public string CodiceCondominio { get; set; }
        public DateTime? DataInizioGestione { get; set; }
        public DateTime DataCreazione { get; set; }
    }

    /// <summary>
    /// Modello per il Movimento Contabile di una gestione
    /// Rappresenta una singola riga di spesa/ricavo in una gestione
    /// </summary>
    public class MovimentoContabile
    {
        public int IdMovimento { get; set; }
        public int IdGestione { get; set; }
        public int IdConto { get; set; }
        public DateTime DataMovimento { get; set; }
        public string Descrizione { get; set; }
        public decimal Importo { get; set; }
        public string TipoMovimento { get; set; } // Dare/Avere
        public string CodiceConto { get; set; }
        public string DescrizioneConto { get; set; }
    }

    /// <summary>
    /// Modello per la Gestione (ordinaria/straordinaria)
    /// Rappresenta un periodo contabile
    /// </summary>
    public class Gestione
    {
        public int IdGestione { get; set; }
        public int IdCondominio { get; set; }
        public string Descrizione { get; set; }
        public string TipoGestione { get; set; } // Ordinaria / Straordinaria
        public DateTime? DataInizio { get; set; }
        public DateTime? DataFine { get; set; }
        public string Stato { get; set; } // Aperta / Chiusa / Provvisoria
    }

    /// <summary>
    /// Modello per il Piano dei Conti
    /// Definisce i conti contabili disponibili per una gestione
    /// </summary>
    public class PianoConto
    {
        public int IdConto { get; set; }
        public int IdCondominio { get; set; }
        public string CodiceConto { get; set; }
        public string Descrizione { get; set; }
        public string TipoConto { get; set; } // Costo / Ricavo / Patrimoniale
    }

    /// <summary>
    /// Modello per le Causali di Spesa
    /// Utilizzate per classificare i movimenti contabili
    /// </summary>
    public class Causale
    {
        public int IdCausale { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public string Tipo { get; set; } // Entrata/Uscita
        public bool Attiva { get; set; }
    }

    /// <summary>
    /// Modello per la Rate di pagamento
    /// Rappresenta una scadenza di pagamento per un'unità immobiliare
    /// </summary>
    public class Rate
    {
        public int IdRata { get; set; }
        public int IdGestione { get; set; }
        public int IdUnita { get; set; }
        public DateTime Scadenza { get; set; }
        public decimal Importo { get; set; }
        public bool Pagata { get; set; }
    }
}
