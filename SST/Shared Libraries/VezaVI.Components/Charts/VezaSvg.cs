using System;
using System.Collections.Generic;
using System.Text;

namespace VezaVI.Light.Components
{
    internal class VezaSvg : IEnumerable<string>
    {
        private List<string> internalList = new List<string>();
        public IEnumerator<string> GetEnumerator() => internalList.GetEnumerator();

        public List<string> GetAttributes()
        {
            return internalList;
        }

        public void Add(string name, string value) => internalList.Add($@"{name}={value}");

        private List<VezaSvg> m_innerCollection = new List<VezaSvg>();
        public List<VezaSvg> GetChildren()
        {
            return m_innerCollection;
        }
        //public IEnumerator<SVG> GetItemsEnumerator() => m_innerCollection.GetEnumerator();
        //IEnumerator IEnumerable.GetEnumerator() => m_innerCollection.GetEnumerator();
        public void AddItems(params VezaSvg[] items)
        {
            foreach (var item in items)
                m_innerCollection.Add(item);
        }
        public void Draw()
        {
            //if here it will end up depnednecy on buildrendertree
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return internalList.GetEnumerator();
        }

        public string type = "svg";
    }
}
