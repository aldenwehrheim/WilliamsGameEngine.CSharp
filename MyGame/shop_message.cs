using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Formats.Asn1;
using System.IO;
using System.Net;
using System.Threading;

namespace MyGame
{
    class shop_message :  GameObject
    {
        private readonly Text _text = new Text();
        private int Coins;

        public shop_message(int _coins)
        {
            Coins = _coins;
            GameScene scene = (GameScene)Game.CurrentScene;
            
            _text.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _text.Position = new Vector2f(50.0f, 50.0f);
            _text.CharacterSize = 48;
            _text.FillColor = Color.White;
            _text.DisplayedString = "test 50,50";
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_text);
        }

        public override void Update(Time elapsed)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Enter))
            {
                GameScene scene = new GameScene();
                Game.SetScene(scene);
            }
        }
    }
}