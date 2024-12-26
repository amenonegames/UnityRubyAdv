using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using VitalRouter;

namespace DefaultNamespace.View
{
    public class OptionView : OptionViewBase , IPointerClickHandler 
    {
        private ICommandPublisher _commandPublisher;
        private string _message;
        private TMP_Text _textMeshPro;
        private TMP_Text ThisTextMeshPro=> _textMeshPro ??= GetComponentInChildren<TMP_Text>(true);
        
        public override void Construct(ICommandPublisher commandPublisher , string message)
        {
            _commandPublisher = commandPublisher;
            _message = message;
            ThisTextMeshPro.text = message;
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            _commandPublisher.PublishAsync(new SelectOptionCommand(_message));
        }
    }
}