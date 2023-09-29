using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Screens
{
    public class GameplayScreen
    {
        private Texture2D crosshair;
        private SpriteFont timer;
        private SpriteFont scoreDisplay;
        private List<TargetSprite> targets;
        private int score;
        private TimeSpan gameTimeRemaining;
        public bool isGameOver;
        private int finalScore;
        private GraphicsDevice graphicsDevice;

        private SoundEffect shot;
        private Song backgroundMusic;

        public GameplayScreen(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
        }

        public void Initialize()
        {
            score = 0;
            gameTimeRemaining = TimeSpan.FromSeconds(10);
            isGameOver = false;

            targets = new List<TargetSprite>();
        }


        public void LoadContent(ContentManager content)
        {
            crosshair = content.Load<Texture2D>("crosshair");
            timer = content.Load<SpriteFont>("arial");
            scoreDisplay = content.Load<SpriteFont>("arial");
            shot = content.Load<SoundEffect>("shotgun-firing-4-6746");
            backgroundMusic = content.Load<Song>("gamemusic-6082");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(backgroundMusic);
        }


        public void Update(GameTime gameTime)
        {
            if (!isGameOver)
            {
                gameTimeRemaining -= gameTime.ElapsedGameTime;

                if(gameTimeRemaining <= TimeSpan.Zero)
                {
                    isGameOver = true;
                    finalScore = score;
                }
            }

            MouseState mouseState = Mouse.GetState();
            Rectangle crosshairBounds = new Rectangle(mouseState.Position.X, mouseState.Position.Y, 35, 35);

            if(mouseState.LeftButton == ButtonState.Pressed)
            {
                shot.Play();
            }

            foreach(var target in targets.ToList())
            {
                if (crosshairBounds.Intersects(target.Bounds) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    targets.Remove(target);
                    score++;
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            MouseState mouseState = Mouse.GetState();
            Vector2 crosshairPosition = new Vector2(mouseState.Position.X - 35 / 2, mouseState.Position.Y - 35 / 2);

            spriteBatch.Begin();
            spriteBatch.DrawString(timer, $"{gameTimeRemaining.TotalSeconds}", new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(scoreDisplay, $"Score: {score}", new Vector2(10, 40), Color.White);
            spriteBatch.End();

            if (isGameOver)
            {
                string gameOverText = "Game Over!";
                string scoreText = $"Final Score: {finalScore}";

                Vector2 gameOverPosition = new Vector2((graphicsDevice.Viewport.Width - scoreDisplay.MeasureString(gameOverText).X) / 2, graphicsDevice.Viewport.Height / 2 - 50);
                Vector2 scorePosition = new Vector2((graphicsDevice.Viewport.Width - scoreDisplay.MeasureString(scoreText).X) / 2, gameOverPosition.Y + 50);

                spriteBatch.Begin();
                spriteBatch.DrawString(scoreDisplay, gameOverText, gameOverPosition, Color.White);
                spriteBatch.DrawString(scoreDisplay, scoreText, scorePosition, Color.White);
                spriteBatch.End();
            }
        }
    }
}
