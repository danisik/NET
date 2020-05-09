using System;
using System.Collections.Generic;
using System.Text;


namespace DataLayer.Data
{
    /// <summary>
    /// Enumeration for graph type.
    /// </summary>
    public class EGraphCustomType
    {
        // Name of custom type.
        private String name;

        // Data type in graph.
        public EDataType dataType;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of graph type.</param>
        /// <param name="dataType">Data type in graph.</param>
        public EGraphCustomType(String name, EDataType dataType)
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
