using System;

namespace Tamagotchi.Common.Exceptions
{
    public class BusinessLayerExceptions : Exception
    {
        public BusinessLayerExceptions()
        {

        }

        public BusinessLayerExceptions(Exception e) : base("Invalid value: " + e)
        {

        }

        public BusinessLayerExceptions(string name, Exception e) : base(name, e)
        {

        }

        public BusinessLayerExceptions(string name) : base(name)
        {

        }
    }
}
