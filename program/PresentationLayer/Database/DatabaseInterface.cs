using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataLayer.Data
{
    public class DatabaseInterface
    {
        private static readonly String databaseConnectionString =
            "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\danisik\\Documents\\GitHub\\NET\\program\\PresentationLayer\\Database\\Database.mdf;Integrated Security=True";

        private SqlConnection connection;
        private SqlCommand command;

        public DatabaseInterface()
        {
            connection = new SqlConnection(databaseConnectionString);
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;

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
                    Measure measure = null;
                    measures.TryGetValue(reader.GetString(2), out measure);

                    datasets.Add(reader.GetString(1), new Dataset(reader.GetInt32(0), reader.GetString(1), measure));
                }
            }

            connection.Close();

            return datasets;
        }

        public List<Record> getRecords(int datasetID, Dictionary<String, City> cities)
        {
            List<Record> records = new List<Record>();

            command.CommandText = "SELECT * FROM Record WHERE id_dataset = @datasetID";
            SqlParameter idDatasetParameter = new SqlParameter("datasetID", System.Data.SqlDbType.Int);
            command.Parameters.Add(idDatasetParameter).Value = datasetID;
            
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    City city = null;
                    cities.TryGetValue(reader.GetString(2), out city);

                    Record record = new Record(reader.GetInt32(0), city, reader.GetDouble(3), reader.GetDouble(4),
                        reader.GetDouble(5), reader.GetDouble(6), reader.GetDouble(7), reader.GetDouble(8),
                        reader.GetDouble(9), reader.GetDouble(10), reader.GetDouble(11), reader.GetDouble(12),
                        reader.GetDouble(13), reader.GetDouble(14), reader.GetInt32(15));

                    records.Add(record);
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

            String commandText = "";

            try
            { 
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
            catch (Exception e)
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
            String commandText = "";

            SqlParameter newDatasetNameParameter = null;
            SqlParameter newMeasureNameParameter = null;
            SqlParameter datasetIDParameter = null;

            try
            {
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
                    connection.Open();
                    command.CommandText = "UPDATE Dataset SET name = @newDatasetName, measure_name = @newMeasureName WHERE id = @id";
                    newDatasetNameParameter = new SqlParameter("newDatasetName", System.Data.SqlDbType.VarChar);
                    newMeasureNameParameter = new SqlParameter("newMeasureName", System.Data.SqlDbType.VarChar);
                    datasetIDParameter = new SqlParameter("id", System.Data.SqlDbType.Int);
                    command.Parameters.Add(newDatasetNameParameter);
                    command.Parameters.Add(newMeasureNameParameter);
                    command.Parameters.Add(datasetIDParameter);


                    foreach (Dataset dataset in datasetsToBeUpdated)
                    {
                        newDatasetNameParameter.Value = dataset.Name;
                        newMeasureNameParameter.Value = dataset.Measure.Name;
                        datasetIDParameter.Value = dataset.ID;

                        command.ExecuteReader();
                    }

                    command.Parameters.Remove(newDatasetNameParameter);
                    command.Parameters.Remove(newMeasureNameParameter);
                    command.Parameters.Remove(datasetIDParameter);
                    connection.Close();
                }
                success = true;
            }
            catch (Exception e)
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

        public Boolean updateMeasures(Dictionary<String, Measure> newMeasures, List<String> measuresToBeDeleted, List<Measure> measuresToBeUpdated)
        {
            bool success = false;
            String commandText = "";

            SqlParameter newMeasureTagParameter = null;
            SqlParameter measureNameParameter = null;

            try
            {
                if (newMeasures.Count > 0)
                {
                    connection.Open();
                    commandText = "INSERT INTO Measure (name, measure_tag) VALUES ";
                    int i = newMeasures.Count - 1;
                    foreach (Measure measure in newMeasures.Values)
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
                    connection.Open();
                    command.CommandText = "UPDATE Measure SET measure_tag = @newMeasureTag WHERE name = @measureName";
                    newMeasureTagParameter = new SqlParameter("newMeasureTag", System.Data.SqlDbType.VarChar);
                    measureNameParameter = new SqlParameter("measureName", System.Data.SqlDbType.VarChar);
                    command.Parameters.Add(newMeasureTagParameter);
                    command.Parameters.Add(measureNameParameter);


                    foreach (Measure measure in measuresToBeUpdated)
                    {
                        newMeasureTagParameter.Value = measure.Tag;
                        measureNameParameter.Value = measure.Name;

                        command.ExecuteReader();
                    }

                    command.Parameters.Remove(newMeasureTagParameter);
                    command.Parameters.Remove(measureNameParameter);
                    connection.Close();
                }
                success = true;
            }
            catch (Exception e)
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

        public bool updateRecords()
        {

            return true;
        }

        public SqlConnection Connection { get; }
    }
}
