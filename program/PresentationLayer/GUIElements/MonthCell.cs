using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.GUIElements
{
    /// <summary>
    /// Extended cell for month in DataGridView.
    /// </summary>
    public class MonthCell : DataGridViewTextBoxCell
    {
        // Temperature value.
        private double cellValue = 0;

        // Measure tag used in cell.
        private String measureTag = "";

        public MonthCell()
        {
        }

        public double CellValue
        {
            get
            {
                return cellValue;
            }
            set
            {
                cellValue = value;
            }
        }
        
        public String MeasureTag
        {
            get
            {
                return measureTag;
            }
            set
            {
                measureTag = value;
            }
        }
        
        /// <summary>
        /// Get displayed text for cell.
        /// </summary>
        /// <returns></returns>
        public String getText()
        {
            return "" + cellValue + " " + measureTag;
        }
    }
}
