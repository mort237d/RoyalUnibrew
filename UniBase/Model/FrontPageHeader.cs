using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBase.Model
{
    class FrontPageHeader
    {
        public string Header { get; set; }
        public string ToolTip { get; set; }

        public FrontPageHeader(string header, string toolTip)
        {
            Header = header;
            ToolTip = toolTip;
        }
    }
}
