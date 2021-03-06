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
        private bool facingRight;
        public FireballCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            facingRight = ((Mario)game.mario).FacingRight;
            if (((Mario)game.mario).CanFire && game.fireBallCount>0)
            {
                Vector2 marioLoc = game.mario.GetLocation();
                game.levelStore.projectileList.Add(new Fireball((int)marioLoc.X + UtilityClass.fireballSpawnXOffset, (int)marioLoc.Y + UtilityClass.fireballSpawnYOffset, ((Mario)game.mario).CurrentGroundSpeed(), facingRight, game.mario));
                game.fireBallCount--;
                ((Mario)game.mario).CanFire = false;
                ((Mario)game.mario).State.ShootFireball();
            }
        }
    }
}
