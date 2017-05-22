using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Transport.Serializer;

namespace TestConsoleApplication
{
    public class SelfTSerializer : ITSerializer
    {
        public byte[] Serialize(object obj)
        {
            return LJC.FrameWork.EntityBuf.EntityBufCore.Serialize(obj);
        }

        public object DeSerialize(Type type, byte[] bytes)
        {
            return LJC.FrameWork.EntityBuf.EntityBufCore.DeSerialize(type, bytes);
        }
    }
}
