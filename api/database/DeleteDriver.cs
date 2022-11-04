using MySql.Data.MySqlClient;
using mis321pa3api.api.interfaces;

namespace mis321pa3api.api.database
{
    public class DeleteDriver : IDeleteDriver
    {
        //fire driver
        void IDeleteDriver.DeleteDriver(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            if (con.State == System.Data.ConnectionState.Closed) {
            con.Open();
            }

            string stm = @"UPDATE drivers SET isDeleted = 1 WHERE id = @id";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.Prepare();
            
            cmd.ExecuteNonQuery();

        }
        
        

    }
}