
namespace com.nttdocomostar
{
    public abstract class StarApplication
    {
        private readonly StarApplicationManager _manager = new();

        protected StarApplicationManager GetStarApplicationManager() => _manager;

        public abstract void Started(int value);
        public abstract void StateChanged(bool value);
        public abstract void Activated(int var1);

        protected void Terminate() => Environment.Exit(0);
    }
}
