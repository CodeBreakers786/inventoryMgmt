using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inventoryMgmt.Utilities
{
    public class Utility
    {
        public static string getUniqueKey()
        {
            return Guid.NewGuid().ToString();
        }
    }
}