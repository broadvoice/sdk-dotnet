using System.Collections.Generic;
using AuthorizeNet.APICore;

namespace AuthorizeNETnetcore.Api.Controllers.Bases
{
    /**
     * @author ramittal
     *
     */
#pragma warning disable 1591
    public interface IApiOperation<TQ, TS>  
        where TQ : ANetApiRequest 
        where TS : ANetApiResponse
	{
        TS GetApiResponse();
        ANetApiResponse GetErrorResponse();
        TS ExecuteWithApiResponse(AuthorizeNet.Environment environment = null);
        void Execute(AuthorizeNet.Environment environment = null);
        messageTypeEnum GetResultCode();
        List<string> GetResults();
    }
#pragma warning restore 1591
}