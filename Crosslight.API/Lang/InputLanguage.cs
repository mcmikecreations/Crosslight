﻿using Crosslight.API.IO;
using Crosslight.API.Nodes;

namespace Crosslight.API.Lang
{
    public abstract class InputLanguage
    {
        // TODO: replace Node return type with a more specialized root node type
        public abstract Node Decode(Source source);
        public abstract string Name { get; }
        public abstract LanguageOptions Options { get; protected set; }
    }
}
