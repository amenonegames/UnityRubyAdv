using DefaultNamespace.Logic;
using UnityEngine;
using VContainer.Unity;
using VitalRouter;
using VitalRouter.MRuby;

namespace DefaultNamespace
{
    public class EntryPoint : IStartable
    {
        private readonly RubyRunner _runner;

        public EntryPoint(RubyRunner runner)
        {
            _runner = runner;
        }

        public async void Start()
        {
            await _runner.RunAsync();
        }
    }
}