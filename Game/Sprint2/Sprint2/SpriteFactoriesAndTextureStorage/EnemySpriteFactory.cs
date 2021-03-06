﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public static class EnemySpriteFactory
    {
        private static Texture2D goombaSpritesheet;
        private static Texture2D goombaDamagedSpritesheet;
        private static Texture2D koopaSpritesheet;
        private static Texture2D koopaShellSpritesheet;

		public static void Load(ContentManager content)
		{
			goombaSpritesheet = content.Load<Texture2D>(UtilityClass.goombaSpriteSheet);
            goombaDamagedSpritesheet = content.Load<Texture2D>(UtilityClass.goombaDamagedSpriteSheet);
            koopaSpritesheet = content.Load<Texture2D>(UtilityClass.koopaSpriteSheet); 
            koopaShellSpritesheet = content.Load<Texture2D>(UtilityClass.koopaShellSpriteSheet);

		}
		
		public static Texture2D CreateGoombaSprite()
		{
			return goombaSpritesheet;
		}
        public static Texture2D CreateGoombaDamangedSprite()
        {
            return goombaDamagedSpritesheet;
        }
		
		public static Texture2D CreateKoopaSprite()
		{
			return koopaSpritesheet;
		}
        public static Texture2D CreateKoopaDamagedSprite()
        {
            return koopaShellSpritesheet;
        }

        
    }
}
