using DeveloperTest.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace DeveloperTest
{
    [WebService, WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class LogService : WebService
    {
        [WebMethod]
        public LogItem Get(int id)
        {
            return LogItemHelper.Get(id);
        }

        [WebMethod]
        public bool Delete(int id)
        {
            return LogItemHelper.Delete(id);
        }

        [WebMethod]
        public List<LogItem> Search(string text)
        {
            return LogItemHelper.Search(text).ToList();
        }
    }
}
