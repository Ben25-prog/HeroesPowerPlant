﻿using SharpDX;
using System;
using static HeroesPowerPlant.SharpRenderer;

namespace HeroesPowerPlant.LayoutEditor
{
    public class Object1189_GlowEffectSpider : SetObjectManagerHeroes
    {
        public override void Draw(string[] modelNames, bool isSelected)
        {
            if (MiscSettings[7] <= 3)
                if (DFFRenderer.DFFStream.ContainsKey(modelNames[MiscSettings[7]]))
                    DFFRenderer.DFFStream[modelNames[MiscSettings[7]]].Render();
                else
                    DrawCube(transformMatrix, isSelected);
            else
                DrawCube(transformMatrix, isSelected);
        }
    }
}