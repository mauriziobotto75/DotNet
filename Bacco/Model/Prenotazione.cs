using System;

public class Prenotazione
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public int CameraId { get; set; }
    public DateTime DataArrivo { get; set; }
    public DateTime DataPartenza { get; set; }
}
