using GameEngine;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Numerics;
using System.Runtime.InteropServices;

namespace MyGame
{
    public class ammo_crate_drop : GameObject
    {
       
        private readonly Sound _pickupammo = new Sound();
        private const float Speed = 0.45f;
             private readonly Sprite _sprite = new Sprite();

         public ammo_crate_drop(Vector2f pos)
        {
            _sprite.Texture = Game.GetTexture("Resources/ammo_crate.png");
            _sprite.Position = pos;
          
            AssignTag("ammo");
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
        
            if (otherGameObject.HasTag("ship"))
            {
              
                GameScene scene = (GameScene)Game.CurrentScene;
                
            _pickupammo.SoundBuffer = Game.GetSoundBuffer("Resources/ammo_grab.wav");
            _pickupammo.Play();
                scene.IncreaseCoins();
                 MakeDead();
            }
           

           }

       
    }
}