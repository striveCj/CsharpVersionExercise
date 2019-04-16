using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Csharp7.Model;

namespace Csharp7
{
    class Program
    {
        static void Main(string[] args)
        {
            #region out变量
            //OutVariables();
            #endregion 

            #region 元组
            //Tuples();

            #region 赋值和元组
            //AssignmentAndTuples();
            #endregion

            #region 作为方法返回值的元组

            //ComputeSumAndSumOfSquares(new List<double> {1.1, 2.2, 3.3, 4.4});


            #endregion

            #region 析构
            //Deconstruction();
            #endregion

            #endregion

            #region 弃元
            //Discards();
            #endregion

            #region 模式匹配

            #region Is表达式
            //IsExpression();
            #endregion
            #region switch语句更新

            //SwitchStatementUpdates(new List<object>
            //{
            //    1,
            //    "1",
            //    new List<object>()
            //    {
            //        2,
            //        "2"
            //    }
            //});


            #endregion

            #endregion

            #region ref 局部变量和返回结果
            RefUse();
            #endregion
        }

        #region out变量
        //可以将out值内联作为参数声明到使用这些参数的方法中。
        public static void OutVariables()
        {
            int numericResult;
            Console.WriteLine("请输入一直数值");
            string input = Console.ReadLine();
            Console.WriteLine("7.0以前");
            if (int.TryParse(input,out numericResult))
                Console.WriteLine(numericResult);
            else
                Console.WriteLine("无法解析输入");
            Console.WriteLine("7.0以后");
            if (int.TryParse(input, out int result))
                Console.WriteLine(result);
            else
                Console.WriteLine("无法解析输入");
            Console.WriteLine("泄露到if外部的值");
            //当使用 out 变量声明时，声明的变量“泄漏”到 if 语句的外部作用域。
            Console.WriteLine(result);
            Console.ReadKey();
            //优势：
            //1.代码更易于阅读。
            //在使用 out 变量的地方声明 out 变量，而不是在上面的另一行。
            //2.无需分配初始值。
            //通过在方法调用中使用 out 变量的位置声明该变量，使得在分配它之前不可能意外使用它。
        }
        #endregion

        #region 元组
        //可以创建包含多个公共字段的轻量级未命名类型。 编译器和 IDE 工具可理解这些类型的语义。
        //新的元组功能需要 ValueTuple 类型。 为在不包括该类型的平台上使用它，必须添加 NuGet 包 System.ValueTuple。
        public static void Tuples()
        {
            var letters = ("a", "b");
            Console.WriteLine("Item1:" + letters.Item1);
            Console.WriteLine("Item2:" + letters.Item2);
            (string alpha, string Beta) namedLetters = letters;
            Console.WriteLine(namedLetters);
            var alphabetStart = (Beta:"a", alpha:"b");
            Console.WriteLine(alphabetStart);

            List<int> intList=new List<int>{1,2,3,4,5,6};
            //析构元组
            (int max, int min) = Range(intList);
            Console.WriteLine(max);
            Console.WriteLine(min);

            var p = new Point(3.14, 2.71);
            //不会受到 Deconstruct 方法中定义的名称的约束。 可以在分配过程中重命名提取变量
            (double horizontalDistance, double verticalDistance) = p;
            Console.WriteLine(horizontalDistance);
            Console.WriteLine(verticalDistance);


        }

        private static (int max, int min) Range(IEnumerable<int> numbers)
        {
            int max = int.MaxValue;
            int min = int.MinValue;
            foreach (var n in numbers)
            {
                min = (n > min) ? n : min;
                max = (n < max) ? n : max;
            }
            return (max, min);
        }

        #region 命名元组和未命名元组

        public static void NameandUnName ()
        {
            //未命名元祖
            var unnamed = ("one", "two");
            //命名元祖
            var name = (first:"one", second:"two");
        }
        #endregion

        #region 元组投影初始值设定项

        public static void TuplesProjectionInitializers()
        {
            //元组投影初始值设定项使用元组初始化语句右侧的变量或字段名称。 如果未提供显式名称，上述名称将优先于任何投影的名称。
            var localVariableOne = 5;
            var localVariableTwo = "some text";
            var tuple = (explicitFieldOne:localVariableOne, explicitFieldTwo:localVariableTwo);
            Console.WriteLine(tuple.explicitFieldOne);
            Console.WriteLine(tuple.explicitFieldTwo);

            var stringContent = "元祖投影";
            var mixedTuple = (42, stringContent);
            Console.WriteLine(mixedTuple.Item1);
            Console.WriteLine(mixedTuple.Item2);
            //在以下两种情况下，不会将候选字段名称投影到元组字段：
            //候选名称是保留元组名称时。 示例包括 Item3、ToString、 或 Rest。
            //候选名称重复了另一元组的显式或隐式字段名称时。
            //TODO：推断需要用7.1所以在7.1中演示
        }


