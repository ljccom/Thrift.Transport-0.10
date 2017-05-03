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


/// <summary>
/// A Scan object is used to specify scanner parameters when opening a scanner.
/// </summary>
#if !SILVERLIGHT
[Serializable]
#endif
public partial class TScan : TBase
{
  private byte[] _startRow;
  private byte[] _stopRow;
  private long _timestamp;
  private List<byte[]> _columns;
  private int _caching;
  private byte[] _filterString;
  private int _batchSize;
  private bool _sortColumns;
  private bool _reversed;
  private bool _cacheBlocks;

  public byte[] StartRow
  {
    get
    {
      return _startRow;
    }
    set
    {
      __isset.startRow = true;
      this._startRow = value;
    }
  }

  public byte[] StopRow
  {
    get
    {
      return _stopRow;
    }
    set
    {
      __isset.stopRow = true;
      this._stopRow = value;
    }
  }

  public long Timestamp
  {
    get
    {
      return _timestamp;
    }
    set
    {
      __isset.timestamp = true;
      this._timestamp = value;
    }
  }

  public List<byte[]> Columns
  {
    get
    {
      return _columns;
    }
    set
    {
      __isset.columns = true;
      this._columns = value;
    }
  }

  public int Caching
  {
    get
    {
      return _caching;
    }
    set
    {
      __isset.caching = true;
      this._caching = value;
    }
  }

  public byte[] FilterString
  {
    get
    {
      return _filterString;
    }
    set
    {
      __isset.filterString = true;
      this._filterString = value;
    }
  }

  public int BatchSize
  {
    get
    {
      return _batchSize;
    }
    set
    {
      __isset.batchSize = true;
      this._batchSize = value;
    }
  }

  public bool SortColumns
  {
    get
    {
      return _sortColumns;
    }
    set
    {
      __isset.sortColumns = true;
      this._sortColumns = value;
    }
  }

  public bool Reversed
  {
    get
    {
      return _reversed;
    }
    set
    {
      __isset.reversed = true;
      this._reversed = value;
    }
  }

  public bool CacheBlocks
  {
    get
    {
      return _cacheBlocks;
    }
    set
    {
      __isset.cacheBlocks = true;
      this._cacheBlocks = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool startRow;
    public bool stopRow;
    public bool timestamp;
    public bool columns;
    public bool caching;
    public bool filterString;
    public bool batchSize;
    public bool sortColumns;
    public bool reversed;
    public bool cacheBlocks;
  }

  public TScan() {
  }

  public void Read (TProtocol iprot)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.String) {
              StartRow = iprot.ReadBinary();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              StopRow = iprot.ReadBinary();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.I64) {
              Timestamp = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.List) {
              {
                Columns = new List<byte[]>();
                TList _list13 = iprot.ReadListBegin();
                for( int _i14 = 0; _i14 < _list13.Count; ++_i14)
                {
                  byte[] _elem15;
                  _elem15 = iprot.ReadBinary();
                  Columns.Add(_elem15);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.I32) {
              Caching = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 6:
            if (field.Type == TType.String) {
              FilterString = iprot.ReadBinary();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 7:
            if (field.Type == TType.I32) {
              BatchSize = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 8:
            if (field.Type == TType.Bool) {
              SortColumns = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 9:
            if (field.Type == TType.Bool) {
              Reversed = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 10:
            if (field.Type == TType.Bool) {
              CacheBlocks = iprot.ReadBool();
            } else { 
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

  public void Write(TProtocol oprot) {
    oprot.IncrementRecursionDepth();
    try
    {
      TStruct struc = new TStruct("TScan");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (StartRow != null && __isset.startRow) {
        field.Name = "startRow";
        field.Type = TType.String;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteBinary(StartRow);
        oprot.WriteFieldEnd();
      }
      if (StopRow != null && __isset.stopRow) {
        field.Name = "stopRow";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteBinary(StopRow);
        oprot.WriteFieldEnd();
      }
      if (__isset.timestamp) {
        field.Name = "timestamp";
        field.Type = TType.I64;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(Timestamp);
        oprot.WriteFieldEnd();
      }
      if (Columns != null && __isset.columns) {
        field.Name = "columns";
        field.Type = TType.List;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.String, Columns.Count));
          foreach (byte[] _iter16 in Columns)
          {
            oprot.WriteBinary(_iter16);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (__isset.caching) {
        field.Name = "caching";
        field.Type = TType.I32;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Caching);
        oprot.WriteFieldEnd();
      }
      if (FilterString != null && __isset.filterString) {
        field.Name = "filterString";
        field.Type = TType.String;
        field.ID = 6;
        oprot.WriteFieldBegin(field);
        oprot.WriteBinary(FilterString);
        oprot.WriteFieldEnd();
      }
      if (__isset.batchSize) {
        field.Name = "batchSize";
        field.Type = TType.I32;
        field.ID = 7;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(BatchSize);
        oprot.WriteFieldEnd();
      }
      if (__isset.sortColumns) {
        field.Name = "sortColumns";
        field.Type = TType.Bool;
        field.ID = 8;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(SortColumns);
        oprot.WriteFieldEnd();
      }
      if (__isset.reversed) {
        field.Name = "reversed";
        field.Type = TType.Bool;
        field.ID = 9;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(Reversed);
        oprot.WriteFieldEnd();
      }
      if (__isset.cacheBlocks) {
        field.Name = "cacheBlocks";
        field.Type = TType.Bool;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(CacheBlocks);
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

  public override string ToString() {
    StringBuilder __sb = new StringBuilder("TScan(");
    bool __first = true;
    if (StartRow != null && __isset.startRow) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("StartRow: ");
      __sb.Append(StartRow);
    }
    if (StopRow != null && __isset.stopRow) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("StopRow: ");
      __sb.Append(StopRow);
    }
    if (__isset.timestamp) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Timestamp: ");
      __sb.Append(Timestamp);
    }
    if (Columns != null && __isset.columns) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Columns: ");
      __sb.Append(Columns);
    }
    if (__isset.caching) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Caching: ");
      __sb.Append(Caching);
    }
    if (FilterString != null && __isset.filterString) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("FilterString: ");
      __sb.Append(FilterString);
    }
    if (__isset.batchSize) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("BatchSize: ");
      __sb.Append(BatchSize);
    }
    if (__isset.sortColumns) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("SortColumns: ");
      __sb.Append(SortColumns);
    }
    if (__isset.reversed) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Reversed: ");
      __sb.Append(Reversed);
    }
    if (__isset.cacheBlocks) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("CacheBlocks: ");
      __sb.Append(CacheBlocks);
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}

