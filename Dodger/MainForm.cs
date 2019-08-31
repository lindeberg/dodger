using System;
using System.Drawing;
using System.Windows.Forms;
using Dodger.Annotations;
using Dodger.Entities;
using Dodger.Factories;
using Dodger.Handlers;
using Dodger.Models;
using Point = Dodger.Models.Point;

namespace Dodger
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var player = PlayerFactory.CreatePlayer(aPlayerImage);
            
            var enemySpawner = new EnemySpawner(aEnemySpawnTimer, this, player);
            var scoreHandler = new ScoreHandler(aScoreTimer, player, aScore);
            var playerHandler = new PlayerHandler(player, aPlayerImage, this);

            new Game(enemySpawner, scoreHandler, playerHandler)
                .Start();
        }
    }
}