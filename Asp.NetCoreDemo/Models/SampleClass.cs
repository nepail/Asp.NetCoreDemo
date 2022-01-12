using Asp.NetCoreDemo.Models.Interfaces;

namespace Asp.NetCoreDemo.Models
{
    public class SampleClass : ISample, IScoped, ITransient, ISingleton
    {
    }
}
