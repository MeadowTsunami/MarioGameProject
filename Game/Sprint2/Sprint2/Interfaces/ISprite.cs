﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public interface ISprite
    {
        void Update();

        void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc);

        Rectangle returnCollisionRectangle();
    }
}
