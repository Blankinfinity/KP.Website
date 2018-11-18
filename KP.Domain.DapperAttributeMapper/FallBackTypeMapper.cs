using System;
using System.Collections.Generic;
using System.Reflection;
using Dapper;

namespace KP.Domain.DapperAttributeMapper
{
    // https://stackoverflow.com/questions/8902674/manually-map-column-names-with-class-properties
    public class FallBackTypeMapper : SqlMapper.ITypeMap
    {
        private readonly IEnumerable<SqlMapper.ITypeMap> _mappers;

        public FallBackTypeMapper(IEnumerable<SqlMapper.ITypeMap> mappers)
        {
            _mappers = mappers;
        }

        public ConstructorInfo FindConstructor(string[] names, Type[] types)
        {
            foreach (var mapper in _mappers)
            {
                try
                {
                    var result = mapper.FindConstructor(names, types);

                    if (result != null)
                    {
                        return result;
                    }
                }
                catch (NotImplementedException nix)
                {
                    // Ignore NotImplementedException's thrown by the CustomPropertyTypeMap
                    // and continue to the next mapping strategy.
                }
            }
            return null;
        }

        public ConstructorInfo FindExplicitConstructor()
        {
            // https://github.com/henkmollema/Dapper-FluentMap/commit/d43ed9f03ae36f9fec101f19ee3e83ab961af5c1
            foreach (var mapper in _mappers)
            {
                try
                {
                    var result = mapper.FindExplicitConstructor();
                    if (result != null)
                    {
                        return result;
                    }
                }
                catch (NotImplementedException)
                {
                    // Ignore NotImplementedException's thrown by the CustomPropertyTypeMap
                    // and continue to the next mapping strategy.
                }
            }
            return null;
        }

        public SqlMapper.IMemberMap GetConstructorParameter(ConstructorInfo constructor, string columnName)
        {
            foreach (var mapper in _mappers)
            {
                try
                {
                    var result = mapper.GetConstructorParameter(constructor, columnName);

                    if (result != null)
                    {
                        return result;
                    }
                }
                catch (NotImplementedException nix)
                {
                    // the CustomPropertyTypeMap only supports a no-args
                    // constructor and throws a not implemented exception.
                    // to work around that, catch and ignore.
                }
            }
            return null;
        }

        public SqlMapper.IMemberMap GetMember(string columnName)
        {
            foreach (var mapper in _mappers)
            {
                try
                {
                    var result = mapper.GetMember(columnName);

                    if (result != null)
                    {
                        return result;
                    }
                }
                catch (NotImplementedException nix)
                {
                    // the CustomPropertyTypeMap only supports a no-args
                    // constructor and throws a not implemented exception.
                    // to work around that, catch and ignore.
                }
            }
            return null;
        }
    }
}
