﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class ProjectileEnviromentalCollisionHandler
    {
        public ProjectileEnviromentalCollisionHandler()
        {

        }
        public void handleCollision(IProjectile projectile,IEnviromental enviromental,ICollision side)
        {
            if (!(side.returnCollisionSide().Equals(CollisionSide.None)))
            {
                handleMovement(projectile, enviromental, side);
            }
        }

        private void handleMovement(IProjectile projectile, IEnviromental enviromental, ICollision side)
        {
            Rectangle projectileRectangle = projectile.returnCollisionRectangle();
            Rectangle enviroRectangle = enviromental.returnCollisionRectangle();
            Rectangle intersectionRectangle = Rectangle.Intersect(enviroRectangle, projectileRectangle);
            Vector2 projectileLocation = projectile.returnLocation();
            int locationDiffToChange = 0;

            if (side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newProjectileX = (int)projectileLocation.X - locationDiffToChange;
                projectile.updateLocation(new Vector2(newProjectileX, projectileLocation.Y));
                projectile.RigidBody().RightCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Right))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newProjectileX = (int)projectileLocation.X + locationDiffToChange;
                projectile.updateLocation(new Vector2(newProjectileX, projectileLocation.Y));
                projectile.RigidBody().LeftCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                locationDiffToChange = intersectionRectangle.Height;
                int newProjectileY = (int)projectileLocation.Y - locationDiffToChange;
                projectile.RigidBody().BottomCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Bottom))
            {
                locationDiffToChange = intersectionRectangle.Height;
                int newProjectileY = (int)projectileLocation.Y + locationDiffToChange;
                projectile.RigidBody().TopCollision();
            }
        }
    }
}
