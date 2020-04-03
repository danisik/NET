using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Data
{
    public class Dataset
    {
        private String name;
        private Measure measure;

        public Dataset(String name, Measure measure)
        {
            this.name = name;
            this.measure = measure;
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
