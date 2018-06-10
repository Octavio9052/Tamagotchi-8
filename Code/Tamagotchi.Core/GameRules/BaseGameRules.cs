namespace Tamagotchi.Core
{
    public class BaseGameRules : IBaseGameRules
    {
        protected const string eatMessage = " has finished eating";
        protected const string sleepMessage = " has finished sleeping";
        protected const string playMessage = " has finished playing";
        private readonly string[] _defaultsKeys = { "Food", "Fun", "Rest" };

        protected PetStatus petStatus;

        public BaseGameRules(PetStatus petStatus)
        {
            this.petStatus = petStatus;
            _checkDefaultGamePoints(_defaultsKeys);
        }

        public virtual GameStatus Eat()
        {
            var maxFood = petStatus.GamePoints["MaxFood"];
            if (petStatus.GamePoints["Food"] + 12 <= maxFood)
            {
                petStatus.GamePoints["Food"] += 12;
            }
            else
            {
                petStatus.GamePoints["Food"] = petStatus.GamePoints["MaxFood"];
            }

            var gameStatus = new GameStatus
            {
                Message = petStatus.Nickname + eatMessage,
                Allowed = true,
                PetStatus = petStatus

            };
            return gameStatus;
        }

        public virtual GameStatus Play()
        {
            var maxFun = petStatus.GamePoints["MaxFun"];
            if (petStatus.GamePoints["Fun"] + 8 <=  maxFun)
            {
                petStatus.GamePoints["Fun"] += 8;
            }
            else
            {
                petStatus.GamePoints["Fun"] = petStatus.GamePoints["MaxFun"];
            }


            var gameStatus = new GameStatus
            {
                Message = petStatus.Nickname + eatMessage,
                Allowed = true,
                PetStatus = petStatus

            };
            return gameStatus;
        }

        public virtual GameStatus Sleep()
        {
            var maxFood = petStatus.GamePoints["MaxRest"];
            if (petStatus.GamePoints["Rest"] + 10 <= maxFood)
            {
                petStatus.GamePoints["Rest"] += 10;
            }
            else
            {
                petStatus.GamePoints["Rest"] = petStatus.GamePoints["MaxRest"];
            }



            var gameStatus = new GameStatus
            {
                Message = petStatus.Nickname + eatMessage,
                Allowed = true,
                PetStatus = petStatus

            };
            return gameStatus;
        }


        private void _checkDefaultGamePoints(string[] defaults)
        {
            foreach (var item in defaults)
            {
                if (!petStatus.GamePoints.ContainsKey(item))
                {
                    petStatus.GamePoints.Add(item, 0);
                    petStatus.GamePoints.Add("Max" + item, 100);
                }
            }
        }
    }
}
