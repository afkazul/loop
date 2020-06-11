using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ImGuiNET;

namespace loupe
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager Graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _dungeonMap;
        private Texture2D _playerExampleSprite;
        private Texture2D _enemyExampleSprite;
        public static Player P;
        private Enemy _e;
        //private Magic _m;
        private static ContentManager _conman;
        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Graphics.PreferredBackBufferWidth = 625;
            Graphics.PreferredBackBufferHeight = 595;
            Console.WriteLine(_conman);
        }

        protected override void Initialize()
        {
            // Add your initialization logic here
            P = new Player();
            _e = new Enemy();
            //_m = new Magic();
            _conman = Content;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _dungeonMap = Content.Load<Texture2D>("untitled1");
            _playerExampleSprite = Content.Load<Texture2D>("necromancer_idle_anim_f0");
            _enemyExampleSprite = Content.Load<Texture2D>("tiny_zombie_idle_anim_f1");

            // Use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Add your update logic here
            P.Move(gameTime, Graphics, _playerExampleSprite);
            _e.Move(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_dungeonMap, new Rectangle(0, 0, 640, 640), Color.White);
            P.Draw(_spriteBatch, _playerExampleSprite);
            _e.Draw(_spriteBatch, _enemyExampleSprite);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}