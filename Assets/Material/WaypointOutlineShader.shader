Shader "Custom/WaypointOutline"
{
    Properties
    {
        _OutlineColor ("Outline Color", Color) = (1,1,1,1)
        _OutlineWidth ("Outline Width", Range(0.001, 0.1)) = 0.02
    }
    SubShader
    {
        Tags { "Queue"="Overlay" }
        Pass
        {
            Cull Front
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha
            ColorMask RGB
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
            };

            float _OutlineWidth;
            float4 _OutlineColor;

            v2f vert(appdata_t v)
            {
                v2f o;
                float3 norm = normalize(mul((float3x3)UNITY_MATRIX_IT_MV, v.normal));
                v.vertex.xyz += norm * _OutlineWidth;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                return _OutlineColor;
            }
            ENDCG
        }
    }
}
