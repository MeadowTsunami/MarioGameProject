﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public static class EnemyEnviromentalCollisionHandler
    {
        public static void handleCollision(IEnemyObject enemy, IEnviromental enviromental,ICollision side)
        {
            if (!(side.returnCollisionSide().Equals(CollisionSide.None)))
            {
                handleEnemyMovement(enemy, enviromental, side);
            }
        }

        private static void handleEnemyMovement(IEnemyObject enemy,IEnviromental enviromental,ICollision side)
        {
            Rectangle enviromentalRectangle = enviromental.returnCollisionRectangle();
            Rectangle enemyRectangle = enemy.returnCollisionRectangle();
            Rectangle intersectionRectangle = Rectangle.Intersect(enemyRectangle, enviromentalRectangle);
            Vector2 enemyLocation = enemy.returnLocation();
            int locationDiffToChange = UtilityClass.zero;

            if (side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newEnemyX = (int)enemyLocation.X - locationDiffToChange;
                enemy.updateLocation(new Vector2((newEnemyX), enemyLocation.Y));
                enemy.RightCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Right))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newEnemyX = (int)enemyLocation.X + locationDiffToChange;
                enemy.updateLocation(new Vector2((newEnemyX), enemyLocation.Y));
                enemy.LeftCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                locationDiffToChange = intersectionRectangle.Height;
                int newEnemyY = (int)enemyLocation.Y - locationDiffToChange;
                enemy.updateLocation(new Vector2(enemyLocation.X, newEnemyY));
                enemy.BottomCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Bottom))
            {
                locationDiffToChange = intersectionRectangle.Height;
                int newEnemyY = (int)enemyLocation.Y + locationDiffToChange;
                enemy.updateLocation(new Vector2(enemyLocation.X, newEnemyY)); 
                enemy.TopCollision();
            }
        }
    }
}
