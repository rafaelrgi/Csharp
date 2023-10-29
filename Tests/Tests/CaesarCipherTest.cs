using CaesarCipher;

namespace Tests;

[TestClass]
public class CaesarCipherTest
{
  [TestMethod]
  public void Test1()
  {
    string s = "Lorem ipsum dolor sit amet,  consectetur adipiscing elit. Suspendisse nec scelerisque urna. ";
    string x = Test.Run(s, 0);
    Assert.AreEqual(s, x);
  }

  [TestMethod]
  public void Test2()
  {
    string s = "Lorem ipsum dolor sit amet,  consectetur adipiscing elit. Suspendisse nec scelerisque urna. ";
    string x = Test.Run(s, 26);
    Assert.AreEqual(s, x);
  }

  [TestMethod]
  public void Test3()
  {
    string s = "abcde";
    string x = Test.Run(s, 1);
    Assert.AreEqual("bcdef", x);
  }

  [TestMethod]
  public void Test4()
  {
    string s = "abcdefghijklmnopqrstuvwxyz";
    string x = Test.Run(s, 13);
    Assert.AreEqual("nopqrstuvwxyzabcdefghijklm", x);
  }

  [TestMethod]
  public void Test5()
  {
    string s = "Lorem ipsum dolor sit amet,  consectetur adipiscing elit. Suspendisse nec scelerisque urna. ";
    string x = Test.Run(s, 26);
    Assert.AreEqual(s, x);
  }

  [TestMethod]
  public void Test6()
  {
    string s = "Lorem ipsum dolor sit amet,  consectetur adipiscing elit! Suspendisse nec scelerisque urna. ";
    string x = Test.Run(s, 21);
    Assert.AreEqual(x, "Gjmzh dknph yjgjm ndo vhzo,  xjinzxozopm vydkdnxdib zgdo! Npnkziydnnz izx nxzgzmdnlpz pmiv. ");
  }

  [TestMethod]
  public void Test7()
  {
    string s = "Lôrém ípsüm dÔlór sít àmêt,  cõnsectetur ãdipiscing elit! Suspendisse nec scelerisque urna.";
    string x = Test.Run(s, 7);
    Assert.AreEqual(x, "Svylt pwzbt kVsvy zpa htla,  jvuzljalaby hkpwpzjpun lspa! Zbzwlukpzzl ulj zjlslypzxbl byuh.");
  }

  [TestMethod]
  public void Test8()
  {
    string s = "Lorem ipsum dolor sit amet,  consectetur adipiscing elit! Suspendisse nec scelerisque urna.";
    string x = Test.Run(s, 13);
    x = Test.Decipher(x, 13);
    Assert.AreEqual(x, s);
  }
}