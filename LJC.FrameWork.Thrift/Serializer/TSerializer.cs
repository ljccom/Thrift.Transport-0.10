using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thrift.Transport.Serializer
{
    public class TSerializer
    {
        static ITSerializer TSerializerInstance = null;

        public static void RegisterSerializer(ITSerializer ser)
        {
            TSerializerInstance = ser;
        }

        public static byte[] GetBytes(object obj)
        {
            if (TSerializerInstance == null)
            {
                return null;
            }

            return TSerializerInstance.Serialize(obj);
        }

        public static object GetObject(Type type, byte[] bytes)
        {
            if (TSerializerInstance == null)
            {
                return null;
            }

            return TSerializerInstance.DeSerialize(type, bytes);
        }
    }
}