        #endregion

        #region 相等和元组
        //从 C# 7.3 开始，元组类型支持 == 和 != 运算符。 这些运算符按顺序将左边参数的每个成员与右边参数的每个成员进行比较。 这些比较将发生短路。 只要有一对不相等，它们即会停止计算成员。 以下代码示例使用 ==，但比较规则均适用于 !=

        //TODO：元祖相等需要用7.3所以在7.3中演示
        #endregion

        #region 赋值和元组

        public static void AssignmentAndTuples()
        {
            var unnamed = (42, "字符串");
            var anonymous = (16, "字符串2");
            var named = (Answer:42, Message:"字符串3");
            var differentNamed = (SercretConstant:42, Label:"字符串4");
            unnamed = named;
            named = unnamed;
            Console.WriteLine($"{named.Answer},{named.Message}");
            anonymous = unnamed;
            named = differentNamed;
            Console.WriteLine($"{named.Answer},{named.Message}");

            (long, string) conversion = named;
            Console.WriteLine(conversion);
            //元组的名称未赋值，元素的赋值顺序遵循元素在元组中的顺序
            //元素类型或数量不同的元组不可赋值
        }


        #endregion

        #region 作为方法返回值的元组

        public static (double, double, int) ComputeSumAndSumOfSquares(IEnumerable<double> sequence)
        {
            double sum = 0;
            double sumOfSquares = 0;
            int count = 0;
            foreach (var item in sequence)
            {
                count++;
                sum += item;
                sumOfSquares += item * item;
            }
            Console.WriteLine((sum, sumOfSquares, count));
            return (sum, sumOfSquares, count);
        }
        #endregion

        #region 析构
        //通过对方法返回的元组进行析构，可以解封元组中的所有项。
        public static void Deconstruction()
        {
            (double sum, var sumOfSquares, var count) = ComputeSumAndSumOfSquares(new List<double>{2.2, 3.4, 5.6});
            Console.WriteLine(sum);
            Console.WriteLine(sumOfSquares);
            Console.WriteLine(count);
        }



        #endregion
        #endregion

        #region 弃元
        //弃元是指在不关心所赋予的值时，赋值中使用的临时只写变量。 在对元组和用户定义类型进行解构，以及在使用 out 参数调用方法时，它们特别有用。
        public static void Discards()
        {
            var(_, _, _, pop1, _, pop2) = QueryCityDataForYears("武汉", 1960, 2010);
            Console.WriteLine($"人口变化{pop2-pop1:N0}");
        }
        private static (string, double, int, int, int, int) QueryCityDataForYears(string name, int year1, int year2)
        {
            int population1 = 0, population2 = 0;
            double area = 0;
            if (name=="武汉")
            {
                area = 468.48;
                if (year1==1960)
                {
                    population1 = 77777777;
                }
                if (year2==2010)
                {
                    population2 = 88888888;
                }
                return (name, area, year1, population1, year2, population2);
            }
            return ("", 0, 0, 0, 0, 0);

        }

        #endregion

        #region 模式匹配
        //可以基于任意类型和这些类型的成员的值创建分支逻辑。

        #region is表达式
        // 你可以在检查类型过程中编写变量初始化。 这将创建一个经过验证的运行时类型的新变量。

        public static void IsExpression()
        {
            Console.WriteLine(DiceSum(new List<int>{1,2,3,4,5}));
            Console.WriteLine(DiceSum2(new List<object>{1,2,3,4,5,new List<object> {1,2,3,4,5}}));
        }

        private static int DiceSum(IEnumerable<int> values)
        {
            return values.Sum();
        }

        private static int DiceSum2(IEnumerable<object> values)
        {
            var sum = 0;
            foreach (var item in values)
            {
                if (item is int val) sum += val;
                else if (item is IEnumerable<object> subList) sum += DiceSum2(subList);
            }
            return sum;
        }


        #endregion

