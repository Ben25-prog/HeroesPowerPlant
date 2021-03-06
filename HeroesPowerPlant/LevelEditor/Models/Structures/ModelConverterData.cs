﻿using SharpDX;
using System.Collections.Generic;

namespace HeroesPowerPlant.LevelEditor
{
    public struct ModelConverterData
    {
        public List<string> MaterialList;
        public List<Vertex> VertexList;
        public List<Vector2> UVList;
        public List<Color> ColorList;
        public List<Triangle> TriangleList;
        public string MTLLib;
    }
}