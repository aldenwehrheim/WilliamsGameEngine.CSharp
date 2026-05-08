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
    public class Boss : GameObject
    {
        private Random Move = new Random();
        private Random Shoot = new Random();
        private Random Big_shoot = new Random();
        private const float Speed = 0.5f;
        private readonly Sprite _sprite = new Sprite();
        public Boss()
        {
         
         _sprite.Texture = Game.GetTexture("Resources/death_ship_of doom.png");
         _sprite.Position = new Vector2f(1000,300);
        AssignTag("bad_ship");
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
          
         Vector2f pos = _sprite.Position;
         float x = pos.X;
         float y = pos.Y;
         int msElapesed = elapsed.AsMilliseconds();
          int move = (Move.Next(1,4));
        
        if (move == 1) {y -= Speed * msElapesed;}
        if (move == 2) {y += Speed * msElapesed;}
        if (move == 3) {x -= Speed * msElapesed;}
        if (move == 4) {x += Speed * msElapesed;}
         
         _sprite.Position = new Vector2f(x, y);
        
        
        int _fireTimer = Shoot.Next(1,3);
        int _boltfireTimer = Shoot.Next(1,4);
        if(_fireTimer == 2)
            {
                
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
        if (_boltfireTimer == 2)
            {
                
               FloatRect bounds = _sprite.GetGlobalBounds();
                float boltx = x + bounds.Width;
                float boltY = y + bounds.Height / 25f;
                Mega_bolt bolt = new Mega_bolt (new Vector2f(boltx, boltY));
                Game.CurrentScene.AddGameObject(bolt);
            }
      
        
        }
    
    }
}