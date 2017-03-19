using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LemonWay.UnitTest
{
    [TestClass]
    public class UnitTest1WebService1
    {
        CoreLib instance = new CoreLib();

        #region tests fibonacci
        [TestMethod]
        public void FibonacciTest1_NegativeValeur()
        {
            int valeur = -1;
            decimal expected = -1;
            decimal actual = this.instance.Fibonacci(valeur);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FibonacciTest2_BorneInf()
        {
            int valeur = 0;
            decimal expected = -1;
            decimal actual = this.instance.Fibonacci(valeur);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FibonacciTest3_ValeurConforme1()
        {
            int valeur = 1;
            decimal expected = 1;
            decimal actual = this.instance.Fibonacci(valeur);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FibonacciTest4_ValeurConforme100()
        {
            int valeur = 100;
            decimal expected = 3.54224848179262E+20;
            decimal actual = this.instance.Fibonacci(valeur);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FibonacciTest5_BorneSup()
        {
            int valeur = 101;
            decimal expected = -1;
            decimal actual = this.instance.Fibonacci(valeur);
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region XmlToJson
        [TestMethod]
        public void XmlToJsonTest1_SimpleOK()
        {
            string valeur = "<foo>bar</foo>";
            string expected = "{\"foo\":\"bar\"}";

            string actual = this.instance.XmlToJson(valeur);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void XmlToJsonTest2_BadFormat()
        {
            string valeur = "<foo>hello</bar>";
            string expected = "Bad  Xml  format";
            string actual = this.instance.XmlToJson(valeur);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void XmlToJsonTest3_CommplexeOK()
        {
            string valeur = "<TRANS><HPAY><ID>103</ID><STATUS>3</STATUS><EXTRA><IS3DS>0</IS3DS><AUTH>031183</AUTH></EXTRA><INT_MSG/><MLABEL>501767XXXXXX6700</MLABEL><MTOKEN>projectOl</MTOKEN></HPAY></TRANS>";
            string expected = "{\"TRANS\":{\"HPAY\":{\"ID\":\"103\",\"STATUS\":\"3\",\"EXTRA\":{\"IS3DS\":\"0\",\"AUTH\":\"031183\"},\"INT_MSG\":null,\"MLABEL\":\"501767XXXXXX6700\",\"MTOKEN\":\"projectOl\"}}}";
            string actual = this.instance.XmlToJson(valeur);
            Assert.AreEqual(expected, actual);
        }
        #endregion
    }
}
