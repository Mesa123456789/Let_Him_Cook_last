using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

using MonoGame.Extended.Collisions;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.Tiled;
using MonoGame.Extended;
using MonoGame.Extended.Timers;


namespace Let_Him_Cook_last
{
    public class CandyScreen : screen
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

        Game1 game; 
        public CandyScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            SpriteTexture = new AnimatedTexture(new Vector2(0, 0), 0, 1.0f, 0.5f);
            player = new Player(SpriteTexture, playerPos);
            SpriteTexture.Load(game.Content, "Char01_1", 5, 4, 10);
            //Load the background texture for the screen
            texture = game.Content.Load<Texture2D>("In_Restaurant");

            _collisionComponent = new CollisionComponent(new RectangleF(0, 0, 1600,900));
            
            
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


            foreach (IEntity entity in _entities)
            {
                _collisionComponent.Insert((ICollisionActor)entity);


            }
            this.game = game;
        }
        public override void Update(GameTime theTime)
        {
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
                       
            _tiledMapRenderer.Draw();
            _spriteBatch.End();
            _spriteBatch.Begin();
            foreach (IEntity entity in _entities)
            {
                entity.Draw(_spriteBatch);
            }
            player.Draw(_spriteBatch);
            
        }
         
        }
    }

