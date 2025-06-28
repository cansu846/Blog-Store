using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.ViewComponents
{
    public class _NavbarLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
