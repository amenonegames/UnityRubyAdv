using System;
using UnityEngine;
using Lua;
using Lua.Standard;

namespace DefaultNamespace
{
    public class SampleStart : MonoBehaviour
    {
        
        
        private async void Start()
        {
            var state = LuaState.Create();
            // 標準ライブラリを追加
            state.OpenStandardLibraries();
            var result = await state.DoFileAsync("Assets/Scenario/TestScenario.lua");
            Debug.Log(result.GetValue(0));
        }
    }
}