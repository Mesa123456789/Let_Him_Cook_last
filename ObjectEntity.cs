using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Collisions;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Let_Him_Cook_last
{
    internal class ObjectEntity
    {
        private readonly Game1 _game;
        public IShapeF Bounds { get; }
        public ObjectEntity(Game1 game, RectangleF rectangleF)
        {
            _game = game;
            Bounds = rectangleF;
        }
        public virtual void Update(GameTime gameTime)
        {
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawRectangle((RectangleF)Bounds, Color.Red, 3);
        }
        public void OnCollision(CollisionEventArgs collisionInfo)
        {
        }
    }
}
