using MySql.Data.MySqlClient;
using mis321pa3api.api.interfaces;

namespace mis321pa3api.api.database
{
    public class UpdateDriverRating : IUpdateDriverRating
    {
        //edit driver rating
        void IUpdateDriverRating.UpdateDriverRating(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE drivers SET rating = 5 WHERE id = @id";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.Prepare();
            
            cmd.ExecuteNonQuery();
        }
    }
}