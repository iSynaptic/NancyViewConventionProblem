using Nancy;
using Nancy.Conventions;
using Nancy.Serialization.JsonNet;
using Nancy.TinyIoc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AspNetHosted
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register(typeof(JsonSerializer), (c, p) => JsonSerializer.Create(new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }));

            container.Register(typeof(JsonNetSerializer), typeof(JsonNetSerializer));
            container.Register(typeof(JsonNetBodyDeserializer), typeof(JsonNetBodyDeserializer));
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.ViewLocationConventions.Add((viewName, model, ctx) => 
                string.IsNullOrEmpty(ctx.ModulePath)
                    ? string.Empty
                    : string.Concat("views/", ctx.ModulePath.TrimStart('/'), "/index"));

            nancyConventions.ViewLocationConventions.Add((viewName, model, viewLocationContext) => 
                !string.IsNullOrEmpty(viewLocationContext.ModulePath)
                    ? string.Empty
                    : "views/index");
        }
    }
}