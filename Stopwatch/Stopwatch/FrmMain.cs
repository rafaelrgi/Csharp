using System;
using System.Drawing;
using System.Windows.Forms;

public class FrmMain : Form
{
  int time = 0;
  private Timer timer;
  private Label labTime;
  private Button btnStartStop;
  private Button btnReset;
  public void FormLayout()
  {
    timer = new Timer();

    this.Name = "Stopwatch";
    this.Text = "Stopwatch";
    this.MaximizeBox = false;
    this.Size = new System.Drawing.Size(300, 200);
    this.StartPosition = FormStartPosition.CenterScreen;

    labTime = new Label
    {
      ForeColor = Color.Lime,
      Padding = new Padding(48, 18, 16, 16),
      BackColor = Color.Black,
      Font = new Font("Consolas", 36, FontStyle.Bold),
      Text = " ",
      Location = new Point(20, 10),
      Size = new Size(245, 96),
      BorderStyle = BorderStyle.Fixed3D,
    };
    this.Controls.Add(labTime);

    btnStartStop = new Button
    {
      Text = "Start/Stop",
      Location = new Point(10, 120),
      Size = new Size(120, 32),
    };
    btnStartStop.Click += new System.EventHandler(this.onStartStop);
    this.Controls.Add(btnStartStop);

    btnReset = new Button
    {
      Text = "Reset",
      Location = new Point(150, 120),
      Size = new Size(120, 32)
    };
    btnReset.Click += new System.EventHandler(this.onReset);
    this.Controls.Add(btnReset);


    timer = new Timer
    {
      Enabled = false,
      Interval = 1000,
    };
    timer.Tick += new System.EventHandler(this.onTick);
  }

  private void onTick(object sender, EventArgs e)
  {
    time++;
    int minutes = (int)(time / 60);
    int seconds = (int)(time % 60);
    string txt = minutes.ToString("00") + ":" + seconds.ToString("00");
    labTime.Text = txt;
    this.Text = txt;
  }

  void onStartStop(object sender, System.EventArgs e)
  {
    timer.Enabled = !timer.Enabled;
  }

  void onReset(object sender, System.EventArgs e)
  {
    time = 0;
    Text = "Stopwatch";
    labTime.Text = time.ToString("00:00");
  }
}