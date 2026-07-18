using Decoder = OldPhonePad.Core.OldPhonePad;
using Xunit;

namespace OldPhonePad.Tests;

public class OldPhonePadTests
{
    [Fact]
    public void Decode_ShouldReturnE_For33()
    {
        Assert.Equal("E", Decoder.Decode("33#"));
    }

    [Fact]
    public void Decode_ShouldReturnB_For227Backspace()
    {
        Assert.Equal("B", Decoder.Decode("227*#"));
    }

    [Fact]
    public void Decode_ShouldReturnHello()
    {
        Assert.Equal("HELLO", Decoder.Decode("4433555 555666#"));
    }

    [Fact]
    public void Decode_ShouldWrapAroundKey2()
    {
        Assert.Equal("A", Decoder.Decode("2222#"));
    }

    [Fact]
    public void Decode_ShouldWrapAroundKey3()
    {
        Assert.Equal("F", Decoder.Decode("333333#"));
    }

    [Fact]
    public void Decode_ShouldReturnEmptyString_WhenInputIsOnlySendKey()
    {
        Assert.Equal(string.Empty, Decoder.Decode("#"));
    }

    [Fact]
    public void Decode_ShouldReturnEmptyString_WhenInputContainsOnlyBackspaces()
    {
        Assert.Equal(string.Empty, Decoder.Decode("****#"));
    }

    [Fact]
    public void Decode_ShouldIgnoreBackspacesBeyondBeginning()
    {
        Assert.Equal(string.Empty, Decoder.Decode("***2***#"));
    }

    [Fact]
    public void Decode_ShouldIgnoreMultiplePauses()
    {
        Assert.Equal("HE", Decoder.Decode("44  33#"));
    }

    [Fact]
    public void Decode_ShouldReturnAB_ForSeparatedKeys()
    {
        Assert.Equal("AB", Decoder.Decode("2 22#"));
    }

    [Fact]
    public void Decode_ShouldThrowArgumentNullException_WhenInputIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => Decoder.Decode(null!));
    }

    [Fact]
    public void Decode_ShouldThrowArgumentException_WhenInputDoesNotEndWithHash()
    {
        Assert.Throws<ArgumentException>(() => Decoder.Decode("33"));
    }

    [Fact]
    public void Decode_ShouldThrowArgumentException_WhenCharactersExistAfterSendKey()
    {
        Assert.Throws<ArgumentException>(() => Decoder.Decode("33#22"));
    }

    [Fact]
    public void Decode_ShouldThrowArgumentException_WhenInputContainsInvalidCharacter()
    {
        Assert.Throws<ArgumentException>(() => Decoder.Decode("22A#"));
    }
}