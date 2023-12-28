using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DevTools
{
  enum WorkItemType
  {
    Fix, Feature
  }

  internal struct GitCommands
  {
    public readonly string[] Commands1;
    public readonly string[] Commands2;

    public GitCommands(string[] commands1, string[] commands2)
    {
      Commands1 = commands1;
      Commands2 = commands2;
    }
  }

  internal static class SvcGit
  {
    internal static GitCommands Run(int id, WorkItemType type)
    {
      var txt = LoadTemplate();

      var branch =
          (type == WorkItemType.Fix ? "Fix" : "Feature")
          + "/#"
          + id.ToString();

      int separator = txt.Length;
      for (int i = txt.Length - 1; i >= 0; i--)
      {
        if (txt[i] == "----")
          separator = i;
        txt[i] = txt[i].Replace("|", "\r\n");
        if (!txt[i].Contains("$branch"))
          continue;
        txt[i] = txt[i].Replace("$branch", branch);
      }

      return new GitCommands(txt.Take(separator).ToArray(), txt.Skip(separator+1).ToArray());
    }

    private static string[] LoadTemplate()
    {
      return File.ReadAllLines("git_commands.txt");
    }

  }
}
