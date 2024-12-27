using Cysharp.Threading.Tasks;
using DefaultNamespace.Data;
using DefaultNamespace.Logic.Interface;
using UnityEngine;
using VitalRouter.MRuby;

namespace DefaultNamespace.Logic
{
    public class RubyRunner : IScriptRunner
    {
        private readonly RubyContextHolder _contextHolder;
        public RubyRunner(RubyContextHolder contextHolder)
        {
            _contextHolder = contextHolder;
        }
        
        public async UniTask RunAsync()
        {
            var rubySource = Resources.Load<TextAsset>("test");
            using MRubyScript script = _contextHolder.Context.CompileScript(rubySource.bytes);    
            await script.RunAsync();
        }
    }
}