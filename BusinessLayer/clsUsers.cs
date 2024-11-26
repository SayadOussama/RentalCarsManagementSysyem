using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsUsers
    {
        public enum enMode { AddNew = 1, Update = 2 }

        public enMode Mode = enMode.AddNew;
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool IsActive { get; set; }

        //People Composition 
        public clsPerson _PersonInfo;

        public clsUsers()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.PassWord = "";
            this.IsActive = false;
            Mode = enMode.AddNew;

        }
        private clsUsers(int UserID, int PersonID, string UserName, string PassWord, bool IsActie)
        {

            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.PassWord = PassWord;
            this.IsActive = IsActie;
            _PersonInfo = clsPerson.GetPersonInfoByPersonID(PersonID);
            Mode = enMode.Update;
        }
        public static clsUsers GetFindUserInfoByUserID(int UserID)
        {
            int PersonID = -1; string UserName = ""; string PassWord = ""; bool IsActive = false;
            bool IsFound = clsDataUsers.GetFindUserInfoByUserID
           (UserID, ref PersonID, ref UserName, ref PassWord, ref IsActive);

            if (IsFound)
                return new clsUsers(UserID, PersonID, UserName, PassWord, IsActive);
            else
                return null;
        }

        public static clsUsers GetFindUserInfoByPersonID(int PersonID)
        {
            int UserID = -1; string UserName = ""; string PassWord = ""; bool IsActive = false;
            bool IsFound = clsDataUsers.GetFindUserInfoByPeronID
           (ref UserID, PersonID, ref UserName, ref PassWord, ref IsActive);

            if (IsFound)
                return new clsUsers(UserID, PersonID, UserName, PassWord, IsActive);
            else
                return null;
        }
        public static clsUsers GetFindUserInfoByUserNameAndPassWord(string UserName, string PassWord)
        {
            int UserID = -1; int PersonID = -1; bool IsActive = false;
            bool IsFound = clsDataUsers.GetUserInfoByUsernameAndPassword
           (UserName, PassWord, ref UserID, ref PersonID, ref IsActive);

            if (IsFound)
                return new clsUsers(UserID, PersonID, UserName, PassWord, IsActive);
            else
                return null;
        }
        private bool _AddNewUser()
        {

            this.UserID = clsDataUsers.AddNewUser
            (this.PersonID, this.UserName, this.PassWord, this.IsActive);

            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {

            return clsDataUsers.UpdateUser
            (this.UserID, this.PersonID, this.UserName, this.PassWord, this.IsActive);

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();

            }

            return false;
        }

        public static bool DeleteUserByID(int UserID)
        {

            return clsDataUsers.DeleteUserByUserID(UserID);
        }
        public static DataTable GetAllUsers()
        {

            return clsDataUsers.GetAllUsers();
        }
        public static bool IsUserExistByID(int UserID)
        {

            return clsDataUsers.IsUserExistByUserID(UserID);
        }

        public static bool IsUserExistByPersonID(int PersonID)
        {

            return clsDataUsers.IsUserExistByPersonID(PersonID);
        }



        public static bool IsUserExistByUserName(string UserName)
        {
            return clsDataUsers.IsUserExistByUserName(UserName);
        }
        public static bool IsUserPassWordExist(int UserID, string PassWord)
        {
            return clsDataUsers.IsUserExistByPassword(UserID, PassWord);
        }
    }
}
