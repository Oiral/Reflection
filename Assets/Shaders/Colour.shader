// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33268,y:32765,varname:node_3138,prsc:2|emission-7800-OUT;n:type:ShaderForge.SFN_Color,id:151,x:32131,y:32809,ptovrint:False,ptlb:Colour,ptin:_Colour,varname:node_151,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:9654,x:32037,y:33039,ptovrint:False,ptlb:Colour2,ptin:_Colour2,varname:node_9654,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Tex2d,id:9172,x:32036,y:33312,ptovrint:False,ptlb:Image,ptin:_Image,varname:node_9172,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:1,isnm:False;n:type:ShaderForge.SFN_RgbToHsv,id:5603,x:32854,y:32984,varname:node_5603,prsc:2|IN-3271-OUT;n:type:ShaderForge.SFN_Hue,id:8808,x:32966,y:32876,varname:node_8808,prsc:2|IN-5603-VOUT;n:type:ShaderForge.SFN_Multiply,id:3270,x:32615,y:32844,varname:node_3270,prsc:2|A-151-RGB,B-967-OUT;n:type:ShaderForge.SFN_Vector1,id:967,x:32399,y:32807,varname:node_967,prsc:2,v1:0.1;n:type:ShaderForge.SFN_OneMinus,id:739,x:32540,y:33288,varname:node_739,prsc:2|IN-9172-RGB;n:type:ShaderForge.SFN_Lerp,id:7800,x:32879,y:33194,varname:node_7800,prsc:2|A-8808-OUT,B-9654-RGB,T-739-OUT;n:type:ShaderForge.SFN_Multiply,id:3271,x:32637,y:32997,varname:node_3271,prsc:2|A-3270-OUT,B-9172-RGB;proporder:151-9654-9172;pass:END;sub:END;*/

Shader "Shader Forge/Colour" {
    Properties {
        _Colour ("Colour", Color) = (0.5,0.5,0.5,1)
        _Colour2 ("Colour2", Color) = (0,0,0,1)
        _Image ("Image", 2D) = "gray" {}
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
            uniform float4 _Colour;
            uniform float4 _Colour2;
            uniform sampler2D _Image; uniform float4 _Image_ST;
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
                float3 node_3271 = ((_Colour.rgb*0.1)*_Image_var.rgb);
                float4 node_5603_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_5603_p = lerp(float4(float4(node_3271,0.0).zy, node_5603_k.wz), float4(float4(node_3271,0.0).yz, node_5603_k.xy), step(float4(node_3271,0.0).z, float4(node_3271,0.0).y));
                float4 node_5603_q = lerp(float4(node_5603_p.xyw, float4(node_3271,0.0).x), float4(float4(node_3271,0.0).x, node_5603_p.yzx), step(node_5603_p.x, float4(node_3271,0.0).x));
                float node_5603_d = node_5603_q.x - min(node_5603_q.w, node_5603_q.y);
                float node_5603_e = 1.0e-10;
                float3 node_5603 = float3(abs(node_5603_q.z + (node_5603_q.w - node_5603_q.y) / (6.0 * node_5603_d + node_5603_e)), node_5603_d / (node_5603_q.x + node_5603_e), node_5603_q.x);;
                float3 node_8808 = saturate(3.0*abs(1.0-2.0*frac(node_5603.b+float3(0.0,-1.0/3.0,1.0/3.0)))-1);
                float3 node_739 = (1.0 - _Image_var.rgb);
                float3 emissive = lerp(node_8808,_Colour2.rgb,node_739);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
