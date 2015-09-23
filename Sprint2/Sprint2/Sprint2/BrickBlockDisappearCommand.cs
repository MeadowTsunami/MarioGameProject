﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class BrickBlockDisappearCommand : ICommand
    {
            private Game1 Game;

            public BrickBlockDisappearCommand(Game1 game)
            {
                Game = game;
            }

            public void Execute()
            {
                Game.brickBlock.Update();
            }
    }
}