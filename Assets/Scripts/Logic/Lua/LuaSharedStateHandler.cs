using DefaultNamespace.Logic.Interface;

namespace DefaultNamespace.Logic.Lua
{
    public class LuaSharedStateHandler : ISharedVariableHandleable
    {
        private readonly LuaStateHolder _luaStateHolder;
        
        public LuaSharedStateHandler(LuaStateHolder luaStateHolder)
        {
            _luaStateHolder = luaStateHolder;
        }
        
        public void Set(string key, string val)
        {
            _luaStateHolder.LuaState.Environment[key] = val;
        }

        public void Set(string key, int val)
        {
            _luaStateHolder.LuaState.Environment[key] = val;
        }

        public void Set(string key, float val)
        {
            _luaStateHolder.LuaState.Environment[key] = val;
        }

        public void Set(string key, bool val)
        {
            _luaStateHolder.LuaState.Environment[key] = val;
        }

        public T Get<T>(string key)
        {
            return _luaStateHolder.LuaState.Environment[key].Read<T>();
        }
    }
}