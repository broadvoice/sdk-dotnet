﻿using AuthorizeNet.Api.Contracts;
using AuthorizeNet.APICore;
using AuthorizeNETnetcore.Api.Controllers.Bases;

namespace AuthorizeNETnetcore.Api.Controllers
{
#pragma warning disable 1591
    public class getMerchantDetailsController : ApiOperationBase<getMerchantDetailsRequest, getMerchantDetailsResponse> {

	    public getMerchantDetailsController(getMerchantDetailsRequest apiRequest) : base(apiRequest) {
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
            RequestFactoryWithSpecified.getMerchantDetailsRequest(request);
        }    
    }
#pragma warning restore 1591
}