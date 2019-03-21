using System;

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
            Tuples();
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
            (string alpha, string Beta) namedLetters = letters;
            Console.WriteLine(namedLetters);
        }

        #endregion

        #region 弃元
        //弃元是指在不关心所赋予的值时，赋值中使用的临时只写变量。 在对元组和用户定义类型进行解构，以及在使用 out 参数调用方法时，它们特别有用。


        #endregion

        #region 模式匹配
        //可以基于任意类型和这些类型的成员的值创建分支逻辑。

        #endregion

        #region ref 局部变量和返回结果
        //方法局部参数和返回值可以是对其他存储的引用。


        #endregion

        #region 本地函数
        //可以将函数嵌套在其他函数内，以限制其范围和可见性。


        #endregion

        #region 更多的 expression-bodied 成员
        //可使用表达式创作的成员列表有所增长。


        #endregion

        #region throw 表达式
        //可以在之前因为 throw 是语句而不被允许的代码构造中引发异常。


        #endregion

        #region 通用的异步返回类型
        //使用 async 修饰符声明的方法可以返回除 Task 和 Task<T> 以外的其他类型。


        #endregion

        #region 数字文本语法改进
        //新令牌可提高数值常量的可读性。


        #endregion

    }
}
