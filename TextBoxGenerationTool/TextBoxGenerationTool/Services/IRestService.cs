using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace TextBoxGenerationTool.Services
{
    public interface IRestService
    {
        Task<HttpStatusCode> VerifyUrl(string url, CancellationToken token);
    }
}
