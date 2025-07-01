using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.Areas.Admin.ViewComponents.Default
{
    public class SidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
