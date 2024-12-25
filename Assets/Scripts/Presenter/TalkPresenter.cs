using Cysharp.Threading.Tasks;
using DefaultNamespace.View;
using VitalRouter;

namespace DefaultNamespace.Presenter
{
    [Routes]
    public partial class TalkPresenter
    {
        private readonly IMessageVisualizable _messageVisualizable;
        private bool _waitContinue = false;
        
        public TalkPresenter(IMessageVisualizable messageVisualizable)
        {
            _messageVisualizable = messageVisualizable;
        }

        [Route]
        async UniTask OnTalk(TalkCommand command)
        {
            _waitContinue = true;
            _messageVisualizable.VisualizeMessage(command.Message);
            await UniTask.WaitWhile( () => _waitContinue == true);
        }
        
        [Route]
        void OnContinue(TalkContinueCommand command)
        {
            _waitContinue = false;
        }
        
    }
}