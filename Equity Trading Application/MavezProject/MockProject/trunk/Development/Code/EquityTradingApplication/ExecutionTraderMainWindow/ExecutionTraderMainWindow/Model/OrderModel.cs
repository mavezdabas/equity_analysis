using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExecutionTraderMainWindow.Model
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int SecurityId { get; set; }
        public string Side { get; set; }
        public string OrderType { get; set; }
        public string OrderQualifier { get; set; }
        public int? TraderId { get; set; }
        public int ManagerId { get; set; }
        public int TotalQuantity { get; set; }
        public int OpenQuantity { get; set; }
        public int AllocatedQuantity { get; set; }
        public decimal? StopPrice { get; set; }
        public decimal? LimitPrice { get; set; }
        public string Notes { get; set; }
        public bool? Notify { get; set; }
        public int ClientId { get; set; }
        public int PortfolioId { get; set; }
        public int StatusId { get; set; }
        public int? BlockId { get; set; }
        public byte[] BookTime { get; set; }
        public decimal? TransactionPrice { get; set; }
        public DateTime? TransactionTime { get; set; }
        public string AccountType { get; set; }
        public SecurityModel Security { get; set; }
        public StatusModel Status { get; set; }
        public UserModel Trader { get; set; }
        public UserModel Manager { get; set; }
        public PortfolioModel Portfolio { get; set; }
        public ClientModel Client { get; set; }
        public BlockModel Block { get; set; }
        public bool IsSelected { get; set; }
    }
}
