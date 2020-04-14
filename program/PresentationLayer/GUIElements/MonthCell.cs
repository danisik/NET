using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.GUIElements
{
    public class MonthCell : DataGridViewTextBoxCell
    {
        private double cellValue = 0;
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
        
        public String getText()
        {
            return "" + cellValue + " " + measureTag;
        }
    }
}
