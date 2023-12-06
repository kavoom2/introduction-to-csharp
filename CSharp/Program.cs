using System;
using System.Security.Cryptography;

namespace CSharp
{
    class Program
    {
        enum PlayerClassType
        {
            None = 0,
            Knight = 1,
            Archer = 2,
            Mage = 3
        }

        enum MonsterType
        {
            None = 0,
            Slime = 1,
            Orc = 2,
            Skeleton = 3
        }

        struct Player
        {
            public int hp;
            public int attack;
            public PlayerClassType playerClass;
        }

        struct Monster
        {
            public int hp;
            public int attack;
            public MonsterType monsterType;
        }

        static PlayerClassType SelectPlayerClass()
        {
            PlayerClassType selectedPlayerClass = PlayerClassType.None;

            Console.WriteLine("직업을 선택해 주세요.");
            Console.WriteLine("[1] 전사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");

            string input = Console.ReadLine() ?? "";

            switch (input)
            {
                case "1":
                {
                    selectedPlayerClass = PlayerClassType.Knight;
                    break;
                }
                case "2":
                {
                    selectedPlayerClass = PlayerClassType.Archer;
                    break;
                }
                case "3":
                {
                    selectedPlayerClass = PlayerClassType.Mage;
                    break;
                }
            }

            return selectedPlayerClass;
        }

        static void CreatePlayer(PlayerClassType playerClass, out Player player)
        {
            switch (playerClass)
            {
                case PlayerClassType.Knight:
                {
                    player.hp = 100;
                    player.attack = 10;
                    player.playerClass = PlayerClassType.Knight;
                    break;
                }
                case PlayerClassType.Archer:
                {
                    player.hp = 75;
                    player.attack = 12;
                    player.playerClass = PlayerClassType.Archer;
                    break;
                }
                case PlayerClassType.Mage:
                {
                    player.hp = 50;
                    player.attack = 15;
                    player.playerClass = PlayerClassType.Mage;
                    break;
                }
                default:
                {
                    player.hp = 0;
                    player.attack = 0;
                    player.playerClass = PlayerClassType.None;
                    break;
                }
            }
        }

        static void CreateRandomMonster(out Monster monster)
        {
            Random rand = new();
            int randMonster = rand.Next(1, 4);

            switch (randMonster)
            {
                case (int)MonsterType.Slime:
                {
                    monster.hp = 20;
                    monster.attack = 2;
                    monster.monsterType = MonsterType.Slime;
                    break;
                }
                case (int)MonsterType.Orc:
                {
                    monster.hp = 40;
                    monster.attack = 4;
                    monster.monsterType = MonsterType.Orc;
                    break;
                }
                case (int)MonsterType.Skeleton:
                {
                    monster.hp = 30;
                    monster.attack = 3;
                    monster.monsterType = MonsterType.Skeleton;
                    break;
                }
                default:
                {
                    monster.hp = 0;
                    monster.attack = 0;
                    monster.monsterType = MonsterType.None;
                    break;
                }
            }
        }

        static void EnterGame(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("게임에 접속했습니다.");
                Console.WriteLine("[1] 필드로 간다.");
                Console.WriteLine("[2] 로비로 돌아간다.");

                string input = Console.ReadLine() ?? "";

                if (input == "1")
                {
                    EnterField(ref player);
                }
                else if (input == "2")
                {
                    break;
                }
            }
        }

        static void EnterField(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("필드에 접속했습니다.");

                CreateRandomMonster(out Monster monster);
                Console.WriteLine($"몬스터가 출현했습니다. ({monster.monsterType})");

                Console.WriteLine("[1] 전투 모드로 돌입한다.");
                Console.WriteLine("[2] 일정 확률로 도망친다.");

                string input = Console.ReadLine() ?? "";
                if (input == "1")
                {
                    EnterBattle(ref player, ref monster);
                }
                else if (input == "2")
                {
                    TryEscape(ref player, ref monster);
                }

                if (player.hp <= 0)
                {
                    Console.WriteLine("사망했습니다.");
                    break;
                }
            }
        }

        static void EnterBattle(ref Player player, ref Monster monster)
        {
            while (true)
            {
                monster.hp -= player.attack;
                if (monster.hp <= 0)
                {
                    Console.WriteLine("승리했습니다.");
                    Console.WriteLine($"남은 체력: {player.hp}");
                    break;
                }

                player.hp -= monster.attack;
                if (player.hp <= 0)
                {
                    Console.WriteLine("패배했습니다.");
                    break;
                }
            }
        }

        static void TryEscape(ref Player player, ref Monster monster)
        {
            Random rand = new();
            int randValue = rand.Next(0, 101);

            if (randValue < 33)
            {
                Console.WriteLine("도망치는데 성공했습니다.");
            }
            else
            {
                Console.WriteLine("도망치는데 실패했습니다.");
                EnterBattle(ref player, ref monster);
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                PlayerClassType selectedPlayerClass = SelectPlayerClass();

                if (selectedPlayerClass != PlayerClassType.None)
                {
                    CreatePlayer(selectedPlayerClass, out Player player);

                    Console.WriteLine("선택한 직업: " + player.playerClass);
                    Console.WriteLine($"HP: {player.hp}, 공격력: {player.attack}");
                    EnterGame(ref player);
                }
            }
        }
    }
}
