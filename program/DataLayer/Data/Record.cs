using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Data
{
    public class Record
    {
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

        public Record(City city, double january, double february, double march, double april, double may,
            double june, double july, double august, double september, double october, double november, double december, int order)
        {
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
        }

        public City City
        {
            get
            {
                return city;
            }
        }

        public Double January
        {
            get
            {
                return january;
            }
        }

        public Double February
        {
            get
            {
                return February;
            }
        }

        public Double March
        {
            get
            {
                return march;
            }
        }

        public Double April
        {
            get
            {
                return April;
            }
        }

        public Double May
        {
            get
            {
                return may;
            }
        }

        public Double June
        {
            get
            {
                return june;
            }
        }

        public Double July
        {
            get
            {
                return july;
            }
        }

        public Double August
        {
            get
            {
                return august;
            }
        }

        public Double September
        {
            get
            {
                return september;
            }
        }

        public Double October
        {
            get
            {
                return october;
            }
        }

        public Double November
        {
            get
            {
                return november;
            }
        }

        public Double December
        {
            get
            {
                return December;
            }
        }

        public int Order
        {
            get
            {
                return order;
            }
        }

        public List<Double> getMonths()
        {
            List<Double> months = new List<Double>();

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
