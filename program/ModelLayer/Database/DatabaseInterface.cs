using System;
using System.Collections.Generic;
using System.Data;
using DataLayer.Model;
using System.IO;
using System.Data.SqlClient;

namespace DataLayer.Data
{
    /// <summary>
    /// Database interface for accessing data.
    /// </summary>
    public class DatabaseInterface
    {
        // Database connecting string.
        private static readonly String databaseConnectionString =
            "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";

        // Database connection.
        private SqlConnection connection = null;
        // Database command.
        private SqlCommand command = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        public DatabaseInterface()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.GetFullPath(@"."));
            connection = new SqlConnection(databaseConnectionString);
            command = new SqlCommand
            {
                Connection = connection,
                CommandType = System.Data.CommandType.Text
            };

            if (connection.State != ConnectionState.Closed) connection.Close();
        }

        /// <summary>
        /// Get all measures.
        /// </summary>
        /// <returns> Map of measures. </returns>
        public Dictionary<String, Measure> getMeasures()
        {
            Dictionary<String, Measure> measures = new Dictionary<String, Measure>();

            command.CommandText = "SELECT * FROM Measure";
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    measures.Add(reader.GetString(0), new Measure(reader.GetString(0), reader.GetString(1)));
                }
            }

            connection.Close();

            return measures;
        } 

        /// <summary>
        /// Get all datasets.
        /// </summary>
        /// <param name="measures"> Measures in database. </param>
        /// <returns> Map of datasets. </returns>
        public Dictionary<String, Dataset> getDatasets(Dictionary<String, Measure> measures)
        {         
            Dictionary<String, Dataset> datasets = new Dictionary<String, Dataset>();

            command.CommandText = "SELECT * FROM Dataset";            
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Measure measure = measures[reader.GetString(2)];

                    datasets.Add(reader.GetString(1), new Dataset(reader.GetInt32(0), reader.GetString(1), measure));
                }
            }

            connection.Close();

            return datasets;
        }

        /// <summary>
        /// Get all records for specific dataset.
        /// </summary>
        /// <param name="datasetID"> ID of current dataset. </param>
        /// <param name="cities"> Cities in database. </param>
        /// <returns> Map of records. </returns>
        public Dictionary<int, Record> getRecords(int datasetID, Dictionary<String, City> cities)
        {
            Dictionary<int, Record> records = new Dictionary<int, Record> ();

            command.CommandText = "SELECT * FROM Record WHERE id_dataset = @datasetID ORDER BY record_order";
            SqlParameter idDatasetParameter = new SqlParameter("datasetID", System.Data.SqlDbType.Int);
            command.Parameters.Add(idDatasetParameter).Value = datasetID;
            
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cities.TryGetValue(reader.GetString(2), out City city);

                    Record record = new Record(reader.GetInt32(0), city, reader.GetDouble(3), reader.GetDouble(4),
                        reader.GetDouble(5), reader.GetDouble(6), reader.GetDouble(7), reader.GetDouble(8),
                        reader.GetDouble(9), reader.GetDouble(10), reader.GetDouble(11), reader.GetDouble(12),
                        reader.GetDouble(13), reader.GetDouble(14), reader.GetInt32(15));

                    records.Add(record.Id, record);
                }
            }

            connection.Close();
            command.Parameters.Remove(idDatasetParameter);

            return records;
        }

        /// <summary>
        /// Get all used cities in dataset.
        /// </summary>
        /// <param name="datasetID"> ID of current dataset. </param>
        /// <returns> List of cities. </returns>
        public List<String> getCitiesInDataset(int datasetID)
        {
            List<String> cities = new List<String>();

            command.CommandText = "SELECT name_city FROM Record WHERE id_dataset = @datasetID";
            SqlParameter idDatasetParameter = new SqlParameter("datasetID", System.Data.SqlDbType.Int);
            command.Parameters.Add(idDatasetParameter).Value = datasetID;

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cities.Add(reader.GetString(0));
                }
            }

            connection.Close();
            command.Parameters.Remove(idDatasetParameter);

            cities.Sort();

            return cities;
        }

        /// <summary>
        /// Update dataset's measure.
        /// </summary>
        /// <param name="nameDataset"> Dataset name. </param>
        /// <param name="newMeasureName"> New measure name. </param>
        /// <returns> True if measure name was successfully updated, false if not. </returns>
        public Boolean updateDatasetMeasure(String nameDataset, String newMeasureName)
        {
            command.CommandText = "UPDATE Dataset SET measure_name = @newMeasureName WHERE name = @nameDataset";
            SqlParameter newMeasureNameParameter = new SqlParameter("newMeasureName", System.Data.SqlDbType.VarChar);
            SqlParameter nameDatasetParameter = new SqlParameter("nameDataset", System.Data.SqlDbType.VarChar);
            command.Parameters.Add(newMeasureNameParameter).Value = newMeasureName;
            command.Parameters.Add(nameDatasetParameter).Value = nameDataset;

            connection.Open();

            int result = command.ExecuteNonQuery();

            connection.Close();
            command.Parameters.Remove(newMeasureNameParameter);
            command.Parameters.Remove(nameDatasetParameter);

            if (result > -1) return true;
            else return false;
        }

        /// <summary>
        /// Get all cities in database.
        /// </summary>
        /// <returns> Map of cities. </returns>
        public Dictionary<String, City> getCities()
        {
            Dictionary<String, City> cities = new Dictionary<string, City>();

            command.CommandText = "SELECT * FROM City";
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cities.Add(reader.GetString(0), new City(reader.GetString(0)));
                }
            }
            
            connection.Close();

            return cities;
        }

        /// <summary>
        /// Update city table.
        /// </summary>
        /// <param name="newCities"> New city names</param>
        /// <param name="deletedCities"> Deleted city names. </param>
        /// <returns> True of every change was successful, false if not. </returns>
        public bool updateCities(List<String> newCities, List<String> deletedCities)
        {
            bool success = false;
            try
            {
                string commandText;
                if (deletedCities.Count > 0)
                {
                    connection.Open();
                    commandText = "DELETE FROM City WHERE name IN (";
                    for (int i = 0; i < deletedCities.Count; i++)
                    {
                        commandText += "'" + deletedCities[i] + "'";

                        if (i < deletedCities.Count - 1) commandText += ", ";
                    }

                    commandText += ")";

                    command.CommandText = commandText;

                    command.ExecuteReader();
                    connection.Close();

                }

                if (newCities.Count > 0)
                {
                    connection.Open();
                    commandText = "INSERT INTO City (name) VALUES ";
                    for (int i = 0; i < newCities.Count; i++)
                    {
                        commandText += "('" + newCities[i] + "')";

                        if (i < newCities.Count - 1) commandText += ", ";
                    }

                    command.CommandText = commandText;

                    command.ExecuteReader();
                    connection.Close();
                }
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            finally
            {
                connection.Close();
            }

            return success;
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
            bool success = false;
            SqlParameter newDatasetNameParameter = null;
            SqlParameter newMeasureNameParameter = null;
            SqlParameter datasetIDParameter = null;

            try
            {
                string commandText;
                if (newDatasets.Count > 0)
                {
                    connection.Open();
                    commandText = "INSERT INTO Dataset (name, measure_name) VALUES ";
                    int i = newDatasets.Count - 1;
                    foreach (Dataset dataset in newDatasets)
                    {
                        commandText += "('" + dataset.Name + "', '" + dataset.Measure.Name + "')";

                        if (i > 0) commandText += ", ";
                        i--;
                    }

                    command.CommandText = commandText;

                    command.ExecuteReader();
                    connection.Close();
                }

                if (datasetsToBeDeleted.Count > 0)
                {
                    connection.Open();
                    commandText = "DELETE FROM Record WHERE id_dataset IN (";
                    for (int i = 0; i < datasetsToBeDeleted.Count; i++)
                    {
                        commandText += "'" + datasetsToBeDeleted[i] + "'";

                        if (i < datasetsToBeDeleted.Count - 1) commandText += ", ";
                    }

                    commandText += ")";

                    command.CommandText = commandText;

                    command.ExecuteReader();
                    connection.Close();

                    connection.Open();
                    commandText = "DELETE FROM Dataset WHERE id IN (";
                    for (int i = 0; i < datasetsToBeDeleted.Count; i++)
                    {
                        commandText += "'" + datasetsToBeDeleted[i] + "'";

                        if (i < datasetsToBeDeleted.Count - 1) commandText += ", ";
                    }

                    commandText += ")";

                    command.CommandText = commandText;

                    command.ExecuteReader();
                    connection.Close();
                }

                if (datasetsToBeUpdated.Count > 0)
                {
                    command.CommandText = "UPDATE Dataset SET name = @newDatasetName, measure_name = @newMeasureName WHERE id = @id";
                    newDatasetNameParameter = new SqlParameter("newDatasetName", System.Data.SqlDbType.VarChar);
                    newMeasureNameParameter = new SqlParameter("newMeasureName", System.Data.SqlDbType.VarChar);
                    datasetIDParameter = new SqlParameter("id", System.Data.SqlDbType.Int);
                    command.Parameters.Add(newDatasetNameParameter);
                    command.Parameters.Add(newMeasureNameParameter);
                    command.Parameters.Add(datasetIDParameter);


                    foreach (Dataset dataset in datasetsToBeUpdated)
                    {
                        connection.Open();
                        newDatasetNameParameter.Value = dataset.Name;
                        newMeasureNameParameter.Value = dataset.Measure.Name;
                        datasetIDParameter.Value = dataset.ID;

                        command.ExecuteReader();
                        connection.Close();
                    }

                    command.Parameters.Remove(newDatasetNameParameter);
                    command.Parameters.Remove(newMeasureNameParameter);
                    command.Parameters.Remove(datasetIDParameter);                    
                }
                success = true;
            }
            catch (Exception)
            {
                success = false;

                if (newDatasetNameParameter != null) command.Parameters.Remove(newDatasetNameParameter);
                if (newMeasureNameParameter != null) command.Parameters.Remove(newMeasureNameParameter);
                if (datasetIDParameter != null) command.Parameters.Remove(datasetIDParameter);
            }
            finally
            {
                connection.Close();
            }

            return success;
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
            bool success = false;
            SqlParameter newMeasureTagParameter = null;
            SqlParameter measureNameParameter = null;

            try
            {
                string commandText;
                if (newMeasures.Count > 0)
                {
                    connection.Open();
                    commandText = "INSERT INTO Measure (name, measure_tag) VALUES ";
                    int i = newMeasures.Count - 1;
                    foreach (Measure measure in newMeasures)
                    {
                        commandText += "('" + measure.Name + "', '" + measure.Tag + "')";

                        if (i > 0) commandText += ", ";
                        i--;
                    }

                    command.CommandText = commandText;

                    command.ExecuteReader();
                    connection.Close();
                }

                if (measuresToBeDeleted.Count > 0)
                {
                    connection.Open();
                    commandText = "DELETE FROM Measure WHERE name IN (";
                    for (int i = 0; i < measuresToBeDeleted.Count; i++)
                    {
                        commandText += "'" + measuresToBeDeleted[i] + "'";

                        if (i < measuresToBeDeleted.Count - 1) commandText += ", ";
                    }

                    commandText += ")";

                    command.CommandText = commandText;

                    command.ExecuteReader();
                    connection.Close();
                }
                
                if (measuresToBeUpdated.Count > 0)
                {                    
                    command.CommandText = "UPDATE Measure SET measure_tag = @newMeasureTag WHERE name = @measureName";
                    newMeasureTagParameter = new SqlParameter("newMeasureTag", System.Data.SqlDbType.VarChar);
                    measureNameParameter = new SqlParameter("measureName", System.Data.SqlDbType.VarChar);
                    command.Parameters.Add(newMeasureTagParameter);
                    command.Parameters.Add(measureNameParameter);


                    foreach (Measure measure in measuresToBeUpdated)
                    {
                        connection.Open();
                        newMeasureTagParameter.Value = measure.Tag;
                        measureNameParameter.Value = measure.Name;

                        command.ExecuteReader();
                        connection.Close();
                    }

                    command.Parameters.Remove(newMeasureTagParameter);
                    command.Parameters.Remove(measureNameParameter);
                }
                success = true;
            }
            catch (Exception)
            {
                success = false;

                if (newMeasureTagParameter != null) command.Parameters.Remove(newMeasureTagParameter);
                if (measureNameParameter != null) command.Parameters.Remove(measureNameParameter);
            }
            finally
            {
                connection.Close();
            }

            return success;
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
            bool success = false;

            SqlParameter idRecordDatasetParameter = new SqlParameter("idRecordDataset", System.Data.SqlDbType.Int);
            SqlParameter nameCityParameter = new SqlParameter("nameCity", System.Data.SqlDbType.VarChar);
            SqlParameter januaryParameter = new SqlParameter("january", System.Data.SqlDbType.Float);
            SqlParameter februaryParameter = new SqlParameter("february", System.Data.SqlDbType.Float);
            SqlParameter marchParameter = new SqlParameter("march", System.Data.SqlDbType.Float);
            SqlParameter aprilParameter = new SqlParameter("april", System.Data.SqlDbType.Float);
            SqlParameter mayParameter = new SqlParameter("may", System.Data.SqlDbType.Float);
            SqlParameter juneParameter = new SqlParameter("june", System.Data.SqlDbType.Float);
            SqlParameter julyParameter = new SqlParameter("july", System.Data.SqlDbType.Float);
            SqlParameter augustParameter = new SqlParameter("august", System.Data.SqlDbType.Float);
            SqlParameter septemberParameter = new SqlParameter("september", System.Data.SqlDbType.Float);
            SqlParameter octoberParameter = new SqlParameter("october", System.Data.SqlDbType.Float);
            SqlParameter novemberParameter = new SqlParameter("november", System.Data.SqlDbType.Float);
            SqlParameter decemberParameter = new SqlParameter("december", System.Data.SqlDbType.Float);
            SqlParameter recordOrderParameter = new SqlParameter("recordOrder", System.Data.SqlDbType.Int);
            SqlParameter idRecordParameter = new SqlParameter("idRecord", System.Data.SqlDbType.Int);

            try
            {
                string commandText;
                if (newRecords.Count > 0)
                { 
                    command.CommandText = "INSERT INTO Record (id_dataset, name_city, january, february," +
                        "march, april, may, june, july, august, " +
                        "september, october, november, december, record_order) VALUES " +
                        "(@idRecordDataset, " +
                        "@nameCity, " +
                        "@january, " +
                        "@february, " +
                        "@march, " +
                        "@april, " +
                        "@may, " +
                        "@june, " +
                        "@july, " +
                        "@august, " +
                        "@september, " +
                        "@october, " +
                        "@november, " +
                        "@december, " +
                        "@recordOrder" +
                        ")";

                    command.Parameters.Add(idRecordDatasetParameter).Value = idDataset;
                    command.Parameters.Add(nameCityParameter);
                    command.Parameters.Add(januaryParameter);
                    command.Parameters.Add(februaryParameter);
                    command.Parameters.Add(marchParameter);
                    command.Parameters.Add(aprilParameter);
                    command.Parameters.Add(mayParameter);
                    command.Parameters.Add(juneParameter);
                    command.Parameters.Add(julyParameter);
                    command.Parameters.Add(augustParameter);
                    command.Parameters.Add(septemberParameter);
                    command.Parameters.Add(octoberParameter);
                    command.Parameters.Add(novemberParameter);
                    command.Parameters.Add(decemberParameter);
                    command.Parameters.Add(recordOrderParameter);

                    foreach (Record record in newRecords)
                    {
                        connection.Open();

                        nameCityParameter.Value = record.City.Name;
                        januaryParameter.Value = record.January;
                        februaryParameter.Value = record.February;
                        marchParameter.Value = record.March;
                        aprilParameter.Value = record.April;
                        mayParameter.Value = record.May;
                        juneParameter.Value = record.June;
                        julyParameter.Value = record.July;
                        augustParameter.Value = record.August;
                        septemberParameter.Value = record.September;
                        octoberParameter.Value = record.October;
                        novemberParameter.Value = record.November;
                        decemberParameter.Value = record.December;
                        recordOrderParameter.Value = record.Order;                        

                        command.ExecuteReader();
                        connection.Close();
                    }

                    command.Parameters.Remove(idRecordDatasetParameter);
                    command.Parameters.Remove(nameCityParameter);
                    command.Parameters.Remove(januaryParameter);
                    command.Parameters.Remove(februaryParameter);
                    command.Parameters.Remove(marchParameter);
                    command.Parameters.Remove(aprilParameter);
                    command.Parameters.Remove(mayParameter);
                    command.Parameters.Remove(juneParameter);
                    command.Parameters.Remove(julyParameter);
                    command.Parameters.Remove(augustParameter);
                    command.Parameters.Remove(septemberParameter);
                    command.Parameters.Remove(octoberParameter);
                    command.Parameters.Remove(novemberParameter);
                    command.Parameters.Remove(decemberParameter);
                    command.Parameters.Remove(recordOrderParameter);
                }

                if (recordsToBeDeleted.Count > 0)
                {
                    connection.Open();

                    commandText = "DELETE FROM Record WHERE id IN (";
                    for (int i = 0; i < recordsToBeDeleted.Count; i++)
                    {
                        commandText += "'" + recordsToBeDeleted[i] + "'";

                        if (i < recordsToBeDeleted.Count - 1) commandText += ", ";
                    }

                    commandText += ")";

                    command.CommandText = commandText;

                    command.ExecuteReader();
                    connection.Close();
                }

                if (recordsToBeUpdated.Count > 0)
                {                    
                    command.CommandText = "UPDATE Record SET " +
                        "id_dataset = @idRecordDataset, " +
                        "name_city = @nameCity, " +
                        "january = @january, " +
                        "february = @february," +
                        "march = @march, " +
                        "april = @april, " +
                        "may = @may, " +
                        "june = @june, " +
                        "july = @july, " +
                        "august = @august," +
                        "september = @september, " +
                        "october = @october, " +
                        "november = @november, " +
                        "december = @december, " +
                        "record_order = @recordOrder " +
                        "WHERE id = @idRecord";

                    command.Parameters.Add(idRecordDatasetParameter).Value = idDataset;
                    command.Parameters.Add(nameCityParameter);
                    command.Parameters.Add(januaryParameter);
                    command.Parameters.Add(februaryParameter);
                    command.Parameters.Add(marchParameter);
                    command.Parameters.Add(aprilParameter);
                    command.Parameters.Add(mayParameter);
                    command.Parameters.Add(juneParameter);
                    command.Parameters.Add(julyParameter);
                    command.Parameters.Add(augustParameter);
                    command.Parameters.Add(septemberParameter);
                    command.Parameters.Add(octoberParameter);
                    command.Parameters.Add(novemberParameter);
                    command.Parameters.Add(decemberParameter);
                    command.Parameters.Add(recordOrderParameter);
                    command.Parameters.Add(idRecordParameter);


                    foreach (Record record in recordsToBeUpdated.Values)
                    {
                        connection.Open();
                        nameCityParameter.Value = record.City.Name;
                        januaryParameter.Value = record.January;
                        februaryParameter.Value = record.February;
                        marchParameter.Value = record.March;
                        aprilParameter.Value = record.April;
                        mayParameter.Value = record.May;
                        juneParameter.Value = record.June;
                        julyParameter.Value = record.July;
                        augustParameter.Value = record.August;
                        septemberParameter.Value = record.September;
                        octoberParameter.Value = record.October;
                        novemberParameter.Value = record.November;
                        decemberParameter.Value = record.December;
                        recordOrderParameter.Value = record.Order;
                        idRecordParameter.Value = record.Id;

                        command.ExecuteReader();
                        connection.Close();
                    }

                    command.Parameters.Remove(idRecordDatasetParameter);
                    command.Parameters.Remove(nameCityParameter);
                    command.Parameters.Remove(januaryParameter);
                    command.Parameters.Remove(februaryParameter);
                    command.Parameters.Remove(marchParameter);
                    command.Parameters.Remove(aprilParameter);
                    command.Parameters.Remove(mayParameter);
                    command.Parameters.Remove(juneParameter);
                    command.Parameters.Remove(julyParameter);
                    command.Parameters.Remove(augustParameter);
                    command.Parameters.Remove(septemberParameter);
                    command.Parameters.Remove(octoberParameter);
                    command.Parameters.Remove(novemberParameter);
                    command.Parameters.Remove(decemberParameter);
                    command.Parameters.Remove(recordOrderParameter);
                    command.Parameters.Remove(idRecordParameter);                    
                }

                success = true;
            }
            catch (Exception)
            {
                success = false;

                if (idRecordDatasetParameter != null) command.Parameters.Remove(idRecordDatasetParameter);
                if (nameCityParameter != null) command.Parameters.Remove(nameCityParameter);
                if (januaryParameter != null) command.Parameters.Remove(januaryParameter);
                if (februaryParameter != null) command.Parameters.Remove(februaryParameter);
                if (marchParameter != null) command.Parameters.Remove(marchParameter);
                if (aprilParameter != null) command.Parameters.Remove(aprilParameter);
                if (mayParameter != null) command.Parameters.Remove(mayParameter);
                if (juneParameter != null) command.Parameters.Remove(juneParameter);
                if (julyParameter != null) command.Parameters.Remove(julyParameter);
                if (augustParameter != null) command.Parameters.Remove(augustParameter);
                if (septemberParameter != null) command.Parameters.Remove(septemberParameter);
                if (octoberParameter != null) command.Parameters.Remove(octoberParameter);
                if (novemberParameter != null) command.Parameters.Remove(novemberParameter);
                if (decemberParameter != null) command.Parameters.Remove(decemberParameter);
                if (recordOrderParameter != null) command.Parameters.Remove(recordOrderParameter);
                if (idRecordParameter != null && command.Parameters.Contains(idRecordParameter)) command.Parameters.Remove(idRecordParameter);
            }
            finally
            {
                connection.Close();
            }

            return success;
        }

        /// <summary>
        /// Test if city is presented in any record in database.
        /// </summary>
        /// <param name="cityName"> City name. </param>
        /// <returns> True if city name is presented in any record, false if not. </returns>
        public bool testIfCityIsPresentedInRecords(String cityName)
        {
            bool isPresented = false;

            command.CommandText = "SELECT * FROM Record WHERE name_city = @cityName";
            SqlParameter cityNameParameter = new SqlParameter("cityName", System.Data.SqlDbType.VarChar);
            command.Parameters.Add(cityNameParameter).Value = cityName;

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) isPresented = true;

            connection.Close();

            command.Parameters.Remove(cityNameParameter);

            return isPresented;
        }

        /// <summary>
        ///  Test if measure is presented in any dataset.
        /// </summary>
        /// <param name="measureName"> Name of measure. </param>
        /// <returns> True if measure name is presented in any dataset, false if not. </returns>
        public bool testIfMeasureIsPresentedInDatasets(String measureName)
        {
            bool isPresented = false;

            command.CommandText = "SELECT * FROM Dataset WHERE measure_name = @measureName";
            SqlParameter measureNameParameter = new SqlParameter("measureName", System.Data.SqlDbType.VarChar);
            command.Parameters.Add(measureNameParameter);
            measureNameParameter.Value = measureName;

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) isPresented = true;

            connection.Close();

            command.Parameters.Remove(measureNameParameter);

            return isPresented;
        }

        public SqlConnection Connection { get; }
    }
}
