using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Thrift.Transport.HBaseConfig
{
    [XmlRoot("HBaseClient")]
    [Serializable]
    public class HBaseClientConfig:System.Configuration.IConfigurationSectionHandler
    {
        [XmlAttribute]
        public string Host
        {
            get;
            set;
        }

        [XmlAttribute]
        public int Port
        {
            get;
            set;
        }

        [XmlAttribute]
        public int TimeOut
        {
            get;
            set;
        }

        private static void AssertConfig(HBaseClientConfig config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            if(string.IsNullOrWhiteSpace(config.Host))
            {
                throw new ArgumentNullException("host");
            }

            if (config.Port == 0)
            {
                throw new ArgumentNullException("port");
            }
        }

        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            HBaseClientConfig config = new HBaseClientConfig();

            foreach(XmlAttribute attr in section.FirstChild.Attributes)
            {
                switch (attr.Name.ToLower())
                {
                    case "host":
                        {
                            if (string.IsNullOrWhiteSpace(attr.Value))
                            {
                                throw new Exception("配置错误:host");
                            }
                            config.Host = attr.Value;
                            break;
                        }
                    case "port":
                        {
                            if (string.IsNullOrWhiteSpace(attr.Value))
                            {
                                throw new Exception("配置错误:port");
                            }
                            config.Port = int.Parse(attr.Value);
                            break;
                        }
                    case "timeout":
                        {
                            if (string.IsNullOrWhiteSpace(attr.Value))
                            {
                                throw new Exception("配置错误:timeout");
                            }
                            config.TimeOut = int.Parse(attr.Value);
                            break;
                        }
                }
            }

            AssertConfig(config);

            return config;
        }
    }
}
