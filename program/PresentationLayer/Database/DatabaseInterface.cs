﻿using System;
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
                    measures.TryGetValue(reader.GetString(1), out measure);

                    datasets.Add(reader.GetString(0), new Dataset(reader.GetString(0), measure));
                }
            }

            connection.Close();

            return datasets;
        }

        public List<Record> getRecords(String datasetName, Dictionary<String, City> cities)
        {
            List<Record> records = new List<Record>();

            command.CommandText = "SELECT * FROM Record WHERE name_dataset = @nameDataset";
            SqlParameter nameDatasetParameter = new SqlParameter("nameDataset", System.Data.SqlDbType.VarChar);
            command.Parameters.Add(nameDatasetParameter).Value = datasetName;
            
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
            command.Parameters.Remove(nameDatasetParameter);

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
                connection.Open();

                if (deletedCities.Count > 0)
                {
                    commandText = "DELETE FROM City WHERE name IN (";
                    for (int i = 0; i < deletedCities.Count; i++)
                    {
                        commandText += "'" + deletedCities[i] + "'";

                        if (i < deletedCities.Count - 1) commandText += ", ";
                    }

                    commandText += ")";

                    command.CommandText = commandText;

                    command.ExecuteReader();

                }

                if (newCities.Count > 0)
                {
                    commandText = "INSERT INTO City (name) VALUES ";
                    for (int i = 0; i < newCities.Count; i++)
                    {
                        commandText += "('" + newCities[i] + "')";

                        if (i < newCities.Count - 1) commandText += ", ";
                    }

                    command.CommandText = commandText;

                    command.ExecuteReader();
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

            if (isPresented) return true;
            else return false;
        }

        public bool updateRecords()
        {

            return true;
        }

        public SqlConnection Connection { get; }
    }
}