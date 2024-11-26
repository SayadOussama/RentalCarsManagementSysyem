using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsPerson
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;
        public int PersonID { set; get; }
        public string NationalNO { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string FullName { get { return LastName + " " + FirstName; } }
        public DateTime BirthDay { set; get; }
        public byte Gender { set; get; }
        public string PhoneNumber { set; get; }

        public string address { get; set; }

        public string Email { get; set; }

        public int NationalCountryID { get; set; }

        private string _ImagePath;
        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }
        //add Countries class Here clsCountries _Countries
        public clsCountries _CountryInfo;
        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNO = "";
            this.FirstName = "";
            this.LastName = "";
            this.BirthDay = DateTime.MinValue;
            this.Gender = 99;
            this.PhoneNumber = "";
            this.address = "";
            this.NationalCountryID = -1;
            this.ImagePath = "";
            Mode = enMode.AddNew;
        }
        private clsPerson(int PersonID, string NationalNO, string FirstName, string LastName, DateTime BirthDay, byte Gender, string PhoneNumber, string Address, string Email, int NationalCountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNO = NationalNO;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BirthDay = BirthDay;
            this.Gender = Gender;
            this.PhoneNumber = PhoneNumber;
            this.address = Address;
            this.Email = Email;
            this.NationalCountryID = NationalCountryID;
            this.ImagePath = ImagePath;
            //add Composition of Countries Class 
            _CountryInfo = clsCountries.FindCountryInfoByCountryID(NationalCountryID);
            Mode = enMode.Update;

        }
        public static clsPerson GetPersonInfoByPersonID(int PersonID)
        {
            string NationalNO = ""; string FirstName = ""; string LastName = ""; DateTime BirthDay = DateTime.MinValue; byte Gender = 99; string PhoneNumber = ""; string address = ""; string Email = ""; int NationalCountryID = -1; string ImagePath = "";
            bool IsFound = clsDataPeople.GetPersonInfoByPersonID
           (PersonID, ref NationalNO, ref FirstName, ref LastName, ref BirthDay, ref Gender, ref PhoneNumber, ref address, ref Email, ref NationalCountryID, ref ImagePath
           );
            if (IsFound)
                return new clsPerson(PersonID, NationalNO, FirstName, LastName, BirthDay, Gender, PhoneNumber, address, Email, NationalCountryID, ImagePath);
            else
                return null;
        }

        public static clsPerson GetPersonInfoByFirstName(string FirstName)
        {
            int PersonID = -1; string NationalNO = ""; string LastName = ""; DateTime BirthDay = DateTime.MinValue; byte Gender = 99; string PhoneNumber = ""; string address = ""; string Email = ""; int NationalCountryID = -1; string ImagePath = "";
            bool IsFound = clsDataPeople.GetPersonInfoByFirstName
           (ref PersonID, ref NationalNO, FirstName, ref LastName, ref BirthDay, ref Gender, ref PhoneNumber, ref address, ref Email, ref NationalCountryID, ref ImagePath
           );
            if (IsFound)
                return new clsPerson(PersonID, NationalNO, FirstName, LastName, BirthDay, Gender, PhoneNumber, address, Email, NationalCountryID, ImagePath);
            else
                return null;
        }
        public static clsPerson GetPersonInfoByLastName(string LastName)
        {
            int PersonID = -1; string NationalNO = ""; string FirstName = ""; DateTime BirthDay = DateTime.MinValue; byte Gender = 99; string PhoneNumber = ""; string address = ""; string Email = ""; int NationalCountryID = -1; string ImagePath = "";
            bool IsFound = clsDataPeople.GetPersonInfoByLastName
           (ref PersonID, ref NationalNO, ref FirstName, LastName, ref BirthDay, ref Gender, ref PhoneNumber, ref address, ref Email, ref NationalCountryID, ref ImagePath
           );
            if (IsFound)
                return new clsPerson(PersonID, NationalNO, FirstName, LastName, BirthDay, Gender, PhoneNumber, address, Email, NationalCountryID, ImagePath);
            else
                return null;
        }
        public static clsPerson GetPersonInfoByNationalNo(string NationalNO)
        {
            int PersonID = -1; string FirstName = ""; string LastName = ""; DateTime BirthDay = DateTime.MinValue; byte Gender = 99; string PhoneNumber = ""; string address = ""; string Email = ""; int NationalCountryID = -1; string ImagePath = "";
            bool IsFound = clsDataPeople.GetPersonInfoByNationalNo
           (ref PersonID, NationalNO, ref FirstName, ref LastName, ref BirthDay, ref Gender, ref PhoneNumber, ref address, ref Email, ref NationalCountryID, ref ImagePath
           );
            if (IsFound)
                return new clsPerson(PersonID, NationalNO, FirstName, LastName, BirthDay, Gender, PhoneNumber, address, Email, NationalCountryID, ImagePath);
            else
                return null;
        }
        private bool _AddNewAddNew()
        {

            this.PersonID = clsDataPeople.AddNewPersonID
            (this.NationalNO, this.FirstName, this.LastName, this.BirthDay, this.Gender, this.PhoneNumber, this.address, this.Email, this.NationalCountryID, this.ImagePath);

            return (this.PersonID != -1);
        }
        private bool _UpdatePersonInfo()
        {

            return clsDataPeople.UpdatePersonID
                (this.PersonID, this.NationalNO, this.FirstName, this.LastName, this.BirthDay, this.Gender, this.PhoneNumber, this.address, this.Email, this.NationalCountryID, this.ImagePath);


        }
        public  bool DeletePersonByPersonID(int PersonID)
        {
            return clsDataPeople.DeletePersonByID(PersonID);
        }
        public static bool IsPersonExistByPersonID(int PersonID)
        {
            return clsDataPeople.IsPersonExistByPersonID(PersonID);
        }
        public static bool IsPersonExistByNationalNo(string NationalNo)
        {
            return clsDataPeople.IsPersonExistByNationalNo(NationalNo);
        }
        public static DataTable GetPeopleList()
        {
            return clsDataPeople.GetAllProple();
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewAddNew())
                    {

                        Mode = enMode.AddNew;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePersonInfo();

            }

            return false;
        }
    }
}
