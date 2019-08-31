using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Dodger.Annotations;
using Dodger.Entities;
using Dodger.Models;

namespace Dodger.Handlers
{
    public class PlayerHandler : IPlayerHandler
    {
        private readonly Player _player;
        private readonly PictureBox _pictureBox;
        private readonly MainForm _mainForm;

        public PlayerHandler(Player player, PictureBox pictureBox, MainForm mainForm)
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
            _pictureBox = pictureBox ?? throw new ArgumentNullException(nameof(pictureBox));
            _mainForm = mainForm ?? throw new ArgumentNullException(nameof(mainForm));

            ConfigureEvents();
        }

        private void ConfigureEvents()
        {
            _mainForm.KeyDown += OnFormKeyDown;
            _player.Moved += MovePictureBox;
        }

        private void OnFormKeyDown(object sender, KeyEventArgs e)
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

            _player.Move(direction);
        }

        private void MovePictureBox(object sender, EventArgs e)
        {
            var location = _player.Location;
            _pictureBox.Location = new System.Drawing.Point(location.X, location.Y);
        }
    }
}