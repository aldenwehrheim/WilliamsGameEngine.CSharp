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
  

    public class Upgrade_lives  : GameObject
    {
          private const float Speed = 0.45f;
          private readonly Sprite _sprite = new Sprite();

         public Upgrade_lives(Vector2f pos)
        {
            _sprite.Texture = Game.GetTexture("Resources/upgrade_lives.png");
            _sprite.Position = pos;

            AssignTag("livesupgrade");
            SetCollisionCheckEnabled(true);
        }
        public override FloatRect GetCollisionRect()
        {
            return _sprite.GetGlobalBounds();
        }
        public override void HandleCollision(GameObject otherGameObject)
        {
            if (otherGameObject.HasTag("ship"))
            {
              
                GameScene scene = (GameScene)Game.CurrentScene;
                MakeDead();
            }       
            
            
           
            Vector2f pos =_sprite.Position;
            pos.X = pos.X + _sprite.GetGlobalBounds().Width / 2.0f;
            pos.Y = pos.Y + _sprite.GetGlobalBounds().Height / 2.0f;

        }
        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }

        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            Vector2f pos = _sprite.Position;
         
         if(pos.X < Game.RenderWindow.Size.X * -1)
            {
             GameScene scene = (GameScene)Game.CurrentScene;
             MakeDead();
            }
            else
            {
                _sprite.Position = new Vector2f(pos.X - Speed * msElapsed, pos.Y);
            }   
        }    
    }
}