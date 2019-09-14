using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Dodger.Core.ValueObjects;

namespace Dodger.Core.Entities.Player.Components
{
    public class InputComponent : Core.Entities.Components.InputComponent.InputComponent
    {
        private readonly MainForm _form;
        private readonly Player _player;

        public InputComponent(MainForm form, Player player)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form));
            _player = player ?? throw new ArgumentNullException(nameof(player));
            ConfigureEvents();
        }

        private void ConfigureEvents()
        {
            _form.KeyDown += (sender, e) => SetDirection(e);
            _form.KeyUp += (sender, e) => StopMoving();
        }

        private void StopMoving()
        {
            _player.MovementComponent.StopMoving();
        }

        private void SetDirection(KeyEventArgs e)
        {
            var keyBindings = new Dictionary<Keys, Action>
            {
                {Keys.Up, () => MovePlayer(Keys.Up)},
                {Keys.Down, () => MovePlayer(Keys.Down)},
                {Keys.Left, () => MovePlayer(Keys.Left)},
                {Keys.Right, () => MovePlayer(Keys.Right)},
            };

            if (keyBindings.ContainsKey(e.KeyCode))
                keyBindings[e.KeyCode].Invoke();
        }

        private void MovePlayer(Keys key)
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