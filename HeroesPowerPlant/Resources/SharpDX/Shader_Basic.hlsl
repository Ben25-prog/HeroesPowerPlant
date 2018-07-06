﻿cbuffer data :register(b0)
{
	float4x4 worldViewProj;
	float4 color;
};

struct VS_IN
{
	float4 position : POSITION;
};

struct PS_IN
{
	float4 position : SV_POSITION;
	float4 color: COLOR;
};

PS_IN VS(VS_IN input)
{
	PS_IN output = (PS_IN)0;
	
	output.position = mul(worldViewProj, input.position);
	output.color = color;

	return output;
}

float4 PS(PS_IN input) : SV_Target
{
	return input.color;
}