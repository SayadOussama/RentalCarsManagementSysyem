using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public  class clsCountries
    {
        enum enMode { AddNew = 1, Update = 2 }
        enMode Mode = enMode.AddNew;
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public clsCountries()
        {
            CountryID = -1;
            CountryName = "";
            Mode = enMode.AddNew;
        }
        private clsCountries(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }
        public static clsCountries FindCountryInfoByCountryID(int CountryID)
        {
            string CountryName = "";
            bool IsFound = clsDataCountries.GetFindCountryByCountryID
           (CountryID, ref CountryName);

            if (IsFound)
                return new clsCountries(CountryID, CountryName);
            else
                return null;
        }
        public static clsCountries FindCountryInfoByCountryName(string CountryName)
        {
            int CountryID = -1;
            bool IsFound = clsDataCountries.GetFindCountryByCountryName
           (ref CountryID, CountryName);

            if (IsFound)
                return new clsCountries(CountryID, CountryName);
            else
                return null;
        }
        public static DataTable GetAllCountriesList()
        {

            return clsDataCountries.GetAllByCountries();
        }
    }
}
