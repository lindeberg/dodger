using Dodger.Core.Entities.Game;
using Dodger.Core.Entities.Player;
using Dodger.Core.Entities.World;
using Dodger.Core.Handlers;
using Dodger.Core.Persistance.Repositories.EnemyRepository;
using Dodger.MonoGame.Handlers;
using Dodger.MonoGame.Renderers;
using Microsoft.Xna.Framework.Graphics;

namespace Dodger.MonoGame.Factories
{
    public class GameFactory
    {
        public Game CreateGame(IWorld world, Player player, GameWindow gameWindow, SpriteBatch spriteBatch)
        {
            var enemyRepository = new EnemyRepository();
            var gameComponents = BuildGameComponents(world, player, enemyRepository);
            var gameGraphicsComponents = BuildGameGraphicsComponents(enemyRepository, player, gameWindow, spriteBatch);

            return new Game(gameComponents, gameGraphicsComponents);
        }

        private GameGraphicsComponents BuildGameGraphicsComponents(IEnemyRepository enemyRepository, Player player,
            GameWindow gameWindow, SpriteBatch spriteBatch)
        {
            var scoreRenderer = new ScoreRenderer(spriteBatch);
            var playerRenderer = new PlayerRenderer();
            var enemyRenderer = new EnemyRenderer(enemyRepository);
            var healthRenderer = new HealthRenderer();
            var inputHandler = new InputHandler(player);

            return new GameGraphicsComponents(scoreRenderer, enemyRenderer, playerRenderer,
                inputHandler, healthRenderer);
        }

        private GameComponents BuildGameComponents(IWorld world, IPlayer player, IEnemyRepository enemyRepository)
        {
            var enemySpawner = new EnemySpawner(enemyRepository, world);
            var enemyDisposer = new EnemyDisposer(enemyRepository, world);
            var scoreHandler = new ScoreHandler(player);

            return new GameComponents(enemySpawner, enemyDisposer, scoreHandler, world, player, enemyRepository);
        }
    }
}