using DataLayer.Data;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Managers
{
    /// <summary>
    /// Manager for manage measures window.
    /// </summary>
    public class ManageMeasuresWindowManager
    {
        // Database interface.
        private DatabaseInterface databaseInterface;

        /// <summary>
        /// Constructor.
        /// </summary>
        public ManageMeasuresWindowManager()
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
        /// Update measures. 
        /// </summary>
        /// <param name="newMeasures"> New measures. </param>
        /// <param name="measuresToBeDeleted"> Measures to be deleted. </param>
        /// <param name="measuresToBeUpdated"> Updated measures. </param>
        /// <returns> True if every change was successful, false if not.</returns>
        public Boolean updateMeasures(List<Measure> newMeasures, List<String> measuresToBeDeleted, List<Measure> measuresToBeUpdated)
        {
            return databaseInterface.updateMeasures(newMeasures, measuresToBeDeleted, measuresToBeUpdated);
        }

        /// <summary>
        ///  Test if measure is presented in any dataset.
        /// </summary>
        /// <param name="measureName"> Name of measure. </param>
        /// <returns> True if measure name is presented in any dataset, false if not. </returns>
        public bool testIfMeasureIsPresentedInDatasets(String measureName)
        {
            return databaseInterface.testIfMeasureIsPresentedInDatasets(measureName);
        }
    }
}
