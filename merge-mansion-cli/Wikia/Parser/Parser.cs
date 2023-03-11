using System;
using System.Collections.Generic;

namespace merge_mansion_cli.Wikia.Parser
{
    class Parser
    {
        private readonly PeekableReader _reader;

        public Parser(string content)
        {
            _reader = new PeekableReader(content);
        }

        public SyntaxNode Parse()
        {
            var result = new SyntaxNode(SyntaxKind.Content);

            var newLine = true;
            var chars = new List<char>();

            var currentChar = _reader.Peek();
            while (currentChar != -1)
            {
                switch (currentChar)
                {
                    case '\n':
                        if (chars.Count > 0)
                            result.Nodes.Add(new SyntaxNode(SyntaxKind.Text, new string(chars.ToArray())));
                        result.Nodes.Add(new SyntaxNode(SyntaxKind.LineBreak, ((char)_reader.Read()).ToString()));

                        chars.Clear();
                        break;

                    case '<':
                        if (chars.Count > 0)
                            result.Nodes.Add(new SyntaxNode(SyntaxKind.Text, new string(chars.ToArray())));
                        result.Nodes.Add(ParseTag());

                        chars.Clear();
                        break;

                    default:
                        chars.Add((char)_reader.Read());
                        break;
                }

                newLine = currentChar == '\n';
                currentChar = _reader.Peek();
            }

            if (chars.Count > 0)
                result.Nodes.Add(new SyntaxNode(SyntaxKind.Text, new string(chars.ToArray())));

            return result;
        }

        private SyntaxNode ParseTag()
        {
            if (_reader.Peek() != '<')
                throw new InvalidOperationException("Trying to parse tag without a starting '<'.");

            var chars = new List<char>();

            var charIndex = 1;
            var peekedChar = _reader.Peek(charIndex++);
            while (peekedChar != '<' && peekedChar != '>' && peekedChar != -1 && peekedChar != '\n')
            {
                chars.Add((char)peekedChar);
                peekedChar = _reader.Peek(charIndex++);
            }

            if (peekedChar == '>')
            {
                // If tag properly closes
                var result = new SyntaxNode(SyntaxKind.Tag);

                result.Nodes.Add(new SyntaxNode(SyntaxKind.SmallerThan, "<"));
                result.Nodes.Add(new SyntaxNode(SyntaxKind.Text, new string(chars.ToArray())));
                result.Nodes.Add(new SyntaxNode(SyntaxKind.GreaterThan, ">"));

                _reader.Skip(charIndex);

                return result;
            }

            // If tag doesn't properly close
            _reader.Skip(1);
            return new SyntaxNode(SyntaxKind.SmallerThan, "<");
        }
    }

    class SyntaxNode
    {
        public SyntaxKind Kind { get; }
        public string Text { get; set; }

        public List<SyntaxNode> Nodes { get; } = new List<SyntaxNode>();

        public SyntaxNode(SyntaxKind kind, string text = null)
        {
            Kind = kind;
            Text = text ?? string.Empty;
        }
    }

    enum SyntaxKind
    {
        Content,

        Text,
        FormattedText,
        ItalicStart,
        ItalicEnd,
        BoldStart,
        BoldEnd,

        Tag,
        GreaterThan,
        SmallerThan,

        LineBreak,

        Indent
    }
}
