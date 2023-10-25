using System;
using System.Windows.Forms;

public class Program
{
  public static FrmMain frm = new FrmMain();
  [STAThread]
  static void Main(string[] args)
  {
    frm.FormLayout(); ;
    Application.Run(frm);
  }
}