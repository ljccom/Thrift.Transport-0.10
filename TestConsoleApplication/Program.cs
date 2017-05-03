﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thrift.Protocol;
using Thrift.Transport;

namespace TestConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            TTransport transport = null;
            try
            {
                //实例化Socket连接
                transport = new TSocket("192.168.0.110", 9090);
                //实例化一个协议对象
                TProtocol tProtocol = new TBinaryProtocol(transport);
                //实例化一个Hbase的Client对象
                var client = new Hbase.Client(tProtocol);
                //打开连接
                transport.Open();

                Console.Write("已连接上");

                client.createTable(Encoding.UTF8.GetBytes("dz_CDN_Ip_Stat"), new List<ColumnDescriptor> { new ColumnDescriptor { Name = Encoding.UTF8.GetBytes("col1") } });
                Console.Write("创建表");
                
                var boo=client.checkAndPut(Encoding.UTF8.GetBytes("dz_CDN_Ip_Stat"), Encoding.UTF8.GetBytes("201310_001_0_1100"), Encoding.UTF8.GetBytes("col1"), Encoding.UTF8.GetBytes("val"), null, null);
                Console.WriteLine("写数据:" + boo);

                //根据表名，RowKey名来获取结果集
                List<TRowResult> reslut = client.getRow(Encoding.UTF8.GetBytes("dz_CDN_Ip_Stat"), Encoding.UTF8.GetBytes("201310_001_0_1100"), null);
                Console.WriteLine("读数据:" + reslut.Count);

                //遍历结果集
                foreach (var key in reslut)
                {
                    Console.WriteLine("RowKey:\n{0}", Encoding.UTF8.GetString(key.Row));
                    //打印Qualifier和对应的Value
                    foreach (var k in key.Columns)
                    {
                        Console.WriteLine("Family:Qualifier:" + "\n" + Encoding.UTF8.GetString(k.Key));
                        Console.WriteLine("Value:" + Encoding.UTF8.GetString(k.Value.Value));
                    }
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