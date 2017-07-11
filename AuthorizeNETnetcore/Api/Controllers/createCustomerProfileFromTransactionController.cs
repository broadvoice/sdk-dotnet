using System;
using AuthorizeNet.APICore;
using AuthorizeNETnetcore.Api.Controllers.Bases;

namespace AuthorizeNETnetcore.Api.Controllers
{
#pragma warning disable 1591
    public class createCustomerProfileFromTransactionController : ApiOperationBase<createCustomerProfileFromTransactionRequest, createCustomerProfileResponse>
    {

        public createCustomerProfileFromTransactionController(createCustomerProfileFromTransactionRequest apiRequest)
            : base(apiRequest)
        {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();
		
		    //validate required fields		
            if (null == request.transId) throw new ArgumentException("transactionId cannot be null");
		
		    //validate not-required fields		
	    }
    }
#pragma warning restore 1591
}