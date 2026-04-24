using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using GameEngine;
using SFML.System;

namespace MyGame
{
    public class GameScene : Scene
    {
    
        private int _score = 0;
        private int _lives = 3;
        public GameScene()
        {
         Ship ship = new Ship();   
         AddGameObject(ship);
         Meteor_spawner meteor_Spawner = new Meteor_spawner();
         AddGameObject(meteor_Spawner);
         Score score = new Score(new Vector2f(10.0f,10.0f));
         AddGameObject(score);
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

        public void Decreaselives()
        {
            --_lives;

            if(_lives == 0)
            {
                GameOverMessage gameOverScene = new GameOverMessage(_score);
                Game.SetScene(gameOverScene); 
            }
        }
    
    }

}
