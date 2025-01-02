using System.Linq;
using System.Threading.Tasks;
using DefaultNamespace.Identfier;
using DefaultNamespace.Logic.Interface;
using Lua;
using UnityEngine;
using VitalRouter;

namespace DefaultNamespace.Logic.Lua
{
    public class LuaFunctionAdder
    {
        private readonly LuaStateHolder _luaStateHolder;
        private readonly ICommandPublisher _commandPublisher;
        private readonly ISharedVariableHandleable  _sharedVariableHandleable;

        public LuaFunctionAdder(LuaStateHolder luaStateHolder, ICommandPublisher commandPublisher, ISharedVariableHandleable sharedVariableHandleable)
        {
            _luaStateHolder = luaStateHolder;
            _commandPublisher = commandPublisher;
            _sharedVariableHandleable = sharedVariableHandleable;
        }
        
        public void AddFunctions()
        {
            _luaStateHolder.LuaState.Environment["print"]=(new LuaFunction((context , buffer, token) =>
            {
                var args = context.GetArgument<string>(0);
                
                _commandPublisher.PublishAsync(new DebugCommand() {Message = args});
                return new ValueTask<int>(0);
            }));

            _luaStateHolder.LuaState.Environment["talk"]=  (new LuaFunction( async (context , buffer, token) =>
            {
                var args = context.GetArgument<string>(0);
                await _commandPublisher.PublishAsync(new TalkCommand() {Message = args});
                return 0;
            }));
            
            _luaStateHolder.LuaState.Environment["option"]=  (new LuaFunction( async (context , buffer, token) =>
            {
                var args = context.GetArgument<LuaTable>(0);

                var span = args.GetArrayMemory().Slice(0,args.ArrayLength);
                
                var array = span.ToArray().Select(x =>x.Read<string>()).ToArray();
                await _commandPublisher.PublishAsync(new ShowOptionCommand() {Options = array});
                
                var variable = _sharedVariableHandleable.Get<string>(Identifier.OptionResult);
                
                // put result in buffer
                buffer.Span[0] = variable;
                // return  value count
                return 1;
            }));
            
        }
    }
}