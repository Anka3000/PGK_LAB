Shader "Unlit/SkyReflectionWater"
{
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        
        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct v2f {
                half3 worldRefl : TEXCOORD0;
                float4 pos : SV_POSITION;
                float3 normal : NORMAL;
            };

            v2f vert (appdata_full v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                
                float3 offset = o.normal * sin(_Time.y * 2 + v.vertex.x * 0.1);
                o.pos.xyz += offset;

                return o;
            }
        
            fixed4 frag (v2f i) : SV_Target
            {
                half4 skyData = UNITY_SAMPLE_TEXCUBE(unity_SpecCube0, i.worldRefl);

                half3 skyColor = DecodeHDR (skyData, unity_SpecCube0_HDR);
                
                half3 waterColor = half3(0.8, 0.08, 0.66);
                
                skyColor = lerp(skyColor, waterColor, 0.5); 
                
                fixed4 c = 0;
                c.rgb = skyColor;
                c.a = 0.5; 
                return c;
            }
            ENDCG
        }
    }
}
