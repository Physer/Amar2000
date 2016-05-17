using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace eFocus.Amar2000.API.Configuration
{
    public abstract class BaseConfigurationElementCollection<TElement> : ConfigurationElementCollection, IEnumerable<TElement>
        where TElement : ConfigurationElement
    {
        private readonly Func<TElement, object> _elementKeyPredicate;

        /// <param name="elementName">Name of the element inside the collection</param>
        /// <param name="elementKeyPredicate">Predicate pointing to the key of the contained element</param>
        protected BaseConfigurationElementCollection(string elementName, Func<TElement, object> elementKeyPredicate)
        {
            ElementName = elementName;
            _elementKeyPredicate = elementKeyPredicate;
        }

        public TElement this[int index]
        {
            get { return (TElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null) BaseRemoveAt(index);
                BaseAdd(index, value);
            }
        }

        public new TElement this[string key] => (TElement)BaseGet(key);

        protected override string ElementName { get; }

        public new IEnumerator<TElement> GetEnumerator()
        {
            return BaseGetAllKeys().Select(key => (TElement)BaseGet(key)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return (TElement)Activator.CreateInstance(typeof(TElement));
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return _elementKeyPredicate((TElement)element);
        }

        public int IndexOf(TElement element) => BaseIndexOf(element);

        public void Add(TElement element) => BaseAdd(element);

        protected override void BaseAdd(ConfigurationElement element) => BaseAdd(element, false);

        public void Remove(TElement element)
        {
            if (BaseIndexOf(element) != -1) BaseRemove(GetElementKey(element));
        }

        public void RemoveAt(int index) => BaseRemoveAt(index);

        public void Remove(string key) => BaseRemove(key);

        public void Clear() => BaseClear();
    }
}