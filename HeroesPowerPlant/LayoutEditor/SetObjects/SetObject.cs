﻿using Newtonsoft.Json;
using SharpDX;
using System;

namespace HeroesPowerPlant.LayoutEditor
{
    public abstract class SetObject
    {
        public ObjectEntry objectEntry;
        public void FindObjectEntry(byte List, byte Type, ObjectEntry[] objectEntries)
        {
            for (int i = 0; i < objectEntries.Length; i++)
            {
                if (objectEntries[i].List == List & objectEntries[i].Type == Type)
                {
                    objectEntry = objectEntries[i];
                    return;
                }
            }
            throw new Exception($"Object entry not found: {List.ToString("X2")} {Type.ToString("X2")}");
        }
        
        public Vector3 Position;
        public Vector3 Rotation;
        public byte Link;
        public byte Rend;

        public byte[] UnkBytes;

        [JsonIgnore]
        public bool isSelected;

        [JsonIgnore]
        public BoundingBox boundingBox;
        
        public override string ToString()
        {
            return objectEntry.GetName() + (Link == 0 ? "" : $" ({Link})");
        }

        public abstract void CreateTransformMatrix();

        public bool DontDraw(Vector3 camPos)
        {
            return Vector3.Distance(camPos, Position) > Rend * 100;
        }

        public abstract void Draw(SharpRenderer renderer, bool drawEveryObject);

        public abstract SetObjectManager ObjectManager { get; }

        public abstract byte[] MiscSettings { get; set; }

        public abstract void FindNewObjectManager(bool replaceMiscSettings = true);

        public float GetDistanceFromOrigin()
        {
            return Position.Length();
        }

        public bool IntersectsWith(Ray r, out float distance)
        {
            if (r.Intersects(ref boundingBox, out distance))
                return TriangleIntersection(r, distance, out distance);

            return false;
        }

        public abstract bool TriangleIntersection(Ray r, float initialDistance, out float distance);

        public BoundingSphere GetGizmoCenter()
        {
            BoundingSphere boundingSphere = BoundingSphere.FromBox(boundingBox);
            boundingSphere.Radius *= 0.9f;
            return boundingSphere;
        }
    }
}