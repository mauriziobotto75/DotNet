using System;

public class Allotment
{
    public int Id { get; set; }
    public int AgenziaId { get; set; }
    public int CameraId { get; set; }

    public DateTime DataInizio { get; set; }
    public DateTime DataFine { get; set; }
    public int Disponibilita { get; set; }
}
