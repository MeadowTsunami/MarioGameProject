﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class OneUpMushroom : IItemObjects
    {
        private ISprite oneUpMushroomSprite;
        private ItemType type;
        private Rectangle collisionRectangle;
        private Vector2 location;
        private Vector2 velocity;
        private float riseSpeed;
        private float slideSpeed;
        private Vector2 gravity;
        private float decayRate;
        private bool testForCollision;
        private bool isFalling;
        private bool applyGravity;
        private bool directionLeft;
        public bool DirectionLeft
        {
            get { return directionLeft; }
            set { directionLeft = value; }
        }
        public Vector2 Gravity
        {
            get { return gravity; }
            set { gravity = value; }
        }
        public OneUpMushroom(int locX, int locY)
        {
            location = new Vector2(locX, locY);
            oneUpMushroomSprite = new OneUpMushroomSprite(location);
            type = ItemType.OneUpMushroom;
            collisionRectangle = oneUpMushroomSprite.returnCollisionRectangle();
            testForCollision=true;
            applyGravity = false;
            riseSpeed = 0.5f;
            slideSpeed = 1.0f;
            gravity.X = 0;
            gravity.Y = 6.0f;
            decayRate = 0.90f;
        }
        public void RiseUp()
        {
            applyGravity = false;
            velocity.X = 0;
            velocity.Y = -riseSpeed;
        }
        public void MoveLeft()
        {
            applyGravity = true;
            isFalling = false;
            velocity.X = -slideSpeed;
        }
        public void MoveRight()
        {
            applyGravity = true;
            isFalling = false;
            velocity.X = slideSpeed;
        }
        public void FallLeft()
        {
            applyGravity = true;
            isFalling = true;
            velocity.X = -slideSpeed;
        }
        public void FallRight()
        {
            applyGravity = true;
            isFalling = true;
            velocity.X = slideSpeed;
        }
        public void StopMoving()
        {
            applyGravity = false;
            isFalling = false;
            velocity.X = 0;
            velocity.Y = 0;
        }
        public void Update()
        {
            if (applyGravity) 
            {
                velocity.Y = 0;
                velocity += gravity; 
            }
            location += velocity;
            if (isFalling) { velocity.X *= decayRate; }
            if (testForCollision)
            {
                ((OneUpMushroomSprite)oneUpMushroomSprite).Location = location;
            }
            oneUpMushroomSprite.Update();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            oneUpMushroomSprite.Draw(spriteBatch, cameraLoc);
        }
        public ItemType returnItemType()
        {
            return type;
        }
        public void setCollisionRectangle(Rectangle sentCollisionRectangle)
        {
            collisionRectangle = sentCollisionRectangle;
            testForCollision=false;
            oneUpMushroomSprite =new UsedItemSprite(location);
        }
        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
        public bool checkForCollisionTestFlag()
        {
            return testForCollision;
        }


        public Vector2 returnLocation()
        {
            return location;
        }
    }
}
