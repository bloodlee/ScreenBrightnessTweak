using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{
  public MainWindow()
    : base(Gtk.WindowType.Toplevel)
  {
    Build();
  }

  protected void OnDeleteEvent(object sender, DeleteEventArgs a)
  {
    Application.Quit();
    a.RetVal = true;
  }

  private void OnTweakEvent(object sender, EventArgs args)
  {
    Console.WriteLine("Brightness will be adjusted to {0}...", brightnessRange.Value / 100.0);
    adjustBrightness(brightnessRange.Value / 100.0);
  }

  private void adjustBrightness(double brightness)
  {
      System.Diagnostics.Process proc = new System.Diagnostics.Process();
      proc.EnableRaisingEvents = false; 
      proc.StartInfo.FileName = "xrandr";
      proc.StartInfo.Arguments = String.Format("--output eDP1 --brightness {0}", brightness);
      proc.Start();
      proc.WaitForExit();
  }
}
