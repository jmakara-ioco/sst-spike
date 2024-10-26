using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VezaVI.Light.Shared
{
    public class VezaSerie
    {
        public string Name { get; set; }

        public Dictionary<string, double> _values { get; set; } = new Dictionary<string, double>();

        public List<string> Legends
        {
            get
            {
                return _values.Keys.ToList();
            }
        }

        public void SetValue(string key, double value)
        {
            if (!string.IsNullOrEmpty(key)) {
                if (_values.ContainsKey(key))
                    _values[key] = value;
                else
                    _values.Add(key, value);
            }
        }

        public double GetValue(string key)
        {
            if (_values.ContainsKey(key))
                return _values[key];
            return 0;
        }

        public double GetValueAsPercentage(string key)
        {
            double sum = _values.Sum(x => x.Value);
            if (_values.ContainsKey(key))
                return _values[key] / sum;
            return 0;
        }
    }
}
