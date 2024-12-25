using VitalRouter;
using VitalRouter.MRuby;

namespace DefaultNamespace
{
    [MRubyObject]
    partial struct ShowOptionCommand : ICommand
    {
        public string[] Options;
    }
}