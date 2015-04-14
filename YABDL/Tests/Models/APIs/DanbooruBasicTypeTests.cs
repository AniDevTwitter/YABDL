using System;
using NUnit.Framework;
using System.Xml.Serialization;
using YABDL.Models.APIs;
using YABDL.Tools.Extensions;

namespace Tests.Models.APIs
{
    [TestFixture]
    public class DanbooruBasicTypeTests
    {
        [Serializable]
        [XmlRoot("test-type")]
        public class TestBasicType
        {

            public TestBasicType()
            {

            }

            public TestBasicType(bool isTesting)
            {
                Assert.IsTrue(isTesting);
                var rand = new Random();
                this.intValue = new DanbooruBasicType<int>(rand.Next(9999));
                this.stringValue = new DanbooruBasicType<string>(rand.NextDouble().ToString());
                this.boolValue = new DanbooruBasicType<bool>((rand.Next() % 2) == 0);
                this.datetimeValue = new DanbooruBasicType<DateTime?>(new DateTime(rand.Next()));
            }

            [XmlElement("int-attribute")]
            public DanbooruBasicType<int> intValue {get; set;}

            [XmlElement("bool-attribute")]
            public DanbooruBasicType<bool> boolValue {get; set;}

            [XmlElement("string-attribute")]
            public DanbooruBasicType<string> stringValue {get; set;}

            [XmlElement("dateTime-attribute")]
            public DanbooruBasicType<DateTime?> datetimeValue {get; set;}
           
        }

        [Test]
        public void TestSerialisation()
        {

            var data = new TestBasicType(true);
            var serialized = data.ToXml();
            var deserialized = serialized.FromXml<TestBasicType>();
            Assert.AreEqual(data.boolValue.Value, deserialized.boolValue.Value);
            Assert.AreEqual(data.datetimeValue.Value, deserialized.datetimeValue.Value);
            Assert.AreEqual(data.stringValue.Value, deserialized.stringValue.Value);
            Assert.AreEqual(data.intValue.Value, deserialized.intValue.Value);

        }



    }
}

