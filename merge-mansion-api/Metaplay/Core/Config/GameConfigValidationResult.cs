using System.Collections.Generic;
using System;

namespace Metaplay.Core.Config
{
    public class GameConfigValidationResult
    {
        private string _variantScope;
        private List<GameConfigBuildMessage> _validationMessages;
        private List<Predicate<GameConfigBuildMessage>> _filters;
        public IEnumerable<GameConfigValidationMessage> FilteredValidationMessages { get; }
        public IReadOnlyList<GameConfigValidationMessage> ValidationMessages { get; }

        public GameConfigValidationResult(string variantScope)
        {
        }

        private List<GameConfigSourceMapping> _sourceMappingScope;
    }
}