using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI
{
    public class Autenticacao
    {
        public static string token = "1w2i3l4l5i6a7n8";
        public static string messagemErro = "Falha na Autenticação.... O Token informado é invalido!";
        IHttpContextAccessor contextAccessor;

        public Autenticacao(IHttpContextAccessor context)
        {
            this.contextAccessor = context;
        }

        public void Autenticar()
        {
            try
            {
                string tokenRecebido = contextAccessor.HttpContext.Request.Headers["token"].ToString();

                if (String.Equals(token, tokenRecebido) ==false)
                {
                    throw new Exception(messagemErro);
                }
            }
            catch
            {
                throw new Exception(messagemErro);
            }
        }
    }
}
