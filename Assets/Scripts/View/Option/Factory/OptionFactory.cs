using System.Collections.Generic;
using DefaultNamespace.View;
using UnityEngine;
using VitalRouter;

namespace DefaultNamespace.Factory
{
    public class OptionFactory
    {
        private readonly OptionViewBase _optionView;
        private readonly ICommandPublisher _commandPublisher;

        public OptionFactory(OptionViewBase optionView, ICommandPublisher commandPublisher)
        {
            _optionView = optionView;
            _commandPublisher = commandPublisher;
        }

        public OptionViewBase Create(string message)
        {
            var optionView = Object.Instantiate(_optionView);
            optionView.Construct(_commandPublisher,message);
            return optionView;
        }
        
        public IEnumerable<OptionViewBase> Create(string[] messages)
        {
            List<OptionViewBase> optionViews = new List<OptionViewBase>();
            foreach (var message in messages)
            {
                optionViews.Add(Create(message));
            }

            return optionViews;
        }
        
    }
}