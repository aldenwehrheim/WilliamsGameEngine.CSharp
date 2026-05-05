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
        private Random random = new Random();

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
             scene.DecreaseLives();
             
             MakeDead();
            }
            else
            {
                _sprite.Position = new Vector2f(pos.X - Speed * msElapsed, pos.Y);
            }   
        }
        public override void HandleCollision(GameObject otherGameObject)
        {
            Vector2f Pos = _sprite.Position;
            float x = Pos.X;
            float y = Pos.Y;
            int dropchance = (random.Next(5,5));
            if (otherGameObject.HasTag("laser"))
            {
                otherGameObject.MakeDead();
                GameScene scene = (GameScene)Game.CurrentScene;
                scene.IncreaseScore();
                if (dropchance == 5)
                {
                FloatRect bounds = _sprite.GetGlobalBounds();
                float upgradex = x + bounds.Width;
                float upgradey = y + bounds.Height;  
                Upgrade_laser Up_laser = new Upgrade_laser (new Vector2f(upgradex, upgradey));
                Game.CurrentScene.AddGameObject(Up_laser);
                }

            }       
            else if (otherGameObject.HasTag("bolt"))
            {
                GameScene scene = (GameScene)Game.CurrentScene;
                scene.IncreaseScore();
                int Dropchance = (random.Next(5,5));
                if (dropchance == 5)
                {
                 FloatRect bounds = _sprite.GetGlobalBounds();
                float upgradex = x + bounds.Width;
                float upgradey = y + bounds.Height;  
                Upgrade_laser Up_laser = new Upgrade_laser (new Vector2f(upgradex, upgradey));
                Game.CurrentScene.AddGameObject(Up_laser);   
                }
            }     
            else if (otherGameObject.HasTag("ship"))
            {
              int Dropchance = (random.Next(5,5));
                GameScene scene = (GameScene)Game.CurrentScene;
                scene.IncreaseScore();
                if (dropchance == 5)
                {
                 FloatRect bounds = _sprite.GetGlobalBounds();
                float upgradex = x + bounds.Width;
                float upgradey = y + bounds.Height;  
                Upgrade_laser Up_laser = new Upgrade_laser (new Vector2f(upgradex, upgradey));
                Game.CurrentScene.AddGameObject(Up_laser);   
                }  
                scene.DecreaseLives();
            }
            MakeDead();

           
            Vector2f pos =_sprite.Position;
            pos.X = pos.X + _sprite.GetGlobalBounds().Width / 2.0f;
            pos.Y = pos.Y + _sprite.GetGlobalBounds().Height / 2.0f;

            Explosion explosion = new Explosion(pos);
            Game.CurrentScene.AddGameObject(explosion);
        }

       
    }
}