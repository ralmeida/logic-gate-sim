using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace FPGA.Tests
{
    [TestFixture]
    public class GateTests
    {
        private static IEnumerable<bool[]> GenerateCombinations(int length)
        {
            int max = 1 << length;
            int limit = Math.Min(50, max);
            for (int i = 0; i < limit; i++)
            {
                bool[] combo = new bool[length];
                for (int b = 0; b < length; b++)
                {
                    combo[b] = (i & (1 << b)) != 0;
                }
                yield return combo;
            }
        }

        private static IEnumerable<TestCaseData> NotCases()
        {
            yield return new TestCaseData(true).Returns(false);
            yield return new TestCaseData(false).Returns(true);
        }

        [TestCaseSource(nameof(NotCases))]
        public bool Not_gate_returns_inverse(bool input)
        {
            return GATE.NOT(input);
        }

        private static IEnumerable<TestCaseData> TwoInputCombinations()
        {
            yield return new TestCaseData(false, false);
            yield return new TestCaseData(false, true);
            yield return new TestCaseData(true, false);
            yield return new TestCaseData(true, true);
        }

        [TestCaseSource(nameof(TwoInputCombinations))]
        public void And_gate_two_input(bool a, bool b)
        {
            bool expected = a && b;
            Assert.AreEqual(expected, GATE.AND(a, b));
        }

        [TestCaseSource(nameof(TwoInputCombinations))]
        public void Nand_gate_two_input(bool a, bool b)
        {
            bool expected = !(a && b);
            Assert.AreEqual(expected, GATE.NAND(a, b));
        }

        [TestCaseSource(nameof(TwoInputCombinations))]
        public void Or_gate_two_input(bool a, bool b)
        {
            bool expected = a || b;
            Assert.AreEqual(expected, GATE.OR(a, b));
        }

        [TestCaseSource(nameof(TwoInputCombinations))]
        public void Nor_gate_two_input(bool a, bool b)
        {
            bool expected = !(a || b);
            Assert.AreEqual(expected, GATE.NOR(a, b));
        }

        [TestCaseSource(nameof(TwoInputCombinations))]
        public void Xor_gate_two_input(bool a, bool b)
        {
            bool expected = a ^ b;
            Assert.AreEqual(expected, GATE.XOR(a, b));
        }

        [TestCaseSource(nameof(TwoInputCombinations))]
        public void Xnor_gate_two_input(bool a, bool b)
        {
            bool expected = !(a ^ b);
            Assert.AreEqual(expected, GATE.XNOR(a, b));
        }

        private static IEnumerable<TestCaseData> MultiInputCombinations()
        {
            foreach (var combo in GenerateCombinations(5))
                yield return new TestCaseData(combo);
        }

        [TestCaseSource(nameof(MultiInputCombinations))]
        public void And_gate_multi_input(bool[] values)
        {
            bool expected = values.Length < 2 ? false : values.All(v => v);
            Assert.AreEqual(expected, GATE.AND(values));
        }

        [TestCaseSource(nameof(MultiInputCombinations))]
        public void Nand_gate_multi_input(bool[] values)
        {
            bool and = values.Length < 2 ? false : values.All(v => v);
            bool expected = !and;
            Assert.AreEqual(expected, GATE.NAND(values));
        }

        [TestCaseSource(nameof(MultiInputCombinations))]
        public void Or_gate_multi_input(bool[] values)
        {
            bool expected = values.Length < 2 ? false : values.Any(v => v);
            Assert.AreEqual(expected, GATE.OR(values));
        }

        [TestCaseSource(nameof(MultiInputCombinations))]
        public void Nor_gate_multi_input(bool[] values)
        {
            bool or = values.Length < 2 ? false : values.Any(v => v);
            bool expected = !or;
            Assert.AreEqual(expected, GATE.NOR(values));
        }

        [TestCaseSource(nameof(MultiInputCombinations))]
        public void Xor_gate_multi_input(bool[] values)
        {
            bool result = false;
            foreach (bool b in values) result ^= b;
            bool expected = result;
            Assert.AreEqual(expected, GATE.XOR(values));
        }

        [TestCaseSource(nameof(MultiInputCombinations))]
        public void Xnor_gate_multi_input(bool[] values)
        {
            bool result = false;
            foreach (bool b in values) result ^= b;
            bool expected = !result;
            Assert.AreEqual(expected, GATE.XNOR(values));
        }
    }
}
