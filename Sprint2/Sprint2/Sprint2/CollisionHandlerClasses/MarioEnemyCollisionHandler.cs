﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class MarioEnemyCollisionHandler
    {
        public MarioEnemyCollisionHandler()
        {

        }
        public void HandleCollision(Mario mario, IEnemyObject enemy, ICollision side)
        {
            ICommand command;
            if (!(side.returnCollisionSide().Equals(CollisionSide.None)))
            {
                HandleMovement(mario, enemy, side);
            }

            if (side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                //Mario takes no damage
                //Enemy is damaged/killed
                command = new MarioHitsEnemyCollision(enemy);
                command.Execute();
            }
            else if (!(side.returnCollisionSide().Equals(CollisionSide.None)))
            {
                command = new EnemyHitsMarioCollision(mario,enemy);
                command.Execute();
            }
        }

        private void HandleMovement(Mario mario, IEnemyObject enemy,ICollision side)
        {
            Rectangle enemyRectangle= enemy.returnCollisionRectangle();
            Rectangle marioRectangle = mario.returnCollisionRectangle();
            Rectangle intersectionRectangle = Rectangle.Intersect(marioRectangle, enemyRectangle);
            int locationDiffToChange = 0;

            if (side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newMarioX = (int)mario.Location.X - locationDiffToChange;
                mario.Location = new Vector2(newMarioX, mario.Location.Y);
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Right))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newMarioX = (int)mario.Location.X + locationDiffToChange;
                mario.Location = new Vector2(newMarioX, mario.Location.Y);
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                locationDiffToChange = intersectionRectangle.Height;
                int newMarioY = (int)mario.Location.Y - locationDiffToChange;
                mario.Location = new Vector2(mario.Location.X, newMarioY);
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Bottom))
            {
                locationDiffToChange = intersectionRectangle.Height;
                int newMarioY = (int)mario.Location.Y + locationDiffToChange;
                mario.Location = new Vector2(mario.Location.X, newMarioY);
            }
        }
    }
}