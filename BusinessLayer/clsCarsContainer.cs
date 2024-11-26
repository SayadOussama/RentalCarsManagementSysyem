using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
    public  class clsCarsContainer
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;

        public int CarID { get; set; }
        public string CarName { get; set; }
        public string CarModel {  get; set; }
        public int CarType { get; set; }

        public string EngineModel { get; set; }
        public string  CarPlateNumber { get; set; }
        public decimal RentalCarPrice { get; set; }

        public string Color {  get; set; }
        public int  DoorsNumber { get; set; }
        public string ImagePath { get; set; }

        public int CurrentKLMT { get; set; }
        public bool IsAvalible { get; set; }
        public int ClientTakenID { get; set; }
        public int CreatedByUserID { get; set; }
        public clsClients _TakenClientInfo { get; set; }
        //Car Type Info Class 
        public clsCarTypes _CarTypeInfo;
        public clsCarsContainer()
        {
            this.CarID = -1;
            this.CarName = "";
            this.CarModel = "";
            this.CarType = -1;
            this.EngineModel = "";
            this.CarPlateNumber = "";
            this.RentalCarPrice = -1;
            this.Color = "";
            this.DoorsNumber = -1;
            this.ImagePath = "";
            this.CurrentKLMT = -1;
            this.IsAvalible = false;
            this.ClientTakenID = -1;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;
           
        }
        private clsCarsContainer(int CarID,string  CarName, string  CarModel,int CarType,string  EngineModel,string CarPlateNumber,decimal RentalCarPrice,string  Color,int  DoorsNumber,string  ImagePath,int CurrentKLMT,bool IsAvailable,int ClientTakenID,int CreatedByUserID)
        {
            this.CarID = CarID;
            this.CarName = CarName;
            this.CarModel = CarModel;
            this.CarType = CarType;
            this.EngineModel = EngineModel;
            this.CarPlateNumber =CarPlateNumber;
            this.RentalCarPrice= RentalCarPrice;
            this.Color = Color;
            this.DoorsNumber = DoorsNumber;
            this.ImagePath = ImagePath;
            this.CurrentKLMT = CurrentKLMT;
            this.IsAvalible = IsAvailable;
            this.ClientTakenID = ClientTakenID;
            this.CreatedByUserID = CreatedByUserID;
            Mode = enMode.Update;
            if (ClientTakenID != -1)
               this._TakenClientInfo= clsClients.GetClientInfoByClientID(ClientTakenID);


            this._CarTypeInfo = clsCarTypes.GetCarTypeInfoByID(this.CarType);



        }
        public static clsCarsContainer GetCarInfoByCarID(int CarID)
        {
            string CarName = ""; string CarModel = ""; int CarType = -1; string EngineModel = "";string CarPlateNumber = ""; decimal RentalCarPrice = -1; string Color = ""; int DoorsNumber = -1; string ImagePath = ""; int CurrentKLMT = -1; bool IsAvailable = false; int ClientTakenID = -1; int CreatedByUserID = -1;
            bool IsFound = clsDataCarsContainer.GetCarInfoByID
           (CarID, ref CarName, ref CarModel, ref CarType, ref EngineModel, ref CarPlateNumber , ref RentalCarPrice, ref Color, ref DoorsNumber, ref ImagePath, ref CurrentKLMT, ref IsAvailable, ref ClientTakenID, ref CreatedByUserID
           );
            if (IsFound)
                return new clsCarsContainer(CarID, CarName, CarModel, CarType, EngineModel, CarPlateNumber,  RentalCarPrice, Color, DoorsNumber, ImagePath, CurrentKLMT, IsAvailable, ClientTakenID, CreatedByUserID);
            else
                return null;
        }
        public static clsCarsContainer GetCarInfoByCarPlateNumber(string CarPlateNumber)
        {
            int CarID = -1;
            string CarName = ""; string CarModel = ""; int CarType = -1; string EngineModel = ""; decimal RentalCarPrice = -1; string Color = ""; int DoorsNumber = -1; string ImagePath = ""; int CurrentKLMT = -1; bool IsAvailable = false; int ClientTakenID = -1; int CreatedByUserID = -1;
            bool IsFound = clsDataCarsContainer.GetCarInfoByCarPlateNumber
           (ref CarID, ref CarName, ref CarModel, ref CarType, ref EngineModel, CarPlateNumber, ref RentalCarPrice, ref Color, ref DoorsNumber, ref ImagePath, ref CurrentKLMT, ref IsAvailable, ref ClientTakenID, ref CreatedByUserID
           );
            if (IsFound)
                return new clsCarsContainer(CarID, CarName, CarModel, CarType, EngineModel,CarPlateNumber, RentalCarPrice, Color, DoorsNumber, ImagePath, CurrentKLMT, IsAvailable, ClientTakenID, CreatedByUserID);
            else
                return null;
        }
        public  bool DeleteCarInfo()
        {

            return clsDataCarsContainer.DeleteCar(this.CarID);
        }
        public static bool IsCarExistByID(int CarID)
        {

            return clsDataCarsContainer.IsCarExistByCarID(CarID);
        }
        public static bool IsCarExistByCarPlateNumber(string CarPlateCarNumber)
        {

            return clsDataCarsContainer.IsCarExistByCarPlateNumber(CarPlateCarNumber);
        }
        private bool _AddNewCar()
        {

            this.CarID = clsDataCarsContainer.AddNewCar
            (this.CarName, this.CarModel, this.CarType, this.EngineModel, this.CarPlateNumber, this.RentalCarPrice, this.Color, this.DoorsNumber, this.ImagePath, this.CurrentKLMT, this.IsAvalible, this.ClientTakenID, this.CreatedByUserID);

            return (this.CarID != -1);
        }

        private bool _UpdatesCar()
        {

            return clsDataCarsContainer.UpdateCarInfo
            (this.CarID, this.CarName, this.CarModel, this.CarType, this.EngineModel, this.CarPlateNumber, this.RentalCarPrice, this.Color, this.DoorsNumber, this.ImagePath, this.CurrentKLMT, this.IsAvalible, this.ClientTakenID, this.CreatedByUserID);

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if ((_AddNewCar()))
                    {

                        Mode = enMode.AddNew;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatesCar();

            }

            return false;
        }
        public static DataTable GetCarContainerList()
        {
            return clsDataCarsContainer.GetAllByCarModel();
        }
    }
   
}
