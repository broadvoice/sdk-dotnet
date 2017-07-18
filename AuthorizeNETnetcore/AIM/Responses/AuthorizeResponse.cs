using System;
using System.Collections.Generic;
using System.Text;
using AuthorizeNet;

namespace AuthorizeNETnetcore.AIM.Responses
{
    public class AuthorizeResponse : IGatewayResponse
    {
        public decimal Amount { get; set; }
        public bool Approved { get; set; }
        public string AuthorizationCode { get; set; }
        public string InvoiceNumber { get; set; }
        public string CardNumber { get; set; }
        public string ResponseCode { get; set; }
        public string Message { get; set; }
        public string TransactionID { get; set; }
        public string ResponseReasonCode { get; set; }
        public string GetValueByIndex(int position)
        {
            throw new NotImplementedException();
        }
    }
}
