using System.Linq;
using System.Web.Mvc;

namespace GeekDaysEdu.Controllers
{
    public class ResourceController : Controller
    {

        //Возращает страницу какого то ресурса (посмотри что лежит в модели)
        public ActionResult Index(string id)
        {
            using (var context = new Context())
            {
                var result = context.ResourceModels.FirstOrDefault(r => r.ResourceId == int.Parse(id));
                return View(result);
            }
        }
    }
}