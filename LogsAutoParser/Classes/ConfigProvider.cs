using System.Collections.Generic;
using System.Configuration;
using System.Xml;


namespace LogsAutoParser
{
    public class ConfigProvider : IConfigurationSectionHandler
    {
        public string PatternRegex { get; set; }
        public object Create(object parent, object configContext, XmlNode section)
        {
            List<string> myConfigObject = new List<string>();

            foreach (XmlNode childNode in section.ChildNodes)
            {
                foreach (XmlAttribute attrib in childNode.Attributes)
                {
                    myConfigObject.Add(PatternRegex = attrib.Value);
                }
            }
            return myConfigObject;
        }
    }
}
