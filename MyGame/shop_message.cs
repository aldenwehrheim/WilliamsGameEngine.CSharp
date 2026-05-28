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
    class shop_message : GameObject
    {
        private readonly Sound _pickup = new Sound();
        private readonly Text _guntext = new Text();
        private readonly Text _livestext = new Text();
        private readonly Text _livesdisplaytext = new Text();
        private readonly Text _boosttext = new Text();
        private readonly Text _cointext = new Text();
        private readonly Text _entertext = new Text();
        private readonly Text _displaycointext = new Text();
        private readonly Text _gun_upgrade_text = new Text();
        private readonly Text _boost_upgrade_text = new Text();
        private readonly Text _coin_upgrade_text = new Text();
        private int Coins;
        private int coins;
        private int lives;
        private int score;
        private int Current_upgrade_L;
        private double Current_upgrade_B;
        private int Current_upgrade_C;
        private int boost_show;
        public shop_message(int _coins)
        {


            Coins = _coins;
            GameScene scene = (GameScene)Game.CurrentScene;
            
            StreamReader reader = new StreamReader("../../../save.txt");
            while (!reader.EndOfStream)
            {
                string readfileline = reader.ReadLine();
                string[] data = readfileline.Split(',');
                    lives = Convert.ToInt32(data[0]);
                    score = Convert.ToInt32(data[1]);
                    coins = Convert.ToInt32(data[2]);
                    Current_upgrade_L = Convert.ToInt32(data[3]);
                    Current_upgrade_B = Convert.ToDouble(data[4]);
                    Current_upgrade_C = Convert.ToInt32(data[5]);
                    boost_show = Convert.ToInt32(data[6]);
            }
            reader.Close();
            
            _guntext.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _guntext.Position = new Vector2f(100.0f, 375.0f);
            _guntext.CharacterSize = 20;
            _guntext.FillColor = Color.White;
            _guntext.DisplayedString = "press (Y) to buy a laser upgrade\nprice: 15";

            _livestext.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _livestext.Position = new Vector2f(450.0f, 375.0f);
            _livestext.CharacterSize = 20;
            _livestext.FillColor = Color.White;
            _livestext.DisplayedString = "press (U) to buy 5 lives\nprice: 10";

            _boosttext.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _boosttext.Position = new Vector2f(680.0f, 375.0f);
            _boosttext.CharacterSize = 20;
            _boosttext.FillColor = Color.White;
            _boosttext.DisplayedString = "press (I) to buy a boost upgrade\nprice: 15";

            _cointext.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _cointext.Position = new Vector2f(1000.0f, 375.0f);
            _cointext.CharacterSize = 20;
            _cointext.FillColor = Color.White;
            _cointext.DisplayedString = "press (O) to buy a coin upgrade\nprice: 20";

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
            _livesdisplaytext.Position = new Vector2f(95.0f, 630.0f);
            _livesdisplaytext.CharacterSize = 30;
            _livesdisplaytext.FillColor = Color.Green;
            _livesdisplaytext.DisplayedString = "Lives: " + lives;

            _gun_upgrade_text.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _gun_upgrade_text.Position = new Vector2f(95.0f, 600.0f);
            _gun_upgrade_text.CharacterSize = 30;
            _gun_upgrade_text.FillColor = Color.Red;
            _gun_upgrade_text.DisplayedString = "laser upgrade: " + (Current_upgrade_L / -40 + 5) + "/5";

           _boost_upgrade_text.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _boost_upgrade_text.Position = new Vector2f(95.0f, 570.0f);
            _boost_upgrade_text.CharacterSize = 30;
            _boost_upgrade_text.FillColor = Color.Blue;
            _boost_upgrade_text.DisplayedString = "boost upgrade: " + (Current_upgrade_B / -40 + 5) + "/5";

            _coin_upgrade_text.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _coin_upgrade_text.Position = new Vector2f(95.0f, 540.0f);
            _coin_upgrade_text.CharacterSize = 30;
            _coin_upgrade_text.FillColor = Color.Yellow;
            _coin_upgrade_text.DisplayedString = "coin upgrade: " + (Current_upgrade_C / -40 + 5) + "/5";

        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_livesdisplaytext);
            Game.RenderWindow.Draw(_guntext);
            Game.RenderWindow.Draw(_livestext);
            Game.RenderWindow.Draw(_boosttext);
            Game.RenderWindow.Draw(_cointext);
            Game.RenderWindow.Draw(_entertext);
            Game.RenderWindow.Draw(_displaycointext);
            Game.RenderWindow.Draw(_gun_upgrade_text);
            Game.RenderWindow.Draw(_boost_upgrade_text);
            Game.RenderWindow.Draw(_coin_upgrade_text);
        }
        
        public override void Update(Time elapsed)
        {
             if (Current_upgrade_L <= 0)
                {
                    _guntext.DisplayedString = "upgrade max";
                }
            _livesdisplaytext.DisplayedString = "Lives: " + lives;
            _displaycointext.DisplayedString = "Coins: " + Coins;
            _gun_upgrade_text.DisplayedString = "laser upgrade: " + (Current_upgrade_L / -40 + 5) + "/5";
            _boost_upgrade_text.DisplayedString = "boost upgrade: " + boost_show + "/5";
            _coin_upgrade_text.DisplayedString = "coin upgrade: " + (Current_upgrade_C / -40 + 5) + "/5";

            if (Keyboard.IsKeyPressed(Keyboard.Key.U) && coins >= 10)
            {
                coins -= 10;
                lives += 5;
                Coins -= 10;
                _pickup.SoundBuffer = Game.GetSoundBuffer("Resources/pickup.wav");
                _pickup.Play();
                Thread.Sleep(100);

            }

            if (Current_upgrade_L >= 40 && Keyboard.IsKeyPressed(Keyboard.Key.Y) && coins >= 15)
            {
               
                coins -= 15;
                Current_upgrade_L -= 40;

                Coins -= 15;
                _pickup.SoundBuffer = Game.GetSoundBuffer("Resources/pickup.wav");
                _pickup.Play();
               
                Thread.Sleep(100);
            
            }

            if (Current_upgrade_B <= 1.4  && Keyboard.IsKeyPressed(Keyboard.Key.I) && coins >= 15)
            {
               
                coins -= 15;
                Current_upgrade_B += 0.2;
                if (boost_show <= 5)
                {
                    boost_show += 1;
                }
                Coins -= 15;
                _pickup.SoundBuffer = Game.GetSoundBuffer("Resources/pickup.wav");
                _pickup.Play();
                  if (Current_upgrade_B >= 1.4)
                {
                    _boosttext.DisplayedString = "upgrade max";
                }
               
                Thread.Sleep(100);
            
            }

            if (Current_upgrade_C >= 40 && Keyboard.IsKeyPressed(Keyboard.Key.O) && coins >= 20)
            {
               
                coins -= 20;
                Current_upgrade_C -= 40;

                Coins -= 20;
                _pickup.SoundBuffer = Game.GetSoundBuffer("Resources/pickup.wav");
                _pickup.Play();
                  if (Current_upgrade_C <= 0)
                {
                    _cointext.DisplayedString = "upgrade max";
                }
               
                Thread.Sleep(100);
            
            }

            else if (Keyboard.IsKeyPressed(Keyboard.Key.Enter))
            {

                StreamWriter writer = new StreamWriter("../../../save.txt");
                writer.WriteLine($"{lives},{score},{coins},{Current_upgrade_L},{Current_upgrade_B},{Current_upgrade_C}");
                writer.Close();

                GameScene scene = new GameScene();
                Game.SetScene(scene);

                Thread.Sleep(1000);
            }
        }
    }
}