using System;
using System.Text;
using MaLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaLibTest
{
    [TestClass]
    public class UtilTest
    {
        class Test1
        {
            public string a = "TEST";
            public int b = 9999;

            public class Test2
            {
                public string a { get; set; } = "TEST";
                public decimal b { get; } = 9999m;
                public float c { private get; set; } = 0.5f;
            }

            public enum Enum1
            {
                ZERO,
                ONE,
                TWO,
            }

            public Test2 c = new Test2();

            public int[] d = new int[] {1, 2, 3};

            public Enum1 e = Enum1.TWO;
        }

        [TestMethod]
        public void ObjectFumpTest()
        {
            var s = Util.Dump(new Test1());
            Console.WriteLine(s);
        }

        [TestMethod]
        public void StopwatchScopeTest()
        {
            using (new StopwatchScope())
            {
                var sb = new StringBuilder();
                for (var i = 0; i < 10000000; ++i)
                {
                    sb.Append(' ');
                }

                sb.ToString();
            }
        }
    }
}
