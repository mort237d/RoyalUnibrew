using System;
using System.Collections.Generic;
using ModelLibrary;

namespace RestService.DBUtil
{
    interface IManage_Frontpage
    {
        List<Frontpage> GetAllFrontpages();

        Frontpage GetFrontpageFromID(int processOrderNo);

        bool CreateFrontpage(Frontpage frontpage);

        bool UpdateFrontpage(Frontpage frontpage, int processOrderNo);

        bool DeleteFrontpage(int processOrderNo);
    }
}
