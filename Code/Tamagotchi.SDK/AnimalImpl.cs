using System.Media;

namespace Tamagotchi.SDK
{
    public abstract class AnimalImpl
    {
        protected PetStatus PetStatus;

        protected AnimalImpl(PetStatus petStatus)
        {
            PetStatus = petStatus;
        }

        public abstract PetStatus Play();
        public abstract PetStatus Sleep();
        public abstract PetStatus Eat();
    }
}