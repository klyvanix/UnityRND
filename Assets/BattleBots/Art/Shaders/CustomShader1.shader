Shader "BrianCustom/CustomShader1"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Health ("Health", Range(0,1)) = 1
        _LowHealth("Low Health Color", Color) = (1, 1, 1, 1)
        _FullHealth("Full Health Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" 
        //"Queue"="Transparent" 
        }

        Pass
        {
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha
            //Blend One One
            //Blend DstColor Zero

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Interpolater
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float _Health;
            float4 _LowHealth;
            float4 _FullHealth;

            Interpolater vert (appdata v)
            {
                Interpolater o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                //o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.uv = v.uv;
                return o;
            }

            float InverseLerp(float start, float end, float value)
            {
                return (value - start)/(end - start);
            }

            float4 frag (Interpolater i) : SV_Target
            {
                //----------HEALTHBAR START-----------
                //float HealthbarMask = _Health > i.uv.x;

                //float3 bgColor = float3(0,0,0);

                //float3 tColor = saturate(InverseLerp(.2, .8, _Health));
                //float3 healthColor = lerp(_LowHealth, _FullHealth, tColor);

                //float3 outColor = lerp(bgColor, healthColor, HealthbarMask);
                //return float4(outColor,0);
                //----------HEALTHBAR End-------------

                //return float4(1,0,0, i.uv.x);

                float4 col = tex2D(_MainTex, i.uv);

                //return col;

                float HealthbarMask = _Health > i.uv.x;

                float4 tColor = saturate(InverseLerp(.2, .8, _Health));

                float4 healthColor = lerp(_LowHealth, _FullHealth, tColor);
                float4 outColor = lerp(float4(0,0,0,0), healthColor, col);
                //clip(HealthbarMask - 0.5);
                //return float4(outColor);
                return float4(outColor.xyz, outColor.w * HealthbarMask);
                //return float4(_FullHealth,1);
            }
            ENDCG
        }
    }
}
