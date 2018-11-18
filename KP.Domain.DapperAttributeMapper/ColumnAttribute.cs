using System;

namespace KP.Domain.DapperAttributeMapper
{
    // https://stackoverflow.com/questions/20951531/dapper-with-attributes-mapping
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public string Name { get; set; }

        public ColumnAttribute(string name)
        {
            Name = name;
        }
    }
}
