// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33190,y:32780,varname:node_3138,prsc:2|emission-4335-OUT;n:type:ShaderForge.SFN_Color,id:613,x:32211,y:32810,ptovrint:False,ptlb:Colour Day,ptin:_ColourDay,varname:node_613,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Tex2d,id:8349,x:32360,y:33293,ptovrint:False,ptlb:Image,ptin:_Image,varname:node_8349,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_TexCoord,id:68,x:31946,y:33073,varname:node_68,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:5527,x:32753,y:32853,varname:node_5527,prsc:2|A-9961-OUT,B-8349-RGB;n:type:ShaderForge.SFN_Add,id:4335,x:33009,y:32869,varname:node_4335,prsc:2|A-5527-OUT,B-6665-OUT;n:type:ShaderForge.SFN_RemapRange,id:2969,x:32625,y:33311,varname:node_2969,prsc:2,frmn:0,frmx:1,tomn:1,tomx:0|IN-8349-R;n:type:ShaderForge.SFN_Multiply,id:6665,x:32890,y:33235,varname:node_6665,prsc:2|A-2969-OUT,B-9798-OUT;n:type:ShaderForge.SFN_Slider,id:9798,x:32763,y:33409,ptovrint:False,ptlb:Saturation Intensity,ptin:_SaturationIntensity,varname:node_9798,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:0;n:type:ShaderForge.SFN_Color,id:3769,x:32211,y:32987,ptovrint:False,ptlb:Colour Night,ptin:_ColourNight,varname:node_3769,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Lerp,id:9961,x:32569,y:32687,varname:node_9961,prsc:2|A-613-RGB,B-3769-RGB,T-5074-OUT;n:type:ShaderForge.SFN_Slider,id:9478,x:32003,y:33252,ptovrint:False,ptlb:Day-Night,ptin:_DayNight,varname:node_9478,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Lerp,id:5074,x:32415,y:33074,varname:node_5074,prsc:2|A-9080-OUT,B-68-V,T-9478-OUT;n:type:ShaderForge.SFN_OneMinus,id:9080,x:32174,y:33142,varname:node_9080,prsc:2|IN-68-V;proporder:613-3769-9478-8349-9798;pass:END;sub:END;*/

Shader "Shader Forge/BackgroundSimpleColours" {
    Properties {
        _ColourDay ("Colour Day", Color) = (0.5,0.5,0.5,1)
        _ColourNight ("Colour Night", Color) = (0.5,0.5,0.5,1)
        _DayNight ("Day-Night", Range(0, 1)) = 0
        _Image ("Image", 2D) = "white" {}
        _SaturationIntensity ("Saturation Intensity", Range(-1, 0)) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _ColourDay;
            uniform sampler2D _Image; uniform float4 _Image_ST;
            uniform float _SaturationIntensity;
            uniform float4 _ColourNight;
            uniform float _DayNight;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 _Image_var = tex2D(_Image,TRANSFORM_TEX(i.uv0, _Image));
                float3 emissive = ((lerp(_ColourDay.rgb,_ColourNight.rgb,lerp((1.0 - i.uv0.g),i.uv0.g,_DayNight))+_Image_var.rgb)+((_Image_var.r*-1.0+1.0)*_SaturationIntensity));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
