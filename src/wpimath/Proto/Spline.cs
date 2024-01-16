// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: spline.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace WPIMath.Proto {

  /// <summary>Holder for reflection information generated from spline.proto</summary>
  public static partial class SplineReflection {

    #region Descriptor
    /// <summary>File descriptor for spline.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static SplineReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CgxzcGxpbmUucHJvdG8SCXdwaS5wcm90byJkChpQcm90b2J1ZkN1YmljSGVy",
            "bWl0ZVNwbGluZRIRCgl4X2luaXRpYWwYASADKAESDwoHeF9maW5hbBgCIAMo",
            "ARIRCgl5X2luaXRpYWwYAyADKAESDwoHeV9maW5hbBgEIAMoASJmChxQcm90",
            "b2J1ZlF1aW50aWNIZXJtaXRlU3BsaW5lEhEKCXhfaW5pdGlhbBgBIAMoARIP",
            "Cgd4X2ZpbmFsGAIgAygBEhEKCXlfaW5pdGlhbBgDIAMoARIPCgd5X2ZpbmFs",
            "GAQgAygBQioKGGVkdS53cGkuZmlyc3QubWF0aC5wcm90b6oCDVdQSU1hdGgu",
            "UHJvdG9iBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::WPIMath.Proto.ProtobufCubicHermiteSpline), global::WPIMath.Proto.ProtobufCubicHermiteSpline.Parser, new[]{ "XInitial", "XFinal", "YInitial", "YFinal" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::WPIMath.Proto.ProtobufQuinticHermiteSpline), global::WPIMath.Proto.ProtobufQuinticHermiteSpline.Parser, new[]{ "XInitial", "XFinal", "YInitial", "YFinal" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class ProtobufCubicHermiteSpline : pb::IMessage<ProtobufCubicHermiteSpline>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<ProtobufCubicHermiteSpline> _parser = new pb::MessageParser<ProtobufCubicHermiteSpline>(() => new ProtobufCubicHermiteSpline());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<ProtobufCubicHermiteSpline> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::WPIMath.Proto.SplineReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ProtobufCubicHermiteSpline() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ProtobufCubicHermiteSpline(ProtobufCubicHermiteSpline other) : this() {
      xInitial_ = other.xInitial_.Clone();
      xFinal_ = other.xFinal_.Clone();
      yInitial_ = other.yInitial_.Clone();
      yFinal_ = other.yFinal_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ProtobufCubicHermiteSpline Clone() {
      return new ProtobufCubicHermiteSpline(this);
    }

    /// <summary>Field number for the "x_initial" field.</summary>
    public const int XInitialFieldNumber = 1;
    private static readonly pb::FieldCodec<double> _repeated_xInitial_codec
        = pb::FieldCodec.ForDouble(10);
    private readonly pbc::RepeatedField<double> xInitial_ = new pbc::RepeatedField<double>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<double> XInitial {
      get { return xInitial_; }
    }

    /// <summary>Field number for the "x_final" field.</summary>
    public const int XFinalFieldNumber = 2;
    private static readonly pb::FieldCodec<double> _repeated_xFinal_codec
        = pb::FieldCodec.ForDouble(18);
    private readonly pbc::RepeatedField<double> xFinal_ = new pbc::RepeatedField<double>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<double> XFinal {
      get { return xFinal_; }
    }

    /// <summary>Field number for the "y_initial" field.</summary>
    public const int YInitialFieldNumber = 3;
    private static readonly pb::FieldCodec<double> _repeated_yInitial_codec
        = pb::FieldCodec.ForDouble(26);
    private readonly pbc::RepeatedField<double> yInitial_ = new pbc::RepeatedField<double>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<double> YInitial {
      get { return yInitial_; }
    }

    /// <summary>Field number for the "y_final" field.</summary>
    public const int YFinalFieldNumber = 4;
    private static readonly pb::FieldCodec<double> _repeated_yFinal_codec
        = pb::FieldCodec.ForDouble(34);
    private readonly pbc::RepeatedField<double> yFinal_ = new pbc::RepeatedField<double>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<double> YFinal {
      get { return yFinal_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as ProtobufCubicHermiteSpline);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(ProtobufCubicHermiteSpline other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!xInitial_.Equals(other.xInitial_)) return false;
      if(!xFinal_.Equals(other.xFinal_)) return false;
      if(!yInitial_.Equals(other.yInitial_)) return false;
      if(!yFinal_.Equals(other.yFinal_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= xInitial_.GetHashCode();
      hash ^= xFinal_.GetHashCode();
      hash ^= yInitial_.GetHashCode();
      hash ^= yFinal_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      xInitial_.WriteTo(output, _repeated_xInitial_codec);
      xFinal_.WriteTo(output, _repeated_xFinal_codec);
      yInitial_.WriteTo(output, _repeated_yInitial_codec);
      yFinal_.WriteTo(output, _repeated_yFinal_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      xInitial_.WriteTo(ref output, _repeated_xInitial_codec);
      xFinal_.WriteTo(ref output, _repeated_xFinal_codec);
      yInitial_.WriteTo(ref output, _repeated_yInitial_codec);
      yFinal_.WriteTo(ref output, _repeated_yFinal_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      size += xInitial_.CalculateSize(_repeated_xInitial_codec);
      size += xFinal_.CalculateSize(_repeated_xFinal_codec);
      size += yInitial_.CalculateSize(_repeated_yInitial_codec);
      size += yFinal_.CalculateSize(_repeated_yFinal_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(ProtobufCubicHermiteSpline other) {
      if (other == null) {
        return;
      }
      xInitial_.Add(other.xInitial_);
      xFinal_.Add(other.xFinal_);
      yInitial_.Add(other.yInitial_);
      yFinal_.Add(other.yFinal_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10:
          case 9: {
            xInitial_.AddEntriesFrom(input, _repeated_xInitial_codec);
            break;
          }
          case 18:
          case 17: {
            xFinal_.AddEntriesFrom(input, _repeated_xFinal_codec);
            break;
          }
          case 26:
          case 25: {
            yInitial_.AddEntriesFrom(input, _repeated_yInitial_codec);
            break;
          }
          case 34:
          case 33: {
            yFinal_.AddEntriesFrom(input, _repeated_yFinal_codec);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10:
          case 9: {
            xInitial_.AddEntriesFrom(ref input, _repeated_xInitial_codec);
            break;
          }
          case 18:
          case 17: {
            xFinal_.AddEntriesFrom(ref input, _repeated_xFinal_codec);
            break;
          }
          case 26:
          case 25: {
            yInitial_.AddEntriesFrom(ref input, _repeated_yInitial_codec);
            break;
          }
          case 34:
          case 33: {
            yFinal_.AddEntriesFrom(ref input, _repeated_yFinal_codec);
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class ProtobufQuinticHermiteSpline : pb::IMessage<ProtobufQuinticHermiteSpline>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<ProtobufQuinticHermiteSpline> _parser = new pb::MessageParser<ProtobufQuinticHermiteSpline>(() => new ProtobufQuinticHermiteSpline());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<ProtobufQuinticHermiteSpline> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::WPIMath.Proto.SplineReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ProtobufQuinticHermiteSpline() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ProtobufQuinticHermiteSpline(ProtobufQuinticHermiteSpline other) : this() {
      xInitial_ = other.xInitial_.Clone();
      xFinal_ = other.xFinal_.Clone();
      yInitial_ = other.yInitial_.Clone();
      yFinal_ = other.yFinal_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ProtobufQuinticHermiteSpline Clone() {
      return new ProtobufQuinticHermiteSpline(this);
    }

    /// <summary>Field number for the "x_initial" field.</summary>
    public const int XInitialFieldNumber = 1;
    private static readonly pb::FieldCodec<double> _repeated_xInitial_codec
        = pb::FieldCodec.ForDouble(10);
    private readonly pbc::RepeatedField<double> xInitial_ = new pbc::RepeatedField<double>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<double> XInitial {
      get { return xInitial_; }
    }

    /// <summary>Field number for the "x_final" field.</summary>
    public const int XFinalFieldNumber = 2;
    private static readonly pb::FieldCodec<double> _repeated_xFinal_codec
        = pb::FieldCodec.ForDouble(18);
    private readonly pbc::RepeatedField<double> xFinal_ = new pbc::RepeatedField<double>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<double> XFinal {
      get { return xFinal_; }
    }

    /// <summary>Field number for the "y_initial" field.</summary>
    public const int YInitialFieldNumber = 3;
    private static readonly pb::FieldCodec<double> _repeated_yInitial_codec
        = pb::FieldCodec.ForDouble(26);
    private readonly pbc::RepeatedField<double> yInitial_ = new pbc::RepeatedField<double>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<double> YInitial {
      get { return yInitial_; }
    }

    /// <summary>Field number for the "y_final" field.</summary>
    public const int YFinalFieldNumber = 4;
    private static readonly pb::FieldCodec<double> _repeated_yFinal_codec
        = pb::FieldCodec.ForDouble(34);
    private readonly pbc::RepeatedField<double> yFinal_ = new pbc::RepeatedField<double>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<double> YFinal {
      get { return yFinal_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as ProtobufQuinticHermiteSpline);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(ProtobufQuinticHermiteSpline other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!xInitial_.Equals(other.xInitial_)) return false;
      if(!xFinal_.Equals(other.xFinal_)) return false;
      if(!yInitial_.Equals(other.yInitial_)) return false;
      if(!yFinal_.Equals(other.yFinal_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= xInitial_.GetHashCode();
      hash ^= xFinal_.GetHashCode();
      hash ^= yInitial_.GetHashCode();
      hash ^= yFinal_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      xInitial_.WriteTo(output, _repeated_xInitial_codec);
      xFinal_.WriteTo(output, _repeated_xFinal_codec);
      yInitial_.WriteTo(output, _repeated_yInitial_codec);
      yFinal_.WriteTo(output, _repeated_yFinal_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      xInitial_.WriteTo(ref output, _repeated_xInitial_codec);
      xFinal_.WriteTo(ref output, _repeated_xFinal_codec);
      yInitial_.WriteTo(ref output, _repeated_yInitial_codec);
      yFinal_.WriteTo(ref output, _repeated_yFinal_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      size += xInitial_.CalculateSize(_repeated_xInitial_codec);
      size += xFinal_.CalculateSize(_repeated_xFinal_codec);
      size += yInitial_.CalculateSize(_repeated_yInitial_codec);
      size += yFinal_.CalculateSize(_repeated_yFinal_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(ProtobufQuinticHermiteSpline other) {
      if (other == null) {
        return;
      }
      xInitial_.Add(other.xInitial_);
      xFinal_.Add(other.xFinal_);
      yInitial_.Add(other.yInitial_);
      yFinal_.Add(other.yFinal_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10:
          case 9: {
            xInitial_.AddEntriesFrom(input, _repeated_xInitial_codec);
            break;
          }
          case 18:
          case 17: {
            xFinal_.AddEntriesFrom(input, _repeated_xFinal_codec);
            break;
          }
          case 26:
          case 25: {
            yInitial_.AddEntriesFrom(input, _repeated_yInitial_codec);
            break;
          }
          case 34:
          case 33: {
            yFinal_.AddEntriesFrom(input, _repeated_yFinal_codec);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10:
          case 9: {
            xInitial_.AddEntriesFrom(ref input, _repeated_xInitial_codec);
            break;
          }
          case 18:
          case 17: {
            xFinal_.AddEntriesFrom(ref input, _repeated_xFinal_codec);
            break;
          }
          case 26:
          case 25: {
            yInitial_.AddEntriesFrom(ref input, _repeated_yInitial_codec);
            break;
          }
          case 34:
          case 33: {
            yFinal_.AddEntriesFrom(ref input, _repeated_yFinal_codec);
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
