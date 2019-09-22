using System;
using System.Collections.Generic;
using System.Linq;
using Dodger.Core.Entities.Player;
using Dodger.Core.Graphics.Handlers;
using Dodger.Core.ValueObjects;
using Microsoft.Xna.Framework.Input;

namespace Dodger.MonoGame.Handlers
{
    public class InputHandler : IInputHandler
    {
        private readonly Player _player;

        public InputHandler(Player player)
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
        }

        public void Update()
        {
            var keyboardState = Keyboard.GetState();

            if (!keyboardState.GetPressedKeys().Any())
            {
                _player.MovementComponent.StopMoving();
                return;
            }

            var keyDirections = new Dictionary<Keys, Direction>
            {
                {Keys.Up, Direction.Up},
                {Keys.Down, Direction.Down},
                {Keys.Left, Direction.Left},
                {Keys.Right, Direction.Right},
            };

            foreach (var key in keyboardState.GetPressedKeys())
            {
                if (keyDirections.TryGetValue(key, out var direction))
                {
                    _player.MovementComponent.SetDirection(direction);
                }
            }
        }
    }
}