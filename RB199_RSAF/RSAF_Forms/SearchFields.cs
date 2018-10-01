using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSAF_Forms
{
    public enum ValueTypes
    {
        Text = 1,
        DateTime = 2,
        ComboBox = 3,
        CheckBox = 4
    }

    public class SearchFields
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ValueTypes ValueType { get; set; }
    }
}
