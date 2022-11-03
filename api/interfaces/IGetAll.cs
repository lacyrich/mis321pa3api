using System.Collections.Generic;
using mis321pa3api.api.models;
namespace mis321pa3api.api.interfaces
{
    public interface IGetAll
    {
         List<Driver> GetAll();
    }
}