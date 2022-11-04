using mis321pa3api.api.models;
using mis321pa3api.api.interfaces;
using MySql.Data.MySqlClient;
namespace mis321pa3api.api.DataAccess
{
    public class DriverDataAccess : IGetAll, IGetDriver
    {
        public List<Driver> GetAll()
        {
            //show all drivers
            List<Driver> drivers = new List<Driver>();
            ConnectionString connectionString = new ConnectionString();
            string cs = connectionString.cs;

            using MySqlConnection con = new MySqlConnection(cs);
            if (con.State == System.Data.ConnectionState.Closed) {
            con.Open();
            }

            string stm = @"SELECT * from drivers";

            using MySqlCommand cmd = new MySqlCommand(stm, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();

            List<Driver> allDrivers = new List<Driver>();
            while(rdr.Read())
            {
                allDrivers.Add(new Driver(){ID = rdr.GetInt32(0), DriverName = rdr.GetString(1), Rating = rdr.GetInt32(2), DateHired = rdr.GetDateTime(3), Deleted = rdr.GetInt32(4)});
            }

            
            return allDrivers;

        }

        public Driver GetDriver(int id){
            ConnectionString connectionString = new ConnectionString();
            string cs = connectionString.cs;

            using MySqlConnection con = new MySqlConnection(cs);
            if (con.State == System.Data.ConnectionState.Closed) {
            con.Open();
            }

            string stm = @"SELECT * from drivers where id = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            
            rdr.Read();
            return new Driver(){ID = rdr.GetInt32(0), DriverName = rdr.GetString(1), Rating = rdr.GetInt32(2), DateHired = rdr.GetDateTime(3), Deleted = rdr.GetInt32(4)};

            
        }
    }

    
}