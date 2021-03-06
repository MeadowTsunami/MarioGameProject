﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class GoombaDamagedSprite:ISprite
    {
        private AnimatedSprite AnimatedDamGoomba;
        private bool FacingRight = true;
        private Vector2 location;
        public Vector2 Location
        {
            get { return location; }
            set { location = value; }
        }

        public GoombaDamagedSprite(Texture2D goombaDamSpritesheet,Vector2 location)
        {
            this.location = location;
            AnimatedDamGoomba = new AnimatedSprite(goombaDamSpritesheet, UtilityClass.one, UtilityClass.two, location, UtilityClass.enemyTotalFramesAndMarioFlagpoleTotalFrames);


        }
        public void Update()
        {
            AnimatedDamGoomba.Update();

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            AnimatedDamGoomba.Draw(spriteBatch, location, cameraLoc, FacingRight);

        }

        public Rectangle returnCollisionRectangle()
        {
            return new Rectangle(UtilityClass.zero, UtilityClass.zero, UtilityClass.zero, UtilityClass.zero);
        }
    }
}
