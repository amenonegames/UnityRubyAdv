using System.Linq;
using DefaultNamespace.Factory;
using UnityEngine;

namespace DefaultNamespace.View
{
    public class OptionController
    {
        private readonly OptionFactory _optionFactory;
        private readonly IOptionRoot _optionRoot;
        private readonly OptionReferenceHolder _optionReferenceHolder;

        public OptionController(OptionFactory optionFactory, IOptionRoot optionRoot, OptionReferenceHolder optionReferenceHolder)
        {
            _optionFactory = optionFactory;
            _optionRoot = optionRoot;
            _optionReferenceHolder = optionReferenceHolder;
        }
        

        public void CreateOptions(string[] options)
        {
            var createdOptions=_optionFactory.Create(options);
            var optionViews = createdOptions as OptionView[] ?? createdOptions.ToArray();
            _optionRoot.SetParent(optionViews);
            
            _optionReferenceHolder.AddRange(optionViews);
        }
        
        public void ClearOptions()
        {
            foreach (var option in _optionReferenceHolder)
            {
                Object.Destroy(option.gameObject);
            }
            _optionReferenceHolder.Clear();
        }
        
    }
}