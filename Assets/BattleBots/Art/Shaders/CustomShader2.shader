Shader "Unlit/CustomShader2"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Health ("Health", Range(0,1)) = 1
        _Amplitude ("Amplitude", Range(0,1)) = 1
        _Frequency ("Frequency", Range(0,30)) = 1
        _UpperHealthRange("Upper Health Range", Range(0,1)) = 1
        _LowerHealthRange("Lower Health Range", Range(0,1)) = 1
        _BorderSize("Border Size", Range(0,1)) = 1
        _ClampValue("Clamp Value", Range(0,.5)) = .1
        _RoundedMultiple("Rounded Multiple", Range(1,5)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct MeshData
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Interpolators
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _Health;
            float _Amplitude;
            float _Frequency;
            float _UpperHealthRange;
            float _LowerHealthRange;
            float _BorderSize;
            float _ClampValue;
            float _RoundedMultiple;

            float InverseLerp(float start, float end, float value)
            {
                return (value - start)/(end - start);
            }

            Interpolators vert (MeshData v)
            {
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag (Interpolators i) : SV_Target
            {
                float2 normalizedCoords = i.uv;
                normalizedCoords.x *= 8;

                float2 pointOnLineSegment = float2( clamp(normalizedCoords.x, 0.5 - _ClampValue, 7.5 + _ClampValue) ,clamp(normalizedCoords.y, 0.5 - _ClampValue, 0.5 + _ClampValue));
                float sinDistanceField = distance(normalizedCoords, pointOnLineSegment) * _RoundedMultiple - 1;

                clip(-sinDistanceField);

                float borderSDF = sinDistanceField + _BorderSize;

                float pd = fwidth(borderSDF); // screen space partial derivative

                //float borderMask = step(0, -borderSDF);

                float borderMask = 1 - saturate(borderSDF / pd);

                //return float4(borderColored, 1);

                float healthBarMask = _Health > i.uv.x;

                float3 HealthBarColor = tex2D(_MainTex, float2(_Health, i.uv.y));

                float flash = cos( _Time.y * _Frequency) * _Amplitude + 1;
                float3 ReverseLerpFlash = saturate(InverseLerp(_LowerHealthRange, _UpperHealthRange, _Health));
                float3 Output = lerp((HealthBarColor * flash), HealthBarColor, ReverseLerpFlash);
                //float BorderMaskColor = (borderMask * _BorderColor) + _BorderColor;

                return float4(Output * healthBarMask * borderMask, 1);
            }
            ENDCG
        }
    }
}
