using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Dapper;

namespace KP.Domain.DapperAttributeMapper
{
    public static class TypeMapper
    {
        public static void Initialize(string @namespace)
        {
            var types = from type in Assembly.GetExecutingAssembly().GetTypes()
                where type.IsClass && type.Namespace == @namespace
                select type;

            types.ToList().ForEach(type =>
            {
                var mapper = (SqlMapper.ITypeMap)Activator
                    .CreateInstance(typeof(ColumnAttributeTypeMapper<>)
                        .MakeGenericType(type));
                SqlMapper.SetTypeMap(type, mapper);
            });
        }

        public static void Initialize(string nameSpace, Assembly assemblies)
        {
            var types = from type in assemblies.GetTypes()
                where type.GetTypeInfo().IsClass && type.Namespace == nameSpace
                select type;

            types.ToList().ForEach(type =>
            {
                var mapper = (SqlMapper.ITypeMap)Activator
                    .CreateInstance(typeof(ColumnAttributeTypeMapper<>)
                        .MakeGenericType(type));
                SqlMapper.SetTypeMap(type, mapper);
            });
        }

        public static void Initialize(Type type)
        {
            var mapper = (SqlMapper.ITypeMap)Activator
                .CreateInstance(typeof(ColumnAttributeTypeMapper<>)
                    .MakeGenericType(type));
            SqlMapper.SetTypeMap(type, mapper);
        }
    }
}
