using Game2.StateManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Screens
{
    public class StartScreen
    {
        private GameState currentGameState;
        private Texture2D startButton;
        private Texture2D exitButton;
        private SpriteFont spriteFont;
        private SpriteBatch spriteBatch;

        public void LoadContent(ContentManager content)
        {
            startButton = content.Load<Texture2D>("start");
            exitButton = content.Load<Texture2D>("exit");
            spriteFont = content.Load<SpriteFont>("arial");
        }

        public void Update(GraphicsDevice graphics)
        {
            MouseState mouseState = Mouse.GetState();

            // use mouse to select button
            if(currentGameState == GameState.StartScreen)
            {
                int screenWidth = graphics.Viewport.Width;
                int screenHeight = graphics.Viewport.Height;

                Rectangle startButtonRec = new Rectangle(screenWidth / 2 - startButton.Width, screenHeight / 2 - startButton.Height, startButton.Width, startButton.Height);
                Rectangle exitButtonRec = new Rectangle(screenWidth / 2 - exitButton.Width, screenHeight / 2 + startButton.Height, exitButton.Width, exitButton.Height);

                // Go to gameplay screen when start button is clicked
                if(startButtonRec.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    currentGameState = GameState.Game;
                }
                // exit game when the exit button is clicked
                else if(exitButtonRec.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    //TODO add exit game when exit button is clicked

                }
            }
        }

        public void Draw(GameTime gameTime)
        {
            if(currentGameState == GameState.StartScreen)
            {
                spriteBatch.Begin();

                spriteBatch.DrawString(spriteFont, $"Target Practice", new Vector2(250, 100), Color.White);
                spriteBatch.Draw(startButton, new Vector2(300, 300), Color.White);
                spriteBatch.Draw(exitButton, new Vector2(350, 350), Color.White);
                

                spriteBatch.End();
            }
        }
    }
}
