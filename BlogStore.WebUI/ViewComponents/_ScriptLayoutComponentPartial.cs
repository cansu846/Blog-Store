using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.ViewComponents
{
    public class _ScriptLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
