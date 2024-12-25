using VitalRouter;
using VitalRouter.MRuby;

namespace DefaultNamespace
{
    [MRubyObject]
    public partial struct TalkCommand : ICommand
    {
        public string Message;
    }
}