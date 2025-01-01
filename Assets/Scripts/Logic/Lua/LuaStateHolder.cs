
using Lua;

namespace DefaultNamespace.Logic.Lua
{
    public class LuaStateHolder
    {
        private readonly LuaState _luaState;
        public LuaState LuaState => _luaState;
        
        public LuaStateHolder(LuaState luaState)
        {
            _luaState = luaState;
        }
        
    }
}