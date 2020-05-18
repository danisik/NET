using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DataLayer.Utils
{
    /// <summary>
    /// Class containing utilities.
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// Display message box.
        /// </summary>
        /// <param name="message"> Message to be displayed.</param>
        /// <param name="appName"> Name of this application. </param>
        /// <param name="buttons"> List of buttons. </param>
        /// <param name="icon"> MessageBoxIcon. </param>
        /// <returns> Result from messagebox. </returns>
        public static DialogResult displayMessageBox(string message, String appName, MessageBoxButtons buttons, MessageBoxIcon icon)
        { 
            return MessageBox.Show(message, appName, buttons, icon);
        }

        /// <summary>
        /// Display error message.
        /// </summary>
        /// <param name="errorMessage"> Error message. </param>
        /// <param name="appName"> Name of this application. </param>
        /// <returns> Result from messagebox. </returns>
        public static DialogResult displayErrorMessageBox(string errorMessage, String appName)
        {
            return displayMessageBox(errorMessage, appName, new MessageBoxButtons { }, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Display info message.
        /// </summary>
        /// <param name="infoMessage"> Info message. </param>
        /// <param name="appName"> Name of this application. </param>
        /// <returns> Result from messagebox. </returns>
        public static DialogResult displayInfoMessageBox(string infoMessage, String appName)
        {
            return displayMessageBox(infoMessage, appName, new MessageBoxButtons { }, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Display warning message.
        /// </summary>
        /// <param name="infoMessage"> Info message. </param>
        /// <param name="appName"> Name of this application. </param>
        /// <returns> Result from messagebox. </returns>
        public static DialogResult displayWarningMessageBox(string infoMessage, String appName)
        {
            return displayMessageBox(infoMessage, appName, new MessageBoxButtons { }, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Display info message with buttons.
        /// </summary>
        /// <param name="infoMessage"> Info message. </param>
        /// <param name="appName"> Name of this application. </param>
        /// <param name="buttons"> List of buttons. </param>
        /// <returns> Result from messagebox. </returns>
        public static DialogResult displayInfoMessageBoxWithButton(string infoMessage, String appName, MessageBoxButtons buttons)
        {
            return displayMessageBox(infoMessage, appName, buttons, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Sort Map of cities by their name.
        /// </summary>
        /// <param name="unsortedCities"> Map of unsorted cities. </param>
        /// <returns> Map of sorted cities. </returns>
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

        /// <summary>
        /// Check if two double values are equal.
        /// </summary>
        /// <param name="val1"> Double value 1. </param>
        /// <param name="val2"> Double value 2. </param>
        /// <returns> True if both values are equal, false if not. </returns>
        public static bool doubleEquals(double val1, double val2)
        {
            double difference = Math.Abs(val1 * .00001);

            // Compare the values
            // The output to the console indicates that the two values are equal
            if (Math.Abs(val1 - val2) <= difference) return true;
            else return false;            
        }

        /// <summary>
        /// Get average value from list of double values.
        /// </summary>
        /// <param name="values"> List of values. </param>
        /// <returns> Average value. </returns>
        public static double getAverageValue(List<double> values)
        {
            double averageValue = 0;

            foreach (double value in values)
            {
                averageValue += value;
            }

            averageValue /= values.Count;
            averageValue = Math.Round(averageValue, 2);

            return averageValue;
        }

        /// <summary>
        /// Export dataset's columns to CSV.
        /// </summary>
        /// <param name="columns"> List of columns. </param>
        /// <param name="values"> List of list values.</param>
        /// <returns></returns>
        public static bool exportDatasetToCSV(List<String> columns, List<List<String>> values)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "Comma-separated values file (*.csv)|*.csv";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                DialogResult result = saveFileDialog.ShowDialog();

                if (result == DialogResult.OK)
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
                else
                {
                    return false;
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
