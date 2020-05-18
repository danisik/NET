using DataLayer.Data;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Managers
{
    /// <summary>
    /// Manager for manage datasets window manager.
    /// </summary>
    public class ManageDatasetsWindowManager
    {
        // Database interface.
        private DatabaseInterface databaseInterface;

        /// <summary>
        /// Constructor.
        /// </summary>
        public ManageDatasetsWindowManager()
        {
            this.databaseInterface = new DatabaseInterface();
        }

        /// <summary>
        /// Get all datasets.
        /// </summary>
        /// <returns> Map of datasets. </returns>
        public Dictionary<String, Dataset> getDatasets()
        {
            return databaseInterface.getDatasets(databaseInterface.getMeasures());
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
        /// Update datasets.
        /// </summary>
        /// <param name="newDatasets"> Newly created datasets. </param>
        /// <param name="datasetsToBeDeleted"> Datasets to be deleted. </param>
        /// <param name="datasetsToBeUpdated"> Updated datasets. </param>
        /// <returns> True if every change was successful, false if not. </returns>
        public Boolean updateDatasets(List<Dataset> newDatasets, List<int> datasetsToBeDeleted, List<Dataset> datasetsToBeUpdated)
        {
            return databaseInterface.updateDatasets(newDatasets, datasetsToBeDeleted, datasetsToBeUpdated);
        }
    }
}
