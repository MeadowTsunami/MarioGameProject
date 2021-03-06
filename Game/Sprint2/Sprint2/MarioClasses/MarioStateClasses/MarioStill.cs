﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class MarioStill: IMarioState
    {
        private Mario mario;
        AnimatedSprite big;
        AnimatedSprite small;
        AnimatedSprite fire;
        AnimatedSprite ice;
        public MarioStill(Mario mario)
        {
            this.mario = mario;
            big = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigStillSprite(), UtilityClass.one, UtilityClass.one, mario.Location, UtilityClass.generalTotalFramesAndSpecializedRows);
            small = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallStillSprite(), UtilityClass.one, UtilityClass.one, mario.Location, UtilityClass.generalTotalFramesAndSpecializedRows);
            fire = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireStillSprite(), UtilityClass.one, UtilityClass.one, mario.Location, UtilityClass.generalTotalFramesAndSpecializedRows);
            ice = new AnimatedSprite(MarioSpriteFactory.CreateMarioIceStillSprite(), UtilityClass.one, UtilityClass.one, mario.Location, UtilityClass.generalTotalFramesAndSpecializedRows);
        }
        public void Update()
        {
            if (mario.Fire)
            {
                fire.Update();
            }
            if (mario.Ice)
            {
                ice.Update();
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
            if (mario.Small)
            {
                small.Draw(spriteBatch, mario.Location, cameraLoc, mario.FacingRight);
            }
            else if (mario.Fire)
            {
                fire.Draw(spriteBatch, mario.Location, cameraLoc, mario.FacingRight);
            }
            else if (mario.Ice)
            {
                ice.Draw(spriteBatch, mario.Location, cameraLoc, mario.FacingRight);
            }
            else
            {
                big.Draw(spriteBatch, mario.Location, cameraLoc, mario.FacingRight);
            }
        }
        public MarioState State()
        {
            return MarioState.Still;
        }
        public void Still()
        {
            
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
            mario.State = new MarioJump(mario);
        }
        public void ShootFireball()
        {
            mario.State = new MarioShootFireball(mario);
        }
        public void ShootIceball()
        {
            mario.State = new MarioShootIceball(mario);
        }
        public void Duck()
        {
            mario.State = new MarioDuck(mario);
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
            else if (mario.Ice)
            {
                collisionRectangle = ice.returnCollisionRectangle();
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
            else if (mario.Ice)
            {
                ice.setColorForDrawing(color);
            }
            else
            {
                big.setColorForDrawing(color);
            }
        }
    }
}
