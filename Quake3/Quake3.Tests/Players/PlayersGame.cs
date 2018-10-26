using Quake3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quake3.Tests.Players
{
    internal class PlayersGame
    {
        private Quake3.Models.Player playerOne;

        private PlayersGame()
        {
            playerOne = new Player(1, "Player test");
        }

        public static PlayersGame Default()
        {
            return new PlayersGame();
        }

        public PlayersGame WithID(int id)
        {
            playerOne = new Player(id);
            return this;
        }

        public PlayersGame WithIdAndName(int id, string name)
        {
            playerOne = new Player(id, name);
            return this;
        }

        public Player Build()
        {
            if (playerOne == null)
                throw new Exception("player was not created.");

            return playerOne;
        }
    }
}
