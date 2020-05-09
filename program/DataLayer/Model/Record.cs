using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Model
{
    /// <summary>
    /// Class representing record in database.
    /// </summary>
    public class Record
    {
        // ID of record.
        private int id;

        // City.
        private City city;

        // Temperature in january.
        private double january;

        // Temperature in february.
        private double february;

        // Temperature in march.
        private double march;

        // Temperature in april.
        private double april;

        // Temperature in may.
        private double may;

        // Temperature in june.
        private double june;

        // Temperature in july.
        private double july;

        // Temperature in august.
        private double august;

        // Temperature in september.
        private double september;

        // Temperature in october.
        private double october;

        // Temperature in november.
        private double november;

        // Temperature in december.
        private double december;

        // Record order in dataset.
        private int order;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"> ID of record. </param>
        /// <param name="city"> City. </param>
        /// <param name="january"> Temperature in january. </param>
        /// <param name="february"> Temperature in february. </param>
        /// <param name="march"> Temperature in march. </param>
        /// <param name="april"> Temperature in april. </param>
        /// <param name="may"> Temperature in may. </param>
        /// <param name="june"> Temperature in june. </param>
        /// <param name="july"> Temperature in july. </param>
        /// <param name="august"> Temperature in august. </param>
        /// <param name="september"> Temperature in september. </param>
        /// <param name="october"> Temperature in october. </param>
        /// <param name="november"> Temperature in november. </param>
        /// <param name="december"> Temperature in december. </param>
        /// <param name="order"> Record order in dataset. </param>
        public Record(int id, City city, double january, double february, double march, double april, double may,
            double june, double july, double august, double september, double october, double november, double december, int order)
        {
            this.id = id;
            this.city = city;
            this.january = january;
            this.february = february;
            this.march = march;
            this.april = april;
            this.may = may;
            this.june = june;
            this.july = july;
            this.august = august;
            this.september = september;
            this.october = october;
            this.november = november;
            this.december = december;
            this.order = order;
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public City City
        {
            get
            {
                return city;
            }
        }

        public double January
        {
            get
            {
                return january;
            }
        }

        public double February
        {
            get
            {
                return february;
            }
        }

        public double March
        {
            get
            {
                return march;
            }
        }

        public double April
        {
            get
            {
                return april;
            }
        }

        public double May
        {
            get
            {
                return may;
            }
        }

        public double June
        {
            get
            {
                return june;
            }
        }

        public double July
        {
            get
            {
                return july;
            }
        }

        public double August
        {
            get
            {
                return august;
            }
        }

        public double September
        {
            get
            {
                return september;
            }
        }

        public double October
        {
            get
            {
                return october;
            }
        }

        public double November
        {
            get
            {
                return november;
            }
        }

        public double December
        {
            get
            {
                return december;
            }
        }

        public int Order
        {
            get
            {
                return order;
            }
        }

        /// <summary>
        /// Get all month values.
        /// </summary>
        /// <returns> List of temperatures in every month. </returns>
        public List<double> getMonths()
        {
            List<double> months = new List<double>();

            months.Add(january);
            months.Add(february);
            months.Add(march);
            months.Add(april);
            months.Add(may);
            months.Add(june);
            months.Add(july);
            months.Add(august);
            months.Add(september);
            months.Add(october);
            months.Add(november);
            months.Add(december);

            return months;
        }
    }
}
