using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using System.Net.Mime;


namespace Let_Him_Cook_last.Sprite
{
    public class Player : IEntity, ICollisionActor
    {

        public Vector2 CharPosition;
        AnimatedTexture SpriteTexture;
        public enum Direction { Left, Right, Up, Down }
        public Direction direction { get; set; }

        private readonly Game1 _game;
        public int Velocity = 2;
        public Vector2 move;
        public IShapeF Bounds { get; }
        private KeyboardState ks;
        private KeyboardState _oldKey;
        Texture2D test;

        public Player(AnimatedTexture SpriteTexture, Vector2 CharPosition, Game1 game, IShapeF circleF)
        {

            this.SpriteTexture = SpriteTexture;
            this.CharPosition = CharPosition;
            direction = Direction.Right;
            _game = game;
            Bounds = circleF;
            SpriteTexture = new AnimatedTexture(new Vector2(0, 0), 0, 1.0f, 0.5f);
        }

        public void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            SpriteTexture.Pause();
            KeyboardState ks = Keyboard.GetState();
            ks = Keyboard.GetState();
            

            //if (Velocity != 0)
            //{
            //    velocity.Normalize();
            //}
            if (ks.IsKeyDown(Keys.D) && Bounds.Position.X < 1600 - ((RectangleF)Bounds).Width)
            {
                move = new Vector2(Velocity, 0) * gameTime.GetElapsedSeconds() * 42;
                move.Normalize();
                if (Bounds.Position.X - _game.GetCameraPosX() >= 400 && _game.GetCameraPosX() < 700)
                {
                    _game.UpdateCamera(move);
                }

                Bounds.Position += move;
                SpriteTexture.Play();
                direction = Direction.Right;
            }
            if (ks.IsKeyDown(Keys.A) && Bounds.Position.X > 0 - ((RectangleF)Bounds).Width)
            {
                move = new Vector2(-Velocity, 0) * gameTime.GetElapsedSeconds() * 42;
                move.Normalize();
                if (Bounds.Position.X - _game.GetCameraPosX() <= 400 && _game.GetCameraPosX() > 0)
                {
                    _game.UpdateCamera(move);
                }

                Bounds.Position += move;
                SpriteTexture.Play();
                direction = Direction.Left;
            }
            if (ks.IsKeyDown(Keys.S) && Bounds.Position.Y < 900 - ((RectangleF)Bounds).Height)
            {
                move = new Vector2(0, Velocity) * gameTime.GetElapsedSeconds() * 42;
                move.Normalize();
                if (Bounds.Position.Y - _game.GetCameraPosY() >= 225 && _game.GetCameraPosY() < 450)
                {
                    _game.UpdateCamera(move);
                }
                Bounds.Position += move;
                SpriteTexture.Play();
                direction = Direction.Right;
            }
            if (ks.IsKeyDown(Keys.W) && Bounds.Position.Y > 0 - ((RectangleF)Bounds).Height)
            {
                move = new Vector2(0, -Velocity) * gameTime.GetElapsedSeconds() * 42;
                move.Normalize();
                if (Bounds.Position.Y - _game.GetCameraPosY() <= 225 && _game.GetCameraPosY() > 0)
                {
                    _game.UpdateCamera(move);
                }
                Bounds.Position += move;
                SpriteTexture.Play();
                direction = Direction.Down;
            }
            if (move != Vector2.Zero)
            {
                move.Normalize();
            }

            SpriteTexture.UpdateFrame(elapsed);

        }


        public void Draw(SpriteBatch _spriteBatch)
        {
            //_spriteBatch.Draw(test, new Rectangle((int)((RectangleF)Bounds).X, (int)((RectangleF)Bounds).Y, 72,64),new Rectangle(0,0,64,64), Color.White);
            SpriteTexture.DrawFrame(_spriteBatch, new Vector2((int)((RectangleF)Bounds).X - 10, (int)((RectangleF)Bounds).Y), (int)direction + 1);


        }

        public void OnCollision(CollisionEventArgs collisionInfo)
        {
            if (collisionInfo.Other.ToString().Contains("PlatformEntity"))
            {
                Bounds.Position -= collisionInfo.PenetrationVector;
            }

        }
    }
}
