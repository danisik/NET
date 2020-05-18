using DataLayer.Data;
using DataLayer.Model;
using System;
using System.Collections.Generic;

namespace ModelLayer.Managers
{
    /// <summary>
    /// Manager for graph window.
    /// </summary>
    public class GraphWindowManager
    {
        // Database interface.
        private DatabaseInterface databaseInterface;

        /// <summary>
        /// Constructor.
        /// </summary>
        public GraphWindowManager()
        {
            this.databaseInterface = new DatabaseInterface();
        }

        /// <summary>
        /// Get all used cities in dataset.
        /// </summary>
        /// <param name="datasetID"> ID of current dataset. </param>
        /// <returns> List of cities. </returns>
        public List<String> getCitiesInDataset(int datasetID)
        {
            return databaseInterface.getCitiesInDataset(datasetID);
        }

        /// <summary>
        /// Get all records for specific dataset.
        /// </summary>
        /// <param name="datasetID"> ID of current dataset. </param>
        /// <param name="cities"> Cities in database. </param>
        /// <returns> Map of records. </returns>
        public Dictionary<int, Record> getRecords(int datasetID, Dictionary<String, City> cities)
        {
            return databaseInterface.getRecords(datasetID, cities);
        }
    }
}
