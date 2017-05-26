using HBase.Thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thrift.Protocol;
using Thrift.Transport;
using Thrift.Transport.Serializer;
using Thrift.Transport.Warpper;

namespace TestConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            TSerializer.RegisterSerializer(new SelfTSerializer());

            Man man=new Man();
            man.Name="李金川";
            man.Sex=1;
            man.Age=30;
            man.Fei = new int[] { 1, 2, 3 };
            man.Addr = new List<string> { "老师","学生","朋友"};
            Thrift2ClientWarpper.Put<Man>("hbaseclient1", "test", "man", man.Name, man, (m) =>
                {
                    var tps = LJC.FrameWork.EntityBuf.EntityBufCore.GetTypeEntityBufType(typeof(Man));
                    var list = new List<KeyValuePair<string, object>>();
                    foreach (Tuple<LJC.FrameWork.EntityBuf.EntityBufType,bool> it in tps)
                    {
                        list.Add(new KeyValuePair<string, object>(it.Item1.Property.PropertyInfo.Name, it.Item1.Property.PropertyInfo.GetValue(m)));
                    }
                    return list;
                });

            Thrift2ClientWarpper.CheckAndDelete("hbaseclient1", "test", man.Name, "man", "Name", "李金川", new[] { "Sex" });
            var resultljc = Thrift2ClientWarpper.Get<Man>("hbaseclient1", "test", man.Name, (t, s) =>
            {
                var tps = LJC.FrameWork.EntityBuf.EntityBufCore.GetTypeEntityBufType(t);
                var pop = tps.First(p => p.Item1.Property.PropertyInfo.Name.Equals(s));

                return pop.Item1.Property.PropertyInfo;
            });


            man.Name = "张三丰";
            man.Age = 100;
            Thrift2ClientWarpper.Append<Man>("hbaseclient1", "test", man.Name, "man", man, (m) =>
            {
                var tps = LJC.FrameWork.EntityBuf.EntityBufCore.GetTypeEntityBufType(typeof(Man));
                var list = new List<KeyValuePair<string, object>>();
                foreach (Tuple<LJC.FrameWork.EntityBuf.EntityBufType, bool> it in tps)
                {
                    list.Add(new KeyValuePair<string, object>(it.Item1.Property.PropertyInfo.Name, it.Item1.Property.PropertyInfo.GetValue(m)));
                }
                return list;
            });

            Thrift2ClientWarpper.Delete("hbaseclient1", "test", man.Name);

            var result = Thrift2ClientWarpper.Get<Man>("hbaseclient1", "test", man.Name, (t, s) =>
                {
                    var tps = LJC.FrameWork.EntityBuf.EntityBufCore.GetTypeEntityBufType(t);
                    var pop = tps.First(p => p.Item1.Property.PropertyInfo.Name.Equals(s));

                    return pop.Item1.Property.PropertyInfo;
                });

            return;


            TTransport transport = null;
            try
            {
                //实例化Socket连接
                //transport = new TSocket("2.5.172.38", 30001);
                transport = new TSocket("hbaseclient1");
                //实例化一个协议对象
                TProtocol tProtocol = new TBinaryProtocol(transport);
                //实例化一个Hbase的Client对象
                var client = new Hbase.Client(tProtocol);
                //打开连接
                transport.Open();

                Console.Write("已连接上");
                //client.disableTable(Encoding.UTF8.GetBytes("dz_CDN_Ip_Stat"));
                //client.deleteTable(Encoding.UTF8.GetBytes("dz_CDN_Ip_Stat"));
                //client.createTable(Encoding.UTF8.GetBytes("dz_CDN_Ip_Stat"), new List<ColumnDescriptor> { new ColumnDescriptor { Name = Encoding.UTF8.GetBytes("col1") } });
                //Console.Write("创建表");
                
                //var boo=client.checkAndPut(Encoding.UTF8.GetBytes("dz_CDN_Ip_Stat"), Encoding.UTF8.GetBytes("201310_001_0_1100"), Encoding.UTF8.GetBytes("col1"), Encoding.UTF8.GetBytes("val"), null, null);
                //Console.WriteLine("写数据:" + boo);

                //根据表名，RowKey名来获取结果集
                //List<TRowResult> reslut = client.getRow(Encoding.UTF8.GetBytes("dz_CDN_Ip_Stat"), Encoding.UTF8.GetBytes("row1"), null);
                //Console.WriteLine("读数据:" + reslut.Count);

                ////遍历结果集
                //foreach (var key in reslut)
                //{
                //    Console.WriteLine("RowKey:\n{0}", Encoding.UTF8.GetString(key.Row));
                //    //打印Qualifier和对应的Value
                //    foreach (var k in key.Columns)
                //    {
                //        Console.WriteLine("Family:Qualifier:" + "\n" + Encoding.UTF8.GetString(k.Key));
                //        Console.WriteLine("Value:" + Encoding.UTF8.GetString(k.Value.Value));
                //    }
                //}

                var tables = client.getTableNames();
                

                foreach (var bi in tables)
                {
                    transport.Close();
                    transport.Open();
                    client.disableTable(bi);
                    client.deleteTable(bi);

                    //var tb = Encoding.UTF8.GetString(bi);
                    //Console.WriteLine(tb);
                    //transport.Close();
                    //transport.Open();
                    //var dic = client.getColumnDescriptors(bi);
                    //foreach (var kv in dic)
                    //{
                    //    Console.WriteLine(string.Format("{0}:{1}", Encoding.UTF8.GetString(kv.Key), Encoding.UTF8.GetString(kv.Value.Name)));
                    //}
                }

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
            finally
            {
                if (null != transport)
                {
                    transport.Close();
                }
            }
            Console.ReadLine();
        }
    }
}
