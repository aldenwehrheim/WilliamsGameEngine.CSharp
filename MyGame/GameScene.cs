using System;
using System.Formats.Asn1;
using System.IO;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using GameEngine;
using SFML.System;

namespace MyGame
{
   
    public class GameScene : Scene
    {
        public string highscore;
        private int _changetoshop = 50;
        private int _coins = 0;
        private int _score = 0;
        private int _lives = 3;
        public GameScene()
        {
            Ship ship = new Ship();
            AddGameObject(ship);
            Meteor_spawner meteor_Spawner = new Meteor_spawner();
            AddGameObject(meteor_Spawner);
            Score score = new Score(new Vector2f(10.0f, 10.0f));
            AddGameObject(score);
            lives_tracker lives = new lives_tracker(new Vector2f(10.0f, 70.0f));
            AddGameObject (lives);
            Text_coins coins = new Text_coins (new Vector2f(10.0f, 40.0f));
            AddGameObject (coins);
        }
       
        public int GetScore()
        {
            return _score;
        }
        public int GetCoins()
        {
            return _coins;
        }
        public void IncreaseScore()
        {
            ++_score;
            int score_changer = _score;
            if (score_changer >= 1)
            {
              StreamWriter writer = new StreamWriter("../../../save.txt");
              writer.Write(_lives);
              writer.Close();
              shop_scene shop = new shop_scene(_coins);
              Game.SetScene(shop); 
            }
        }
        public void IncreaseCoins()
        {
            ++_coins;
        }
        public void DecreaseCoins()
        {
            --_coins;
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
                Gameover_scene gameOverScene = new Gameover_scene(_score);
                Game.SetScene(gameOverScene);
            }
        }
        
        }

}
