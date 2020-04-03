using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Data
{
    public class City
    {
        private String name;

        public City (String name)
        {
            this.name = name;
        }

        public String Name
        {
            get
            {
                return name;
            }
        }
    }
}
