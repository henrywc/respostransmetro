using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackSys.Models
{
    public class SEC_MENU_MODEL
    {
        public int MenuID { get; set; }
        public string DisplayName { get; set; }
        public int ParentMenuID { get; set; }
        public int OrderNumber { get; set; }
        public string MenuURL { get; set; }
        public string MenuIcon { get; set; }
    }
}