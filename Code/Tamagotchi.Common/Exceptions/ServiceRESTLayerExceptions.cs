using System;

namespace Tamagotchi.Common.Exceptions
{
    public class ServiceRestLayerExceptions : Exception
    {
        public ServiceRestLayerExceptions()
        {

        }

        public ServiceRestLayerExceptions(Exception e) : base("Invalid value: " + e)
        {

        }

        public ServiceRestLayerExceptions(string name, Exception e) : base(name, e)
        {

        }

        public ServiceRestLayerExceptions(string name) : base(name)
        {

        }
    }
}