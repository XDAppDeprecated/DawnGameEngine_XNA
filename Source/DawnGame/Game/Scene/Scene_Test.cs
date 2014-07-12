﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dawn.Engine.Manager;
using Dawn;
using Dawn.Engine;
using System.Diagnostics;

namespace DawnGame.Game.Scene
{
	class Scene_Test : Dawn.Engine.Basic.Scene
	{
		Dawn.Engine.Manager.Processor.FontManager.FontHelper helper;
		public Scene_Test()
		{
		}

		public override void Start()
		{
			base.Start();
			Dawn.Engine.Resource.Audio audios = new Dawn.Engine.Resource.Audio(DGE.Data.Audio("tmp.mp3"));

			Dawn.Engine.Resource.Audio audio = new Dawn.Engine.Resource.Audio(DGE.Data.Audio("3711.mp3"));
            audio.Load();
            DGE.Audio.PlayBGS(audio);
			Dawn.Engine.Basic.ThreadProcessor.ResourceLoadProcessor processor = new Dawn.Engine.Basic.ThreadProcessor.ResourceLoadProcessor(audios);
			System.Threading.Thread threadRes = new System.Threading.Thread(new System.Threading.ThreadStart(processor.Process));
			threadRes.IsBackground = true;
			
			threadRes.Start();
			while (threadRes.ThreadState != System.Threading.ThreadState.Stopped) ;
			//DGE.Audio.PlayBGM((Engine.Resource.Audio)processor.Res);
			DGE.Audio.FadeInPlay(Dawn.Engine.Define.EngineConst.AudioManager_ChannelType.BGM, audios);
			//DGE.Audio.FadeOutStop(Engine.Define.EngineConst.AudioManager_ChannelType.BGM)

			Dawn.Engine.Resource.Font font = new Dawn.Engine.Resource.Font(new Dawn.Engine.Resource.Data.FontFamilyData(new System.Drawing.FontFamily("微软雅黑"), 22, System.Drawing.Color.White, false, false, false));
			font.Load();
			helper = new Dawn.Engine.Manager.Processor.FontManager.FontHelper(font);
		}

		public override void Update()
		{
			DGE.Input.SetBusy(true);
			Trace.WriteLine("Dawn> Render String...");
			Microsoft.Xna.Framework.Graphics.Texture2D tex = helper.DrawStringToTexture("哇咔咔Dawn Game Engine~!!!");
			DGE.Game._SpriteBatch.Draw(tex, new Microsoft.Xna.Framework.Vector2(0, 0), Microsoft.Xna.Framework.Color.White);
			base.Update();
		}

		public override void End()
		{
			DGE.Audio.StopBGS();
			DGE.Audio.StopBGM();
			base.End();
		}
	}
}
