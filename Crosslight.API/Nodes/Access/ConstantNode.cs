﻿using System;

namespace Crosslight.API.Nodes.Access
{
    /// <summary>
    /// ConstantNode represents the constant abstraction in the language.
    /// </summary>
    public class ConstantNode : ValueNode
    {
        public override string Type => nameof(ConstantNode);
        public string Name { get; }
        public ConstantNode(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return "ConstantNode";
        }
        public override object AcceptVisitor(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
