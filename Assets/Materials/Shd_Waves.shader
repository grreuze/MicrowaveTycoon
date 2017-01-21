// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:32716,y:32678,varname:node_4795,prsc:2|emission-2393-OUT,alpha-798-OUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:32495,y:32793,varname:node_2393,prsc:2|A-9548-RGB,B-2053-RGB,C-797-RGB,D-9248-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32041,y:32784,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:32041,y:32942,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Vector1,id:9248,x:32041,y:33108,varname:node_9248,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:798,x:32495,y:32923,varname:node_798,prsc:2|A-9548-A,B-2053-A,C-797-A;n:type:ShaderForge.SFN_Tex2d,id:9548,x:32086,y:32582,ptovrint:False,ptlb:Smoke,ptin:_Smoke,varname:node_2493,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8689fac7742124e4ebd4c379ee337bcc,ntxv:0,isnm:False|UVIN-6664-OUT;n:type:ShaderForge.SFN_Tex2d,id:9842,x:31344,y:32559,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_9736,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-7796-UVOUT;n:type:ShaderForge.SFN_Panner,id:7796,x:31163,y:32559,varname:node_7796,prsc:2,spu:-0.3,spv:-0.2|UVIN-9979-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:9979,x:30986,y:32559,varname:node_9979,prsc:2,uv:0;n:type:ShaderForge.SFN_Lerp,id:7491,x:31775,y:32582,varname:node_7491,prsc:2|A-2462-UVOUT,B-263-OUT,T-4484-OUT;n:type:ShaderForge.SFN_ComponentMask,id:263,x:31534,y:32559,varname:node_263,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-9842-RGB;n:type:ShaderForge.SFN_Slider,id:4484,x:31411,y:32747,ptovrint:False,ptlb:node_8867,ptin:_node_8867,varname:node_8867,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1,max:1;n:type:ShaderForge.SFN_TexCoord,id:2462,x:31611,y:32388,varname:node_2462,prsc:2,uv:0;n:type:ShaderForge.SFN_ComponentMask,id:6664,x:31929,y:32582,varname:node_6664,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-7491-OUT;proporder:797-9548-9842-4484;pass:END;sub:END;*/

Shader "Shader Forge/Shd_Waves" {
    Properties {
        _TintColor ("Color", Color) = (0.5,0.5,0.5,1)
        _Smoke ("Smoke", 2D) = "white" {}
        _Noise ("Noise", 2D) = "white" {}
        _node_8867 ("node_8867", Range(0, 1)) = 0.1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _TintColor;
            uniform sampler2D _Smoke; uniform float4 _Smoke_ST;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _node_8867;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_6567 = _Time + _TimeEditor;
                float2 node_7796 = (i.uv0+node_6567.g*float2(-0.3,-0.2));
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(node_7796, _Noise));
                float2 node_6664 = lerp(i.uv0,_Noise_var.rgb.rg,_node_8867).rg;
                float4 _Smoke_var = tex2D(_Smoke,TRANSFORM_TEX(node_6664, _Smoke));
                float3 emissive = (_Smoke_var.rgb*i.vertexColor.rgb*_TintColor.rgb*2.0);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,(_Smoke_var.a*i.vertexColor.a*_TintColor.a));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
