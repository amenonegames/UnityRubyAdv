using UnityEngine;
using VContainer.Unity;
using VitalRouter;
using VitalRouter.MRuby;

namespace DefaultNamespace
{
    public class EntryPoint : IStartable
    {
        private readonly Router _router;

        public EntryPoint(Router router)
        {
            _router = router;
        }

        public async void Start()
        {
            var context = MRubyContext.Create();
            context.Router = _router;                // ... 1
            context.CommandPreset = new MyCommandPreset(); // ... 2
            
            var rubySource = Resources.Load<TextAsset>("test");

            using MRubyScript script = context.CompileScript(rubySource.bytes);    
            await script.RunAsync();
            
        }
    }
}