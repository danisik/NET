using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.GUIElements
{
    /// <summary>
    /// Class extending row in DataGridView.
    /// </summary>
    public class DataGridViewRowWithId : DataGridViewRow
    {
        // ID of dataset row.
        private int id;

        public DataGridViewRowWithId(int id)
        {
            this.id = id;
        }

        public int Id
        {
            get
            {
                return id;
            }
        }
    }
}
