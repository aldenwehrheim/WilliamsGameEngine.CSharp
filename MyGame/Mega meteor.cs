using GameEngine;
using SFML.Graphics;
using SFML.System;
using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Numerics;
using System.Runtime.InteropServices;

namespace MyGame
{
    public class Mega_meteor : GameObject
    {
        private Random random = new Random();

        private const float Speed = 0.45f;
        private readonly Sprite _sprite = new Sprite();

        public Mega_meteor(Vector2f pos)
        {
            _sprite.Texture = Game.GetTexture("Resources/big_meteor.png");
            _sprite.Position = pos;

            AssignTag("big_meteor");
            SetCollisionCheckEnabled(true);
        }
        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }

        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            Vector2f pos = _sprite.Position;

            if (pos.X < Game.RenderWindow.Size.X * -1)
            {
                GameScene scene = (GameScene)Game.CurrentScene;
                scene.DecreaseLives();

                MakeDead();
            }
            else
            {
                _sprite.Position = new Vector2f(pos.X - Speed * msElapsed, pos.Y);
            }


        }
        public override FloatRect GetCollisionRect()
        {
            return _sprite.GetGlobalBounds();
        }
        public override void HandleCollision(GameObject otherGameObject)
        {
            Vector2f Pos = _sprite.Position;
            float x = Pos.X;
            float y = Pos.Y;
            if (otherGameObject.HasTag("laser"))
            {
                otherGameObject.MakeDead();
                GameScene scene = (GameScene)Game.CurrentScene;
            }
            else if (otherGameObject.HasTag("bolt"))
            {
                otherGameObject.MakeDead();
                GameScene scene = (GameScene)Game.CurrentScene;
                scene.IncreaseScore();
                int Dropchance = (random.Next(1, 10));
                if (Dropchance == 5)
                {
                    FloatRect bounds = _sprite.GetGlobalBounds();
                    float coinx = x + bounds.Width;
                    float coiny = y + bounds.Height;
                    Coin_drop coin = new Coin_drop(new Vector2f(coinx, coiny));
                    Game.CurrentScene.AddGameObject(coin);
                }
                MakeDead();
                Vector2f pos = _sprite.Position;
                    pos.X = pos.X + _sprite.GetGlobalBounds().Width / 2.0f;
                    pos.Y = pos.Y + _sprite.GetGlobalBounds().Height / 2.0f;

                    Explosion explosion = new Explosion(pos);
                    Game.CurrentScene.AddGameObject(explosion);
            }
            else if (otherGameObject.HasTag("ship"))
            {
                GameScene scene = (GameScene)Game.CurrentScene;
                scene.IncreaseScore();
                int Dropchance = (random.Next(1, 10));
                if (Dropchance == 5)
                {
                    FloatRect bounds = _sprite.GetGlobalBounds();
                    float coinx = x + bounds.Width;
                    float coiny = y + bounds.Height;
                    Coin_drop coin = new Coin_drop(new Vector2f(coinx, coiny));
                    Game.CurrentScene.AddGameObject(coin);
                    scene.DecreaseLives();
                    MakeDead();
                    Vector2f pos = _sprite.Position;
                    pos.X = pos.X + _sprite.GetGlobalBounds().Width / 2.0f;
                    pos.Y = pos.Y + _sprite.GetGlobalBounds().Height / 2.0f;

                    Explosion explosion = new Explosion(pos);
                    Game.CurrentScene.AddGameObject(explosion);
                }
                if (IsDead())
                {
                    Vector2f pos = _sprite.Position;
                    pos.X = pos.X + _sprite.GetGlobalBounds().Width / 2.0f;
                    pos.Y = pos.Y + _sprite.GetGlobalBounds().Height / 2.0f;

                    Explosion explosion = new Explosion(pos);
                    Game.CurrentScene.AddGameObject(explosion);
                }
            }


        }
    }
}