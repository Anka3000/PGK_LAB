Shader "Unlit/Water"
{
    Properties
    {
        _Speed ("Speed", Float) = 1.0 
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" } 
        LOD 100
        
        Blend SrcAlpha OneMinusSrcAlpha 
        Cull Off 

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            float _Speed;

            v2f vert (appdata v)
            {
                v2f o;
                float scale = 0.3; 
                o.vertex = UnityObjectToClipPos(v.vertex + float4(sin(_Time.y * _Speed) * scale, cos(_Time.y * _Speed) * scale, 0, 0));
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                return half4(0.8, 0.08, 0.66, 0.5); 
            }
            ENDCG
        }
    }
}
