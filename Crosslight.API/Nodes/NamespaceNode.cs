﻿using Crosslight.API.Nodes.Access;
using Crosslight.API.Nodes.Function;
using Crosslight.API.Util;
using System;
using System.Collections.Generic;

namespace Crosslight.API.Nodes
{
    /// <summary>
    /// NamespaceNode represents the namespace abstraction in the language.
    /// </summary>
    public class NamespaceNode : Node
    {
        public override Type Type => typeof(NamespaceNode);
        public SyncedList<TypeNode, Node> Types { get; protected set; }
        public SyncedList<ValueNode, Node> Values { get; protected set; }
        public SyncedList<FunctionNode, Node> Functions { get; protected set; }
        public NamespaceNode()
        {
            Types = new SyncedList<TypeNode, Node>(Children);
            Values = new SyncedList<ValueNode, Node>(Children);
            Functions = new SyncedList<FunctionNode, Node>(Children);
        }
        public override string ToString()
        {
            return "NamespaceNode";
        }
        public override object AcceptVisitor(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
