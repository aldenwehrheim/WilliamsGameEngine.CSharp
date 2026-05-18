using GameEngine;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;


using System;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace MyGame
{
   
    public class Ship : GameObject
    {
        GameScene scene = new GameScene();
        private readonly Sound _pew = new Sound();
        private const float Speed = 0.5f;
        private const int FireDelay = 200;
        private const int boltFireDelay = 700;
        private int _fireTimer = 0;
        private int _boltfireTimer = 0;
        public  int Position;
        public int follow_pos;
        private readonly Sprite _sprite = new Sprite();


        public Ship()
        {
        
          
         _sprite.Texture = Game.GetTexture("Resources/ship.png");
         _sprite.Position = new Vector2f(100, 100);
         Vector2f pos = _sprite.Position;
          float y = pos.Y;
          follow_pos = Convert.ToInt16(y);
         AssignTag("ship");

        }
        public float Get_Ship_Pos()
        {
            return follow_pos;
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

         if (Keyboard.IsKeyPressed(Keyboard.Key.Up)) { y -= Speed * msElapesed;}
         if (Keyboard.IsKeyPressed(Keyboard.Key.Down)) { y += Speed * msElapesed;}
         if (Keyboard.IsKeyPressed(Keyboard.Key.Left)) { x -= Speed * msElapesed;}
         if (Keyboard.IsKeyPressed(Keyboard.Key.Right)) { x += Speed * msElapesed;}
        
         if (Keyboard.IsKeyPressed(Keyboard.Key.W)) { y -= Speed * msElapesed;}
         if (Keyboard.IsKeyPressed(Keyboard.Key.S)) { y += Speed * msElapesed;}
         if (Keyboard.IsKeyPressed(Keyboard.Key.A)) { x -= Speed * msElapesed;}
         if (Keyboard.IsKeyPressed(Keyboard.Key.D)) { x += Speed * msElapesed;}
         GameScene scene = (GameScene)Game.CurrentScene;
         
         
         _sprite.Position = new Vector2f(x, y);
        
        if (_fireTimer > 0)
            {
                _fireTimer -= msElapesed;
            }
        if (_boltfireTimer > 0)
            {
                _boltfireTimer -= msElapesed;
            }
        
        if(Keyboard.IsKeyPressed(Keyboard.Key.Space) && _fireTimer <= 0)
            {
                _fireTimer = FireDelay;
                _pew.SoundBuffer= Game.GetSoundBuffer("Resources/laserShoot.wav");
                _pew.Play();
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
        if (Keyboard.IsKeyPressed(Keyboard.Key.F) && _boltfireTimer <= 0)
            {
               _boltfireTimer = boltFireDelay;  
               FloatRect bounds = _sprite.GetGlobalBounds();
                float boltx = x + bounds.Width;
                float boltY = y + bounds.Height / 25f;
                _pew.SoundBuffer= Game.GetSoundBuffer("Resources/laserShoot.wav");
                _pew.Play();
                Mega_bolt bolt = new Mega_bolt (new Vector2f(boltx, boltY));
                Game.CurrentScene.AddGameObject(bolt);
            }
      
        
        }
    
    }
}