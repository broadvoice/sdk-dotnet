using System;
using AuthorizeNet.APICore;
using AuthorizeNETnetcore.Api.Controllers.Bases;

namespace AuthorizeNETnetcore.Api.Controllers
{
#pragma warning disable 1591
    public class createCustomerProfileTransactionController : ApiOperationBase<createCustomerProfileTransactionRequest, createCustomerProfileTransactionResponse> {

	    public createCustomerProfileTransactionController(createCustomerProfileTransactionRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();
		
		    //validate required fields		
            if (null == request.transaction) throw new ArgumentException("transaction cannot be null");
		
		    //validate not-required fields		
	    }
    }
#pragma warning restore 1591
}