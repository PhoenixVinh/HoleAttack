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
//Shader "Unlit/ZWriteOff"
//{
//    Properties
//    {
//        _HoleCenter ("Hole Center (XZ)", Vector) = (0,0,0,0)
//        _HoleRadius ("Hole Radius", Float) = 1.0
//        _HoleColor ("Hole Color", Color) = (0,0,0,1)
//        _MainTex ("Texture", 2D) = "white" {}
//        _MainColor ("Main Color", Color) = (1,1,1,1)
//    }
//    SubShader
//    {
//        Tags { "RenderType"="Opaque" }
//        LOD 100
//
//        Pass
//        {
//            CGPROGRAM
//            #pragma vertex vert
//            #pragma fragment frag
//
//            #include "UnityCG.cginc"
//
//            struct appdata
//            {
//                float4 vertex : POSITION;
//                float2 uv : TEXCOORD0;
//                float3 normal : NORMAL;
//            };
//
//            struct v2f
//            {
//                float2 uv : TEXCOORD0;
//                float4 vertex : SV_POSITION;
//                float3 worldPos : TEXCOORD1;
//            };
//
//            float2 _HoleCenter;
//            float _HoleRadius;
//            fixed4 _HoleColor;
//            sampler2D _MainTex;
//            float4 _MainTex_ST;
//            fixed4 _MainColor;
//
//            v2f vert (appdata v)
//            {
//                v2f o;
//                o.vertex = UnityObjectToClipPos(v.vertex);
//                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
//                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
//                return o;
//            }
//
//            fixed4 frag (v2f i) : SV_Target
//            {
//                // Calculate the distance in the XZ plane from the world position to the hole center
//                float distanceToHole = distance(float2(i.worldPos.x, i.worldPos.z), _HoleCenter);
//
//                // If the distance is within the hole radius, output the hole color
//                if (distanceToHole < _HoleRadius)
//                {
//                    return _HoleColor;
//                }
//                else
//                {
//                    // Otherwise, sample the texture and apply the main color
//                    fixed4 col = tex2D(_MainTex, i.uv) * _MainColor;
//                    return col;
//                }
//            }
//            ENDCG
//        }
//    }
//}


Shader "Unlit/HoleWithTexture"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {} // Texture for the surface (brown background and gray bar)
        _Color ("Tint Color", Color) = (0.588, 0.294, 0, 1) // Brown color for the background
        _HoleCenter ("Hole Center (UV)", Vector) = (0.5, 0.5, 0, 0) // Center of the hole in UV space
        _HoleRadius ("Hole Radius", Float) = 0.2 // Radius of the hole
        _HoleEdgeSmoothness ("Hole Edge Smoothness", Range(0.0, 0.01)) = 0.005 // Smoothness of the hole's edge
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 100

        // Disable depth writing
        ZWrite Off
        // Enable alpha blending
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            ZWrite Off
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
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
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;
            float2 _HoleCenter;
            float _HoleRadius;
            float _HoleEdgeSmoothness;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Sample the texture
                fixed4 col = tex2D(_MainTex, i.uv) * _Color;

                // Calculate distance from the current UV to the hole center
                float dist = distance(i.uv, _HoleCenter);

                // Create a smooth alpha transition for the hole
                float alpha = smoothstep(_HoleRadius - _HoleEdgeSmoothness, _HoleRadius, dist);

                // Apply alpha: 0 inside the hole (fully transparent), 1 outside (opaque)
                col.a *= alpha;

                return col;
            }
            ENDCG
        }
    }
}