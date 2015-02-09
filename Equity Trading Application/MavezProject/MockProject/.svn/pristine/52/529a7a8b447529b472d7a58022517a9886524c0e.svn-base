 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using DataAccessLayer.DAL.ExecutionBrokerDAL;
using System.Threading;

namespace AutoAllocationService
{
    public class CalculatingTradePrice
    {


        public List<ParameterToSend> BlockExecution(List<Block> blockList)
        {
            Thread.SpinWait(1000);
            List<ParameterToSend> ParameterToSendObject = new List<ParameterToSend>();

            Random randomNumber = new Random();
            //Random randomTradePriceGeneration = new Random();
            //Random randomDecimalPart = new Random();
            Random noOfSecuritiesToExecute = new Random();

            //EquityTradingDBEntities ctx = new EquityTradingDBEntities();

            ISecurityConfigurationDAL securityConfigurationDAL = new SecurityConfigurationDAL();
            //  var securityConfigurationDetailsList = securityConfigurationDAL.GetAllDetails();

            //   var securitiesList = securityConfigurationDAL.GetSecurities();
            ISecuritiesDAL securityDALObject = new SecuritiesDAL();

            int orderCount;

            IOrderDAL orderDAL = new OrderDAL();
            //  orderCount = orderDAL.OrderCountPerBlock(blockList);
            //   List<decimal> currentTradingPrice = new List<decimal>();
            //   List<int> numberOfExecution = new List<int>();
            int j = 0;
            try
            {
                foreach (var block in blockList)
                {
                    ParameterToSend ObjectOfParameterToSend = new ParameterToSend();
                    var securityConfigurationDetailsList = securityConfigurationDAL.GetSecurityConfigurationDetailsByBlockId(block);
                    //foreach (var r in securityConfigurationDetailsList)
                    //{
                    if (securityConfigurationDetailsList.SecurityID == block.SecurityID)
                    {
                        var securityRecieved = securityDALObject.GetSecurities(block);
                        //foreach (var n in securitiesList)
                        orderCount = orderDAL.OrderCountPerBlock(block);
                        if (securityRecieved.SecurityID == securityConfigurationDetailsList.SecurityID)
                        {
                            //The system determines the number of execution at random (between 1 and Max No. of Executions per order). 
                            int numberOfExecutionCalc = randomNumber.Next(1, securityConfigurationDetailsList.MaxExecutionNumber);
                            //Console.WriteLine(r.MaxExecutionNumber);
                            // numberOfExecution.Add(numberOfExecutionCalc);
                            //Current Price Execution 
                            decimal currentTradingPrice;
                            ISecuritiesDAL dalObj = new SecuritiesDAL();
                            currentTradingPrice = dalObj.GetSecurities(block).MarketPrice;
                            //decimal currentTradingPrice = randomTradePriceGeneration.Next(Convert.ToInt32(securityRecieved.LastTradedPrice) - securityConfigurationDetailsList.MaxPriceSpread, Convert.ToInt32(securityRecieved.LastTradedPrice) + securityConfigurationDetailsList.MaxPriceSpread);
                            //decimal decimalPartCalculation = randomDecimalPart.Next(0, 99);
                            //decimal decimalPart = decimalPartCalculation / 100;
                            //currentTradingPrice = currentTradingPrice + decimalPart;
                            // currentTradingPrice.Add(currentTradingPrice);
                            //  int RandomSecuritiesToExecute = noOfSecuritiesToExecute.Next(0, orderCount);
                            ObjectOfParameterToSend.currentTradingPrice = currentTradingPrice;
                            ObjectOfParameterToSend.executionsPerOrder = numberOfExecutionCalc;
                            ObjectOfParameterToSend.BlockToSend = block;
                            ObjectOfParameterToSend.TimeStamp = DateTime.Now;
                            int orderToExecute = noOfSecuritiesToExecute.Next(1, orderCount);
                            ObjectOfParameterToSend.OrderToExecute = orderToExecute;
                            ParameterToSendObject.Add(ObjectOfParameterToSend);
                            j++;
                        }
                    }


                }
            }


            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Ocurred:" + e.Message);
            }
            return ParameterToSendObject;

        }

    }
    //public class CalculatingTradePrice
    //{


    //    public List<ParameterToSend> BlockExecution(List<Block> blockList)
    //    {
    //        Thread.SpinWait(1000);
    //        List<ParameterToSend> ParameterToSendObject = new List<ParameterToSend>();

    //        Random randomNumber = new Random();
    //        Random randomTradePriceGeneration = new Random();
    //        Random randomDecimalPart = new Random();
    //        Random noOfSecuritiesToExecute = new Random();

    //        //EquityTradingDBEntities ctx = new EquityTradingDBEntities();

    //        ISecurityConfigurationDAL securityConfigurationDAL = new SecurityConfigurationDAL();
    //        //  var securityConfigurationDetailsList = securityConfigurationDAL.GetAllDetails();

    //        //   var securitiesList = securityConfigurationDAL.GetSecurities();
    //        ISecuritiesDAL securityDALObject = new SecuritiesDAL();

    //        int orderCount;

    //        IOrderDAL orderDAL = new OrderDAL();
    //        //  orderCount = orderDAL.OrderCountPerBlock(blockList);
    //        //   List<decimal> currentTradingPrice = new List<decimal>();
    //        //   List<int> numberOfExecution = new List<int>();
    //        int j = 0;
    //        try
    //        {
    //            foreach (var block in blockList)  //Re change the code
    //            {
    //                ParameterToSend ObjectOfParameterToSend = new ParameterToSend();
    //                var securityConfigurationDetailsList = securityConfigurationDAL.GetSecurityConfigurationDetailsByBlockId(block);
    //                //foreach (var r in securityConfigurationDetailsList)
    //                //{
    //                if (securityConfigurationDetailsList.SecurityID == block.SecurityID)
    //                {
    //                    var securityRecieved = securityDALObject.GetSecurities(block);
    //                    //foreach (var n in securitiesList)
    //                    orderCount = orderDAL.OrderCountPerBlock(block);
    //                    if (securityRecieved.SecurityID == securityConfigurationDetailsList.SecurityID)
    //                    {
    //                        //The system determines the number of execution at random (between 1 and Max No. of Executions per order). 
    //                        int numberOfExecutionCalc = randomNumber.Next(1, securityConfigurationDetailsList.MaxExecutionNumber);
    //                        //Console.WriteLine(r.MaxExecutionNumber);
    //                        // numberOfExecution.Add(numberOfExecutionCalc);
    //                        //Current Price Execution 
    //                        decimal currentTradingPrice = randomTradePriceGeneration.Next(Convert.ToInt32(securityRecieved.LastTradedPrice) - securityConfigurationDetailsList.MaxPriceSpread, Convert.ToInt32(securityRecieved.LastTradedPrice) + securityConfigurationDetailsList.MaxPriceSpread);
    //                        decimal decimalPartCalculation = randomDecimalPart.Next(1, 99);
    //                        decimal decimalPart = decimalPartCalculation / 100;
    //                        currentTradingPrice = currentTradingPrice + decimalPart;
    //                        // currentTradingPrice.Add(currentTradingPrice);
    //                        //  int RandomSecuritiesToExecute = noOfSecuritiesToExecute.Next(0, orderCount);
    //                        ObjectOfParameterToSend.currentTradingPrice = currentTradingPrice;
    //                        ObjectOfParameterToSend.executionsPerOrder = numberOfExecutionCalc;
    //                        ObjectOfParameterToSend.BlockToSend = block;
    //                        ObjectOfParameterToSend.TimeStamp = DateTime.Now;
    //                        int orderToExecute = noOfSecuritiesToExecute.Next(1, orderCount);
    //                        ObjectOfParameterToSend.OrderToExecute = orderToExecute;
    //                        ParameterToSendObject.Add(ObjectOfParameterToSend);
    //                        j++;
    //                    }
    //                }
    //                break;

    //            }
    //        }


    //        catch (NullReferenceException ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine("Exception Ocurred:" + e.Message);
    //        }
    //        return ParameterToSendObject;

    //    }

    //}

    //public class CalculatingTradePrice
    //{
        
       
    //    public List<ParameterToSend> BlockExecution(List<Block> blockList)
    //    {
            
    //        List<ParameterToSend> ParameterToSendObject = new List<ParameterToSend>();
           
    //        Random randomNumber = new Random();
    //        Random randomTradePriceGeneration = new Random();
    //        Random randomDecimalPart = new Random();
    //        Random noOfSecuritiesToExecute = new Random();
            
    //        EquityTradingDBEntities ctx = new EquityTradingDBEntities();
            
    //        ISecurityConfigurationDAL securityConfigurationDAL = new SecurityConfigurationDAL();
    //        var securityConfigurationDetailsList = securityConfigurationDAL.GetAllDetails();

    //        var securitiesList = securityConfigurationDAL.GetSecurities();

           
    //        List<int> orderCount = new List<int>();
            
    //        IOrderDAL orderDAL = new OrderDAL();
    //        orderCount = orderDAL.OrderCountPerBlock(blockList);
    //        decimal[] currentTradingPrice = new decimal[100];
    //        int[] numberOfExecution = new int[200];
    //        int j = 0;
    //        foreach (var block in blockList)
    //        {
    //            ParameterToSend ObjectOfParameterToSend = new ParameterToSend();
    //            foreach (var r in securityConfigurationDetailsList)
    //            {
    //                if (r.SecurityID == block.SecurityID)
    //                {
    //                    foreach (var n in securitiesList)
    //                        if (n.SecurityID == r.SecurityID)
    //                        {
    //                            //The system determines the number of execution at random (between 1 and Max No. of Executions per order). 
    //                            numberOfExecution[j] = randomNumber.Next(1, r.MaxExecutionNumber);
    //                            //Console.WriteLine(r.MaxExecutionNumber);

    //                            //Current Price Execution 
    //                            currentTradingPrice[j] = randomTradePriceGeneration.Next(Convert.ToInt32(n.LastTradedPrice) - r.MaxPriceSpread, Convert.ToInt32(n.LastTradedPrice) + r.MaxPriceSpread);
    //                            decimal decimalPartCalculation = randomDecimalPart.Next(0, 99);
    //                            decimal decimalPart = decimalPartCalculation / 100;
    //                            currentTradingPrice[j] = currentTradingPrice[j] + decimalPart;
    //                            int RandomSecuritiesToExecute = noOfSecuritiesToExecute.Next(0, orderCount[j]);
    //                            ObjectOfParameterToSend.currentTradingPrice = currentTradingPrice[j];
    //                            ObjectOfParameterToSend.executionsPerOrder = numberOfExecution[j];
    //                            ObjectOfParameterToSend.BlockToSend = block;
    //                            ObjectOfParameterToSend.TimeStamp = DateTime.Now;
    //                            int orderToExecute = noOfSecuritiesToExecute.Next(0, orderCount[j]);
    //                            ObjectOfParameterToSend.OrderToExecute = orderToExecute;
    //                            ParameterToSendObject.Add(ObjectOfParameterToSend);
    //                            j++;
    //                        }
    //                }

    //            }
               

    //        }

    //        return ParameterToSendObject;

    //    }
       
    //}
}
