using VitalRouter.MRuby;

namespace DefaultNamespace
{
    [MRubyCommand("debug", typeof(DebugCommand))]
    [MRubyCommand("talk", typeof(TalkCommand))]
    [MRubyCommand("option" , typeof(ShowOptionCommand))]
    public partial class MyCommandPreset : MRubyCommandPreset { }

}