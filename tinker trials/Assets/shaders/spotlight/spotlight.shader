Shader "test/spotlight"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Charictor_Position("charictor Pos",vector)= (0,0,0,0)
        _spotlight_Radious("spotlight size",range(1,10))=3
        _Ring_Size("blend",range(0,5))=2
        _colour_Tint("colour outside soptlight",Color)=(0,0,0,0) 
        
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 worldPostion: TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            
            float4 _Charictor_Position;
            float _spotlight_Radious;
            float _Ring_Size;
            float4 _colour_Tint;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                
                o.worldPostion= mul(unity_ObjectToWorld,v.vertex).xyz;
                
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = _colour_Tint;
                
                float dist = distance(i.worldPostion,_Charictor_Position.xyz);
                
                //spotlight
                if(dist<_spotlight_Radious)
                    col= tex2D(_MainTex, i.uv);
                //blending
                else if(dist> _spotlight_Radious&& dist<_spotlight_Radious+_Ring_Size)
                {
                    float BlendStrengh =dist-_spotlight_Radious;
                    col=lerp(tex2D(_MainTex,i.uv),_colour_Tint,BlendStrengh/_Ring_Size);
                }
                
                //out of blending
                
                return col;
            }
            ENDCG
        }
    }
}
