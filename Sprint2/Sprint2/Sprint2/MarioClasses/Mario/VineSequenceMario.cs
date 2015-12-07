﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class VineSequenceMario
    {
        private VineSequenceMarioSprite VineMarioSprite;
        private Vector2 location;
        private bool smallMario;
        public bool attop;
        private bool climbinganimation;
        private float slideSpeed;
        bool sequencefinished;
        public bool SequenceFinished
        {
            get { return sequencefinished; }
            set { sequencefinished = value; }
        }
        public VineSequenceMario(Mario mario, bool smallMario, bool fireMario, bool iceMario, float elapsedtime)
        {
            this.location = mario.Location;
            this.smallMario = smallMario;
            sequencefinished = false;
            climbinganimation = true;
            slideSpeed = UtilityClass.slideSpeed;
            VineMarioSprite = new VineSequenceMarioSprite(location, smallMario, fireMario, iceMario);
        }
        private void SlideUpVine()
        {
            if (smallMario)
            {
                if (location.Y > UtilityClass.TopOfScreen)
                { location.Y -= slideSpeed; }
                else
                {
                    attop = true;
                }
            }
            else
            {
                if (location.Y > UtilityClass.TopOfScreen)
                { location.Y -= slideSpeed; }
                else
                {
                    attop = true;
                }
            }
        }
        public void Update()
        {
            VineMarioSprite.Update();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc, SpriteFont font)
        {
            if (climbinganimation)
            {
                if (!attop)
                {
                    SlideUpVine();
                    VineMarioSprite.MarioVineDrawFacingRight(location, spriteBatch, cameraLoc);
                }
                else
                {
                    sequencefinished = true;
                }
            }           
        }
    }
}