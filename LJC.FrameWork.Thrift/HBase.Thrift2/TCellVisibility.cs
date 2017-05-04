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

namespace HBase.Thrift2
{
#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TCellVisibility : TBase
    {
        private string _expression;

        public string Expression
        {
            get
            {
                return _expression;
            }
            set
            {
                __isset.expression = true;
                this._expression = value;
            }
        }


        public Isset __isset;
#if !SILVERLIGHT
        [Serializable]
#endif
        public struct Isset
        {
            public bool expression;
        }

        public TCellVisibility()
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
                                Expression = iprot.ReadString();
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
                TStruct struc = new TStruct("TCellVisibility");
                oprot.WriteStructBegin(struc);
                TField field = new TField();
                if (Expression != null && __isset.expression)
                {
                    field.Name = "expression";
                    field.Type = TType.String;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    oprot.WriteString(Expression);
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
            StringBuilder __sb = new StringBuilder("TCellVisibility(");
            bool __first = true;
            if (Expression != null && __isset.expression)
            {
                if (!__first) { __sb.Append(", "); }
                __first = false;
                __sb.Append("Expression: ");
                __sb.Append(Expression);
            }
            __sb.Append(")");
            return __sb.ToString();
        }

    }

}