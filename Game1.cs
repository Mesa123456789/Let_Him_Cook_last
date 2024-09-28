using Let_Him_Cook_last.Screen;
using Let_Him_Cook_last.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using System;

namespace Let_Him_Cook_last
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public GameplayScreen GameplayScreen;
        public CandyScreen CandyScreen;
        SeaScreen SeaScreen;
        public RestauarntScreen RestauarntScreen;
        public TitleScreen TitleScreen;
        public screen mCurrentScreen;
        public static Vector2 _bgPosition;
        Tile_Camera _camera;
        Player player;
        public static Vector2 move;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 450;
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            GameplayScreen = new GameplayScreen(this, new EventHandler(GameplayScreenEvent));
            TitleScreen = new TitleScreen(this, new EventHandler(GameplayScreenEvent));
            RestauarntScreen = new RestauarntScreen(this, new EventHandler(GameplayScreenEvent));
            CandyScreen = new CandyScreen(this, new EventHandler(GameplayScreenEvent));
            SeaScreen = new SeaScreen(this, new EventHandler(GameplayScreenEvent));
            mCurrentScreen = GameplayScreen;
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
           Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            _camera.UpdateCamera(player.);


            mCurrentScreen.Update(gameTime);
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            mCurrentScreen.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
        public void GameplayScreenEvent(object obj, EventArgs e)
        {
            mCurrentScreen = (screen)obj;
        }

        
    }
}
