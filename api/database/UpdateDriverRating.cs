using MySql.Data.MySqlClient;
using mis321pa3api.api.interfaces;
using mis321pa3api.api.models;

namespace mis321pa3api.api.database
{
    public class UpdateDriverRating : IUpdateDriverRating
    {
        //edit driver rating
        void IUpdateDriverRating.UpdateDriverRating(Driver driver)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE drivers SET driverName = @driverName, rating = @rating, dateHired = @dateHired, isDeleted = @deleted WHERE id = @id";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", driver.ID);
            cmd.Parameters.AddWithValue("@driverName", driver.DriverName);
            cmd.Parameters.AddWithValue("@rating", driver.Rating);
            cmd.Parameters.AddWithValue("@dateHired", driver.DateHired);
            cmd.Parameters.AddWithValue("@deleted", driver.Deleted);

            cmd.Prepare();
            
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}