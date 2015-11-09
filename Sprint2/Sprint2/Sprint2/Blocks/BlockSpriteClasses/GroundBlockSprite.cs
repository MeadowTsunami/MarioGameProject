﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class GroundBlockSprite : ISprite
    {
        private Texture2D groundBlockSpriteSheet;
        private Vector2 location;
        private Rectangle collisionRectangle;
        private int spriteSheetSpriteSize;

        public GroundBlockSprite(Vector2 location)
        {
            groundBlockSpriteSheet = BlockSpriteTextureStorage.CreateGroundBlockSprite();
            this.location = location;
            spriteSheetSpriteSize = groundBlockSpriteSheet.Width;
            collisionRectangle = new Rectangle((int)location.X, (int)location.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);
        }
        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            Rectangle sourceRectangle = new Rectangle(spriteSheetSpriteSize*0, 0, spriteSheetSpriteSize, spriteSheetSpriteSize);
            Rectangle destinationRectangle = new Rectangle((int)location.X - (int)cameraLoc.X, (int)location.Y - (int)cameraLoc.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);
            
            spriteBatch.Begin();
            spriteBatch.Draw(groundBlockSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
