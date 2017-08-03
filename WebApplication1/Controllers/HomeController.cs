using Business;
using System.Web.Mvc;

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

            return View();
        }
    }
}