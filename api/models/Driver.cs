using mis321pa3api.api.database;
using mis321pa3api.api.interfaces;

namespace mis321pa3api.api.models
{
    public class Driver 
    {
        public int ID {get; set;}
        public string DriverName {get; set;}
        public int Rating {get; set;}
        public System.DateTime DateHired {get; set;}
        public int Deleted {get; set;}
        
        public override string ToString()
        {
            return (ID + " " + DriverName + " " + Rating + " " + DateHired + " " + Deleted);
        }
        public Driver(){
            DriverName = "";
            Rating = 0;
            DateHired = System.DateTime.Now;
            Deleted = 0;
        }

       
    }
}