using SFML.System;
using SFML.Graphics;
using GameEngine;
using System.ComponentModel;
using System.Collections.Concurrent;

namespace MyGame
{
    public class Meteor_spawner : GameObject
    {
    
     private const int SpawnDelaymini = 1000;
     private const int SpawnDelaymega = 3000;

     private int _mintimer;
     private int _megtimer;
   
     public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            
            
            _mintimer -= msElapsed;
           
            if(_mintimer<=0)
            {
                _mintimer = SpawnDelaymini;
                
               Vector2u size = Game.RenderWindow.Size;

                float meteorX = size.X + 100;

                float meteorY = Game.Random.Next((int)size.Y);
                
                Meteor meteor = new Meteor(new Vector2f(meteorX, meteorY));
                Game.CurrentScene.AddGameObject(meteor);
                
            }
             _megtimer -= msElapsed;
             if (_megtimer <=0)
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
    
               