using System;

namespace Tamagotchi.Common.Exceptions
{
    public class ServiceSoapLayerExceptions : Exception
    {
        public ServiceSoapLayerExceptions()
        {

        }

        public ServiceSoapLayerExceptions(Exception e) : base("Invalid value: " + e)
        {

        }

        public ServiceSoapLayerExceptions(string name, Exception e) : base(name, e)
        {

        }

        public ServiceSoapLayerExceptions(string name) : base(name)
        {

        }
    }
}