using HBase.Thrift2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport.Serializer;

namespace Thrift.Transport.Warpper
{
    public class Thrift2ClientWarpper
    {

        public static void Test<T>(string configname, string table, string rowid)
        {
            //实例化Socket连接
            //transport = new TSocket("2.5.172.38", 30001);
            var transport = new TSocket(configname);
            //实例化一个协议对象
            TProtocol tProtocol = new TBinaryProtocol(transport);

            byte[] tablenamebytes = Encoding.UTF8.GetBytes(table);
            byte[] rownamebytes = Encoding.UTF8.GetBytes(rowid);
            using (var client = new HBase.Thrift2.THBaseService.Client(tProtocol))
            {
                transport.Open();

                try
                {
                    
                }
                finally
                {
                    transport.Close();
                }
            }
        }

        public static void Put<T>(string configname, string table,string family,string rowid,T obj,Func<T,IEnumerable<KeyValuePair<string,object>>> fun)
        {
            //实例化Socket连接
            //transport = new TSocket("2.5.172.38", 30001);
            var transport = new TSocket(configname);
            //实例化一个协议对象
            TProtocol tProtocol = new TBinaryProtocol(transport);

            byte[] tablenamebytes = Encoding.UTF8.GetBytes(table);
            byte[] familybytes=Encoding.UTF8.GetBytes(family);
            byte[] rownamebytes = Encoding.UTF8.GetBytes(rowid);
            using (var client = new HBase.Thrift2.THBaseService.Client(tProtocol))
            {
                transport.Open();

                try
                {
                    List<TColumnValue> columnvaluelist = new List<TColumnValue>();
                    foreach (var kv in fun(obj))
                    {
                        columnvaluelist.Add(new TColumnValue(familybytes, Encoding.UTF8.GetBytes(kv.Key),
                            Serializer.TSerializer.GetBytes(kv.Value)));
                    }

                    client.put(tablenamebytes, new HBase.Thrift2.TPut(rownamebytes, columnvaluelist));

                }
                finally
                {
                    transport.Close();
                }
            }
        }

        public static T Get<T>(string configname,string table,string rowid,Func<Type,string,System.Reflection.PropertyInfo> funGetProperty) where T:new()
        {
            //实例化Socket连接
            //transport = new TSocket("2.5.172.38", 30001);
            var transport = new TSocket(configname);
            //实例化一个协议对象
            TProtocol tProtocol = new TBinaryProtocol(transport);

            byte[] tablenamebytes = Encoding.UTF8.GetBytes(table);
            byte[] rownamebytes = Encoding.UTF8.GetBytes(rowid);
            using (var client = new HBase.Thrift2.THBaseService.Client(tProtocol))
            {
                transport.Open();

                try
                {
                    var rows = client.get(tablenamebytes, new HBase.Thrift2.TGet(rownamebytes));
                    if (rows.ColumnValues != null && rows.ColumnValues.Count > 0)
                    {
                        T instance = (T)System.Activator.CreateInstance(typeof(T));
                        var typet=typeof(T);
                        foreach (var cv in rows.ColumnValues)
                        {
                            var columname = Encoding.UTF8.GetString(cv.Qualifier);
                            var pop = funGetProperty(typet, columname);
                            pop.SetValue(instance, TSerializer.GetObject(pop.PropertyType, cv.Value));
                        }
                        return instance;
                    }
                    else
                    {
                        return default(T);
                    }
                }
                finally
                {
                    transport.Close();
                }
            }
        }
    }
}
