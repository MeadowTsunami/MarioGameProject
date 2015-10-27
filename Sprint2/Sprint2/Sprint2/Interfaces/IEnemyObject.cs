﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public interface IEnemyObject
    {
        bool DirectionLeft
        { get; set; }
        Vector2 Gravity
        { get; set; }
        void MoveLeft();
        void MoveRight();
        void FallLeft();
        void FallRight();
        void StopMoving();
        void Update();

        void Draw(SpriteBatch spriteBatch);
                
        Rectangle returnCollisionRectangle();

        void TakeDamage();

        void updateLocation(Vector2 location);

        Vector2 returnLocation();
    
    }
}
