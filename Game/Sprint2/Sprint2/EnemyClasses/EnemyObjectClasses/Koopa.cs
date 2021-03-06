﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class Koopa: IEnemyObject
    {
        private NonPlayerScoreItem score;
        private Vector2 location;
        private bool directionLeft;
        private AutonomousPhysicsObject rigidbody;
        private IEnemyState state;
        private bool shellForm;
        private bool hurtMario;
        private bool frozen;
        private int freezeCounter;
        private int enemyFreezeTime;

        public IEnemyState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }
        public bool DirectionLeft
        {
            get { return directionLeft; }
            set { directionLeft = value; }
        }

        public void ZeroScoreValue()
        {
            score.ScoreValue = 0;
        }

        public Koopa(int locX, int locY)
        {
            score = new NonPlayerScoreItem(100, true);
            location = new Vector2(locX, locY);
            state = new KoopaHealthy(this);
            rigidbody = new AutonomousPhysicsObject();
            LoadRigidBodyProperties();
            directionLeft = false;
            shellForm = false;
            hurtMario = true;
            frozen = false;
            freezeCounter = UtilityClass.zero;
            enemyFreezeTime = UtilityClass.enemyFreezeTime;
        }

        private void LoadRigidBodyProperties()
        {
            rigidbody.AirFriction = UtilityClass.koopaAirFriction;
            rigidbody.GroundFriction = UtilityClass.koopaGroundFriction;
            rigidbody.GroundSpeed = UtilityClass.koopaGroundSpeed;
            rigidbody.MaxFallSpeed = UtilityClass.koopaMaxFallSpeed;
            rigidbody.Elasticity = UtilityClass.koopaElasticity;
            rigidbody.IsEnabled = false;
        }

        public NonPlayerScoreItem ScoreData()
        {
            return score;
        }
        public void LeftCollision()
        {
            directionLeft = true;
            rigidbody.LeftCollision();
        }
        public void RightCollision()
        {
            directionLeft = false;
            rigidbody.RightCollision();
        }
        public void TopCollision()
        {
           rigidbody.TopCollision();
        }
        public void BottomCollision()
        {
           rigidbody.BottomCollision();
        }
        public AutonomousPhysicsObject GetRigidBody()
        {
            return rigidbody;
        }
        public void Update()
        {
            rigidbody.UpdatePhysics();
            location += rigidbody.Velocity;
            if (frozen)
            {
                state.SetDrawColor(Color.LightSteelBlue);
                freezeCounter++;
                if (freezeCounter > enemyFreezeTime)
                {
                    frozen = false;
                    rigidbody.GroundSpeed = UtilityClass.koopaGroundSpeed;
                    freezeCounter = UtilityClass.zero;
                }
            }
            else
            {
                state.Update();
                state.SetDrawColor(Color.White);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            state.Draw(spriteBatch, cameraLoc);
        }

        public Rectangle returnCollisionRectangle()
        {
            return state.returnStateCollisionRectangle();
        }

        public void TakeDamage()
        {
            state.TakeDamage();
            shellForm = true;
            rigidbody.GroundSpeed = UtilityClass.noMovement;
            hurtMario = false;
            ZeroScoreValue();
        }

        public void TakeDamage(IPlayer mario)
        {
            if (!shellForm) ((Mario)mario).stats.KilledKoopa();
            state.TakeDamage();
            shellForm = true;
            rigidbody.GroundSpeed = UtilityClass.noMovement;
            hurtMario = false;
            ((Mario)mario).ScoreEvent(score);
            ZeroScoreValue();
        }
        public void Freeze()
        {
            frozen = true;
            rigidbody.GroundSpeed = UtilityClass.noMovement;
        }

        public void updateLocation(Vector2 newLocation)
        {
            this.location = newLocation;
        }

        public Vector2 returnLocation()
        {
            return location;
        }
        public bool canHurtOtherEnemies()
        {
            return shellForm;
        }

        public bool canHurtMario()
        {
            return hurtMario;
        }

        public void shellLeftHit()
        {
            rigidbody.GroundSpeed = UtilityClass.koopShellLeftMovement;
            hurtMario = true;
        }

        public void shellRightHit()
        {
            rigidbody.GroundSpeed = UtilityClass.koopaGroundSpeed;
            hurtMario = true;
        }
    }
}
