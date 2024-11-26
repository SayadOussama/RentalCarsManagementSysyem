using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public  class clsDashBoard
    {


        public static int  GetTotalOfCars()
        {

            return clsDataDashBoard.GetTotalCars();
        }

        public static int GetTotalOfCarsAvailable()
        {

            return clsDataDashBoard.GetTotalCarsAvailable();
        }

        public static int GetTotalOfCarsNotAvailable()
        {

            return clsDataDashBoard.GetTotalCarsNotAvailable();
        }

        public static int GetTotalOfClients()
        {

            return clsDataDashBoard.GetTotalOfClients();
        }







    }
}
