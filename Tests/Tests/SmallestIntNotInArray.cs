using SmallestIntNotInArray;

namespace Tests;

[TestClass]
public class SmallestIntNotInArrayTest
{
  [TestMethod]
  public void Test1()
  {
    int x = Test.Run(new[] { 1, 3, 6, 4, -1, 2 });
    Assert.AreEqual(5, x);
  }

  [TestMethod]
  public void Test2()
  {
    int x = Test.Run(new[] { 1, 3, 5, 4, 1, 9, 6, 2 });
    Assert.AreEqual(7, x);
  }

  [TestMethod]
  public void Test3()
  {
    int x = Test.Run(new[] { -9, 3, 2, 2, 1, -4 });
    Assert.AreEqual(4, x);
  }

  [TestMethod]
  public void Test4()
  {
    int x = Test.Run(new[] { -3, 0, -1, 0 });
    Assert.AreEqual(1, x); //799.999
  }
}