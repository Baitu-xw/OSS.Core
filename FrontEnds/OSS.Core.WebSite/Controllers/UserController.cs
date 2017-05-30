using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OSS.Common.ComModels;
using OSS.Core.WebSite.Controllers.Mos.Reqs;

namespace OSS.Core.WebSite.Controllers
{
    /// <summary>
    ///   �û�ģ��
    /// </summary>
    public class UserController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// �����¼
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> mobile_login(UserMobileLoginReq req)
        {
            await Task.Delay(100);
            return Json(new ResultMo());
        }
        



    }


}