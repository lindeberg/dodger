using Dodger.Core.Entities.World;
using Dodger.Core.Factories;
using Dodger.Core.ValueObjects;
using Dodger.MonoGame.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dodger.MonoGame
{
    public class GameWindow : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private readonly Core.Entities.Game.Game _game;

        public GameWindow()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = @"Content\bin";
            
            var world = new World(new Size(Window.ClientBounds.Width, Window.ClientBounds.Height));
            var player = new PlayerFactory().CreatePlayer(world);
            _game = new GameFactory().CreateGame(world, player, _spriteBatch, Content);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            _game.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _spriteBatch.Begin();
            _game.Render();
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}