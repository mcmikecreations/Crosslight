﻿using Crosslight.API.Nodes.Access;
using Crosslight.API.Util;
using System;

namespace Crosslight.API.Nodes.Componentization
{
    /// <summary>
    /// ProjectNode represents the project abstraction in the language.
    /// E.g. in C# it is assembly, for Java it is executable .jar,
    /// in C++ it is static program.
    /// Nothing is higher than ProjectNode, so its Parent property is null.
    /// </summary>
    public class ProjectNode : Node
    {
        public override Type Type => typeof(ProjectNode);
        public SyncedList<AttributeNode, Node> Attributes { get; protected set; }
        public SyncedList<ModuleNode, Node> Modules { get; protected set; }
        public string Name { get; }
        public ProjectNode(string name)
        {
            Attributes = new SyncedList<AttributeNode, Node>(Children);
            Modules = new SyncedList<ModuleNode, Node>(Children);
            Name = name;
        }
        public override string ToString()
        {
            return $"Project {Name}";
        }
        public override object AcceptVisitor(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
