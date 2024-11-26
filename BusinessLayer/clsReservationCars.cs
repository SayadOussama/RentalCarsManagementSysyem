using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public  class clsReservationCars
    {
        public enum enMode { AddNew = 1, Update = 2 }

        public enMode Mode = enMode.AddNew;
        public int ReservationID { get; set; }
        public int CarSelectedID { get; set; }
        public int ClientID { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime DateToCheckOut { get; set; }
        public DateTime DateToCheckIn { get; set; }
        public int KLMTSpend { get; set; }
        public decimal TotalRentalFee { get; set; }
        public decimal DamageCostfee { get; set; }

        public string Note {  get; set; }
        public bool CarIsReturn { get; set; }
        public int CreatedByUserID { get; set; }
        public clsPerson _PersonInfo;
        public clsClients _ClientInfo;
        public clsCarsContainer _CarContainer;
        public clsReservationCars()
        {
            this.ReservationID = -1; 
            this.CarSelectedID = -1;
            this.ClientID = -1;
            this.ReservationDate = DateTime.MinValue;
            this.DateToCheckOut = DateTime.MinValue;
            this.DateToCheckIn = DateTime.MinValue;
            this.KLMTSpend = -1;
            this.TotalRentalFee = -1;
            this.DamageCostfee = -1;
            this.Note = "";
            this.CarIsReturn = false;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;

        }
        private clsReservationCars(int ReservationID , int CarSelectedID , int ClientID, DateTime ReservationDate , DateTime DateToCheckOut
            , DateTime DateToCheckIn ,
                int KLMTSpend ,decimal TotalRentalFee , decimal DamageCostfee , string Note ,bool CarIsReturn , int CreatedByUserID)
        {
            this.ReservationID = ReservationID;
            this.CarSelectedID = CarSelectedID;
            this.ClientID = ClientID;
            this.ReservationDate = ReservationDate;
            this.DateToCheckOut = DateToCheckOut;
            this.DateToCheckIn = DateToCheckIn;
            this.KLMTSpend = KLMTSpend;
            this.TotalRentalFee =TotalRentalFee;
            this.DamageCostfee =DamageCostfee;
            this.Note = Note;
            this.CarIsReturn = CarIsReturn;
            this.CreatedByUserID =CreatedByUserID;
            Mode = enMode.Update;
            this._ClientInfo = clsClients.GetClientInfoByClientID(this.ClientID);
            this._PersonInfo = clsPerson.GetPersonInfoByPersonID(this._ClientInfo.PersonID);
            this._CarContainer = clsCarsContainer.GetCarInfoByCarID(this.CarSelectedID);

        }
        private bool _AddNewReservationCar()
        {

            this.ReservationID = clsDataReservationCars.AddNewReservationCar
            (this.CarSelectedID, this.ClientID, this.ReservationDate, this.DateToCheckOut, this.DateToCheckIn, this.KLMTSpend, this.TotalRentalFee, this.DamageCostfee, this.Note,this.CarIsReturn, this.CreatedByUserID);

            return this.ReservationID != -1;
        }
        private bool _UpdateReservationCar()
        {

            return clsDataReservationCars.UpdateReservationCar
            (this.ReservationID, this.CarSelectedID, this.ClientID, this.ReservationDate, this.DateToCheckOut, this.DateToCheckIn, this.KLMTSpend, this.TotalRentalFee, this.DamageCostfee, this.Note, this.CarIsReturn, this.CreatedByUserID );

        }

        public static clsReservationCars GetReservationCarInfoByID(int ReservationID)
        {
            int CarSelectedID = -1; int ClientID = -1; DateTime ReservationDate=DateTime.MinValue; DateTime DateToCheckOut = DateTime.MinValue;   DateTime DateToCheckIn =DateTime.MinValue; int KLMTSpend = -1; decimal TotalRentalFee = -1; decimal DamageCostfee = -1; string Note = ""; int CreatedByUserID = -1; bool CarIsReturn= false;
            bool IsFound = clsDataReservationCars.GetReservationCarByID
           (ReservationID, ref CarSelectedID, ref ClientID, ref ReservationDate, ref DateToCheckOut, ref DateToCheckIn, ref KLMTSpend, ref TotalRentalFee, ref DamageCostfee, ref Note,ref CarIsReturn , ref CreatedByUserID
           );
            if (IsFound)
                return new clsReservationCars(ReservationID, CarSelectedID, ClientID, ReservationDate, DateToCheckOut, DateToCheckIn, KLMTSpend, TotalRentalFee, DamageCostfee, Note,CarIsReturn, CreatedByUserID);
            else
                return null;
        }
        public static clsReservationCars GetReservationByClientID(int ClientID)
        {
            int CarSelectedID = -1;int ReservationID = -1; DateTime ReservationDate = DateTime.MinValue; DateTime DateToCheckOut = DateTime.MinValue; DateTime DateToCheckIn = DateTime.MinValue; int KLMTSpend = -1; decimal TotalRentalFee = -1; decimal DamageCostfee = -1; string Note = ""; int CreatedByUserID = -1;bool CarIsReturn = false;
            bool IsFound = clsDataReservationCars.GetReservationInfoByClientID
           (ref ReservationID, ref CarSelectedID,  ClientID, ref ReservationDate, ref DateToCheckOut, ref DateToCheckIn, ref KLMTSpend, ref TotalRentalFee, ref DamageCostfee, ref Note,ref CarIsReturn, ref CreatedByUserID
           );
            if (IsFound)
                return new clsReservationCars(ReservationID, CarSelectedID, ClientID, ReservationDate, DateToCheckOut, DateToCheckIn, KLMTSpend, TotalRentalFee, DamageCostfee, Note,CarIsReturn, CreatedByUserID);
            else
                return null;
        }
        public static clsReservationCars GetReservationByCarID(int CarSelectedID)
        {
             int ClientID=-1; int ReservationID = -1; DateTime ReservationDate = DateTime.MinValue; DateTime DateToCheckOut = DateTime.MinValue; DateTime DateToCheckIn = DateTime.MinValue; int KLMTSpend = -1; decimal TotalRentalFee = -1; decimal DamageCostfee = -1; string Note = ""; bool CarIsReturn = false; int CreatedByUserID = -1;
            bool IsFound = clsDataReservationCars.GetReservationInfoByCarID
           (ref ReservationID,  CarSelectedID, ref ClientID, ref ReservationDate, ref DateToCheckOut, ref DateToCheckIn, ref KLMTSpend, ref TotalRentalFee, ref DamageCostfee, ref Note, ref CarIsReturn ,ref CreatedByUserID
           );
            if (IsFound)
                return new clsReservationCars(ReservationID, CarSelectedID, ClientID, ReservationDate, DateToCheckOut, DateToCheckIn, KLMTSpend, TotalRentalFee, DamageCostfee, Note,CarIsReturn, CreatedByUserID);
            else
                return null;
        }
        public static bool DeleteReservation(int ReservationID)
        {

            return clsDataReservationCars.Delete(ReservationID);
        }
        public static bool IsExistReservationById(int ReservationID)
        {

            return clsDataReservationCars.IsReservationExistID(ReservationID);
        }
        public static DataTable GerAllReservationList()
        {

            return clsDataReservationCars.GetAllByReservations();
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewReservationCar())
                    {

                        Mode = enMode.AddNew;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateReservationCar();

            }

            return false;
        }
    }
}
