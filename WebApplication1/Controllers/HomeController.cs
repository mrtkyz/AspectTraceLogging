using Business;
using Common.Aspects;
using System.Web.Mvc;

[assembly: Log]
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            Hesaplama calc = new Hesaplama();

            double bolum = calc.Bol(100, 0);

            double toplam = calc.Ekle(1, 1);

            return Content(string.Format("Bolum: {0}, Toplam: {1}", bolum, toplam));
        }
    }
}