using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Csharp6._0.Model;

namespace Csharp6._0
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 只读自动属性、自动属性初始化表达式
            //Test1();
            #endregion

            #region Expression-bodied函数成员
            //Test2();
            #endregion

            #region using static
            //Test3();
            #endregion

            #region null条件运算符
            //Test4();
            #endregion

            #region 字符串内插

            Test5();

            #endregion

        }

        #region 只读自动属性、自动属性初始化表达式
        public static void Test1()
        {
            Student student=new Student("chen","jie");
            student.Grades.Add(1);
            student.Grades.Add(2);
            Console.WriteLine(student.FirstName);
            Console.WriteLine(student.LastName);
            Console.WriteLine(student.Address);
            Console.WriteLine(student.Grades.Count);
        }
        #endregion
        #region Expression-bodied函数成员
        public static void Test2()
        {
            Student s=new Student("陈","莫");        
            Console.WriteLine(s.ToString());
            Console.WriteLine(s.FullName);
        }
        #endregion
        #region using static
        public static void Test3()
        {
            WriteLine("using static");
        }
        #endregion
        #region Null条件运算符
        public static void Test4()
        {
            var student=new Student("f","l");
            var first = student?.Address;
            first = student?.Address ?? "U";
            WriteLine(first);
        }
        #endregion
        #region 字符串内插

        public static void Test5()
        {
          var student = new Student("c","j");
          WriteLine(student.GetGradePointPercentage());
        }

        #endregion
        #region 异常筛选器



        #endregion
        #region nameof表达式



        #endregion
        #region Catch和Finally块中的Await



        #endregion
        #region 使用索引器初始化关联集合



        #endregion
        #region 集合初始值设定项中的扩展Add方法



        #endregion

        #region 改进了重载解析



        #endregion
    }
}
