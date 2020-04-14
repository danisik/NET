using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.GUIElements
{
    public class DataGridViewRowWithId : DataGridViewRow
    {
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
