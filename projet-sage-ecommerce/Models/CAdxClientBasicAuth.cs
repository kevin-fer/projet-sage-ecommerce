using projet_sage_ecommerce.WebReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SAGE_Client_WS
{
    public class CAdxClientBasicAuth : CAdxWebServiceXmlCCService
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            HttpWebRequest webRequest = (HttpWebRequest)base.GetWebRequest(uri);
            NetworkCredential credentials = Credentials as NetworkCredential;
            if (credentials != null)
            {
                string authInfo = "";
                
                if(credentials.Domain != null && credentials.Domain.Length > 0)
                {
                    authInfo = string.Format(@"{0}\{1}:{2}", credentials.Domain, credentials.UserName, credentials.Password);
                }
                else
                {
                    authInfo  = string.Format(@"{0}:{1}", credentials.UserName, credentials.Password);
                }

                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                webRequest.Headers["Authorization"] = "Basic " + authInfo;
            }
            //return base.GetWebRequest(uri);
            return webRequest;
        }
    }
}
