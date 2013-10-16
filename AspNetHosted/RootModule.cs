using Nancy;

namespace AspNetHosted
{
    public class RootModule : NancyModule
    {
        public RootModule()
        {
            Get["/"] = p => new { Greeting = "Welcome! What do you think of Nancy?" };
        }
    }
}