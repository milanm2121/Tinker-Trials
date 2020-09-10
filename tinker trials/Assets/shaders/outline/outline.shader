Shader "test/outline"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _outline_Colour("outline colour",Color)=(0,0,0,0)
        _outline_With("outline with",Range(1,1.1))=5
    }
     CGINCLUDE
     #include "UnityCG.cginc"
     
     struct appdata
     {
        float4 vertex : POSITION;          
        float3 normal : NORMAL;
     };
     
     struct v2f
     {
        float4 pos: POSITION;

        float3 normal : NORMAL;
     };
     
     
     float _outline_With;
     float4 _outline_Colour;
     
     v2f vert(appdata v)
     {
        v.vertex.xyz *=_outline_With;
        
        
        v2f o;
        o.pos = UnityObjectToClipPos(v.vertex);

        return o;
     
     }
     
        ENDCG
    SubShader
    {
        pass//render outline
        {
            ZWrite off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            half4 frag(v2f i) :COLOR
            {
                return _outline_Colour;
            }
            
            ENDCG
        }
        
        
        Pass//normal render
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata2
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f2
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f2 vert (appdata2 v)
            {
                v2f2 o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f2 i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
