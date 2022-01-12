using Asp.NetCoreDemo.Models.Interfaces;

namespace Asp.NetCoreDemo.Models.Services
{
    public class SampleService 
    {
        private readonly ISample _transient;
        private readonly ISample _scoped;
        private readonly ISample _singleton;
        public SampleService(ITransient transient, IScoped scoped, ISingleton singleton)
        {
            _transient = transient;
            _scoped = scoped;
            _singleton = singleton;
        }

        public string GetSampleHashCode()
        {
            return $"Transient:{_transient.GetHashCode()}," +
                   $"Scoped: {_scoped.GetHashCode()}," +
                   $"Singleton: {_singleton.GetHashCode()}";
        }


    }
}
