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
    public class SeaScreen : screen
    {

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
        RectangleF Bounds = new RectangleF(new Vector2(200, 250), new Vector2(40, 60));


        //Tile_FrontRestaurant Tile_Wall_Frontres
        public SeaScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            var viewportadapter = new BoxingViewportAdapter(game.Window, game.GraphicsDevice, 800, 450);
            Game1._camera = new OrthographicCamera(viewportadapter);//******//
            Game1._bgPosition = new Vector2(400, 225);//******//


            SpriteTexture = new AnimatedTexture(new Vector2(0, 0), 0, 1.0f, 0.5f);
            SpriteTexture.Load(game.Content, "Char01_1", 5, 4, 5);
            player = new Player(SpriteTexture, playerPos, game, Bounds);
            //Load the background texture for the screen

            _collisionComponent = new CollisionComponent(new RectangleF(0, 0, 1600, 900));


            _tiledMap = game.Content.Load<TiledMap>("Map_Candy");

            _tiledMapRenderer = new TiledMapRenderer(game.GraphicsDevice, _tiledMap);
            //Get object layers
            foreach (TiledMapObjectLayer layer in _tiledMap.ObjectLayers)
            {
                if (layer.Name == "Wall")
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
        public override void Update(GameTime theTime)
        {
            MouseState ms = Mouse.GetState();

            mouseRec = new RectangleF(ms.X, ms.Y, 50, 50);
            foreach (IEntity entity in _entities)
            {
                entity.Update(theTime);
            }
            _collisionComponent.Update(theTime);
            _tiledMapRenderer.Update(theTime);

            Game1._camera.LookAt(Game1._bgPosition + Game1._cameraPosition);//******//
            player.Update(theTime);
            base.Update(theTime);
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {

            var transformMatrix = Game1._camera.GetViewMatrix();//******//
            _tiledMapRenderer.Draw(transformMatrix);//******//
            _spriteBatch.End();
            _spriteBatch.Begin(transformMatrix: transformMatrix, samplerState: SamplerState.PointClamp);//******//
            foreach (IEntity entity in _entities)
            {
                entity.Draw(_spriteBatch);
            }
            player.Draw(_spriteBatch);
            _spriteBatch.End();

            _spriteBatch.Begin();
            


        }

    }
}

