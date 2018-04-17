using System;
using System.Net.Http;

namespace MyNewDotNetWeb.Clients
{
    public class TypedHttpClient
    {
        public HttpClient Client { get; private set; }

        public TypedHttpClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://www.google.com");
            Client = client;
        }
    }
}
