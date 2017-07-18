using System;
using AuthorizeNet;
using Xunit;


namespace AuthorizeNET_xunit
{
    public class UnitTest1
    {
        protected string ApiLogin;
        protected string TransactionKey;
        private CustomerGateway _target;

        [Fact]
        public void ClientConnection_Success()
        {
            var sError = CheckApiLoginTransactionKey();
            Assert.True(sError == "", sError);

            _target = new CustomerGateway(ApiLogin, TransactionKey);
            var result = _target.GetCustomerIDs();
            Assert.NotNull(result);
        }

        [Fact]
        public void AuthorizeNoAccount_Success()
        {
            var sError = CheckApiLoginTransactionKey();
            Assert.True(sError == "", sError);

            _target = new CustomerGateway(ApiLogin, TransactionKey);
            System.Threading.Thread.Sleep(2000);
            decimal chargeAmount = 5;            
            var response = _target.AuthorizeNoAccount("4111111111111111", new DateTime(DateTime.Now.Year + 5, 1, 1), "111", chargeAmount);            

            Assert.True(response, "Charge was not approved");
            System.Threading.Thread.Sleep(2000);
            response = _target.AuthorizeNoAccount("4111111111111111", new DateTime(DateTime.Now.Year + 5, 1, 1), "111", chargeAmount);
            //Assert.NotNull(response.AuthorizationCode);
            Assert.True(response, "Second charge was not approved");
        }

        [Fact]
        public void AuthorizeNoAccount_Fail_InvalidCCV()
        {
            var sError = CheckApiLoginTransactionKey();
            Assert.True(sError == "", sError);

            _target = new CustomerGateway(ApiLogin, TransactionKey);
            System.Threading.Thread.Sleep(2000);
            decimal chargeAmount = 5;
            var response = _target.AuthorizeNoAccount("4111111111111111", new DateTime(DateTime.Now.Year + 5, 1, 1), "901", chargeAmount);

            Assert.False(response, "CCV should cause test to fail");
        }

        //[Fact]
        public void AuthorizeCharge_Success()
        {
            var sError = CheckApiLoginTransactionKey();
            Assert.True(sError == "", sError);

            _target = new CustomerGateway(ApiLogin, TransactionKey);

            RandomStringGenerator generator = new RandomStringGenerator();
            var email = generator.Len(10, 55) + "@visa.com";
            const string description = "Authorization Test";
            var customer = CreateCustomer(email, description);
            Assert.NotNull(customer);
            Assert.True(!string.IsNullOrWhiteSpace(customer.ProfileID), "Unable to create customer");

            string paymentProfileId = CreateCustomerPaymentProfile(customer.ProfileID, "4111111111111111", 1, 2030);
            Assert.NotNull(paymentProfileId);
            Assert.True(!string.IsNullOrWhiteSpace(paymentProfileId), "Unable to create payment profile Id");

            decimal chargeAmount = 3;
            var response = _target.Authorize(customer.ProfileID, paymentProfileId, chargeAmount);
           
            Assert.True(response.Approved, "Charge was not approved");
            Assert.NotNull(response.AuthorizationCode);
        }

        private string CreateCustomerPaymentProfile(string custProfileId, string cardNumber, int expirationMonth, int expirationYear)
        {
            string custPaymentProfileId = null;
            custPaymentProfileId = _target.AddCreditCard(custProfileId, cardNumber, expirationMonth, expirationYear);
            Assert.NotNull(custPaymentProfileId);
            return custPaymentProfileId;
        }

        private Customer CreateCustomer(string email, string description, string custId = "")
        {
            Customer customer = null;
            customer = _target.CreateCustomer(email, description, custId);
            Assert.NotNull(customer);
            return customer;
        }

        /// <summary>
        /// CheckApiLoginTransactionKey - make sure that we are not using the default invalid ApiLogin and TransactionKey.
        /// </summary>
        protected string CheckApiLoginTransactionKey()
        {
            ApiLogin = AuthorizeNet.Test.UnitTestData.GetPropertyFromNames(AuthorizeNet.Util.Constants.EnvApiLoginid, AuthorizeNet.Util.Constants.PropApiLoginid);
            TransactionKey = AuthorizeNet.Test.UnitTestData.GetPropertyFromNames(AuthorizeNet.Util.Constants.EnvTransactionKey, AuthorizeNet.Util.Constants.PropTransactionKey);

            string sRet = "";
            //if ((string.IsNullOrEmpty(ApiLogin)) || (ApiLogin.Trim().Length == 0)
            //    || (string.IsNullOrEmpty(TransactionKey)) || (TransactionKey.Trim().Length == 0))
            //{
            //    LoadLoginTranskey();
            //}

            if ((string.IsNullOrEmpty(ApiLogin)) || (ApiLogin.Trim().Length == 0)
                || (string.IsNullOrEmpty(TransactionKey)) || (TransactionKey.Trim().Length == 0))
            {
                sRet = "Invalid Login / Password: blank \n";
            }

#if !USELOCAL
            if ((ApiLogin == "ApiLogin") || (TransactionKey == "TransactionKey"))
            {
                sRet += "Invalid Login / Password \n";
            }
#endif
            return sRet;
        }
    }
}
