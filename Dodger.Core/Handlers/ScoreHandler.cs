using System;
using Dodger.Core.Entities.Player;

namespace Dodger.Core.Handlers
{
    public class ScoreHandler : IScoreHandler
    {
        private readonly IPlayer _player;

        public ScoreHandler(IPlayer player)
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
        }

        public void AddPoint()
        {
            _player.Score.AddPoint();
        }
    }
}