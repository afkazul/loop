using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Sprites;

namespace loupe
{
    public class Player
    {
        //private static Texture2D _example;
        public Vector2 Position;
        private static float _speed;
        public Player()
        {
            Console.WriteLine("sample text");
            Position = new Vector2(Game1.Graphics.PreferredBackBufferWidth / 2, Game1.Graphics.PreferredBackBufferHeight / 2);
            _speed = 200f;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D sprite)
        {
            spriteBatch.Draw(sprite, Position, null, Color.White, 0f, Vector2.Zero, 2.5f, SpriteEffects.None, 0f);
        }

        public void Move(GameTime gameTime, GraphicsDeviceManager graphics, Texture2D sprite)
        {
            var kstate = Keyboard.GetState();
 
            if (kstate.IsKeyDown(Keys.W))
                Position.Y -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
 
            if(kstate.IsKeyDown(Keys.S))
                Position.Y += _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
 
            if (kstate.IsKeyDown(Keys.A))
                Position.X -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
 
            if(kstate.IsKeyDown(Keys.D))
                Position.X += _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(Position.X > graphics.PreferredBackBufferWidth - sprite.Width / 2)
                Position.X = graphics.PreferredBackBufferWidth - sprite.Width / 2;    
            else if(Position.X < sprite.Width / 2)
                Position.X = sprite.Width / 2;
 
            if(Position.Y > graphics.PreferredBackBufferHeight - sprite.Height / 2)
                Position.Y = graphics.PreferredBackBufferHeight - sprite.Height / 2;
            else if(Position.Y < sprite.Height / 2)
                Position.Y = sprite.Height / 2;
        }
    }
}