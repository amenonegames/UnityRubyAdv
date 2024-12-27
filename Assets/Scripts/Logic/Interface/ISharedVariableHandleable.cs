namespace DefaultNamespace.Logic.Interface
{
    public interface ISharedVariableHandleable
    {
        public void Set(string key, string val);
        public void Set(string key, int val);
        public void Set(string key, float val);
        public void Set(string key, bool val);
        public T Get<T>(string key);
    }
}