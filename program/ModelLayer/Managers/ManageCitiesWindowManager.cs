using DataLayer.Data;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Managers
{
    /// <summary>
    /// Manager for manage cities window.
    /// </summary>
    public class ManageCitiesWindowManager
    {
        // Database interface.
        private DatabaseInterface databaseInterface;

        /// <summary>
        /// Constructor.
        /// </summary>
        public ManageCitiesWindowManager()
        {
            this.databaseInterface = new DatabaseInterface();
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
        /// Test if city is presented in any record in database.
        /// </summary>
        /// <param name="cityName"> City name. </param>
        /// <returns> True if city name is presented in any record, false if not. </returns>
        public bool testIfCityIsPresentedInRecords(String cityName)
        {
            return databaseInterface.testIfCityIsPresentedInRecords(cityName);
        }

        /// <summary>
        /// Update city table.
        /// </summary>
        /// <param name="newCities"> New city names</param>
        /// <param name="deletedCities"> Deleted city names. </param>
        /// <returns> True of every change was successful, false if not. </returns>
        public bool updateCities(List<String> newCities, List<String> deletedCities)
        {
            return databaseInterface.updateCities(newCities, deletedCities);
        }
    }
}
