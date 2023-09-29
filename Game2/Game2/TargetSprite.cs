using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    public class TargetSprite
    {
        // The atlas for the target sprite
        private Texture2D target;

        // The position of the target
        public Vector2 Position { get; set; }

        // The velocity of the target when it is moving
        public Vector2 Velocity { get; set; }

        // The bounds of the target 
        public Rectangle Bounds => new Rectangle((int)Position.X, (int)Position.Y, 35, 35);

        // If the target is active on the game screen
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Creates new target sprite
        /// </summary>
        /// <param name="positoin">The current position of the target</param>
        public TargetSprite(Vector2 position, Vector2 velocity)
        {
            Position = position;
            Velocity = velocity;
        }

        /// <summary>
        /// Loads the target texture
        /// </summary>
        /// <param name="content">The ContentManager to use to load the content</param>
        public void LoadContent(ContentManager content)
        {
            target = content.Load<Texture2D>("target");
        }

        /// <summary>
        /// Updatest the targets
        /// </summary>
        /// <param name="gameTime">An object representing time in the game</param>
        public void Update(GraphicsDevice graphics)
        {
            if (IsActive) 
            {
                Position += Velocity;

                int screenWidth = graphics.Viewport.Width;
                int screenHeight = graphics.Viewport.Height;

                if (Position.X + 35 > screenHeight || Position.X < 0)
                {
                    Velocity = new Vector2(-Velocity.X, Velocity.Y);
                }

                if (Position.Y + 35 > screenWidth || Position.Y < 0)
                {
                    Velocity = new Vector2(Velocity.X, -Velocity.Y);
                }

                if(Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Point mousePosition = Mouse.GetState().Position;
                    if (Bounds.Contains(mousePosition))
                    {
                        IsActive = false;
                    }
                }
            } 
        }

        /// <summary>
        /// Draws the target
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to draw the sprite</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(target, Position, Color.White);
        }
    }
}
