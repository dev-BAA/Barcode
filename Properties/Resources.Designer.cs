// Decompiled with JetBrains decompiler
// Type: codebar.Properties.Resources
// Assembly: Barcode, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AB4BCE4F-D8B2-4A05-9B0E-5091896B062F
// Assembly location: D:\TEMP\ProjectS\barcode v 1.3\Barcode.exe

using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace codebar.Properties
{
  [CompilerGenerated]
  [DebuggerNonUserCode]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (codebar.Properties.Resources.resourceMan == null)
          codebar.Properties.Resources.resourceMan = new ResourceManager("codebar.Properties.Resources", typeof (codebar.Properties.Resources).Assembly);
        return codebar.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return codebar.Properties.Resources.resourceCulture;
      }
      set
      {
        codebar.Properties.Resources.resourceCulture = value;
      }
    }

    internal Resources()
    {
    }
  }
}
