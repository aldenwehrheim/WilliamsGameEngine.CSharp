using System.IO;
using System.Security.Cryptography.X509Certificates;
using GameEngine;

namespace MyGame
{
    
    public static class MyGame
    {
        private const int WindowWidth = 1300;
        private const int WindowHeight = 750;

        private const string WindowTitle = "spaceship destroyer";
        
         public static void Main(string[] args)
        {
            // Initialize the game.
            Game.Initialize(WindowWidth, WindowHeight, WindowTitle);
            StreamWriter writer = new StreamWriter("../../../save.txt");
              writer.WriteLine($"{3},{0},{500},{200},{200},{200}");
              writer.Close();
            // Create our scene.
            GameScene scene = new GameScene();
            Game.SetScene(scene);
            // Run the game loop.
            Game.Run();
        }
    
    }
}