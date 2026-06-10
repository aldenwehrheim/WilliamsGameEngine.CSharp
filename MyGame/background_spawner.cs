using SFML.System;
using SFML.Graphics;
using GameEngine;
using System.ComponentModel;
using System.Collections.Concurrent;
using System.Threading;

namespace MyGame
{
    public class background_spawner : GameObject
    {

        private const int SpawnDelay = 3000;

        private int _timer;
        
        
        
        public override void Update(Time elapsed)
        {
           
            int msElapsed = elapsed.AsMilliseconds();
            GameScene scene = (GameScene)Game.CurrentScene;
            
            


                _timer -= msElapsed;

                if (_timer <= 0)
                {
                    _timer = SpawnDelay;

                    Vector2u size = Game.RenderWindow.Size;

                    float X = size.X + 100;

                    float Y = Game.Random.Next((int)size.Y);

                    Meteor meteor = new Meteor(new Vector2f(X, Y));
                    Game.CurrentScene.AddGameObject(meteor);

                }
                _megtimer -= msElapsed;
                if (_megtimer <= 0)
                {
                    _megtimer = SpawnDelaymega;

                    Vector2u size = Game.RenderWindow.Size;

                    float MeteorX = size.X + 100;

                    float MeteorY = Game.Random.Next((int)size.Y);

                    Mega_meteor Megmeteor = new Mega_meteor(new Vector2f(MeteorX, MeteorY));
                    Game.CurrentScene.AddGameObject(Megmeteor);
                }

            
        }
    }
}

