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
                
                // Wave effect
                float3 offset = o.normal * sin(_Time.y * 2 + v.vertex.x * 0.1);
                o.pos.xyz += offset;

                return o;
            }
        
            fixed4 frag (v2f i) : SV_Target
            {
                // sample the default reflection cubemap, using the reflection vector
                half4 skyData = UNITY_SAMPLE_TEXCUBE(unity_SpecCube0, i.worldRefl);
                // decode cubemap data into actual color
                half3 skyColor = DecodeHDR (skyData, unity_SpecCube0_HDR);
                
                // Define water color
                half3 waterColor = half3(0.8, 0.08, 0.66);
                
                // Mix sky color with water color
                skyColor = lerp(skyColor, waterColor, 0.5); // Adjust the blending factor as needed
                
                // output it!
                fixed4 c = 0;
                c.rgb = skyColor;
                c.a = 0.5; // Set the transparency level (0 - fully transparent, 1 - fully opaque)
                return c;
            }
            ENDCG
        }
    }
}
