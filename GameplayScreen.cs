using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Formats.Asn1.AsnWriter;
namespace Let_Him_Cook_last.Screen
{
    public class GameplayScreen : screen
    {
        public static Player player;
        public Food food;
        Enemy enemy;
        AnimatedTexture SpriteTexture;
        Vector2 playerPos = new Vector2(775,440);
        Camera _camera;

        public static int currentHeart;

        Vector2 foodPos;
        Vector2 enemyPos;

        SpriteFont font;
        Texture2D foodTex;
        Texture2D enemyTex;
        Texture2D foodTexture;
        Texture2D foodTex2;
        Texture2D foodTex3;
        Texture2D foodTex4;
        Texture2D foodTex5;
        Texture2D foodTex6;
        Texture2D foodTex7;
        Texture2D foodTex8;
        Texture2D foodTex9;
        Texture2D foodTex10;
        Texture2D foodTex11;
        Texture2D uni;
        Texture2D babiq;
        Texture2D dunpling;
        Texture2D tempura;
        Texture2D menuBG;
        ////////////////asset////////////////////
        Texture2D Inventory;
        Texture2D bg;
        Texture2D interact;
        Texture2D bg2;
        Texture2D table;
        Texture2D inventory;
        Texture2D menu1;
        Texture2D craft;
        Texture2D popup;
        Texture2D FridgeUi;
        Texture2D bookUi;
        Texture2D ui;
        Texture2D uiHeart;
        Texture2D bag;
        public Texture2D QuestUI;
        public Texture2D Quest;
        public Texture2D book;

        public static List<Food> BagList = new List<Food>();
        public static List<Food> foodList = new();
        public static List<Enemy> enemyList = new();
        public static List<Food> CraftList = new List<Food>();
        public static List<Food> MenuList = new List<Food>();
        public static List<Texture2D> FoodMenuList = new List<Texture2D>();

        public static bool IsPopUp = false;
        public static Vector2 tablePos = new Vector2(848, 345);
        public Rectangle tableBox = new Rectangle((int)tablePos.X, (int)tablePos.Y, 100, 50);
        public Rectangle sendMenu = new Rectangle(1000, 440, 100, 50);
        public Rectangle equalBox = new Rectangle((int)equalPos.X, (int)equalPos.Y, 150, 40);
        public static Vector2 equalPos = new Vector2(720, 310);
        bool IsInterect = false;
        bool IssendMenuInterect = false;
        bool GotMenu = false;
        public Rectangle FrigeRec = new Rectangle(750, 310, 40, 80);
        int getbabiq;
        int rotationMenuBG;
        bool FinsihCooking;
        Texture2D gameplayTexture; Game1 game; public GameplayScreen(Game1 game,
       EventHandler theScreenEvent) : base(theScreenEvent)
        {
            //Load the background texture for the screen
            this.game = game;
            _camera = new Camera(new Vector2(-400, -225));
            SpriteTexture = new AnimatedTexture(new Vector2(0, 0), 0, 1.0f, 0.5f);
            player = new Player(SpriteTexture, playerPos);
            SpriteTexture.Load(game.Content, "Char01_1", 5, 4, 10);
            food = new Food(foodTex, foodPos);
            enemy = new Enemy(enemyTex, enemyPos);

            foodTexture = game.Content.Load<Texture2D>("chicken");
            foodTex2 = game.Content.Load<Texture2D>("enemy");
            foodTex3 = game.Content.Load<Texture2D>("enemy2");
            foodTex4 = game.Content.Load<Texture2D>("flower");
            foodTex5 = game.Content.Load<Texture2D>("fruit");
            foodTex6 = game.Content.Load<Texture2D>("mushroom1");
            foodTex7 = game.Content.Load<Texture2D>("mushroom2");
            foodTex8 = game.Content.Load<Texture2D>("pumkin");
            foodTex9 = game.Content.Load<Texture2D>("pumkin2");
            foodTex10 = game.Content.Load<Texture2D>("snail");
            foodTex11 = game.Content.Load<Texture2D>("snail2");
            foodList.Add(new Food(foodTex3, new Vector2(300 + 100, 300)));
            foodList.Add(new Food(foodTex4, new Vector2(150 + 100, 150)));
            foodList.Add(new Food(foodTex5, new Vector2(300 + 100, 200)));
            foodList.Add(new Food(foodTex6, new Vector2(380 + 100, 330)));
            foodList.Add(new Food(foodTex7, new Vector2(230 + 100, 260)));
            foodList.Add(new Food(foodTex8, new Vector2(300, 200)));
            foodList.Add(new Food(foodTex9, new Vector2(100, 200)));
            //font = game.Content.Load<SpriteFont>("myfontsss");
            bg = game.Content.Load<Texture2D>("map");
            bg2 = game.Content.Load<Texture2D>("In_Restaurant");
            inventory = game.Content.Load<Texture2D>("inventory");
            popup = game.Content.Load<Texture2D>("popup");
            craft = game.Content.Load<Texture2D>("craft");
            interact = game.Content.Load<Texture2D>("interact");
            uni = game.Content.Load<Texture2D>("Uni");
            babiq = game.Content.Load<Texture2D>("BabiQ");
            dunpling = game.Content.Load<Texture2D>("Dunpling");
            tempura = game.Content.Load<Texture2D>("tempura");
            ui = game.Content.Load<Texture2D>("ui");
            uiHeart = game.Content.Load<Texture2D>("uiHeart");
            book = game.Content.Load<Texture2D>("book");
            Quest = game.Content.Load<Texture2D>("Quest");
            bag = game.Content.Load<Texture2D>("bag");
            FridgeUi = game.Content.Load<Texture2D>("FridgeUI");
            bookUi = game.Content.Load<Texture2D>("BookUI");
            QuestUI = game.Content.Load<Texture2D>("QuestUI");
            currentHeart = uiHeart.Width - 10;
        }

