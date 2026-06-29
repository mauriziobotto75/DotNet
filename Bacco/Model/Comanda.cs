using System;
using System.Collections.ObjectModel;

public class Comanda : BaseModel
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public int CameraId { get; set; }

    public DateTime Data { get; set; }
    public string Stato { get; set; }

    public ObservableCollection<ComandaDettaglio> Dettagli { get; set; }
        = new ObservableCollection<ComandaDettaglio>();
}
