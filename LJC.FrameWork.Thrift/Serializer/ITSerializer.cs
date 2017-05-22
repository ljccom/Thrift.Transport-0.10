using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thrift.Transport.Serializer
{
    public interface ITSerializer
    {
        byte[] Serialize(object obj);
        object DeSerialize(Type type, byte[] bytes);
    }
}
