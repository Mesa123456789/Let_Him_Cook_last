using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

using MonoGame.Extended.Collisions;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.Tiled;
using MonoGame.Extended;
using MonoGame.Extended.Timers;
using MonoGame.Extended.ViewportAdapters;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input;
using Let_Him_Cook_last.Sprite;


namespace Let_Him_Cook_last.Screen
{
    public class RestauarntScreen : screen
    {
        Texture2D popup;
        Texture2D texture;
        AnimatedTexture SpriteTexture;
        Player player;
        Vector2 playerPos = Vector2.Zero;
        TiledMap _tiledMap;
        TiledMapRenderer _tiledMapRenderer;
        TiledMapObjectLayer _platformTiledObj;
        private readonly List<IEntity> _entities = new List<IEntity>();
        public readonly CollisionComponent _collisionComponent;
        //Camera _camera;
        Game1 game;
        RectangleF Bounds = new RectangleF(new Vector2(180,330), new Vector2(40, 60));


        //Tile_FrontRestaurant Tile_Wall_Frontres
        public RestauarntScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            Game1._bgPosition = new Vector2(400, 225);//******/
            SpriteTexture = new AnimatedTexture(new Vector2(0, 0), 0, 1.0f, 0.5f);
            SpriteTexture.Load(game.Content, "Char01_1", 5, 4, 5);
            player = new Player(SpriteTexture, playerPos, game, Bounds);
            popup = game.Content.Load<Texture2D>("popup");

            //Load the background texture for the screen

            _collisionComponent = new CollisionComponent(new RectangleF(0, 0, 800, 450));


            _tiledMap = game.Content.Load<TiledMap>("Tile_Inrestaurant");

            _tiledMapRenderer = new TiledMapRenderer(game.GraphicsDevice, _tiledMap);
            //Get object layers
            foreach (TiledMapObjectLayer layer in _tiledMap.ObjectLayers)
            {
                if (layer.Name == "Tile_Wall_Inretaurant")
                {
                    _platformTiledObj = layer;
                }
            }
            foreach (TiledMapObject obj in _platformTiledObj.Objects)
            {
                Vector2 position = new Vector2(obj.Position.X, obj.Position.Y);
                _entities.Add(new PlatformEntity(game, new RectangleF(position, obj.Size)));
            }

            _entities.Add(player);

            foreach (IEntity entity in _entities)
            {
                _collisionComponent.Insert(entity);


            }
            this.game = game;
        }

        RectangleF mouseRec;
        RectangleF doorRec = new RectangleF(100,40, 100, 20);
        public override void Update(GameTime theTime)
        {
            if (player.Bounds.Intersects(doorRec))
            {
                ScreenEvent.Invoke(game.CandyScreen, new EventArgs());
                playerPos = new Vector2(0, 0);
                return;
            }
            MouseState ms = Mouse.GetState();

            mouseRec = new RectangleF(ms.X, ms.Y, 50, 50);
            foreach (IEntity entity in _entities)
            {
                entity.Update(theTime);
            }
            _collisionComponent.Update(theTime);
            _tiledMapRenderer.Update(theTime);
            player.Update(theTime);
            base.Update(theTime);
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {

            _tiledMapRenderer.Draw();//******//
            _spriteBatch.End();
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);//******//
            foreach (IEntity entity in _entities)
            {
                entity.Draw(_spriteBatch);
            }
            _spriteBatch.Draw(popup, new Rectangle((int)doorRec.X, (int)doorRec.Y, (int)doorRec.Width, (int)doorRec.Height), Color.White);
            player.Draw(_spriteBatch);
            _spriteBatch.End();

            _spriteBatch.Begin();



        }

    }
}

