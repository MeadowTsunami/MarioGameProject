﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    class MarioJump: IMarioState
    {
        private Mario mario;
        private AnimatedSprite big;
        private AnimatedSprite small;
        private AnimatedSprite fire;

        public MarioJump(Mario mario)
        {
            this.mario = mario;
            big = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigJumpingSprite(), UtilityClass.one, UtilityClass.one, mario.Location, UtilityClass.four);
            small = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallJumpingSprite(), UtilityClass.one, UtilityClass.one, mario.Location, UtilityClass.four);
            fire = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireJumpingSprite(), UtilityClass.one, UtilityClass.one, mario.Location, UtilityClass.four);         
        }
        public void Update()
        {
            if (mario.Fire)
            {
                fire.Update();
            }
            else if (mario.Small)
            {
                small.Update();
            }
            else
            {
                big.Update();
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            if (mario.Fire)
                fire.Draw(spriteBatch, mario.Location, cameraLoc, mario.FacingRight);
            else if (mario.Small)
                small.Draw(spriteBatch, mario.Location, cameraLoc, mario.FacingRight);
            else
                big.Draw(spriteBatch, mario.Location, cameraLoc, mario.FacingRight);

        }
        public MarioState State()
        {
            return MarioState.Jump;
        }
        public void Still()
        {
            mario.State = new MarioStill(mario);
        }
        public void Running()
        {
            mario.State = new MarioRunning(mario);
        }
        public void ChangeDirection()
        {
            mario.State = new MarioChangeDirection(mario);
        }
        public void Jump()
        {

        }
        public void ShootFireball()
        {
            mario.State = new MarioShootFireball(mario);
        }
        public void Duck()
        {
            mario.State = new MarioStill(mario);
        }
        public void TakeDamage()
        {

        }
        public void Dying()
        {
            if (!mario.Star)
            {
                mario.State = new MarioDying(mario);
            }
        }

        public Rectangle returnStateCollisionRectangle()
        {
            Rectangle collisionRectangle;

            if (mario.Small)
            {
                collisionRectangle = small.returnCollisionRectangle();
            }
            else if(mario.Fire)
            {
                collisionRectangle = fire.returnCollisionRectangle();
            }
            else
            {
                collisionRectangle = big.returnCollisionRectangle();
            }

            return collisionRectangle;
        }

        public void setDrawColor(Color color)
        {
            if (mario.Small)
            {
                small.setColorForDrawing(color);
            }
            else if (mario.Fire)
            {
                fire.setColorForDrawing(color);
            }
            else
            {
                big.setColorForDrawing(color);
            }
        }
    }
}
