using System;
using System.Windows.Forms;
using Dodger.Core.Entities.Player;
using Dodger.Core.Graphics.Handlers;
using Dodger.Core.Graphics.Renderers;

namespace Dodger.Graphics.Renderers
{
    public class HealthRenderer : IHealthRenderer
    {
        private readonly Label _healthValueLabel;

        public HealthRenderer(Label healthValueLabel)
        {
            _healthValueLabel = healthValueLabel ?? throw new ArgumentNullException(nameof(healthValueLabel));
        }
        public void Render(IPlayer player)
        {
            _healthValueLabel.Text = player.Health.Points.ToString();
        }
    }
}