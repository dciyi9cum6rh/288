using System;

namespace DataModel
{
    public class OrderListViewModel
    {
        public string OrderId { get; set; }
        public string MemberMobile { get; set; }
        public string MemberName { get; set; }
        public string ContactAddress { get; set; }
        public string Phone { get; set; }
        public string eMail { get; set; }
        public byte OrderStateId { get; set; }
        public string OrderState { get; set; }
        public DateTime? OrderTime { get; set; }
        public DateTime? PaymentTime { get; set; }
        public DateTime? ShipTime { get; set; }
        public decimal TotalExpense { get; set; }
        public string PaymentType { get; set; }
        public string PaymentTypeDescription { get; set; }
        public string PaymentNo { get; set; }
        public string vAccount { get; set; }
        public string ExpireDate { get; set; }
        public string Mobile { get; set; }
    }
}