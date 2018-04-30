using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyNewDotNetWeb.Clients;

namespace MyNewDotNetWeb.Controllers
{
    [Route("http")]
    [ApiController]
    public class HttpClientController : ControllerBase
    {
        private readonly TypedHttpClient _crownBetClient;
        IHttpClientFactory _httpClientFactory;

        public HttpClientController(IHttpClientFactory httpClientFactory, TypedHttpClient crownBetClient)
        {
            _crownBetClient = crownBetClient;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("default")]
        public IEnumerable<string> GetDefaultHttpResult()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new System.Uri("https://www.google.com.au");
            var result = client.GetAsync("");
            if (result.Result.IsSuccessStatusCode)
            {
                return new string[] { "Default Client is ok" };
            }
            return new string[] { "Something went wrong" };
        }

        [HttpGet]
        [Route("named")]
        public IEnumerable<string> GetNamedHttpResult()
        {
            var whClient = _httpClientFactory.CreateClient("NamedHttpClient");
            var result = whClient.GetAsync("");
            if (result.Result.IsSuccessStatusCode)
            {
                return new string[] { "Named Client is ok" };
            }
            return new string[] { "Something went wrong" };
        }

        [HttpGet]
        [Route("typed")]
        public async Task<IEnumerable<string>> GetTypedHttpResult()
        {
            var typedClient = await _crownBetClient.Client.GetAsync("");
            if (typedClient.IsSuccessStatusCode)
            {
                return new string[] { "Typed Client is ok" };
            }
            return new string[] { "Something went wrong" };
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IEnumerable<string>> GetTypedHttpResult([Required] int id)
        {
            var typedClient = await _crownBetClient.Client.GetAsync("");
            if (typedClient.IsSuccessStatusCode)
            {
                return new string[] { "Typed Client is ok" };
            }
            return new string[] { "Something went wrong" };
        }
    }
}
