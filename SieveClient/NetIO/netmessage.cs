//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: netmessage.proto
namespace netmessage
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CProto")]
  public partial class CProto : global::ProtoBuf.IExtensible
  {
    public CProto() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private byte[] _body;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"body", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public byte[] body
    {
      get { return _body; }
      set { _body = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CP1")]
  public partial class CP1 : global::ProtoBuf.IExtensible
  {
    public CP1() {}
    
    private int _a;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"a", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int a
    {
      get { return _a; }
      set { _a = value; }
    }
    private long _b;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"b", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public long b
    {
      get { return _b; }
      set { _b = value; }
    }
    private string _c;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"c", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string c
    {
      get { return _c; }
      set { _c = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CP2")]
  public partial class CP2 : global::ProtoBuf.IExtensible
  {
    public CP2() {}
    
    private string _a;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"a", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string a
    {
      get { return _a; }
      set { _a = value; }
    }
    private string _b;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"b", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string b
    {
      get { return _b; }
      set { _b = value; }
    }
    private long _c;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"c", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public long c
    {
      get { return _c; }
      set { _c = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"EchoProto")]
  public partial class EchoProto : global::ProtoBuf.IExtensible
  {
    public EchoProto() {}
    
    private string _data;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"data", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string data
    {
      get { return _data; }
      set { _data = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CSetCamaraSeqReqProto")]
  public partial class CSetCamaraSeqReqProto : global::ProtoBuf.IExtensible
  {
    public CSetCamaraSeqReqProto() {}
    
    private uint _seq;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"seq", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint seq
    {
      get { return _seq; }
      set { _seq = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SSetCamaraSeqRepProto")]
  public partial class SSetCamaraSeqRepProto : global::ProtoBuf.IExtensible
  {
    public SSetCamaraSeqRepProto() {}
    
    private uint _result;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint result
    {
      get { return _result; }
      set { _result = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CSendImageProcessDataReqProto")]
  public partial class CSendImageProcessDataReqProto : global::ProtoBuf.IExtensible
  {
    public CSendImageProcessDataReqProto() {}
    
    private string _ic_card_no;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"ic_card_no", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string ic_card_no
    {
      get { return _ic_card_no; }
      set { _ic_card_no = value; }
    }
    private int _image_seq;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"image_seq", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int image_seq
    {
      get { return _image_seq; }
      set { _image_seq = value; }
    }
    private int _x;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"x", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int x
    {
      get { return _x; }
      set { _x = value; }
    }
    private int _y;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"y", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int y
    {
      get { return _y; }
      set { _y = value; }
    }
    private byte[] _data;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"data", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public byte[] data
    {
      get { return _data; }
      set { _data = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SSendImageProcessDataRepProto")]
  public partial class SSendImageProcessDataRepProto : global::ProtoBuf.IExtensible
  {
    public SSendImageProcessDataRepProto() {}
    
    private string _ic_card_no;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"ic_card_no", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string ic_card_no
    {
      get { return _ic_card_no; }
      set { _ic_card_no = value; }
    }
    private int _image_seq;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"image_seq", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int image_seq
    {
      get { return _image_seq; }
      set { _image_seq = value; }
    }
    private int _result;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int result
    {
      get { return _result; }
      set { _result = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CRegisterCpsdReqProto")]
  public partial class CRegisterCpsdReqProto : global::ProtoBuf.IExtensible
  {
    public CRegisterCpsdReqProto() {}
    
    private uint _seq;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"seq", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint seq
    {
      get { return _seq; }
      set { _seq = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SRegisterCpsdRepProto")]
  public partial class SRegisterCpsdRepProto : global::ProtoBuf.IExtensible
  {
    public SRegisterCpsdRepProto() {}
    
    private uint _result;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint result
    {
      get { return _result; }
      set { _result = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CRegisterClientReqProto")]
  public partial class CRegisterClientReqProto : global::ProtoBuf.IExtensible
  {
    public CRegisterClientReqProto() {}
    
    private uint _seq;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"seq", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint seq
    {
      get { return _seq; }
      set { _seq = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SRegisterClientRepProto")]
  public partial class SRegisterClientRepProto : global::ProtoBuf.IExtensible
  {
    public SRegisterClientRepProto() {}
    
    private uint _result;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint result
    {
      get { return _result; }
      set { _result = value; }
    }
    private int _samples_count;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"samples_count", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int samples_count
    {
      get { return _samples_count; }
      set { _samples_count = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"FValidatePosReqpProto")]
  public partial class FValidatePosReqpProto : global::ProtoBuf.IExtensible
  {
    public FValidatePosReqpProto() {}
    
    private uint _result;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint result
    {
      get { return _result; }
      set { _result = value; }
    }
    private string _image_path;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"image_path", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string image_path
    {
      get { return _image_path; }
      set { _image_path = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CProcessFeatureReqProto")]
  public partial class CProcessFeatureReqProto : global::ProtoBuf.IExtensible
  {
    public CProcessFeatureReqProto() {}
    
    private string _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string id
    {
      get { return _id; }
      set { _id = value; }
    }
    private double _AvgSaturation;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"AvgSaturation", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public double AvgSaturation
    {
      get { return _AvgSaturation; }
      set { _AvgSaturation = value; }
    }
    private double _AvgHue;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"AvgHue", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public double AvgHue
    {
      get { return _AvgHue; }
      set { _AvgHue = value; }
    }
    private double _AvgIntensity;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"AvgIntensity", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public double AvgIntensity
    {
      get { return _AvgIntensity; }
      set { _AvgIntensity = value; }
    }
    private double _DeviationSaturation;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"DeviationSaturation", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public double DeviationSaturation
    {
      get { return _DeviationSaturation; }
      set { _DeviationSaturation = value; }
    }
    private double _DeviationHue;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"DeviationHue", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public double DeviationHue
    {
      get { return _DeviationHue; }
      set { _DeviationHue = value; }
    }
    private double _DeviationIntensity;
    [global::ProtoBuf.ProtoMember(7, IsRequired = true, Name=@"DeviationIntensity", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public double DeviationIntensity
    {
      get { return _DeviationIntensity; }
      set { _DeviationIntensity = value; }
    }
    private double _Length;
    [global::ProtoBuf.ProtoMember(8, IsRequired = true, Name=@"Length", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public double Length
    {
      get { return _Length; }
      set { _Length = value; }
    }
    private double _Width;
    [global::ProtoBuf.ProtoMember(9, IsRequired = true, Name=@"Width", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public double Width
    {
      get { return _Width; }
      set { _Width = value; }
    }
    private double _WidthLengthRatio;
    [global::ProtoBuf.ProtoMember(10, IsRequired = true, Name=@"WidthLengthRatio", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public double WidthLengthRatio
    {
      get { return _WidthLengthRatio; }
      set { _WidthLengthRatio = value; }
    }
    private double _ApexAngle;
    [global::ProtoBuf.ProtoMember(11, IsRequired = true, Name=@"ApexAngle", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public double ApexAngle
    {
      get { return _ApexAngle; }
      set { _ApexAngle = value; }
    }
    private double _Circularity;
    [global::ProtoBuf.ProtoMember(12, IsRequired = true, Name=@"Circularity", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public double Circularity
    {
      get { return _Circularity; }
      set { _Circularity = value; }
    }
    private double _Area;
    [global::ProtoBuf.ProtoMember(13, IsRequired = true, Name=@"Area", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public double Area
    {
      get { return _Area; }
      set { _Area = value; }
    }
    private double _ThickMean;
    [global::ProtoBuf.ProtoMember(14, IsRequired = true, Name=@"ThickMean", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public double ThickMean
    {
      get { return _ThickMean; }
      set { _ThickMean = value; }
    }
    private double _DefectRate;
    [global::ProtoBuf.ProtoMember(15, IsRequired = true, Name=@"DefectRate", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public double DefectRate
    {
      get { return _DefectRate; }
      set { _DefectRate = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SProcessFeatureRepProto")]
  public partial class SProcessFeatureRepProto : global::ProtoBuf.IExtensible
  {
    public SProcessFeatureRepProto() {}
    
    private uint _result;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint result
    {
      get { return _result; }
      set { _result = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SProcessResultProto")]
  public partial class SProcessResultProto : global::ProtoBuf.IExtensible
  {
    public SProcessResultProto() {}
    
    private uint _result;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint result
    {
      get { return _result; }
      set { _result = value; }
    }
    private int _group;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"group", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int group
    {
      get { return _group; }
      set { _group = value; }
    }
    private int _rank;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"rank", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int rank
    {
      get { return _rank; }
      set { _rank = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CSetProcessStateReqProto")]
  public partial class CSetProcessStateReqProto : global::ProtoBuf.IExtensible
  {
    public CSetProcessStateReqProto() {}
    
    private int _state;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"state", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int state
    {
      get { return _state; }
      set { _state = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SSetProcessStateRepProto")]
  public partial class SSetProcessStateRepProto : global::ProtoBuf.IExtensible
  {
    public SSetProcessStateRepProto() {}
    
    private uint _result;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint result
    {
      get { return _result; }
      set { _result = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CEndBatchProcessReqProto")]
  public partial class CEndBatchProcessReqProto : global::ProtoBuf.IExtensible
  {
    public CEndBatchProcessReqProto() {}
    
    private int _state;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"state", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int state
    {
      get { return _state; }
      set { _state = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"LeafGradeCount")]
  public partial class LeafGradeCount : global::ProtoBuf.IExtensible
  {
    public LeafGradeCount() {}
    
    private int _group;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"group", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int group
    {
      get { return _group; }
      set { _group = value; }
    }
    private int _rank;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"rank", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int rank
    {
      get { return _rank; }
      set { _rank = value; }
    }
    private int _count;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"count", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int count
    {
      get { return _count; }
      set { _count = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SEndBatchProcessRepProto")]
  public partial class SEndBatchProcessRepProto : global::ProtoBuf.IExtensible
  {
    public SEndBatchProcessRepProto() {}
    
    private uint _result;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint result
    {
      get { return _result; }
      set { _result = value; }
    }
    private readonly global::System.Collections.Generic.List<LeafGradeCount> _leaf_grade_counts = new global::System.Collections.Generic.List<LeafGradeCount>();
    [global::ProtoBuf.ProtoMember(2, Name=@"leaf_grade_counts", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<LeafGradeCount> leaf_grade_counts
    {
      get { return _leaf_grade_counts; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CLearnSampleReqProto")]
  public partial class CLearnSampleReqProto : global::ProtoBuf.IExtensible
  {
    public CLearnSampleReqProto() {}
    
    private int _group;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"group", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int group
    {
      get { return _group; }
      set { _group = value; }
    }
    private int _rank;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"rank", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int rank
    {
      get { return _rank; }
      set { _rank = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SLearnSampleRepProto")]
  public partial class SLearnSampleRepProto : global::ProtoBuf.IExtensible
  {
    public SLearnSampleRepProto() {}
    
    private uint _result;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint result
    {
      get { return _result; }
      set { _result = value; }
    }
    private int _group;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"group", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int group
    {
      get { return _group; }
      set { _group = value; }
    }
    private int _rank;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"rank", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int rank
    {
      get { return _rank; }
      set { _rank = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}