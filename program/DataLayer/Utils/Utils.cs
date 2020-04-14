using DataLayer.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataLayer.Utils
{
    public class Utils
    {
        public static void displayMessageBox(string errorMessage, String appName, MessageBoxButtons buttons,
            MessageBoxIcon icon, DataGridViewCellValidatingEventArgs newValue)
        {
            MessageBox.Show(errorMessage, appName, buttons, icon);

            if (newValue != null) newValue.Cancel = true;
        }

        public static void displayErrorMessageBox(string errorMessage, String appName, DataGridViewCellValidatingEventArgs newValue)
        {
            displayMessageBox(errorMessage, appName, new MessageBoxButtons { }, MessageBoxIcon.Error, newValue);
        }

        public static void displayInfoMessageBox(string infoMessage, String appName)
        {
            displayMessageBox(infoMessage, appName, new MessageBoxButtons { }, MessageBoxIcon.Information, null);
        }

        public static void displayWarningMessageBox(string infoMessage, String appName)
        {
            displayMessageBox(infoMessage, appName, new MessageBoxButtons { }, MessageBoxIcon.Warning, null);
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
    }
}
