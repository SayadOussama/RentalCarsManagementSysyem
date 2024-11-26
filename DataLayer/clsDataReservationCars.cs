using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsDataReservationCars
    {
        public static int AddNewReservationCar(int CarSelectedID, int ClientID, DateTime ReservationDate, DateTime DateToCheckOut, DateTime DateToCheckIn, int KLMTSpend, decimal TotalRentalFee, decimal DamageCostfee, string Note,bool CarIsReturn, int CreatedByUserID)
        {
            using (var Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (var command = new SqlCommand("SP_AddNewReservationCar", Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CarSelectedID", CarSelectedID);
                    command.Parameters.AddWithValue("@ClientID", ClientID);
                    command.Parameters.AddWithValue("@ReservationDate", ReservationDate);
                    command.Parameters.AddWithValue("@DateToCheckOut", DateToCheckOut);
                    command.Parameters.AddWithValue("@DateToCheckIn", DateToCheckIn);
                    command.Parameters.AddWithValue("@KLMTSpend", KLMTSpend);
                    command.Parameters.AddWithValue("@TotalRentalFee", TotalRentalFee);
                    if (DamageCostfee != -1 && DamageCostfee != null)
                        command.Parameters.AddWithValue("@DamageCostfee", DamageCostfee);
                    else
                        command.Parameters.AddWithValue("@DamageCostfee", System.DBNull.Value);
                    if (Note != "" && Note != null)
                        command.Parameters.AddWithValue("@Note", Note);
                    else
                        command.Parameters.AddWithValue("@Note", System.DBNull.Value);
                    command.Parameters.AddWithValue("@CarIsReturn", CarIsReturn);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    var outputIdParam = new SqlParameter("@NewReservationID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    }; command.Parameters.Add(outputIdParam);
                    Connection.Open();
                    command.ExecuteNonQuery();

                    return (int)outputIdParam.Value;
                }
            }
        }
        public static bool UpdateReservationCar(int ReservationID, int CarSelectedID, int ClientID, DateTime ReservationDate, DateTime DateToCheckOut, DateTime DateToCheckIn, int KLMTSpend, decimal TotalRentalFee, decimal DamageCostfee, string Note,bool CarIsReturn, int CreatedByUserID)
        {

            using (var Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_UpdateReservationCar", Connection))
            {
                {
                   
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ReservationID", ReservationID);
                    command.Parameters.AddWithValue("@CarSelectedID", CarSelectedID);
                    command.Parameters.AddWithValue("@ClientID", ClientID);
                    command.Parameters.AddWithValue("@ReservationDate", ReservationDate);
                    command.Parameters.AddWithValue("@DateToCheckOut", DateToCheckOut);
                    command.Parameters.AddWithValue("@DateToCheckIn", DateToCheckIn);
                    command.Parameters.AddWithValue("@KLMTSpend", KLMTSpend);
                    command.Parameters.AddWithValue("@TotalRentalFee", TotalRentalFee);
                    if (DamageCostfee != -1 && DamageCostfee != null)
                        command.Parameters.AddWithValue("@DamageCostfee", DamageCostfee);
                    else
                        command.Parameters.AddWithValue("@DamageCostfee", System.DBNull.Value);
                    if (Note != "" && Note != null)
                        command.Parameters.AddWithValue("@Note", Note);
                    else
                        command.Parameters.AddWithValue("@Note", System.DBNull.Value);
                    command.Parameters.AddWithValue("@CarIsReturn", CarIsReturn);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    Connection.Open();
                    command.ExecuteNonQuery();
                    return true;

                }
            }

        }
        public static bool Delete(int ReservationID)
        {
            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_DeleteReservationID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ReservationID", ReservationID);
                connection.Open();

                int rowsAffected = (int)command.ExecuteScalar();
                return (rowsAffected == 1);


            }
        }
        public static bool GetReservationCarByID(int ReservationID, ref int CarSelectedID, ref int ClientID, ref DateTime ReservationDate, ref DateTime DateToCheckOut, ref DateTime DateToCheckIn, ref int KLMTSpend, ref decimal TotalRentalFee, ref decimal DamageCostfee, ref string Note,ref bool CarIsReturn, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString); string query = "SELECT * FROM ReservationCars WHERE ReservationID= @ReservationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ReservationID ", ReservationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true; CarSelectedID = (int)reader["CarSelectedID"];
                    ClientID = (int)reader["ClientID"];
                    ReservationDate = (DateTime)reader["ReservationDate"];
                    DateToCheckOut = (DateTime)reader["DateToCheckOut"];
                    DateToCheckIn = (DateTime)reader["DateToCheckIn"];
                    KLMTSpend = (int)reader["KLMTSpend"];
                    TotalRentalFee = (decimal)reader["TotalRentalFee"];

                    if (reader["DamageCostfee"] != DBNull.Value)
                        DamageCostfee = (decimal)reader["DamageCostfee"];
                    else
                        DamageCostfee = -1;


                    if (reader["Note"] != DBNull.Value)
                        Note = (string)reader["Note"];
                    else
                        Note = "";
                    CarIsReturn = (bool)reader["CarIsReturn"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();

            }
            return isFound;
        }
        public static bool GetReservationInfoByCarID(ref int ReservationID, int CarSelectedID, ref int ClientID, ref DateTime ReservationDate, ref DateTime DateToCheckOut, ref DateTime DateToCheckIn, ref int KLMTSpend, ref decimal TotalRentalFee, ref decimal DamageCostfee, ref string Note,ref bool CarIsReturn , ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString); string query = "SELECT * FROM ReservationCars WHERE CarSelectedID= @CarSelectedID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CarSelectedID ", CarSelectedID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true; ReservationID = (int)reader["ReservationID"];
                    ClientID = (int)reader["ClientID"];
                    ReservationDate = (DateTime)reader["ReservationDate"];
                    DateToCheckOut = (DateTime)reader["DateToCheckOut"];
                    DateToCheckIn = (DateTime)reader["DateToCheckIn"];
                    KLMTSpend = (int)reader["KLMTSpend"];
                    TotalRentalFee = (decimal)reader["TotalRentalFee"];

                    if (reader["DamageCostfee"] != DBNull.Value)
                        DamageCostfee = (decimal)reader["DamageCostfee"];
                    else
                        DamageCostfee = -1;


                    if (reader["Note"] != DBNull.Value)
                        Note = (string)reader["Note"];
                    else
                        Note = "";
                    CarIsReturn = (bool)reader["CarIsReturn"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool GetReservationInfoByClientID(ref int ReservationID, ref int CarSelectedID, int ClientID, ref DateTime ReservationDate, ref DateTime DateToCheckOut, ref DateTime DateToCheckIn, ref int KLMTSpend, ref decimal TotalRentalFee, ref decimal DamageCostfee, ref string Note,ref bool CarIsReturn , ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString); string query = "SELECT * FROM ReservationCars WHERE ClientID= @ClientID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClientID ", ClientID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true; ReservationID = (int)reader["ReservationID"];
                    CarSelectedID = (int)reader["CarSelectedID"];
                    ReservationDate = (DateTime)reader["ReservationDate"];
                    DateToCheckOut = (DateTime)reader["DateToCheckOut"];
                    DateToCheckIn = (DateTime)reader["DateToCheckIn"];
                    KLMTSpend = (int)reader["KLMTSpend"];
                    TotalRentalFee = (decimal)reader["TotalRentalFee"];

                    if (reader["DamageCostfee"] != DBNull.Value)
                        DamageCostfee = (decimal)reader["DamageCostfee"];
                    else
                        DamageCostfee = -1;


                    if (reader["Note"] != DBNull.Value)
                        Note = (string)reader["Note"];
                    else
                        Note = "";
                    CarIsReturn = (bool)reader["CarIsReturn"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool IsReservationExistID(int ReservationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Found=1 FROM ReservationCars  
             where ReservationID = @ReservationID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ReservationID ", ReservationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;

            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static DataTable GetAllByReservations()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select ReservationCars.ReservationID , ReservationCars.CarSelectedID,ReservationCars.ClientID ,People.FirstName +' '+ People.LastName as FullName,
ReservationCars.ReservationDate , ReservationCars.DateToCheckOut,ReservationCars.DateToCheckIn ,ReservationCars.KLMTSpend
,ReservationCars.TotalRentalFee , ReservationCars.DamageCostfee , case WHEN ReservationCars.CarIsReturn = 0 then 'No'when ReservationCars.CarIsReturn  = 1 then 'Yas' end as CarIsReturn,
Users.Username
from ReservationCars
inner join Clients on ReservationCars.ClientID = Clients.ClientID
inner join People on Clients.PersonID = People.PersonID
Inner Join Users on CLients.CreatedByUserID = Users.UserID
Order by ReservationID DESC   ";

  SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
              // return false;

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
    } 
}