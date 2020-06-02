using System;
using System.Windows.Forms;

namespace PresentationLayer.GUIElements
{    
    /// <summary>
    /// Extended cell for city in DataGridView.
    /// </summary>
    public class CityCell : DataGridViewComboBoxCell
    {
        // Name of selected city.
        private String cityName = "";

        public String CityName
        {
            get
            {
                return cityName;
            }
            set
            {
                cityName = value;
            }
        }
    }
}
