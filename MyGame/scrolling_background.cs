using GameEngine;
using SFML.Graphics;
using SFML.System;
using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Numerics;
using System.Runtime.InteropServices;

namespace MyGame
{
    public class scrolling_background : GameObject
    {
        private const float Speed = 0.45f;

        private readonly Sprite _sprite = new Sprite();

         public scrolling_background(Vector2f pos)
        {
            _sprite.Texture = Game.GetTexture("Resources/background.png");
            _sprite.Position = pos;
        }

         public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }

        public override void Update(Time elapsed)
        {
          
            int msElapsed = elapsed.AsMilliseconds();
            Vector2f pos = _sprite.Position;

         if(pos.X < Game.RenderWindow.Size.X * -10)
            {
             MakeDead();
            }
            else
            {
                _sprite.Position = new Vector2f(pos.X - Speed * msElapsed, pos.Y);
            }   
        }
    }
}