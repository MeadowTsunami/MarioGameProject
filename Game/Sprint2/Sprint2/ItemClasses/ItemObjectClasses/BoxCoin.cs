﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class BoxCoin : IItemObjects
    {
        private NonPlayerScoreItem score;
        private ISprite boxCoinSprite;
        private ItemType type;
        private Vector2 location;
        private Vector2 velocity;
        private float moveSpeed;
        private float decayRate;
        private int timer;
        private bool animate;
        private bool testForCollision;
        private AutonomousPhysicsObject rigidbody;

        public BoxCoin(int locX, int locY)
        {
            score = new NonPlayerScoreItem(UtilityClass.coinScore, false);
            location = new Vector2(locX, locY);
            boxCoinSprite = new BoxCoinSprite(location);
            type = ItemType.BoxCoin;
            testForCollision =true;
            moveSpeed = UtilityClass.coinMoveSpeed;
            decayRate = UtilityClass.coindecayRate;
            animate = true;
            timer = UtilityClass.CoinTimer;
            rigidbody = new AutonomousPhysicsObject();
        }

        public void Update()
        {
            if (animate)
            {
                if (timer > UtilityClass.zero)
                {
                    moveSpeed += decayRate;
                    velocity.Y = moveSpeed;
                    location = new Vector2(location.X, location.Y + velocity.Y);
                    timer--;
                }
                else
                {
                    setCollisionRectangle(new Rectangle(UtilityClass.zero, UtilityClass.zero, UtilityClass.zero, UtilityClass.zero));
                }
            }
            if (testForCollision)
            {
                ((BoxCoinSprite)boxCoinSprite).Location = location;
            }
            boxCoinSprite.Update();
        }

        public NonPlayerScoreItem ScoreData()
        {
            return score;
        }
        public ItemType returnItemType()
        {
            return type;
        }
        public Rectangle returnCollisionRectangle()
        {
            return new Rectangle(UtilityClass.zero, UtilityClass.zero, UtilityClass.zero, UtilityClass.zero);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            boxCoinSprite.Draw(spriteBatch, cameraLoc);
        }

        public void setCollisionRectangle(Rectangle collisionRectangle)
        {
            testForCollision = false;
            boxCoinSprite = new UsedItemSprite(location);
        }

        public bool checkForCollisionTestFlag()
        {
            return testForCollision;
        }
        public Vector2 returnLocation()
        {
            return location;
        }
        public void updateLocation(Vector2 sentLocation)
        {
            location = sentLocation;
        }

        public AutonomousPhysicsObject RigidBody()
        {
            return rigidbody;
        }
    }
}
