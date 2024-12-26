using UnityEngine;
using UnityEngine.EventSystems;
using VitalRouter;

namespace DefaultNamespace.View
{
    public class OptionView : OptionViewBase , IPointerClickHandler 
    {
        private ICommandPublisher _commandPublisher;
        private string _message;
        
        public override void Construct(ICommandPublisher commandPublisher , string message)
        {
            _commandPublisher = commandPublisher;
            _message = message;
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            _commandPublisher.PublishAsync(new SelectOptionCommand(_message));
        }
    }
}