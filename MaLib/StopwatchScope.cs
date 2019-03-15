using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MaLib
{
    /// <summary>
    /// usingで使用する経過時間計測
    /// </summary>
    public class StopwatchScope : IDisposable
    {
        private string name;
        private Stopwatch sw;

        public StopwatchScope([CallerMemberName] string name = "")
        {
            this.name = name;
            this.sw = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            Console.WriteLine($"{name} = {sw.ElapsedMilliseconds} ms");
        }
    }
}
