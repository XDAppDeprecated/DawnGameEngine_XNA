﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Windows.Forms;

namespace Dawn.Engine.Define
{
	static class GameWindow
	{
		public static int Width() { return 1024; }
		public static int Height() { return 768; }

		public static Color BackgroundColor() { return Color.Black; }

		public static int ScreenX()
		{
			return Screen.AllScreens[ScreenID()].Bounds.X;
		}
		public static int ScreenY()
		{
			return Screen.AllScreens[ScreenID()].Bounds.Y;
		}

		public static int ScreenWidth()
		{
			return Screen.AllScreens[ScreenID()].Bounds.Width;
		}

		public static int ScreenHeight()
		{
			return Screen.AllScreens[ScreenID()].Bounds.Height;
		}

		public static int StartPositionX(Microsoft.Xna.Framework.GameWindow window)
		{
			var form = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(window.Handle);
			//int Position_X = (Define.GameWindow.ScreenWidth() - form.Width) / 2 + ScreenX();
			int Position_X = (Define.GameWindow.ScreenWidth() - form.Width) / 2 + ScreenX();
			return Position_X;
		}

		public static int StartPositionY(Microsoft.Xna.Framework.GameWindow window)
		{
			var form = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(window.Handle);
			int Position_Y = (Define.GameWindow.ScreenHeight() - form.Height) / 2 + ScreenY();
			return Position_Y;
		}

		public static bool StartAtSecondScreen()
		{
#if DEBUG
   return true;
#else
			return false;
#endif
		}

		public static int ScreenID()
		{
			if (StartAtSecondScreen())
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}
	}
}
