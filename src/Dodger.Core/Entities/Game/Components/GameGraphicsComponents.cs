using System;
using Dodger.Core.Graphics.Handlers;
using Dodger.Core.Graphics.Renderers;

namespace Dodger.Core.Entities.Game.Components
{
    public class GameGraphicsComponents
    {
        public GameGraphicsComponents(IScoreRenderer scoreRenderer, IEnemyRenderer enemyRenderer,
            IPlayerRenderer playerRenderer,
            IInputHandler inputHandler, IHealthRenderer healthRenderer)
        {
            ScoreRenderer = scoreRenderer ?? throw new ArgumentNullException(nameof(scoreRenderer));
            EnemyRenderer = enemyRenderer ?? throw new ArgumentNullException(nameof(enemyRenderer));
            PlayerRenderer = playerRenderer ?? throw new ArgumentNullException(nameof(playerRenderer));
            InputHandler = inputHandler ?? throw new ArgumentNullException(nameof(inputHandler));
            HealthRenderer = healthRenderer ?? throw new ArgumentNullException(nameof(healthRenderer));
        }

        public IScoreRenderer ScoreRenderer { get; set; }
        public IEnemyRenderer EnemyRenderer { get; set; }
        public IPlayerRenderer PlayerRenderer { get; set; }
        public IInputHandler InputHandler { get; set; }
        public IHealthRenderer HealthRenderer { get; set; }
    }
}