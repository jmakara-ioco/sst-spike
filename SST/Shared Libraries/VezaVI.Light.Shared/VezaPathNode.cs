using System;
using System.Collections.Generic;
using System.Text;

namespace VezaVI.Light.Shared
{
    public enum NodeType
    {
        Normal,
        Error,
        Answer,
        Selectable
    }

    public class VezaPathNode
    {
        public VezaPathNode(string caption, Guid entityID, Dictionary<string, string> values)
        {
            Caption = caption;
            EntityID = entityID;
            if (values != null)
                _values = values;
        }

        private Dictionary<string, string> _values = new Dictionary<string, string>();
        public VezaPathNode ParentNode { get; private set; } = null;
        public string Caption { get; set; }
        public bool IsSelected { get; set; }
        public Guid EntityID { get; set; }
        public NodeType NType { get; set; }

        public virtual string CustomSelectedNodeCSS { get; }
        public virtual string CustomNodeCSS { get; }

        private List<VezaPathNode> Nodes { get; set; } = new List<VezaPathNode>();

        public string this[string key]
        {
            get
            {
                if (_values.ContainsKey(key))
                    return _values[key];
                return string.Empty;
            }
        }

        public void AddNodes(params VezaPathNode[] nodes)
        {
            foreach (var node in nodes) {
                node.ParentNode = this;
                Nodes.Add(node);
            }
        }

        public bool HasNodes
        {
            get
            {
                return (Nodes.Count > 0);
            }
        }

        public List<VezaPathNode> GetNodes()
        {
            return Nodes;
        }

    }

}
