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
    public class Perso : GameScreen
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Vector2 _positionPerso;
        public AnimatedSprite _perso;
        public Texture2D _texturePerso;


        public static Game1 _myGame;
        //private GraphicsDeviceManager _graphics;

        public SpriteBatch SpriteBatch { get; set; }

        // pour récupérer une référence à l’objet game pour avoir accès à tout ce qui est
        // défini dans Game1
        public Perso(Game1 game,SpriteBatch spriteBatch) : base(game)
        {
            _myGame = game;
            this.SpriteBatch = spriteBatch;
        }
        public override void Initialize()
        {         
            _positionPerso = new Vector2(20, 340);
            base.Initialize();

        }
        public override void LoadContent()
        {
            //_texturePerso = Content.Load<Texture2D>("perso");         
            SpriteSheet spriteSheet = _myGame.Content.Load<SpriteSheet>("perso.sf", new JsonContentLoader());
            _perso = new AnimatedSprite(spriteSheet);
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                _myGame.Exit();

            _perso.Play("idle"); // une des animations définies dans « animation.sf »
            _perso.Update(gameTime); // time écoulé 
            _perso.Update(deltaTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(_texturePerso, _positionPerso, Color.White);
            _spriteBatch.End();

        }
    }
}