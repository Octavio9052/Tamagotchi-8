using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            double maxFood = this.petStatus.GamePoints["MaxFood"];
            if (this.petStatus.GamePoints["Food"] + 12 <= maxFood)
            {
                this.petStatus.GamePoints["Food"] += 12;
            }
            else
            {
                this.petStatus.GamePoints["Food"] = this.petStatus.GamePoints["MaxFood"];
            }

            GameStatus gameStatus = new GameStatus
            {
                Message = this.petStatus.Nickname + eatMessage,
                Allowed = true,
                PetStatus = this.petStatus

            };
            return gameStatus;
        }

        public virtual GameStatus Play()
        {
            double maxFun = this.petStatus.GamePoints["MaxFun"];
            if (this.petStatus.GamePoints["Fun"] + 8 <=  maxFun)
            {
                this.petStatus.GamePoints["Fun"] += 8;
            }
            else
            {
                this.petStatus.GamePoints["Fun"] = this.petStatus.GamePoints["MaxFun"];
            }


            GameStatus gameStatus = new GameStatus
            {
                Message = this.petStatus.Nickname + eatMessage,
                Allowed = true,
                PetStatus = this.petStatus

            };
            return gameStatus;
        }

        public virtual GameStatus Sleep()
        {
            double maxFood = this.petStatus.GamePoints["MaxRest"];
            if (this.petStatus.GamePoints["Rest"] + 10 <= maxFood)
            {
                this.petStatus.GamePoints["Rest"] += 10;
            }
            else
            {
                this.petStatus.GamePoints["Rest"] = this.petStatus.GamePoints["MaxRest"];
            }



            GameStatus gameStatus = new GameStatus
            {
                Message = this.petStatus.Nickname + eatMessage,
                Allowed = true,
                PetStatus = this.petStatus

            };
            return gameStatus;
        }


        private void _checkDefaultGamePoints(string[] defaults)
        {
            foreach (var item in defaults)
            {
                if (!this.petStatus.GamePoints.ContainsKey(item))
                {
                    this.petStatus.GamePoints.Add(item, 0);
                    this.petStatus.GamePoints.Add("Max" + item, 100);
                }
            }
        }
    }
}
