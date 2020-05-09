using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Model
{

    /// <summary>
    /// Class representing City in database.
    /// </summary>
    public class City
    {
        // Name of city.
        private String name;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name"> Name of city. </param>
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
