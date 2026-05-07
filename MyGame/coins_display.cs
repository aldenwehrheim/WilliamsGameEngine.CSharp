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
  

    public class coins_display  : GameObject
    {
          private readonly Sprite _sprite = new Sprite();

         public coins_display (Vector2f pos)
        {
            _sprite.Texture = Game.GetTexture("Resources/coin_display.png");
            _sprite.Position = pos;
            AssignTag("coins_display");
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