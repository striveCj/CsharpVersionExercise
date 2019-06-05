using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp6._0.Model;

namespace Csharp6._0
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 只读自动属性
            //Test1();
            #endregion
        }

        #region 只读自动属性

        #endregion
        #region 自动属性初始化表达式

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
            
        }
        #endregion
        #region using static



        #endregion
        #region Null条件运算符



        #endregion
        #region 字符串内插



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
