using Microsoft.VisualStudio.TestTools.UnitTesting;
using RtfPipe.Tokens;

namespace RtfPipe.Tests;

[TestClass]
public class ControlTagTests
{
  [TestMethod]
  public void Negate_PreservesConcreteType_AndFlipsValue()
  {
    AssertNegated(new IsBold(true));
    AssertNegated(new IsAllCaps(false));
    AssertNegated(new IsEmbossed(true));
    AssertNegated(new IsEngraved(false));
    AssertNegated(new IsItalic(true));
    AssertNegated(new IsHidden(false));
    AssertNegated(new IsOutlined(true));
    AssertNegated(new IsShadow(false));
    AssertNegated(new IsSmallCaps(true));
    AssertNegated(new IsDoubleStrike(false));
    AssertNegated(new IsStrikethrough(true));
    AssertNegated(new IsUnderline(false));
    AssertNegated(new HtmlRtf(true));
    AssertNegated(new FromHtml(false));
    AssertNegated(new RowAutoFit(true));
  }

  private static void AssertNegated(ControlWord<bool> word)
  {
    var negated = ControlTag.Negate(word);

    Assert.AreEqual(word.GetType(), negated.GetType());
    Assert.AreEqual(!word.Value, negated.Value);
  }
}
