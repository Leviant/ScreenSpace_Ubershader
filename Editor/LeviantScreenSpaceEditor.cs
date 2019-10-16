//Made by Aidan.ogg#0001 for Leviant#8796
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class LeviantScreenSpaceEditor : ShaderGUI
{
    static string paypalURL = "https://www.paypal.me/LeviantTech";
    static string[] RGB_Labels = new string[] { "Red", "Green", "Blue" };
    static Texture2D bannerTex;
    static GUIStyle linkStyle;
    static GUIStyle foldLabelStyle;
    static GUIStyle toggleStyle;
    static GUIStyle layoutStyle;
    static GUIStyle introLayoutStyle;
    static Dictionary<Category, GUIContent> labels;
    static GUIContent activeText = new GUIContent("Active");
    static int foldState;
    static bool useSliders;
    static Rect linkRect;

    Material _material;
    MaterialProperty[] _props;
    MaterialEditor _materialEditor;

    //Main Settings
    MaterialProperty Particle_Render;
    //Fade Settings
    MaterialProperty _MinRange;
    MaterialProperty _MaxRange;

    //Glitch
    MaterialProperty Glitch;
    MaterialProperty _BlockSize;
    MaterialProperty _BlockGlitch;
    MaterialProperty _LineGlitch;
    MaterialProperty _UPS;
    MaterialProperty _ActiveTime;
    MaterialProperty _Period;

    //Zoom Settings
    MaterialProperty Magnification;
    MaterialProperty _Magnification;
    MaterialProperty _Gravitation;
    MaterialProperty _AngleStartFade;
    MaterialProperty _MaxAngle;

    //Girlscam
    MaterialProperty _SizeGirls;
    MaterialProperty _TimeGirls;

    //Rotation
    MaterialProperty ScreenRotation;
    MaterialProperty _ScreenRotation;
    MaterialProperty _ScreenRotationSpeed;

    //Screen Transform
    MaterialProperty _ScreenHorizontalFlip;
    MaterialProperty _ScreenVerticalFlip;

    //Screen Shake
    MaterialProperty Shake;
    MaterialProperty _ShakeTex;
    MaterialProperty _SIntensity_X;
    MaterialProperty _SIntensity_Y;
    MaterialProperty _ShakeScroll;
    MaterialProperty _ShakeWave;
    MaterialProperty _ShakeWaveSpeed;

    //Pixelation
    MaterialProperty Pixelization;
    MaterialProperty _PSize_X;
    MaterialProperty _PSize_Y;

    //Screen Distortion
    MaterialProperty Distorsion;
    MaterialProperty Wave_Distorsion;
    MaterialProperty Texture_Distorsion;
    MaterialProperty _DistorsionTex;
    MaterialProperty _DIntensity_X;
    MaterialProperty _DIntensity_Y;
    MaterialProperty _DistorsionScroll;
    MaterialProperty _DistorsionWave;
    MaterialProperty _DistorsionWaveSpeed;
    MaterialProperty _DistorsionWaveDensity;

    //Blur Settings
    MaterialProperty Blur;
    MaterialProperty Blur_Distorsion;
    MaterialProperty _BlurColor;
    MaterialProperty _BlurRange;
    MaterialProperty _BlurRotation;
    MaterialProperty _BlurRotationSpeed;
    MaterialProperty _BlurIterations;
    MaterialProperty _BlurCenterOffset;
    MaterialProperty _BlurMask;

    //Chromatic Aberration
    MaterialProperty Chromatic_Aberration;
    MaterialProperty Aberration_Quality;
    MaterialProperty CA_Distorsion;
    MaterialProperty _CA_amplitude;
    MaterialProperty _CA_iterations;
    MaterialProperty _CA_speed;
    MaterialProperty _CA_direction;
    MaterialProperty _CA_factor;
    MaterialProperty _CA_centerOffset;
    MaterialProperty _CA_mask;

    //Neon
    MaterialProperty Neon;
    MaterialProperty _NeonColor;
    MaterialProperty _NeonColorAlpha;
    MaterialProperty _NeonOrigColor;
    MaterialProperty _NeonOrigColorAlpha;
    MaterialProperty _NeonBrightness;
    MaterialProperty _NeonPosterization;
    MaterialProperty _NeonWidth;
    MaterialProperty _NeonGlow;

    //HSV Colour Space
    MaterialProperty HSV_Selection;
    MaterialProperty _TargetColor;
    MaterialProperty _HueRange;
    MaterialProperty _SaturationRange;
    MaterialProperty _LightnessRange;
    MaterialProperty _HueSmoothRange;
    MaterialProperty _SaturationSmoothRange;
    MaterialProperty _LightnessSmoothRange;
    MaterialProperty HSV_Desaturate_Selected;
    //Extra Settings
    MaterialProperty HSV_Transform;
    MaterialProperty _TransformColor;
    MaterialProperty _Hue;
    MaterialProperty _HueAnimationSpeed;
    MaterialProperty _Saturation;
    MaterialProperty _Lightness;

    //Colour Correction
    MaterialProperty Color_Tint;
    MaterialProperty ACES_Tonemapping;
    MaterialProperty _EmissionColor;
    MaterialProperty _Color;
    MaterialProperty _ColorAlpha;
    MaterialProperty _Grayscale;
    MaterialProperty _Contrast;
    MaterialProperty _Gamma;
    MaterialProperty _Brightness;
    MaterialProperty _RedInvert;
    MaterialProperty _GreenInvert;
    MaterialProperty _BlueInvert;

    //Posterization
    MaterialProperty Posterization;
    MaterialProperty _PosterizationSteps;

    //Dithering
    MaterialProperty Dithering;
    MaterialProperty _DitheringMask;

    //Overlay Texture
    MaterialProperty Overlay_Texture;
    MaterialProperty Overlay_Grid;
    MaterialProperty _OverlayTex;
    MaterialProperty _OverlayTint;
    MaterialProperty _OverlayScroll;
    MaterialProperty _OverlayRotation;
    MaterialProperty _OverlayOpaque;
    MaterialProperty _OverlayTransparent;
    MaterialProperty Overlay_Texture_Sheet;
    MaterialProperty _OverlayColumns;
    MaterialProperty _OverlayRows;
    MaterialProperty _OverlayStartFrame;
    MaterialProperty _OverlayTotalFrames;
    MaterialProperty _OverlayAnimationSpeed;

    //Static
    MaterialProperty Static_Noise;
    MaterialProperty _StaticColour;
    MaterialProperty _StaticIntensity;
    MaterialProperty _StaticAlpha;
    MaterialProperty _StaticBrightness;
    MaterialProperty _MaskAmount;

    //Vignette
    MaterialProperty Vignette;
    MaterialProperty _VignetteColor;
    MaterialProperty _VignetteAlpha;
    MaterialProperty _VignetteWidth;
    MaterialProperty _VignetteShape;
    MaterialProperty _VignetteRounding;

    //Mask Texture
    MaterialProperty Mask_Texture;
    MaterialProperty Mask_Multisampling;
    MaterialProperty Mask_Noise;
    MaterialProperty _MaskTex;
    MaterialProperty _MaskColor;
    MaterialProperty _MaskAlpha;
    MaterialProperty _MaskScroll;

    //Stlyes
    GUIStyle friendStyle;

    static class Styles
    {
        public static GUIContent MainText = new GUIContent("Background Texture");
    }

    enum Category
    {
        MainSettings,
        Glitch,
        ZoomSettings,
        Girlscam,
        Rotation,
        ScreenTransform,
        ScreenShake,
        Pixelation,
        ScreenDistortion,
        BlurSettings,
        ChromaticAberration,
        Neon,
        HSVColourSpace,
        ColourCorrection,
        Posterization,
        Dithering,
        OverlayTexture,
        Static,
        Vignette,
        MaskTexture,
        HELP,
        Credits
    }
    static LeviantScreenSpaceEditor()
    {
        
    }
    void AssignHeaderProperties()
    {
        Glitch = FindProperty("Glitch", _props);
        Magnification = FindProperty("Magnification", _props);
        _SizeGirls = FindProperty("_SizeGirls", _props);
        ScreenRotation = FindProperty("ScreenRotation", _props);
        _ScreenHorizontalFlip = FindProperty("_ScreenHorizontalFlip", _props);
        _ScreenVerticalFlip = FindProperty("_ScreenVerticalFlip", _props);
        Shake = FindProperty("Shake", _props);
        Pixelization = FindProperty("Pixelization", _props);
        Distorsion = FindProperty("Distorsion", _props);
        Blur = FindProperty("Blur", _props);
        Chromatic_Aberration = FindProperty("Chromatic_Aberration", _props);
        Neon = FindProperty("Neon", _props);
        HSV_Selection = FindProperty("HSV_Selection", _props);
        HSV_Transform = FindProperty("HSV_Transform", _props);
        Color_Tint = FindProperty("Color_Tint", _props);
        Posterization = FindProperty("Posterization", _props);
        Dithering = FindProperty("Dithering", _props);
        Overlay_Texture = FindProperty("Overlay_Texture", _props);
        Static_Noise = FindProperty("Static_Noise", _props);
        Vignette = FindProperty("Vignette", _props);
        Mask_Texture = FindProperty("Mask_Texture", _props);
    }

    //Defines Styles (Fonts)
    public void defineStyles()
    {
        labels = new Dictionary<Category, GUIContent>(32)
        {
            { Category.MainSettings, new GUIContent("Main Settings") },
            { Category.Glitch, new GUIContent("Glitch") },
            { Category.ZoomSettings, new GUIContent("Zoom Settings") },
            { Category.Girlscam, new GUIContent("Girlscam") },
            { Category.Rotation, new GUIContent("Rotation") },
            { Category.ScreenTransform, new GUIContent("Screen Transform") },
            { Category.ScreenShake, new GUIContent("Screen Shake") },
            { Category.Pixelation, new GUIContent("Pixelation") },
            { Category.ScreenDistortion, new GUIContent("Screen Distortion") },
            { Category.BlurSettings, new GUIContent("Blur Settings") },
            { Category.ChromaticAberration, new GUIContent("Chromatic Aberration") },
            { Category.Neon, new GUIContent("Neon") },
            { Category.HSVColourSpace, new GUIContent("HSV Colour Space") },
            { Category.ColourCorrection, new GUIContent("Colour Correction") },
            { Category.Posterization, new GUIContent("Posterization") },
            { Category.Dithering, new GUIContent("Dithering") },
            { Category.OverlayTexture, new GUIContent("Overlay Texture") },
            { Category.Static, new GUIContent("Static") },
            { Category.Vignette, new GUIContent("Vignette") },
            { Category.MaskTexture, new GUIContent("Mask Texture") },
            { Category.HELP, new GUIContent("HELP!") },
            { Category.Credits, new GUIContent("Credits") }
        };

        bannerTex = Resources.Load<Texture2D>("LeviantHeaderNew");

        linkStyle = new GUIStyle();
        linkStyle.fontSize = 12;
        linkStyle.hover.textColor = Color.blue;
        linkStyle.alignment = TextAnchor.MiddleCenter;
        linkStyle.padding = new RectOffset(8, 8, 8, 8);

        foldLabelStyle = new GUIStyle(EditorStyles.foldout);
        foldLabelStyle.fontSize = 13;
        foldLabelStyle.fontStyle = FontStyle.Bold;
        foldLabelStyle.alignment = TextAnchor.MiddleLeft;
        foldLabelStyle.padding = new RectOffset(18, 2, 3, 3);

        toggleStyle = new GUIStyle(EditorStyles.toggle);
        toggleStyle.alignment = TextAnchor.MiddleRight;
        layoutStyle = new GUIStyle(EditorStyles.helpBox);
        layoutStyle.margin.left = 0;
        layoutStyle.margin.right = 0;
        layoutStyle.padding.left = 0;
        layoutStyle.padding.right = 0;
        introLayoutStyle = new GUIStyle();
    }
    public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] props)
    {
        _material = materialEditor.target as Material;
        _props = props;
        _materialEditor = materialEditor;
        if (toggleStyle == null)
            defineStyles();

        AssignHeaderProperties();

        DrawGUI();

        Undo.RecordObject(_material, "Material Edition");
    }
    void DrawBanner()
    {
        if (bannerTex != null)
        {
            GUILayout.Space(3);
            Rect rect = GUILayoutUtility.GetRect(0, int.MaxValue, 100, 100);
            EditorGUI.DrawPreviewTexture(rect, bannerTex, null, ScaleMode.ScaleAndCrop);
            GUILayout.Space(3);
        }
    }

    void DrawGUI()
    {
        EditorGUILayout.BeginVertical();
        DrawBanner();   //Draws Banner Image

        if (BeginFold(Category.MainSettings))
        {
            DrawMainSettings();
        }
        EndFold();

        if (BeginToggleFold(Category.Glitch, Glitch))
        {
            DrawGlitch();
        }
        EndFold();

        if (BeginFold(Category.ZoomSettings, Magnification))
        {
            DrawZoomSettings();
        }
        EndFold();

        if (BeginFold(Category.Girlscam, _SizeGirls))
        {
            DrawGirlscam();
        }
        EndFold();

        if (BeginToggleFold(Category.Rotation, ScreenRotation))
        {
            DrawRotation();
        }
        EndFold();

        if (BeginFold(Category.ScreenTransform, _ScreenHorizontalFlip, _ScreenVerticalFlip))
        {
            DrawScreenTransform();
        }
        EndFold();

        if (BeginToggleFold(Category.ScreenShake, Shake))
        {
            DrawScreenShake();
        }
        EndFold();

        if (BeginToggleFold(Category.Pixelation, Pixelization))
        {
            DrawPixelation();
        }
        EndFold();

        if (BeginToggleFold(Category.ScreenDistortion, Distorsion))
        {
            DrawScreenDistortion();
        }
        EndFold();

        if (BeginFold(Category.BlurSettings, Blur))
        {
            DrawBlurSettings();
        }
        EndFold();

        if (BeginFold(Category.ChromaticAberration, Chromatic_Aberration))
        {
            DrawChromaticAberration();
        }
        EndFold();

        if (BeginToggleFold(Category.Neon, Neon))
        {
            DrawNeon();
        }
        EndFold();

        if (BeginFold(Category.HSVColourSpace, HSV_Selection, HSV_Transform))
        {
            DrawHSVColourSpace();
        }
        EndFold();

        if (BeginToggleFold(Category.ColourCorrection, Color_Tint))
        {
            DrawColourCorrection();
        }
        EndFold();

        if (BeginToggleFold(Category.Posterization, Posterization))
        {
            DrawPosterization();
        }
        EndFold();

        if (BeginToggleFold(Category.Dithering, Dithering))
        {
            DrawDithering();
        }
        EndFold();

        if (BeginToggleFold(Category.OverlayTexture, Overlay_Texture))
        {
            DrawOverlayTexture();
        }
        EndFold();

        if (BeginToggleFold(Category.Static, Static_Noise))
        {
            DrawStatic();
        }
        EndFold();

        if (BeginToggleFold(Category.Vignette, Vignette))
        {
            DrawVignette();
        }
        EndFold();
        if (BeginToggleFold(Category.MaskTexture, Mask_Texture))
        {
            DrawMaskTexture();
        }
        EndFold();

        if (BeginFold(Category.HELP))
        {
            DrawHELP();
        }
        EndFold();

        if (BeginFold(Category.Credits))
        {
            DrawCredits();
        }
        EndFold();
        
        DrawLeviantPayPal();
        EditorGUILayout.EndVertical();
    }

    //applying dark or light theme text
    public void generateMessage(String textToDis, GUIStyle textStyle)
    {
        String colorModifier = "000000";
    }

    void DrawMainSettings()
    {
        Particle_Render = FindProperty("Particle_Render", _props);
        _MinRange = FindProperty("_MinRange", _props);
        _MaxRange = FindProperty("_MaxRange", _props);

        _materialEditor.ShaderProperty(Particle_Render, "Setup for Particle System");

        GameObject go = Selection.activeObject as GameObject;
        if (go != null)
        {
            ParticleSystemRenderer particles = go.GetComponent<ParticleSystemRenderer>();
            bool setupForParticles = Particle_Render.floatValue != 0.0f;
            if (setupForParticles)
            {
                if (particles != null)
                {
                    List<ParticleSystemVertexStream> streams = new List<ParticleSystemVertexStream>();
                    particles.GetActiveVertexStreams(streams);
                    bool correctSetup = particles.activeVertexStreamsCount >= 2 && streams.Contains(ParticleSystemVertexStream.Position) && streams.Contains(ParticleSystemVertexStream.Center);
                    if (!correctSetup)
                    {
                        EditorGUILayout.HelpBox("Particle System Renderer is using this material with incorrect Vertex Streams. Use Apply to System button to fix this", MessageType.Warning);
                        if (GUILayout.Button("Apply to System"))
                        {
                            if(!streams.Contains(ParticleSystemVertexStream.Position)) streams.Add(ParticleSystemVertexStream.Position);
                            if (!streams.Contains(ParticleSystemVertexStream.Center)) streams.Add(ParticleSystemVertexStream.Center);
                            particles.SetActiveVertexStreams(streams);
                        }
                    }
                }
                else
                {
                    EditorGUILayout.HelpBox("Shader rendered by Mesh Renderer, but using setup for particles. Shader will be appearing incorrectly!", MessageType.Warning);
                    if (GUILayout.Button("Fix now"))
                        Particle_Render.floatValue = 0.0f;
                }
            }
            else 
            {
                if (particles != null)
                {
                    EditorGUILayout.HelpBox("Shader rendered by Particle System, but using setup for meshes. Shader will be appearing incorrectly!", MessageType.Warning);
                    if (GUILayout.Button("Fix now"))
                        Particle_Render.floatValue = 1.0f;
                }
            }
        }

        GUILayout.Label("Fade settings", EditorStyles.boldLabel);
        _materialEditor.ShaderProperty(_MinRange, "Start fading");
        _materialEditor.ShaderProperty(_MaxRange, "End fading");
        GUILayout.Label("Editor settings", EditorStyles.boldLabel);
        useSliders = EditorGUILayout.Toggle("More SLIDERS!!!", useSliders);
        if(GUILayout.Button("[Experimental] Setup random effects"))
        {
            Glitch.floatValue = Mathf.RoundToInt(UnityEngine.Random.value * 0.6f);
            Magnification.floatValue = Mathf.RoundToInt(UnityEngine.Random.Range(0, 5));
            _SizeGirls.floatValue = UnityEngine.Random.value * 0.6f;
            ScreenRotation.floatValue = Mathf.RoundToInt(UnityEngine.Random.value * 0.6f);
            _ScreenHorizontalFlip.floatValue = Mathf.RoundToInt(UnityEngine.Random.value * 0.6f);
            _ScreenVerticalFlip.floatValue = Mathf.RoundToInt(UnityEngine.Random.value * 0.6f);
            Shake.floatValue = Mathf.RoundToInt(UnityEngine.Random.value * 0.6f);
            Pixelization.floatValue = Mathf.RoundToInt(UnityEngine.Random.value * 0.6f);
            Distorsion.floatValue = Mathf.RoundToInt(UnityEngine.Random.value * 0.6f);
            Blur.floatValue = Mathf.RoundToInt(UnityEngine.Random.Range(0, 4));
            if(Blur.floatValue == 0)
                Chromatic_Aberration.floatValue = Mathf.RoundToInt(UnityEngine.Random.Range(0, 2));
            Neon.floatValue = Mathf.RoundToInt(UnityEngine.Random.value * 0.6f);
            HSV_Selection.floatValue = Mathf.RoundToInt(UnityEngine.Random.value * 0.6f);
            HSV_Transform.floatValue = Mathf.RoundToInt(UnityEngine.Random.value * 0.6f);
            Color_Tint.floatValue = Mathf.RoundToInt(UnityEngine.Random.value * 0.6f);
            Posterization.floatValue = Mathf.RoundToInt(UnityEngine.Random.value * 0.6f);
            Dithering.floatValue = Mathf.RoundToInt(UnityEngine.Random.value * 0.6f);
            Overlay_Texture.floatValue = Mathf.RoundToInt(UnityEngine.Random.value * 0.6f);
            Static_Noise.floatValue = Mathf.RoundToInt(UnityEngine.Random.value * 0.6f);
            Vignette.floatValue = Mathf.RoundToInt(UnityEngine.Random.value * 0.6f);
            Mask_Texture.floatValue = Mathf.RoundToInt(UnityEngine.Random.value*0.6f);
        }
    }
    void DrawZoomSettings()
    {
        _Magnification = FindProperty("_Magnification", _props);
        _Gravitation = FindProperty("_Gravitation", _props);
        _AngleStartFade = FindProperty("_AngleStartFade", _props);
        _MaxAngle = FindProperty("_MaxAngle", _props);

        _materialEditor.ShaderProperty(Magnification, "Mode");
        _materialEditor.ShaderProperty(_Magnification, "Zoom/Scale");

        GUILayout.Label("Zoom ranges", EditorStyles.boldLabel);
        _materialEditor.ShaderProperty(_Gravitation, "Gravitation range");
        _materialEditor.ShaderProperty(_AngleStartFade, "Angle range");
        _materialEditor.ShaderProperty(_MaxAngle, "Max Angle range");
    }
    void DrawGirlscam()
    {
        _TimeGirls = FindProperty("_TimeGirls", _props);

        _materialEditor.ShaderProperty(_SizeGirls, "Size");
        _materialEditor.ShaderProperty(_TimeGirls, "Time");

        GUILayout.Label("Looks best if you put Time to almost max and then adjust the Size to your liking.", EditorStyles.helpBox);
    }
    void DrawRotation()
    {
        _ScreenRotation = FindProperty("_ScreenRotation", _props);
        _ScreenRotationSpeed = FindProperty("_ScreenRotationSpeed", _props);

        _materialEditor.ShaderProperty(_ScreenRotation, "Angle");
        _materialEditor.ShaderProperty(_ScreenRotationSpeed, "Shake speed");
    }
    void DrawScreenTransform()
    {
        GUILayout.Label("Screen flip", EditorStyles.boldLabel);
        _materialEditor.ShaderProperty(_ScreenHorizontalFlip, "Horizontal");
        _materialEditor.ShaderProperty(_ScreenVerticalFlip, "Vertical");
    }
    void DrawScreenShake()
    {
        _ShakeTex = FindProperty("_ShakeTex", _props);
        _SIntensity_X = FindProperty("_SIntensity_X", _props);
        _SIntensity_Y = FindProperty("_SIntensity_Y", _props);
        _ShakeScroll = FindProperty("_ShakeScroll", _props);
        _ShakeWave = FindProperty("_ShakeWave", _props);
        _ShakeWaveSpeed = FindProperty("_ShakeWaveSpeed", _props);

        GUILayout.Label("Texture settings", EditorStyles.boldLabel);
        _materialEditor.ShaderProperty(_ShakeTex, "Normal Map");
        _materialEditor.ShaderProperty(_SIntensity_X, "Intensity X");
        _materialEditor.ShaderProperty(_SIntensity_Y, "Intensity Y");
        if (useSliders)
        {
            _ShakeScroll.vectorValue = new Vector4(
                EditorGUILayout.Slider("Scroll X", _ShakeScroll.vectorValue.x, -10, 10),
                EditorGUILayout.Slider("Scroll Y", _ShakeScroll.vectorValue.y, -10, 10));

            GUILayout.Label("Wave settings", EditorStyles.boldLabel);
            _ShakeWave.vectorValue = new Vector4(
                EditorGUILayout.Slider("Offset X", _ShakeWave.vectorValue.x, 0, 0.25f),
                EditorGUILayout.Slider("Offset Y", _ShakeWave.vectorValue.y, 0, 0.25f));
            _ShakeWaveSpeed.vectorValue = new Vector4(
                EditorGUILayout.Slider("Speed X", _ShakeWaveSpeed.vectorValue.x, 0, 100),
                EditorGUILayout.Slider("Speed Y", _ShakeWaveSpeed.vectorValue.y, 0, 100));
        }
        else
        {
            _ShakeScroll.vectorValue = EditorGUILayout.Vector2Field("Scroll", _ShakeScroll.vectorValue);

            GUILayout.Label("Wave settings", EditorStyles.boldLabel);
            _ShakeWave.vectorValue = EditorGUILayout.Vector2Field("Offset", _ShakeWave.vectorValue);
            _ShakeWaveSpeed.vectorValue = EditorGUILayout.Vector2Field("Speed", _ShakeWaveSpeed.vectorValue);
        }
    }
    void DrawPixelation()
    {
        _PSize_X = FindProperty("_PSize_X", _props);
        _PSize_Y = FindProperty("_PSize_Y", _props);

        GUILayout.Label("Pixel size", EditorStyles.boldLabel);
        _materialEditor.ShaderProperty(_PSize_X, "Width");
        _materialEditor.ShaderProperty(_PSize_Y, "Height");
    }
    void DrawScreenDistortion()
    {
        Wave_Distorsion = FindProperty("Wave_Distorsion", _props);
        Texture_Distorsion = FindProperty("Texture_Distorsion", _props);
        _DistorsionTex = FindProperty("_DistorsionTex", _props);
        _DIntensity_X = FindProperty("_DIntensity_X", _props);
        _DIntensity_Y = FindProperty("_DIntensity_Y", _props);
        _DistorsionScroll = FindProperty("_DistorsionScroll", _props);
        _DistorsionWave = FindProperty("_DistorsionWave", _props);
        _DistorsionWaveSpeed = FindProperty("_DistorsionWaveSpeed", _props);
        _DistorsionWaveDensity = FindProperty("_DistorsionWaveDensity", _props);

        GUILayout.Label("Texture settings", EditorStyles.boldLabel);
        _materialEditor.ShaderProperty(Texture_Distorsion, "Active");
        _materialEditor.ShaderProperty(_DistorsionTex, "Normal Map");
        _materialEditor.ShaderProperty(_DIntensity_X, "Horizontal distortion");
        _materialEditor.ShaderProperty(_DIntensity_Y, "Vertical distortion");
        if (useSliders)
        {
            _DistorsionScroll.vectorValue = new Vector4(
                EditorGUILayout.Slider("Scroll texture X", _DistorsionScroll.vectorValue.x, -10, 10),
                EditorGUILayout.Slider("Scroll texture Y", _DistorsionScroll.vectorValue.y, -10, 10));

            GUILayout.Label("Wave settings", EditorStyles.boldLabel);
            _materialEditor.ShaderProperty(Wave_Distorsion, "Active");
            _DistorsionWave.vectorValue = new Vector4(
                EditorGUILayout.Slider("Offset X", _DistorsionWave.vectorValue.x, 0, 0.1f),
                EditorGUILayout.Slider("Offset Y", _DistorsionWave.vectorValue.y, 0, 0.1f));
            _DistorsionWaveSpeed.vectorValue = new Vector4(
                EditorGUILayout.Slider("Speed X", _DistorsionWaveSpeed.vectorValue.x, 0, 20),
                EditorGUILayout.Slider("Speed Y", _DistorsionWaveSpeed.vectorValue.y, 0, 20));
            _DistorsionWaveDensity.vectorValue = new Vector4(
                EditorGUILayout.Slider("Density X", _DistorsionWaveDensity.vectorValue.x, 0, 10),
                EditorGUILayout.Slider("Density Y", _DistorsionWaveDensity.vectorValue.y, 0, 10));
        }
        else
        {
            _DistorsionScroll.vectorValue = EditorGUILayout.Vector2Field("Scroll texture", _DistorsionScroll.vectorValue);

            GUILayout.Label("Wave settings", EditorStyles.boldLabel);
            _materialEditor.ShaderProperty(Wave_Distorsion, "Active");
            _DistorsionWave.vectorValue = EditorGUILayout.Vector2Field("Offset", _DistorsionWave.vectorValue);
            _DistorsionWaveSpeed.vectorValue = EditorGUILayout.Vector2Field("Speed", _DistorsionWaveSpeed.vectorValue);
            _DistorsionWaveDensity.vectorValue = EditorGUILayout.Vector2Field("Density", _DistorsionWaveDensity.vectorValue);
        }
    }
    void DrawBlurSettings()
    {
        Blur_Distorsion = FindProperty("Blur_Distorsion", _props);
        _BlurColor = FindProperty("_BlurColor", _props);
        _BlurRange = FindProperty("_BlurRange", _props);
        _BlurRotation = FindProperty("_BlurRotation", _props);
        _BlurRotationSpeed = FindProperty("_BlurRotationSpeed", _props);
        _BlurIterations = FindProperty("_BlurIterations", _props);
        _BlurCenterOffset = FindProperty("_BlurCenterOffset", _props);
        _BlurMask = FindProperty("_BlurMask", _props);

        _materialEditor.ShaderProperty(Blur, "Mode");
        _materialEditor.ShaderProperty(Blur_Distorsion, "Use Distortion");
        _materialEditor.ShaderProperty(_BlurColor, "Blur colour");
        _materialEditor.ShaderProperty(_BlurRange, "Offset");
        _materialEditor.ShaderProperty(_BlurRotation, "Rotation");
        _materialEditor.ShaderProperty(_BlurRotationSpeed, "Rotation speed");
        _materialEditor.ShaderProperty(_BlurIterations, "Samples");
        if (useSliders)
            _BlurCenterOffset.vectorValue = new Vector4(
                EditorGUILayout.Slider("Center offset X", _BlurCenterOffset.vectorValue.x, -1.0f, 1.0f),
                EditorGUILayout.Slider("Center offset Y", _BlurCenterOffset.vectorValue.y, -1.0f, 1.0f));
        else
            _BlurCenterOffset.vectorValue = EditorGUILayout.Vector2Field("Center offset", _BlurCenterOffset.vectorValue);
        _materialEditor.ShaderProperty(_BlurMask, "Mask effect");

        GUILayout.Label("Looks best if you put samples to max.", EditorStyles.helpBox);
    }
    void DrawChromaticAberration()
    {
        Aberration_Quality = FindProperty("Aberration_Quality", _props);
        CA_Distorsion = FindProperty("CA_Distorsion", _props);
        _CA_amplitude = FindProperty("_CA_amplitude", _props);
        _CA_iterations = FindProperty("_CA_iterations", _props);
        _CA_speed = FindProperty("_CA_speed", _props);
        _CA_direction = FindProperty("_CA_direction", _props);
        _CA_factor = FindProperty("_CA_factor", _props);
        _CA_centerOffset = FindProperty("_CA_centerOffset", _props);
        _CA_mask = FindProperty("_CA_mask", _props);

        _materialEditor.ShaderProperty(Chromatic_Aberration, "Mode");
        _materialEditor.ShaderProperty(Aberration_Quality, "Quality");
        _materialEditor.ShaderProperty(CA_Distorsion, "Use distortion");
        _materialEditor.ShaderProperty(_CA_amplitude, "Offset");
        _materialEditor.ShaderProperty(_CA_iterations, "Samples");
        _materialEditor.ShaderProperty(_CA_speed, "Animation speed");
        if (useSliders)
        {
            _CA_direction.vectorValue = new Vector4(
                EditorGUILayout.Slider("Vector direction X", _CA_direction.vectorValue.x, -1.0f, 1.0f),
                EditorGUILayout.Slider("Vector direction Y", _CA_direction.vectorValue.y, -1.0f, 1.0f));
            _materialEditor.ShaderProperty(_CA_factor, "Effect");
            _CA_centerOffset.vectorValue = new Vector4(
                EditorGUILayout.Slider("Radial center offset X", _CA_centerOffset.vectorValue.x, -1.0f, 1.0f),
                EditorGUILayout.Slider("Radial center offset Y", _CA_centerOffset.vectorValue.y, -1.0f, 1.0f));
        }
        else
        {
            _CA_direction.vectorValue = EditorGUILayout.Vector2Field("Vector direction", _CA_direction.vectorValue);
            _materialEditor.ShaderProperty(_CA_factor, "Effect");
            _CA_centerOffset.vectorValue = EditorGUILayout.Vector2Field("Radial center offset", _CA_centerOffset.vectorValue);
        }
        _materialEditor.ShaderProperty(_CA_mask, "Mask effect");
    }
    void DrawNeon()
    {
        _NeonColor = FindProperty("_NeonColor", _props);
        _NeonColorAlpha = FindProperty("_NeonColorAlpha", _props);
        _NeonOrigColor = FindProperty("_NeonOrigColor", _props);
        _NeonOrigColorAlpha = FindProperty("_NeonOrigColorAlpha", _props);
        _NeonBrightness = FindProperty("_NeonBrightness", _props);
        _NeonPosterization = FindProperty("_NeonPosterization", _props);
        _NeonWidth = FindProperty("_NeonWidth", _props);
        _NeonGlow = FindProperty("_NeonGlow", _props);

        _materialEditor.ShaderProperty(_NeonColor, "Tint");
        _materialEditor.ShaderProperty(_NeonColorAlpha, "Intensity");
        _materialEditor.ShaderProperty(_NeonOrigColor, "Background colour");
        _materialEditor.ShaderProperty(_NeonOrigColorAlpha, "Background mix");
        _materialEditor.ShaderProperty(_NeonBrightness, "Brightness");
        _materialEditor.ShaderProperty(_NeonPosterization, "Posterization");
        _materialEditor.ShaderProperty(_NeonWidth, "Width");
        _materialEditor.ShaderProperty(_NeonGlow, "Glow");
    }
    void DrawHSVColourSpace()
    {
        _TargetColor = FindProperty("_TargetColor", _props);
        _HueRange = FindProperty("_HueRange", _props);
        _SaturationRange = FindProperty("_SaturationRange", _props);
        _LightnessRange = FindProperty("_LightnessRange", _props);
        _HueSmoothRange = FindProperty("_HueSmoothRange", _props);
        _SaturationSmoothRange = FindProperty("_SaturationSmoothRange", _props);
        _LightnessSmoothRange = FindProperty("_LightnessSmoothRange", _props);
        HSV_Desaturate_Selected = FindProperty("HSV_Desaturate_Selected", _props);
        _TransformColor = FindProperty("_TransformColor", _props);
        _Hue = FindProperty("_Hue", _props);
        _HueAnimationSpeed = FindProperty("_HueAnimationSpeed", _props);
        _Saturation = FindProperty("_Saturation", _props);
        _Lightness = FindProperty("_Lightness", _props);

        GUILayout.Label("Selection settings", EditorStyles.boldLabel);
        _materialEditor.ShaderProperty(HSV_Selection, "Selection enable");
        _materialEditor.ShaderProperty(_TargetColor, "Select colour");
        _materialEditor.ShaderProperty(_HueRange, "HUE range");
        _materialEditor.ShaderProperty(_SaturationRange, "Saturation range");
        _materialEditor.ShaderProperty(_LightnessRange, "Lightness range");
        _materialEditor.ShaderProperty(_HueSmoothRange, "HUE fade");
        _materialEditor.ShaderProperty(_SaturationSmoothRange, "Saturation fade");
        _materialEditor.ShaderProperty(_LightnessSmoothRange, "Lightness fade");
        _materialEditor.ShaderProperty(HSV_Desaturate_Selected, "Desaturate");

        GUILayout.Label("Transform settings", EditorStyles.boldLabel);
        _materialEditor.ShaderProperty(HSV_Transform, "Transform enable");
        _materialEditor.ShaderProperty(_TransformColor, "Transform colour");
        _materialEditor.ShaderProperty(_Hue, "HUE value");
        _materialEditor.ShaderProperty(_HueAnimationSpeed, "HUE animation speed");
        _materialEditor.ShaderProperty(_Saturation, "Saturation value");
        _materialEditor.ShaderProperty(_Lightness, "Lightness value");
    }
    void DrawColourCorrection()
    {
        ACES_Tonemapping = FindProperty("ACES_Tonemapping", _props);
        _EmissionColor = FindProperty("_EmissionColor", _props);
        _Color = FindProperty("_Color", _props);
        _ColorAlpha = FindProperty("_ColorAlpha", _props);
        _Grayscale = FindProperty("_Grayscale", _props);
        _Contrast = FindProperty("_Contrast", _props);
        _Gamma = FindProperty("_Gamma", _props);
        _Brightness = FindProperty("_Brightness", _props);
        _RedInvert = FindProperty("_RedInvert", _props);
        _GreenInvert = FindProperty("_GreenInvert", _props);
        _BlueInvert = FindProperty("_BlueInvert", _props);

        _materialEditor.ShaderProperty(ACES_Tonemapping, "ACES tonemapping");
        _materialEditor.ShaderProperty(_EmissionColor, "Emission colour");
        _materialEditor.ShaderProperty(_Color, "Mix colour");
        _materialEditor.ShaderProperty(_ColorAlpha, "Mix factor");
        _materialEditor.ShaderProperty(_Grayscale, "Grayscale");
        if (useSliders)
        {
            GUILayout.Label("Contrast", EditorStyles.boldLabel);
            _Contrast.vectorValue = new Vector4(
                EditorGUILayout.Slider("Red", _Contrast.vectorValue.x, 0, 10),
                EditorGUILayout.Slider("Green", _Contrast.vectorValue.y, 0, 10),
                EditorGUILayout.Slider("Blue", _Contrast.vectorValue.z, 0, 10));

            GUILayout.Label("Gamma", EditorStyles.boldLabel);
            _Gamma.vectorValue = new Vector4(
                EditorGUILayout.Slider("Red", _Gamma.vectorValue.x, 0, 10),
                EditorGUILayout.Slider("Green", _Gamma.vectorValue.y, 0, 10),
                EditorGUILayout.Slider("Blue", _Gamma.vectorValue.z, 0, 10));

            GUILayout.Label("Brightness", EditorStyles.boldLabel);
            _Brightness.vectorValue = new Vector4(
                EditorGUILayout.Slider("Red", _Brightness.vectorValue.x, 0, 10),
                EditorGUILayout.Slider("Green", _Brightness.vectorValue.y, 0, 10),
                EditorGUILayout.Slider("Blue", _Brightness.vectorValue.z, 0, 10));

            GUILayout.Label("Invert", EditorStyles.boldLabel);
            _materialEditor.ShaderProperty(_RedInvert, "Red");
            _materialEditor.ShaderProperty(_GreenInvert, "Green");
            _materialEditor.ShaderProperty(_BlueInvert, "Blue");

        }
        else
        {
            _Contrast.vectorValue = EditorGUILayout.Vector3Field("Contrast", _Contrast.vectorValue);
            _Gamma.vectorValue = EditorGUILayout.Vector3Field("Gamma", _Gamma.vectorValue);
            _Brightness.vectorValue = EditorGUILayout.Vector3Field("Brightness", _Brightness.vectorValue);
            Vector3 invert = EditorGUILayout.Vector3Field("Invert", new Vector3(_RedInvert.floatValue, _GreenInvert.floatValue, _BlueInvert.floatValue));
            _RedInvert.floatValue = invert.x;
            _GreenInvert.floatValue = invert.y;
            _BlueInvert.floatValue = invert.z;
        }
        
    }
    void DrawPosterization()
    {
        _PosterizationSteps = FindProperty("_PosterizationSteps", _props);

        _materialEditor.ShaderProperty(_PosterizationSteps, "Gradient steps");
    }
    void DrawDithering()
    {
        _DitheringMask = FindProperty("_DitheringMask", _props);

        _materialEditor.ShaderProperty(_DitheringMask, "Dithering mask");
    }
    void DrawOverlayTexture()
    {
        Overlay_Grid = FindProperty("Overlay_Grid", _props);
        _OverlayTex = FindProperty("_OverlayTex", _props);
        _OverlayTint = FindProperty("_OverlayTint", _props);
        _OverlayScroll = FindProperty("_OverlayScroll", _props);
        _OverlayRotation = FindProperty("_OverlayRotation", _props);
        _OverlayOpaque = FindProperty("_OverlayOpaque", _props);
        _OverlayTransparent = FindProperty("_OverlayTransparent", _props);

        Overlay_Texture_Sheet = FindProperty("Overlay_Texture_Sheet", _props);
        _OverlayColumns = FindProperty("_OverlayColumns", _props);
        _OverlayRows = FindProperty("_OverlayRows", _props);
        _OverlayStartFrame = FindProperty("_OverlayStartFrame", _props);
        _OverlayTotalFrames = FindProperty("_OverlayTotalFrames", _props);
        _OverlayAnimationSpeed = FindProperty("_OverlayAnimationSpeed", _props);

        _materialEditor.ShaderProperty(Overlay_Grid, "Image grid");
        _materialEditor.ShaderProperty(_OverlayTex, "Texture");
        _materialEditor.ShaderProperty(_OverlayTint, "Tint");
        _materialEditor.ShaderProperty(_OverlayOpaque, "Opaque");
        _materialEditor.ShaderProperty(_OverlayTransparent, "Transparent");
        _materialEditor.ShaderProperty(_OverlayRotation, "Rotation");
        if (useSliders)
        {
            _OverlayScroll.vectorValue = new Vector4(
                EditorGUILayout.Slider("Scroll vector X", _OverlayScroll.vectorValue.x, -10, 10),
                EditorGUILayout.Slider("Scroll vector Y", _OverlayScroll.vectorValue.y, -10, 10));
        }
        else
            _OverlayScroll.vectorValue = EditorGUILayout.Vector2Field("Scroll vector", _OverlayScroll.vectorValue);

        GUILayout.Label("Texture sheet animation", EditorStyles.boldLabel);
        _materialEditor.ShaderProperty(Overlay_Texture_Sheet, "Enable");
        _materialEditor.ShaderProperty(_OverlayColumns, "Columns");
        _materialEditor.ShaderProperty(_OverlayRows, "Rows");
        _materialEditor.ShaderProperty(_OverlayStartFrame, "Start frame");
        _materialEditor.ShaderProperty(_OverlayTotalFrames, "Total frames");
        _materialEditor.ShaderProperty(_OverlayAnimationSpeed, "Animation speed");
    }
    void DrawGlitch()
    {
        _BlockSize = FindProperty("_BlockSize", _props);
        _BlockGlitch = FindProperty("_BlockGlitch", _props);
        _LineGlitch = FindProperty("_LineGlitch", _props);
        _UPS = FindProperty("_UPS", _props);
        _ActiveTime = FindProperty("_ActiveTime", _props);
        _Period = FindProperty("_Period", _props);

        _materialEditor.ShaderProperty(_BlockSize, "Block size");
        _materialEditor.ShaderProperty(_BlockGlitch, "Block Glitch");
        _materialEditor.ShaderProperty(_LineGlitch, "Line Glitch");
        _materialEditor.ShaderProperty(_UPS, "Glitches per second");
        _materialEditor.ShaderProperty(_ActiveTime, "Active Time");
        _materialEditor.ShaderProperty(_Period, "Period Time");
        EditorGUILayout.HelpBox("The Glitch affects on others modules: Chromatic Aberration, Color Correction, Pixelation", MessageType.Info);

    }
    void DrawStatic()
    {
        _StaticColour = FindProperty("_StaticColour", _props);
        _StaticIntensity = FindProperty("_StaticIntensity", _props);
        _StaticAlpha = FindProperty("_StaticAlpha", _props);
        _StaticBrightness = FindProperty("_StaticBrightness", _props);
        _MaskAmount = FindProperty("_MaskAmount", _props);

        _materialEditor.ShaderProperty(_StaticColour, "Color");
        _materialEditor.ShaderProperty(_StaticIntensity, new GUIContent("Intensity", "Noise amplitude"));
        GUILayout.Label("Extra settings", EditorStyles.boldLabel);
        _materialEditor.ShaderProperty(_StaticAlpha, new GUIContent("Alpha", "Effect scene color to noise"));
        _materialEditor.ShaderProperty(_StaticBrightness, new GUIContent("Brightness", "Scene light"));

        //GUILayout.Label("Looks best if you put Static Colour to white, put Static Alpha to 0.83, put Static Brightness to 4.2, and put Static Intensity to -0.6.", EditorStyles.helpBox);
        GUILayout.Label(
            "-Static Added by: Aidan.ogg#0001\n" +
            "-Updated by: Leviant#8796", EditorStyles.miniBoldLabel);
    }
    void DrawVignette()
    {
        _VignetteColor = FindProperty("_VignetteColor", _props);
        _VignetteAlpha = FindProperty("_VignetteAlpha", _props);
        _VignetteWidth = FindProperty("_VignetteWidth", _props);
        _VignetteShape = FindProperty("_VignetteShape", _props);
        _VignetteRounding = FindProperty("_VignetteRounding", _props);

        _materialEditor.ShaderProperty(_VignetteColor, "Colour");
        _materialEditor.ShaderProperty(_VignetteAlpha, "Transparent");
        _materialEditor.ShaderProperty(_VignetteWidth, "Width");
        _materialEditor.ShaderProperty(_VignetteShape, "Shape");
        _materialEditor.ShaderProperty(_VignetteRounding, "Rounding");
    }
    void DrawMaskTexture()
    {
        Mask_Multisampling = FindProperty("Mask_Multisampling", _props);
        Mask_Noise = FindProperty("Mask_Noise", _props);
        _MaskTex = FindProperty("_MaskTex", _props);
        _MaskColor = FindProperty("_MaskColor", _props);
        _MaskAlpha = FindProperty("_MaskAlpha", _props);
        _MaskScroll = FindProperty("_MaskScroll", _props);

        _materialEditor.ShaderProperty(Mask_Multisampling, "Multisampling");
        _materialEditor.ShaderProperty(Mask_Noise, "Generate noise");
        _materialEditor.ShaderProperty(_MaskTex, "Mask");
        _materialEditor.ShaderProperty(_MaskColor, "Mix colour");
        _materialEditor.ShaderProperty(_MaskAlpha, "Mix factor");
        if (useSliders)
        {
            _MaskScroll.vectorValue = new Vector4(
                EditorGUILayout.Slider("Scroll vector X", _MaskScroll.vectorValue.x, -10, 10),
                EditorGUILayout.Slider("Scroll vector Y", _MaskScroll.vectorValue.y, -10, 10));
        }
        else
            _MaskScroll.vectorValue = EditorGUILayout.Vector2Field("Scroll vector", _MaskScroll.vectorValue);
    }
    void DrawHELP()
    {
        EditorGUI.indentLevel++;
        GUILayout.Label(
            "-If you have any questions DM us on Discord: Leviant#8796 & Aidan.ogg#0001\n" +
            "-Version 1.6", EditorStyles.helpBox);
        EditorGUI.indentLevel--;
    }
    void DrawCredits()
    {
        EditorGUI.indentLevel++;
        GUILayout.Label(
            "-Made By: Leviant#8796\n" +
            "-Edited by: Aidan.ogg#0001\n" +
            "-Editor Created by: Aidan.ogg#0001", EditorStyles.helpBox);
        EditorGUI.indentLevel--;
    }
    //Draws Buttons
    void DrawLeviantPayPal()
    {
        if (LinkButton(paypalURL))
        {
            Application.OpenURL(paypalURL);
        }
    }
    bool LinkButton(string caption)
    {
        bool clicked = GUILayout.Button(caption, linkStyle);
        if (Event.current.type == EventType.Repaint)
            linkRect = GUILayoutUtility.GetLastRect();

        EditorGUIUtility.AddCursorRect(linkRect, MouseCursor.Link);

        return clicked;
    }
    static bool GetFoldState(Category c)
    {
        return (foldState & (1 << (int)c)) > 0;
    }
    static void SetFoldState(Category c, bool active)
    {
        if(active)
            foldState |= 1 << (int)c;
        else
            foldState &= ~(1 << (int)c);
    }
    static bool BeginFold(Category fold, params MaterialProperty[] toggles)
    {
        EditorGUILayout.BeginVertical(layoutStyle);
        EditorGUI.indentLevel++;

        //FoldoutforLeviant fold = FoldoutforLeviant.Get(bit);
        EditorGUILayout.BeginHorizontal(introLayoutStyle);
        bool active = EditorGUILayout.Foldout(GetFoldState(fold), labels[fold], true, foldLabelStyle);
        GUILayout.FlexibleSpace();
        EditorGUILayout.Toggle(activeText, toggles.Any(toggle => toggle.floatValue != 0.0f), toggleStyle);
        EditorGUILayout.EndHorizontal();
        SetFoldState(fold, active);

        return active;
    }
    static bool BeginToggleFold(Category fold, MaterialProperty toggle)
    {
        EditorGUILayout.BeginVertical(layoutStyle);
        EditorGUI.indentLevel++;

        //FoldoutforLeviant fold = FoldoutforLeviant.Get(bit);
        EditorGUILayout.BeginHorizontal(introLayoutStyle);
        bool active = EditorGUILayout.Foldout(GetFoldState(fold), labels[fold], true, foldLabelStyle);
        GUILayout.FlexibleSpace();
        toggle.floatValue = EditorGUILayout.Toggle("Active", toggle.floatValue != 0.0f, toggleStyle) ? 1.0f : 0.0f;
        EditorGUILayout.EndHorizontal();
        SetFoldState(fold, active);

        return active;
    }
    static bool BeginFold(Category fold, MaterialProperty toggle)
    {
        EditorGUILayout.BeginVertical(layoutStyle);
        EditorGUI.indentLevel++;

        //FoldoutforLeviant fold = FoldoutforLeviant.Get(bit);
        EditorGUILayout.BeginHorizontal(introLayoutStyle);
        bool active = EditorGUILayout.Foldout(GetFoldState(fold), labels[fold], true, foldLabelStyle);
        GUILayout.FlexibleSpace();
        EditorGUILayout.Toggle("Active", toggle.floatValue != 0.0f, toggleStyle);
        EditorGUILayout.EndHorizontal();

        SetFoldState(fold, active);
        return active;
    }
    static bool BeginFold(Category fold)
    {
        EditorGUILayout.BeginVertical(layoutStyle);
        EditorGUI.indentLevel++;

        //FoldoutforLeviant fold = FoldoutforLeviant.Get(bit);
        bool active = EditorGUILayout.Foldout(GetFoldState(fold), labels[fold], true, foldLabelStyle);
        SetFoldState(fold, active);
        return active;
    }

    static void EndFold()
    {
        EditorGUI.indentLevel--;
        EditorGUILayout.EndVertical();
    }
}
