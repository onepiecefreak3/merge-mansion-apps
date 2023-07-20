using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using merge_mansion_dumper.Dumper.Base;
using Metaplay;
using Metaplay.GameLogic.Area;
using Metaplay.GameLogic.Config;
using Metaplay.GameLogic.Player.Director.Config;
using Metaplay.GameLogic.Story;
using Metaplay.Metaplay.Unity.ConnectionStates;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace merge_mansion_dumper.Dumper
{
    class DialogDumper : ImageDumper
    {
        private const string BoxResource_ = "merge_mansion_dumper.Resources.Dialogue.dialogue_box.png";
        private const string BannerResource_ = "merge_mansion_dumper.Resources.Dialogue.dialogue_banner.png";
        private const string FontResource_ = "merge_mansion_dumper.Resources.Fonts.tisa_sans.ttf";
        private const string PeopleResource_ = "merge_mansion_dumper.Resources.Dialogue.People.{0}{1}.png";
        private const string DialogTitle_ = "Dialog_Title_{0}";

        private const int BannerXDelta_ = 47;
        private const int CharacterXDelta_ = 29;

        private static readonly Color NameColor = Color.FromRgb(0xfd, 0xf4, 0xe3);
        private static readonly Color NameBorderColor = Color.FromRgba(0x22, 0x22, 0x22, 0x90);
        private static readonly Color DialogColor = Color.FromRgb(0x97, 0x66, 0x38);

        private readonly Image<Rgba32> _boxImg;
        private readonly Image<Rgba32> _bannerImg;
        private readonly Font _nameFont;
        private readonly Font _dialogFont;

        public DialogDumper()
        {
            _boxImg = LoadImageFromResource(BoxResource_);
            _bannerImg = LoadImageFromResource(BannerResource_);

            var family = new FontCollection().Add(Assembly.GetExecutingAssembly().GetManifestResourceStream(FontResource_));
            _nameFont = family.CreateFont(35, FontStyle.Bold);
            _dialogFont = family.CreateFont(28);
        }

        public override IEnumerable<(string, Image<Rgba32>)> Dump(SharedGameConfig config)
        {
            foreach (var area in config.Areas.EnumerateAll())
                foreach (var hotspot in ((AreaInfo)area.Value).HotspotsRefs)
                {
                    var actions = hotspot.Ref.CompletionActions.OfType<TriggerDialogue>().Select(x => ("Completion", x));
                    actions = actions.Concat(hotspot.Ref.AppearActions.OfType<TriggerDialogue>().Select(x => ("Appear", x)));
                    actions = actions.Concat(hotspot.Ref.FinalizationActions.OfType<TriggerDialogue>().Select(x => ("Finalization", x)));

                    foreach (var dialogueAction in actions)
                    {
                        var leftChar = DialogCharacterType.None;
                        var leftMood = DialogCharacterState.Default;
                        var rightChar = DialogCharacterType.None;
                        var rightMood = DialogCharacterState.Default;

                        var storyElement = config.StoryElements.GetInfoByKey(dialogueAction.x.DialogueId);
                        if (storyElement == null)
                        {
                            Output.Warning("Unknown dialog {0} for action {1} on hotspot {2}.", dialogueAction.x.DialogueId, dialogueAction.Item1, hotspot.KeyObject);
                            continue;
                        }

                        foreach (var dialog in ((StoryElementInfo)config.StoryElements.GetInfoByKey(dialogueAction.x.DialogueId)).DialogItems.Select(x => x.Value))
                        {
                            var dialogImg = CreateImage(dialog.Ref, leftChar, rightChar, leftMood, rightMood);
                            if (dialogImg != null)
                            {
                                yield return (Path.Combine(((AreaId)area.Key).Value, hotspot.Ref.Id.ToString(), dialogueAction.Item1, dialog.Ref.ConfigKey.Value), dialogImg);
                                dialogImg.Dispose();
                            }

                            // Update speakers for every dialog item, even when they have no dialogue
                            leftChar = dialog.Ref.LeftCharacter == DialogCharacterType.NoChange ? leftChar : dialog.Ref.LeftCharacter;
                            leftMood = dialog.Ref.LeftCharacterState == DialogCharacterState.NoChange ? leftMood : dialog.Ref.LeftCharacterState;
                            rightChar = dialog.Ref.RightCharacter == DialogCharacterType.NoChange ? rightChar : dialog.Ref.RightCharacter;
                            rightMood = dialog.Ref.RightCharacterState == DialogCharacterState.NoChange ? rightMood : dialog.Ref.RightCharacterState;
                        }
                    }
                }
        }

        private Image<Rgba32> CreateImage(DialogItemInfo dialog, DialogCharacterType prevLeftType, DialogCharacterType prevRightType, DialogCharacterState prevLeftMood, DialogCharacterState prevRightMood)
        {
            if (string.IsNullOrEmpty(dialog.LocalizationId))
                return null;

            // Define people sizes
            var defaultSize = new Size(256, 256);   // * 1
            var bigSize = new Size(281, 281);       // * 1.1
            var smallSize = new Size(212, 212);     // * 0.83

            // Create new image
            var aboveBox = bigSize.Height - 19;
            var res = new Image<Rgba32>(_boxImg.Width, _boxImg.Height + aboveBox);

            // Draw speakers
            var leftCharacter = dialog.LeftCharacter == DialogCharacterType.NoChange ? prevLeftType : dialog.LeftCharacter;
            var leftMood = dialog.LeftCharacterState == DialogCharacterState.NoChange ? prevLeftMood : dialog.LeftCharacterState;
            if (leftCharacter != DialogCharacterType.None)
            {
                if (Enum.IsDefined(leftCharacter))
                {
                    if (!ExistsPeopleResource(leftCharacter, leftMood))
                    {
                        Output.Warning("Unknown asset for character {0} with mood {1}", GetCharacterResourceName(leftCharacter), leftMood);
                        leftMood = DialogCharacterState.Default;
                    }

                    var resizeSize = dialog.LeftSpeaks ? bigSize : smallSize;
                    var leftImg = LoadImageFromResource(GetCharacterResourcePath(leftCharacter, leftMood));
                    if (leftImg != null)
                    {
                        leftImg.Mutate(x => x.Resize(resizeSize));

                        res.Mutate(x => x.DrawImage(leftImg, new Point(CharacterXDelta_ + (defaultSize.Width - resizeSize.Width) / 2, bigSize.Height - resizeSize.Height), 1));
                    }
                }
                else
                    Output.Warning("Unknown dialogue character {0}", leftCharacter);
            }

            var rightCharacter = dialog.RightCharacter == DialogCharacterType.NoChange ? prevRightType : dialog.RightCharacter;
            var rightMood = dialog.RightCharacterState == DialogCharacterState.NoChange ? prevRightMood : dialog.RightCharacterState;
            if (rightCharacter != DialogCharacterType.None)
            {
                if (Enum.IsDefined(rightCharacter))
                {
                    if (!ExistsPeopleResource(rightCharacter, rightMood))
                    {
                        Output.Warning("Unknown asset for character {0} with mood {1}", GetCharacterResourceName(rightCharacter), rightMood);
                        rightMood = DialogCharacterState.Default;
                    }

                    var resizeSize = dialog.RightSpeaks ? bigSize : smallSize;
                    var rightImg = LoadImageFromResource(GetCharacterResourcePath(rightCharacter, rightMood));
                    if (rightImg != null)
                    {
                        rightImg.Mutate(x => x.Flip(FlipMode.Horizontal).Resize(resizeSize));

                        res.Mutate(x => x.DrawImage(rightImg, new Point(res.Width - CharacterXDelta_ - defaultSize.Width + (defaultSize.Width - resizeSize.Width) / 2, bigSize.Height - resizeSize.Height), 1));
                    }
                }
                else
                    Output.Warning("Unknown dialogue character {0}", rightCharacter);
            }

            // Draw box
            res.Mutate(x => x.DrawImage(_boxImg, new Point(0, aboveBox), 1));

            // Draw name banner
            var bannerPos = dialog.LeftSpeaks ? new Point(BannerXDelta_, aboveBox - 14) : new Point(res.Width - _bannerImg.Width - BannerXDelta_, aboveBox - 14);
            res.Mutate(x => x.DrawImage(_bannerImg, bannerPos, 1));

            // Draw name text
            var activeSpeaker = dialog.LeftSpeaks ? leftCharacter : rightCharacter;
            if (Enum.IsDefined(activeSpeaker))
            {
                var name = GetSpeakerName(activeSpeaker);
                var nameSize = TextMeasurer.Measure(name, new TextOptions(_nameFont));
                var namePoint = bannerPos + new PointF((_bannerImg.Width - nameSize.Width) / 2, 0);

                res.Mutate(x => x.DrawText(name, _nameFont, Brushes.Solid(NameColor), Pens.Solid(NameBorderColor, 1.6f), namePoint));
            }

            // Draw dialog text
            var wrappedText = WrapText(LocMan.Get(dialog.LocalizationId), 750, _dialogFont);
            var wrappedTextSizes = wrappedText.Select(x => TextMeasurer.Measure(x, new TextOptions(_dialogFont))).ToArray();

            var lineHeight = wrappedTextSizes.Max(x => x.Height);
            var lineY = aboveBox - 14 + (_boxImg.Height - wrappedTextSizes.Length * lineHeight) / 2;

            var linePoints = wrappedTextSizes.Select((x, i) => new PointF((_boxImg.Width - x.Width) / 2, lineY + i * lineHeight)).ToArray();
            for (var i = 0; i < linePoints.Length; i++)
                res.Mutate(x => x.DrawText(wrappedText[i], _dialogFont, DialogColor, linePoints[i]));

            return res;
        }

        private IList<string> WrapText(string text, int width, Font font)
        {
            var textOptions = new TextOptions(font);

            var lines = new List<string>();

            var currentLine = string.Empty;
            foreach (var word in EscapeText(text).Split(' '))
            {
                var localLine = currentLine;

                if (localLine != string.Empty)
                    localLine += " ";
                localLine += word;

                var textSize = TextMeasurer.Measure(localLine, textOptions);
                if (textSize.Width < width)
                {
                    currentLine = localLine;
                    continue;
                }

                lines.Add(localLine);
                currentLine = string.Empty;
            }

            if (currentLine != string.Empty)
                lines.Add(currentLine);

            return lines;
        }

        private string EscapeText(string text)
        {
            return Regex.Replace(text, "<[^>]*>", "");
        }

        private string GetSpeakerName(DialogCharacterType type)
        {
            return LocMan.Get(string.Format(DialogTitle_, GetLocalizationName(type)));
        }

        private string GetCharacterResourcePath(DialogCharacterType character, DialogCharacterState mood)
        {
            return string.Format(PeopleResource_, GetCharacterResourceName(character), mood);
        }

        private string GetLocalizationName(DialogCharacterType type)
        {
            if (!Enum.IsDefined(type))
            {
                Output.Error("Unknown dialogue character {0}", type);
                return string.Empty;
            }

            switch (type)
            {
                case DialogCharacterType.Grandma:
                    return "Ursula";

                case DialogCharacterType.AntiqueDealer:
                    return "Julius";

                case DialogCharacterType.Dog:
                    return "Rufus";

                case DialogCharacterType.Phone:
                    return "Charlie";

                default:
                    return type.ToString();
            }
        }

        private string GetCharacterResourceName(DialogCharacterType type)
        {
            if (!Enum.IsDefined(type))
            {
                Output.Error("Unknown dialogue character {0}", type);
                return string.Empty;
            }

            switch (type)
            {
                case DialogCharacterType.Grandma:
                    return "Ursula";

                case DialogCharacterType.AntiqueDealer:
                    return "Julius";

                case DialogCharacterType.Phone:
                    return "Charlie";

                case DialogCharacterType.Winston:
                    return "Butler";

                default:
                    return type.ToString();
            }
        }

        private bool ExistsPeopleResource(DialogCharacterType character, DialogCharacterState mood)
        {
            var resourceName = GetCharacterResourcePath(character, mood);
            return Assembly.GetExecutingAssembly().GetManifestResourceNames().Contains(resourceName);
        }

        private Image<Rgba32> LoadImageFromResource(string resourceName)
        {
            if (!Assembly.GetExecutingAssembly().GetManifestResourceNames().Contains(resourceName))
                return null;

            return Image.Load<Rgba32>(Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName));
        }
    }
}
