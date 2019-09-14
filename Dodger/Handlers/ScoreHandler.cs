using System;
using System.Windows.Forms;
using Dodger.Core.Entities;
using Dodger.Core.Entities.Player;
using Dodger.Core.Handlers;

namespace Dodger.Handlers
{
    public class ScoreHandler : IScoreHandler
    {
        private readonly Timer _timer;
        private readonly Player _player;
        private readonly Label _scoreLabel;

        public ScoreHandler(Timer timer, Player player, Label scoreLabel)
        {
            _timer = timer ?? throw new ArgumentNullException(nameof(timer));
            _player = player ?? throw new ArgumentNullException(nameof(player));
            _scoreLabel = scoreLabel ?? throw new ArgumentNullException(nameof(scoreLabel));
        }

        public void StartCountingScore()
        {
            _timer.Tick += (sender, e) => AddPoint();
        }

        private void AddPoint()
        {
            _player.Score.AddPoint();
            _scoreLabel.Text = _player.Score.Points.ToString();
        }
    }
}