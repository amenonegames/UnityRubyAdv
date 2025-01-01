using Cysharp.Threading.Tasks;
using UnityEngine;
using VitalRouter;

namespace DefaultNamespace
{
    [Routes]
    public partial class DebugPresenter
    {

        [Route]
        private void Move(DebugCommand command)
        {
            Debug.Log(command.Message);
        }
    }
}