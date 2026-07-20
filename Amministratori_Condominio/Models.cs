csharp Amministratori_Condominio/Data/Models.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amministratori_Condominio.Data
{
    public class Immobile
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Indirizzo { get; set; }
        public string Note { get; set; }
    }

    public class Spesa
    {
        [Key]
        public int Id { get; set; }
        public int ImmobileId { get; set; }
        [ForeignKey(nameof(ImmobileId))]
        public Immobile Immobile { get; set; }
        public DateTime Data { get; set; }
        public decimal Importo { get; set; }
        public string Descrizione { get; set; }
    }

    public class Contatto
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string Nome { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Telefono { get; set; }
    }

    public class Bolletta
    {
        [Key]
        public int Id { get; set; }
        public int ContattoId { get; set; }
        [ForeignKey(nameof(ContattoId))]
        public Contatto Contatto { get; set; }
        public DateTime DataEmissione { get; set; }
        public decimal Totale { get; set; }
        public bool Pagata { get; set; }
    }

    public class AgendaItem
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Titolo { get; set; }
        public string Descrizione { get; set; }
    }

    public class Parcella
    {
        [Key]
        public int Id { get; set; }
        public int ContattoId { get; set; }
        [ForeignKey(nameof(ContattoId))]
        public Contatto Contatto { get; set; }
        public DateTime Data { get; set; }
        public decimal Importo { get; set; }
    }

    public class Sollecito
    {
        [Key]
        public int Id { get; set; }
        public int BollettaId { get; set; }
        [ForeignKey(nameof(BollettaId))]
        public Bolletta Bolletta { get; set; }
        public DateTime DataSollecito { get; set; }
        public string Testo { get; set; }
    }
}
