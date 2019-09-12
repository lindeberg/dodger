using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Dodger.Annotations;
using Dodger.Core.Entities;
using Dodger.Core.Handlers;
using Dodger.Core.ValueObjects;

namespace Dodger.Handlers
{
    public class PlayerMover : IPlayerMover
    {
        private readonly Player _player;
        private readonly PictureBox _pictureBox;
        private readonly MainForm _mainForm;
        private readonly Timer _movementTimer;

        public PlayerMover(Player player, PictureBox pictureBox, MainForm mainForm, Timer movementTimer)
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
            _pictureBox = pictureBox ?? throw new ArgumentNullException(nameof(pictureBox));
            _mainForm = mainForm ?? throw new ArgumentNullException(nameof(mainForm));
            _movementTimer = movementTimer ?? throw new ArgumentNullException(nameof(movementTimer));

            ConfigureEvents();
        }

        private void ConfigureEvents()
        {
            _movementTimer.Tick += (sender, e) => MovePlayer();
            _mainForm.KeyDown += (sender, e) => SetPlayerDirection(e);
            _mainForm.KeyUp += (sender, e) => NullifyPlayerDirection();
            _player.Moved += (sender, e) => MovePlayerPictureBox();
        }

        private void NullifyPlayerDirection()
        {
            _player.StopMoving();
        }

        private void MovePlayer()
        {
            var space = new Size(_mainForm.Size.Width, _mainForm.Size.Height);

            _player.Move(space);
        }

        private void SetPlayerDirection(KeyEventArgs e)
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

            _player.SetDirection(direction);
        }

        private void MovePlayerPictureBox()
        {
            var location = _player.Location;

            _pictureBox.Location = new System.Drawing.Point(location.X, location.Y);
        }
    }
}