using GameEngine;
using SFML.Graphics;
using SFML.System;
using System;
using System.Drawing;
using System.Net.Http.Headers;
using System.Numerics;
using System.Runtime.InteropServices;

namespace MyGame
{



    class Mega_bolt : GameObject
    {
        private const float Speed = 1.2f;   

        private readonly Sprite _sprite = new Sprite();     
        
        
        public Mega_bolt(Vector2f pos)
        {
            _sprite.Texture = Game.GetTexture("Resources/bolt1.png");
            _sprite.Position = pos;

            AssignTag("bolt");
          
        }
         public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }
        public override FloatRect GetCollisionRect()
        {
            return _sprite.GetGlobalBounds();
        }
        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            
Vector2f pos = _sprite.Position;

         if(pos.X > Game.RenderWindow.Size.X)
            {
             MakeDead();
            }
            else
            {
                _sprite.Position = new Vector2f(pos.X + Speed * msElapsed, pos.Y);
            }   
        }
    }
}