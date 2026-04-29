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
    class GameOverMessage : GameObject
    {
        private readonly Text _text = new Text();
        private int Score;

        public GameOverMessage(int score)
        {
            Score = score;
            GameScene scene = (GameScene)Game.CurrentScene;

             if (Score > Convert.ToInt32(scene.highscore))
            {

                StreamWriter writer = new StreamWriter("../../../highscore.txt");
                writer.WriteLine(Score);
                writer.Close();
            }

            _text.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _text.Position = new Vector2f(50.0f, 50.0f);
            _text.CharacterSize = 48;
            _text.FillColor = Color.Red;
            _text.DisplayedString = "GAME OVER\n\nYOUR SCORE:" + score + "\nHIGHSCORE:" + scene.highscore + "\n\nPRESS ENTER TO CONTINUE";
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