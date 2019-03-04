using Microsoft.AspNetCore.Http;

namespace D8M8.API.Helpers
{
    // Using static keyword means we don't need to create a new instance of this class when we want
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message) {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}