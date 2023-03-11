using System;
using System.Collections.Generic;
using System.IO;

namespace merge_mansion_cli.Wikia.Parser
{
    class PeekableReader
    {
        private readonly TextReader _reader;
        private readonly IDictionary<int, int> _peekedChars;

        private int _currentPosition;

        public PeekableReader(string text) : this(new StringReader(text))
        { }

        public PeekableReader(TextReader reader)
        {
            _reader = reader;
            _peekedChars = new Dictionary<int, int>();
        }

        public int Peek(int position = 0)
        {
            if (position < 0)
                throw new ArgumentOutOfRangeException(nameof(position));

            if (_peekedChars.ContainsKey(_currentPosition + position))
                return _peekedChars[_currentPosition + position];

            var currentPosition = _currentPosition;
            for (var i = currentPosition; i <= currentPosition + position; i++)
                _peekedChars[i] = Read();
            _currentPosition -= position + 1;

            return _peekedChars[_currentPosition + position];
        }

        public int Read()
        {
            if (_peekedChars.ContainsKey(_currentPosition))
            {
                var nextNode = _peekedChars[_currentPosition];
                _peekedChars.Remove(_currentPosition);

                _currentPosition++;
                return nextNode;
            }

            _currentPosition++;
            return _reader.Read();
        }

        public void Skip(int length)
        {
            for (var i = 0; i < length; i++)
                Read();
        }
    }
}
