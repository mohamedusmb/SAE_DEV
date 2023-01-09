using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Content;

namespace Monogame
{
    public class ScreenLobby : GameScreen
    {
        private GraphicsDeviceManager _graphics;
        private TiledMap _tiledMap;
        private TiledMapRenderer _tiledMapRenderer;
        private SpriteBatch _spriteBatch;
        private Perso _perso;
        public Game1 game1;

        private Game1 _myGame;
        //private GraphicsDeviceManager _graphics;

        public SpriteBatch SpriteBatch { get; set; }

        // pour récupérer une référence à l’objet game pour avoir accès à tout ce qui est
        // défini dans Game1
        public ScreenLobby(Game1 game) : base(game)
        {
            _myGame = game;
        }
        public override void Initialize()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);


            base.Initialize();

        }
        public override void LoadContent()
        {
            _tiledMap = Content.Load<TiledMap>("mapLobby");
            _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            _tiledMapRenderer.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _tiledMapRenderer.Draw();

        }
    }

}