using System.Windows.Forms;
using Dodger.Core.Entities.Game;
using Dodger.Core.Entities.Player;
using Dodger.Core.Entities.World;
using Dodger.Core.Persistance.Repositories;
using Dodger.Core.Repositories.EnemyRepository;
using Dodger.Core.ValueObjects;
using Dodger.Factories;
using Dodger.Graphics.Handlers;
using EnemyDisposer = Dodger.Core.Handlers.EnemyDisposer;
using EnemySpawner = Dodger.Core.Handlers.EnemySpawner;
using ScoreHandler = Dodger.Core.Handlers.ScoreHandler;
using Timer = Dodger.Core.Entities.Timer;

namespace Dodger
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var world = new World(new Size(Width, Height));
            var player = PlayerFactory.CreatePlayer(playerPictureBox);

            CreateGame(world, player)
                .Start();
        }

        private Game CreateGame(IWorld world, Player player)
        {
            var enemyRepository = new EnemyRepository();
            var gameComponents = BuildGameComponents(world, player, enemyRepository);
            var gameGraphicsComponents = BuildGameGraphicsComponents(enemyRepository, player);
            var gameTimer = WireUpTimer();

            return new Game(gameTimer, gameComponents, gameGraphicsComponents);
        }

        private Timer WireUpTimer()
        {
            var gameTimer = new Timer();

            timer.Tick += (sender, e) => gameTimer.InvokeTick();

            return gameTimer;
        }

        private GameGraphicsComponents BuildGameGraphicsComponents(IEnemyRepository enemyRepository, Player player)
        {
            var enemySpawner = new Graphics.Handlers.EnemySpawner(enemyRepository, this);
            var enemyDisposer = new Graphics.Handlers.EnemyDisposer(enemyRepository, this);
            var scoreHandler = new Graphics.Handlers.ScoreHandler(player, scoreLabel);
            var playerRenderer = new PlayerRenderer(this);
            var enemyRenderer = new EnemyRenderer(this);
            var inputHandler = new InputHandler(player, this);

            return new GameGraphicsComponents(enemySpawner, enemyDisposer, scoreHandler, enemyRenderer, playerRenderer,
                inputHandler);
        }

        private GameComponents BuildGameComponents(IWorld world, IPlayer player, IEnemyRepository enemyRepository)
        {
            var enemySpawner = new EnemySpawner(enemyRepository, world);
            var enemyDisposer = new EnemyDisposer(enemyRepository, world);
            var scoreHandler = new ScoreHandler(player);

            return new GameComponents(enemySpawner, enemyDisposer, scoreHandler, world, player, enemyRepository);
        }
    }
}