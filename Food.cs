using Let_Him_Cook_last.Screen;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Let_Him_Cook_last
{
    public class Food : Sprite
    {
        public Vector2 foodPosition;
        public Rectangle foodBox;
        public Texture2D foodTexture;
        public int getFood;
        public bool OntableAble;

        public Food(Texture2D foodTexture, Vector2 foodPosition)
        {
            this.foodTexture = foodTexture;
            this.foodPosition = foodPosition;
            foodBox = new Rectangle((int)foodPosition.X, (int)foodPosition.Y, 50, 50);
            OntableAble = false;

        }

        public override void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();
            if (foodBox.Intersects(GameplayScreen.player.playerBox) && !OntableAble)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    OnCollision();

                }
            }
            foodBox = new Rectangle((int)foodPosition.X, (int)foodPosition.Y, 50, 50);
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(foodTexture, foodPosition, Color.White);
        }
        public virtual void OnCollision()
        {
            OntableAble = true;
            GameplayScreen.BagList.Add(this);
            GameplayScreen.IsPopUp = true;
            foreach (Food food in GameplayScreen.foodList)
            {
                GameplayScreen.foodList.Remove(this);
                break;
            }
        }


    }
}
