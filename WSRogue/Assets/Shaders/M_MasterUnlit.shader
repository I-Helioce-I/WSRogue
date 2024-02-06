Shader "Unlit/M_Test"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BaseColor ("Base Color", Color) = (1, 1, 1, 1)
        _Tilling ("Tilling and offset", Vector) = (1,1,0,0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100


        HLSLINCLUDE
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        
        
        CBUFFER_START(UnityPerMaterial)
            float4 _BaseColor;
            float4 _Tilling;
        CBUFFER_END

        TEXTURE2D(_MainTex);
        SAMPLER(sampler_MainTex);

       

        struct VertexInput
{
         float4 position : POSITION;
         float2 uv : TEXCOORD0;
        };
        struct VertexOutput
{
            float4 position : SV_POSITION;
            float2 uv : TEXCOORD0;
        };
        
        
        
        ENDHLSL


        Pass
        {
           

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            VertexOutput vert(VertexInput i)
            {
                 VertexOutput o;
                 o.position = TransformObjectToHClip(i.position.xyz);
                 o.uv = i.uv * _Tilling.xy;
                 o.uv += _Tilling.zw;
                 return o;
            }
            float4 frag(VertexOutput i) : SV_Target
            {
                 float4 baseTex = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv);
                 return baseTex * _BaseColor;
            }
            ENDHLSL
        }
    }
}
