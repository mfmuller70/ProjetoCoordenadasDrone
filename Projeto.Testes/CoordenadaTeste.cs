using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Projeto.Testes
{
    [TestClass]
    public class DroneUnitTest
    {
        [TestMethod]
        public void Input_NNNNNLLLLL()
        {
            Assert.AreEqual("(5, 5)", Evaluate.PosicaoCartesiana("NNNNNLLLLL"));
        }

        [TestMethod]
        public void Input_NLNLNLNLNL()
        {
            Assert.AreEqual("(5, 5)", Evaluate.PosicaoCartesiana("NLNLNLNLNL"));
        }

        [TestMethod]
        public void Input_NNNNNXLLLLLX()
        {
            Assert.AreEqual("(4, 4)", Evaluate.PosicaoCartesiana("NNNNNXLLLLLX"));
        }

        [TestMethod]
        public void Input_SSSSSOOOOO()
        {
            Assert.AreEqual("(-5, -5)", Evaluate.PosicaoCartesiana("SSSSSOOOOO"));
        }

        [TestMethod]
        public void Input_S5O5()
        {
            Assert.AreEqual("(-5, -5)", Evaluate.PosicaoCartesiana("S5O5"));
        }

        [TestMethod]
        public void Input_NNX2()
        {
            Assert.AreEqual("(999, 999)", Evaluate.PosicaoCartesiana("NNX2"));
        }

        [TestMethod]
        public void Input_N123LSX()
        {
            Assert.AreEqual("(1, 123)", Evaluate.PosicaoCartesiana("N123LSX"));
        }

        [TestMethod]
        public void Input_NLS3X()
        {
            Assert.AreEqual("(1, 1)", Evaluate.PosicaoCartesiana("NLS3X"));
        }

        [TestMethod]
        public void Input_NNNXLLLXX()
        {
            Assert.AreEqual("(1, 2)", Evaluate.PosicaoCartesiana("NNNXLLLXX"));
        }

        [TestMethod]
        public void Input_N40L30S20O10NLSOXX()
        {
            Assert.AreEqual("(21, 21)", Evaluate.PosicaoCartesiana("N40L30S20O10NLSOXX"));
        }

        [TestMethod]
        public void Input_NLSOXXN40L30S20O10()
        {
            Assert.AreEqual("(21, 21)", Evaluate.PosicaoCartesiana("NLSOXXN40L30S20O10"));
        }

        [TestMethod]
        public void Input_NULL()
        {
            Assert.AreEqual("(999, 999)", Evaluate.PosicaoCartesiana(null)); // Entrada nula
        }

        [TestMethod]
        public void Input_EMPTY()
        {
            Assert.AreEqual("(999, 999)", Evaluate.PosicaoCartesiana("")); // Entrada vazia
        }

        [TestMethod]
        public void Input_WHITESPACE()
        {
            Assert.AreEqual("(999, 999)", Evaluate.PosicaoCartesiana("   ")); // Entrada espaço vazio
        }

        [TestMethod]
        public void Input_123()
        {
            Assert.AreEqual("(999, 999)", Evaluate.PosicaoCartesiana("123")); // Entrada inválida
        }

        [TestMethod]
        public void Input_123N()
        {
            Assert.AreEqual("(999, 999)", Evaluate.PosicaoCartesiana("123N")); // passos antes da direçao
        }

        [TestMethod]
        public void Input_N2147483647N()
        {
            Assert.AreEqual("(999, 999)", Evaluate.PosicaoCartesiana("N2147483647N")); // Overflow
        }

        [TestMethod]
        public void Input_NNI()
        {
            Assert.AreEqual("(999, 999)", Evaluate.PosicaoCartesiana("NNI")); // Commando inválido
        }

        [TestMethod]
        public void Input_N2147483647XN()
        {
            Assert.AreEqual("(0, 1)", Evaluate.PosicaoCartesiana("N2147483647XN")); // Overflow cancelado
        }

        [TestMethod]
        public void Input_BIGSTRING()
        {
            Assert.AreEqual("(500, 500)", Evaluate.PosicaoCartesiana(new string(
                Enumerable.Repeat('N', 1000).Concat(
                Enumerable.Repeat('S', 500)).Concat(
                Enumerable.Repeat('L', 1000)).Concat(
                Enumerable.Repeat('O', 500)).ToArray())));
        }
    }
}