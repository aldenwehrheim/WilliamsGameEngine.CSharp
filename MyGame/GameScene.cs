using System;
using System.Formats.Asn1;
using System.IO;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using GameEngine;
using SFML.System;

namespace MyGame
{
   
    public class GameScene : Scene
    {
        public string highscore;
        private int _score = 0;
        private int _lives = 3;
        public GameScene()
        {
            StreamReader reader = new StreamReader("../../../highscore.txt");

            highscore = reader.ReadLine();
            reader.Close();
            StreamWriter writer = new StreamWriter("../../../highscore.txt");
            Ship ship = new Ship();
            AddGameObject(ship);
            Meteor_spawner meteor_Spawner = new Meteor_spawner();
            AddGameObject(meteor_Spawner);
            Score score = new Score(new Vector2f(10.0f, 10.0f));
            AddGameObject(score);
            lives_tracker lives = new lives_tracker(new Vector2f(10.0f, 40.0f));
            AddGameObject (lives);
            writer.Close();
        }
       
        public int GetScore()
        {
            return _score;
        }

        public void IncreaseScore()
        {
            ++_score;
        }

        public int Getlives()
        {
            return _lives;
        }

        public void DecreaseLives()
        {
            --_lives;
            if (_lives == 0)
            {
                GameOverScene gameOverScene = new GameOverScene(_score);
                Game.SetScene(gameOverScene);
            }
        }

    }

}
