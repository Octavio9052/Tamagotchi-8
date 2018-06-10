using System;

namespace Tamagotchi.Common.Exceptions
{
    public class InvalidSessionExceptions : Exception
    {
        public InvalidSessionExceptions() : base("Not valid session or it has been expired")
        {

        }
    }
}
