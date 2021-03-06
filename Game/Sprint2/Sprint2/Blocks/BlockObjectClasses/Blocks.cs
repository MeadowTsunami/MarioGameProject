﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class Blocks:IBlock
    {
        private ISprite sprite;
        private BlockType type;
        private bool testForCollision;
        private bool noLongerSpecialized;
        
        public Blocks(int locX,int locY,BlockType type)
        {
            Vector2 location = new Vector2(locX, locY);
            if(type.Equals(BlockType.Brick)){
                sprite = new BrickBlockSprite(location);
            }
            else if(type.Equals(BlockType.Ground))
            {
                sprite = new GroundBlockSprite(location);
            }
            else if (type.Equals(BlockType.Hidden))
            {
                sprite = new HiddenBlockSprite(location);
            }
            else if (type.Equals(BlockType.Platforming))
            {
                sprite = new PlatformingBlockSprite(location);
            }
            else if (type.Equals(BlockType.Question))
            {
                sprite = new QuestionBlockSprite(location);
            }
            else if (type.Equals(BlockType.BlueBrick))
            {
                sprite = new BlueBrickBlockSprite(location);
            }
            else if (type.Equals(BlockType.BlueGround))
            {
                sprite = new BlueGroundBlockSprite(location);
            }

            this.type = type;
            testForCollision=true;
            noLongerSpecialized = false;
        }
        public void Update()
        {
            sprite.Update();
            noLongerSpecialized = true;
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
    }
}
