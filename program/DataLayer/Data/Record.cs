using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Data
{
    public class Record
    {
        private int id;
        private City city;
        private double january;
        private double february;
        private double march;
        private double april;
        private double may;
        private double june;
        private double july;
        private double august;
        private double september;
        private double october;
        private double november;
        private double december;
        private int order;

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
