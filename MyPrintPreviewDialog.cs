using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace codebar
{
  internal class MyPrintPreviewDialog : PrintPreviewDialog
  {
    public MyPrintPreviewDialog()
    {
      this.InitializeComponent();
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.AccessibleDescription = (string) null;
      this.AccessibleName = (string) null;
      //componentResourceManager.ApplyResources((object) this, "$this");
      //componentResourceManager.ApplyResources(this, "$this");
      this.BackgroundImage = (Image) null;
      this.Font = (Font) null;
      this.Icon = (Icon) null;
      this.Name = "MyPrintPreviewDialog";
      this.ResumeLayout(false);
    }
  }
}
