namespace AspNetHosted.Model
{
    public class Person
    {
        public Person(string handle, string twitterHandle, string bio)
        {
            Handle = handle;
            TwitterHandle = twitterHandle;
            Bio = bio;
        }

        public string Handle { get; private set; }
        public string TwitterHandle { get; private set; }
        public string Bio { get; private set; }
    }
}