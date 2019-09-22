using System;
using Dodger.Core.Entities.Game.Components;
using Dodger.Core.Entities.Player;
using Dodger.Core.Entities.World;
using Dodger.Core.Handlers;
using Dodger.Core.Persistance.Repositories.EnemyRepository;
using Dodger.MonoGame.Handlers;
using Dodger.MonoGame.Renderers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Game = Dodger.Core.Entities.Game.Game;

namespace Dodger.MonoGame.Factories
{
    public class GameFactory
    {
        public Game CreateGame(IWorld world, Player player, SpriteBatch spriteBatch, ContentManager contentManager,
            GraphicsDeviceManager graphics)
        {
            if (world == null) throw new ArgumentNullException(nameof(world));
            if (player == null) throw new ArgumentNullException(nameof(player));
            if (spriteBatch == null) throw new ArgumentNullException(nameof(spriteBatch));
            if (contentManager == null) throw new ArgumentNullException(nameof(contentManager));
            if (graphics == null) throw new ArgumentNullException(nameof(graphics));

            var enemyRepository = new EnemyRepository();
            var gameComponents = BuildGameComponents(world, player, enemyRepository);
            var gameGraphicsComponents =
                BuildGameGraphicsComponents(enemyRepository, player, spriteBatch, contentManager, graphics);

            return new Game(gameComponents, gameGraphicsComponents);
        }

        private GameGraphicsComponents BuildGameGraphicsComponents(IEnemyRepository enemyRepository, Player player,
            SpriteBatch spriteBatch, ContentManager contentManager, GraphicsDeviceManager graphics)
        {
            if (enemyRepository == null) throw new ArgumentNullException(nameof(enemyRepository));
            if (player == null) throw new ArgumentNullException(nameof(player));
            if (spriteBatch == null) throw new ArgumentNullException(nameof(spriteBatch));
            if (contentManager == null) throw new ArgumentNullException(nameof(contentManager));
            if (graphics == null) throw new ArgumentNullException(nameof(graphics));

            var scoreRenderer = new ScoreRenderer(spriteBatch, contentManager);
            var playerRenderer = new PlayerRenderer(spriteBatch, contentManager);
            var enemyRenderer = new EnemyRenderer(spriteBatch, contentManager);
            var healthRenderer = new HealthRenderer(spriteBatch, contentManager);
            var inputHandler = new InputHandler(player);

            return new GameGraphicsComponents(scoreRenderer, enemyRenderer, playerRenderer,
                inputHandler, healthRenderer);
        }

        private GameComponents BuildGameComponents(IWorld world, IPlayer player, IEnemyRepository enemyRepository)
        {
            if (world == null) throw new ArgumentNullException(nameof(world));
            if (player == null) throw new ArgumentNullException(nameof(player));
            if (enemyRepository == null) throw new ArgumentNullException(nameof(enemyRepository));
            
            var enemySpawner = new EnemySpawner(enemyRepository, world);
            var enemyDisposer = new EnemyDisposer(enemyRepository, world);
            var scoreHandler = new ScoreHandler(player);

            return new GameComponents(enemySpawner, enemyDisposer, scoreHandler, world, player, enemyRepository);
        }
    }
}