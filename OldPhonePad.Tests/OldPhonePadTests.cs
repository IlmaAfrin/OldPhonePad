using Decoder = OldPhonePad.Core.OldPhonePad;
using Xunit;

namespace OldPhonePad.Tests;

public class OldPhonePadTests
{
    [Fact]
    public void Decode_ShouldReturnE_For33()
    {
        string result = Decoder.Decode("33#");

        Assert.Equal("E", result);
    }

    [Fact]
    public void Decode_ShouldReturnB_For227Backspace()
    {
        string result = Decoder.Decode("227*#");

        Assert.Equal("B", result);
    }

    [Fact]
    public void Decode_ShouldReturnHello()
    {
        string result = Decoder.Decode("4433555 555666#");

        Assert.Equal("HELLO", result);
    }
}