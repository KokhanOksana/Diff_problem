using Microsoft.VisualStudio.TestTools.UnitTesting;
using Koshi_giu.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koshi_giu.Helper.Tests
{
    [TestClass()]
    public class Tridiagonal_matrixTests
    {
        [TestMethod()]
        public void RightTest()
        {

            decimal [ ] a = new decimal [ ] {0, 1,   1, 0.25M};
            decimal [ ] b = new decimal [ ] {1, 10, -5, 1    };
            decimal [ ] c = new decimal [ ] {0.5M, -5, 2, 0 };
            decimal [ ] [ ] vectors = new decimal [ 3 ] [ ] { a, b, c };
            decimal [ ] f = new decimal [ ] {-2.5M, -18, -40,  -6.75M};

            decimal [ ] expect = new decimal [ ] {-3, 1, 5, -8};
            decimal [ ] real = Tridiagonal_matrix.Right( vectors, f );

            Assert.AreEqual((double)expect[0], (double)real[0]);
        }
    }
}