using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OSS.Common.ComModels;
using OSS.Common.ComModels.Enums;
using OSS.Core.Infrastructure.Enums;
using OSS.Core.WebSite.AppCodes;
using OSS.Core.WebSite.Controllers.Users.Mos;

namespace OSS.Core.WebSite.Controllers.Users
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
        public async Task<IActionResult> Login(UserRegLoginReq req)
        {
            var stateRes = CheckLoginModelState(req);
            if (!stateRes.IsSuccess())
                return Json(stateRes);
          
            var loginRes =await ApiUtil.PostApi<UserRepLoginResp>("/user/login", req);
            if (loginRes.IsSuccess())
            {
                
            }
            return Json(loginRes);
        }
        /// <summary>
        ///   ������¼ʱ����֤ʵ�����
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        private ResultMo CheckLoginModelState(UserRegLoginReq req)
        {
            if (!ModelState.IsValid)
                return new ResultMo(ResultTypes.ParaError, GetVolidMessage());

            if (!Enum.IsDefined(typeof(RegLoginType), req.type))
                return new ResultMo(ResultTypes.ParaError, "δ֪���˺����ͣ�");


            var validator = new DataTypeAttribute(
                req.type == RegLoginType.Mobile
                    ? DataType.PhoneNumber
                    : DataType.EmailAddress);

            return !validator.IsValid(req.name) ? 
                new ResultMo(ResultTypes.ParaError, "��������ȷ���ֻ������䣡")
                : new ResultMo();
        }
    }


}