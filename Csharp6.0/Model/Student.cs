using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp6._0.Model
{
    public class Student
    {
        //只读自动属性
        public string FirstName { get; }

        public string LastName { get; }
        //自动属性初始化表达式
        public string Address { get; } = "湖北武汉";
        public ICollection<double> Grades { get; }=new List<double>();
        //编写 expression-bodied 成员
        public string FullName=> $"{LastName},{FirstName}";
        public override string ToString() => $"{LastName},{FirstName}";
        //字符串插值
        public  string GetGradePointPercentage() => $"Name:{LastName},{FirstName}. GPA:{100:F2}";

        //为属性赋值，只读自动属性，只能在构造函数中设置值

        public Student(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException(message:"空白",paramName:nameof(lastName));
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException(message: "空白", paramName: nameof(firstName));
            FirstName = firstName;
            LastName = lastName;
            Address = null;
        }


    }
}
