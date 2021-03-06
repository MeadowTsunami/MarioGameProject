﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class HiddenBlock:IBlock
    {
        private ISprite sprite;
        private BlockType type;
        private bool testForCollision;
        private bool noLongerSpecialized;
        private bool dispenseItemFlag;
        private Vector2 location;
        
        public HiddenBlock(int locX,int locY,BlockType type)
        {
            location = new Vector2(locX, locY);
            sprite = new HiddenBlockSprite(location);
            this.type = type;
            testForCollision=true;
            noLongerSpecialized = false;
            dispenseItemFlag = true;
        }
        public void Update()
        {
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            sprite.Draw(spriteBatch, cameraLoc);
        }

        public BlockType returnBlockType()
        {
            return type;
        }

        public Rectangle returnCollisionRectangle()
        {
            return sprite.returnCollisionRectangle();
        }
        public bool checkForCollisionTestFlag()
        {
            return testForCollision;
        }

        public void removeFromTestingCollision()
        {
            testForCollision = false;
        }

        public bool checkForSpecalizedSideCollision()
        {
            return noLongerSpecialized;
        }

        public void useHiddenBlock()
        {
            ((HiddenBlockSprite)sprite).usedHiddenBlock();
        }
        public IItemObjects spawnOneUp()
        {
            SoundEffectFactory.Item();
            dispenseItemFlag = false;
            return new OneUpMushroom((int)location.X, (int)location.Y - UtilityClass.itemOffSet);
        }

        public bool dispenseItem()
        {
            return dispenseItemFlag;
        }
        public void unSpeaclize()
        {
            noLongerSpecialized = true;
        }
    }
}
