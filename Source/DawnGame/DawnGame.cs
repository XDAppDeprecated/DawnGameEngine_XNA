﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dawn;

namespace DawnGame
{
	class DawnGame : Dawn.Engine.Basic.Game
	{
		public override void Main()
		{
			base.Main();
			DGE.Scenes.Push<Game.Scene.Scene_Test>();
		}
	}
}