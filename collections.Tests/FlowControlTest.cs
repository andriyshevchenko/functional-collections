using static System.Functional.FlowControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace collections.Tests
{
    [TestClass]
    public class FlowControlTest
    {
        [TestMethod]
        public void should_switch()
        {
            Assert.ThrowsException<ArithmeticException>(
                () =>
                    Switch(
                        5,
                        value => throw new ArgumentException(),
                        (6, value => throw new NotFiniteNumberException()),
                        (8, value => throw new ArgumentNullException()),
                        (5, value => throw new ArithmeticException())
                        ));
        }

        [TestMethod]
        public void should_not_switch_on_null()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => Switch(5, null));
        }

        [TestMethod]
        public void should_switch_on_null_label()
        {
            Switch(
                5,
                value => { },
                (5, null)
                );
        }

        [TestMethod]
        public void should_switch_on_default()
        {
            Assert.ThrowsException<ArgumentException>(
                () =>
                    Switch(
                        5,
                        value => throw new ArgumentException(),
                        (6, value => throw new NotFiniteNumberException()),
                        (8, value => throw new ArgumentNullException()),
                        (9, value => throw new ArithmeticException())
                        ));
        }
    }
}
