﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class BrickBlock:IBlock
    {
        private NonPlayerScoreItem score;
        private ISprite sprite;
        private BlockType type;
        private bool testForCollision;
        private bool noLongerSpecialized;
        private Vector2 location;
        
        public BrickBlock(int locX,int locY,BlockType type)
        {
            location = new Vector2(locX, locY);
            sprite = new BrickBlockSprite(location);
            this.type = type;
            testForCollision=true;
            noLongerSpecialized = false;
            score = new NonPlayerScoreItem(50, false);
        }
        public NonPlayerScoreItem ScoreData()
        {
            return score;
        }
        public void Update()
        {
            sprite.Update();
            noLongerSpecialized = true;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            sprite.Draw(spriteBatch, cameraLoc);
        }

        public BlockType returnBlockType()
        {
            return type;
        }

        public Rectangle returnCollisionRectangle()
        {
            return sprite.returnCollisionRectangle();
        }
        public bool checkForCollisionTestFlag()
        {
            return testForCollision;
        }

        public void removeFromTestingCollision()
        {
            testForCollision = false;
        }

        public bool checkForSpecalizedSideCollision()
        {
            return noLongerSpecialized;
        }

        public void smashBlock()
        {
            SoundEffectFactory.BrickBreak();
            ((BrickBlockSprite)sprite).hasSmashed();
        }

        public void becomeSmashed(ArrayList enviromentalList)
        {
            IEnviromental firstPiece = new BrickPieces((int)location.X-UtilityClass.BrickPieceXAdjustmentSmall, (int)location.Y-UtilityClass.BrickPieceYAdjustment,true);
            IEnviromental secondPiece = new BrickPieces((int)location.X+UtilityClass.BrickPieceXAdjustmentSmall, (int)location.Y-UtilityClass.BrickPieceYAdjustment,false);
            IEnviromental thirdPiece = new BrickPieces((int)location.X-UtilityClass.BrickPieceXAdjustmentBig, (int)location.Y+UtilityClass.BrickPieceYAdjustment, true);
            IEnviromental fourthPiece = new BrickPieces((int)location.X + UtilityClass.BrickPieceXAdjustmentBig, (int)location.Y + UtilityClass.BrickPieceYAdjustment, false);
            enviromentalList.Add(firstPiece);
            enviromentalList.Add(secondPiece);
            enviromentalList.Add(thirdPiece);
            enviromentalList.Add(fourthPiece);
        }
    }
}
