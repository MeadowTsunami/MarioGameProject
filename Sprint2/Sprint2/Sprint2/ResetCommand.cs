﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class ResetCommand:ICommand
    {
            private Game1 Game;

            public ResetCommand(Game1 game)
            {
                Game = game;
            }

            public void Execute()
            {
                ((Mario)Game.mario).Small = true;
                ((Mario)Game.mario).FacingRight = false;
                ((Mario)Game.mario).Fire = false;
                ((Mario)Game.mario).State.Still();
            }
    }
}
