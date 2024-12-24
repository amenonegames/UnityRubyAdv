using Cysharp.Threading.Tasks;
using UnityEngine;
using VitalRouter;

namespace DefaultNamespace
{
    [Routes]
    public partial class DebugPresenter
    {

        [Route]
        private async UniTask Move(DebugCommand command)
        {
            Debug.Log(command.Message);
        }
    }
}