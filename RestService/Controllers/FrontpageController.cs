using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ModelLibrary;
using RestService.DBUtil;

namespace RestService.Controllers
{
    public class FrontpageController : ApiController
    {
        Manage_Frontpage mngFrontpage = new Manage_Frontpage();

        public IEnumerable<Frontpage> Get()
        {
            return mngFrontpage.GetAllFrontpages();
        }

        public Frontpage Get(int id)
        {
            return mngFrontpage.GetFrontpageFromID(id);
        }

        public void Post([FromBody]Frontpage value)
        {
            mngFrontpage.CreateFrontpage(value);
        }

        public void Put([FromBody]Frontpage value, int id)
        {
            mngFrontpage.UpdateFrontpage(value, id);
        }

        public void Delete(int id)
        {
            mngFrontpage.DeleteFrontpage(id);
        }
    }
}
