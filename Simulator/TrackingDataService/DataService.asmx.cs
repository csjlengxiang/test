using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace TrackingDataService
{
    /// <summary>
    /// DataService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class DataService : System.Web.Services.WebService
    {
        static SPService spService = new SPService("com6", false);
        static object loc = new object();
        static int cnt = 0;
        [WebMethod]
        public string insert(string sbbh, string state, string tim, string jd, string wd)
        {
            string str = sbbh + " " + state + " " + tim + " " + jd + " " + wd;
            lock (loc)
            {
                //cnt++;
                //str = "cnt:" + cnt.ToString() + " " + str;
                spService.Send(str);
            }
            return "ok";
        }
    }
}
