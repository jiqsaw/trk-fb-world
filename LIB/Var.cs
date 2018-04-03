using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LIB
{
    public class Var
    {

        public struct Meta
        {
            public string Description;
            public string Keywords;
        }

        public struct MetaOg
        {
            public string Description;
            public string Image;
            public string Title;
            public string Type_;
        }

        public enum OrderType
        {
            ASC,
            DESC
        }
    }
}
