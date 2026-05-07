using GameEngine;
using SFML.System;


namespace MyGame
{
    class shop_scene : Scene
    {
        public shop_scene(int coins)
        {
            shop_message shop = new shop_message(coins);
            AddGameObject(shop);
            Upgrade_laser upgrade_laser = new Upgrade_laser(new Vector2f(100.0f, 100.0f));
            AddGameObject(upgrade_laser);
        }
    
    }
}

