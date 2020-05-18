using DataLayer.Data;
using DataLayer.Model;
using System;
using System.Collections.Generic;

namespace ModelLayer.Managers
{
    /// <summary>
    /// Manager for main window.
    /// </summary>
    public class MainWindowManager
    {
        // Database interface.
        private DatabaseInterface databaseInterface;

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainWindowManager()
        {
            this.databaseInterface = new DatabaseInterface();
        }

        /// <summary>
        /// Get all measures.
        /// </summary>
        /// <returns> Map of measures. </returns>
        public Dictionary<String, Measure> getMeasures()
        {
            return databaseInterface.getMeasures();
        }

        /// <summary>
        /// Get all cities in database.
        /// </summary>
        /// <returns> Map of cities. </returns>
        public Dictionary<String, City> getCities()
        {
            return databaseInterface.getCities();
        }

        /// <summary>
        /// Get all datasets.
        /// </summary>
        /// <param name="measures"> Measures in database. </param>
        /// <returns> Map of datasets. </returns>
        public Dictionary<String, Dataset> getDatasets(Dictionary<String, Measure> measures)
        {
            return databaseInterface.getDatasets(measures);
        }

        /// <summary>
        /// Update all records in dataset.
        /// </summary>
        /// <param name="idDataset"> ID of current dataset. </param>
        /// <param name="newRecords"> Newly created records. </param>
        /// <param name="recordsToBeDeleted"> Records to be deleted. </param>
        /// <param name="recordsToBeUpdated"> Updated records. </param>
        /// <returns></returns>
        public bool updateRecords(int idDataset, List<Record> newRecords, List<int> recordsToBeDeleted, Dictionary<int, Record> recordsToBeUpdated)
        {
            return databaseInterface.updateRecords(idDataset, newRecords, recordsToBeDeleted, recordsToBeUpdated);
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

        /// <summary>
        /// Validate value, if it is double or not.
        /// </summary>
        /// <param name="newValue"> Value in String. </param>
        /// <returns> True if value is double, false if not. </returns>
        public bool validateMonth(String newValue)
        {
            if (!Double.TryParse(newValue, out Double ignored)) return false;
            else return true;
        }
    }
}
