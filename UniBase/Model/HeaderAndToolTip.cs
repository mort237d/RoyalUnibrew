using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBase.Model
{
    class HeaderAndToolTip
    {
        public string Header { get; set; }
        public string ToolTip { get; set; }

        public HeaderAndToolTip(string header, string toolTip)
        {
            Header = header;
            ToolTip = toolTip;
        }
    }
}
