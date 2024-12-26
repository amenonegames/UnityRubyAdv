using NullObjectGenerator;

namespace DefaultNamespace.View
{
    [InterfaceToNullObj]
    public interface IMessageVisualizable
    {
        void VisualizeMessage(string message);
    }
}