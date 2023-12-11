using System;

namespace CSharp
{
    class Knight
    {
        public static int myStaticField = 0; // 클래스에 속한 정적 필드입니다. (Javascript의 생성자 함수의 Static Method or field와 동일한 맥락입니다. 예시: Number.isNaN)

        public static void MyStaticMethod()
        {
            // Static Method 안에서는 this 키워드를 사용할 수 없습니다.
            // Static Method 안에서는 정적 필드만 사용할 수 있습니다.
            Console.WriteLine("MyStaticMethod is called");
            myStaticField = 100;
        }

        public static Knight CreateKnight()
        {
            Knight knight = new() { health = 100, attack = 50 };
            return knight;
        }

        public int health;
        public int attack;

        public Knight()
        {
            health = 100;
            attack = 50;
            Console.WriteLine("Knight: Constructor is called");
        }

        public Knight(int health = 100, int attack = 50)
            : this() // 기본 생성자를 호출한다.
        {
            this.health = health;
            this.attack = attack;
            Console.WriteLine("Knight: Constructor is called - with parameters");
        }

        public void Move()
        {
            Console.WriteLine("Knight is moving");
        }

        public void Attack()
        {
            Console.WriteLine("Knight is attacking");
        }

        public Knight DeepCopy()
        {
            return new Knight() { health = health, attack = attack };
        }
    }

    struct Mage
    {
        public int health;
        public int attack;
    }

    class Player
    {
        protected int hp;
        protected int attack;

        public virtual void Move()
        {
            Console.WriteLine("Player is moving");
        }
    }

    class Archer : Player
    {
        public int dex;

        // 오버로딩과 오버라이딩은 서로 다른 개념입니다!
        // 오버로딩 - 같은 이름의 메서드를 여러개 만드는 것입니다. (함수 이름의 재사용)
        // 오버라이딩 - 부모 클래스의 메서드를 자식 클래스에서 재정의하는 것입니다. (다형성)
        public override void Move()
        {
            base.Move(); // 부모 클래스의 메서드를 호출합니다.
            Console.WriteLine("Archer is moving");
        }
    }

    class Ninja : Player
    {
        public int dex;
    }

    class Program
    {
        static void MovePlayer(Player player)
        {
            // Ninja ninja = (Ninja)player; // YOU SHALL NOT PASS! :(
            player.Move();

            if (player is Archer) // 'is' 키워드를 사용하여 Casting이 가능한지 확인할 수 있다.
            {
                Archer archer = (Archer)player;
            }

            // "Ninja"로 변환할 수 없으면 null을 반환한다. (Casting을 할 수 없는 경우)
            Ninja ninja = player as Ninja;
        }

        static Player? GetNullablePlayer(Player player)
        {
            if (player is Archer)
            {
                return player;
            }

            return null; // Nullable을 사용하면 null을 반환할 수 있다.
        }

        static void KillMage(Mage mage)
        // 'Strut(구조체)'은 값 형식(Value Type)이기 때문에 복사가 일어난다. (복사본이 생성된다.)
        // 따라서 mage.health = 0;이 적용되지 않는다.
        {
            mage.health = 0;
        }

        static void KillKnight(Knight knight)
        // 'Class'는 참조 형식(Reference Type)이기 때문에 복사가 일어나지 않는다. (복사본이 생성되지 않는다.)
        // 따라서 knight.health = 0;이 적용된다.
        {
            knight.health = 0;
        }

        static void Main(string[] args)
        {
            // Mage mage = new() { health = 100, attack = 50 }; // Strut
            // Knight knight = new(health: 200, attack: 100); // Class

            // Console.WriteLine($"Knight health: {knight.health}");
            // Console.WriteLine($"Knight attack: {knight.attack}");

            // knight.Move();
            // knight.Attack();

            // KillMage(mage);
            // KillKnight(knight);

            // Console.WriteLine($"Mage health: {mage.health}");
            // Console.WriteLine($"Knight health: {knight.health}");

            // Knight knight2 = knight.DeepCopy();
            // Console.WriteLine(knight == knight2); // False

            // Archer archer = new() { dex = 10 };
            // Ninja ninja = new() { dex = 20 };

            // MovePlayer(archer);
            // MovePlayer(ninja);

            string name = "Harry Potter";
            bool foundHarry = name.Contains("Harry"); // true
            int index = name.IndexOf("Potter"); // 6

            name += " Junior";
            string lowerCaseName = name.ToLower(); // "harry potter junior"
            string upperCaseName = name.ToUpper(); // "HARRY POTTER JUNIOR"

            name.Split(" "); // ["Harry", "Potter", "Junior"]
            name.Split(new char[] { ' ' }); // ["Harry", "Potter", "Junior"]
        }

        static void StaticTest()
        {
            Knight.MyStaticMethod();
            Knight.myStaticField = 100;
        }
    }
}
