using System.Media;

namespace Tamagotchi.SDK
{
    public abstract class AnimalImpl
    {
        protected IPetStatus PetStatus;

        protected AnimalImpl(IPetStatus petStatus)
        {
            PetStatus = petStatus;
        }

        public abstract IPetStatus Play();
        public abstract IPetStatus Sleep();
        public abstract IPetStatus Eat();
    }
}