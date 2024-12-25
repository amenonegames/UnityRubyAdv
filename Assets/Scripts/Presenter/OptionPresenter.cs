using DefaultNamespace;
using DefaultNamespace.Data;
using DefaultNamespace.Factory;
using DefaultNamespace.Logic;
using VitalRouter;

namespace Presenter
{
    [Routes]
    public partial class OptionPresenter
    {
        private readonly SharedStateHandler _sharedStateHandler;
        private readonly OptionFactory _optionFactory;

        public OptionPresenter(SharedStateHandler sharedStateHandler, OptionFactory optionFactory)
        {
            _sharedStateHandler = sharedStateHandler;
            _optionFactory = optionFactory;
        }

        [Route]
        private void OnOptionSelected( SelectOptionCommand command)
        {
            _sharedStateHandler.Set("result" , command.OptionMessage);
        }

        [Route] 
        private void ShowOption(ShowOptionCommand command)
        {
            _optionFactory.Create(command.Options);
        }
        
    }
}