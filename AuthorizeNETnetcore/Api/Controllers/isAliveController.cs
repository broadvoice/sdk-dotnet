using AuthorizeNet.Api.Contracts;
using AuthorizeNet.APICore;
using AuthorizeNETnetcore.Api.Controllers.Bases;

namespace AuthorizeNETnetcore.Api.Controllers
{
#pragma warning disable 1591
    public class isAliveController : ApiOperationBase<ANetApiRequest, isAliveResponse>
    {

        public isAliveController(ANetApiRequest apiRequest)
            : base(apiRequest)
        {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();
		
	    }

        protected override void BeforeExecute()
        {
            var request = GetApiRequest();
            RequestFactoryWithSpecified.isAliveRequest(request);
        }
    }
#pragma warning restore 1591
}