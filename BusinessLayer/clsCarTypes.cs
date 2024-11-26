using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public  class clsCarTypes
    {

        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;

        public int CarTypeID { get; set; }
        public string TypeName { get; set; }

        public int CreatedByUserID { get; set; }


       public  clsCarTypes() { 
        
            this.CarTypeID = -1;
            this.TypeName = "";
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;

        }
        private clsCarTypes(int  CarTypeID, string TypeName , int CreatedByUserID)
        {
            this.CarTypeID = CarTypeID;
            this.TypeName = TypeName;
            this.CreatedByUserID = CreatedByUserID;
            Mode = enMode.Update;
        }
        private bool _AddNewCarType()
        {

            this.CarTypeID = clsDataCarTypes.AddNewCarType
            (this.TypeName, this.CreatedByUserID);

            return (this.CarTypeID != -1);
        }
        private bool _UpdateCarType()
        {

            return clsDataCarTypes.UpdateCarTypeInfoByCarTypeID
            (this.CarTypeID, this.TypeName, this.CreatedByUserID );

        }
        public static clsCarTypes GetCarTypeInfoByID(int CarTypeID)
        {
            string TypeName = ""; int CreatedByUserID = -1;
            bool IsFound = clsDataCarTypes.GetCarTypeByID
           (CarTypeID, ref TypeName, ref CreatedByUserID);

            if (IsFound)
                return new clsCarTypes(CarTypeID, TypeName, CreatedByUserID);
            else
                return null;
        }
        public static clsCarTypes GetCarTypeInfoByTypeName(string  TypeName)
        {
            int CarTypeID = -1; int CreatedByUserID = -1;
            bool IsFound = clsDataCarTypes.GetCarTypeByTypeName
           (ref CarTypeID,  TypeName, ref CreatedByUserID);

            if (IsFound)
                return new clsCarTypes(CarTypeID, TypeName, CreatedByUserID);
            else
                return null;
        }
        public static bool DeleteCarTypeID(int CarTypeID)
        {

            return clsDataCarTypes.DeleteCarType(CarTypeID);
        }
        public static bool IsCarTypeExistByID(int CarTypeID)
        {

            return clsDataCarTypes.IsCarTypeExistByID (CarTypeID);
        }
        public static DataTable GetAllByCarType()
        {

            return clsDataCarTypes.GetAllByCarType();
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCarType())
                    {

                        Mode = enMode.AddNew;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateCarType();

            }

            return false;
        }
    }
}
