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
        public Texture2D StartButton;
        public Texture2D ExitButton;
        private SpriteFont spriteFont;
        private GraphicsDevice graphics;
        //private ContentManager contentManager;


        public StartScreen(GraphicsDevice graphicsDevice)
        {
            this.graphics = graphicsDevice;
            currentGameState = GameState.StartScreen;
        }

        public void Initialize()
        {

        }

        public void LoadContent(ContentManager content)
        {
            StartButton = content.Load<Texture2D>("start");
            ExitButton = content.Load<Texture2D>("exit");
            spriteFont = content.Load<SpriteFont>("arial");
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            // use mouse to select button
            if(currentGameState == GameState.StartScreen)
            {
                int screenWidth = graphics.Viewport.Width;
                int screenHeight = graphics.Viewport.Height;

                Rectangle startButtonRec = new Rectangle(screenWidth / 2 - StartButton.Width, screenHeight / 2 - StartButton.Height, StartButton.Width, StartButton.Height);
                Rectangle exitButtonRec = new Rectangle(screenWidth / 2 - ExitButton.Width, screenHeight / 2 + StartButton.Height, ExitButton.Width, ExitButton.Height);

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

        public void Draw(SpriteBatch spriteBatch)
        {
            if(currentGameState == GameState.StartScreen)
            {
                spriteBatch.Begin();

                spriteBatch.DrawString(spriteFont, $"Target Practice", new Vector2(250, 100), Color.White);
                spriteBatch.Draw(StartButton, new Vector2(300, 300), Color.White);
                spriteBatch.Draw(ExitButton, new Vector2(350, 350), Color.White);
                

                spriteBatch.End();
            }
        }
    }
}
