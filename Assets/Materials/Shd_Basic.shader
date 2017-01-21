// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:1873,x:33229,y:32719,varname:node_1873,prsc:2|emission-627-OUT,alpha-5703-A,refract-7587-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:30404,y:33139,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1086,x:30665,y:33228,cmnt:RGB,varname:node_1086,prsc:2|A-4805-RGB,B-5983-RGB,C-5376-RGB;n:type:ShaderForge.SFN_Color,id:5983,x:30404,y:33325,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:30404,y:33489,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1749,x:30878,y:33228,cmnt:Premultiply Alpha,varname:node_1749,prsc:2|A-1086-OUT,B-603-OUT;n:type:ShaderForge.SFN_Multiply,id:603,x:30665,y:33402,cmnt:A,varname:node_603,prsc:2|A-4805-A,B-5983-A,C-5376-A;n:type:ShaderForge.SFN_Tex2d,id:5703,x:30597,y:32314,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_5703,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0ce04d96eb4134c40b4efb0a814a79d2,ntxv:0,isnm:False|UVIN-4171-OUT;n:type:ShaderForge.SFN_Multiply,id:5482,x:31017,y:32601,varname:node_5482,prsc:2|A-5082-OUT,B-2579-OUT;n:type:ShaderForge.SFN_Append,id:4171,x:30420,y:32314,varname:node_4171,prsc:2|A-4413-OUT,B-1286-OUT;n:type:ShaderForge.SFN_TexCoord,id:2274,x:29733,y:32275,varname:node_2274,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:4318,x:29983,y:32329,varname:node_4318,prsc:2|A-2274-V,B-4213-OUT;n:type:ShaderForge.SFN_Vector1,id:4213,x:29983,y:32465,varname:node_4213,prsc:2,v1:1.25;n:type:ShaderForge.SFN_Multiply,id:4413,x:30211,y:32251,varname:node_4413,prsc:2|A-2274-U,B-4188-X;n:type:ShaderForge.SFN_Multiply,id:1286,x:30211,y:32374,varname:node_1286,prsc:2|A-6696-OUT,B-4188-Y;n:type:ShaderForge.SFN_Tex2d,id:2785,x:30597,y:32120,ptovrint:False,ptlb:Texture_Damages,ptin:_Texture_Damages,varname:node_2785,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3e474cdcc4c833c4e8b299bd4e67e455,ntxv:0,isnm:False|UVIN-4171-OUT;n:type:ShaderForge.SFN_Tex2d,id:3075,x:30041,y:32589,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_3075,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:2787,x:30866,y:32424,varname:node_2787,prsc:2|A-2785-RGB,B-5703-RGB,T-906-OUT;n:type:ShaderForge.SFN_Power,id:4852,x:30412,y:32591,varname:node_4852,prsc:2|VAL-2424-OUT,EXP-6160-OUT;n:type:ShaderForge.SFN_Vector1,id:6160,x:30230,y:32750,varname:node_6160,prsc:2,v1:5;n:type:ShaderForge.SFN_Multiply,id:2424,x:30230,y:32591,varname:node_2424,prsc:2|A-3075-RGB,B-2658-OUT;n:type:ShaderForge.SFN_Vector1,id:2658,x:30041,y:32750,varname:node_2658,prsc:2,v1:2.5;n:type:ShaderForge.SFN_Clamp01,id:906,x:30582,y:32591,varname:node_906,prsc:2|IN-4852-OUT;n:type:ShaderForge.SFN_ObjectScale,id:4188,x:29710,y:32127,varname:node_4188,prsc:2,rcp:False;n:type:ShaderForge.SFN_Vector1,id:2304,x:32475,y:33282,varname:node_2304,prsc:2,v1:0;n:type:ShaderForge.SFN_Append,id:7587,x:32659,y:33248,varname:node_7587,prsc:2|A-2304-OUT,B-2304-OUT;n:type:ShaderForge.SFN_Multiply,id:893,x:31191,y:33426,varname:node_893,prsc:2|A-3649-OUT,B-1749-OUT;n:type:ShaderForge.SFN_Vector1,id:3649,x:31024,y:33426,varname:node_3649,prsc:2,v1:0;n:type:ShaderForge.SFN_OneMinus,id:3977,x:31365,y:33426,varname:node_3977,prsc:2|IN-893-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:2579,x:31608,y:33212,ptovrint:False,ptlb:Override,ptin:_Override,varname:node_2579,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-1749-OUT,B-3977-OUT;n:type:ShaderForge.SFN_Tex2d,id:9505,x:32151,y:32541,ptovrint:False,ptlb:Gradient,ptin:_Gradient,varname:node_9505,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8667c6969b722014f9de666a0fe76ba4,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:5637,x:32396,y:32842,varname:node_5637,prsc:2|A-1049-OUT,B-5482-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:4340,x:32592,y:32823,ptovrint:False,ptlb:Perspective,ptin:_Perspective,varname:node_4340,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-5482-OUT,B-5637-OUT;n:type:ShaderForge.SFN_Lerp,id:1049,x:32420,y:32479,varname:node_1049,prsc:2|A-7133-OUT,B-7285-RGB,T-9505-R;n:type:ShaderForge.SFN_Vector1,id:7133,x:32151,y:32285,varname:node_7133,prsc:2,v1:1;n:type:ShaderForge.SFN_Color,id:7285,x:32151,y:32370,ptovrint:False,ptlb:Shadow_Color,ptin:_Shadow_Color,varname:node_7285,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_SwitchProperty,id:6696,x:29770,y:32523,ptovrint:False,ptlb:Rectification,ptin:_Rectification,varname:node_6696,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-2274-V,B-4318-OUT;n:type:ShaderForge.SFN_Desaturate,id:2767,x:33000,y:32140,varname:node_2767,prsc:2|COL-4340-OUT,DES-1358-OUT;n:type:ShaderForge.SFN_Power,id:4764,x:33241,y:32140,varname:node_4764,prsc:2|VAL-2767-OUT,EXP-4681-OUT;n:type:ShaderForge.SFN_ValueProperty,id:454,x:33016,y:32451,ptovrint:False,ptlb:Saturation,ptin:_Saturation,varname:node_454,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:4681,x:33241,y:32302,ptovrint:False,ptlb:Contraste,ptin:_Contraste,varname:node_4681,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_OneMinus,id:1358,x:33000,y:32285,varname:node_1358,prsc:2|IN-454-OUT;n:type:ShaderForge.SFN_RgbToHsv,id:3202,x:31485,y:32380,varname:node_3202,prsc:2|IN-1481-OUT;n:type:ShaderForge.SFN_HsvToRgb,id:5082,x:31711,y:32490,varname:node_5082,prsc:2|H-3202-HOUT,S-3202-SOUT,V-2513-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7300,x:31433,y:32529,ptovrint:False,ptlb:Luminosite,ptin:_Luminosite,varname:node_7300,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_SwitchProperty,id:1481,x:31064,y:32449,ptovrint:False,ptlb:Recolorize,ptin:_Recolorize,varname:node_1481,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-2787-OUT,B-9608-OUT;n:type:ShaderForge.SFN_Desaturate,id:9608,x:31064,y:32284,varname:node_9608,prsc:2|COL-2787-OUT;n:type:ShaderForge.SFN_RgbToHsv,id:1671,x:33377,y:32560,varname:node_1671,prsc:2|IN-4764-OUT;n:type:ShaderForge.SFN_HsvToRgb,id:627,x:33587,y:32560,varname:node_627,prsc:2|H-8653-OUT,S-1671-SOUT,V-1671-VOUT;n:type:ShaderForge.SFN_Add,id:8653,x:33489,y:32402,varname:node_8653,prsc:2|A-1671-HOUT,B-6976-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6976,x:33474,y:32331,ptovrint:False,ptlb:Hue,ptin:_Hue,varname:node_6976,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Add,id:2513,x:31596,y:32642,varname:node_2513,prsc:2|A-3202-VOUT,B-5857-OUT;n:type:ShaderForge.SFN_Add,id:5857,x:31433,y:32660,varname:node_5857,prsc:2|A-8282-OUT,B-7300-OUT;n:type:ShaderForge.SFN_Vector1,id:8282,x:31433,y:32815,varname:node_8282,prsc:2,v1:-1;proporder:4805-5983-5703-2785-3075-2579-9505-4340-7285-6696-1481-7300-454-4681-6976;pass:END;sub:END;*/

