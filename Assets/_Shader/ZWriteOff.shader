//Shader "Unlit/ZWriteOff"
//{
//
//
//    SubShader
//    {
//        Pass
//        {
//            ZWrite Off
//        }
//        
//    }
//}
Shader "Unlit/ZWriteOff"
{
    Properties
    {
        _HoleCenter ("Hole Center (XZ)", Vector) = (0,0,0,0)
        _HoleRadius ("Hole Radius", Float) = 1.0
        _HoleColor ("Hole Color", Color) = (0,0,0,1)
        _MainTex ("Texture", 2D) = "white" {}
        _MainColor ("Main Color", Color) = (1,1,1,1)
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

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD1;
            };

            float2 _HoleCenter;
            float _HoleRadius;
            fixed4 _HoleColor;
            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _MainColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Calculate the distance in the XZ plane from the world position to the hole center
                float distanceToHole = distance(float2(i.worldPos.x, i.worldPos.z), _HoleCenter);

                // If the distance is within the hole radius, output the hole color
                if (distanceToHole < _HoleRadius)
                {
                    return _HoleColor;
                }
                else
                {
                    // Otherwise, sample the texture and apply the main color
                    fixed4 col = tex2D(_MainTex, i.uv) * _MainColor;
                    return col;
                }
            }
            ENDCG
        }
    }
}