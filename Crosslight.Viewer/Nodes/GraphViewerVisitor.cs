﻿using Crosslight.API.Nodes;
using Crosslight.Viewer.Models.Graph;
using System.Collections.Generic;

namespace Crosslight.Viewer.Nodes
{
    public class GraphViewerVisitor : IViewerVisitor
    {
        public GraphModel Context { get; private set; }
        private int idGen;

        public GraphViewerVisitor()
        {
            Context = new GraphModel
            {
                Nodes = new List<NodeModel>()
            };
            idGen = 0;
        }
        public object Visit(Node node)
        {
            string name = node.ToString();// + idGen.ToString();
            var parent = new NodeModel()
            {
                ID = idGen++,
                Data = name,
                Connections = new List<int>(),
            };
            Context.Nodes.Add(parent);
            if (node.Children != null)
            {
                foreach (Node nodeChild in node.Children)
                {
                    NodeModel visitResult;
                    if (nodeChild is ViewerNode viewerNode)
                    {
                        visitResult = Visit(viewerNode) as NodeModel;
                    }
                    else
                    {
                        visitResult = Visit(nodeChild) as NodeModel;
                    }
                    parent.Connections.Add(visitResult.ID);
                }
            }
            return parent;
        }

        public object Visit(ViewerNode node)
        {
            string name = (node.Content ?? node).ToString() + idGen.ToString();
            var parent = new NodeModel()
            {
                ID = idGen++,
                Data = name,
                Connections = new List<int>(),
            };
            Context.Nodes.Add(parent);
            if (node.Children != null)
            {
                foreach (Node nodeChild in node.Children)
                {
                    ViewerNode viewerNode;
                    if (nodeChild is ViewerNode)
                    {
                        viewerNode = nodeChild as ViewerNode;
                    }
                    else
                    {
                        viewerNode = new ViewerNode(nodeChild);
                    }
                    var child = Visit(viewerNode) as NodeModel;
                    parent.Connections.Add(child.ID);
                }
            }
            return parent;
        }
    }
}
