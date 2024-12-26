using UnityEngine;
using VContainer;
using VitalRouter;

namespace DefaultNamespace.View
{
    public class ContinueButton : MonoBehaviour
    {

        private ICommandPublisher _commandPublisher;
        
        [Inject]
        public void Construct(ICommandPublisher commandPublisher)
        {
            _commandPublisher = commandPublisher;
        }
        
        public void OnClick()
        {
            _commandPublisher.PublishAsync(new TalkContinueCommand());
        }

    }
}