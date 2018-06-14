using System.Media;

namespace Tamagotchi.SDK
{
    public abstract class Animal
    {
        protected IPetStatus PetStatus;

        protected Animal(IPetStatus petStatus)
        {
            PetStatus = petStatus;
        }

        public abstract IPetStatus Play();
        public abstract IPetStatus Sleep();
        public abstract IPetStatus Eat();
    }
}