using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;

namespace Monogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        private readonly ScreenManager _screenManager;
        public const int LARGEUR_FENETRE = 704;
        public const int LONGUEUR_FENETRE = 1120;

        // on définit les différents états possibles du jeu ( à compléter) 
        public enum Etats { Menu, Options, Play, Quit };

        // on définit un champ pour stocker l'état en cours du jeu
        private Etats etat;

        // on définit  2 écrans ( à compléter )
        private ScreenMenu _screenMenu;
        private ScreenLobby _screenLobby;
        private ScreenOptions _screenOption;

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

        public Etats Etat
        {
            get
            {
                return this.etat;
            }

            set
            {
                this.etat = value;
            }
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _screenManager = new ScreenManager();
            Components.Add(_screenManager);

            // Par défaut, le 1er état flèche l'écran de menu
            Etat = Etats.Menu;

            // on charge les 2 écrans 
            _screenMenu = new ScreenMenu(this);
            _screenLobby = new ScreenLobby(this);
            _screenOption = new ScreenOptions(this);

        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = LONGUEUR_FENETRE;
            _graphics.PreferredBackBufferHeight = LARGEUR_FENETRE;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            // on charge l'écran de menu par défaut 
            _screenManager.LoadScreen(_screenMenu, new FadeTransition(GraphicsDevice, Color.Black));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // On teste le clic de souris et l'état pour savoir quelle action faire 
            MouseState _mouseState = Mouse.GetState();
            if (_mouseState.LeftButton == ButtonState.Pressed)
            {
                // Attention, l'état a été mis à jour directement par l'écran en question
                if (this.Etat == Etats.Quit)
                    Exit();

                else if (this.Etat == Etats.Play)
                    _screenManager.LoadScreen(_screenLobby, new FadeTransition(GraphicsDevice, Color.Black));
                else if (this.Etat == Etats.Options)
                    _screenManager.LoadScreen(_screenOption, new FadeTransition(GraphicsDevice, Color.Black));

            }

            if (Keyboard.GetState().IsKeyDown(Keys.Back))
            {
                if (this.Etat == Etats.Menu)
                    _screenManager.LoadScreen(_screenMenu, new FadeTransition(GraphicsDevice, Color.Black));
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }
    }
}