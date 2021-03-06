﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class MarioHiddenBlockCollisionCommand:ICommand
    {
        private IBlock block;
        private Game1 game;
        public MarioHiddenBlockCollisionCommand(IBlock block,Game1 game)
        {
            this.block = block;
            this.game = game;
        }
        public void Execute()
        {
            ((HiddenBlock)block).useHiddenBlock();
            ((HiddenBlock)block).unSpeaclize();
            if (((HiddenBlock)block).dispenseItem())
            {
                IItemObjects oneUp = ((HiddenBlock)block).spawnOneUp();
                game.levelStore.itemList.Add(oneUp);
            }
        }
    }
}
