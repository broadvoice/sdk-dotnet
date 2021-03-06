﻿using AuthorizeNet.Api.Contracts;
using AuthorizeNETnetcore.Api.Controllers.Bases;
using createTransactionRequest = AuthorizeNet.APICore.createTransactionRequest;
using createTransactionResponse = AuthorizeNet.APICore.createTransactionResponse;

namespace AuthorizeNETnetcore.Api.Controllers
{
#pragma warning disable 1591
    public class createTransactionController : ApiOperationBase<createTransactionRequest, createTransactionResponse> {

	    public createTransactionController(createTransactionRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();
		
		    //validate required fields		
		    //if ( 0 == request.SearchType) throw new ArgumentException( "SearchType cannot be null");
		    //if ( null == request.Paging) throw new ArgumentException("Paging cannot be null");
		
		    //validate not-required fields		
	    }

        protected override void BeforeExecute()
        {
            var request = GetApiRequest();
            RequestFactoryWithSpecified.createTransactionRequest(request);
        }
    }
#pragma warning restore 1591
}