Shader "Custom/Shd_Basic" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _Texture ("Texture", 2D) = "white" {}
        _Texture_Damages ("Texture_Damages", 2D) = "white" {}
        _Noise ("Noise", 2D) = "white" {}
        [MaterialToggle] _Override ("Override", Float ) = 0
        _Gradient ("Gradient", 2D) = "white" {}
        [MaterialToggle] _Perspective ("Perspective", Float ) = 0
        _Shadow_Color ("Shadow_Color", Color) = (1,0,0,1)
        [MaterialToggle] _Rectification ("Rectification", Float ) = 0
        [MaterialToggle] _Recolorize ("Recolorize", Float ) = 0
        _Luminosite ("Luminosite", Float ) = 1
        _Saturation ("Saturation", Float ) = 1
        _Contraste ("Contraste", Float ) = 1
        _Hue ("Hue", Float ) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _Color;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform sampler2D _Texture_Damages; uniform float4 _Texture_Damages_ST;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform fixed _Override;
            uniform sampler2D _Gradient; uniform float4 _Gradient_ST;
            uniform fixed _Perspective;
            uniform float4 _Shadow_Color;
            uniform fixed _Rectification;
            uniform float _Saturation;
            uniform float _Contraste;
            uniform float _Luminosite;
            uniform fixed _Recolorize;
            uniform float _Hue;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 screenPos : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float3 objScale = 1.0/recipObjScale;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float3 objScale = 1.0/recipObjScale;
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float node_2304 = 0.0;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + float2(node_2304,node_2304);
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
////// Emissive:
                float2 node_4171 = float2((i.uv0.r*objScale.r),(lerp( i.uv0.g, (i.uv0.g*1.25), _Rectification )*objScale.g));
                float4 _Texture_Damages_var = tex2D(_Texture_Damages,TRANSFORM_TEX(node_4171, _Texture_Damages));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_4171, _Texture));
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float3 node_2787 = lerp(_Texture_Damages_var.rgb,_Texture_var.rgb,saturate(pow((_Noise_var.rgb*2.5),5.0)));
                float3 _Recolorize_var = lerp( node_2787, dot(node_2787,float3(0.3,0.59,0.11)), _Recolorize );
                float4 node_3202_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_3202_p = lerp(float4(float4(_Recolorize_var,0.0).zy, node_3202_k.wz), float4(float4(_Recolorize_var,0.0).yz, node_3202_k.xy), step(float4(_Recolorize_var,0.0).z, float4(_Recolorize_var,0.0).y));
                float4 node_3202_q = lerp(float4(node_3202_p.xyw, float4(_Recolorize_var,0.0).x), float4(float4(_Recolorize_var,0.0).x, node_3202_p.yzx), step(node_3202_p.x, float4(_Recolorize_var,0.0).x));
                float node_3202_d = node_3202_q.x - min(node_3202_q.w, node_3202_q.y);
                float node_3202_e = 1.0e-10;
                float3 node_3202 = float3(abs(node_3202_q.z + (node_3202_q.w - node_3202_q.y) / (6.0 * node_3202_d + node_3202_e)), node_3202_d / (node_3202_q.x + node_3202_e), node_3202_q.x);;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 node_1749 = ((_MainTex_var.rgb*_Color.rgb*i.vertexColor.rgb)*(_MainTex_var.a*_Color.a*i.vertexColor.a)); // Premultiply Alpha
                float3 node_5482 = ((lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(node_3202.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),node_3202.g)*(node_3202.b+((-1.0)+_Luminosite)))*lerp( node_1749, (1.0 - (0.0*node_1749)), _Override ));
                float node_7133 = 1.0;
                float4 _Gradient_var = tex2D(_Gradient,TRANSFORM_TEX(i.uv0, _Gradient));
                float3 node_4764 = pow(lerp(lerp( node_5482, (lerp(float3(node_7133,node_7133,node_7133),_Shadow_Color.rgb,_Gradient_var.r)*node_5482), _Perspective ),dot(lerp( node_5482, (lerp(float3(node_7133,node_7133,node_7133),_Shadow_Color.rgb,_Gradient_var.r)*node_5482), _Perspective ),float3(0.3,0.59,0.11)),(1.0 - _Saturation)),_Contraste);
                float4 node_1671_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_1671_p = lerp(float4(float4(node_4764,0.0).zy, node_1671_k.wz), float4(float4(node_4764,0.0).yz, node_1671_k.xy), step(float4(node_4764,0.0).z, float4(node_4764,0.0).y));
                float4 node_1671_q = lerp(float4(node_1671_p.xyw, float4(node_4764,0.0).x), float4(float4(node_4764,0.0).x, node_1671_p.yzx), step(node_1671_p.x, float4(node_4764,0.0).x));
                float node_1671_d = node_1671_q.x - min(node_1671_q.w, node_1671_q.y);
                float node_1671_e = 1.0e-10;
                float3 node_1671 = float3(abs(node_1671_q.z + (node_1671_q.w - node_1671_q.y) / (6.0 * node_1671_d + node_1671_e)), node_1671_d / (node_1671_q.x + node_1671_e), node_1671_q.x);;
                float3 emissive = (lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac((node_1671.r+_Hue)+float3(0.0,-1.0/3.0,1.0/3.0)))-1),node_1671.g)*node_1671.b);
                float3 finalColor = emissive;
                return fixed4(lerp(sceneColor.rgb, finalColor,_Texture_var.a),1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
