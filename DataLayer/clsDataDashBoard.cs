using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public  class clsDataDashBoard
    {

        public static int GetTotalCars()

        {
            //** You Must declare var string To Loaded With First Name You Looking For

            int TotalCars = -1;

            //SqlConnection they there Objective Doing the Connectivity with Data Base


            //the Necessary information To Get Access To Database 
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            //Write Your Query                                          //the parametrize (will Looking For)

            string Query = @" select TotalCars = Count(CarsContainer.CarID)
                               from CarsContainer ;";


            //Prepare To Execute Comment 

            SqlCommand command = new SqlCommand(Query, connection);

            

            try
            {
                //Open the Gate to Get Access to Database 
                connection.Open();

                //**
                //**We Use Here Execute Scalar
                //**

                object Result = command.ExecuteScalar();

                if (Result != null)//IF Find 
                {
                    TotalCars = int.Parse(Result.ToString());
                }
                else//If Not Find
                {
                    TotalCars = -1;
                }

                connection.Close();

            }
            //Must Apply catch Because if the Data base Get ERROR Will Display it on the Screen 
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);
            }
            //IMPORTANT:
            //Return First name Must Be At The End of function 
            return TotalCars;

        }

        public static int GetTotalCarsAvailable()

        {
            //** You Must declare var string To Loaded With First Name You Looking For

            int TotalCarsAvailable = -1;

            //SqlConnection they there Objective Doing the Connectivity with Data Base


            //the Necessary information To Get Access To Database 
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            //Write Your Query                                          //the parametrize (will Looking For)

            string Query = @" select TotalCarsAvilable = Count(CarsContainer.CarID)
from CarsContainer where CarsContainer.IsAvailable= 1  ;";


            //Prepare To Execute Comment 

            SqlCommand command = new SqlCommand(Query, connection);



            try
            {
                //Open the Gate to Get Access to Database 
                connection.Open();

                //**
                //**We Use Here Execute Scalar
                //**

                object Result = command.ExecuteScalar();

                if (Result != null)//IF Find 
                {
                    TotalCarsAvailable = int.Parse(Result.ToString());
                }
                else//If Not Find
                {
                    TotalCarsAvailable = -1;
                }

                connection.Close();

            }
            //Must Apply catch Because if the Data base Get ERROR Will Display it on the Screen 
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);
            }
            //IMPORTANT:
            //Return First name Must Be At The End of function 
            return TotalCarsAvailable;

        }
        public static int GetTotalCarsNotAvailable()

        {
            //** You Must declare var string To Loaded With First Name You Looking For

            int TotalCarsNotAvailable = -1;

            //SqlConnection they there Objective Doing the Connectivity with Data Base


            //the Necessary information To Get Access To Database 
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            //Write Your Query                                          //the parametrize (will Looking For)

            string Query = @" select TotalCarsAvilable = Count(CarsContainer.CarID)
from CarsContainer where CarsContainer.IsAvailable= 0  ;";


            //Prepare To Execute Comment 

            SqlCommand command = new SqlCommand(Query, connection);



            try
            {
                //Open the Gate to Get Access to Database 
                connection.Open();

                //**
                //**We Use Here Execute Scalar
                //**

                object Result = command.ExecuteScalar();

                if (Result != null)//IF Find 
                {
                    TotalCarsNotAvailable = int.Parse(Result.ToString());
                }
                else//If Not Find
                {
                    TotalCarsNotAvailable = -1;
                }

                connection.Close();

            }
            //Must Apply catch Because if the Data base Get ERROR Will Display it on the Screen 
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);
            }
            //IMPORTANT:
            //Return First name Must Be At The End of function 
            return TotalCarsNotAvailable;

        }
        public static int GetTotalOfClients()

        {
            //** You Must declare var string To Loaded With First Name You Looking For

            int TotalOfClients = -1;

            //SqlConnection they there Objective Doing the Connectivity with Data Base


            //the Necessary information To Get Access To Database 
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            //Write Your Query                                          //the parametrize (will Looking For)

            string Query = @" select TotalClient = Count(Clients.ClientID)
                              from Clients  ;";


            //Prepare To Execute Comment 

            SqlCommand command = new SqlCommand(Query, connection);



            try
            {
                //Open the Gate to Get Access to Database 
                connection.Open();

                //**
                //**We Use Here Execute Scalar
                //**

                object Result = command.ExecuteScalar();

                if (Result != null)//IF Find 
                {
                    TotalOfClients = int.Parse(Result.ToString());
                }
                else//If Not Find
                {
                    TotalOfClients = -1;
                }

                connection.Close();

            }
            //Must Apply catch Because if the Data base Get ERROR Will Display it on the Screen 
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);
            }
            //IMPORTANT:
            //Return First name Must Be At The End of function 
            return TotalOfClients;

        }
    }
}
