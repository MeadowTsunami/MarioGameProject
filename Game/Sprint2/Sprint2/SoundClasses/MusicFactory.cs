﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Sprint2
{
    public static class MusicFactory
    {
        private static Song mainTheme;
        private static Song underworldTheme;
        private static Song starMan;
        private static Song dead;
        private static Song gameOver;

           
        public static void Load(ContentManager content){
            mainTheme = content.Load<Song>(UtilityClass.mainTheme);
            underworldTheme = content.Load<Song>(UtilityClass.underworldTheme);
            starMan = content.Load<Song>(UtilityClass.starManTheme);
            dead = content.Load<Song>(UtilityClass.deadTheme);
            gameOver = content.Load<Song>(UtilityClass.gameOverTheme);

            
        }

        public static void MainTheme()
        {
            MediaPlayer.Play(mainTheme);
            MediaPlayer.IsRepeating = true;
        }
        public static void UnderworldTheme()
        {
            MediaPlayer.Play(underworldTheme);
            MediaPlayer.IsRepeating = true;
        }

        public static void StarMan()
        {
            MediaPlayer.Play(starMan);
            MediaPlayer.IsRepeating = true;
        }
        public static void Dead()
        {
            MediaPlayer.Play(dead);
            MediaPlayer.IsRepeating = false;           
        }
        public static void GameOver()
        {
            MediaPlayer.Play(gameOver);
            MediaPlayer.IsRepeating = false;

        }
        
    }
}
