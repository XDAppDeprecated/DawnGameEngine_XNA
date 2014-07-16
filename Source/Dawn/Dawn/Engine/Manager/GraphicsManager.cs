﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Dawn.Engine.Resource;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Dawn.GameDawn")]
namespace Dawn.Engine.Manager
{
    public class GraphicsManager : EngineObject
    {
        public override string ObjectClassName() { return Define.EngineClassName.GraphicsManager(); }

        private SceneManager _Scenes;


		public event SimpleEventHandler StartUpdate;
		public event SimpleEventHandler PreRender;
		public event SimpleEventHandler PostRender;
		public event SimpleEventHandler EndUpdate;

		public event EventHandler<EventArgs> WhenDeviceChanged;
		public event EventHandler<EventArgs> WhenDeviceChanging;

		private Basic.ThreadProcessor.FPSProcessor fps;
		public Microsoft.Xna.Framework.Graphics.GraphicsDevice Device { get { return DGE.Game._GraphicsDevice; } }
		public Microsoft.Xna.Framework.Graphics.SpriteBatch Canvas { get { return DGE.Game._SpriteBatch; } }
        public SceneManager Scenes { get { return _Scenes; } }
		public double FPS { get { return fps.FPS; } }
        public GraphicsManager()
        {
            _Scenes=new SceneManager();
        }

        public void Initialize()
        {
			_Scenes.Initialize();
			fps = new Basic.ThreadProcessor.FPSProcessor();
        }

		protected void OnStartUpdate()
		{
			if (StartUpdate != null)
			{
				EventArgs e = new EventArgs();
				StartUpdate(this, e);
			}
		}
		protected void OnPreRender()
		{
			if (PreRender != null)
			{
				EventArgs e = new EventArgs();
				PreRender(this, e);
			}
		}
		protected void OnPostRender()
		{
			if (PostRender != null)
			{
				EventArgs e = new EventArgs();
				PostRender(this, e);
			}
		}
		protected void OnEndUpdate()
		{
			if (EndUpdate != null)
			{
				EventArgs e = new EventArgs();
				EndUpdate(this, e);
			}
		}
		public void Update()
		{
			fps.AddFrame();

			OnStartUpdate();
			Device.Clear(Engine.Define.GameWindow.BackgroundColor());
			Canvas.Begin(Microsoft.Xna.Framework.Graphics.SpriteSortMode.BackToFront, Microsoft.Xna.Framework.Graphics.BlendState.AlphaBlend);
			OnPreRender();

			Scenes.Update();

			OnPostRender();
			Canvas.End();
			OnEndUpdate();
		}
		public void Draw(Texture texture, Rectangle destinationRectangle, Color color)
		{
			Canvas.Draw(texture.GetTexture(), destinationRectangle, color);
		}
		public void Draw(Texture texture, Vector2 position, Color color)
		{
			Canvas.Draw(texture.GetTexture(), position, color);
		}
		public void Draw(Texture texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color)
		{
			Canvas.Draw(texture.GetTexture(), destinationRectangle, sourceRectangle, color);
		}
		public void Draw(Texture texture, Vector2 position, Rectangle? sourceRectangle, Color color)
		{
			Canvas.Draw(texture.GetTexture(), position, sourceRectangle, color);
		}
		public void Draw(Texture texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Microsoft.Xna.Framework.Graphics.SpriteEffects effects, float layerDepth)
		{
			Canvas.Draw(texture.GetTexture(), destinationRectangle, sourceRectangle, color, rotation, origin, effects, layerDepth);
		}
		public void Draw(Texture texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, Microsoft.Xna.Framework.Graphics.SpriteEffects effects, float layerDepth)
		{
			Canvas.Draw(texture.GetTexture(), position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth);
		}
		public void Draw(Texture texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, Microsoft.Xna.Framework.Graphics.SpriteEffects effects, float layerDepth)
		{
			Canvas.Draw(texture.GetTexture(), position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth);
		}

		public int Width()
		{
			return Dawn.Engine.Define.GameWindow.Width();
		}

		public int Height()
		{
			return Dawn.Engine.Define.GameWindow.Height();
		}
		
		internal void graphics_DeviceReset(object sender, EventArgs e)
		{
			WhenDeviceChanged(sender, e);
		}
		internal void graphics_DeviceResetting(object sender, EventArgs e)
		{
			WhenDeviceChanging(sender, e);
		}
    }
}
