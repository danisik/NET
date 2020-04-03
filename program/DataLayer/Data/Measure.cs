using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Data
{
    public class Measure
    {
        private String name;
        private String tag;

        public Measure(String name, String tag)
        {
            this.name = name;
            this.tag = tag;
        }

        public String Name
        {
            get
            {
                return name;
            }
        }
        public String Tag
        {
            get
            {
                return tag;
            }
        }
    }
}
