using System;
using System.Drawing;
using Valsom.AnsiBuilder.Abstractions;
using Valsom.AnsiBuilder.Enums;
using Xunit;

namespace Valsom.AnsiBuilder.Test
{
    public class BuildClean
    {
        [Fact]
        public void BuildsWithoutColor()
        {
            IAnsiStringBuilder builder = new AnsiStringBuilder();

            builder.AddPart("Hello ");
            builder.AddPart("world!");

            Assert.Equal("Hello world!", builder.BuildClean());
        }

        [Fact]
        public void BuildsWithColor()
        {
            IAnsiStringBuilder builder = new AnsiStringBuilder();

            builder.AddPart("I ").With(Color.Red);
            builder.AddPart("am ").WithBackground(Color.Green);
            builder.AddPart("testing").With(AnsiCode.Reverse);

            Assert.Equal("I am testing", builder.BuildClean());
        }

        [Fact]
        public void BuildsWithSpecials()
        {
            IAnsiStringBuilder builder = new AnsiStringBuilder();

            builder.AddPart("Is ").With(AnsiCode.Bold);
            builder.AddPart("this ").With(AnsiCode.Italic);
            builder.AddPart("working?").With(AnsiCode.Underline);

            Assert.Equal("Is this working?", builder.BuildClean());
        }
    }
}
