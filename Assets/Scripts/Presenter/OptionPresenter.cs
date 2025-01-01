using Cysharp.Threading.Tasks;
using DefaultNamespace;
using DefaultNamespace.Data;
using DefaultNamespace.Factory;
using DefaultNamespace.Identfier;
using DefaultNamespace.Logic;
using DefaultNamespace.Logic.Interface;
using DefaultNamespace.View;
using UnityEngine.UI;
using VitalRouter;

namespace Presenter
{
    [Routes]
    public partial class OptionPresenter
    {
        private readonly ISharedVariableHandleable _sharedStateHandler;
        private readonly OptionController _optionController;
        private bool _waitOptionSelected;

        public OptionPresenter(ISharedVariableHandleable sharedStateHandler, OptionController optionController)
        {
            _sharedStateHandler = sharedStateHandler;
            _optionController = optionController;
        }

        [Route]
        void OnOptionSelected( SelectOptionCommand command)
        {
            _sharedStateHandler.Set(Identifier.OptionResult , command.OptionMessage);
            _optionController.ClearOptions();
            _waitOptionSelected = false;
        }

        [Route] 
        async UniTask ShowOption(ShowOptionCommand command)
        {
            _waitOptionSelected = true;
            _optionController.CreateOptions(command.Options);
            await UniTask.WaitWhile(()=>_waitOptionSelected);
        }
        
    }
}