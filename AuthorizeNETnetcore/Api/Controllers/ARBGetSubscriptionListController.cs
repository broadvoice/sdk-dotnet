using AuthorizeNet.APICore;
using AuthorizeNETnetcore.Api.Controllers.Bases;

namespace AuthorizeNETnetcore.Api.Controllers
{
#pragma warning disable 1591
    public class ARBGetSubscriptionListController : ApiOperationBase<ARBGetSubscriptionListRequest, ARBGetSubscriptionListResponse> {

	    public ARBGetSubscriptionListController(ARBGetSubscriptionListRequest apiRequest) : base(apiRequest) {
	    }

	    override protected void ValidateRequest() {
            var request = GetApiRequest();
		}
    }
#pragma warning restore 1591
}