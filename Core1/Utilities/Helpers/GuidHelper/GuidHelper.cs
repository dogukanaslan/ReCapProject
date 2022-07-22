using System;
using System.Collections.Generic;
using System.Text;

namespace Core1.Utilities.Helpers.GuidHelper
{
    public class GuidHelper
    {
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString();
        } 
    }
}
