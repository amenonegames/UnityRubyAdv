using DefaultNamespace;
using DefaultNamespace.Data;
using DefaultNamespace.Factory;
using DefaultNamespace.Logic;
using DefaultNamespace.View;
using VitalRouter;

namespace Presenter
{
    [Routes]
    public partial class OptionPresenter
    {
        private readonly SharedStateHandler _sharedStateHandler;
        private readonly OptionController _optionController;

        public OptionPresenter(SharedStateHandler sharedStateHandler, OptionController optionController)
        {
            _sharedStateHandler = sharedStateHandler;
            _optionController = optionController;
        }

        [Route]
        void OnOptionSelected( SelectOptionCommand command)
        {
            _sharedStateHandler.Set("result" , command.OptionMessage);
            _optionController.ClearOptions();
        }

        [Route] 
        void ShowOption(ShowOptionCommand command)
        {
            _optionController.CreateOptions(command.Options);
        }
        
    }
}