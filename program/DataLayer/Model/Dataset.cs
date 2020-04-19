using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Model
{
    public class Dataset
    {
        private int id;
        private String name;
        private Measure measure;

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
