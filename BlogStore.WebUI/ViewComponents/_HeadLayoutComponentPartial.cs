using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.ViewComponents
{
    public class _HeadLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