        #region switch语句更新
        //switch 表达式的控制类型不再局限于整数类型、Enum 类型、string 或与这些类型之一对应的可为 null 的类型。 可能会使用任何类型。
        //可以在每个 case 标签中测试 switch 表达式的类型。 与 is 表达式一样，可以为该类型指定一个新变量。
        //可以添加 when 子句以进一步测试该变量的条件。
        // case 标签的顺序现在很重要。 执行匹配的第一个分支；其他将跳过。
        public static int SwitchStatementUpdates(IEnumerable<object> values)
        {
            var sum = 0;
            foreach (var item in values)
            {
                switch (item)
                {
                    case 0://常量模式匹配
                        break;
                    case short sval://类型模式匹配
                        sum += sval;
                        break;
                    case int ival://类型模式匹配
                        sum += ival;
                        break;
                    case string str when int.TryParse(str, out var result)://类型模式匹配+条件表达式
                        sum += result;
                        break;
                    case IEnumerable<object> subList when subList.Any():
                        sum += SwitchStatementUpdates(subList);
                        break;
                        default:
                        throw new InvalidOperationException("未知的类型");

                }
            }
            Console.WriteLine(sum);
            return sum;
        }


        #endregion


        #endregion

        #region ref 局部变量和返回结果
        //方法局部参数和返回值可以是对其他存储的引用。

        public static ref int Find(int[,] matrix, Func<int, bool> predicate)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (predicate(matrix[i, j]))
                    return ref matrix[i, j];
            throw new InvalidOperationException("Not found");
        }

        public static void RefUse()
        {
            var bc=new BookCollection();
            bc.ListBooks();

            ref var book = ref bc.GetBookByTitle("Call of the wild, The");
            if (book!=null)
            {
                book=new Book
                {
                    Title = "Republic, The",
                    Author="Plato"
                };
            }
            bc.ListBooks();
        }
        #endregion

        #region 本地函数
        //可以将函数嵌套在其他函数内，以限制其范围和可见性。
        public static IEnumerable<char> AlphabetSubset3(char start, char end)
        {
            if (start<'a'||start>'z')
            {
                throw new ArgumentOutOfRangeException(paramName:nameof(start),message: "start must be a letter");
            }
            if (end < 'a' || end > 'z')
            {
                throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");
            }
            if (end<=start)
            {
                throw new ArgumentException($"{nameof(end)}must be greater than {nameof(start)}");
            }
            return AlphabetSubsetImplementation();
            IEnumerable<char> AlphabetSubsetImplementation()
            {
                for (var c = start; c < end; c++)
                    yield return c;
            }
        }

        //public Task<string> PerformLongRunningWork(string address, int index, string name)
        //{
        //    if(string.IsNullOrWhiteSpace(address))
        //        throw new ArgumentException(message:"An Address is required",paramName:nameof(address));
        //    if (index<0)
        //    {
        //        throw  new ArgumentOutOfRangeException(paramName:nameof(index),message:"索引必须是非负数");
        //    }
        //    if (string.IsNullOrEmpty(name))
        //    {
        //        throw new ArgumentException(message:"你必须提供name",paramName:nameof(name));
        //    }

        //    async Task<string> LongRunningWorkImplementation()
        //    {
        //        //var interimResult = await FirstWork(address);
        //        //var secondResult = await SecondStep(index,name);
        //        return $"{1},{2}";
        //    }
        //}
        #endregion

        #region 更多的 expression-bodied 成员
        //可使用表达式创作的成员列表有所增长。

        private string label;

        public string Label
        {
            get => label;
            set => this.label = value ?? "Default label";
        }

        #endregion

        #region throw 表达式

        //可以在之前因为 throw 是语句而不被允许的代码构造中引发异常。

        private string _name = GetName() ?? throw new ArgumentNullException(nameof(GetName));

        private int _age;

        public int Age
        {
            get => _age;
            set => _age = value <= 0 || value >= 130 ? throw new ArgumentException("参数不合法") : value;
        }

        public static string GetName() => null;

        #endregion

        #region 通用的异步返回类型

        //使用 async 修饰符声明的方法可以返回除 Task 和 Task<T> 以外的其他类型。

        public async ValueTask<int> Func()
        {
            await Task.Delay(100);
            return 5;
        }
        #endregion

        #region 数字文本语法改进

        //误读的数值常量可能使第一次阅读代码时更难理解。 位掩码或其他符号值容易产生误解。 C# 7.0 包括两项新功能，可用于以最可读的方式写入数字来用于预期用途：二进制文本和数字分隔符。
        //在创建位掩码时，或每当数字的二进制表示形式使代码最具可读性时，以二进制形式写入该数字：
        public const int Sixteen = 0b001_0000;

        public const long BillionsAndBillions = 100_000_000_000;


        #endregion

    }
}
