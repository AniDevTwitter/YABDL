using System;
using System.Xml.Serialization;
using YABDL.Tools.XML.Attributes;
using MoreLinq;
using YABDL.Tools.Extenstions;

namespace YABDL.Tools.XML.Generics
{
        public abstract class XMLEntity : IEquatable<XMLEntity>
        {
            [XmlIgnore]
            private object owner;

            protected XMLEntity()
            {
                this.owner = null;
            }

            public abstract Guid Id
            {
                get;
                set;
            }

            [XmlIgnore]
            public object Owner
            {
                get
                {
                    return this.owner;
                }
                set
                {
                    this.owner = value;
                }
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

            //Override to specify behaviour
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

            //used to identify which context own this entity, object type because giving a real type is meaninless here
        }
    }

