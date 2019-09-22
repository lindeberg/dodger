using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Dodger.Core.Entities.Player;
using Dodger.Core.Graphics.Handlers;
using Dodger.Core.ValueObjects;

namespace Dodger.WinForms.Handlers
{
    public class InputHandler : IInputHandler
    {
        private readonly MainForm _form;
        private readonly IPlayer _player;
        private Keys? _currentKey;

        public InputHandler(IPlayer player, MainForm form)
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
            _form = form ?? throw new ArgumentNullException(nameof(form));

            ConfigureEvents();
        }

        public void Update()
        {
            if (_currentKey.HasValue)
            {
                Move(_currentKey.Value);
            }
            else
            {
                StopMoving();
            }
        }

        private void ConfigureEvents()
        {
            _form.KeyDown += (sender, e) => _currentKey = e.KeyCode;
            _form.KeyUp += (sender, e) => _currentKey = null;
        }

        private void StopMoving()
        {
            _player.MovementComponent.StopMoving();
        }

        private void Move(Keys key)
        {
                var keyDirections = new Dictionary<Keys, Direction>
                {
                    {Keys.Up, Direction.Up},
                    {Keys.Down, Direction.Down},
                    {Keys.Left, Direction.Left},
                    {Keys.Right, Direction.Right},
                };

            var direction = keyDirections[key];

            _player.MovementComponent.SetDirection(direction);
        }
    }
}