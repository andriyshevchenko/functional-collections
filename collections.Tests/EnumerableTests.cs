using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static System.Collections.Generic.SeriesCreate;
using static System.Collections.Generic.Create;

namespace System.Linq.Functional.Tests
{
    [TestClass()]
    public class EnumerableTests
    {
        [TestMethod]
        public void ShouldSubstractArrays()
        {
            IsTrue(array(1.0, 2, 3, 4, 5)
                .SequenceEqual(Subst(array(3.0, 4, 5, 6, 7),
                                     array(2.0, 2, 2, 2, 2))));
        }

        [TestMethod]
        public void ShouldMult()
        {
            IsTrue(array(3.0, 6, 9, 12, 15).
                SequenceEqual(mul(2.0, array(1.5, 3, 4.5, 6, 7.5))));
        }

        [TestMethod]
        public void ShouldAddArrays()
        {
            IsTrue(array(3.0, 6, 9, 12, 15)
                .SequenceEqual(Sum(array(1.0, 2, 3, 4, 5),
                                   array(1.0, 2, 3, 4, 5),
                                   array(1.0, 2, 3, 4, 5))));
        }
    }
}