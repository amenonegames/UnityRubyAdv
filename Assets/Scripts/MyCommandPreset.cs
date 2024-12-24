using VitalRouter.MRuby;

namespace DefaultNamespace
{
    [MRubyCommand("debug", typeof(DebugCommand))]
    public partial class MyCommandPreset : MRubyCommandPreset { }

}