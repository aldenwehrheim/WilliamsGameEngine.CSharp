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
  

    public class Upgrade_boost  : GameObject
    {
          private readonly Sprite _sprite = new Sprite();

         public Upgrade_boost (Vector2f pos)
        {
            _sprite.Texture = Game.GetTexture("Resources/upgrade_boost.png");
            _sprite.Position = pos;
            AssignTag("boostupgrade");
            SetCollisionCheckEnabled(true);
        
        }
            
        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }

        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            Vector2f pos = _sprite.Position; 
        }    
    }
}