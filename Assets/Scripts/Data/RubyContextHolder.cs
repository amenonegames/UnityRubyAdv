using VitalRouter;
using VitalRouter.MRuby;

namespace DefaultNamespace.Data
{
    public class RubyContextHolder
    {
        private readonly Router _router;
        private readonly MRubyContext _context;
        private readonly MRubyCommandPreset _commandPreset;

        public MRubyContext Context => _context;
        public RubyContextHolder(Router router, MRubyContext context, MRubyCommandPreset commandPreset)
        {
            _router = router;
            _context = context;
            _commandPreset = commandPreset;
            context.Router = _router;
            context.CommandPreset = _commandPreset; 
        }
        
    }
}