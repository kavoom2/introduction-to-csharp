namespace CSharp
{
    class Program
    {
        static void OnInputTest()
        {
            Console.WriteLine("OnInputTest");
        }

        class TestException : Exception
        {
            public TestException(string message)
                : base(message) { }
        }

        static void Main(string[] args)
        {
            object obj = 3;
            object obj2 = 4;

            int num = (int)obj;
            int num2 = (int)obj2;

            MyList<int> myIntList = new();

            FlyableOrc flyableOrc = new();
            DoFly(flyableOrc);

            Knight knight = new();
            int hp = knight.Hp;

            UI ui = new();
            UI.ButtonPressed(UI.DemoDelegate);

            UI.OnClicked onClicked = new(UI.DemoDelegate);
            onClicked += UI.DemoDelegate2;

            UI.ButtonPressed(onClicked);

            InputManager inputManager = new();
            inputManager.InputKey += OnInputTest;
            inputManager.InputKey += () =>
            {
                Console.WriteLine("Lambda");
            };

            try
            {
                while (true)
                {
                    inputManager.Update();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Func<int> func = () =>
            {
                return 0;
            };

            Action action = () =>
            {
                Console.WriteLine("Action");
            };

            try
            {
                int a = 0;
                int b = 10 / a;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Finally");
            }
        }

        class MyList<T>
            where T : struct
        {
            T[] arr = new T[10];

            public T GetItem(int i)
            {
                return arr[i];
            }
        }

        abstract class Monster
        {
            public int hp;
            public int attack;
            public abstract void Walk();
        }

        interface IFlyable
        {
            void Fly();
        }

        class Orc : Monster
        {
            public override void Walk()
            {
                //...
            }
        }

        class FlyableOrc : Orc, IFlyable
        {
            public void Fly()
            {
                //...
            }
        }

        static void DoFly(IFlyable flyable)
        {
            flyable.Fly();
        }
    }

    class Knight
    {
        protected int _hp;
        public int Hp
        {
            get { return _hp; }
            private set { _hp = value; }
        }

        public int Armor { get; set; }
        public int Attack { get; private set; }
    }

    class UI
    {
        public delegate int OnClicked(); // 함수 자체를 인자로 넘겨주는 형식

        public static void ButtonPressed(OnClicked clickedFunction)
        {
            clickedFunction();
        }

        public static int DemoDelegate()
        {
            Console.WriteLine("DemoDelegate");
            return 0;
        }

        public static int DemoDelegate2()
        {
            Console.WriteLine("DemoDelegate2");
            return 0;
        }
    }
}
