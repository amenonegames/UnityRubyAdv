﻿using DefaultNamespace.Data;

namespace DefaultNamespace.Logic
{
    public class SharedStateHandler
    {
        private readonly RubyContextHolder _contextHolder;

        public SharedStateHandler(RubyContextHolder contextHolder)
        {
            _contextHolder = contextHolder;
        }

        public void Set( string key, string val)
        {
            _contextHolder.Context.SharedState.Set(key, val);
        }
        
        public void Set( string key, int val)
        {
            _contextHolder.Context.SharedState.Set(key, val);
        }
        
        public void Set( string key, float val)
        {
            _contextHolder.Context.SharedState.Set(key, val);
        }
        
        public void Set( string key, bool val)
        {
            _contextHolder.Context.SharedState.Set(key, val);
        }

        public T Get<T>(string key)
        {
            return _contextHolder.Context.SharedState.GetOrDefault<T>(key);
        }
        
    }
}