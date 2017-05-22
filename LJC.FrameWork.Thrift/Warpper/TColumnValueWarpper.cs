using HBase.Thrift2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thrift.Transport.Warpper
{
    public class TColumnValueWarpper
    {
        internal TColumnValue TColumnVal = null;

        public TColumnValueWarpper(string familyname,string colname,object val)
        {
            byte[] family=Encoding.UTF8.GetBytes(familyname);
            byte[] qualifiter=Encoding.UTF8.GetBytes(colname);
            TColumnVal = new TColumnValue(family, qualifiter, Serializer.TSerializer.GetBytes(val));
        }
    }
}
