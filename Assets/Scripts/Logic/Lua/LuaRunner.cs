using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DefaultNamespace.Logic.Interface;
using Lua;
using Lua.Standard;
using Lua.Unity;
using UnityEngine;

namespace DefaultNamespace.Logic.Lua
{
    public class LuaRunner : IScriptRunner
    {
        private readonly LuaStateHolder _luaStateHolder;
        private readonly LuaFunctionAdder _luaFunctionAdder;
        
        public LuaRunner(LuaStateHolder luaStateHolder, LuaFunctionAdder luaFunctionAdder)
        {
            _luaStateHolder = luaStateHolder;
            _luaFunctionAdder = luaFunctionAdder;
        }

        public async UniTask RunAsync()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            
            var script = Resources.Load<LuaAsset>("Assets/Resources/testLua");
            
            _luaFunctionAdder.AddFunctions();
            
            // Add standard libraries
            _luaStateHolder.LuaState.OpenModuleLibrary();
            
            try
            {
                await _luaStateHolder.LuaState.DoFileAsync("Assets/Resources/testLua.lua", cancellationToken:token);
            }
            catch (LuaParseException)
            {
                // 構文にエラーがあった際の処理
                throw;
            }
            catch (LuaRuntimeException)
            {
                // 実行時例外が発生した際の処理
                throw;
            }
        }
    }
}