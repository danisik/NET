using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Data
{
    public class GraphCustomType
    {
        private String name;
        public EDataType dataType;

        public GraphCustomType(String name, EDataType dataType)
        {
            this.name = name;
            this.dataType = dataType;
        }

        public String Name
        {
            get
            {
                return name;
            }
        }

        public EDataType DataType
        {
            get
            {
                return dataType;
            }
        }
    }
}
