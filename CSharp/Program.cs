using System;

namespace MyCSharpProgram
{
    class MyClass
    {
        static int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        static float Add(float num1, float num2)
        {
            return num1 + num2;
        }

        static int Add(int num1, int num2, int num3 = 0, int num4 = 0)
        {
            return num1 + num2 + num3 + num4;
        }

        // 메서드 오버로딩 -> 같은 이름의 메서드를 여러개 정의할 수 있습니다.
        static void AddOne(int num)
        {
            num += 1;
            Console.WriteLine(num);
        }

        static void AddOneByRef(ref int num) // reference -> 값이 아닌 주소를 전달합니다.
        {
            num += 1;
            Console.WriteLine(num);
        }

        static int Sum(int[] numbers)
        {
            int sum = 0;

            foreach (int num in numbers)
            {
                sum += num;
            }

            return sum;
        }

        static void Swap(ref int num1, ref int num2)
        {
            (num1, num2) = (num2, num1);
        }

        static void Divide(int num1, int num2, out int result, out int remainder) // out -> 값을 반환하지 않고, 참조로 전달합니다.
        {
            result = num1 / num2;
            remainder = num1 % num2;
        }

        static void MyMethod()
        {
            Console.WriteLine("Hello World!");
        }

        static void Main(string[] args)
        {
            int myNum = 1;

            AddOne(myNum);
            Console.WriteLine(myNum);

            AddOneByRef(ref myNum);
            Console.WriteLine(myNum);

            int[] numbers = { 1, 2, 3, 4, 5 };

            Swap(ref numbers[0], ref numbers[1]); // reference -> 값이 아닌 주소를 전달합니다.
            Console.WriteLine(numbers[0]);
            Console.WriteLine(numbers[1]);
            Console.WriteLine(numbers);

            int result;
            int remainder;

            Divide(10, 3, out result, out remainder); // out -> 값을 반환하지 않고, 참조로 전달합니다.
            Console.WriteLine(result);
            Console.WriteLine(remainder);

            Console.WriteLine(Add(1.2f, 1.0f));
            Console.WriteLine(Add(1, 2));
            Console.WriteLine(Add(1, 2, 3)); // 선택적 매개변수
            Console.WriteLine(Add(1, 2, num4: 4)); // 키워드 매개변수
        }
    }
}
