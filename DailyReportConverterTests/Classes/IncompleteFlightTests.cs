using Microsoft.VisualStudio.TestTools.UnitTesting;
using DailyReportConverter.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyReportConverter.Classes.Tests
{
    [TestClass()]
    public class IncompleteFlightTests
    {
        [TestMethod()]
        public void ReturnFlightNumberTest()
        {
            //Arrange
            string unsplitData = " \"2019-06-05 10:36:49\",\"RW Scene\",\"Mission Complete\",\"South Rim Helibase - AZ\",\"19-03503\",\"Sunrise Medical Center and Childrens Hospital -Las Vegas, NV\",\"Page\",\"N407LF(CLASSIC 09)\",,,\"HIGHEST 5500\"";
            string[] data = unsplitData.Split('"');
            int i = 0;
            //Act
            IncompleteFlight incompleteFlight = new IncompleteFlight(data, i);
            //End Act
            string expectedFlightNumber = "19-03503";
            string actualFlightNumber = incompleteFlight.FlightNumber;


            

            //Assert
            Assert.AreEqual(expectedFlightNumber, actualFlightNumber);
        }

        //[TestMethod()]
        //public void GetCurrentYearTest()
        //{
        //    //Arrange
        //    string desiredOutputYearString = "19";

        //    //Act
        //    string actualOutputYearString = ;

        //    //Assert
        //}
    }
}