using Microsoft.AspNetCore.Mvc;

namespace OSS.Core.WebSite.Controllers
{
    public class UnController : Controller
    {
        public IActionResult notfound()
        {
            
            return View();
        }

        public IActionResult error(int? err_ret)
        {
            //  todo ǰ̨�޸�Ϊͨ��Context��ȡ
            ViewBag.ErrRet = err_ret;
            return View();
        }
    }
}