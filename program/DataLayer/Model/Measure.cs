using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Model
{
    /// <summary>
    /// Class representing Measure in database.
    /// </summary>
    public class Measure
    {
        // Name of measure.
        private String name;

        // Measure tag.
        private String tag;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name"> Name of measure. </param>
        /// <param name="tag"> Measure tag. </param>
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
