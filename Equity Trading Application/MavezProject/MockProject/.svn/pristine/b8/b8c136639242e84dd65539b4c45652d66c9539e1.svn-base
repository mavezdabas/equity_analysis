using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestPortfolio
{
    
    
    /// <summary>
    ///This is a test class for PortfolioDALTest and is intended
    ///to contain all PortfolioDALTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PortfolioDALTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetAllOrders
        ///</summary>
        [TestMethod()]
        public void GetAllOrdersTest()
        {
            PortfolioDAL target = new PortfolioDAL(); // TODO: Initialize to an appropriate value
          DateTime d= new DateTime(2012,12,05);
         
       
            List<Order> expected = new List<Order>() { new Order(){OrderID=8,SecurityID=1,Side="BUY",OrderType="Market",OrderQualifier="GTC",AccountType="Cash",TotalQuantity=200,AllocatedQuantity=150,OpenQuantity=50,StopPrice=500,LimitPrice=1000,Notes="bhaiye",ClientID=1,StatusID=1,PortfolioID=1,BlockID=1,TransactionPrice=400,TransactionTime=d,ManagerID=2,TraderID=3}}; // TODO: Initialize to an appropriate value
            List<Order> actual= new List<Order>();
            actual = target.GetAllOrders();

            for (int i = 0,j=0; i < actual.Count; i++,j++)
            {
              Assert.AreEqual(actual[i].OrderID, expected[i].OrderID);
              Assert.AreEqual(actual[i].OrderType, expected[i].OrderType);
            }
           // Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeleteOrder
        ///</summary>
        [TestMethod()]
        public void DeleteOrderTest()
        {
            PortfolioDAL target = new PortfolioDAL(); // TODO: Initialize to an appropriate value
            Order orderToDelete = null; // TODO: Initialize to an appropriate value
            target.DeleteOrder(orderToDelete);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetAllSecurities
        ///</summary>
        [TestMethod()]
        public void GetAllSecuritiesTest()
        {
            PortfolioDAL target = new PortfolioDAL(); // TODO: Initialize to an appropriate value
            List<Security> list = new List<Security>(){ new Security(){SecurityID=1,SecurityName="NASDAQ",SecuritySymbol="NAS",LastTradedPrice=100},
            new Security(){SecurityID=2,SecurityName="BSE", SecuritySymbol="BSE", LastTradedPrice=57}};

            List<Security> expected = list; // TODO: Initialize to an appropriate value
            List<Security> actual;
            actual = new List<Security>();
            actual = target.GetAllSecurities();
            //foreach (var item in actual)
            //{
            //    foreach (var item1 in expected)
            //    {
            //        Assert.AreEqual(item.SecurityID, item1.SecurityID);
            //        Assert.AreEqual(item.SecurityName,actual,item1.SecurityName);
            //        Assert.AreEqual(item.SecuritySymbol,item1.SecuritySymbol);
            //        Assert.AreEqual(item.LastTradedPrice,item1.LastTradedPrice);
            //        //item.SecurityID = item1.SecurityID;
            //        //item.SecurityName = item1.SecurityName;
            //        //item.SecuritySymbol = item1.SecuritySymbol;
            //        //item.LastTradedPrice = item1.LastTradedPrice;
            //    }
            //}

            //int i=0,j=0;
            if (actual.Count == expected.Count)
            {
                for (int i = 0, j = 0; i < actual.Count; i++, j++)
                {
                    Assert.AreEqual(actual[i].SecurityID, expected[i].SecurityID);
                    Assert.AreEqual(actual[i].SecurityName, expected[i].SecurityName);
                    Assert.AreEqual(actual[i].SecuritySymbol, expected[i].SecuritySymbol);
                    Assert.AreEqual(actual[i].LastTradedPrice, expected[i].LastTradedPrice);
                }
            }
           
       //     Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetClientByID
        ///</summary>
        [TestMethod()]
        public void GetClientByIDTest()
        {
            PortfolioDAL target = new PortfolioDAL(); // TODO: Initialize to an appropriate value
            int id = 1; // TODO: Initialize to an appropriate value
            Client client = new Client() { ClientID= 1,ClientName="Sapient"};
            Client expected = client; // TODO: Initialize to an appropriate value
            Client actual= new Client();
            actual = target.GetClientByID(id);
            Assert.AreEqual(expected.ClientID, actual.ClientID);
            Assert.AreEqual(expected.ClientName,actual.ClientName);
          //  Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetClientNameByID
        ///</summary>
        [TestMethod()]
        public void GetClientNameByIDTest()
        {
            PortfolioDAL target = new PortfolioDAL(); // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            string expected = null; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetClientNameByID(id);
            Assert.AreEqual(expected, actual);
          //  Assert.Inconclusive("Verify the correctness of this test method.");
        }

       [TestMethod()]
        public void GetClientNameByIDTest1()
        {
            PortfolioDAL target = new PortfolioDAL(); // TODO: Initialize to an appropriate value
            int id = 2; // TODO: Initialize to an appropriate value
            string expected = "Google"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetClientNameByID(id);
            Assert.AreEqual(expected, actual);
            //  Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetOrderByID
        ///</summary>
        [TestMethod()]
        public void GetOrderByIDTest()
        {
            PortfolioDAL target = new PortfolioDAL(); // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            Order expected = null; // TODO: Initialize to an appropriate value
            Order actual;
            actual = target.GetOrderByID(id);
            Assert.AreEqual(expected, actual);
          //  Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetPortfolioByID
        ///</summary>
        [TestMethod()]
        public void GetPortfolioByIDTest()
        {
            PortfolioDAL target = new PortfolioDAL(); // TODO: Initialize to an appropriate value
            int id = 1; // TODO: Initialize to an appropriate value
            Portfolio expected = new Portfolio() { PortfolioID=1,PortfolioName="SapientP1",ClientID=1};
            // TODO: Initialize to an appropriate value
            Portfolio actual = new Portfolio();
            actual = target.GetPortfolioByID(id);
            Assert.AreEqual(expected.PortfolioID, actual.PortfolioID);
            Assert.AreEqual(expected.PortfolioName,actual.PortfolioName);
            Assert.AreEqual(expected.ClientID,actual.ClientID);
          //  Assert.Inconclusive("Verify the correctness of this test method.");
        }


        [TestMethod()]
        public void GetPortfolioByIDTest1()
        {
            PortfolioDAL target = new PortfolioDAL(); // TODO: Initialize to an appropriate value
            int id = -6; // TODO: Initialize to an appropriate value
            Portfolio expected = null;
            // TODO: Initialize to an appropriate value
            Portfolio actual = null;
            actual = target.GetPortfolioByID(id);
            Assert.AreEqual(expected, actual);
         
        }

        /// <summary>
        ///A test for GetPortfolioNameByID
        ///</summary>
        [TestMethod()]
        public void GetPortfolioNameByIDTest()
        {
            PortfolioDAL target = new PortfolioDAL(); // TODO: Initialize to an appropriate value
            int id = -3; // TODO: Initialize to an appropriate value
            string expected = null; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetPortfolioNameByID(id);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void GetPortfolioNameByIDTest1()
        {
            PortfolioDAL target = new PortfolioDAL(); // TODO: Initialize to an appropriate value
            int id = 2; // TODO: Initialize to an appropriate value
            string expected = "SapientP2"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetPortfolioNameByID(id);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetSecurityByID
        ///</summary>
        [TestMethod()]
        public void GetSecurityByIDTest()
        {
            PortfolioDAL target = new PortfolioDAL(); // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            Security expected = null; // TODO: Initialize to an appropriate value
            Security actual;
            actual = target.GetSecurityByID(id);
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }



        [TestMethod()]
        public void GetSecurityByIDTest1()
        {
            PortfolioDAL target = new PortfolioDAL(); // TODO: Initialize to an appropriate value
            int id = 2; // TODO: Initialize to an appropriate value
            Security expected = new Security() { SecurityID=2,SecuritySymbol="BSE",SecurityName="BSE",LastTradedPrice=57}; // TODO: Initialize to an appropriate value
            Security actual;
            actual = target.GetSecurityByID(id);
            Assert.AreEqual(expected.SecurityID, actual.SecurityID);
            Assert.AreEqual(expected.SecurityName,actual.SecurityName);
            Assert.AreEqual(expected.SecuritySymbol,actual.SecuritySymbol);
            Assert.AreEqual(expected.LastTradedPrice,actual.LastTradedPrice);
            // Assert.Inconclusive("Verify the correctness of this test method.");
        }
        /// <summary>
        ///A test for GetSecurityNameByID
        ///</summary>
        [TestMethod()]
        public void GetSecurityNameByIDTest()
        {
            PortfolioDAL target = new PortfolioDAL(); // TODO: Initialize to an appropriate value
            int id = 1; // TODO: Initialize to an appropriate value
            string expected = "NASDAQ"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetSecurityNameByID(id);
            Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        }


        [TestMethod()]
        public void GetSecurityNameByIDTest1()
        {
            PortfolioDAL target = new PortfolioDAL(); // TODO: Initialize to an appropriate value
            int id = -4; // TODO: Initialize to an appropriate value
            string expected = null; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetSecurityNameByID(id);
            Assert.AreEqual(expected, actual);
            //    Assert.Inconclusive("Verify the correctness of this test method.");
        }


        /// <summary>
        ///A test for GetStatusByID
        ///</summary>
        [TestMethod()]
        public void GetStatusByIDTest()
        {
            PortfolioDAL target = new PortfolioDAL(); // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            Status expected = null; // TODO: Initialize to an appropriate value
            Status actual;
            actual = target.GetStatusByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

       

        [TestMethod()]
        public void InsertOrderTest()
        {
            PortfolioDAL target = new PortfolioDAL(); // TODO: Initialize to an appropriate value
            Order orderToInsert = null; // TODO: Initialize to an appropriate value
            target.InsertOrder(orderToInsert);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetStatusNameByID
        ///</summary>
        [TestMethod()]
        public void GetStatusNameByIDTest()
        {
            PortfolioDAL target = new PortfolioDAL(); // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            string expected = null; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetStatusNameByID(id);
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }

    [TestMethod]
        public void GetStatusNameByIDTest1()
        {
            PortfolioDAL target = new PortfolioDAL(); // TODO: Initialize to an appropriate value
            int id = 1; // TODO: Initialize to an appropriate value
            string expected = "NEW"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetStatusNameByID(id);
            Assert.AreEqual(expected, actual);
            // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdateOrder
        ///</summary>
        [TestMethod()]
        public void UpdateOrderTest()
        {
            PortfolioDAL target = new PortfolioDAL(); // TODO: Initialize to an appropriate value
            Order orderToUpdate = null; // TODO: Initialize to an appropriate value
            target.UpdateOrder(orderToUpdate);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
