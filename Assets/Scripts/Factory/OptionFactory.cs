using DefaultNamespace.View;
using UnityEngine;
using VitalRouter;

namespace DefaultNamespace.Factory
{
    public class OptionFactory
    {
        private readonly OptionView _optionView;
        private readonly IOptionRoot _optionRoot;
        private readonly ICommandPublisher _commandPublisher;

        public OptionFactory(OptionView optionView, IOptionRoot optionRoot, ICommandPublisher commandPublisher)
        {
            _optionView = optionView;
            _optionRoot = optionRoot;
            _commandPublisher = commandPublisher;
        }

        public void Create(string message)
        {
            var optionView = Object.Instantiate(_optionView, _optionRoot.Transform);
            optionView.Construct(_commandPublisher,message);
        }
        
        public void Create(string[] messages)
        {
            foreach (var message in messages)
            {
                Create(message);
            }
        }
        
    }
}