using DataLayer.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataLayer.Utils
{
    public class Utils
    {
        public static void displayMessageBox(string errorMessage, String appName, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MessageBox.Show(errorMessage, appName, buttons, icon);
        }

        public static void displayErrorMessageBox(string errorMessage, String appName)
        {
            displayMessageBox(errorMessage, appName, new MessageBoxButtons { }, MessageBoxIcon.Error);
        }

        public static void displayInfoMessageBox(string infoMessage, String appName)
        {
            displayMessageBox(infoMessage, appName, new MessageBoxButtons { }, MessageBoxIcon.Information);
        }

        public static void displayWarningMessageBox(string infoMessage, String appName)
        {
            displayMessageBox(infoMessage, appName, new MessageBoxButtons { }, MessageBoxIcon.Warning);
        }

        public static Dictionary<String, City> sortCities(Dictionary<String, City> unsortedCities)
        {
            Dictionary<String, City> sortedCities = new Dictionary<String, City>();

            List<String> keys = new List<String>(unsortedCities.Keys);
            keys.Sort();

            for (int i = 0; i < unsortedCities.Count; i++)
            {
                City city = null;
                unsortedCities.TryGetValue(keys[i], out city);
                sortedCities.Add(keys[i], city);
            }

            return sortedCities;
        }

        public static bool doubleEquals(double val1, double val2)
        {
            double difference = Math.Abs(val1 * .00001);

            // Compare the values
            // The output to the console indicates that the two values are equal
            if (Math.Abs(val1 - val2) <= difference) return true;
            else return false;            
        }

        public static bool exportDatasetToCSV(List<String> columns, List<List<String>> values)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "Comma-separated values file (*.csv)|*.csv";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Stream myStream;
                    if ((myStream = saveFileDialog.OpenFile()) != null)
                    {
                        StreamWriter streamWriter = new StreamWriter(myStream);

                        for (int i = 0; i < columns.Count; i++)
                        {
                            streamWriter.Write(columns[i]);

                            if (i < columns.Count - 1) streamWriter.Write(";");
                        }

                        streamWriter.WriteLine();

                        for (int i = 0; i < values.Count; i++)
                        {
                            for (int j = 0; j < values[i].Count; j++)
                            {
                                streamWriter.Write(values[i][j]);

                                if (j < values[i].Count - 1) streamWriter.Write(";");
                            }

                            if (i < values.Count - 1) streamWriter.WriteLine();
                        }

                        streamWriter.Flush();
                        streamWriter.Close();
                        myStream.Close();                        
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

/*
var file = @"C:\myOutput.csv";

using (var stream = File.CreateText(file))
{
    for (int i = 0; i < reader.Count(); i++)
    {
        string first = reader[i].ToString();
        string second = image.ToString();
        string csvRow = string.Format("{0},{1}", first, second);

        stream.WriteLine(csvRow);
    }
}
*/
