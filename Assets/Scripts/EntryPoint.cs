using DefaultNamespace.Logic;
using DefaultNamespace.Logic.Interface;
using UnityEngine;
using VContainer.Unity;
using VitalRouter;
using VitalRouter.MRuby;

namespace DefaultNamespace
{
    public class EntryPoint : IStartable
    {
        private readonly IScriptRunner _runner;

        public EntryPoint(IScriptRunner runner)
        {
            _runner = runner;
        }

        public async void Start()
        {
            await _runner.RunAsync();
        }
    }
}