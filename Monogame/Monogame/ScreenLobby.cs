using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Content;
using MonoGame.Extended.Screens.Transitions;

namespace Monogame
{
    public class ScreenLobby : GameScreen
    {
        private GraphicsDeviceManager _graphics;
        private TiledMap _tiledMap;
        private TiledMapRenderer _tiledMapRenderer;
        private SpriteBatch _spriteBatch;
        public Game1 game1;
        public Perso perso;
        private TiledMapTileLayer mapLayer;

        private Game1 _myGame;

        public SpriteBatch SpriteBatch
        {
            get
            {
                return this._spriteBatch;
            }

            set
            {
                this._spriteBatch = value;
            }
        }

        //private GraphicsDeviceManager _graphics;



        // pour récupérer une référence à l’objet game pour avoir accès à tout ce qui est
        // défini dans Game1
        public ScreenLobby(Game1 game) : base(game)
        {
            _myGame = game;
        }
        public override void Initialize()
        {
            
            perso = new Perso(game1,this.SpriteBatch);
            perso.Initialize();
            base.Initialize();

        }
        public override void LoadContent()
        {
            perso.LoadContent();
            _tiledMap = Content.Load<TiledMap>("mapLobby");
            _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);
            mapLayer = _tiledMap.GetLayer<TiledMapTileLayer>("obstacles");
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            _tiledMapRenderer.Update(gameTime);
            perso.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _tiledMapRenderer.Draw();
            perso.Draw(gameTime);

        }
        public bool IsCollision(ushort x, ushort y)
        {
            // définition de tile qui peut être null (?)
            TiledMapTile? tile;
            if (mapLayer.TryGetTile(x, y, out tile) == false)
                return false;
            if (!tile.Value.IsBlank)
                return true;
            return false;
        }
    }

}