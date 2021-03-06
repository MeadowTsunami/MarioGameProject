﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public interface IEnemyState
    {
        void Draw(SpriteBatch spritebatch, Vector2 cameraLoc);
        void Update();
        void TakeDamage();
        void SetDrawColor(Color color);
        Rectangle returnStateCollisionRectangle();
    }
}
