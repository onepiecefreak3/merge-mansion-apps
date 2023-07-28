using System;
using System.Text.RegularExpressions;

namespace Metaplay.Core
{
    public class ConfigLexer
    {
        // 0x0
        //private static readonly ConfigLexer.TokenSpec[] s_tokenSpecs;

        // 0x10
        public readonly string Input;

        // 0x18
        public int Offset { get; set; }
        // 0x1C
        public Token CurrentToken { get; set; }

        public bool IsAtEnd => CurrentToken.Type == TokenType.EndOfInput;

        public ConfigLexer()
        {
            CurrentToken = default;
            Input = string.Empty;

            Advance();
        }

        public ConfigLexer(string input)
        {
            CurrentToken = default;
            Input = input;

            Advance();
        }

        public ConfigLexer(ConfigLexer other)
        {
            Input = other.Input;
            Offset = other.Offset;
            CurrentToken = other.CurrentToken;
        }

        public void Advance()
        {
            if (Input == null)
                throw new ArgumentNullException(nameof(Input));

            var token = Offset == Input.Length ? new Token(TokenType.EndOfInput, Offset, 0) : ParseToken();
            CurrentToken = token;
        }

        private Token ParseToken()
        {
            // TODO: Implement
            throw new NotSupportedException();
        }

        //// RVA: 0x1D56258 Offset: 0x1D56258 VA: 0x1D56258
        //private bool IsWhitespace(char c) { }

        //// RVA: 0x1D56304 Offset: 0x1D56304 VA: 0x1D56304
        //public void ExpectToken(ConfigLexer.TokenType expectedTokenType) { }

        //// RVA: 0x1D563C8 Offset: 0x1D563C8 VA: 0x1D563C8
        //public ConfigLexer.Token ParseToken(ConfigLexer.TokenType expectedTokenType) { }

        //// RVA: 0x1D563FC Offset: 0x1D563FC VA: 0x1D563FC
        //public string TryParseCustomToken(ConfigLexer.CustomTokenSpec spec) { }

        //// RVA: 0x1D52594 Offset: 0x1D52594 VA: 0x1D52594
        //public string ParseCustomToken(ConfigLexer.CustomTokenSpec spec) { }

        //// RVA: 0x1D5659C Offset: 0x1D5659C VA: 0x1D5659C
        //public string GetTokenString(ConfigLexer.Token token) { }

        //// RVA: 0x1D565BC Offset: 0x1D565BC VA: 0x1D565BC
        //public string ParseIdentifier() { }

        //// RVA: 0x1D565F8 Offset: 0x1D565F8 VA: 0x1D565F8
        //private char ConvertQuotedChar(char c) { }

        //// RVA: 0x1D566CC Offset: 0x1D566CC VA: 0x1D566CC
        //public string ParseQuotedString(string quoted) { }

        //// RVA: 0x1D567C4 Offset: 0x1D567C4 VA: 0x1D567C4
        //public char ParseQuotedChar(string quoted) { }

        //// RVA: 0x1D56858 Offset: 0x1D56858 VA: 0x1D56858
        //public string ParseStringLiteral() { }

        //// RVA: 0x1D5689C Offset: 0x1D5689C VA: 0x1D5689C
        //public string ParseIdentifierOrString() { }

        //// RVA: 0x1D56944 Offset: 0x1D56944 VA: 0x1D56944
        //public bool ParseBooleanLiteral() { }

        //// RVA: 0x1D569C4 Offset: 0x1D569C4 VA: 0x1D569C4
        //public char ParseCharLiteral() { }

        //// RVA: 0x1D56B24 Offset: 0x1D56B24 VA: 0x1D56B24
        //public int ParseIntegerLiteral() { }

        // RVA: 0x1D56BC4 Offset: 0x1D56BC4 VA: 0x1D56BC4
        public long ParseLongLiteral()
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        //// RVA: 0x1D56C64 Offset: 0x1D56C64 VA: 0x1D56C64
        //public float ParseFloatLiteral() { }

        //// RVA: 0x1D56DA8 Offset: 0x1D56DA8 VA: 0x1D56DA8
        //public double ParseDoubleLiteral() { }

        // RVA: 0x1D564E8 Offset: 0x1D564E8 VA: 0x1D564E8
        public string GetRemainingInputInfo()
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        public bool TryParseToken(TokenType tokenType)
        {
            var isEqual = CurrentToken.Type == tokenType;
            if (isEqual)
                Advance();

            return isEqual;
        }

        public struct Token
        {
            public TokenType Type; // 0x0
            public int StartOffset; // 0x4
            public int Length; // 0x8

            public Token(TokenType type, int startOffset, int length)
            {
                Type = type;
                StartOffset = startOffset;
                Length = length;
            }
        }

        public enum TokenType
        {
            Invalid = 0,
            EndOfInput = 1,
            IntegerLiteral = 2,
            FloatLiteral = 3,
            BooleanLiteral = 4,
            StringLiteral = 5,
            CharLiteral = 6,
            Identifier = 7,
            EqualEqual = 8,
            NotEqual = 9,
            GreaterOrEqual = 10,
            LessOrEqual = 11,
            GreaterThan = 12,
            LessThan = 13,
            Comma = 14,
            Dot = 15,
            ForwardSlash = 16,
            LeftParenthesis = 17,
            RightParenthesis = 18,
            LeftBracket = 19,
            RightBracket = 20,
            LeftBrace = 21,
            RightBrace = 22,
            Colon = 23
        }

        public class CustomTokenSpec
        {
            // 0x10
            private Regex _regex;

            // 0x18
            public string Name { get; set; }

            public CustomTokenSpec(string regex, string name)
            {
                _regex = new Regex("\\G" + regex);
                Name = name;
            }

            public bool TryMatch(string input, int offset, out int length)
            {
                var match = _regex.Match(input, offset);

                length = !match.Success ? 0 : match.Length;
                return match.Success;
            }
        }
    }
}
