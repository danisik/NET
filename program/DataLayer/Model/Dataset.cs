using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Model
{
    /// <summary>
    /// Class representing dataset in database.
    /// </summary>
    public class Dataset
    {
        // ID of dataset.
        private int id;

        // Name of dataset.
        private String name;

        // Used measure in dataset.
        private Measure measure;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"> ID of dataset. </param>
        /// <param name="name"> Name of dataset. </param>
        /// <param name="measure"> Used measure. </param>
        public Dataset(int id, String name, Measure measure)
        {
            this.id = id;
            this.name = name;
            this.measure = measure;
        }

        public int ID
        {
            get
            {
                return id;
            }
        }

        public String Name 
        { 
            get
            {
                return name;
            }
        }

        public Measure Measure 
        {
            get
            {
                return measure;
            }
            set
            {
                this.measure = value;
            }
        }
    }
}
