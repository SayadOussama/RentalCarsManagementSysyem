using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsDataCarsContainer
    {
        public static int AddNewCar(string CarName, string CarModel,  int CarType, string EngineModel,string CarPlateNumber  ,decimal RentalCarPrice, string Color, int DoorsNumber, string ImagePath, int CurrentKLMT, bool IsAvailable, int ClientTakenID, int CreatedByUserID)
        {
            using (var Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (var command = new SqlCommand("SP_AddNewCar", Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CarName", CarName);
                    command.Parameters.AddWithValue("@CarModel", CarModel);
                    command.Parameters.AddWithValue("@EngineModel", EngineModel);
                    command.Parameters.AddWithValue("@CarType", CarType);
                    command.Parameters.AddWithValue("@CarPlateNumber", CarPlateNumber);
                    command.Parameters.AddWithValue("@RentalCarPrice", RentalCarPrice);
                    command.Parameters.AddWithValue("@Color", Color);
                    command.Parameters.AddWithValue("@DoorsNumber", DoorsNumber);
                    command.Parameters.AddWithValue("@ImagePath", ImagePath);
                    command.Parameters.AddWithValue("@CurrentKLMT", CurrentKLMT);
                    command.Parameters.AddWithValue("@IsAvailable", IsAvailable);
                    if (ClientTakenID != -1 && ClientTakenID != null)
                        command.Parameters.AddWithValue("@ClientTakenID", ClientTakenID);
                    else
                        command.Parameters.AddWithValue("@ClientTakenID", System.DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    var outputIdParam = new SqlParameter("@NewCarID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    }; command.Parameters.Add(outputIdParam);
                    Connection.Open();
                    command.ExecuteNonQuery();

                    return (int)outputIdParam.Value;
                }
            }
        }
        public static bool UpdateCarInfo(int CarID, string CarName, string CarModel, int CarType, string EngineModel,string CarPlateNumber, decimal RentalCarPrice, string Color, int DoorsNumber, string ImagePath, int CurrentKLMT, bool IsAvailable, int ClientTakenID, int CreatedByUserID)
        {

            using (var Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_UpdateCar", Connection))
            {
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CarID", CarID);
                    command.Parameters.AddWithValue("@CarName", CarName);
                    command.Parameters.AddWithValue("@CarModel", CarModel);
                    command.Parameters.AddWithValue("@CarType", CarType);
                    command.Parameters.AddWithValue("@EngineModel", EngineModel);
                    command.Parameters.AddWithValue("@CarPlateNumber", CarPlateNumber);
                    command.Parameters.AddWithValue("@RentalCarPrice", RentalCarPrice);
                    command.Parameters.AddWithValue("@Color", Color);
                    command.Parameters.AddWithValue("@DoorsNumber", DoorsNumber);
                    command.Parameters.AddWithValue("@ImagePath", ImagePath);
                    command.Parameters.AddWithValue("@CurrentKLMT", CurrentKLMT);
                    command.Parameters.AddWithValue("@IsAvailable", IsAvailable);
                    if (ClientTakenID != -1 && ClientTakenID != null)
                        command.Parameters.AddWithValue("@ClientTakenID", ClientTakenID);
                    else
                        command.Parameters.AddWithValue("@ClientTakenID", System.DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    Connection.Open();
                    command.ExecuteNonQuery();
                    return true;

                }
            }
        }
        public static bool DeleteCar(int CarID)
        {
            using (var connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_DeleteCar", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CarID", CarID); connection.Open();

                int rowsAffected = (int)command.ExecuteScalar();
                return (rowsAffected == 1);


            }
        }
        public static bool GetCarInfoByID(int CarID, ref string CarName, ref string CarModel, ref int CarType, ref string EngineModel,ref string CarPlateNumber ,  ref decimal RentalCarPrice, ref string Color, ref int DoorsNumber, ref string ImagePath, ref int CurrentKLMT, ref bool IsAvailable, ref int ClientTakenID, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM CarsContainer WHERE CarID= @CarID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CarID ", CarID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;
                    CarName = (string)reader["CarName"];
                    CarModel = (string)reader["CarModel"];
                    CarType = (int)reader["CarType"];
                    EngineModel = (string)reader["EngineModel"];
                    CarPlateNumber = (string)reader["CarPlateNumber"];
                    RentalCarPrice = (decimal)reader["RentalCarPrice"];
                    Color = (string)reader["Color"];
                    DoorsNumber = (int)reader["DoorsNumber"];
                    ImagePath = (string)reader["ImagePath"];
                    CurrentKLMT = (int)reader["CurrentKLMT"];
                    IsAvailable = (bool)reader["IsAvailable"];

                    if (reader["ClientTakenID"] != DBNull.Value)
                        ClientTakenID = (int)reader["ClientTakenID"];
                    else
                        ClientTakenID = -1;

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
       
       
        public static bool GetCarInfoByCarPlateNumber(ref int CarID, ref string CarName, ref string CarModel, ref int CarType,ref string EngineModel, string CarPlateNumber ,ref decimal RentalCarPrice, ref string Color, ref int DoorsNumber, ref string ImagePath, ref int CurrentKLMT, ref bool IsAvailable, ref int ClientTakenID, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM CarsContainer WHERE CarPlateNumber= @CarPlateNumber";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CarPlateNumber ", CarPlateNumber);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;
                    CarID = (int)reader["CarID"];
                    CarName = (string)reader["CarName"];
                    CarModel = (string)reader["CarModel"];
                    CarType = (int)reader["CarType"];
                    EngineModel = (string)reader["EngineModel"];
                    RentalCarPrice = (decimal)reader["RentalCarPrice"];
                    Color = (string)reader["Color"];
                    DoorsNumber = (int)reader["DoorsNumber"];
                    ImagePath = (string)reader["ImagePath"];
                    CurrentKLMT = (int)reader["CurrentKLMT"];
                    IsAvailable = (bool)reader["IsAvailable"];

                    if (reader["ClientTakenID"] != DBNull.Value)
                        ClientTakenID = (int)reader["ClientTakenID"];
                    else
                        ClientTakenID = -1;

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
        public static bool IsCarExistByCarID(int CarID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Found=1 FROM CarsContainer  
             where CarID = @CarID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CarID ", CarID);

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
        public static bool IsCarExistByCarPlateNumber(string CarPlateNumber)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Found=1 FROM CarsContainer  
             where CarPlateNumber = @CarPlateNumber;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CarPlateNumber ", CarPlateNumber);

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
   
        public static DataTable GetAllByCarModel()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select CarsContainer.CarID , CarsContainer.CarName , CarsContainer.CarModel ,CarsContainer.EngineModel , CarTypes.TypeName , CarsContainer.CarPlateNumber,
CarsContainer.Color,CarsContainer.DoorsNumber ,case WHEN CarsContainer.IsAvailable= 0 then 'No'when CarsContainer.IsAvailable = 1 then 'Yas' end as IsAvailable ,CarsContainer.CurrentKLMT , CarsContainer.ClientTakenID,Users.Username As CreatedByUser
from CarsContainer
inner join CarTypes on CarTypes.CarTypeID = CarsContainer.CarType
inner join Users on Users.UserID=CarsContainer.CreatedByUserID 
order by CarID DESC;  ";

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
                //return false;

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
    }
}