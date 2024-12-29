namespace DefaultNamespace.Logic.Lua
{
    public class LuaRunner
    {
        private readonly LuaEnvHolder _luaEnvHolder;
        
        public LuaRunner(LuaEnvHolder luaEnvHolder)
        {
            _luaEnvHolder = luaEnvHolder;
        }
        
        public void Run()
        {
            // _luaEnvHolder.Env.DoString();
        }
    }
}