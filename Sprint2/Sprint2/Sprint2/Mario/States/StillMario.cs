﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KrisWengersSprint0
{
    public class MarioStill : IPlayerState
    {
        private Mario mario;
        public MarioStill(Mario mario)
        {
            this.mario = mario;
            if (mario.small)
            {
                if (mario.fire)
                {
                    //Set mario sprite to small still fire
                }
                if (mario.star)
                {
                    //Set mario sprite to small still star
                }
            }
            else //mario is big
            {
                if (mario.fire)
                {
                    //Set mario sprite to big still fire
                }
                if (mario.star)
                {
                    //Set mario sprite to big still star
                }
            }
            
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