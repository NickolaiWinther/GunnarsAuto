using GunnarsAuto.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunnarsAuto.DAL
{
    public class CarRepository : BaseRepository
    {
        //public Car GetCarById(int id)
        //{
        //    string sql = $"SELECT * FROM Cars WHERE CarId = {id}";
        //    return HandleData(ExecuteQuery(sql)).FirstOrDefault();
        //}

        public int CreateCar(Car car)
        {
            int isUsed = car.IsUsed ? 1 : 0;
            string sql =
                $"INSERT INTO Cars (Make, Model, VIN, RegistryNumber, IsUsed) " +
                $"VALUES ('{car.Make}', '{car.Model}', '{car.VIN}', '{car.RegistryNumber}', {isUsed})";

            return ExecuteNonQuery(sql);
        }

        //private List<Car> HandleData(DataTable dataTable)
        //{
        //    List<Car> carList = new List<Car>();

        //    if (dataTable is null)
        //        return carList;

        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        Car tempCar = new Car()
        //        {
        //            Id = (int)row["CarId"],
        //            Make = (string)row["Make"],
        //            Model = (string)row["Model"],
        //            VIN = (string)row["VIN"],
        //            RegistryNumber = (string)row["RegistryNumber"],
        //            IsUsed = (bool)row["IsUsed"]
        //        };
        //        carList.Add(tempCar);
        //    }
        //    return carList;
        //}
    }
}
