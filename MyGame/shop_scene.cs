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
            Upgrade_lives upgrade_lives = new Upgrade_lives(new Vector2f(430.0f, 100.0f));
            AddGameObject(upgrade_lives);
            Upgrade_boost upgrade_boost = new Upgrade_boost(new Vector2f(700.0f, 100.0f));
            AddGameObject(upgrade_boost);
            Upgrade_coins upgrade_coins = new Upgrade_coins(new Vector2f(1000.0f, 100.0f));
            AddGameObject(upgrade_coins);
            coins_display Coins_display = new coins_display(new Vector2f(10.0f, 650.0f));
            AddGameObject(Coins_display);
        }
    
    }
}

