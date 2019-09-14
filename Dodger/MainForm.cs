using System.Windows.Forms;
using Dodger.Core.Entities;
using Dodger.Core.Entities.Game;
using Dodger.Core.Entities.World;
using Dodger.Core.ValueObjects;
using Dodger.Factories;
using Dodger.Handlers;
using Dodger.Persistance.Repositories;

namespace Dodger
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var world = new World(new Size(Width, Height));
            var player = PlayerFactory.CreatePlayer(playerPictureBox, this);
            var enemyRepository = new EnemyRepository();
            var gameObjectHandler = new GameObjectHandler(timer, enemyRepository, world, player);
            var enemyDisposer = new EnemyDisposer(enemyRepository, world);
            var enemySpawner = new EnemySpawner(enemySpawnTimer, enemyRepository, world, this);
            var scoreHandler = new ScoreHandler(scoreTimer, player, aScore);
                
            new Game(enemySpawner, scoreHandler)
                .Start();
        }
    }
}