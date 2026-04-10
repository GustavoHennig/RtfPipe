using System;
using System.Text;
using RtfPipe.Tokens;

namespace RtfPipe
{
  public abstract class ControlTag : IEquatable<ControlTag>, IWord
  {
    public abstract string Name { get; }
    public virtual TokenType Type => TokenType.Word;

    public override bool Equals(object obj)
    {
      if (obj is ControlTag tag)
        return Equals(tag);
      return false;
    }

    public bool Equals(ControlTag other)
    {
      if (other == null)
        return false;
      return this.Name == other.Name;
    }

    public override int GetHashCode()
    {
      return GetType().GetHashCode()
        .AddHashCode(Name);
    }

    public override string ToString()
    {
      return "\\" + Name;
    }

    public static ControlWord<bool> Negate(ControlWord<bool> word)
    {
      var value = !word.Value;
      return word switch
      {
        IsBold _ => new IsBold(value),
        IsAllCaps _ => new IsAllCaps(value),
        IsEmbossed _ => new IsEmbossed(value),
        IsEngraved _ => new IsEngraved(value),
        IsItalic _ => new IsItalic(value),
        IsHidden _ => new IsHidden(value),
        IsOutlined _ => new IsOutlined(value),
        IsShadow _ => new IsShadow(value),
        IsSmallCaps _ => new IsSmallCaps(value),
        IsDoubleStrike _ => new IsDoubleStrike(value),
        IsStrikethrough _ => new IsStrikethrough(value),
        IsUnderline _ => new IsUnderline(value),
        HtmlRtf _ => new HtmlRtf(value),
        FromHtml _ => new FromHtml(value),
        RowAutoFit _ => new RowAutoFit(value),
        _ => throw new NotSupportedException($"Unsupported negatable control word type '{word.GetType().FullName}'.")
      };
    }
  }
}
