using System;
using System.Windows.Forms;
using Dodger.Core.Entities.Player;

namespace Dodger.Graphics.Handlers
{
    public class ScoreHandler : IScoreHandler
    {
        private readonly Player _player;
        private readonly Label _scoreLabel;

        public ScoreHandler(Player player, Label scoreLabel)
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
            _scoreLabel = scoreLabel ?? throw new ArgumentNullException(nameof(scoreLabel));
            ConfigureEventHandlers();
        }

        private void ConfigureEventHandlers()
        {
            _player.Score.ScoreChanged += (sender, e) => UpdateScoreLabel();
        }

        public void UpdateScoreLabel()
        {
            _scoreLabel.Text = _player.Score.Points.ToString();
        }
    }
}