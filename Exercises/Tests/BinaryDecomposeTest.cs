using BinaryDecompose;

namespace Tests;

[TestClass]
public class BinaryDecomposeTest
{
  [TestMethod]
  public void Test1()
  {
    int x = Test.Run("111");
    Assert.AreEqual(5, x);
  }

  [TestMethod]
  public void Test2()
  {
    int x = Test.Run("011100");
    Assert.AreEqual(7, x);
  }

  [TestMethod]
  public void Test3()
  {
    int x = Test.Run("1111010101111");
    Assert.AreEqual(22, x);
  }

  [TestMethod]
  public void Test4()
  {
    int x = Test.Run(new string('1', 400000));
    Assert.AreEqual(799999, x); //799.999
  }
}