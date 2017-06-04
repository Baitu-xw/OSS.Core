﻿#region Copyright (C) 2017 Kevin (OSS开源作坊) 公众号：osscoder

/***************************************************************************
*　　	文件功能描述：OSSCore —— 成员相关接口
*
*　　	创建人： Kevin
*       创建人Email：1985088337@qq.com
*    	创建日期：2017-5-16
*       
*****************************************************************************/

#endregion

using System.Threading.Tasks;
using OSS.Common.Authrization;
using OSS.Common.ComModels;
using OSS.Core.Domains.Members.Mos;
using OSS.Core.Services.Members;


namespace OSS.Core.WebApi.Controllers.Member
{
    public class MemberController : BaseApiController
    {
        private static readonly MemberService service=new MemberService();

        /// <summary>
        ///   获取当前登录用户信息
        /// </summary>
        /// <returns></returns>
        public async Task<ResultMo<UserInfoMo>> GetCurrentUser()
        {
            return await service.GetUserInfo(MemberShiper.Identity.Id);
        }


        
    }
}
