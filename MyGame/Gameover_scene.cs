using GameEngine;

namespace MyGame
{
    class Gameover_scene : Scene
    {
        public Gameover_scene(int score)
        {
            GameOverMessage gameOverMessage = new GameOverMessage(score);
            AddGameObject(gameOverMessage);
           
        }
    
    }
}

