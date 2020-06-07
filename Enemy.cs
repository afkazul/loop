using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace loupe
{
    public class Enemy
    {
        private static Vector2 _position;
        private static float _speed;
        public Enemy()
        {
            Console.WriteLine("sample text");
            _position = new Vector2(Game1.Graphics.PreferredBackBufferWidth / 2 + 50, Game1.Graphics.PreferredBackBufferHeight / 2 + 50);
            _speed = 100f;
        }
        public void Draw(SpriteBatch spriteBatch, Texture2D sprite)
        {
            spriteBatch.Draw(sprite, _position, null, Color.White, 0f, Vector2.Zero, 2.5f, SpriteEffects.None, 0f);
        }

        public void Move(GameTime gameTime)
        {
            if(_position.X > Game1.P.Position.X)
                _position.X -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(_position.X < Game1.P.Position.X)
                _position.X += _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(_position.Y > Game1.P.Position.Y)
                _position.Y -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(_position.Y < Game1.P.Position.Y)
                _position.Y += _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}