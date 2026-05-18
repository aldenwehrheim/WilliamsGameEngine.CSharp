using SFML.System;
using SFML.Graphics;
using GameEngine;
using System;

namespace MyGame
{



    class lives_tracker : GameObject
    {
         private readonly Text _text2 = new Text();
         private Int32 lives;
         public lives_tracker (Vector2f pos)
        {
            _text2.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _text2.Position = pos;
            _text2.CharacterSize = 24;
            _text2.FillColor = Color.Green;
            
    
            AssignTag("lives");

        }   
        
         public override void Draw()
        {
            Game.RenderWindow.Draw(_text2);     
            
        }

        public override void Update(Time elapsed)
        {
            
            GameScene scene = (GameScene)Game.CurrentScene;
            
            _text2.DisplayedString = "LIVES: " + scene.Getlives();

        }
    }
}