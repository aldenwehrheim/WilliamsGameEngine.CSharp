using SFML.System;
using SFML.Graphics;
using GameEngine;

namespace MyGame
{

    class Text_coins : GameObject
    {
        private readonly Text _text = new Text();
      
        public Text_coins (Vector2f pos)
        {
            _text.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _text.Position = pos;
            _text.CharacterSize = 24;
            _text.FillColor = Color.Yellow;

            AssignTag("coins");
        }
     
        public override void Draw()
        {
            Game.RenderWindow.Draw(_text);
       
            
        }

        public override void Update(Time elapsed)
        {
            GameScene scene = (GameScene)Game.CurrentScene;
            _text.DisplayedString = "coins: " + scene.GetCoins();

        }
    }
}