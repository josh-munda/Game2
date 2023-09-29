using Game2.StateManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game2.Screens
{
    public class ScreenManager
    {
        private StartScreen currentScreen;
        private GameplayScreen nextScreen;
        private ContentManager contentManager;

        public StartScreen CurrentScreen => currentScreen;
        public GameplayScreen NextScreen => nextScreen;

        public ScreenManager(ContentManager contentManager, StartScreen startScreen, GameplayScreen newScreen)
        {
            this.contentManager = contentManager;
            currentScreen = startScreen;
            currentScreen.Initialize();
            nextScreen = newScreen;
            nextScreen.Initialize();
        }

        /// <summary>
        /// Changes the screens
        /// </summary>
        /// <param name="newScreen">The new screen</param>
        public void ChangeScreen(GameplayScreen newScreen)
        {
            nextScreen = newScreen;
            nextScreen.Initialize();
        }

        /// <summary>
        /// Updates the things it needs to update for the screen
        /// </summary>
        /// <param name="gameTime">The game time</param>
        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }

        /// <summary>
        /// Draws the things it needs to draw for the screen
        /// </summary>
        /// <param name="spriteBatch">The sprites to draw</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
        }
    }
}
