using System;
using System.Windows.Forms;
using Dodger.Core.Entities.Player;
using Dodger.Core.Graphics.Handlers;
using Dodger.Core.Graphics.Renderers;

namespace Dodger.Graphics.Renderers
{
    public class ScoreRenderer : IScoreRenderer
    {
        private readonly Label _scoreValueLabel;

        public ScoreRenderer(Label scoreValueLabel)
        {
            _scoreValueLabel = scoreValueLabel ?? throw new ArgumentNullException(nameof(scoreValueLabel));
        }

        public void Render(IPlayer player)
        {
            _scoreValueLabel.Text = player.Score.Points.ToString();
        }
    }
}