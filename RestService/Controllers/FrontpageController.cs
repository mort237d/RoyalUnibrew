using ModelLibrary;
using RestService.DBUtil;
using System.Collections.Generic;
using System.Web.Http;

namespace RestService.Controllers
{
    public class FrontpageController : ApiController
    {
        private Manage_Frontpage _mngFrontpage = new Manage_Frontpage();

        public IEnumerable<Frontpage> Get()
        {
            return _mngFrontpage.GetAllFrontpages();
        }

        public Frontpage Get(int id)
        {
            return _mngFrontpage.GetFrontpageFromID(id);
        }

        public bool Post([FromBody]Frontpage value)
        {
            return _mngFrontpage.CreateFrontpage(value);
        }

        public bool Put([FromBody]Frontpage value, int id)
        {
            return _mngFrontpage.UpdateFrontpage(value, id);
        }

        public bool Delete(int id)
        {
            return _mngFrontpage.DeleteFrontpage(id);
        }
    }
}
