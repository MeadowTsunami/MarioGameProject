﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public static class StatePuaseAlterationCall
    {
        private static Game1 game;

        public static void setGame(Game1 sentGame)
        {
            game = sentGame;
        }

        public static void Execute()
        {
            game.setStateTransistionTimer(UtilityClass.stateTransistionTimer);
            ICommand marioPause = new StateTransistionPause(game);
            marioPause.Execute();
        }
    }
}
