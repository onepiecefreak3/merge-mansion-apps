namespace merge_mansion_cli.Models.Wikia
{
    internal class WikiaText
    {
        private readonly string _text;
        private readonly WikiaText _wikiaText;

        public bool IsBold { get; }
        public bool IsItalic { get; }

        private WikiaText(string text)
        {
            _text = text;
        }

        private WikiaText(WikiaText text, bool isBold, bool isItalic)
        {
            _wikiaText = text;
            IsBold = isBold;
            IsItalic = isItalic;
        }

        private WikiaText(string text, bool isBold, bool isItalic)
        {
            _text = text;
            IsBold = isBold;
            IsItalic = isItalic;
        }

        public static WikiaText CreateBold(string text) => new WikiaText(text, true, false);
        public static WikiaText CreateBold(WikiaText text) => new WikiaText(text, true, false);

        public static WikiaText CreateItalic(string text) => new WikiaText(text, false, true);
        public static WikiaText CreateItalic(WikiaText text) => new WikiaText(text, false, true);

        public static implicit operator WikiaText(string s) => new WikiaText(s);

        public override string ToString()
        {
            if (IsItalic)
                return $"''{GetText()}''";

            if (IsBold)
                return $"'''{GetText()}'''";

            return GetText();
        }

        private string GetText()
        {
            return _text ?? _wikiaText.ToString();
        }
    }
}
