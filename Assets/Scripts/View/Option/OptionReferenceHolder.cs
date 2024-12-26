using System.Collections;
using System.Collections.Generic;

namespace DefaultNamespace.View
{
    public class OptionReferenceHolder : IList<OptionViewBase>
    {
        private List<OptionViewBase> _activeOptions = new List<OptionViewBase>();

        public int Count => _activeOptions.Count;
        
        public bool IsReadOnly => false;
        public IEnumerator<OptionViewBase> GetEnumerator()
        {
            return _activeOptions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        { 
            return GetEnumerator();
        }

        public void Add(OptionViewBase item)
        {
            _activeOptions.Add(item);
        }
        
        public void AddRange(IEnumerable<OptionViewBase> items)
        {
            _activeOptions.AddRange(items);
        }

        public void Clear()
        {
            _activeOptions.Clear();
        }

        public bool Contains(OptionViewBase item)
        {
            return _activeOptions.Contains(item);
        }

        public void CopyTo(OptionViewBase[] array, int arrayIndex)
        {
            _activeOptions.CopyTo(array,arrayIndex);
        }

        public bool Remove(OptionViewBase item)
        {
            return _activeOptions.Remove(item);
        }

        public int IndexOf(OptionViewBase item)
        {
            return _activeOptions.IndexOf(item);
        }

        public void Insert(int index, OptionViewBase item)
        {
            _activeOptions.Insert(index,item);
        }

        public void RemoveAt(int index)
        {
            _activeOptions.RemoveAt(index);
        }

        public OptionViewBase this[int index]
        {
            get => _activeOptions[index];
            set => _activeOptions[index] = value;
        }
    }
}