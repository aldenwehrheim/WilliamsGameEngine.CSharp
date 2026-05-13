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
        private int test;
        private Random Big_shoot = new Random();
        private const float Speed = 0.5f;
        private readonly Sprite _sprite = new Sprite();
        private Ship ship;
        
        public Boss(Ship ship)
        {
         this.ship = ship;
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
         GameScene scene = (GameScene)Game.CurrentScene;
         scene.IncreaseBoss_dead_false();
    
         Vector2f pos = _sprite.Position;
         float x = pos.X;
         float y = pos.Y;
          int move = (Move.Next(1,20));
        
        if (move == 1 && y >= Convert.ToInt16(ship.Get_Ship_Pos())) {y -= Speed * 20;}
        if (move == 2 && y <= Convert.ToInt16(ship.Get_Ship_Pos())) {y += Speed * 20;}
         
         _sprite.Position = new Vector2f(x, y);
        
        
        int _fireTimer = Shoot.Next(1,40);
        int _boltfireTimer = Shoot.Next(1,50);
        if(_fireTimer == 2)
            {
                
                FloatRect bounds = _sprite.GetGlobalBounds();
                float laserx = x + bounds.Width / 2.5f;
                float laserY = y + bounds.Height / 1.6f;

              

                FloatRect bounds2 = _sprite.GetGlobalBounds();
                float laserx2 = x + bounds.Width  / 2.5f;
                float laserY2 = y + bounds.Height / 3f;
                
                Boss_laser laser = new Boss_laser (new Vector2f(laserx, laserY));
                Game.CurrentScene.AddGameObject(laser);
                
                Boss_laser laser3 = new Boss_laser (new Vector2f(laserx2, laserY2));
                Game.CurrentScene.AddGameObject(laser3);
            
            } 
        if (_boltfireTimer == 2)
            {
                
               FloatRect bounds = _sprite.GetGlobalBounds();
                float boltx = x + bounds.Width  / 2.5f;
                float boltY = y + bounds.Height / 3f;
                Boss_bolt bolt = new Boss_bolt (new Vector2f(boltx, boltY));
                Game.CurrentScene.AddGameObject(bolt);
            }
        
        
        }
    
    }
}