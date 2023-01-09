using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame
{
    public class ScreenOptions : GameScreen
    {
        private Game1 _myGame;

        // pour récupérer une référence à l’objet game pour avoir accès à tout ce qui est 
        // défini dans Game1
        public ScreenOptions(Game1 game) : base(game)
        {
            _myGame = game;

        }
        public override void LoadContent()
        {

            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Back))
                _myGame.Etat = Game1.Etats.Menu;

        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Purple);
            _myGame.SpriteBatch.Begin();

            _myGame.SpriteBatch.End();


        }
    }
}