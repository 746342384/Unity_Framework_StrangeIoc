using System;

namespace Framework.framework.attribute
{
    public class RepositoryAttribute : Attribute
    {
        public readonly Type Type;

        public RepositoryAttribute(Type Type)
        {
            this.Type = Type;
        }
    }
}