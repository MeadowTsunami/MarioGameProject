﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace KrisWengersSprint0
{
    public class Mario 
    {
        public bool facingRight;
        public bool small;
        public bool falling;
        public bool fire;
        public bool star;
        public float velX;
        public float velY;
        public Vector2 location;
        public IPlayerState state;
        public Mario()
        {
            state = new MarioStill(this);
        }
        void Still()
        {
            state.Still();
        }
        void Running()
        {
            state.Running();
        }
        void ChangeDirection()
        {
            state.ChangeDirection();
        }
        void Jump()
        {
            state.Jump();
        }
        void ShootFireball()
        {
            state.ShootFireball();
        }
        void Duck()
        {
            state.Duck();
        }
        void Dying()
        {
            state.Dying();
        }

        /*void Draw(spriteBatch spriteBatch)
         * {
         *  if (!facingRight)
         *  {
         *      sprite = flipped sprite   
         *  }
         *  Draw(sprite, location) 
         * 
         * 
         * */
    }
}