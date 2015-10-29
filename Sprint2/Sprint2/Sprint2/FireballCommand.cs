﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class FireballCommand:ICommand
    {
        private Game1 game;
        public FireballCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            if (((Mario)game.mario).Fire)
            {
                Vector2 marioLoc = game.mario.returnLocation();
                game.levelStore.projectileList.Add(new Fireball((int)marioLoc.X + 3, (int)marioLoc.Y + 8));
            }
        }
    }
}