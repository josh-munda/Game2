using Game2.StateManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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
        public bool IsStartClicked = false;
        public bool IsExitClicked = false;
        private SpriteFont spriteFont;
        private GraphicsDevice graphics;
        private Song backgroundMusic;
        private SoundEffect shot;
        private Texture2D crosshair;
        //private ContentManager contentManager;


        public StartScreen(GraphicsDevice graphicsDevice)
        {
            this.graphics = graphicsDevice;
            currentGameState = GameState.StartScreen;
        }

        public void Initialize()
        {
            //Mouse.SetCursor(crosshair);
        }

        public void LoadContent(ContentManager content)
        {
            crosshair = content.Load<Texture2D>("crosshair");
            StartButton = content.Load<Texture2D>("start");
            ExitButton = content.Load<Texture2D>("exit");
            spriteFont = content.Load<SpriteFont>("arial");
            backgroundMusic = content.Load<Song>("gamemusic-6082");
            shot = content.Load<SoundEffect>("shotgun-firing-4-6746");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(backgroundMusic);
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            // use mouse to select button
            if(currentGameState == GameState.StartScreen)
            {
                int screenWidth = graphics.Viewport.Width;
                int screenHeight = graphics.Viewport.Height;

                Rectangle startButtonRec = new Rectangle(screenWidth / 2 - 64, screenHeight / 2 - 22, 64, 22);
                Rectangle exitButtonRec = new Rectangle(screenWidth / 2 - 64, screenHeight / 2 + 22, 64, 22);

                if(mouseState.LeftButton == ButtonState.Pressed)
                {
                    shot.Play();
                }

                // Go to gameplay screen when start button is clicked
                if(startButtonRec.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    IsStartClicked = true;
                    currentGameState = GameState.Game;
                }
                // exit game when the exit button is clicked
                else if(exitButtonRec.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    IsExitClicked = true;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(currentGameState == GameState.StartScreen)
            {
                spriteBatch.Begin();

                spriteBatch.DrawString(spriteFont, $"Target Practice", new Vector2(300, 100), Color.Black);
                spriteBatch.Draw(StartButton, new Vector2(375, 300), Color.White);
                spriteBatch.Draw(ExitButton, new Vector2(375, 350), Color.White);

                spriteBatch.End();
            }
        }
    }
}
