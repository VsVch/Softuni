using DependenciInjectionWorkoshop.Containers;
using DependenciInjectionWorkoshop.DI;
using DependenciInjectionWorkoshop.DI.Containers;
using DependenciInjectionWorkoshop.Loggers;

namespace DependenciInjectionWorkoshop
{
    public class Program
    {
        static void Main(string[] args)
        {

            Engine engine = InjectorSingleton.Istance.Inject<Engine>();

            engine.Strat();
            engine.End();
        }
        
    }
}
