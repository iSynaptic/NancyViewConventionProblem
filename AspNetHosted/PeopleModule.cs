using System;
using System.Collections.Generic;
using System.Linq;
using AspNetHosted.Model;
using iSynaptic.Commons;
using iSynaptic.Commons.Collections.Generic;
using Nancy;

namespace AspNetHosted
{
    public class PeopleModule : NancyModule
    {
        public PeopleModule() : base("/People")
        {
            Get["/"] = (object p) => _people.Select(x => string.Format("/people/{0}", x.Key)).ToArray();
            Get["/{handle}"] = p => _people.TryGetValue((string)p.handle).OfType<Object>().ValueOrDefault(HttpStatusCode.NotFound);
        }

        private Dictionary<string, Person> _people = new Dictionary<string, Person>
        {
            { "TheCodeJunkie", new Person("TheCodeJunkie", "thecodejunkie", "Open-source activist, software craftsman, speaker, blogger, Twitter addict, believer of agile practices, swede, husband, father, and overall awesome - especially for helping out with Nancy questions!" ) },
            { "jordan.terrell", new Person("jordan.terrell", "jordanterrell", "Software Enginner Guru checking out this cool Nancy framework!" ) }
        };
    }
}