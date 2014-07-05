﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dawn.Engine.Manager
{
    class EngineManager : EngineObject
    {
        public override string ObjectClassName() { return Define.EngineClassName.EngineManager(); }
        private AudioManager _Audio;
        private DebugManager _Debug;
        private GraphicsManager _Graphics;
        private InputManager _Input;
        private DataManager _Data;
		private ThreadManager _Threads;
        public AudioManager Audio { get { return _Audio;} }
        public DebugManager Debug { get { return _Debug; } }
        public GraphicsManager Graphics { get { return _Graphics; } }
        public InputManager Input { get { return _Input; } }
        public SceneManager Scenes { get { return _Graphics.Scenes; } }
        public DataManager Data { get { return _Data; } }
		public CacheManager Cache { get { return _Data.Cache; } }
		public ThreadManager Threads { get { return _Threads; } }
		public GameDawn Game { get { return Program.Game; } }

		public event SimpleEventHandler Start;
        public EngineManager()
        {
            _Audio = new AudioManager();
            _Debug = new DebugManager();
            _Graphics = new GraphicsManager();
            _Input = new InputManager();
            _Data = new DataManager();
        }

		protected void OnStart()
		{
			if (Start != null)
			{
				EventArgs e=new EventArgs();
				Start(this, e);
			}
		}

		~EngineManager()
		{

		}

        public void Initialize()
        {
            _Audio.Initialize();
            _Debug.Initialize();
            _Graphics.Initialize();
            _Input.Initialize();
            _Data.Initialize();

			OnStart();
        }
        public void Update()
        {


            Audio.Update();
			Graphics.Update();
        }
    }
}