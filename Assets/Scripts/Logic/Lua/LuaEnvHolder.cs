using XLua;

namespace DefaultNamespace.Logic.Lua
{
    public class LuaEnvHolder
    {
        private readonly LuaEnv _env;
        public LuaEnv Env => _env;

        public LuaEnvHolder(LuaEnv env)
        {
            _env = env;
        }
        
        
        
    }
}