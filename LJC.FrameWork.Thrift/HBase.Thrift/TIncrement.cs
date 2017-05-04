/**
 * Autogenerated by Thrift Compiler (0.10.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace HBase.Thrift
{
    /// <summary>
    /// For increments that are not incrementColumnValue
    /// equivalents.
    /// </summary>
#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TIncrement : TBase
    {
        private byte[] _table;
        private byte[] _row;
        private byte[] _column;
        private long _ammount;

        public byte[] Table
        {
            get
            {
                return _table;
            }
            set
            {
                __isset.table = true;
                this._table = value;
            }
        }

        public byte[] Row
        {
            get
            {
                return _row;
            }
            set
            {
                __isset.row = true;
                this._row = value;
            }
        }

        public byte[] Column
        {
            get
            {
                return _column;
            }
            set
            {
                __isset.column = true;
                this._column = value;
            }
        }

        public long Ammount
        {
            get
            {
                return _ammount;
            }
            set
            {
                __isset.ammount = true;
                this._ammount = value;
            }
        }


        public Isset __isset;
#if !SILVERLIGHT
        [Serializable]
#endif
        public struct Isset
        {
            public bool table;
            public bool row;
            public bool column;
            public bool ammount;
        }

        public TIncrement()
        {
        }

        public void Read(TProtocol iprot)
        {
            iprot.IncrementRecursionDepth();
            try
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.String)
                            {
                                Table = iprot.ReadBinary();
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        case 2:
                            if (field.Type == TType.String)
                            {
                                Row = iprot.ReadBinary();
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        case 3:
                            if (field.Type == TType.String)
                            {
                                Column = iprot.ReadBinary();
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        case 4:
                            if (field.Type == TType.I64)
                            {
                                Ammount = iprot.ReadI64();
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }
            finally
            {
                iprot.DecrementRecursionDepth();
            }
        }

        public void Write(TProtocol oprot)
        {
            oprot.IncrementRecursionDepth();
            try
            {
                TStruct struc = new TStruct("TIncrement");
                oprot.WriteStructBegin(struc);
                TField field = new TField();
                if (Table != null && __isset.table)
                {
                    field.Name = "table";
                    field.Type = TType.String;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBinary(Table);
                    oprot.WriteFieldEnd();
                }
                if (Row != null && __isset.row)
                {
                    field.Name = "row";
                    field.Type = TType.String;
                    field.ID = 2;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBinary(Row);
                    oprot.WriteFieldEnd();
                }
                if (Column != null && __isset.column)
                {
                    field.Name = "column";
                    field.Type = TType.String;
                    field.ID = 3;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteBinary(Column);
                    oprot.WriteFieldEnd();
                }
                if (__isset.ammount)
                {
                    field.Name = "ammount";
                    field.Type = TType.I64;
                    field.ID = 4;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteI64(Ammount);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }
            finally
            {
                oprot.DecrementRecursionDepth();
            }
        }

        public override string ToString()
        {
            StringBuilder __sb = new StringBuilder("TIncrement(");
            bool __first = true;
            if (Table != null && __isset.table)
            {
                if (!__first) { __sb.Append(", "); }
                __first = false;
                __sb.Append("Table: ");
                __sb.Append(Table);
            }
            if (Row != null && __isset.row)
            {
                if (!__first) { __sb.Append(", "); }
                __first = false;
                __sb.Append("Row: ");
                __sb.Append(Row);
            }
            if (Column != null && __isset.column)
            {
                if (!__first) { __sb.Append(", "); }
                __first = false;
                __sb.Append("Column: ");
                __sb.Append(Column);
            }
            if (__isset.ammount)
            {
                if (!__first) { __sb.Append(", "); }
                __first = false;
                __sb.Append("Ammount: ");
                __sb.Append(Ammount);
            }
            __sb.Append(")");
            return __sb.ToString();
        }

    }

}