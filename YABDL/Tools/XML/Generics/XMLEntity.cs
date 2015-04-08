using System;
using System.Xml.Serialization;
using YABDL.Tools.XML.Attributes;
using MoreLinq;
using YABDL.Tools.Extenstions;

namespace YABDL.Tools.XML.Generics
{
        public abstract class XMLEntity : IEquatable<XMLEntity>
        {
            protected XMLEntity()
            {
                this.Owner = null;
            }

            public abstract Guid Id
            {
                get;
                set;
            }

            [XmlIgnore]
            //used to identify which context own this entity, type is object because giving a real type/interface is meaningless here
            public object Owner
            {
                get;
                set;
            }

            public static bool operator !=(XMLEntity left, XMLEntity right)
            {
                return !(left == right);
            }

            public static bool operator ==(XMLEntity left, XMLEntity right)
            {
                if (object.ReferenceEquals(left, right))
                {
                    return true;
                }
                if (object.ReferenceEquals(left, null))
                {
                    return false;
                }
                return left.Equals(right);
            }

            public void ApplyDiff(ModifyEntry modify)
            {
                modify.Modifiers.ForEach(x => this.ApplyDiff(x.FieldName, x.FieldValue));
            }

            public override bool Equals(object obj)
            {
                var casted = obj as XMLEntity;
                if (casted != null)
                {
                    return this.Equals(casted);
                }
                return false;
            }

            public bool Equals(XMLEntity other)
            {
                if (object.ReferenceEquals(this, other))
                {
                    return true;
                }
                if (object.ReferenceEquals(other, null))
                {
                    return false; // this cannot be null if member method is called
                }
                return this.Id.Equals(other.Id);
            }

            //Override this to specify behaviour
            public virtual ModifyEntry GetDiff()
            {
                var ret = new ModifyEntry();
                ret.IdEntry = this.Id;
                this.GetType().GetFields().ForEach(x =>
                    {
                        var complex = (ComplexType)Attribute.GetCustomAttribute(x, typeof(ComplexType));
                        ret.Modifiers.Add(new ModifyField()
                            {
                                FieldName = x.Name,
                                FieldValue = complex == null ? x.GetValue(this).ConvertToString() : complex.ConvertToString(x.GetValue(this))
                            });
                    });
                return ret;
            }

            public override int GetHashCode()
            {
                return this.Id.GetHashCode();
            }

            //Override for specific behaviour
            protected virtual void ApplyDiff(string fieldName, string fieldValue)
            {
                var field = this.GetType().GetField(fieldName);
                var complex = (ComplexType)Attribute.GetCustomAttribute(field, typeof(ComplexType));
                field.SetValue(this, complex == null ? fieldValue.ConvertTo(field.FieldType) : complex.ConvertFromString(fieldValue));
            }

        }
    }

