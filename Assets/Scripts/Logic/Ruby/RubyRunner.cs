using Cysharp.Threading.Tasks;
using DefaultNamespace.Data;
using DefaultNamespace.Logic.Interface;
using UnityEngine;
using VitalRouter;
using VitalRouter.MRuby;

namespace DefaultNamespace.Logic
{
    public class RubyRunner : IScriptRunner
    {
        private readonly RubyContextHolder _contextHolder;
        private readonly Router _router;
        private readonly MyCommandPreset _commandPreset;

        public RubyRunner(RubyContextHolder contextHolder, Router router, MyCommandPreset commandPreset)
        {
            _contextHolder = contextHolder;
            _router = router;
            _commandPreset = commandPreset;
        }

        public async UniTask RunAsync()
        {
            var context = _contextHolder.Context;
            context.Router = _router;
            context.CommandPreset = _commandPreset; 
            
            var rubySource = Resources.Load<TextAsset>("Ruby/main");
            using MRubyScript script = context.CompileScript(rubySource.bytes);    
            await script.RunAsync();
        }
    }
}