using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{

    public  class clsClients
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;



        public int ClientID {  get; set; }
        public int PersonID { get; set; }
        public int VehicalLicenseNumber { get; set; }
        public DateTime LicenseExpirationDate { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public int CreatedByUserID { get; set; }
        public clsPerson _PersonInfo;



        public clsClients()
        {
            this.ClientID = -1;
             this.PersonID = -1;
            this.VehicalLicenseNumber = -1;
            this.LicenseExpirationDate = DateTime.MinValue;
            this.AccountCreationDate = DateTime.MinValue;
            this.CreatedByUserID = -1;
            Mode =  enMode.AddNew;
          
        }
        private clsClients(int ClientID , int PersonID , int VehicalLicenseNumber ,  DateTime LicenseExpirationDate
            ,DateTime AccountCreationdate, int CreatedByUserID)
        {
            this.ClientID= ClientID;
            this.PersonID= PersonID;
            this.VehicalLicenseNumber= VehicalLicenseNumber;
            this.LicenseExpirationDate= LicenseExpirationDate;
            this.AccountCreationDate= AccountCreationdate;
            this.CreatedByUserID = CreatedByUserID;
            Mode = enMode.Update;
            this._PersonInfo = clsPerson.GetPersonInfoByPersonID(this.PersonID);
        }
        private bool _AddNewClientInfoByClientID()
        {

            this.ClientID = clsDataClients.AddNewClientByID
            (this.PersonID, this.VehicalLicenseNumber, this.LicenseExpirationDate, this.AccountCreationDate, this.CreatedByUserID);

            return (this.ClientID != -1);
        }
        private bool _UpdateClientInfoBy()
        {

            return clsDataClients.UpdateClientByClientID
            (this.ClientID, this.PersonID, this.VehicalLicenseNumber, this.LicenseExpirationDate, this.AccountCreationDate, this.CreatedByUserID );

        }
        public  bool DeleteClientID()
        {

            return clsDataClients.DeleteByID(this.ClientID);
        }
        public static clsClients GetClientInfoByClientID(int ClientID)
        {
            int PersonID = -1; int VehicalLicenseNumber = -1; DateTime LicenseExpirationDate= DateTime.MinValue; DateTime AccountCreationDate =DateTime.MinValue; int CreatedByUserID = -1;
            bool IsFound = clsDataClients.GetClientInfoByClientID
           (ClientID, ref PersonID, ref VehicalLicenseNumber, ref LicenseExpirationDate, ref AccountCreationDate, ref CreatedByUserID
           );
            if (IsFound)
                return new clsClients(ClientID, PersonID, VehicalLicenseNumber, LicenseExpirationDate, AccountCreationDate, CreatedByUserID);
            else
                return null;
        }
        public static clsClients GetClientInfoByPersonID(int PersonID)
        {
            int ClientID = -1; int VehicalLicenseNumber = -1; DateTime LicenseExpirationDate = DateTime.MinValue; DateTime AccountCreationDate = DateTime.MinValue; int CreatedByUserID = -1;
            bool IsFound = clsDataClients.GetClientInfoByPersonID
           (ref ClientID,  PersonID, ref VehicalLicenseNumber, ref LicenseExpirationDate, ref AccountCreationDate, ref CreatedByUserID
           );
            if (IsFound)
                return new clsClients(ClientID, PersonID, VehicalLicenseNumber, LicenseExpirationDate, AccountCreationDate, CreatedByUserID);
            else
                return null;
        }

        public static clsClients GetClientInfoByVehicalLicenseNumber(int VehicalLicenseNumber)
        {
            int ClientID = -1; int PersonID = -1; DateTime LicenseExpirationDate = DateTime.MinValue; DateTime AccountCreationDate = DateTime.MinValue; int CreatedByUserID = -1;
            bool IsFound = clsDataClients.GetClientInfoByVehicalLicenseNumber
           (ref ClientID, ref PersonID,  VehicalLicenseNumber, ref LicenseExpirationDate, ref AccountCreationDate, ref CreatedByUserID
           );
            if (IsFound)
                return new clsClients(ClientID, PersonID, VehicalLicenseNumber, LicenseExpirationDate, AccountCreationDate, CreatedByUserID);
            else
                return null;
        }
        public static bool IsClientByIDExist(int ClientID)
        {

            return clsDataClients.ClientExistByID(ClientID);
        }
        public static bool IsClientByPersonIDExist(int PersonID)
        {

            return clsDataClients.ClientExistByPersonID(PersonID);
        }
        public static bool IsClientByVehicalLicenseNumber(int VehicalLicenseNumber)
        {

            return clsDataClients.ClientExistByVehicalLicenseNumber(VehicalLicenseNumber);
        }
        public static DataTable GetAllClients()
        {

            return clsDataClients.GetAllCLients();
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewClientInfoByClientID())
                    {

                        Mode = enMode.AddNew;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateClientInfoBy();

            }

            return false;
        }


    }
}
