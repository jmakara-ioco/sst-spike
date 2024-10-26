using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VezaVI.Light.Shared
{
    public class VezaMultiSerie
    {
        public string Name { get; set; }

        public Dictionary<string, List<double>> _values { get; set; } = new Dictionary<string, List<double>>();

        public List<string> Legends
        {
            get
            {
                return _values.Keys.ToList();
            }
        }

        public void SetValues(string key, List<double> values)
        {
            if (_values.ContainsKey(key))
                _values[key] = values;
            else
                _values.Add(key, values);
        }

        public double GetColumnCount()
        {
            if (_values.Count == 0)
                return 0;
            return _values.Max(x => x.Value.Count);
        }

        public double GetMaxValue()
        {
            if (_values.Count == 0)
                return 0;
            return _values.Max(x => x.Value.Max());
        }

        public List<double> GetValue(string key)
        {
            int maxValues = _values.Max(x => x.Value.Count);
            List<double> values = new List<double>();
            if (_values.ContainsKey(key))
                values = _values[key];
            while (values.Count < maxValues)
            {
                values.Add(0);
            }
            return values;
        }
    }
}
