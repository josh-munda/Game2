using Game2.Screens;
using Game2.StateManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    public class Game2 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private GraphicsDevice _graphicsDevice;

        private ScreenManager screenManager;
        private StartScreen startScreen;
        private GameplayScreen gameplayScreen;

        private GameState currentGameState = GameState.StartScreen;

        public Game2()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //screenManager = new ScreenManager(Content);
            //_graphicsDevice = GraphicsDevice;
            //screenManager.ChangeScreen(new GameplayScreen(_graphicsDevice));

            _graphicsDevice = GraphicsDevice;
            screenManager = new ScreenManager(Content);
            startScreen = new StartScreen(_graphicsDevice);
            gameplayScreen = new GameplayScreen(_graphicsDevice);
            screenManager.ChangeScreen(startScreen);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //screenManager = new ScreenManager(Content);

            // TODO: use this.Content to load your game content here
            startScreen.LoadContent(Content);
            gameplayScreen.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            switch (currentGameState)
            {
                case GameState.StartScreen:
                    startScreen.Update(gameTime);
                    if (/* Add logic to switch to gameplay screen */)
                    {
                        currentGameState = GameState.Game;
                        screenManager.ChangeScreen(gameplayScreen);
                    }
                    break;

                case GameState.Game:
                    gameplayScreen.Update(gameTime);
                    // Add logic to switch back to the start screen if needed
                    break;
            }


            screenManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            switch (currentGameState)
            {
                case GameState.StartScreen:
                    startScreen.Draw(_spriteBatch);
                    break;

                case GameState.Game:
                    gameplayScreen.Draw(_spriteBatch);
                    break;
            }

            screenManager.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}