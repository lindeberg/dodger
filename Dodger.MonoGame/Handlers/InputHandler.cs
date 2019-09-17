using System;
using Dodger.Core.Entities.Player;
using Dodger.Core.Graphics.Handlers;

namespace Dodger.MonoGame.Handlers
{
    public class InputHandler : IInputHandler
    {
        private readonly Player _player;

        public InputHandler(Player player)
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
            throw new NotImplementedException();
        }
    }
}