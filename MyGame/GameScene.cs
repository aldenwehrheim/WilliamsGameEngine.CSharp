using System;
using System.ComponentModel;
using System.Dynamic;
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
        private int _score_keeptrack = 0;
        private bool _dead = true;
        //private Ship test = new Ship();
        private int test2;
        private int _coins = 0;
        private int _score = 0;
        private int _lives = 3;
        private string saved_lives;
        private string saved_score;
        private string saved_coins;
        private int laser_upgrade;
        private string saved_laser_upgrade;
        private int speed_upgrade;
        private int coins_upgrade;
        private string saved_speed_upgrade;
        private string saved_coins_upgrade;
        private int ship_L_upgrade;

        
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
            Boss boss = new Boss (ship);
            AddGameObject (boss);
            
            StreamReader reader = new StreamReader("../../../save.txt");
                while (!reader.EndOfStream)
                {
                    string readfileline = reader.ReadLine();
                    string [] data = readfileline.Split(',');
                    saved_lives = data[0];
                    saved_score = data[1];
                    saved_coins = data[2];
                    saved_laser_upgrade = (data[3]);
                    saved_speed_upgrade = (data[4]);
                    saved_coins_upgrade = (data[5]);
                }
                reader.Close();
            
            _lives = Convert.ToInt32(saved_lives);
            _coins = Convert.ToInt32(saved_coins);
            _score = Convert.ToInt32(saved_score);
            laser_upgrade = Convert.ToInt32(saved_laser_upgrade);
            speed_upgrade = Convert.ToInt32(saved_speed_upgrade);
            coins_upgrade = Convert.ToInt32(saved_coins_upgrade);
            
            
            if (_lives <= 0)
            {
                _lives = 3;
            }
            //test2 = Convert.ToInt16(test.Get_Ship_Pos());
        }
        
        public int Get_Ship_Pos()
        {
            return test2;
        }
        public int GetScore()
        {
            return _score;
        }
        public int Get_upgrade_L()
        {
            return laser_upgrade;
        }
        public void IncreaseBoss_dead_true()
        {
            _dead = true;
        }
        public void IncreaseBoss_dead_false()
        {
            _dead = false;
        }
        public bool GetBoss_status()
        {
            return _dead;
        }

        public int GetCoins()
        {
            return _coins;
        }
        public void IncreaseScore()
        {
            ++_score;
            ++_score_keeptrack;
            if (_score_keeptrack >= 1)
            {
              StreamWriter writer = new StreamWriter("../../../save.txt");
              writer.WriteLine($"{_lives},{_score},{_coins},{laser_upgrade},{speed_upgrade},{coins_upgrade}");
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
        public void ShopDecreaseCoins()
        {
            _coins -= 10;
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
        public void ShopIncreaseLives()
        {
            _lives += 5;
        }
        }

}
