// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32876,y:32712,varname:node_2865,prsc:2|emission-2959-OUT,alpha-2723-OUT;n:type:ShaderForge.SFN_Tex2d,id:7736,x:31153,y:32543,ptovrint:True,ptlb:Base Color,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9a7f9c930a3fd644682ea6cd771d8020,ntxv:1,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2959,x:32643,y:32794,varname:node_2959,prsc:2|A-7781-OUT,B-2723-OUT;n:type:ShaderForge.SFN_Add,id:7781,x:32406,y:32546,varname:node_7781,prsc:2|A-2114-OUT,B-1619-OUT;n:type:ShaderForge.SFN_Add,id:2723,x:32415,y:32858,varname:node_2723,prsc:2|A-1619-OUT,B-6405-OUT;n:type:ShaderForge.SFN_Vector1,id:4435,x:32101,y:32469,varname:node_4435,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Multiply,id:975,x:31860,y:32640,varname:node_975,prsc:2|A-8292-OUT,B-8594-OUT;n:type:ShaderForge.SFN_Multiply,id:8292,x:31612,y:32640,varname:node_8292,prsc:2|A-8037-RGB,B-1955-OUT;n:type:ShaderForge.SFN_Color,id:8037,x:31612,y:32457,ptovrint:False,ptlb:node_8037,ptin:_node_8037,varname:node_8037,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.3,c2:0.8,c3:0.9,c4:1;n:type:ShaderForge.SFN_Desaturate,id:1955,x:31385,y:32656,varname:node_1955,prsc:2|COL-7736-RGB,DES-2208-OUT;n:type:ShaderForge.SFN_Slider,id:2208,x:31050,y:32773,ptovrint:False,ptlb:amount,ptin:_amount,varname:node_2208,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Lerp,id:8594,x:31612,y:32885,varname:node_8594,prsc:2|A-5501-OUT,B-6337-OUT,T-1592-OUT;n:type:ShaderForge.SFN_Vector1,id:5501,x:31593,y:32805,varname:node_5501,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:6337,x:31332,y:32912,varname:node_6337,prsc:2|A-8732-OUT,B-1592-OUT;n:type:ShaderForge.SFN_Vector1,id:1592,x:31332,y:33077,varname:node_1592,prsc:2,v1:2;n:type:ShaderForge.SFN_RemapRange,id:8732,x:31098,y:32912,varname:node_8732,prsc:2,frmn:0,frmx:1,tomn:0.5,tomx:1|IN-6987-OUT;n:type:ShaderForge.SFN_Noise,id:6652,x:30715,y:32919,varname:node_6652,prsc:2|XY-4293-OUT;n:type:ShaderForge.SFN_Multiply,id:4293,x:30555,y:32919,varname:node_4293,prsc:2|A-2110-UVOUT,B-1872-TSL;n:type:ShaderForge.SFN_Slider,id:6405,x:32337,y:33051,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_6405,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6310679,max:1;n:type:ShaderForge.SFN_Multiply,id:1619,x:32193,y:32804,varname:node_1619,prsc:2|A-3293-OUT,B-617-OUT;n:type:ShaderForge.SFN_Multiply,id:2114,x:32142,y:32544,varname:node_2114,prsc:2|A-4435-OUT,B-975-OUT;n:type:ShaderForge.SFN_Slider,id:617,x:31977,y:33008,ptovrint:False,ptlb:scanline opacity,ptin:_scanlineopacity,varname:node_617,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Power,id:3293,x:31977,y:32804,varname:node_3293,prsc:2|VAL-9046-OUT,EXP-5606-OUT;n:type:ShaderForge.SFN_Frac,id:9046,x:31626,y:33042,varname:node_9046,prsc:2|IN-5958-OUT;n:type:ShaderForge.SFN_Vector1,id:5606,x:31784,y:33076,varname:node_5606,prsc:2,v1:10;n:type:ShaderForge.SFN_OneMinus,id:7625,x:31399,y:33314,varname:node_7625,prsc:2|IN-1102-OUT;n:type:ShaderForge.SFN_Add,id:1102,x:31222,y:33314,varname:node_1102,prsc:2|A-3921-OUT,B-923-OUT;n:type:ShaderForge.SFN_Multiply,id:3921,x:31024,y:33314,varname:node_3921,prsc:2|A-6522-OUT,B-9817-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:2584,x:30607,y:33192,varname:node_2584,prsc:2;n:type:ShaderForge.SFN_Append,id:9817,x:30807,y:33428,varname:node_9817,prsc:2|A-9511-OUT,B-6379-OUT;n:type:ShaderForge.SFN_Vector1,id:9511,x:30620,y:33381,varname:node_9511,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:6379,x:30620,y:33488,cmnt:canLine,varname:node_6379,prsc:2,v1:1;n:type:ShaderForge.SFN_Append,id:4663,x:30807,y:33650,varname:node_4663,prsc:2|A-126-OUT,B-9600-OUT;n:type:ShaderForge.SFN_Vector1,id:126,x:30640,y:33650,varname:node_126,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:9600,x:30640,y:33727,varname:node_9600,prsc:2,v1:3;n:type:ShaderForge.SFN_Append,id:6522,x:30807,y:33211,varname:node_6522,prsc:2|A-2584-X,B-2584-Y;n:type:ShaderForge.SFN_ComponentMask,id:5958,x:31592,y:33314,varname:node_5958,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-7625-OUT;n:type:ShaderForge.SFN_ScreenPos,id:2110,x:30370,y:32819,varname:node_2110,prsc:2,sctp:0;n:type:ShaderForge.SFN_Time,id:1872,x:30370,y:32980,varname:node_1872,prsc:2;n:type:ShaderForge.SFN_Time,id:37,x:30795,y:33803,varname:node_37,prsc:2;n:type:ShaderForge.SFN_Multiply,id:923,x:31021,y:33708,varname:node_923,prsc:2|A-4663-OUT,B-37-TSL;n:type:ShaderForge.SFN_Multiply,id:6987,x:30921,y:32919,varname:node_6987,prsc:2|A-6652-OUT,B-3797-OUT;n:type:ShaderForge.SFN_Vector1,id:3797,x:30885,y:33067,varname:node_3797,prsc:2,v1:5;proporder:7736-8037-2208-6405-617;pass:END;sub:END;*/

