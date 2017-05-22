using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Thrift.Protocol;
using Thrift.Transport;
namespace HBase.Thrift.HbaseTests
{
    [TestClass()]
    public class ClientTests
    {
        [TestMethod()]
        public void CreateTableTest()
        {
             //实例化Socket连接
             //transport = new TSocket("2.5.172.38", 30001);
            var transport = new TSocket("hbaseclient1");
            //实例化一个协议对象
            TProtocol tProtocol = new TBinaryProtocol(transport);
            
            string logtablename="logs";
            using(var client = new HBase.Thrift.Hbase.Client(tProtocol))
            {
                transport.Open();
                client.createTable(Encoding.UTF8.GetBytes(logtablename), new List<ColumnDescriptor>
                {
                    new ColumnDescriptor{
                        Name=Encoding.UTF8.GetBytes("cjzf.vlogs")
                     }
                });

                var tables = client.getTableNames();
                foreach (var tb in tables)
                {
                    var tbname = Encoding.UTF8.GetString(tb);
                }
            }
        }

        [TestMethod()]
        public void InsertData()
        {
            //实例化Socket连接
            //transport = new TSocket("2.5.172.38", 30001);
            var transport = new TSocket("hbaseclient1");
            //实例化一个协议对象
            TProtocol tProtocol = new TBinaryProtocol(transport);

            string logtablename = "logs";
            using (var client = new HBase.Thrift.Hbase.Client(tProtocol))
            {
                transport.Open();
                var boo = client.checkAndPut(Encoding.UTF8.GetBytes(logtablename), Encoding.UTF8.GetBytes("row1"), Encoding.UTF8.GetBytes("cjzf.vlogs:url"),
                    null, new Mutation
                    {
                        Column = Encoding.UTF8.GetBytes("cjzf.vlogs:url"),
                        Value = Encoding.UTF8.GetBytes("http://lulufaer.web2.nat123.net/cjzf/newsDetail.aspx?id=434494"),
                        IsDelete=false,
                        WriteToWAL=true
                    },null);

                var rows = client.getRow(Encoding.UTF8.GetBytes(logtablename), Encoding.UTF8.GetBytes("row1"), null);
            }
        }

        [TestMethod()]
        public void InsertReadData()
        {
            //实例化Socket连接
            //transport = new TSocket("2.5.172.38", 30001);
            var transport = new TSocket("hbaseclient1");
            //实例化一个协议对象
            TProtocol tProtocol = new TBinaryProtocol(transport);

            string logtablename = "logs";
            //using (var client = new HBase.Thrift.Hbase.Client(tProtocol))
            //{
            //    transport.Open();

            //    var rows = client.getRow(Encoding.UTF8.GetBytes(logtablename), Encoding.UTF8.GetBytes("row1"), null);
            //}
            using (var client = new HBase.Thrift2.THBaseService.Client(tProtocol))
            {
                transport.Open();

                var rows = client.get(Encoding.UTF8.GetBytes(logtablename), new Thrift2.TGet(Encoding.UTF8.GetBytes("row1")));
            }
        }
    }
}
