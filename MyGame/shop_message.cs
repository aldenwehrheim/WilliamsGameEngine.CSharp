using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Formats.Asn1;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Linq;
using SFML.Audio;
using System.Security.AccessControl;

namespace MyGame
{
    class shop_message :  GameObject
    {
        private readonly Sound _pickup= new Sound();
        private readonly Text _guntext = new Text();
        private readonly Text _livestext = new Text();
        private readonly Text _livesdisplaytext = new Text();
        private readonly Text _boosttext = new Text();
        private readonly Text _cointext = new Text();
        private readonly Text _entertext = new Text();
        private readonly Text _displaycointext = new Text();
        private int Coins;
        private int coins;
        private int lives;
        private int score;
       
        public shop_message(int _coins)
        {
            
            
            Coins = _coins;
            GameScene scene = (GameScene)Game.CurrentScene;
            

            _guntext.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _guntext.Position = new Vector2f(100.0f, 375.0f);
            _guntext.CharacterSize = 20;
            _guntext.FillColor = Color.White;
            _guntext.DisplayedString = "press (1) to buy a laser upgrade\nprice: 15";

            _livestext.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _livestext.Position = new Vector2f(450.0f, 375.0f);
            _livestext.CharacterSize = 20;
            _livestext.FillColor = Color.White;
            _livestext.DisplayedString = "press (2) to buy 5 lives\nprice: 10";

            _boosttext.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _boosttext.Position = new Vector2f(680.0f, 375.0f);
            _boosttext.CharacterSize = 20;
            _boosttext.FillColor = Color.White;
            _boosttext.DisplayedString = "press (3) to buy a boost upgrade\nprice: 15";

            _cointext.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _cointext.Position = new Vector2f(1000.0f, 375.0f);
            _cointext.CharacterSize = 20;
            _cointext.FillColor = Color.White;
            _cointext.DisplayedString = "press (4) to buy a coin upgrade\nprice: 20";

            _entertext.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _entertext.Position = new Vector2f(500.0f, 600.0f);
            _entertext.CharacterSize = 30;
            _entertext.FillColor = Color.White;
            _entertext.DisplayedString = "(ENTER) to go next";

            _displaycointext.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _displaycointext.Position = new Vector2f(95.0f, 660.0f);
            _displaycointext.CharacterSize = 30;
            _displaycointext.FillColor = Color.White;
            _displaycointext.DisplayedString = "Coins: " + Coins;

            _livesdisplaytext.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _livesdisplaytext.Position = new Vector2f(500.0f, 600.0f);
            _livesdisplaytext.CharacterSize = 300;
            _livesdisplaytext.FillColor = Color.Green;
            _livesdisplaytext.DisplayedString = "Lives: " + lives;
            
        }

        public override void Draw()
        {
            
            Game.RenderWindow.Draw(_guntext);
            Game.RenderWindow.Draw(_livestext);
            Game.RenderWindow.Draw(_boosttext);
            Game.RenderWindow.Draw(_cointext);
            Game.RenderWindow.Draw(_entertext);
            Game.RenderWindow.Draw(_displaycointext);
        }
        GameScene scene = new GameScene();
        StreamReader reader = new StreamReader("../../../save.txt");
        public override void Update(Time elapsed)
        {
            
                while (!reader.EndOfStream)
                {
                    string readfileline = reader.ReadLine();
                    string [] data = readfileline.Split(',');
                     lives = Convert.ToInt16(data[0]);
                     score = Convert.ToInt16(data[1]);
                     coins = Convert.ToInt16(data[2]);
                }
            
         
            

            _displaycointext.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _displaycointext.Position = new Vector2f(95.0f, 660.0f);
            _displaycointext.CharacterSize = 30;
            _displaycointext.FillColor = Color.White;
            _displaycointext.DisplayedString = "Coins: " + Coins;

            int Current_upgrade_L;
            int Current_upgrade_B;
            int Current_upgrade_C;
            
            if (Keyboard.IsKeyPressed(Keyboard.Key.U) && coins >= 10)
            {
                coins -= 10;
                lives += 5;
                Coins -= 10;
                _pickup.SoundBuffer = Game.GetSoundBuffer("Resources/pickup.wav");
                _pickup.Play();
                Thread.Sleep(100);
                
            }
            
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Enter))
            {
                reader.Close();
                
                StreamWriter writer = new StreamWriter("../../../save.txt");
                writer.WriteLine($"{lives},{score},{coins}");
                writer.Close();
                
                GameScene scene = new GameScene();
                Game.SetScene(scene);
                
                Thread.Sleep(1000);
            }        
        }
    }
}