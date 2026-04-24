using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;


using System;
using System.Numerics;

namespace MyGame
{
    public class Ship : GameObject
    {
        private const float Speed = 0.3f;
        private const int FireDelay = 200;
        private int _fireTimer = 0;
        private readonly Sprite _sprite = new Sprite();


        public Ship()
        {
         _sprite.Texture = Game.GetTexture("Resources/ship.png");
         _sprite.Position = new Vector2f(100, 100);
        }
        public override void Draw()
        {
         Game.RenderWindow.Draw(_sprite);
        }
        public override void Update(Time elapsed)
        {
         Vector2f pos = _sprite.Position;
         float x = pos.X;
         float y = pos.Y;
         int msElapesed = elapsed.AsMilliseconds();

         if (Keyboard.IsKeyPressed(Keyboard.Key.Up)) { y -= Speed * msElapesed;}
         if (Keyboard.IsKeyPressed(Keyboard.Key.Down)) { y += Speed * msElapesed;}
         if (Keyboard.IsKeyPressed(Keyboard.Key.Left)) { x -= Speed * msElapesed;}
         if (Keyboard.IsKeyPressed(Keyboard.Key.Right)) { x += Speed * msElapesed;}
        
         if (Keyboard.IsKeyPressed(Keyboard.Key.W)) { y -= Speed * msElapesed;}
         if (Keyboard.IsKeyPressed(Keyboard.Key.S)) { y += Speed * msElapesed;}
         if (Keyboard.IsKeyPressed(Keyboard.Key.A)) { x -= Speed * msElapesed;}
         if (Keyboard.IsKeyPressed(Keyboard.Key.D)) { x += Speed * msElapesed;}
         
         
         _sprite.Position = new Vector2f(x, y);
        
        if (_fireTimer > 0)
            {
                _fireTimer -= msElapesed;
            }
        
        if(Keyboard.IsKeyPressed(Keyboard.Key.Space) && _fireTimer <= 0)
            {
                _fireTimer = FireDelay;

                FloatRect bounds = _sprite.GetGlobalBounds();
                float laserx = x + bounds.Width;
                float laserY = y + bounds.Height / 1.2f;

                FloatRect bounds2 = _sprite.GetGlobalBounds();
                float laserx2 = x + bounds.Width;
                float laserY2 = y + bounds.Height / 6.0f;

                FloatRect bounds3 = _sprite.GetGlobalBounds();
                float laserx3 = x + bounds.Width;
                float laserY3 = y + bounds.Height / 2f;
                
                Laser laser = new Laser (new Vector2f(laserx, laserY));
                Game.CurrentScene.AddGameObject(laser);
                
                Laser laser2 = new Laser (new Vector2f(laserx2, laserY2));
                Game.CurrentScene.AddGameObject(laser2);

                Laser laser3 = new Laser (new Vector2f(laserx3, laserY3));
                Game.CurrentScene.AddGameObject(laser3);
            
            } 
        
        }
    
    }
}