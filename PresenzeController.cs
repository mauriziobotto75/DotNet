using System;
using System.Linq;
using System.Web.Mvc;

public class PresenzeController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    public ActionResult Calendario(int idAnagrafica, int mese, int anno)
    {
        var presenze = db.Presenze
            .Where(p => p.ID_Anagrafica == idAnagrafica && p.Data.Month == mese && p.Data.Year == anno)
            .ToList();

        return View(presenze);
    }
}
