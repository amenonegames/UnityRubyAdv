using System;
using System.Numerics;
using VitalRouter;
using VitalRouter.MRuby;


namespace DefaultNamespace
{

    [MRubyObject]
    partial struct DebugCommand : ICommand
    {
        public string Message;
    }
}