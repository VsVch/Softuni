namespace ASP.netCoreTreningApp.Service
{
    public class InstanceCounter : IInstanceCounter
    {
        private static int instance;

        public InstanceCounter()
        {
            instance++;
        }

        public int Instance => instance;
    }
}
