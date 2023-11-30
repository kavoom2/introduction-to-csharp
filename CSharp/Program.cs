using System;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxHp = 100;
            int hp = maxHp;

            float a = 3.14256f; // float는 suffix로 f를 붙어야 합니다. 4byte의 정확도가 떨어지는 값입니다.
            double b = 3.14256d; // double은 suffix로 d를 붙이거나 생략합니다. 정확한 값입니다. 8byte의 정확도가 높은 값입니다.

            string myName = "홍길동";
            bool myBool = false;

            int myInt = 100;
            short fromIntToShort = (short)myInt; // short는 2byte의 정수형입니다. int는 4byte의 정수형입니다. 따라서 형변환(캐스팅)을 해야 합니다. -> int는 32bit의 정수형이므로, 16bit의 short로 변환하면 16bit가 손실됩니다.
            int fromShortToInt = fromIntToShort;

            float myFloat = a;
            int fromFloatToInt = (int)myFloat; // float는 4byte의 실수형입니다. int는 4byte의 정수형입니다. 따라서 형변환(캐스팅)을 해야 합니다. -> float은 가장 앞의 1bit가 부호를 나타내므로, 31bit만 사용합니다. 따라서 32bit의 int로 변환하면 1bit가 손실됩니다.

            // Console.WriteLine("Please input your name:");
            // string input = Console.ReadLine();
            // int parsedInput = int.Parse(input);

            // Console.WriteLine($"Input is {input}");
            // Console.WriteLine($"Parsed input is {parsedInput}");

            string legacyMessage = string.Format("당신의 HP는 {0} / {1}입니다.", hp, maxHp);
            Console.WriteLine(legacyMessage);

            string message = $"당신의 HP는 {hp} / {maxHp}입니다.";
            Console.WriteLine(message);

            int dividedInt = 10 / 3; // 3.3333... -> 3
            int remainderInt = 10 % 3; // 1
            Console.WriteLine(dividedInt);
            Console.WriteLine(remainderInt);

            int myVal = 10;
            myVal *= 2; // myVal = myVal * 2;
            Console.WriteLine(myVal);
            Console.WriteLine(++myVal); // 21
            Console.WriteLine(myVal++); // 21
            Console.WriteLine(myVal); // 22

            Console.WriteLine(10 / 3); // 3
            Console.WriteLine(10d / 3); // 3.3333...

            bool isAlive = (hp > 0);
            bool isHpFull = (hp == maxHp);
            var inferredType = 10; // 컴파일 시점에 타입을 추론합니다. int로 추론됩니다.
        }
    }
}
