/*
Create an implementation of the rotational cipher, also sometimes called the Caesar cipher.

The Caesar cipher is a simple shift cipher that relies on transposing all the letters in the alphabet using an integer key between 0 and 26. Using a key of 0 or 26 will always yield the same output due to modular arithmetic. The letter is shifted for as many values as the value of the key.

The general notation for rotational ciphers is ROT + <key>. The most commonly used rotational cipher is ROT13.

A ROT13 on the Latin alphabet would be as follows:

Plain:  abcdefghijklmnopqrstuvwxyz
Cipher: nopqrstuvwxyzabcdefghijklm
It is stronger than the Atbash cipher because it has 27 possible keys, and 25 usable keys.

Ciphertext is written out in the same formatting as the input including spaces and punctuation.

Examples
ROT5 omg gives trl
ROT0 c gives c
ROT26 Cool gives Cool
ROT13 The quick brown fox jumps over the lazy dog. gives Gur dhvpx oebja sbk whzcf bire gur ynml qbt.
ROT13 Gur dhvpx oebja sbk whzcf bire gur ynml qbt. gives The quick brown fox jumps over the lazy dog.
*/

using System.Globalization;
using System.Reflection.Metadata;
using System.Text;

namespace CaesarCipher;

public static class Test
{
  public static string Decipher(string s, int key)
  {
    return Run(s, 26 - key);
  }

  public static string Run(string s, int key)
  {
    if (key == 0 || key == 26)
      return s;

    StringBuilder x = new(s.RemoveAccents(), s.Length);
    for (int i = 0; i < s.Length; i++)
    {
      char c = x[i];
      if (!Char.IsLetter(c))
        continue;

      int b = (char.IsLower(c) ? 'a' : 'A');
      x[i] = (char)((c - b + key) % 26 + b);
    }

    return x.ToString();
  }

  static string RemoveAccents(this string s)
  {
    return new string(s
        .Normalize(NormalizationForm.FormD)
        .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
        .ToArray());
  }

}