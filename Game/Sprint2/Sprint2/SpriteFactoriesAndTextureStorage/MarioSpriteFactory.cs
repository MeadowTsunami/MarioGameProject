﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Sprint2
{
    public static class MarioSpriteFactory
    {
        private static Texture2D marioSmallStill;
        private static Texture2D marioSmallRunning;
        private static Texture2D marioSmallJumping;
        private static Texture2D marioSmallChangeDirection;

        private static Texture2D marioBigStill;
        private static Texture2D marioBigRunning;
        private static Texture2D marioBigJumping;

        private static Texture2D marioFireStill;
        private static Texture2D marioFireStillShoot;
        private static Texture2D marioFireRunning;
        private static Texture2D marioFireRunningShoot;
        private static Texture2D marioFireJumping;
        private static Texture2D marioFireDuck;
        private static Texture2D marioFireChangeDirection;

        private static Texture2D marioIceStill;
        private static Texture2D marioIceStillShoot;
        private static Texture2D marioIceRunning;
        private static Texture2D marioIceRunningShoot;
        private static Texture2D marioIceJumping;
        private static Texture2D marioIceDuck;
        private static Texture2D marioIceChangeDirection;

        private static Texture2D marioDuck;
        private static Texture2D marioDying;
        private static Texture2D marioBigChangeDirection;

        private static Texture2D marioSmallFlagpole;
        private static Texture2D marioBigFlagpole;
        private static Texture2D marioFireFlagpole;
        private static Texture2D marioIceFlagpole;

        public static void Load(ContentManager content)
        {
            marioSmallStill = content.Load<Texture2D>(UtilityClass.marioSmallStillSpriteSheet);
            marioSmallRunning = content.Load<Texture2D>(UtilityClass.marioSmallRunningSpriteSheet);
            marioSmallJumping = content.Load<Texture2D>(UtilityClass.marioSmallJumpingSpriteSheet);
            marioSmallChangeDirection = content.Load<Texture2D>(UtilityClass.marioSmallChangeDirectionSpriteSheet);

            marioBigStill = content.Load<Texture2D>(UtilityClass.marioBigStillSpriteSheet);
            marioBigRunning = content.Load<Texture2D>(UtilityClass.marioBigRunningSpriteSheet);
            marioBigJumping = content.Load<Texture2D>(UtilityClass.marioBigJumpingSpriteSheet);
            marioBigChangeDirection = content.Load<Texture2D>(UtilityClass.marioBigChangeDirectionSpriteSheet);

            marioFireStill = content.Load<Texture2D>(UtilityClass.marioFireStillSpriteSheet);
            marioFireStillShoot = content.Load<Texture2D>(UtilityClass.marioFireStillSpriteSheet);
            marioFireRunning = content.Load<Texture2D>(UtilityClass.marioFireRunningSpriteSheet);
            marioFireRunningShoot = content.Load<Texture2D>(UtilityClass.marioFireRunningSpriteSheet);
            marioFireJumping = content.Load<Texture2D>(UtilityClass.marioFireJumpingSpriteSheet);
            marioFireDuck = content.Load<Texture2D>(UtilityClass.marioFireDuckSpriteSheet);
            marioFireChangeDirection = content.Load<Texture2D>(UtilityClass.marioFireChangeDirectionSpriteSheet);

            marioIceStill = content.Load<Texture2D>(UtilityClass.marioIceStillSpriteSheet);
            marioIceStillShoot = content.Load<Texture2D>(UtilityClass.marioIceStillSpriteSheet);
            marioIceRunning = content.Load<Texture2D>(UtilityClass.marioIceRunningSpriteSheet);
            marioIceRunningShoot = content.Load<Texture2D>(UtilityClass.marioIceRunningSpriteSheet);
            marioIceJumping = content.Load<Texture2D>(UtilityClass.marioIceJumpingSpriteSheet);
            marioIceDuck = content.Load<Texture2D>(UtilityClass.marioIceDuckSpriteSheet);
            marioIceChangeDirection = content.Load<Texture2D>(UtilityClass.marioIceChangeDirectionSpriteSheet);

            marioDuck = content.Load<Texture2D>(UtilityClass.marioDuckSpriteSheet);
            marioDying = content.Load<Texture2D>(UtilityClass.marioDyingSpriteSheet);

            marioSmallFlagpole = content.Load<Texture2D>(UtilityClass.marioSmallFlagpoleSpriteSheet);
            marioBigFlagpole = content.Load<Texture2D>(UtilityClass.marioBigFlagpoleSpriteSheet);
            marioFireFlagpole = content.Load<Texture2D>(UtilityClass.marioFireFlagpoleSpriteSheet);
            marioIceFlagpole = content.Load<Texture2D>(UtilityClass.marioIceFlagpoleSpriteSheet);
        }

        public static Texture2D CreateMarioBigFlagpoleSprite()
        {

            return marioBigFlagpole;
        }

        public static Texture2D CreateMarioFireFlagpoleSprite()
        {

            return marioFireFlagpole;
        }
        public static Texture2D CreateMarioIceFlagpoleSprite()
        {

            return marioIceFlagpole;
        }

        public static Texture2D CreateMarioSmallFlagpoleSprite()
        {

            return marioSmallFlagpole;
        }

        public static Texture2D CreateMarioSmallStillSprite()
        {
            return marioSmallStill;
        }
        public static Texture2D CreateMarioSmallRunningSprite()
        {

            return marioSmallRunning;
        }
        public static Texture2D CreateMarioSmallJumpingSprite()
        {
            return marioSmallJumping;
        }

        public static Texture2D CreateMarioSmallChangeDirectionSprite()
        {

            return marioSmallChangeDirection;
        }
        public static Texture2D CreateMarioBigStillSprite()
        {

            return marioBigStill;
        }
        public static Texture2D CreateMarioBigRunningSprite()
        {

            return marioBigRunning;
        }
        public static Texture2D CreateMarioBigJumpingSprite()
        {

            return marioBigJumping;
        }
        public static Texture2D CreateMarioBigChangeDirectionSprite()
        {

            return marioBigChangeDirection;
        }
        public static Texture2D CreateMarioFireStillSprite()
        {

            return marioFireStill;
        }
        public static Texture2D CreateMarioFireStillShootSprite()
        {

            return marioFireStillShoot;
        }
        public static Texture2D CreateMarioFireRunningSprite()
        {

            return marioFireRunning;
        }
        public static Texture2D CreateMarioFireRunningShootSprite()
        {

            return marioFireRunningShoot;
        }
        public static Texture2D CreateMarioFireChangeDirectionSprite()
        {

            return marioFireChangeDirection;
        }
        public static Texture2D CreateMarioFireJumpingSprite()
        {

            return marioFireJumping;
        }
        public static Texture2D CreateMarioFireDuckSprite()
        {

            return marioFireDuck;
        }
        public static Texture2D CreateMarioIceStillSprite()
        {

            return marioIceStill;
        }
        public static Texture2D CreateMarioIceStillShootSprite()
        {

            return marioIceStillShoot;
        }
        public static Texture2D CreateMarioIceRunningSprite()
        {

            return marioIceRunning;
        }
        public static Texture2D CreateMarioIceRunningShootSprite()
        {

            return marioIceRunningShoot;
        }
        public static Texture2D CreateMarioIceChangeDirectionSprite()
        {

            return marioIceChangeDirection;
        }
        public static Texture2D CreateMarioIceJumpingSprite()
        {

            return marioIceJumping;
        }
        public static Texture2D CreateMarioIceDuckSprite()
        {

            return marioIceDuck;
        }
        public static Texture2D CreateMarioDuckSprite()
        {

            return marioDuck;
        }

        public static Texture2D CreateMarioDyingSprite()
        {
            return marioDying;
        }
    }


}
