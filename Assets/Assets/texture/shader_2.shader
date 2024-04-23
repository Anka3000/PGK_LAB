Shader "Custom/MetallicWithGlossAndReflection"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Metallic ("Metallic", Range(0,1)) = 0.5
        _Glossiness ("Glossiness", Range(0,1)) = 0.5
        _SpecularColor ("Specular Color", Color) = (1, 1, 1, 1)
        _ReflectionTex ("Reflection Texture", 2D) = "white" {} 
        _CustomTex ("Custom Texture", 2D) = "white" {} 
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
        
        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0
        
        sampler2D _MainTex;
        sampler2D _ReflectionTex; 
        sampler2D _CustomTex; 
        half _Metallic;
        half _Glossiness;
        fixed4 _SpecularColor;
        
        struct Input
        {
            float2 uv_MainTex;
            float3 viewDir;
            float3 worldPos;
        };
        
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            // kolor odbicia
            o.Albedo = c.rgb;
            // poziom metalicznoœci
            o.Metallic = _Metallic;
            // poziom po³ysku
            o.Smoothness = _Glossiness;
            // b³ysk
            half spec = pow(saturate(dot(reflect(-IN.viewDir, o.Normal), normalize(IN.worldPos - _WorldSpaceCameraPos))), 10);
            o.Emission = _SpecularColor.rgb * spec;
            // lustrzane odbicie
            o.Normal = reflect(IN.viewDir, o.Normal); 
            fixed4 reflColor = tex2D(_ReflectionTex, IN.uv_MainTex);
            o.Albedo += reflColor.rgb;
            fixed4 customColor = tex2D(_CustomTex, IN.uv_MainTex); // kolor z dowolnej tekstury jest pobierany
            o.Albedo *= customColor.rgb;
        }
        ENDCG
    } 
    FallBack "Diffuse"
}
