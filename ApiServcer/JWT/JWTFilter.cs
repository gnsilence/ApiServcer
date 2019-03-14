using BeetleX.FastHttpApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiServcer.JWT
{
  public  class JWTFilter: FilterAttribute
    {
        public static JWTHelper JWTHelper = new JWTHelper();
        public override bool Executing(ActionContext context)
        {
            string token = context.HttpContext.Request.Header[HeaderTypeFactory.AUTHORIZATION];
            var user = JWTHelper.GetUserInfo(token);
            if (!string.IsNullOrEmpty(user.Name))
            {
                return true;
            }
            else
            {
                //token验证失败
                context.Result = new TextResult("StatusCode:401 not allowed,token is necessary");
                return false;
            }
        }
    }
}
