﻿
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;


namespace Let_Him_Cook_last
{
    public class Player : IEntity, ICollisionActor
    {
        private readonly Point _mapTileSize = new(50, 30);
        public Vector2 CharPosition = new Vector2(3, 3);
        public Vector2 CharInventory = new Vector2(575, 395);
        AnimatedTexture SpriteTexture;
        int speed = 2;
        public int Life = 10;
        private Viewport viewport;
        private Matrix _translation;

        public enum Direction { Left, Right, Up, Down }
        public Direction direction { get; set; }

        public Rectangle playerBox;

        private readonly Game1 _game;
        public int Velocity = 4;

        Vector2 move;
        public IShapeF Bounds { get; }
        private KeyboardState ks;
        private KeyboardState _oldKey;

        public Player(AnimatedTexture SpriteTexture, Vector2 CharPosition , Game1 game, IShapeF circleF)
        {

            this.SpriteTexture = SpriteTexture;
            this.CharPosition = CharPosition;
            direction = Direction.Right;
            playerBox = new Rectangle((int)CharPosition.X, (int)CharPosition.Y, 64, 64);
            _game = game;
            Bounds = circleF;
        }



        public void Update(GameTime gameTime)
        {

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            SpriteTexture.Pause();

            Vector2 velocity = Vector2.Zero;


            //if (Keyboard.GetState().IsKeyDown(Keys.W))
            //{

            //    velocity.Y -= 1;
            //    SpriteTexture.Play();
            //    direction = Direction.Down;

            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.S))
            //{

            //    velocity.Y += 1;
            //    SpriteTexture.Play();
            //    direction = Direction.Right;
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.D))
            //{

            //    velocity.X += 1;
            //    SpriteTexture.Play();
            //    direction = Direction.Right;
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.A))
            //{

            //    velocity.X -= 1;
            //    SpriteTexture.Play();
            //    direction = Direction.Left;
            //}






            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            CharPosition += velocity * speed;

            CharPosition.X = MathHelper.Clamp(CharPosition.X, 0, Game1.WindowSize.X - playerBox.Width);
            CharPosition.Y = MathHelper.Clamp(CharPosition.Y, 0, Game1.WindowSize.Y - playerBox.Height);


            playerBox.Location = CharPosition.ToPoint();

            SpriteTexture.UpdateFrame(elapsed);

            playerBox = new Rectangle((int)CharPosition.X, (int)CharPosition.Y, 64, 64);

        }


        public void Draw(SpriteBatch _spriteBatch)
        {

            SpriteTexture.DrawFrame(_spriteBatch, CharPosition, (int)direction + 1);

        }

        public void DrawInventory(SpriteBatch _spriteBatch)
        {

            SpriteTexture.DrawFrame(_spriteBatch, CharInventory, (int)direction + 1);

        }
    }
}
