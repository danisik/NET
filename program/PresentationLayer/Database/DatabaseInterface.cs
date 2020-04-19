using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataLayer.Model;

namespace DataLayer.Data
{
    public class DatabaseInterface
    {
        private static readonly String databaseConnectionString =
            "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\danisik\\Documents\\GitHub\\NET\\program\\PresentationLayer\\Database\\Database.mdf;Integrated Security=True";

        private SqlConnection connection = null;
        private SqlCommand command = null;

        public DatabaseInterface()
        {
            connection = new SqlConnection(databaseConnectionString);
            command = new SqlCommand
            {
                Connection = connection,
                CommandType = System.Data.CommandType.Text
            };

            if (connection.State != ConnectionState.Closed) connection.Close();
        }

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

        public bool updateRecords(int idDataset, List<Record> newRecords, List<int> recordsToBeDeleted, Dictionary<int, Record> recordsToBeUpdated)
        {
            bool success = false;

            SqlParameter idRecordDatasetParameter = new SqlParameter("idRecordDataset", System.Data.SqlDbType.Int);
            SqlParameter nameCityParameter = new SqlParameter("nameCity", System.Data.SqlDbType.VarChar);
            SqlParameter temperature1Parameter = new SqlParameter("temperature1", System.Data.SqlDbType.Float);
            SqlParameter temperature2Parameter = new SqlParameter("temperature2", System.Data.SqlDbType.Float);
            SqlParameter temperature3Parameter = new SqlParameter("temperature3", System.Data.SqlDbType.Float);
            SqlParameter temperature4Parameter = new SqlParameter("temperature4", System.Data.SqlDbType.Float);
            SqlParameter temperature5Parameter = new SqlParameter("temperature5", System.Data.SqlDbType.Float);
            SqlParameter temperature6Parameter = new SqlParameter("temperature6", System.Data.SqlDbType.Float);
            SqlParameter temperature7Parameter = new SqlParameter("temperature7", System.Data.SqlDbType.Float);
            SqlParameter temperature8Parameter = new SqlParameter("temperature8", System.Data.SqlDbType.Float);
            SqlParameter temperature9Parameter = new SqlParameter("temperature9", System.Data.SqlDbType.Float);
            SqlParameter temperature10Parameter = new SqlParameter("temperature10", System.Data.SqlDbType.Float);
            SqlParameter temperature11Parameter = new SqlParameter("temperature11", System.Data.SqlDbType.Float);
            SqlParameter temperature12Parameter = new SqlParameter("temperature12", System.Data.SqlDbType.Float);
            SqlParameter recordOrderParameter = new SqlParameter("recordOrder", System.Data.SqlDbType.Int);
            SqlParameter idRecordParameter = new SqlParameter("idRecord", System.Data.SqlDbType.Int);

            try
            {
                string commandText;
                if (newRecords.Count > 0)
                { 
                    command.CommandText = "INSERT INTO Record (id_dataset, name_city, temperature1, temperature2," +
                        "temperature3, temperature4, temperature5, temperature6, temperature7, temperature8, " +
                        "temperature9, temperature10, temperature11, temperature12, record_order) VALUES " +
                        "(@idRecordDataset, " +
                        "@nameCity, " +
                        "@temperature1, " +
                        "@temperature2, " +
                        "@temperature3, " +
                        "@temperature4, " +
                        "@temperature5, " +
                        "@temperature6, " +
                        "@temperature7, " +
                        "@temperature8, " +
                        "@temperature9, " +
                        "@temperature10, " +
                        "@temperature11, " +
                        "@temperature12, " +
                        "@recordOrder" +
                        ")";

                    command.Parameters.Add(idRecordDatasetParameter).Value = idDataset;
                    command.Parameters.Add(nameCityParameter);
                    command.Parameters.Add(temperature1Parameter);
                    command.Parameters.Add(temperature2Parameter);
                    command.Parameters.Add(temperature3Parameter);
                    command.Parameters.Add(temperature4Parameter);
                    command.Parameters.Add(temperature5Parameter);
                    command.Parameters.Add(temperature6Parameter);
                    command.Parameters.Add(temperature7Parameter);
                    command.Parameters.Add(temperature8Parameter);
                    command.Parameters.Add(temperature9Parameter);
                    command.Parameters.Add(temperature10Parameter);
                    command.Parameters.Add(temperature11Parameter);
                    command.Parameters.Add(temperature12Parameter);
                    command.Parameters.Add(recordOrderParameter);

                    foreach (Record record in newRecords)
                    {
                        connection.Open();

                        nameCityParameter.Value = record.City.Name;
                        temperature1Parameter.Value = record.January;
                        temperature2Parameter.Value = record.February;
                        temperature3Parameter.Value = record.March;
                        temperature4Parameter.Value = record.April;
                        temperature5Parameter.Value = record.May;
                        temperature6Parameter.Value = record.June;
                        temperature7Parameter.Value = record.July;
                        temperature8Parameter.Value = record.August;
                        temperature9Parameter.Value = record.September;
                        temperature10Parameter.Value = record.October;
                        temperature11Parameter.Value = record.November;
                        temperature12Parameter.Value = record.December;
                        recordOrderParameter.Value = record.Order;                        

                        command.ExecuteReader();
                        connection.Close();
                    }

                    command.Parameters.Remove(idRecordDatasetParameter);
                    command.Parameters.Remove(nameCityParameter);
                    command.Parameters.Remove(temperature1Parameter);
                    command.Parameters.Remove(temperature2Parameter);
                    command.Parameters.Remove(temperature3Parameter);
                    command.Parameters.Remove(temperature4Parameter);
                    command.Parameters.Remove(temperature5Parameter);
                    command.Parameters.Remove(temperature6Parameter);
                    command.Parameters.Remove(temperature7Parameter);
                    command.Parameters.Remove(temperature8Parameter);
                    command.Parameters.Remove(temperature9Parameter);
                    command.Parameters.Remove(temperature10Parameter);
                    command.Parameters.Remove(temperature11Parameter);
                    command.Parameters.Remove(temperature12Parameter);
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
                        "temperature1 = @temperature1, " +
                        "temperature2 = @temperature2," +
                        "temperature3 = @temperature3, " +
                        "temperature4 = @temperature4, " +
                        "temperature5 = @temperature5, " +
                        "temperature6 = @temperature6, " +
                        "temperature7 = @temperature7, " +
                        "temperature8 = @temperature8," +
                        "temperature9 = @temperature9, " +
                        "temperature10 = @temperature10, " +
                        "temperature11 = @temperature11, " +
                        "temperature12 = @temperature12, " +
                        "record_order = @recordOrder " +
                        "WHERE id = @idRecord";

                    command.Parameters.Add(idRecordDatasetParameter).Value = idDataset;
                    command.Parameters.Add(nameCityParameter);
                    command.Parameters.Add(temperature1Parameter);
                    command.Parameters.Add(temperature2Parameter);
                    command.Parameters.Add(temperature3Parameter);
                    command.Parameters.Add(temperature4Parameter);
                    command.Parameters.Add(temperature5Parameter);
                    command.Parameters.Add(temperature6Parameter);
                    command.Parameters.Add(temperature7Parameter);
                    command.Parameters.Add(temperature8Parameter);
                    command.Parameters.Add(temperature9Parameter);
                    command.Parameters.Add(temperature10Parameter);
                    command.Parameters.Add(temperature11Parameter);
                    command.Parameters.Add(temperature12Parameter);
                    command.Parameters.Add(recordOrderParameter);
                    command.Parameters.Add(idRecordParameter);


                    foreach (Record record in recordsToBeUpdated.Values)
                    {
                        connection.Open();
                        nameCityParameter.Value = record.City.Name;
                        temperature1Parameter.Value = record.January;
                        temperature2Parameter.Value = record.February;
                        temperature3Parameter.Value = record.March;
                        temperature4Parameter.Value = record.April;
                        temperature5Parameter.Value = record.May;
                        temperature6Parameter.Value = record.June;
                        temperature7Parameter.Value = record.July;
                        temperature8Parameter.Value = record.August;
                        temperature9Parameter.Value = record.September;
                        temperature10Parameter.Value = record.October;
                        temperature11Parameter.Value = record.November;
                        temperature12Parameter.Value = record.December;
                        recordOrderParameter.Value = record.Order;
                        idRecordParameter.Value = record.Id;

                        command.ExecuteReader();
                        connection.Close();
                    }

                    command.Parameters.Remove(idRecordDatasetParameter);
                    command.Parameters.Remove(nameCityParameter);
                    command.Parameters.Remove(temperature1Parameter);
                    command.Parameters.Remove(temperature2Parameter);
                    command.Parameters.Remove(temperature3Parameter);
                    command.Parameters.Remove(temperature4Parameter);
                    command.Parameters.Remove(temperature5Parameter);
                    command.Parameters.Remove(temperature6Parameter);
                    command.Parameters.Remove(temperature7Parameter);
                    command.Parameters.Remove(temperature8Parameter);
                    command.Parameters.Remove(temperature9Parameter);
                    command.Parameters.Remove(temperature10Parameter);
                    command.Parameters.Remove(temperature11Parameter);
                    command.Parameters.Remove(temperature12Parameter);
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
                if (temperature1Parameter != null) command.Parameters.Remove(temperature1Parameter);
                if (temperature2Parameter != null) command.Parameters.Remove(temperature2Parameter);
                if (temperature3Parameter != null) command.Parameters.Remove(temperature3Parameter);
                if (temperature4Parameter != null) command.Parameters.Remove(temperature4Parameter);
                if (temperature5Parameter != null) command.Parameters.Remove(temperature5Parameter);
                if (temperature6Parameter != null) command.Parameters.Remove(temperature6Parameter);
                if (temperature7Parameter != null) command.Parameters.Remove(temperature7Parameter);
                if (temperature8Parameter != null) command.Parameters.Remove(temperature8Parameter);
                if (temperature9Parameter != null) command.Parameters.Remove(temperature9Parameter);
                if (temperature10Parameter != null) command.Parameters.Remove(temperature10Parameter);
                if (temperature11Parameter != null) command.Parameters.Remove(temperature11Parameter);
                if (temperature12Parameter != null) command.Parameters.Remove(temperature12Parameter);
                if (recordOrderParameter != null) command.Parameters.Remove(recordOrderParameter);
                if (idRecordParameter != null && command.Parameters.Contains(idRecordParameter)) command.Parameters.Remove(idRecordParameter);
            }
            finally
            {
                connection.Close();
            }

            return success;
        }

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
