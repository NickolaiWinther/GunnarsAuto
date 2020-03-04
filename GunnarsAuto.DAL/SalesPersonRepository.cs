using GunnarsAuto.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunnarsAuto.DAL
{
    public class SalesPersonRepository : BaseRepository
    {
        public List<SalesPerson> GetAllSalesPersons()
        {
            string sql =
                $"SELECT * FROM SalesPersons";
            return HandleData(ExecuteQuery(sql));
        }


        private List<SalesPerson> HandleData(DataTable dataTable)
        {
            List<SalesPerson> salesPersonList = new List<SalesPerson>();

            if (dataTable is null)
                return salesPersonList;

            foreach (DataRow row in dataTable.Rows)
            {
                SalesPerson tempSalesPerson= new SalesPerson()
                {
                    Id = (int)row["Id"],
                    Firstname = (string)row["Firstname"],
                    Lastname = (string)row["Lastname"],
                    Initials = (string)row["Initials"]
                };
                salesPersonList.Add(tempSalesPerson);
            }
            return salesPersonList;
        }
    }
}
