Shader "Custom/Normal Gloss Mapped Specular" {
    Properties{
        _Color("Main Color", Color) = (1,1,1,1)
        _MainTex("Base (RGB)", 2D) = "white" {}
        _Scale("Texture Scale", Float) = 1.0
                     _SpecColor("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
        _Shininess("Shininess", Range(0.01, 1)) = 0.078125
        _Gloss("Gloss", Range(0.0, 2.0)) = 1
       
        _BumpMap("Normal Map", 2D) = "bump" {}
        _GlossMap("Gloss Map", 2D) = "gloss" {}

    }
        SubShader{
            Tags { "RenderType" = "Opaque" }
            LOD 200

        CGPROGRAM
        #pragma surface surf Lambert fullforwardshadows

        sampler2D _MainTex;
        fixed4 _Color;
        float _Scale;
        half _Shininess;
        half _Gloss;
       
        sampler2D _BumpMap;
        sampler2D _GlossMap;


        struct Input {
            float3 worldNormal;
            float3 worldPos;
            float2 uv_MainTex;
            float2 uv_BumpMap;
            float2 uv_GlossMap;
        };

        void surf(Input IN, inout SurfaceOutput o) {
            float2 UV;
            fixed4 ppp;
            half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Alpha = c.a;
            o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
            o.Gloss = tex2D(_GlossMap, IN.uv_GlossMap).a * _Gloss;
            o.Specular = _Shininess;

            if (abs(IN.worldNormal.x) > 0.5) {
                UV = IN.worldPos.yz; // side
                ppp = tex2D(_MainTex, UV * _Scale); // use WALLSIDE texture
            }
            else if (abs(IN.worldNormal.z) > 0.5) {
                UV = IN.worldPos.xy; // front
                ppp = tex2D(_MainTex, UV * _Scale); // use WALL texture
            }
            else {
                UV = IN.worldPos.xz; // top
                ppp = tex2D(_MainTex, UV * _Scale); // use FLR texture
            }

            o.Albedo = ppp.rgb * _Color;
        }
        ENDCG
        }

            Fallback "Specular"
}