Shader "Shader Forge/logo" {
    Properties {
        _MainTex ("Base Color", 2D) = "gray" {}
        _node_8037 ("node_8037", Color) = (0.3,0.8,0.9,1)
        _amount ("amount", Range(0, 1)) = 1
        _Opacity ("Opacity", Range(0, 1)) = 0.6310679
        _scanlineopacity ("scanline opacity", Range(0, 1)) = 0.5
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
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _node_8037;
            uniform float _amount;
            uniform float _Opacity;
            uniform float _scanlineopacity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 projPos : TEXCOORD3;
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
////// Lighting:
////// Emissive:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 node_1872 = _Time;
                float2 node_4293 = ((sceneUVs * 2 - 1).rg*node_1872.r);
                float2 node_6652_skew = node_4293 + 0.2127+node_4293.x*0.3713*node_4293.y;
                float2 node_6652_rnd = 4.789*sin(489.123*(node_6652_skew));
                float node_6652 = frac(node_6652_rnd.x*node_6652_rnd.y*(1+node_6652_skew.x));
                float node_1592 = 2.0;
                float4 node_37 = _Time;
                float2 node_7625 = (1.0 - ((float2(i.posWorld.r,i.posWorld.g)*float2(1.0,1.0))+(float2(0.0,3.0)*node_37.r)));
                float node_1619 = (pow(frac(node_7625.g),10.0)*_scanlineopacity);
                float node_2723 = (node_1619+_Opacity);
                float3 emissive = (((1.5*((_node_8037.rgb*lerp(_MainTex_var.rgb,dot(_MainTex_var.rgb,float3(0.3,0.59,0.11)),_amount))*lerp(1.0,(((node_6652*5.0)*0.5+0.5)*node_1592),node_1592)))+node_1619)*node_2723);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,node_2723);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _node_8037;
            uniform float _amount;
            uniform float _Opacity;
            uniform float _scanlineopacity;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float4 projPos : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 node_1872 = _Time;
                float2 node_4293 = ((sceneUVs * 2 - 1).rg*node_1872.r);
                float2 node_6652_skew = node_4293 + 0.2127+node_4293.x*0.3713*node_4293.y;
                float2 node_6652_rnd = 4.789*sin(489.123*(node_6652_skew));
                float node_6652 = frac(node_6652_rnd.x*node_6652_rnd.y*(1+node_6652_skew.x));
                float node_1592 = 2.0;
                float4 node_37 = _Time;
                float2 node_7625 = (1.0 - ((float2(i.posWorld.r,i.posWorld.g)*float2(1.0,1.0))+(float2(0.0,3.0)*node_37.r)));
                float node_1619 = (pow(frac(node_7625.g),10.0)*_scanlineopacity);
                float node_2723 = (node_1619+_Opacity);
                o.Emission = (((1.5*((_node_8037.rgb*lerp(_MainTex_var.rgb,dot(_MainTex_var.rgb,float3(0.3,0.59,0.11)),_amount))*lerp(1.0,(((node_6652*5.0)*0.5+0.5)*node_1592),node_1592)))+node_1619)*node_2723);
                
                float3 diffColor = float3(0,0,0);
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, 0, specColor, specularMonochrome );
                o.Albedo = diffColor;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
