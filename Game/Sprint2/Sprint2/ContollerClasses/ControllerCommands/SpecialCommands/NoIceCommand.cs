﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class NoIceCommand : ICommand
    {
        private Game1 Game;

        public NoIceCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            ((Mario)Game.mario).CanIce = true;
        }
    }
}
