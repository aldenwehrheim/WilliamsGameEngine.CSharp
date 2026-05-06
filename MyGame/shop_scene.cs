using GameEngine;


namespace MyGame
{
    class shop_scene : Scene
    {
        public shop_scene(int coins)
        {
            shop_message shop = new shop_message(coins);
            AddGameObject(shop);
            
        }
    
    }
}

