namespace DelegateProject
{
    enum OperationType
    {
        Sum,
        Mult,
    }

    delegate void HelloDelegate();
    delegate int OperationDelegate(int x, int y);

    delegate void SayDelegate<T>(T arg);

    internal class Program
    {

        static void SayHello<T>(T mes)
        {
            Console.WriteLine(mes);
        }

        static void SayInteger(int num)
        {
            Console.WriteLine(num);
        }

        static void SayString(string str)
        {
            Console.WriteLine(str);
        }

        static int Sum(int a, int b)
        {
            Console.WriteLine("sum is work");
            return a + b;
        }

        static int Mult(int a, int b)
        {
            Console.WriteLine("mult is work");
            return a * b;
        }

        static int? Calc(int a, int b, OperationDelegate operation)
        {
            return operation?.Invoke(a, b);
        }

        static OperationDelegate? SelectOperation(OperationType type)
        {
            switch (type)
            {
                case OperationType.Sum:
                    return Sum;
                    break;
                case OperationType.Mult:
                    return Mult;
                    break;
                default:
                    return null;
                    break;
            }
        }
        static void HelloWorld()
        {
            Console.WriteLine("Hello World");
        }

        static void HelloPeople()
        {
            Console.WriteLine("Hello People");
        }
        static void Main(string[] args)
        {
            Action action = HelloWorld;
            Action<int> actionInt = SayInteger;

            //HelloDelegate? helloDelegate;
            //helloDelegate = HelloWorld;
            //helloDelegate();
            //helloDelegate = HelloPeople;
            //helloDelegate = null;
            //helloDelegate?.Invoke();

            //int x = 10, y = 20;
            //Console.WriteLine(Calc(x, y, Sum));
            //OperationDelegate? op = Mult;
            //Console.WriteLine(Calc(x, y, op));
            //op = SelectOperation(OperationType.Sum);
            //Console.WriteLine(Calc(x, y, op!));

            //op = delegate(int a, int b)
            //{
            //    return a - b;
            //};

            //op = (a, b) => a - b;

            //Console.WriteLine(Calc(x, y, delegate (int a, int b)
            //{
            //    return a - b;
            //}));

            HelloDelegate hello = () => { Console.WriteLine("Hello"); };
            //HelloDelegate helloLambda = () => Console.WriteLine("Hello");

            //OperationDelegate operationDelegate = new OperationDelegate(Mult);

            //Console.WriteLine(operationDelegate.GetType());

            //Message mes = new Message();

            //HelloDelegate? helloDelegate;

            //helloDelegate = mes.PrintHello;
            //helloDelegate.Invoke();
            //Console.WriteLine("-------------------");

            //helloDelegate += mes.PrintBy;
            //helloDelegate.Invoke();
            //Console.WriteLine("-------------------");

            //helloDelegate -= mes.PrintHello;
            //helloDelegate?.Invoke();

            Func<int, int, int> oFunc = Sum;

            OperationDelegate? operation;
            operation = Sum;
            Console.WriteLine(operation.Invoke(10, 20));
            Console.WriteLine("-------------------");
            
            operation += Mult;
            Console.WriteLine(operation.Invoke(10, 20));
            Console.WriteLine("-------------------");
            operation -= Sum;
            Console.WriteLine(operation.Invoke(10, 20));
            Console.WriteLine("-------------------");

            operation += (a, b) => { Console.WriteLine("delete is work"); return a - b; };
            Console.WriteLine(operation.Invoke(10, 20));

            var ooo = (int a, int b) => { Console.WriteLine("delete is work"); return a - b; };

            Console.WriteLine(ooo.GetType());

            Console.WriteLine("-------------------");

            operation += (a, b) => { Console.WriteLine("delete is work"); return a - b; };
            Console.WriteLine(operation.Invoke(10, 20));
            Console.WriteLine("-------------------");

            //SayDelegate<int> sayInt = SayInteger;
            //sayInt(100);
            //SayDelegate<string> sayString = SayString;
            //sayString("qwerty");
            //SayDelegate<float> sayFloat = SayHello<float>;
            //sayFloat(123.456f);
        }
    }
}