using System;
using Dodger.Core.Entities.Game;
using Dodger.Core.Entities.Game.Components;
using Dodger.Core.Entities.Player;
using Dodger.Core.Entities.World;
using Dodger.Core.Handlers;
using Dodger.Core.Persistance.Repositories.EnemyRepository;
using Dodger.WinForms.Handlers;
using Dodger.WinForms.Renderers;

namespace Dodger.WinForms.Factories
{
    public class GameFactory
    {
        public Game CreateGame(IWorld world, Player player, MainForm form)
        {
            if (world == null) throw new ArgumentNullException(nameof(world));
            if (player == null) throw new ArgumentNullException(nameof(player));
            if (form == null) throw new ArgumentNullException(nameof(form));

            var enemyRepository = new EnemyRepository();
            var gameComponents = BuildGameComponents(world, player, enemyRepository);
            var gameGraphicsComponents = BuildGameGraphicsComponents(enemyRepository, player, form);

            return new Game(gameComponents, gameGraphicsComponents);
        }

        private GameGraphicsComponents BuildGameGraphicsComponents(IEnemyRepository enemyRepository, Player player,
            MainForm form)
        {
            var scoreRenderer = new ScoreRenderer(form.ScoreValueLabel);
            var playerRenderer = new PlayerRenderer(form);
            var enemyRenderer = new EnemyRenderer(form, enemyRepository);
            var healthRenderer = new HealthRenderer(form.HealthValueLabel);
            var inputHandler = new InputHandler(player, form);

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