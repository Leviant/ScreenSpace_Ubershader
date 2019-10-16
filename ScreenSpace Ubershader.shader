
// Copyright © 2019 Leviant
// Email: leviant@yandex.ru
// Discord: Leviant#8796
// Discord server: https://discord.gg/MdykFMf
// License: http://opensource.org/licenses/MIT
// GitHub: https://github.com/Leviant/ScreenSpace_Ubershader
// Version: 2.8.1 (16.10.2019)

Shader "Leviant's Shaders/ScreenSpace Ubershader v2.8"
{
	Properties 
	{
		//Main Settings
		[Toggle(_)]Particle_Render("Main/Setup for Particle system", Int) = 0
		//Fade Settings
		_MinRange ("Main/Start fading", Float) = 2.0
		_MaxRange ("Main/End distance", Float) = 10.0

		//Glitch
		[Toggle(_)]Glitch("Glitch/Active", Int) = 0
		_BlockSize("Glitch/Block size", Float) = 24.0
		_BlockGlitch("Glitch/Block Glitch", Range(0, 1)) = 0.25
		_LineGlitch("Glitch/Line Glitch", Range(0, 1)) = 0.5
		_UPS("Glitch/Glitches per second", Float) = 15.0
		_ActiveTime("Glitch/Active Time", Range(0, 1)) = 0.4
		_Period("Glitch/Period Time", Float) = 6.0

		//Zoom Settings
		[KeywordEnum(OFF, Simple scale, Zoom, Zoom falloff, Centering, Gravitational lens)]Magnification("Zoom/Mode", Int) = 0
		[PowerSlider(2.0)]_Magnification("Zoom/Scale", Range (-1, 1)) = 0.1
		[PowerSlider(2.0)]_Gravitation("Zoom/Gravitation range", Range (0, 100.0)) = 1.0
		_AngleStartFade("Zoom/Angle range", Range (0, 1)) = 0.25
		_MaxAngle("Zoom/Max angle range", Range (0, 1)) = 0.5
		
		//Girlscam
		_SizeGirls("Girlscam/Size", Range(0, 1)) = 0
		_TimeGirls("Girlscam/Time", Range(0, 1)) = 1

		//Rotation
		[Toggle(_)]ScreenRotation("Rotation/Active", Int) = 0
		_ScreenRotation("Rotation/Angle", Float) = 0.1
		_ScreenRotationSpeed("Rotation/Shake speed", Float) = 2.0

		//Screen Transform
		_ScreenHorizontalFlip("Flip/Horizontal", Range(0.0, 1.0)) = 0
		_ScreenVerticalFlip("Flip/Vertical", Range(0.0, 1.0)) = 0

		//Screen Shake
		[Toggle(_)]Shake("Screen Shake/Active", Int) = 0
		[Normal][NoScaleOffset]_ShakeTex("Screen Shake/Normalmap", 2D) = "bump" {}
		[PowerSlider(2.0)]_SIntensity_X ("Screen Shake/Intensity X", Range(0, 1)) = 0.01
		[PowerSlider(2.0)]_SIntensity_Y ("Screen Shake/Intensity Y", Range(0, 1)) = 0.01
		_ShakeScroll("Screen Shake/Texture Scroll(XY)", Vector) = (2, 0.02, 0, 0)
		_ShakeWave("Screen Shake/Wave offset(XY)", Vector) = (0.01, 0.01, 0, 0)
		_ShakeWaveSpeed("Screen Shake/Wave speed(XY)", Vector) = (20, 19, 0, 0)

		//Pixelation
		[Toggle(_)]Pixelization("Pixelation/Active", Int) = 0
		[PowerSlider(2.0)]_PSize_X ("Pixelation/Pixel Width", Range(1.0, 128.0)) = 4.0
		[PowerSlider(2.0)]_PSize_Y ("Pixelation/Pixel Height", Range(1.0, 128.0)) = 4.0

		//Screen Distortion
		[Toggle(_)]Distorsion("Screen Distorsion/Active", Int) = 0
		[Toggle(_)]Wave_Distorsion("Screen Distorsion/Wave Active", Int) = 1
		[Toggle(_)]Texture_Distorsion("Screen Distorsion/Texture Active", Int) = 0
		[Normal]_DistorsionTex("Screen Distorsion/Normalmap", 2D) = "bump" {}
		[PowerSlider(2.0)]_DIntensity_X ("Screen Distorsion/Horizontal", Range(0, 10)) = 0.01
		[PowerSlider(2.0)]_DIntensity_Y ("Screen Distorsion/Vertical", Range(0, 10)) = 0.01
		_DistorsionScroll("Screen Distorsion/Scroll Texture(XY)", Vector) = (0, 0, 0, 0)
		_DistorsionWave("Screen Distorsion/Wave offset(XYZ)", Vector) = (0.01, 0.01, 1, 0)
		_DistorsionWaveSpeed("Screen Distorsion/Wave speed(XYZ)", Vector) = (2.6, -3.1, 1, 0)
		_DistorsionWaveDensity("Screen Distorsion/Wave density(XYZ)", Vector) = (8.4, 3, 1, 0)
		
		//Blur Settings
		[KeywordEnum(OFF, Horizontal, Star, Circle, Radial)]Blur("Blur/Mode", Int) = 0
		[Toggle(_)]Blur_Distorsion("Blur/Blur with Distorsion", Int) = 0
		[HDR]_BlurColor("Blur/Blur Color (RGB)", Color) = (1,1,1,1)
		[PowerSlider(2.0)]_BlurRange ("Blur/Offset", Range(0, 1)) = 0.01
		_BlurRotation ("Blur/Rotation", Float) = 0.0
		_BlurRotationSpeed("Blur/Rotation speed", Float) = 0
		_BlurIterations ("Blur/Samples", Range(1, 128)) = 8.0
		_BlurCenterOffset("Blur/Center offset(XY)", Vector) = (0, 0, 0, 0)
		_BlurMask("Blur/Mask effect", Range(0.0, 1.0)) = 0.5

		//Chromatic Aberration
		[KeywordEnum(OFF, Vector, Radial)]Chromatic_Aberration("Chromatic Aberration/Mode", Int) = 0
		[KeywordEnum(Simple split, Multisampling)]Aberration_Quality("Chromatic Aberration/Quality", Int) = 1
		[Toggle(_)]CA_Distorsion("Chromatic Aberration/Use Distorsion", Int) = 0
		[PowerSlider(2.0)]_CA_amplitude("Chromatic Aberration/Offset", Range(0.0, 1.0)) = 0.015
		_CA_iterations ("Chromatic Aberration/Samples", Range(1, 128.0)) = 8.0
		_CA_speed("Chromatic Aberration/Animation Speed", Float) = 0.0
		_CA_direction("Chromatic Aberration/Vector direction", Vector) = (1, 0, 0, 0)
		_CA_factor ("Chromatic Aberration/Effect", Range(0, 1.0)) = 1.0
		_CA_centerOffset("Chromatic Aberration/Radial center offset", Vector) = (0, 0, 0, 0)
		_CA_mask("Chromatic Aberration/Mask effect", Range(0.0, 1.0)) = 0.5

		//Neon
		[Toggle(_)]Neon("Neon/Active", Int) = 0
		[HDR]_NeonColor("Neon/Tint (RGB)", Color) = (1, 1, 1, 1)
		_NeonColorAlpha("Neon/Intensity", Range(0.0, 1.0)) = 1.0
		_NeonOrigColor("Neon/Background Color (RGB)", Color) = (0.25, 0.25, 0.25, 1)
		_NeonOrigColorAlpha("Neon/Background mix", Range(0.0, 1.0)) = 1.0
		_NeonBrightness("Neon/Brightness", Float) = 3.0
		_NeonPosterization("Neon/Posterization", Range (0.0, 1.0)) = 1.0
		_NeonWidth("Neon/Width", Float) = 1.5
		_NeonGlow("Neon/Glow", Range (0.0, 1.0)) = 1.0

		//HSV Colour Space
		[Toggle(_)]HSV_Selection("HSV Selection/Active", Int) = 0
		_TargetColor("HSV Selection/Select color (RGB)", Color) = (1,0,0,1)
		_HueRange("HSV Selection/Hue range", Range(0, 0.5)) = 0.02
		_SaturationRange("HSV Selection/Saturation range", Range(0, 1)) = 0.4
		_LightnessRange("HSV Selection/Lightness range", Range(0, 1)) = 1
		_HueSmoothRange("HSV Selection/Hue fade", Range(0, 0.5)) = 0.02
		_SaturationSmoothRange("HSV Selection/Saturation fade", Range(0, 1)) = 0.1
		_LightnessSmoothRange("HSV Selection/Lightness fade", Range(0, 1)) = 1
		[Toggle(_)]HSV_Desaturate_Selected("HSV Selection/Desaturate", Int) = 1

		//Extra Settings
		[Toggle(_)]HSV_Transform("HSV Transform/Active", Int) = 0
		_TransformColor("HSV Transform/Color (RGB)", Color) = (0, 0, 1, 1)
		_Hue("HSV Transform/Hue value", Range(0, 1)) = 1.0
		_HueAnimationSpeed("HSV Transform/Hue Animation Speed", Float) = 0.0
		_Saturation("HSV Transform/Saturation value", Range(0, 1)) = 0
		_Lightness("HSV Transform/Lightness value", Range(0, 1)) = 0

		//Colour Correction
		[Toggle(_)]Color_Tint("Color Correction/Active", Int) = 0
		[Toggle(_)]ACES_Tonemapping("Color Correction/ACES Tonemapping", Int) = 0
		[HDR]_EmissionColor("Color Correction/Emission color (RGB)", Color) = (0, 0, 0, 1)
		[HDR]_Color("Color Correction/Mix color (RGB)", Color) = (0, 0, 0, 0)
		_ColorAlpha("Color Correction/Mix factor", Range(0.0, 1.0)) = 0.0
		_Grayscale("Color Correction/Grayscale", Range (0.0, 1.0)) = 0.0
		_Contrast("Color Correction/Contrast", Vector) = (1.0, 1.0, 1.0, 1.0)
		_Gamma("Color Correction/Gamma", Vector) = (1.0, 1.0, 1.0, 1.0)
		_Brightness("Color Correction/Brightness", Vector) = (1.0, 1.0, 1.0, 1.0)
		_RedInvert("Color Correction/Red Invert", Range (0.0, 1.0)) = 0.0
		_GreenInvert("Color Correction/Green Invert", Range (0.0, 1.0)) = 0.0
		_BlueInvert("Color Correction/Blue Invert", Range (0.0, 1.0)) = 0.0

		//Posterization
		[Toggle(_)]Posterization("Posterization/Active", Int) = 0
		[PowerSlider(2.0)]_PosterizationSteps("Posterization/Gradient steps", Range(1.0, 256.0)) = 16.0
		
		//Dithering
		[Toggle(_)]Dithering("Dithering/Active", Int) = 0
		[NoScaleOffset]_DitheringMask("Dithering/Mask", 2D) = "white" {}

		//Overlay Texture
		[Toggle(_)]Overlay_Texture("Overlay/Active", Int) = 0
		[Toggle(_)]Overlay_Grid("Overlay/Image grid", Int) = 1
		_OverlayTex("Overlay/Texture", 2D) = "white" {}
		[HDR]_OverlayTint("Overlay/Tint (RGB)", Color) = (1, 1, 1, 1)
		_OverlayOpaque("Overlay/Opaque", Range(0, 1)) = 0.0
		_OverlayTransparent("Overlay/Transparent", Range(0, 2)) = 1.0
		_OverlayRotation("Overlay/Rotation", Float) = 0
		_OverlayScroll("Overlay/Scroll Vector", Vector) = (0, 1, 0, 0)
		[Toggle(_)]Overlay_Texture_Sheet("Overlay/Texture sheet enable", Int) = 0
		
		_OverlayColumns("Overlay/Columns", Int) = 4
		_OverlayRows("Overlay/Rows", Int) = 4
		_OverlayStartFrame("Overlay/Start frame", Int) = 0
		_OverlayTotalFrames("Overlay/Total frames", Int) = 16
		_OverlayAnimationSpeed("Overlay/Animation speed", Float) = 0.8

		//Static
		[Toggle(_)]Static_Noise("Static noise/Active", Int) = 0
		[HDR]_StaticColour("Static noise/Color", Color) = (1,1,1,1)
		_StaticIntensity("Static noise/Intensity", Range(-1, 1)) = -0.34
		_StaticAlpha("Static noise/Alpha", Range(0,1)) = 0.17
		_StaticBrightness("Static noise/Brightness", Range(0, 1)) = 1.0
		[HideInInspector]_MaskAmount("Static noise/Mix Amount (WIP)", Range(0,1)) = 0

		//Vignette
		[Toggle(_)]Vignette("Vignette/Active", Int) = 0
		_VignetteColor("Vignette/Color (RGB)", Color) = (0, 0, 0, 1)
		_VignetteAlpha("Vignette/Transparent", Range(0, 1)) = 0.15
		_VignetteWidth("Vignette/Width", Float) = 0.5
		_VignetteShape("Vignette/Shape", Range(-1, 1)) = 0.5
		_VignetteRounding("Vignette/Rounding", Range(0, 1)) = 0.5

		//Mask Texture
		[Toggle(_)]Mask_Texture("Mask/Active", Int) = 0
		[Toggle(_)]Mask_Multisampling("Mask/Multisampling", Int) = 0
		[Toggle(_)]Mask_Noise("Mask/Generate Noise", Int) = 0
		_MaskTex("Mask/Texture", 2D) = "white" {}
		[HDR]_MaskColor("Mask/Mix color (RGB)", Color) = (1, 1, 1, 0)
		_MaskAlpha("Mask/Color mix", Range(0, 1)) = 0.0
		_MaskScroll("Mask/Scroll Vector", Vector) = (0, 0, 0, 0)

		[HideInInspector]_Fold("_Fold", Int) = 0
	}
	SubShader 
	{
		Tags { "Queue"="Overlay+2" "RenderType"="Overlay" "IgnoreProjector" = "True" "ForceNoShadowCasting" = "True" "LightMode" = "Always"}
		Cull Off
		Lighting Off
		ZTest Always
		ZWrite Off
		GrabPass {"_UberShaderGrabTexture"}

		Pass {
			HLSLPROGRAM
			//#pragma enable_d3d11_debug_symbols
			#pragma target 4.0
			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			#define MAGNIFICATION_SIMPLE_SCALE 1 
			#define MAGNIFICATION_ZOOM 2 
			#define MAGNIFICATION_ZOOM_FALLOFF 3 
			#define MAGNIFICATION_CENTERING 4
			#define MAGNIFICATION_GRAVITATIONAL_LENS 5

			#define BLUR_HORIZONTAL 1
			#define BLUR_STAR 2
			#define BLUR_CIRCLE 3
			#define BLUR_RADIAL 4

			#define CHROMATIC_ABERRATION_VECTOR 1
			#define CHROMATIC_ABERRATION_RADIAL 2

			#define ABERRATION_QUALITY_SIMPLE_SPLIT 0
			#define ABERRATION_QUALITY_MULTISAMPLING 1

			struct appdata
			{
				float4 vertex : POSITION;
				float3 texcoord : TEXCOORD0; //xyz - Particle center
			};

			struct v2f 
			{
				float4 pos : SV_POSITION;
				float4 grabPos : TEXCOORD0;
				float4 uv : TEXCOORD1;     //[0 .. 1] overlayScreenSpace
				float falloff: TEXCOORD2;  //[0 .. 1] shader effect strength
				float3 viewPos : TEXCOORD3;
				float3 viewCenter : TEXCOORD4;
				float3 worldRayDir: TEXCOORD5;
			};
			uniform int Particle_Render;
			uniform int Magnification;
			uniform int ScreenRotation;
			uniform int Shake;
			uniform int Pixelization;
			uniform int Distorsion;
			uniform int Wave_Distorsion;
			uniform int Texture_Distorsion;
			uniform int Blur;
			uniform int Blur_Distorsion;
			uniform int Chromatic_Aberration;
			uniform int Aberration_Quality;
			uniform int CA_Distorsion;
			uniform int Neon;
			uniform int HSV_Selection;
			uniform int HSV_Desaturate_Selected;
			uniform int HSV_Transform;
			uniform int Color_Tint;
			uniform int ACES_Tonemapping;
			uniform int Posterization;
			uniform int Dithering;
			uniform int Overlay_Texture;
			uniform int Overlay_Grid;
			uniform int Overlay_Texture_Sheet;
			uniform int Glitch;
			uniform int Vignette;
			uniform int Static_Noise;
			uniform int Mask_Texture;
			uniform int Mask_Multisampling;
			uniform int Mask_Noise;

			uniform Texture2D _UberShaderGrabTexture;
			uniform sampler2D _NormalizedPass;

			uniform SamplerState linear_mirror_sampler;
			#define grabSampler linear_mirror_sampler

			uniform float4 _UberShaderGrabTexture_TexelSize;

		#ifdef UNITY_SINGLE_PASS_STEREO
			static const float2 factor = float2(0.5, 1.0);
		#else
			static const float2 factor = float2(1.0, 1.0);
		#endif
			uniform float _SizeGirls;
			uniform float _TimeGirls;
			//Falloff
			uniform float _MaxRange;
			uniform float _MinRange;

			uniform sampler2D _DistorsionTex;
			uniform float4 _DistorsionTex_ST;
			uniform float4 _DistorsionTex_TexelSize;
			uniform float2 _DistorsionScroll;
			uniform float3 _DistorsionWave;
			uniform float3 _DistorsionWaveSpeed;
			uniform float3 _DistorsionWaveDensity;
			uniform float _DIntensity_X;
			uniform float _DIntensity_Y;

			uniform float _PSize_X;
			uniform float _PSize_Y;

			uniform float _PosterizationSteps;

			uniform sampler2D _DitheringMask;
			uniform float4 _DitheringMask_TexelSize;

			uniform float _ScreenRotation;
			uniform float _ScreenRotationSpeed;

			uniform sampler2D _ShakeTex;
			uniform float4 _ShakeTex_ST;
			uniform float2 _ShakeWave;
			uniform float2 _ShakeWaveSpeed;
			uniform float2 _ShakeScroll;
			uniform float _SIntensity_X;
			uniform float _SIntensity_Y;

			uniform float _ScreenHorizontalFlip;
			uniform float _ScreenVerticalFlip;

			uniform float _CA_amplitude;
			uniform float _CA_speed;
			uniform float _CA_iterations;
			uniform float _CA_factor;
			uniform float _CA_mask;
			uniform float2 _CA_direction;
			uniform float2 _CA_centerOffset;

			uniform float _BlurRange;
			uniform float _BlurIterations;
			uniform float _BlurRotation;
			uniform float _BlurRotationSpeed;
			uniform float _BlurMask;
			uniform float2 _BlurCenterOffset;
			uniform float3 _BlurColor;

			uniform float _Magnification;
			uniform float _Gravitation;
			uniform float _AngleStartFade;
			uniform float _MaxAngle;

			uniform float3 _EmissionColor;
			uniform float3 _Color;
			uniform float3 _Contrast;
			uniform float3 _Gamma;
			uniform float3 _Brightness;
			uniform float _ColorAlpha;
			uniform float _Grayscale;
			uniform float _RedInvert;
			uniform float _GreenInvert;
			uniform float _BlueInvert;

			uniform float3 _TargetColor;
			uniform float _HueRange;
			uniform float _SaturationRange;
			uniform float _LightnessRange;
			uniform float _HueSmoothRange;
			uniform float _SaturationSmoothRange;
			uniform float _LightnessSmoothRange;

			uniform float3 _TransformColor;
			uniform float _HueAnimationSpeed;
			uniform float _Hue;
			uniform float _Saturation;
			uniform float _Lightness;

			uniform float3 _NeonColor;
			uniform float3 _NeonOrigColor;
			uniform float _NeonColorAlpha;
			uniform float _NeonOrigColorAlpha;
			uniform float _NeonBrightness;
			uniform float _NeonPosterization;
			uniform float _NeonWidth;
			uniform float _NeonGlow;

			uniform sampler2D _OverlayTex;
			uniform float4 _OverlayTex_ST;
			uniform float2 _OverlayScroll;
			uniform float3 _OverlayTint;
			uniform float _OverlayOpaque;
			uniform float _OverlayTransparent;
			uniform float _OverlayRotation;
			uniform uint _OverlayColumns;
			uniform uint _OverlayRows;
			uniform uint _OverlayStartFrame;
			uniform uint _OverlayTotalFrames;
			uniform float _OverlayAnimationSpeed;

			uniform float _BlockSize;
			uniform float _UPS;
			uniform float _BlockGlitch;
			uniform float _LineGlitch;
			uniform float _ActiveTime;
			uniform float _Period;

			uniform float3 _VignetteColor;
			uniform float _VignetteAlpha;
			uniform float _VignetteWidth;
			uniform float _VignetteShape;
			uniform float _VignetteRounding;

			uniform sampler2D _MaskTex;
			uniform float4 _MaskTex_ST;
			uniform float3 _MaskColor;
			uniform float2 _MaskScroll;
			uniform float _MaskAlpha;

			uniform float _MaskAmount;
			uniform float _StaticAlpha;
			uniform float _StaticBrightness;
			uniform float _StaticIntensity;
			uniform float3 _StaticColour;

			bool IsInMirror() //Thanks DocMe ^w^
			{
				return unity_CameraProjection[2][0] != 0.0 || unity_CameraProjection[2][1] != 0.0;
			}

			v2f vert(appdata v) 
			{
				v2f o;
				UNITY_INITIALIZE_OUTPUT(v2f, o);
			#ifdef UNITY_SINGLE_PASS_STEREO
				float3 nonStereoCameraPosition = (unity_StereoWorldSpaceCameraPos[0] + unity_StereoWorldSpaceCameraPos[1])*0.5;
			#else
				float3 nonStereoCameraPosition = _WorldSpaceCameraPos;
			#endif
				float4 viewPos = v.vertex;
				float3 worldCenter;
				float3 viewCenter;
				float dist;
				float angle;
				[branch] if(Particle_Render != 0)
				{
					viewPos.xyz -= v.texcoord;
					worldCenter = v.texcoord;
					viewCenter = UnityObjectToViewPos(worldCenter);
					dist = distance(nonStereoCameraPosition, v.texcoord);
					angle = 1 - acos(dot(normalize(v.texcoord - nonStereoCameraPosition), UNITY_MATRIX_V[2])) / UNITY_PI;
				}
				else
				{
					worldCenter = mul(unity_ObjectToWorld, float4(0,0,0,1));
					viewCenter = UnityObjectToViewPos(float3(0,0,0));
					dist = distance(nonStereoCameraPosition, worldCenter);
					angle = 1 - acos(dot(normalize(worldCenter - nonStereoCameraPosition), UNITY_MATRIX_V[2])) / UNITY_PI;
				}
				
				if(dist > _MaxRange || IsInMirror())
				{
					o.pos = float4(0, 0, -2, 1);
					return o;
				}
				float4 viewPos2 = viewPos;
				float4 clipPos = UnityViewToClipPos(viewPos);
				o.grabPos = ComputeGrabScreenPos(clipPos);
				o.falloff = smoothstep(1, 0, (clamp(dist, _MinRange, _MaxRange) - _MinRange) / (_MaxRange - _MinRange));
				o.viewCenter = viewCenter;
				o.viewPos = viewPos;
				[branch] switch(Magnification)
				{
				case MAGNIFICATION_SIMPLE_SCALE:
					float4 grabPosForward = ComputeGrabScreenPos(UnityViewToClipPos(float4(0, 0, 1, 1)));
					_Magnification = 2.0 - 2.0 / (_Magnification + 1.0);
					o.grabPos.xy = lerp(o.grabPos.xy, grabPosForward / grabPosForward.w * o.grabPos.w ,  o.falloff * _Magnification);
					break;
				case MAGNIFICATION_ZOOM:
					{
						float4 clipCenter = UnityViewToClipPos(viewCenter);
						float4 grabPosCenter = ComputeGrabScreenPos(clipCenter);
				
						float borderFalloff = grabPosCenter.w > 0 ? 1 : 0;
						float2 grabPosCenterNormalized = grabPosCenter.xy / max(0.0001, grabPosCenter.w);
						float4 uv = ComputeNonStereoScreenPos(clipCenter);
						uv /= uv.w;
						borderFalloff *= step(0, uv.x)*step(0, uv.y)*step(-1, -uv.x)*step(-1, -uv.y); // check in range [-1 .. 1]
						_Magnification = 2.0 - 2.0 / (_Magnification + 1.0);
						o.grabPos.xy = lerp(o.grabPos.xy, grabPosCenterNormalized * o.grabPos.w, borderFalloff * o.falloff * _Magnification);
						break;
					}
				case MAGNIFICATION_ZOOM_FALLOFF:
					{
						//float angle = 1 - acos(normalize(viewCenter).z) / UNITY_PI;
						float linearRange = (clamp(angle, _AngleStartFade, _MaxAngle) - _MaxAngle) / (_AngleStartFade - _MaxAngle);
						float angleFalloff = smoothstep(0, 1, linearRange);

						float4 clipCenter = UnityViewToClipPos(viewCenter);
						float4 grabPosCenter = ComputeGrabScreenPos(clipCenter);
						float2 grabPosCenterNormalized = grabPosCenter / grabPosCenter.w;
						_Magnification = 2.0 - 2.0 / (_Magnification + 1.0);
						o.grabPos.xy = lerp(o.grabPos.xy, grabPosCenterNormalized * o.grabPos.w, angleFalloff * o.falloff * _Magnification);
						break;
					}
				case MAGNIFICATION_CENTERING:
					{
						float3 v_forward = normalize(-viewCenter);
						//float angle = acos(v_forward.z) / UNITY_PI;
						float linearRange = (clamp(angle, _AngleStartFade, _MaxAngle) - _MaxAngle) / (_AngleStartFade - _MaxAngle);
						float angleFalloff = smoothstep(0, 1, linearRange);

						v_forward = lerp(float3(0, 0, 1), v_forward, angleFalloff * o.falloff);
						float3 v_up = float3(0, 1, 0);
						float3 v_right = -normalize(cross(v_forward, v_up));
						v_up = -normalize(cross(v_right, v_forward));
				
						float3x3 matrix_v = float3x3(v_right, v_up, v_forward);
						viewPos2.xyz = mul(matrix_v, viewPos2.xyz);

						float4 clipCenter = UnityViewToClipPos(viewCenter);
						float4 grabPosCenter = ComputeGrabScreenPos(clipCenter);
						float2 grabPosCenterNormalized = grabPosCenter / grabPosCenter.w;

						o.grabPos.xy = lerp(o.grabPos.xy, grabPosCenterNormalized * o.grabPos.w, angleFalloff * o.falloff * _Magnification);
						break;
					}
				}

				[branch] if(ScreenRotation > 0)
				{
					float s, c;
					sincos(_ScreenRotation*cos(_Time.y*_ScreenRotationSpeed*UNITY_TWO_PI)*o.falloff, s, c);
					viewPos2.xy = mul(float2x2(c, -s, s, c), viewPos2.xy);
				}

				o.grabPos.xy = lerp(o.grabPos.xy, o.grabPos.ww - o.grabPos.xy, float2(_ScreenHorizontalFlip, _ScreenVerticalFlip) * o.falloff);
				[branch] if(Shake > 0)
				{
					float2 shake = UnpackNormal(tex2Dlod(_ShakeTex, float4(_Time.x * _ShakeScroll.xy, 0, 0)));
					shake *= float2(_SIntensity_X, _SIntensity_Y);
					shake += _ShakeWave.xy * float2(cos(_Time.y * _ShakeWaveSpeed.x), sin(_Time.y * _ShakeWaveSpeed.y));
					shake.x *= _ScreenParams.y / _ScreenParams.x;
					o.grabPos.xy += o.grabPos.w * shake * o.falloff * factor.x;
				}
				o.worldRayDir = mul((float3x3)UNITY_MATRIX_I_V, viewPos2);
				o.pos = UnityViewToClipPos(viewPos2);
				o.uv = ComputeNonStereoScreenPos(o.pos);

				return o;
			}

			// Hash without Sine
			// https://www.shadertoy.com/view/4djSRW

			#define HASHSCALE1 443.8975
			#define HASHSCALE3 float3(443.897, 441.423, 437.195)
			#define HASHSCALE4 float4(443.897, 441.423, 437.195, 444.129)

			float hash11(float p)
			{
				p = frac(p * .1031);
				p *= p + 33.33;
				p *= p + p;
				return frac(p);
			}
			float hash12(float2 p)
			{
				float3 p3  = frac(float3(p.xyx) * HASHSCALE1);
				p3 += dot(p3, p3.yzx + 19.19);
				return frac((p3.x + p3.y) * p3.z);
			}
			float hash13(float3 p3)
			{
				p3  = frac(p3 * HASHSCALE1);
				p3 += dot(p3, p3.yzx + 19.19);
				return frac((p3.x + p3.y) * p3.z);
			}
			float2 hash21(float p)
			{
				float3 p3 = frac(p * float3(.1031, .1030, .0973));
				p3 += dot(p3, p3.yzx + 19.19);
				return frac((p3.xx + p3.yz) * p3.zy);

			}
			float2 hash22(float2 p)
			{
				float3 p3 = frac(float3(p.xyx) * HASHSCALE3);
				p3 += dot(p3, p3.yzx+19.19);
				return frac((p3.xx+p3.yz)*p3.zy);
			}
			float2 hash23(float3 p3)
			{
				p3 = frac(p3 * float3(.1031, .1030, .0973));
				p3 += dot(p3, p3.yzx + 33.33);
				return frac((p3.xx + p3.yz) * p3.zy);
			}
			float3 hash31(float p)
			{
				float3 p3 = frac(p * float3(.1031, .1030, .0973));
				p3 += dot(p3, p3.yzx + 33.33);
				return frac((p3.xxy + p3.yzz) * p3.zyx);
			}
			float3 hash32(float2 p)
			{
				float3 p3 = frac(p.xyx * float3(.1031, .1030, .0973));
				p3 += dot(p3, p3.yxz + 33.33);
				return frac((p3.xxy + p3.yzz) * p3.zyx);
			}
			float3 hash33(float3 p3)
			{
				p3 = frac(p3 * HASHSCALE3);
				p3 += dot(p3, p3.yxz+19.19);
				return frac((p3.xxy + p3.yxx)*p3.zyx);
			}
			float4 hash41(float p)
			{
				float4 p4 = frac(p * float4(.1031, .1030, .0973, .1099));
				p4 += dot(p4, p4.wzxy + 33.33);
				return frac((p4.xxyz + p4.yzzw) * p4.zywx);
			}
			float4 hash42(float2 p)
			{
				float4 p4 = frac(p.xyxy * float4(.1031, .1030, .0973, .1099));
				p4 += dot(p4, p4.wzxy + 33.33);
				return frac((p4.xxyz + p4.yzzw) * p4.zywx);
			}
			float4 hash43(float3 p)
			{
				float4 p4 = frac(float4(p.xyzx)  * HASHSCALE4);
				p4 += dot(p4, p4.wzxy+19.19);
				return frac((p4.xxyz+p4.yzzw)*p4.zywx);
			}
			float4 hash44(float4 p4)
			{
				p4 = frac(p4 * float4(.1031, .1030, .0973, .1099));
				p4 += dot(p4, p4.wzxy + 33.33);
				return frac((p4.xxyz + p4.yzzw) * p4.zywx);
			}
			float mod(float x, float y)
			{
				return frac(x / y)*y;
			}
			float2 mod(float2 x, float2 y)
			{
				return frac(x / y)*y;
			}

			float mask1(float2 uv)
			{
				if(Mask_Texture > 0)
				{
					float maskColor;
					if(Mask_Noise > 0)
						maskColor = hash13(float3(uv, _Time.x));
					else
					{
						maskColor = tex2D(_MaskTex, TRANSFORM_TEX(uv, _MaskTex) + _Time.y*_MaskScroll.xy);
						if(Mask_Multisampling > 0)
							for(float a = 0.5; a >= 0.125; a /= 2)
							{
								float2 maskUV = TRANSFORM_TEX(uv, _MaskTex) + _Time.y*_MaskScroll.xy;
								maskColor = lerp(maskColor, tex2D(_MaskTex, maskUV / a), a);
							}
					}
					return lerp(maskColor, _MaskColor, _MaskAlpha);
				}
				else
					return 1.0;
			}

			float4 mask4(float2 uv)
			{
				if(Mask_Texture > 0)
				{
					float4 maskColor;
					if(Mask_Noise > 0)
						maskColor = hash43(float3(uv, _Time.y));
					else
					{
						maskColor = tex2D(_MaskTex, TRANSFORM_TEX(uv, _MaskTex) + _Time.y*_MaskScroll.xy);
						if(Mask_Multisampling)
							for(float a = 0.5; a >= 0.125; a /= 2)
							{
								float2 maskUV = TRANSFORM_TEX(uv, _MaskTex) + _Time.y*_MaskScroll.xy;
								maskColor = lerp(maskColor, tex2D(_MaskTex, maskUV / a), a);
							}
					}
					return lerp(maskColor, float4(_MaskColor, 1.0), _MaskAlpha);
				}
				else
					return 1.0;
			}
		
			float3 HSVToRGB( float3 c )
			{
				float4 K = float4( 1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0 );
				float3 p = abs( frac( c.xxx + K.xyz ) * 6.0 - K.www );
				return c.z * lerp( K.xxx, saturate( p - K.xxx ), c.y );
			}

			float3 RGBToHSV(float3 c)
			{
				float4 K = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
				float4 p = lerp( float4( c.bg, K.wz ), float4( c.gb, K.xy ), step( c.b, c.g ) );
				float4 q = lerp( float4( p.xyw, c.r ), float4( c.r, p.yzx ), step( p.x, c.r ) );
				float d = q.x - min( q.w, q.y );
				float e = 1.0e-10;
				return float3( abs(q.z + (q.w - q.y) / (6.0 * d + e)), d / (q.x + e), q.x);
			}

			// ACES Filmic Tone Mapping Curve
			//
			// Adapted from code by Krzysztof Narkowicz
			// https://knarkowicz.wordpress.com/2016/01/06/
			// aces-filmic-tone-mapping-curve/

			float3 ACESFilm( float3 color )
			{
				float a = 2.51f;
				float b = 0.03f;
				float c = 2.43f;
				float d = 0.59f;
				float e = 0.14f;
				return saturate((color*(a*color+b))/(color*(c*color+d)+e));
			}

			inline float CheckGrabTextureBorder(float2 uv)
			{
			#ifdef UNITY_SINGLE_PASS_STEREO
				float4 scaleOffset = unity_StereoScaleOffset[unity_StereoEyeIndex];
				return step(scaleOffset.z, uv.x)*step(0, uv.y)*step(-scaleOffset.z - scaleOffset.x, -uv.x)*step(-1, -uv.y);
			#else
				return step(0, uv.x)*step(0, uv.y)*step(-1, -uv.x)*step(-1, -uv.y);
			#endif
			}

			//return color from red to blue
			float3 rainbowOld(float t)
			{
				float3 dist = 1.0 - 2.0*abs(t - float3(0.0, 0.5, 1.0));
				return max(0, dist*float3(4.0, 2.0, 4.0));
			}

			//https://www.shadertoy.com/view/ls2Bz1
			float3 rainbowJET(float x)
			{
				return float3(4.0*x - 2.0,
    						  4.0*x + min(0.0, 4.0 - 8.0*x),
							  1.0 + 4.0*(0.25-x));
			}
			// --- Spectral Zucconi --------------------------------------------
			// By Alan Zucconi
			// Based on GPU Gems: https://developer.nvidia.com/sites/all/modules/custom/gpugems/books/GPUGems/gpugems_ch08.html
			// But with values optimised to match as close as possible the visible spectrum
			// Fits this: https://commons.wikimedia.org/wiki/File:Linear_visible_spectrum.svg
			// With weighter MSE (RGB weights: 0.3, 0.59, 0.11)
			float3 bump3y (float3 x, float3 yoffset)
			{
				float3 y = float3(1.,1.,1.) - x * x;
				y = saturate(y-yoffset);
				return y;
			}
			float3 rainbow (float x)  //spectral_zucconi
			{
				const float3 cs = float3(3.54541723, 2.86670055, 2.29421995);
				const float3 xs = float3(0.69548916, 0.49416934, 0.28269708);
				const float3 ys = float3(0.02320775, 0.15936245, 0.53520021);

				return bump3y (cs * (x - xs), ys) * float3(2.5, 2.5, 5);
			}
			// --- Spectral Zucconi 6 --------------------------------------------

			// Based on GPU Gems
			// Optimised by Alan Zucconi
			float3 rainbow2 (float x)  //spectral_zucconi6
			{
				const float3 c1 = float3(3.54585104, 2.93225262, 2.41593945);
				const float3 x1 = float3(0.69549072, 0.49228336, 0.27699880);
				const float3 y1 = float3(0.02312639, 0.15225084, 0.52607955);

				const float3 c2 = float3(3.90307140, 3.21182957, 3.96587128);
				const float3 x2 = float3(0.11748627, 0.86755042, 0.66077860);
				const float3 y2 = float3(0.84897130, 0.88445281, 0.73949448);

				float3 result = bump3y(c1 * (x - x1), y1) +
								bump3y(c2 * (x - x2), y2) ;
				return result * float3(2.6, 2.7, 4.6);
			}

			float2 DistorsionSample(float2 uv)
			{
				float2 distorsion = 0;
				if(Texture_Distorsion)
				{
					float2 disUV = uv;
					disUV.x *= _ScreenParams.x / _ScreenParams.y;
					disUV = TRANSFORM_TEX(disUV, _DistorsionTex) + _Time.x * _DistorsionScroll.xy;
					distorsion = UnpackNormal(tex2D(_DistorsionTex, disUV)) * float2(_DIntensity_X, _DIntensity_Y);
					distorsion.x *= _ScreenParams.y/_ScreenParams.x;
				}
				if(Wave_Distorsion)
				{
					float4 sc;
					sincos(_DistorsionWaveDensity.xy*(uv.xy - 0.5) + _Time.yy*_DistorsionWaveSpeed.xy, sc.yw, sc.xz);
					distorsion += _DistorsionWave.xy*(sc.xy + sc.zw);
					//distorsion += _DistorsionWave.xy*cos(length(_DistorsionWaveDensity.xy*(uv - 0.5)) + _Time.y*_DistorsionWaveSpeed.xy);
				}
				return distorsion;
			}
			float3 TriPlanarSample(in float3 position, in float3 normal)
			{
				normal *= normal;
				float3 distorsion = normal.x * UnpackNormal(tex2D(_DistorsionTex, TRANSFORM_TEX(position.zy, _DistorsionTex) + _Time.x * _DistorsionScroll.xy)) +
					normal.y * UnpackNormal(tex2D(_DistorsionTex, TRANSFORM_TEX(position.xz, _DistorsionTex) + _Time.x * _DistorsionScroll.xy)) +
					normal.z * UnpackNormal(tex2D(_DistorsionTex, TRANSFORM_TEX(position.xy, _DistorsionTex) + _Time.x * _DistorsionScroll.xy));
				return distorsion;
			}
			float3 DistorsionSampleDir(in float3 direction)
			{
				float3 distorsion = 0;
				if (Texture_Distorsion)
				{
					float3 position = direction;
					//disUV.x *= _ScreenParams.x / _ScreenParams.y;
					//position = TRANSFORM_TEX(position.xy, _DistorsionTex) + _Time.x * _DistorsionScroll.xy;
					distorsion = TriPlanarSample(position, direction) * float3(_DIntensity_X, _DIntensity_Y, _DIntensity_X);
					
				}
				if (Wave_Distorsion)
				{
					float3 s, c;
					sincos(_DistorsionWaveDensity.xyz * direction.xyz + _Time.yyy * _DistorsionWaveSpeed.xyz, s, c);
					distorsion += _DistorsionWave.xyz * (s + c);
					//distorsion += _DistorsionWave.xy*cos(length(_DistorsionWaveDensity.xy*(uv - 0.5)) + _Time.y*_DistorsionWaveSpeed.xy);
				}
				return distorsion;
			}

			float2 BlurDistorsion(float2 uv) 
			{
				return Blur_Distorsion ? DistorsionSample(uv) : 0;
			}

			//Cheap Cubemap
			//https://www.shadertoy.com/view/ltl3D8
			//returns 2D UV 
			float2 cubeUV(in float3 d)
			{
				// intersect cube
				float3 n = abs(d);
				float3 v = (n.x > n.y && n.x > n.z) ? d.xyz :
					(n.y > n.x && n.y > n.z) ? d.yzx :
					d.zxy;
				// project into face
				float2 q = v.yz / v.x;
				// undistort in the edges
				q *= 1.25 - 0.25 * q * q;

				return 0.5 + 0.5 * q;
			}

			float4 frag(v2f i) : COLOR 
			{
				float4 grabPos = i.grabPos;
				grabPos.xy /= grabPos.w;
				i.uv /= i.uv.w;
				i.viewPos = normalize(i.viewPos);
				i.worldRayDir = normalize(i.worldRayDir);
				[branch] if (Glitch > 0)
				{
					float2 uv = i.viewPos.xy / abs(i.viewPos.z);
					//float2 uv = cubeUV(i.worldRayDir);
					float2 block = floor(uv * _BlockSize);
					float2 uv_noise = block / _BlockSize;
					float time = floor(_Time.y * _UPS);

					float2 rand = hash21(time);
					uv_noise += floor(rand.xy * float2(123.4, 354.3)) / _BlockSize;

					rand *= rand;
					_ActiveTime = max(0.0001, _ActiveTime);
					float glitchMul = pow(abs(sin(_Time.y * UNITY_PI / _Period)), 1.0 / _ActiveTime - 1.0);
					float block_thresh = rand.x * _BlockGlitch * glitchMul;
					float line_thresh = rand.y * rand.y * _LineGlitch * glitchMul;

					float3 noise = hash32(uv_noise);
					float3 line_noise = hash31(uv_noise.y);

					if (line_noise.x < line_thresh)
					{
						if (Chromatic_Aberration <= CHROMATIC_ABERRATION_VECTOR)
						{
							Chromatic_Aberration = CHROMATIC_ABERRATION_VECTOR;
							_CA_amplitude += 0.01;
							_CA_direction.x = line_noise.x - 0.5;
						}
						else
						{
							_CA_amplitude += 0.1;
							_CA_centerOffset.x += (line_noise.x - 0.5) * 0.1;
						}
					}
					else if (noise.x < block_thresh) 
					{
						if (Chromatic_Aberration <= CHROMATIC_ABERRATION_VECTOR)
						{
							Chromatic_Aberration = CHROMATIC_ABERRATION_VECTOR;
							_CA_amplitude += 0.01;
							_CA_direction.xy = noise.xy - 0.5;
						}
						else
						{
							_CA_amplitude += 0.1;
							_CA_centerOffset.xy += (noise.xy - 0.5) * 0.1;
						}
					}
					

					// discolor block lines
					//if (line_noise.g * 3.5 < line_thresh)
					//	fragColor.rgb = float3(0.0, dot(fragColor.rgb, 1.0), 0.0);

					if (line_noise.y < line_thresh * 0.4)
					{
						grabPos.xy += (line_noise.xy - 0.5) * 0.01;
					}
					else if (noise.y < block_thresh * 0.2)
					{
						grabPos.xy += (noise.xy - 0.5) * 0.01;
					}
					// interleave lines in some blocks
					else if (noise.y < block_thresh * 0.3)
					{
						float _line = frac(i.pos.y / 3.0);
						float3 mask = float3(2.0, 0.5, 0.5);
						if (_line > 0.333)
							mask = float3(0.5, 2.0, 0.5);
						if (_line > 0.666)
							mask = float3(0.5, 0.5, 2.0);
						Color_Tint = 1;
						_Brightness = mask;
					}
					
					
					// discolor block lines
					if (line_noise.z < line_thresh * 0.3 || noise.z < block_thresh * 0.1)
					{
						//fragColor.rgb = float3(0.0, dot(fragColor.rgb, 1.0), 0.0);
						Color_Tint = 1;
						_Grayscale = 1.0;
					}
					else if (noise.z < block_thresh * 0.1)
					{
						Posterization = 1;
						_PosterizationSteps = noise.x * 255.0;
					}
					else if (noise.z < block_thresh * 0.3)
					{
						//float2 dist = (frac(uv_noise) - 0.5) * 0.3;
						Pixelization = 1;
						_PSize_X = _PSize_Y = noise.x * noise.x * 32.0;
					}
					
				}
				[branch] if (_SizeGirls > 0)
				{
					//Girlscam https://www.shadertoy.com/view/4tVcRW
					float scanLineJitter = _SizeGirls * lerp(abs(_SinTime.w), 1.0, sin(_TimeGirls));
					float sl_thresh = saturate(1.0 - scanLineJitter * 1.2);
					float sl_disp = 0.002 + pow(scanLineJitter, 3.0) * 0.05;
					float jitter = hash12(float2(round(grabPos.y * _UberShaderGrabTexture_TexelSize.w) * _UberShaderGrabTexture_TexelSize.y, _SinTime.w)) * 2.0 - 1.0;
					jitter *= step(sl_thresh, abs(jitter)) * sl_disp;
					grabPos.x += jitter * i.falloff * factor.x;
				}
				[branch] if(Magnification == MAGNIFICATION_GRAVITATIONAL_LENS) 
				{
					float magFalloff = dot(i.viewCenter, i.viewCenter);
					magFalloff = 1.0 / (1.0/ _Gravitation*magFalloff + 1.0);

					i.viewCenter = normalize(i.viewCenter);
					float angle = acos(dot(i.viewPos, i.viewCenter)) / UNITY_PI;
					float3 viewPos = i.viewPos * 0.5;
					
					float angleFalloff = smoothstep(0, 1, (clamp(angle, _AngleStartFade, _MaxAngle) - _MaxAngle) / (_AngleStartFade - _MaxAngle));
				
					float3 vec = i.viewCenter - viewPos;
					float3 viewSpaceDistorsion = viewPos + vec * magFalloff * angleFalloff * i.falloff * tan(_Magnification * UNITY_HALF_PI);
					float4 grabPosDest = ComputeGrabScreenPos(UnityViewToClipPos(viewPos));
					float4 grabPosSrc = ComputeGrabScreenPos(UnityViewToClipPos(viewSpaceDistorsion));
					float4 magOffset = grabPosSrc / grabPosSrc.w - grabPosDest / grabPosDest.w;
					grabPos.xy += magOffset.xy;
				}

				float4 maskColor = 1.0;
				float maskGray = 1.0;
				
				[branch] if(Mask_Texture > 0)
				{
					[branch] if(Mask_Noise > 0)
					{
						maskColor.rgb = hash33(float3(i.viewPos.xy, frac(_Time.y)));
						maskColor.a  = 1;
					} else {
						maskColor = tex2D(_MaskTex, TRANSFORM_TEX(i.viewPos.xy, _MaskTex) + _Time.y*_MaskScroll.xy);
						if(Mask_Multisampling)
						{
							for(float a = 0.5; a >= 0.125; a /= 2)
							{
								float2 maskUV = TRANSFORM_TEX(i.viewPos.xy, _MaskTex) + _Time.y*_MaskScroll.xy;
								maskColor = lerp(maskColor, tex2D(_MaskTex, maskUV / a), a);
							}
							maskColor = saturate(maskColor);
						}
					}
					maskColor = lerp(maskColor, float4(_MaskColor, 1.0), _MaskAlpha);
					maskGray = dot(maskColor.rgb, 0.333);
				}
		
				[branch] if(Pixelization > 0)
				{
					float2 blockSize = _ScreenParams.xy / factor / lerp(1.0, float2(_PSize_X, _PSize_Y), i.falloff);
					grabPos.xy = round(grabPos.xy * blockSize) / blockSize;
				}
				
				[branch] if(Distorsion > 0)
				{
					float3 displace = DistorsionSampleDir(i.worldRayDir);

					displace.x *= _ScreenParams.y / _ScreenParams.x;
					grabPos.xy += displace.xy * i.falloff * factor * maskGray;
					//grabPos.xy += DistorsionSample(i.viewPos.xy + 0.5) * i.falloff * factor * maskGray;
				}

				float4 color = _UberShaderGrabTexture.Sample(grabSampler, grabPos);
				
				[branch] if(Blur > 0)
				{
					float2 blurVector;
					float3 blurColor = 0;
					[branch] if(Blur == BLUR_HORIZONTAL)
					{
						sincos((_BlurRotation + _Time.y*_BlurRotationSpeed)*UNITY_HALF_PI, blurVector.y, blurVector.x);
						blurVector.y *= _ScreenParams.x / _ScreenParams.y;
						blurVector *= _BlurRange;
						//blurVector += BlurDistorsion(i.viewPos.xy);
						[branch] if (Blur_Distorsion)
							blurVector += DistorsionSampleDir(i.worldRayDir).xy;
						blurVector *= i.falloff * factor;
						float blurStep = 1.0 / _BlurIterations;

						for(float x = -0.5; x < 0.5; x += blurStep)
							blurColor += _UberShaderGrabTexture.Sample(grabSampler, grabPos.xy + x * blurVector);
						blurColor *= blurStep;
					}
					else if (Blur == BLUR_STAR)
					{
						sincos((_BlurRotation + _Time.y*_BlurRotationSpeed)*UNITY_HALF_PI, blurVector.y, blurVector.x);
						blurVector.y *= _ScreenParams.x / _ScreenParams.y;
						blurVector *= _BlurRange;
						//blurVector += BlurDistorsion(i.viewPos.xy);
						[branch] if (Blur_Distorsion)
							blurVector += DistorsionSampleDir(i.worldRayDir).xy;
						blurVector *= i.falloff * factor;
						float blurStep = 1.0 / _BlurIterations;

						for(float x = -0.5; x < 0.5; x += blurStep)
							blurColor += _UberShaderGrabTexture.Sample(grabSampler, grabPos.xy + x * blurVector);
						sincos((_BlurRotation + 1 + _Time.y*_BlurRotationSpeed)*UNITY_HALF_PI, blurVector.y, blurVector.x);
						blurVector.y *= _ScreenParams.x / _ScreenParams.y;
						blurVector *= _BlurRange;
						//blurVector += BlurDistorsion(i.viewPos.xy);
						[branch] if (Blur_Distorsion)
							blurVector += DistorsionSampleDir(i.worldRayDir).xy;
						blurVector *= i.falloff * factor;
						for(x = -0.5; x <= 0.5; x += blurStep)
							blurColor += _UberShaderGrabTexture.Sample(grabSampler, grabPos.xy + x * blurVector);
						blurColor *= blurStep / 2.0;
					}
					else if (Blur == BLUR_CIRCLE)
					{
						float blurStep = 1.0 / _BlurIterations;
						float rotation = (_BlurRotation + _Time.y*_BlurRotationSpeed)*UNITY_HALF_PI;
						float2 vecMul = _BlurRange;
						vecMul.y *= _ScreenParams.x / _ScreenParams.y;
						//vecMul += BlurDistorsion(i.viewPos.xy);
						[branch] if (Blur_Distorsion)
							vecMul += DistorsionSampleDir(i.worldRayDir).xy;
						vecMul *= i.falloff * factor;
						for(float x = 0.0; x < 1.0; x += blurStep)
						{
							sincos(rotation + x*UNITY_TWO_PI, blurVector.y, blurVector.x);
							blurVector *= vecMul;
							blurColor += _UberShaderGrabTexture.Sample(grabSampler, grabPos.xy + blurVector);
						}
						blurColor *= blurStep;
					}
					else if (Blur == BLUR_RADIAL)
					{
						blurVector = -(i.viewPos.xy + _BlurCenterOffset.xy);
						float2 rotatedBlurVec = float2(blurVector.y, -blurVector.x);
						float2 sc;
						sincos((_BlurRotation + _Time.y*_BlurRotationSpeed)*UNITY_HALF_PI, sc.y, sc.x);
						blurVector = blurVector * sc.x + rotatedBlurVec * sc.y;
						blurVector.y *= _ScreenParams.x / _ScreenParams.y;
						blurVector *= _BlurRange;
						//blurVector += BlurDistorsion(i.viewPos.xy);
						[branch] if(Blur_Distorsion)
							blurVector += DistorsionSampleDir(i.worldRayDir).xy;
						blurVector *= i.falloff * factor;
						float blurStep = 1.0 / _BlurIterations;

						for(float x = -0.5; x < 0.5; x += blurStep)
							blurColor += _UberShaderGrabTexture.Sample(grabSampler, grabPos.xy + x * blurVector);
						blurColor *= blurStep;
					}
					color.rgb = lerp(color.rgb, blurColor.rgb, _BlurColor * lerp(1.0, maskGray, _BlurMask));
				}
				[branch] if(Chromatic_Aberration > 0)
				{
					float shift = 0.5 + 0.5*cos(_Time.y*_CA_speed);
					shift = _CA_amplitude * pow(shift, 3.0) * i.falloff;
					float2 shift2;
					if(Chromatic_Aberration >= CHROMATIC_ABERRATION_RADIAL)
					{
						#ifdef UNITY_SINGLE_PASS_STEREO
							shift2 = i.viewPos.xy + _CA_centerOffset.xy;
						#else
							shift2 = i.viewPos.xy * _ScreenParams.yy / _ScreenParams.xy + _CA_centerOffset.xy;
						#endif
					
						float l = length(shift2);
						shift2 *= -shift*l;
					}
					else
					{
						shift2 = _CA_direction.xy * shift;
						shift2.y *= _ScreenParams.x / _ScreenParams.y;
					}
					shift2 *= factor;
					float3 chromatcColor = 0;

					[branch] if(Aberration_Quality >= ABERRATION_QUALITY_MULTISAMPLING)
					{
						float w = 1.0 / _CA_iterations;
						[branch] if(CA_Distorsion > 0)
							shift2 += DistorsionSampleDir(i.worldRayDir).xy * i.falloff;
						[branch] if(Chromatic_Aberration <= CHROMATIC_ABERRATION_VECTOR)
							[loop] for(float t = 0.0; t < 1.0; t += w)
							{
								float2 uv = (t - 0.5) * shift2;
								chromatcColor += rainbow(t) * _UberShaderGrabTexture.Sample(grabSampler, grabPos.xy + uv).rgb;
							}
						else
							[loop] for(float x = 0.0; x < 1.0; x += w)
							{
								float2 uv = x * shift2;
								chromatcColor += rainbow(x) * _UberShaderGrabTexture.Sample(grabSampler, grabPos.xy + uv).rgb;
							}
						chromatcColor /= _CA_iterations;
						color.rgb = lerp(color.rgb, chromatcColor, _CA_factor * lerp(1.0, maskColor.rgb, _CA_mask));
					}
					else
					{
						[branch] if(CA_Distorsion > 0)
							shift2 += DistorsionSampleDir(i.worldRayDir).xy * i.falloff;
						color.r = lerp(color.r, _UberShaderGrabTexture.Sample(grabSampler, grabPos - shift2).r, _CA_factor* lerp(1.0, maskColor.r, _CA_mask));
						color.b = lerp(color.b, _UberShaderGrabTexture.Sample(grabSampler, grabPos + shift2).b, _CA_factor* lerp(1.0, maskColor.b, _CA_mask));
					}
				}

				[branch] if(Neon > 0)
				{
					float3 pix = float3(_UberShaderGrabTexture_TexelSize.xy, 0) * _NeonWidth * factor.x;
					float3 color_sub = _UberShaderGrabTexture.Sample(grabSampler, grabPos.xy - pix.xz);
					color_sub += _UberShaderGrabTexture.Sample(grabSampler, grabPos.xy + pix.xz);
					color_sub += _UberShaderGrabTexture.Sample(grabSampler, grabPos.xy - pix.zy);
					color_sub += _UberShaderGrabTexture.Sample(grabSampler, grabPos.xy + pix.zy);
					float3 delta_color = 4.0*color.rgb*_NeonOrigColorAlpha - color_sub;
					delta_color *= _NeonBrightness;
					delta_color = lerp(delta_color, length(delta_color) > 1.0 ? normalize(delta_color) : 0.0, _NeonPosterization);
					delta_color = lerp(delta_color, abs(delta_color), _NeonGlow);
					float3 neonColor = color.rgb * _NeonOrigColor.rgb + delta_color *_NeonColor.rgb;
					color.rgb = lerp(color.rgb, neonColor, _NeonColorAlpha * i.falloff);
				}
				float3 hsv;
				float hsvMask;
				[branch] if (HSV_Selection > 0 || HSV_Transform > 0)
					hsv = RGBToHSV(color.rgb);
				else
					hsv = 0.0;
				[branch] if (HSV_Selection > 0)
				{
					float3 targetHSV = RGBToHSV(_TargetColor.rgb);
					float3 diff;
					diff.x = frac(targetHSV.x - hsv.x);
					diff.x -= step(0.5, diff.x);
					diff.yz = targetHSV.yz - hsv.yz;

					hsvMask = abs(diff.x) < _HueRange ? 1 : 1 - saturate((abs(diff.x) - _HueRange) / _HueSmoothRange - 1);
					hsvMask *= diff.y < _SaturationRange ? 1 : 1 - saturate(max(0, diff.y - _SaturationRange) / _SaturationSmoothRange - 1);
					hsvMask *= diff.z < _LightnessRange ? 1 : 1 - saturate(max(0, diff.z - _LightnessRange) / _LightnessSmoothRange - 1);

					if (HSV_Desaturate_Selected > 0)
						hsv.y = hsv.y * hsvMask;
					if (HSV_Transform == 0)
						color.rgb = lerp(color.rgb, HSVToRGB(hsv), i.falloff);
				}
				else
					hsvMask = 1.0;

				[branch] if(HSV_Transform > 0)
				{
					float3 transformHSV = RGBToHSV(_TransformColor.rgb);
					transformHSV.x = frac(transformHSV.x + _Time.y * _HueAnimationSpeed);
					if (_Hue < 1.0)
					{
						float hue_diff = frac(transformHSV.x - hsv.x);
						hue_diff -= step(0.5, hue_diff);
						float hue_shift = -8.0*hue_diff*(hue_diff*hue_diff - 0.25); //Smoothing hue shift
						hsv.x = frac(hsv.x + hue_shift * _Hue);
					}
					else
						hsv.x = transformHSV.x;
					hsv.y = lerp(hsv.y, transformHSV.y, _Saturation);
					hsv.z = lerp(hsv.z, transformHSV.z, _Lightness);
					color.rgb = lerp(color.rgb, HSVToRGB(hsv), i.falloff * hsvMask);
				}

				[branch] if(Color_Tint > 0)
				{
					float3 col = color;
					if(ACES_Tonemapping)
						col = ACESFilm(max(0, col));
					col = lerp(col, 1 - min(1, col), float3(_RedInvert, _GreenInvert, _BlueInvert));
					col = max(0.0, (col - 0.5)*_Contrast + 0.5);
					col = pow(col, _Gamma);
					col *= _Brightness;
					col = lerp(col, LinearRgbToLuminance(col), _Grayscale);
					col = lerp(col, _Color, _ColorAlpha);
					col += _EmissionColor.rgb;
					color.rgb = lerp(color.rgb, col, i.falloff);
				}

				[branch] if(Posterization > 0 && _PosterizationSteps <= 255.0)
				{
					float luminance = max(0.001, LinearRgbToLuminance(color.rgb));
					if(Dithering > 0)
					{
						// 8x8 ordered dithering, texture-based
						float floorLum = floor(luminance * _PosterizationSteps) / _PosterizationSteps;
						float ceilLum = ceil(luminance * _PosterizationSteps) / _PosterizationSteps;
						float dtLum = luminance * _PosterizationSteps - floor(luminance * _PosterizationSteps);
					
						float dither = tex2Dlod( _DitheringMask, float4(i.pos.xy*_DitheringMask_TexelSize.xy, 0, 0));
						dither = pow(dither, 1/2.4); //Gamma Correction
						color.rgb = lerp(color.rgb, color.rgb / luminance * (dtLum > dither ? ceilLum : floorLum),  i.falloff);
					}
					else
						color.rgb = lerp(color.rgb, color.rgb / luminance * round( luminance * _PosterizationSteps ) / _PosterizationSteps, i.falloff);
				}

				[branch] if(Overlay_Texture > 0)
				{
					float s, c;
					sincos(_OverlayRotation * UNITY_HALF_PI, s, c);
				#ifdef UNITY_SINGLE_PASS_STEREO
					// Calculate UV for VR
					float2 overlayUV = i.viewPos.xy / abs(i.viewPos.z);
				#else
					// Moving uv origin to center
					i.uv.xy -= 0.5;
					// Screen aspect correction
					i.uv.xy *= _ScreenParams.xy / _ScreenParams.yy;
					float2 overlayUV = i.uv.xy;
				#endif
					// Rotate UV
					overlayUV = mul(float2x2(c, -s, s, c), overlayUV);
					// Move uv origin back
					overlayUV = TRANSFORM_TEX(overlayUV, _OverlayTex) + 0.5 + _Time.y * _OverlayScroll.xy;

					float overlayAlpha = 1.0;
					if (Overlay_Grid)
						overlayUV = frac(overlayUV);
					else
					{
						overlayAlpha = 0.0 <= overlayUV.x && overlayUV.x <= 1.0 && 0.0 <= overlayUV.y && overlayUV.y <= 1.0;
						overlayUV = saturate(overlayUV);
					}
					[branch] if (Overlay_Texture_Sheet)
					{
						uint frame = floor(_Time.y * _OverlayAnimationSpeed * _OverlayTotalFrames);
						uint current = (_OverlayStartFrame + frame) % _OverlayTotalFrames;
						uint2 spritePosition = uint2(current % _OverlayColumns, _OverlayRows - 1 - current / _OverlayColumns);

						overlayUV = (overlayUV + spritePosition) / uint2(_OverlayColumns, _OverlayRows);
					}
					float4 overlaySample = tex2Dlod(_OverlayTex, float4(overlayUV, 0, 0));
					overlayAlpha *= overlaySample.a;
					
					[branch] if (_OverlayOpaque < 0.999)
						overlayAlpha = saturate((overlayAlpha + _OverlayTransparent - 1) / (1 - _OverlayOpaque));
					else
						overlayAlpha = step(1 - _OverlayTransparent, overlayAlpha);
					color.rgb = lerp(color.rgb, _OverlayTint * overlaySample.rgb, overlayAlpha * i.falloff);
				}
				
				[branch] if (Static_Noise > 0)
				{
					//float staticValue = hash13(float3(grabPos.xy, _Time.x));
					//staticValue *= staticValue <= _StaticIntensity ? _StaticBrightness / _StaticIntensity : 0.0;
					//float3 staticColor = lerp(color.rgb, _StaticColour.rgb, saturate(staticValue + _StaticAlpha - 1));

					float staticValue = hash13(float3(grabPos.xy, _Time.x)) * tan(_StaticIntensity * UNITY_HALF_PI);
					float3 staticColor = staticValue * _StaticColour.rgb * lerp(color.rgb, 1.0, _StaticAlpha);
					color.rgb = lerp(color.rgb, staticColor + color.rgb * _StaticBrightness, i.falloff);
				}
				[branch] if(Vignette > 0)
				{
					float2 VignetteUV = i.viewPos.xy / i.viewPos.z;
					if (_VignetteShape < 0)
						VignetteUV.y *= 1.0 + _VignetteShape;
					else
						VignetteUV.x *= 1.0 - _VignetteShape;

					_VignetteRounding = max(0.05, _VignetteRounding);
					float z = pow(dot(1.0, pow(abs(VignetteUV), 2.0 / _VignetteRounding)), _VignetteRounding / 2.0);
					float vignette = saturate(pow(saturate(z + _VignetteWidth), 1.0 / tan(_VignetteAlpha * UNITY_HALF_PI)));

					color.rgb = lerp(color.rgb, _VignetteColor, vignette * i.falloff);
					
					//The best formula for desktop (but not for VR) from https://www.shadertoy.com/view/lsKSWR
					//float2 windowPos = VignetteUV;
					//windowPos *= 1.0 - windowPos.yx;
					//float vignette = windowPos.x * windowPos.y * (1.0 - _VignetteAlpha) * 100.0;
					//color.rgb = lerp(color.rgb, _VignetteColor, saturate(1.0 - pow(vignette, _VignetteWidth)) * i.falloff);
				}
				return color;
			} //frag
			ENDHLSL
		} //Pass
	} //SubShader
	CustomEditor "LeviantScreenSpaceEditor"
	FallBack "Particles/Multiply"
}  //Shader
