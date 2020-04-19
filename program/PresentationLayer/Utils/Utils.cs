using DataLayer.Data;
using DataLayer.Model;
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
        public static DialogResult displayMessageBox(string errorMessage, String appName, MessageBoxButtons buttons, MessageBoxIcon icon)
        { 
            return MessageBox.Show(errorMessage, appName, buttons, icon);
        }

        public static DialogResult displayErrorMessageBox(string errorMessage, String appName)
        {
            return displayMessageBox(errorMessage, appName, new MessageBoxButtons { }, MessageBoxIcon.Error);
        }

        public static DialogResult displayInfoMessageBox(string infoMessage, String appName)
        {
            return displayMessageBox(infoMessage, appName, new MessageBoxButtons { }, MessageBoxIcon.Information);
        }

        public static DialogResult displayWarningMessageBox(string infoMessage, String appName)
        {
            return displayMessageBox(infoMessage, appName, new MessageBoxButtons { }, MessageBoxIcon.Warning);
        }

        public static DialogResult displayInfoMessageBoxWithButton(string infoMessage, String appName, MessageBoxButtons buttons)
        {
            return displayMessageBox(infoMessage, appName, buttons, MessageBoxIcon.Information);
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
