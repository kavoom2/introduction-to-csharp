namespace CSharp
{
    public enum GameMode
    {
        None = 0,
        Lobby = 1,
        Town = 2,
        Field = 3,
        Battle = 4
    }

    class Game
    {
        private GameMode _gameMode = GameMode.Lobby;
        private Player _player = null;
        private Monster _monster = null;
        private Random _rand = new();

        public void Process()
        {
            switch (_gameMode)
            {
                case GameMode.Lobby:
                    ProcessLobby();
                    break;
                case GameMode.Town:
                    ProcessTown();
                    break;
                case GameMode.Field:
                    ProcessField();
                    break;
                case GameMode.Battle:
                    break;
            }
        }

        private void ProcessLobby()
        {
            Console.WriteLine("직업을 선택하세요.");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 마법사");

            string input = Console.ReadLine() ?? "";

            switch (input)
            {
                case "1":
                    Console.WriteLine("기사를 선택하셨습니다.");
                    _player = new Knight();
                    _gameMode = GameMode.Town;
                    break;
                case "2":
                    Console.WriteLine("궁수를 선택하셨습니다.");
                    _player = new Archer();
                    _gameMode = GameMode.Town;
                    break;
                case "3":
                    Console.WriteLine("마법사를 선택하셨습니다.");
                    _player = new Mage();
                    _gameMode = GameMode.Town;
                    break;
            }
        }

        private void ProcessTown()
        {
            Console.WriteLine("마을에 입장했습니다.");
            Console.WriteLine("[1] 필드로 가기");
            Console.WriteLine("[2] 로비로 돌아가기");

            string input = Console.ReadLine() ?? "";

            switch (input)
            {
                case "1":
                    Console.WriteLine("필드로 갑니다.");
                    _gameMode = GameMode.Field;
                    break;
                case "2":
                    Console.WriteLine("로비로 돌아갑니다.");
                    _player = null;
                    _gameMode = GameMode.Lobby;
                    break;
            }
        }

        private void ProcessField()
        {
            Console.WriteLine("필드에 입장했습니다.");
            Console.WriteLine("[1] 싸우기");
            Console.WriteLine("[2] 일정 확률로 마을 돌아가기");

            CreateRandomMonster();

            string input = Console.ReadLine() ?? "";
            switch (input)
            {
                case "1":
                    ProcessBattle();
                    break;
                case "2":
                    TryEscape();
                    break;
            }
        }

        private void ProcessBattle()
        {
            while (true)
            {
                int damage = _player.GetAttack();
                _monster.OnDamaged(damage);

                if (_monster.IsDead())
                {
                    Console.WriteLine("승리했습니다.");
                    Console.WriteLine($"남은 체력 {_player.GetHp()}");
                    break;
                }

                damage = _monster.GetAttack();
                _player.OnDamaged(damage);

                if (_player.IsDead())
                {
                    Console.WriteLine("패배했습니다.");
                    _gameMode = GameMode.Lobby;
                    break;
                }
            }
        }

        private void TryEscape()
        {
            int randValue = _rand.Next(0, 101);
            if (randValue < 33)
            {
                Console.WriteLine("마을로 돌아갑니다.");
                _gameMode = GameMode.Town;
            }
            else
            {
                ProcessBattle();
            }
        }

        private void CreateRandomMonster()
        {
            int randValue = _rand.Next(0, 3);

            switch (randValue)
            {
                case (int)MonsterType.Slime:
                {
                    _monster = new Slime();
                    Console.WriteLine("슬라임이 생성되었습니다.");
                    break;
                }

                case (int)MonsterType.Orc:
                {
                    _monster = new Orc();
                    Console.WriteLine("오크가 생성되었습니다.");
                    break;
                }

                case (int)MonsterType.Skeleton:
                {
                    _monster = new Skeleton();
                    Console.WriteLine("스켈레톤이 생성되었습니다.");
                    break;
                }
            }
        }
    }
}
