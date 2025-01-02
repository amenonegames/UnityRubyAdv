using VitalRouter.MRuby;

namespace DefaultNamespace.Data
{
    public class RubyContextHolder
    {
        private readonly MRubyContext _context;

        public MRubyContext Context => _context;

        public RubyContextHolder(MRubyContext context)
        {
            _context = context;
        }
    }
}