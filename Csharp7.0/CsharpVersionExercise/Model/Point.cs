using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp7.Model
{
    public class Point
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public double X { get; set; }

        public double Y { get; set; }
        //为 .NET 中的任何类型提供类似的析构。 这通过将 Deconstruct 方法编写为类的成员来完成。 Deconstruct 方法为你要提取的每个属性提供一组 out 参数。
        public void Deconstruct(out double x, out double y)
        {
            x = this.X;
            y = this.Y;
        }
    }
}
