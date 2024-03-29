using MySql.Data.MySqlClient;
using mis321pa3api.api.interfaces;
using mis321pa3api.api.models;

namespace mis321pa3api.api.database
{
    public class CreateDriver : ICreateDriver
    {
        //hire driver
       void ICreateDriver.CreateDriver(Driver myDriver)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            if (con.State == System.Data.ConnectionState.Closed) {
            con.Open();
            }

            string stm = @"INSERT INTO drivers(driverName, rating, dateHired, isDeleted) VALUES(@driverName, @rating, @dateHired, @isDeleted)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@driverName", myDriver.DriverName);
            cmd.Parameters.AddWithValue("@rating", myDriver.Rating);
            cmd.Parameters.AddWithValue("@dateHired", myDriver.DateHired);
            cmd.Parameters.AddWithValue("@isDeleted", myDriver.Deleted);

            cmd.Prepare();
            
            cmd.ExecuteNonQuery();

          
        }
    }
    
}
