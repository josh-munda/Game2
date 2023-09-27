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
    public class GameplayScreen
    {
        private Texture2D crosshair;
        private SpriteFont timer;
        private SpriteFont scoreDisplay;
        private List<TargetSprite> targets;
        private int score;
        private TimeSpan gameTimeRemaining;
        private bool isGameOver;

        
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
            timer = content.Load<SpriteFont>("consolas");
            scoreDisplay = content.Load<SpriteFont>("consolas");
        }


        public void Update(GameTime gameTime)
        {
            if (!isGameOver)
            {
                if(gameTimeRemaining <= TimeSpan.Zero)
                {
                    isGameOver = true;
                }
            }

            MouseState mouseState = Mouse.GetState();
            Rectangle crosshairBounds = new Rectangle(mouseState.Position.X, mouseState.Position.Y, crosshair.Width, crosshair.Height);

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
            
        }
    }
}
