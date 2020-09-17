﻿using System;

namespace Crosslight.API.Nodes
{
    /// <summary>
    /// ExpressionNode represents the expression.
    /// </summary>
    public abstract class ExpressionNode : Node
    {
        public override string Type => nameof(ExpressionNode);
        public ExpressionNode()
        {
        }
        public override string ToString()
        {
            return "ExpressionNode";
        }
    }
}
