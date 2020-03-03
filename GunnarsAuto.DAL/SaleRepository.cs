using GunnarsAuto.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunnarsAuto.DAL
{
    public class SaleRepository : BaseRepository
    {
        public List<Sale> GetSalesBySalePersonsId(SalesPerson salesPerson)
        {
            string sql = 
                $"SELECT * FROM Sales " +
                $"JOIN SalesPersons ON SalesPersons.Id = Sales.SalesPersonId " +
                $"JOIN Cars ON Cars.Id = Sales.CarId " +
                $"WHERE SalesPersonId = {salesPerson.Id}";
            return HandleData(ExecuteQuery(sql));
        }

        public int CreateSale(Sale sale)
        {
            string saleSql = 
                $"INSERT INTO Sales(BuyPrice, SalesPersonId, CarId) " +
                $"VALUES ({sale.BuyPrice}, {sale.SalesPerson.Id}, {sale.Car.Id})";

            int rowsAffected = new CarRepository().CreateCar(sale.Car);

            return rowsAffected + ExecuteNonQuery(saleSql);
        }

        public int UpdateSale(Sale sale)
        {
            string sql =
                $"UPDATE Sales " +
                $"SET SellPrice = {sale.SellPrice}, IsSold = 1 " +
                $"WHERE Id = {sale.Id}";

            return ExecuteNonQuery(sql);
        }


        private List<Sale> HandleData(DataTable dataTable)
        {
            List<Sale> saleList = new List<Sale>();

            if (dataTable is null)
                return saleList;

            foreach (DataRow row in dataTable.Rows)
            {
                Sale tempSale = new Sale()
                {
                    Id = (int)row["CarId"],
                    BuyPrice = (decimal)row["BuyPrice"],
                    SellPrice = (decimal)row["SellPrice"],
                    IsSold = Convert.ToBoolean(row["IsSold"]),
                    Car = new Car()
                    {
                        Id = (int)row["CarId"],
                        Make = (string)row["Make"],
                        Model = (string)row["Model"],
                        VIN = (string)row["VIN"],
                        RegistryNumber = (string)row["RegistryNumber"],
                        IsUsed = Convert.ToBoolean(row["IsUsed"])
                    },
                    SalesPerson = new SalesPerson()
                    {
                        Id = (int)row["SalesPersonId"],
                        Firstname = (string)row["Firstname"],
                        Lastname = (string)row["Lastname"],
                        Initials = (string)row["Initials"]
                    }
                };
                saleList.Add(tempSale);
            }
            return saleList;
        }
    }
}