        public Rectangle doorRec = new Rectangle(810, 380, 50, 2);
        public Rectangle doorRestaurantRec = new Rectangle(530, 230, 100, 2);
        public Rectangle xBox;
        Rectangle bagRec;
        Rectangle bookRec;
        Rectangle questboxRec;

        Color color = Color.White;
        bool OnCursor = false;
        bool OnCursor1 = false;
        bool OnCursor2 = false;
        bool OnCursorXBOX = false;
        bool openbookUI = false;
        bool openQuestUI = false;
        bool openFridgeUI = false;
        int mouse_state = 1;
        bool fade;
        int MenuPopup;
        bool IsFrigeInterect = false;
        bool sendingMenu = false;
        bool ShowInventory = false;
        bool closeXBox;
        Vector2 temp_mouse;
        public override void Update(GameTime gameTime)
        {
           
            if (player.playerBox.Intersects(doorRec))
            {
                ScreenEvent.Invoke(game.RestauarntScreen, new EventArgs());
                return;
            }

            bagRec = new Rectangle((int)(player.CharPosition.X + 350), (int)(player.CharPosition.Y - 240), 30, 30);
            bookRec = new Rectangle((int)(player.CharPosition.X + 350), (int)(player.CharPosition.Y - 160), 30, 20);
            questboxRec = new Rectangle((int)(player.CharPosition.X + 350), (int)(player.CharPosition.Y - 100), 30, 30);
            xBox = new Rectangle((int)(player.CharPosition.X) + 250, (int)(player.CharPosition.Y - 160), 30, 30);
            MouseState ms = Mouse.GetState();
            Rectangle mouseBox = new Rectangle((int)_camera.worldPos.X + (int)temp_mouse.X, (int)_camera.worldPos.Y + (int)temp_mouse.Y, 50, 50);
            temp_mouse.X = ms.X;
            temp_mouse.Y = ms.Y;
            ////////////////Camera////////////////////
            _camera.Follow(player);
            if (mouseBox.Intersects(bookRec) && ms.LeftButton == ButtonState.Pressed)
            {
                closeXBox = false;
                openbookUI = true;
                openQuestUI = false;
                ShowInventory = false;
            }
            else { OnCursor1 = false; }
            if (mouseBox.Intersects(questboxRec) && ms.LeftButton == ButtonState.Pressed)
            {
                closeXBox = false;
                openQuestUI = true;
                ShowInventory = false;
                openbookUI = false;
            }
            else { OnCursor2 = false; }
            if (mouseBox.Intersects(bagRec))
            {
                OnCursor = true;
                if (ms.LeftButton == ButtonState.Pressed && mouseBox.Intersects(bagRec))
                {
                    closeXBox = false;
                    ShowInventory = true;
                    openQuestUI = false;
                    openbookUI = false;
                }
            }
            else { OnCursor = false; }
            if (mouseBox.Intersects(xBox) && ms.LeftButton == ButtonState.Pressed)
            {
                closeXBox = true;
                openbookUI = false;
                ShowInventory = false;
                openQuestUI = false;
            }
            if (mouseBox.Intersects(xBox)) { OnCursorXBOX = true; }
            else { OnCursorXBOX = false; }
            if (mouseBox.Intersects(bookRec)) { OnCursor1 = true; }
            else { OnCursor1 = false; }
            if (mouseBox.Intersects(questboxRec)) { OnCursor2 = true; }
            else { OnCursor2 = false; }
            if (currentHeart < 60) { color = Color.Red; }
            else { color = Color.White; }
            ////////////////Food.Update////////////////////
            for (int i = foodList.Count - 1; i >= 0; i--)
            {
                foodList[i].Update(gameTime);
            }
            for (int i = enemyList.Count - 1; i >= 0; i--)
            {
                enemyList[i].Update(gameTime);
            }
            player.Update(gameTime);
            _camera.Follow(player);
            //food.Update(gameTime);
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.End();
            _spriteBatch.Begin(transformMatrix: _camera.Transform, samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(bg, new Rectangle(0, 0, 1600, 900), Color.White);
            //_spriteBatch.DrawString(heart, player.Life.ToString(), new Vector2(10, 30), Color.White);
            ////////////////Food.Draw////////////////////
            foreach (Food food in foodList)
            {
                for (int i = 0; i < foodList.Count; i++)
                {
                    foodList[i].Draw(_spriteBatch);
                }
            }
            foreach (Enemy enemy in enemyList)
            {
                for (int i = 0; i < enemyList.Count; i++)
                {
                    enemyList[i].Draw(_spriteBatch);
                }
            }

            //_spriteBatch.Draw(table, doorRec, Color.White);
            ////////////////player////////////////////
            player.Draw(_spriteBatch);
            ////////////////Inventory////////////////////
            ////////////////popup////////////////////


            if (fade == true)
            {
                _spriteBatch.Draw(bg, new Rectangle(0, 0, 1600, 900), Color.Black);
                CountTime(70);
            }
            if (clicked == true)
            {
                _spriteBatch.DrawString(font, $"{_camera.worldPos} + {temp_mouse} = {_camera.worldPos + temp_mouse}", _camera.worldPos + temp_mouse, Color.White);
            }
            base.Draw(_spriteBatch);
        }
        public int countPopUp;
        bool clicked;
        public void CountTime(int timePopup)
        {
            countPopUp += 1;
            {
                if (countPopUp > timePopup)
                {
                    countPopUp = 0;
                    IsPopUp = false;
                    fade = false;
                    MenuPopup = 0;
                    ShowInventory = false;

                }
            }
        }
    }
}
