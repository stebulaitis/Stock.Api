using Flurl.Http;
using Stock.Core.Models;

namespace Stock.Core.Extensions
{
    public static class FlurlExtensions
    {
        public static async Task<ErrorResponse> GetFlurlErrorResponse(this FlurlHttpException flurlHttpException)
        {
            try
            {
                var errorMessage = await flurlHttpException.GetResponseJsonAsync<ErrorResponse>();

                if (errorMessage is null)
                {
                    return new ErrorResponse(await flurlHttpException.GetResponseStringAsync());
                }

                return errorMessage;
            }
            catch
            {
                return new ErrorResponse(await flurlHttpException.GetResponseStringAsync());
            }
        }
    }
}
