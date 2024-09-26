using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using System.Diagnostics;
using System.Collections;

namespace Let_Him_Cook_last.Screen
{
    public class RestauarntScreen : screen
    {
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
        Texture2D texture;
        AnimatedTexture SpriteTexture;
        Player player;
        Vector2 playerPos = Vector2.Zero;
        Game1 game; public RestauarntScreen(Game1 game,
       EventHandler theScreenEvent) : base(theScreenEvent)
        {

            SpriteTexture = new AnimatedTexture(new Vector2(0, 0), 0, 1.0f, 0.5f);
            player = new Player(SpriteTexture, playerPos);
            SpriteTexture.Load(game.Content, "Char01_1", 5, 4, 10);
            //Load the background texture for the screen
            texture = game.Content.Load<Texture2D>("In_Restaurant");

            //bg = game.Content.Load<Texture2D>("map");
            //bg2 = game.Content.Load<Texture2D>("In_Restaurant");
            //inventory = game.Content.Load<Texture2D>("inventory");
            //popup = game.Content.Load<Texture2D>("popup");
            //craft = game.Content.Load<Texture2D>("craft");
            //interact = game.Content.Load<Texture2D>("interact");
            //uni = game.Content.Load<Texture2D>("Uni");
            //babiq = game.Content.Load<Texture2D>("BabiQ");
            //dunpling = game.Content.Load<Texture2D>("Dunpling");
            //tempura = game.Content.Load<Texture2D>("tempura");
            //ui = game.Content.Load<Texture2D>("ui");
            //uiHeart = game.Content.Load<Texture2D>("uiHeart");
            //book = game.Content.Load<Texture2D>("book");
            //Quest = game.Content.Load<Texture2D>("Quest");
            //bag = game.Content.Load<Texture2D>("bag");
            //FridgeUi = game.Content.Load<Texture2D>("FridgeUI");
            //bookUi = game.Content.Load<Texture2D>("BookUI");
            //QuestUI = game.Content.Load<Texture2D>("QuestUI");
            this.game = game;
        }
        public override void Update(GameTime theTime)
        {
            player.Update(theTime);
            base.Update(theTime);
        }
        int MenuPopup;
        bool IsFrigeInterect = false;
        bool sendingMenu = false;
        bool IsInterect = false;
        bool IssendMenuInterect = false;
        bool GotMenu = true;
        bool clicked = false;
        bool FinsihCooking = false;
        bool fade;
        bool Ontable;
        bool Crafting;
        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(texture, Vector2.Zero, Color.White);
            //if (IsInterect == true)
            //{
            //    _spriteBatch.Draw(interact, new Rectangle(848, 340, 134, 50), Color.White);
            //}
            //if (IsFrigeInterect == true)
            //{
            //    _spriteBatch.Draw(interact, new Rectangle(748, 310, 40, 80), Color.White);
            //}
            //if (IssendMenuInterect == true)
            //{
            //    _spriteBatch.Draw(interact, new Rectangle(995, 435, 60, 37), Color.White);
            //}
            player.Draw(_spriteBatch);
        }
            //if (fade == true)
            //{
            //    _spriteBatch.Draw(bg, new Rectangle(0, 0, 1600, 900), Color.Black);
            //    CountTime(70);
            //}
            //menu
//            if (sendingMenu == true && GotMenu == true && food.getFood == 2)
//            {
//                _spriteBatch.Draw(uni, new Rectangle((int)player.CharPosition.X, (int)player.CharPosition.Y + 13, 32, 32), Color.White);
//            }
//            if (Ontable == true)
//            {
//                _spriteBatch.Draw(craft, new Vector2(600, 220), Color.White);
//                _spriteBatch.Draw(inventory, new Vector2(520, 400), Color.White);
//                if (!GotMenu)
//                {
//                    for (int i = 0; i < CraftList.Count; i++)
//                    {
//                        _spriteBatch.Draw(CraftList[i].foodTexture, new Vector2(673 + i * 68, 252), Color.White);
//                    }
//                }
//                for (int i = 0; i < BagList.Count; i++)
//                {
//                    _spriteBatch.Draw(BagList[i].foodTexture, new Vector2(550 + i * 52, 430), Color.White);
//                }
//            }

//            if (MenuPopup == 1 && !FinsihCooking)
//            {
//                if (Crafting == true && food.getFood == 2)
//                {
//                    _spriteBatch.Draw(QuestUI, new Vector2(720, 320), new Rectangle(725, 133, 146, 190), Color.White,
//rotationMenuBG, Vector2.Zero, 1f, 0, 1);
//                    //_spriteBatch.Draw(menuBG, new Rectangle(650, 230, 300, 300), Color.White);
//                    _spriteBatch.Draw(uni, new Rectangle(733, 330, 128, 128), Color.White);
//                    GotMenu = true;
//                }

//                CountTime(200);
//            }
//            /// _spriteBatch.Draw(QuestUI, new Vector2(720, 320), new Rectangle(725, 133, 146, 190), Color.White,
//            //rotationMenuBG, Vector2.Zero, 1f, 0, 1);
//            //if (clicked == true)
//            //{
//            //    _spriteBatch.DrawString(font, $"{_camera.worldPos} + {temp_mouse} = {_camera.worldPos + temp_mouse}", _camera.worldPos + temp_mouse, Color.White);
//            //}
//            base.Draw(_spriteBatch);
//        }
//        public int countPopUp;
//        public void CountTime(int timePopup)
//        {
//            countPopUp += 1;
//            {
//                if (countPopUp > timePopup)
//                {
//                    countPopUp = 0;
//                    IsPopUp = false;
//                    fade = false;
//                    MenuPopup = 0;
//                    ShowInventory = false;

//                }
//            }
//        }

    }
}
