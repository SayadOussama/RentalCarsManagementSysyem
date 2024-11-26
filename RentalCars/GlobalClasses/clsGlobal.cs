using BusinessLayer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCars.GlobalClasses
{
    internal static  class clsGlobal
    {
        public static clsUsers CurrentUser;
        public static bool RememberUsernameAndPassword(string Username, string Password)
        {


            try
            {
                string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\RentalCars";
                string NameValue = "UserName/Password";
                using (RegistryKey BaseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey Key = BaseKey.OpenSubKey(keyPath, true))
                    {
                        string value = Username + "#//#" + Password;
                        if (Key == null)
                        {
                            RegistryKey Key1 = BaseKey.CreateSubKey(keyPath);
                            Key1.SetValue(NameValue, value);
                            return true;
                        }
                        Key.SetValue(NameValue, value);
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }
        public static bool GetStoredCredential(ref string Username, ref string Password)
        {

            try
            {
                string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\RentalCars";
                string NameValue = "UserName/Password";
                using (RegistryKey BaseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey Key = BaseKey.OpenSubKey(keyPath, true))
                    {
                        if (Key == null)
                            return false;
                        object Value = Key.GetValue(NameValue); // 7timal fl badya maykonch l subkey "UserName/PassWord"

                        if (Value != null)
                        {
                            object[] Result = Value.ToString().Split(new string[] { "#//#" }, StringSplitOptions.None);
                            Username = (string)Result[0];
                            Password = (string)Result[1];
                        }
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }
        //Save Error Message in EventLog 

        //Run Application as Adminstrator
        public static void GetSaveErrorMessage(string Message, EventLogEntryType LogType, string sourceName = "GYMmanagement")
        {
            //// Specify the source name for the event log
            //string sourceName = "DVLDApplication";
            ////ProjectApplication Name 

            // Create the event source if it does not exist
            if (!EventLog.SourceExists(sourceName))
            {                                           //we Save Envet In Application Section 
                EventLog.CreateEventSource(sourceName, "Application");

            }


            //// Log an information event            //Type Message in Event Viewer 
            //EventLog.WriteEntry(sourceName, "This is My information :-).", EventLogEntryType.Information);

            //// Log a Warning event
            //EventLog.WriteEntry(sourceName, "This My Warning :-)", EventLogEntryType.Warning);

            // Log an Error event

            EventLog.WriteEntry(sourceName, Message, LogType);



        }
    }
}
