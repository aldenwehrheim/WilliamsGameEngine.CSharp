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
    public class Meteor : GameObject
    {
        private const float Speed = 0.45f;
             private readonly Sprite _sprite = new Sprite();

         public Meteor(Vector2f pos)
        {
            _sprite.Texture = Game.GetTexture("Resources/meteor.png");
            _sprite.Position = pos;

            AssignTag("meteor");
            SetCollisionCheckEnabled(true);
        }
        public override FloatRect GetCollisionRect()
        {
            return _sprite.GetGlobalBounds();
        }
        public override void HandleCollision(GameObject otherGameObject)
        {
            if (otherGameObject.HasTag("laser"))
            {
                otherGameObject.MakeDead();
                GameScene scene = (GameScene)Game.CurrentScene;
                scene.IncreaseScore();
            }   
            MakeDead();
           
            Vector2f pos =_sprite.Position;
            pos.X = pos.X + _sprite.GetGlobalBounds().Width / 2.0f;
            pos.Y = pos.Y + _sprite.GetGlobalBounds().Height / 2.0f;

            Explosion explosion = new Explosion(pos);
            Game.CurrentScene.AddGameObject(explosion);
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
             GameScene scene = (GameScene)gane
             
             MakeDead();
            }
            else
            {
                _sprite.Position = new Vector2f(pos.X - Speed * msElapsed, pos.Y);
            }   

        
        }
    }
}