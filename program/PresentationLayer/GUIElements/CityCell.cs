using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.GUIElements
{    
    public class CityCell : DataGridViewComboBoxCell
    {
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
