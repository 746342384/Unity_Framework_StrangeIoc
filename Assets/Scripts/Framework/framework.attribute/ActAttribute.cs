using System;

namespace Framework.framework.attribute.api
{
    public class ActAttribute : Attribute
    {
        public Type Tag;
        public object Key;

        public ActAttribute(Type type)
        {
            Tag = type;
        }

        public ActAttribute(Type type, object key)
        {
            Tag = type;
            Key = key;
        }
    }
}