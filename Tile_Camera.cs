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

        public static OrthographicCamera _camera;
        public Vector2 _cameraPosition;
        public static Vector2 _bgPosition;
        Game1 game;
        Player player;
        public Tile_Camera(Vector2 _cameraPosition)
        {
            this._cameraPosition = _cameraPosition;
            var viewportadapter = new BoxingViewportAdapter(game.Window, game.GraphicsDevice, 800, 450);
            _camera = new OrthographicCamera(viewportadapter);//******//
            _bgPosition = new Vector2(400, 225);//******//

        }
        public void UpdateCamera(Vector2 move)
        {
            _camera.LookAt(Game1._bgPosition + _cameraPosition);//******//
            _cameraPosition += move;
        }
        
        public void Draw()
        {
            var transformMatrix = _camera.GetViewMatrix();//******//
        }

        public float GetCameraPosX()
        {
            return _cameraPosition.X;
        }
        public float GetCameraPosY()
        {
            return _cameraPosition.Y;
        }
    }
}
