﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class MarioStill: IPlayerState
    {
        private Mario mario;
        AnimatedSprite big;
        AnimatedSprite small;
        AnimatedSprite fire;
        public MarioStill(Mario mario)
        {
            this.mario = mario;
            //Set Sprite here
            big = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigStillSprite(mario.facingRight), 1, 1);
            small = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallStillSprite(mario.facingRight), 1, 1);
            fire = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigStillSprite(mario.facingRight), 1, 1);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (mario.fire)
                fire.Draw(spriteBatch, mario.location);
            else if (mario.small)
                small.Draw(spriteBatch, mario.location);
            else
                big.Draw(spriteBatch, mario.location);
        }
        public void Still()
        {
            //Do nothing
        }
        public void Running()
        {
            mario.state = new MarioRunning(mario);
        }
        public void ChangeDirection()
        {
            mario.state = new MarioChangeDirection(mario);
        }
        public void Jump()
        {
            mario.state = new MarioJump(mario);
        }
        public void ShootFireball()
        {
            if (mario.fire)
            mario.state = new MarioShootFireball(mario);
        }
        public void Duck()
        {
            mario.state = new MarioDuck(mario);
        }
        public void Dying()
        {
            mario.state = new MarioDying(mario);
        }
    }
}
