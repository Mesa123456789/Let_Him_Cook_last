using Let_Him_Cook_last.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.ViewportAdapters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Let_Him_Cook_last
{
    public class Tile_Camera
    {
        public void UpdateCamera()
        {
            _camera.LookAt(Game1._bgPosition + _cameraPosition);//******//
            _cameraPosition += player.move;
        }

    }
}
