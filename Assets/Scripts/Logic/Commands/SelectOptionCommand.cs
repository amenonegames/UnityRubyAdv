using VitalRouter;

namespace DefaultNamespace
{
    public struct SelectOptionCommand : ICommand
    {
        public string OptionMessage;
        
        public SelectOptionCommand(string optionMessage)
        {
            OptionMessage = optionMessage;
        }
    }
}