//Made by Aidan.ogg#0001 for Leviant#8796
using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class LeviantScreenSpaceEditor : ShaderGUI
{
    Material _material;
    MaterialProperty[] _props;
    MaterialEditor _materialEditor;

    //Main Settings
    private MaterialProperty Particle_Render = null;
    //Fade Settings
    private MaterialProperty _MinRange = null;
    private MaterialProperty _MaxRange = null;

    //Zoom Settings
    private MaterialProperty Magnification = null;
    private MaterialProperty _Magnification = null;
    private MaterialProperty _Gravitation = null;
    private MaterialProperty _AngleStartFade = null;
    private MaterialProperty _MaxAngle = null;

    //Girlscam
    private MaterialProperty _SizeGirls = null;
    private MaterialProperty _TimeGirls = null;

    //Rotation
    private MaterialProperty ScreenRotation = null;
    private MaterialProperty _ScreenRotation = null;
    private MaterialProperty _ScreenRotationSpeed = null;

    //Screen Transform
    private MaterialProperty _ScreenHorizontalFlip = null;
    private MaterialProperty _ScreenVerticalFlip = null;

    //Screen Shake
    private MaterialProperty Shake = null;
    private MaterialProperty _ShakeTex = null;
    private MaterialProperty _SIntensity_X = null;
    private MaterialProperty _SIntensity_Y = null;
    private MaterialProperty _ShakeScroll = null;
    private MaterialProperty _ShakeWave = null;
    private MaterialProperty _ShakeWaveSpeed = null;

    //Pixelation
    private MaterialProperty Pixelization = null;
    private MaterialProperty _PSize_X = null;
    private MaterialProperty _PSize_Y = null;

    //Screen Distortion
    private MaterialProperty Distorsion = null;
    private MaterialProperty Wave_Distorsion = null;
    private MaterialProperty Texture_Distorsion = null;
    private MaterialProperty _DistorsionTex = null;
    private MaterialProperty _DIntensity_X = null;
    private MaterialProperty _DIntensity_Y = null;
    private MaterialProperty _DistorsionScroll = null;
    private MaterialProperty _DistorsionWave = null;
    private MaterialProperty _DistorsionWaveSpeed = null;
    private MaterialProperty _DistorsionWaveDensity = null;

    //Blur Settings
    private MaterialProperty Blur = null;
    private MaterialProperty Blur_Distorsion = null;
    private MaterialProperty _BlurColor = null;
    private MaterialProperty _BlurRange = null;
    private MaterialProperty _BlurRotation = null;
    private MaterialProperty _BlurRotationSpeed = null;
    private MaterialProperty _BlurIterations = null;
    private MaterialProperty _BlurCenterOffset = null;
    private MaterialProperty _BlurMask = null;

    //Chromatic Aberration
    private MaterialProperty Chromatic_Aberration = null;
    private MaterialProperty Aberration_Quality = null;
    private MaterialProperty CA_Distorsion = null;
    private MaterialProperty _CA_amplitude = null;
    private MaterialProperty _CA_iterations = null;
    private MaterialProperty _CA_speed = null;
    private MaterialProperty _CA_direction = null;
    private MaterialProperty _CA_factor = null;
    private MaterialProperty _CA_centerOffset = null;
    private MaterialProperty _CA_mask = null;

    //Neon
    private MaterialProperty Neon = null;
    private MaterialProperty _NeonColor = null;
    private MaterialProperty _NeonOrigColor = null;
    private MaterialProperty _NeonBrightness = null;
    private MaterialProperty _NeonPosterization = null;
    private MaterialProperty _NeonWidth = null;
    private MaterialProperty _NeonGlow = null;

    //HSV Colour Space
    private MaterialProperty HSV_Selection = null;
    private MaterialProperty _TargetColor = null;
    private MaterialProperty _HueRange = null;
    private MaterialProperty _SaturationRange = null;
    private MaterialProperty _LightnessRange = null;
    private MaterialProperty _HueSmoothRange = null;
    private MaterialProperty _SaturationSmoothRange = null;
    private MaterialProperty _LightnessSmoothRange = null;
    private MaterialProperty HSV_Desaturate_Selected = null;
    //Extra Settings
    private MaterialProperty HSV_Transform = null;
    private MaterialProperty _TransformColor = null;
    private MaterialProperty _Hue = null;
    private MaterialProperty _HueAnimationSpeed = null;
    private MaterialProperty _Saturation = null;
    private MaterialProperty _Lightness = null;

    //Colour Correction
    private MaterialProperty Color_Tint = null;
    private MaterialProperty ACES_Tonemapping = null;
    private MaterialProperty _EmissionColor = null;
    private MaterialProperty _Color = null;
    private MaterialProperty _Grayscale = null;
    private MaterialProperty _Contrast = null;
    private MaterialProperty _Gamma = null;
    private MaterialProperty _Brightness = null;
    private MaterialProperty _RedInvert = null;
    private MaterialProperty _GreenInvert = null;
    private MaterialProperty _BlueInvert = null;

    //Posterization
    private MaterialProperty Posterization = null;
    private MaterialProperty _PosterizationSteps = null;

    //Dithering
    private MaterialProperty Dithering = null;
    private MaterialProperty _DitheringMask = null;

    //Overlay Texture
    private MaterialProperty Overlay_Texture = null;
    private MaterialProperty _OverlayTex = null;
    private MaterialProperty _OverlayTint = null;
    private MaterialProperty _OverlayScroll = null;

    //Static
    private MaterialProperty Static_Noise = null;
    private MaterialProperty _StaticColour = null;
    private MaterialProperty _StaticIntensity = null;
    //Extra Settings
    private MaterialProperty _StaticAlpha = null;
    private MaterialProperty _StaticBrightness = null;
    private MaterialProperty _MaskAmount = null;

    //Vignette
    private MaterialProperty Vignette = null;
    private MaterialProperty _VignetteColor = null;
    private MaterialProperty _VignetteWidth = null;

    //Mask Texture
    private MaterialProperty Mask_Texture = null;
    private MaterialProperty Mask_Multisampling = null;
    private MaterialProperty Mask_Noise = null;
    private MaterialProperty _MaskTex = null;
    private MaterialProperty _MaskColor = null;
    private MaterialProperty _MaskScroll = null;

    //Stlyes
    GUIStyle friendStyle;

    private static class Styles
    {
        public static GUIContent MainText = new GUIContent("Background Texture");
    }

    enum Category
    {
        MainSettings,
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

    void AssignProperties()
    {

        //Main Settings
        Particle_Render = FindProperty("Particle_Render", _props);
        //Fade Settings
        _MinRange = FindProperty("_MinRange", _props);
        _MaxRange = FindProperty("_MaxRange", _props);

        //Zoom Settings
        Magnification = FindProperty("Magnification", _props);
        _Magnification = FindProperty("_Magnification", _props);
        _Gravitation = FindProperty("_Gravitation", _props);
        _AngleStartFade = FindProperty("_AngleStartFade", _props);
        _MaxAngle = FindProperty("_MaxAngle", _props);

        //Girlscam
        _SizeGirls = FindProperty("_SizeGirls", _props);
        _TimeGirls = FindProperty("_TimeGirls", _props);

        //Rotation
        ScreenRotation = FindProperty("ScreenRotation", _props);
        _ScreenRotation = FindProperty("_ScreenRotation", _props);
        _ScreenRotationSpeed = FindProperty("_ScreenRotationSpeed", _props);

        //Screen Transform
        _ScreenHorizontalFlip = FindProperty("_ScreenHorizontalFlip", _props);
        _ScreenVerticalFlip = FindProperty("_ScreenVerticalFlip", _props);

        //Screen Shake
        Shake = FindProperty("Shake", _props);
        _ShakeTex = FindProperty("_ShakeTex", _props);
        _SIntensity_X = FindProperty("_SIntensity_X", _props);
        _SIntensity_Y = FindProperty("_SIntensity_Y", _props);
        _ShakeScroll = FindProperty("_ShakeScroll", _props);
        _ShakeWave = FindProperty("_ShakeWave", _props);
        _ShakeWaveSpeed = FindProperty("_ShakeWaveSpeed", _props);

        //Pixelation
        Pixelization = FindProperty("Pixelization", _props);
        _PSize_X = FindProperty("_PSize_X", _props);
        _PSize_Y = FindProperty("_PSize_Y", _props);

        //Screen Distortion
        Distorsion = FindProperty("Distorsion", _props);
        Wave_Distorsion = FindProperty("Wave_Distorsion", _props);
        Texture_Distorsion = FindProperty("Texture_Distorsion", _props);
        _DistorsionTex = FindProperty("_DistorsionTex", _props);
        _DIntensity_X = FindProperty("_DIntensity_X", _props);
        _DIntensity_Y = FindProperty("_DIntensity_Y", _props);
        _DistorsionScroll = FindProperty("_DistorsionScroll", _props);
        _DistorsionWave = FindProperty("_DistorsionWave", _props);
        _DistorsionWaveSpeed = FindProperty("_DistorsionWaveSpeed", _props);
        _DistorsionWaveDensity = FindProperty("_DistorsionWaveDensity", _props);

        //Blur Settings
        Blur = FindProperty("Blur", _props);
        Blur_Distorsion = FindProperty("Blur_Distorsion", _props);
        _BlurColor = FindProperty("_BlurColor", _props);
        _BlurRange = FindProperty("_BlurRange", _props);
        _BlurRotation = FindProperty("_BlurRotation", _props);
        _BlurRotationSpeed = FindProperty("_BlurRotationSpeed", _props);
        _BlurIterations = FindProperty("_BlurIterations", _props);
        _BlurCenterOffset = FindProperty("_BlurCenterOffset", _props);
        _BlurMask = FindProperty("_BlurMask", _props);

        //Chromatic Aberration
        Chromatic_Aberration = FindProperty("Chromatic_Aberration", _props);
        Aberration_Quality = FindProperty("Aberration_Quality", _props);
        CA_Distorsion = FindProperty("CA_Distorsion", _props);
        _CA_amplitude = FindProperty("_CA_amplitude", _props);
        _CA_iterations = FindProperty("_CA_iterations", _props);
        _CA_speed = FindProperty("_CA_speed", _props);
        _CA_direction = FindProperty("_CA_direction", _props);
        _CA_factor = FindProperty("_CA_factor", _props);
        _CA_centerOffset = FindProperty("_CA_centerOffset", _props);
        _CA_mask = FindProperty("_CA_mask", _props);

        //Neon
        Neon = FindProperty("Neon", _props);
        _NeonColor = FindProperty("_NeonColor", _props);
        _NeonOrigColor = FindProperty("_NeonOrigColor", _props);
        _NeonBrightness = FindProperty("_NeonBrightness", _props);
        _NeonPosterization = FindProperty("_NeonPosterization", _props);
        _NeonWidth = FindProperty("_NeonWidth", _props);
        _NeonGlow = FindProperty("_NeonGlow", _props);

        //HSV Colour Space
        HSV_Selection = FindProperty("HSV_Selection", _props);
        _TargetColor = FindProperty("_TargetColor", _props);
        _HueRange = FindProperty("_HueRange", _props);
        _SaturationRange = FindProperty("_SaturationRange", _props);
        _LightnessRange = FindProperty("_LightnessRange", _props);
        _HueSmoothRange = FindProperty("_HueSmoothRange", _props);
        _SaturationSmoothRange = FindProperty("_SaturationSmoothRange", _props);
        _LightnessSmoothRange = FindProperty("_LightnessSmoothRange", _props);
        HSV_Desaturate_Selected = FindProperty("HSV_Desaturate_Selected", _props);
        //Extra Settings
        HSV_Transform = FindProperty("HSV_Transform", _props);
        _TransformColor = FindProperty("_TransformColor", _props);
        _Hue = FindProperty("_Hue", _props);
        _HueAnimationSpeed = FindProperty("_HueAnimationSpeed", _props);
        _Saturation = FindProperty("_Saturation", _props);
        _Lightness = FindProperty("_Lightness", _props);

        //Colour Correction
        Color_Tint = FindProperty("Color_Tint", _props);
        ACES_Tonemapping = FindProperty("ACES_Tonemapping", _props);
        _EmissionColor = FindProperty("_EmissionColor", _props);
        _Color = FindProperty("_Color", _props);
        _Grayscale = FindProperty("_Grayscale", _props);
        _Contrast = FindProperty("_Contrast", _props);
        _Gamma = FindProperty("_Gamma", _props);
        _Brightness = FindProperty("_Brightness", _props);
        _RedInvert = FindProperty("_RedInvert", _props);
        _GreenInvert = FindProperty("_GreenInvert", _props);
        _BlueInvert = FindProperty("_BlueInvert", _props);

        //Posterization
        Posterization = FindProperty("Posterization", _props);
        _PosterizationSteps = FindProperty("_PosterizationSteps", _props);

        //Dithering
        Dithering = FindProperty("Dithering", _props);
        _DitheringMask = FindProperty("_DitheringMask", _props);

        //Overlay Texture
        Overlay_Texture = FindProperty("Overlay_Texture", _props);
        _OverlayTex = FindProperty("_OverlayTex", _props);
        _OverlayTint = FindProperty("_OverlayTint", _props);
        _OverlayScroll = FindProperty("_OverlayScroll", _props);

        //Static
        Static_Noise = FindProperty("Static_Noise", _props);
        _StaticColour = FindProperty("_StaticColour", _props);
        _StaticIntensity = FindProperty("_StaticIntensity", _props);
        //Extra Settings
        _StaticAlpha = FindProperty("_StaticAlpha", _props);
        _StaticBrightness = FindProperty("_StaticBrightness", _props);
        _MaskAmount = FindProperty("_MaskAmount", _props);

        //Vignette
        Vignette = FindProperty("Vignette", _props);
        _VignetteColor = FindProperty("_VignetteColor", _props);
        _VignetteWidth = FindProperty("_VignetteWidth", _props);

        //Mask Texture
        Mask_Texture = FindProperty("Mask_Texture", _props);
        Mask_Multisampling = FindProperty("Mask_Multisampling", _props);
        Mask_Noise = FindProperty("Mask_Noise", _props);
        _MaskTex = FindProperty("_MaskTex", _props);
        _MaskColor = FindProperty("_MaskColor", _props);
        _MaskScroll = FindProperty("_MaskScroll", _props);
    }

    //Defines Styles (Fonts)
    public void defineStyles()
    {
        //Friend special style
        friendStyle = new GUIStyle();
        friendStyle.richText = true;
        friendStyle.fontSize = 10;
        friendStyle.alignment = TextAnchor.MiddleCenter;
    }

    public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] props)
    {
        _material = materialEditor.target as Material;
        _props = props;
        _materialEditor = materialEditor;

        AssignProperties();

        LayoutforLeviant.Initialize(_material);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Space(-7);
        EditorGUILayout.BeginVertical();
        EditorGUI.BeginChangeCheck();
        DrawGUI();
        EditorGUILayout.EndVertical();
        GUILayout.Space(1);
        EditorGUILayout.EndHorizontal();

        Undo.RecordObject(_material, "Material Edition");
    }

    static Texture2D bannerTex = null;
    static Texture2D leviantPayPal = null;
    static GUIStyle rateTxt = null;
    static GUIStyle title = null;
    static GUIStyle linkStyle = null;
    static string paypalURL = "https://www.paypal.me/LeviantTech";

    void DrawBanner()
    {
        if (bannerTex == null)
            bannerTex = Resources.Load<Texture2D>("LeviantHeaderNew");

        if (rateTxt == null)
        {
            
            rateTxt = new GUIStyle();
            rateTxt.alignment = TextAnchor.LowerRight;
            rateTxt.normal.textColor = new Color(0, 1, 1, 1);
            rateTxt.fontSize = 9;
            rateTxt.padding = new RectOffset(0, 1, 0, 1);
        }

        if (title == null)
        {
            title = new GUIStyle(rateTxt);
            title.normal.textColor = new Color(0f, 0f, 0f);
            title.alignment = TextAnchor.MiddleCenter;
            title.fontSize = 19;
        }

        if (linkStyle == null) linkStyle = new GUIStyle();

        if (bannerTex != null)
        {
            GUILayout.Space(3);
            var rect = GUILayoutUtility.GetRect(0, int.MaxValue, 100, 100);
            EditorGUI.DrawPreviewTexture(rect, bannerTex, null, ScaleMode.ScaleAndCrop);
            rateTxt.alignment = TextAnchor.LowerRight;
            GUILayout.Space(3);
        }
    }

    void DrawGUI()
    {
        DrawBanner();   //Draws Banner Image

        if (LayoutforLeviant.BeginFold((int)Category.MainSettings, "- Main Settings -"))
        {
            DrawMainSettings();
        }
        LayoutforLeviant.EndFold();

        if (LayoutforLeviant.BeginFold((int)Category.ZoomSettings, "- Zoom Settings -"))
        {
            DrawZoomSettings();
        }
        LayoutforLeviant.EndFold();

        if (LayoutforLeviant.BeginFold((int)Category.Girlscam, "- Girlscam -"))
        {
            DrawGirlscam();
        }
        LayoutforLeviant.EndFold();

        if (LayoutforLeviant.BeginFold((int)Category.Rotation, "- Rotation -"))
        {
            DrawRotation();
        }
        LayoutforLeviant.EndFold();

        if (LayoutforLeviant.BeginFold((int)Category.ScreenTransform, "- Screen Transform -"))
        {
            DrawScreenTransform();
        }
        LayoutforLeviant.EndFold();

        if (LayoutforLeviant.BeginFold((int)Category.ScreenShake, "- Screen Shake -"))
        {
            DrawScreenShake();
        }
        LayoutforLeviant.EndFold();

        if (LayoutforLeviant.BeginFold((int)Category.Pixelation, "- Pixelation -"))
        {
            DrawPixelation();
        }
        LayoutforLeviant.EndFold();

        if (LayoutforLeviant.BeginFold((int)Category.ScreenDistortion, "- Screen Distortion -"))
        {
            DrawScreenDistortion();
        }
        LayoutforLeviant.EndFold();

        if (LayoutforLeviant.BeginFold((int)Category.BlurSettings, "- Blur Settings -"))
        {
            DrawBlurSettings();
        }
        LayoutforLeviant.EndFold();

        if (LayoutforLeviant.BeginFold((int)Category.ChromaticAberration, "- Chromatic Aberration -"))
        {
            DrawChromaticAberration();
        }
        LayoutforLeviant.EndFold();

        if (LayoutforLeviant.BeginFold((int)Category.Neon, "- Neon -"))
        {
            DrawNeon();
        }
        LayoutforLeviant.EndFold();

        if (LayoutforLeviant.BeginFold((int)Category.HSVColourSpace, "- HSV Colour Space -"))
        {
            DrawHSVColourSpace();
        }
        LayoutforLeviant.EndFold();

        if (LayoutforLeviant.BeginFold((int)Category.ColourCorrection, "- Colour Correction -"))
        {
            DrawColourCorrection();
        }
        LayoutforLeviant.EndFold();

        if (LayoutforLeviant.BeginFold((int)Category.Posterization, "- Posterization -"))
        {
            DrawPosterization();
        }
        LayoutforLeviant.EndFold();

        if (LayoutforLeviant.BeginFold((int)Category.Dithering, "- Dithering -"))
        {
            DrawDithering();
        }
        LayoutforLeviant.EndFold();

        if (LayoutforLeviant.BeginFold((int)Category.OverlayTexture, "- Overlay Texture -"))
        {
            DrawOverlayTexture();
        }
        LayoutforLeviant.EndFold();

        if (LayoutforLeviant.BeginFold((int)Category.Static, "- Static -"))
        {
            DrawStatic();
        }
        LayoutforLeviant.EndFold();

        if (LayoutforLeviant.BeginFold((int)Category.Vignette, "- Vignette -"))
        {
            DrawVignette();
        }
        LayoutforLeviant.EndFold();
        if (LayoutforLeviant.BeginFold((int)Category.MaskTexture, "- Mask Texture -"))
        {
            DrawMaskTexture();
        }
        LayoutforLeviant.EndFold();

        if (LayoutforLeviant.BeginFold((int)Category.HELP, "- HELP! -"))
        {
            DrawHELP();
        }
        LayoutforLeviant.EndFold();

        if (LayoutforLeviant.BeginFold((int)Category.Credits, "- Credits -"))
        {
            DrawCredits();
        }
        LayoutforLeviant.EndFold();

        DrawLeviantPayPal();
    }

    //applying dark or light theme text
    public void generateMessage(String textToDis, GUIStyle textStyle)
    {
        String colorModifier = "000000";
    }

    void DrawMainSettings()
    {
        GUILayout.Space(-3);
        GUILayout.Label("Main Settings", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        var ofs = EditorGUIUtility.labelWidth;
        _materialEditor.SetDefaultGUIWidths();
        _materialEditor.ShaderProperty(Particle_Render, "Setup for Particle System");
        EditorGUI.indentLevel--;
        //Fade Settings
        GUILayout.Label("Fade Settings", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        _materialEditor.ShaderProperty(_MinRange, "Start Fading");
        _materialEditor.ShaderProperty(_MaxRange, "End Fading");
        EditorGUIUtility.labelWidth = ofs;
        EditorGUI.indentLevel--;
    }

    void DrawZoomSettings()
    {
        GUILayout.Space(-3);
        GUILayout.Label("Type of Zoom", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        _materialEditor.ShaderProperty(Magnification, "Zoom Mode");
        EditorGUI.indentLevel--;
        //Main Settings
        GUILayout.Label("Main Settings", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        _materialEditor.ShaderProperty(_Magnification, "Zoom/Scale");
        EditorGUI.indentLevel++;
        _materialEditor.ShaderProperty(_Gravitation, "Gravitation Range");
        _materialEditor.ShaderProperty(_AngleStartFade, "Angle Range");
        _materialEditor.ShaderProperty(_MaxAngle, "Max Angle Range");
        EditorGUI.indentLevel--;
    }

    void DrawGirlscam()
    {
        GUILayout.Space(-3);
        GUILayout.Label("Main Settings", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        var ofs = EditorGUIUtility.labelWidth;
        _materialEditor.SetDefaultGUIWidths();
        _materialEditor.ShaderProperty(_SizeGirls, "Size");
        _materialEditor.ShaderProperty(_TimeGirls, "Time");
        GUILayout.Label("Looks best if you put Time to almost max and then adjust the Size to your liking.", EditorStyles.helpBox);
        EditorGUIUtility.labelWidth = ofs;
        EditorGUI.indentLevel--;
    }

    void DrawRotation()
    {
        GUILayout.Space(-3);
        GUILayout.Label("Main Settings", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        var ofs = EditorGUIUtility.labelWidth;
        _materialEditor.SetDefaultGUIWidths();
        _materialEditor.ShaderProperty(ScreenRotation, "Screen Rotation Toggle");
        _materialEditor.ShaderProperty(_ScreenRotation, "Rotation Angle");
        _materialEditor.ShaderProperty(_ScreenRotationSpeed, "Rotation Speed Shake");
        EditorGUIUtility.labelWidth = ofs;
        EditorGUI.indentLevel--;
    }

    void DrawScreenTransform()
    {
        GUILayout.Space(-3);
        GUILayout.Label("Main Settings", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        var ofs = EditorGUIUtility.labelWidth;
        _materialEditor.SetDefaultGUIWidths();
        _materialEditor.ShaderProperty(_ScreenHorizontalFlip, "Horizontal Flip");
        _materialEditor.ShaderProperty(_ScreenVerticalFlip, "Vertical Flip");
        EditorGUIUtility.labelWidth = ofs;
        EditorGUI.indentLevel--;
    }

    void DrawScreenShake()
    {
        GUILayout.Space(-3);
        GUILayout.Label("Main Settings", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        var ofs = EditorGUIUtility.labelWidth;
        _materialEditor.SetDefaultGUIWidths();
        _materialEditor.ShaderProperty(Shake, "Screen Shake Toggle");
        _materialEditor.ShaderProperty(_ShakeTex, "Shake Normal Map");
        _materialEditor.ShaderProperty(_SIntensity_X, "Shake Intensity X");
        _materialEditor.ShaderProperty(_SIntensity_Y, "Shake Intensity Y");
        _materialEditor.ShaderProperty(_ShakeScroll, "Texture Scroll");
        _materialEditor.ShaderProperty(_ShakeWave, "Wave Offset(XY)");
        _materialEditor.ShaderProperty(_ShakeWaveSpeed, "Wave Speed(XY)");
        EditorGUIUtility.labelWidth = ofs;
        EditorGUI.indentLevel--;
    }

    void DrawPixelation()
    {
        GUILayout.Space(-3);
        GUILayout.Label("Main Settings", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        var ofs = EditorGUIUtility.labelWidth;
        _materialEditor.SetDefaultGUIWidths();
        _materialEditor.ShaderProperty(Pixelization, "Pixelization Toggle");
        _materialEditor.ShaderProperty(_PSize_X, "Pixel Width");
        _materialEditor.ShaderProperty(_PSize_Y, "Pixel Height");
        EditorGUIUtility.labelWidth = ofs;
        EditorGUI.indentLevel--;
    }

    void DrawScreenDistortion()
    {
        GUILayout.Space(-3);
        GUILayout.Label("Main Settings", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        var ofs = EditorGUIUtility.labelWidth;
        _materialEditor.SetDefaultGUIWidths();
        _materialEditor.ShaderProperty(Distorsion, "Screen Distortion Toggle");
        _materialEditor.ShaderProperty(Wave_Distorsion, "Wave Toggle");
        _materialEditor.ShaderProperty(Texture_Distorsion, "Texture Toggle");
        _materialEditor.ShaderProperty(_DistorsionTex, "Distortion Normal Map");
        _materialEditor.ShaderProperty(_DIntensity_X, "Horizontal Distortion");
        _materialEditor.ShaderProperty(_DIntensity_Y, "Vertical Distortion");
        _materialEditor.ShaderProperty(_DistorsionScroll, "Scroll Texture(XY)");
        _materialEditor.ShaderProperty(_DistorsionWave, "Wave Offset(XY)");
        _materialEditor.ShaderProperty(_DistorsionWaveSpeed, "Wave Speed(XY)");
        _materialEditor.ShaderProperty(_DistorsionWaveDensity, "Wave Density(XY)");
        EditorGUIUtility.labelWidth = ofs;
        EditorGUI.indentLevel--;
    }

    void DrawBlurSettings()
    {
        GUILayout.Space(-3);
        GUILayout.Label("Main Settings", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        var ofs = EditorGUIUtility.labelWidth;
        _materialEditor.SetDefaultGUIWidths();
        _materialEditor.ShaderProperty(Blur, "Blur Mode");
        _materialEditor.ShaderProperty(Blur_Distorsion, "Blur With Distortion");
        _materialEditor.ShaderProperty(_BlurColor, "Blur Colour (RGBA)");
        _materialEditor.ShaderProperty(_BlurRange, "Offset");
        _materialEditor.ShaderProperty(_BlurRotation, "Rotation");
        _materialEditor.ShaderProperty(_BlurRotationSpeed, "Rotation Speed");
        _materialEditor.ShaderProperty(_BlurIterations, "Samples");
        _materialEditor.ShaderProperty(_BlurCenterOffset, "Center Offset");
        _materialEditor.ShaderProperty(_BlurMask, "Mask Effect");
        GUILayout.Label("Looks best if you put samples to max.", EditorStyles.helpBox);
        EditorGUIUtility.labelWidth = ofs;
        EditorGUI.indentLevel--;
    }

    void DrawChromaticAberration()
    {
        GUILayout.Space(-3);
        GUILayout.Label("Main Settings", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        var ofs = EditorGUIUtility.labelWidth;
        _materialEditor.SetDefaultGUIWidths();
        _materialEditor.ShaderProperty(Chromatic_Aberration, "Chromatic Aberration Mode");
        _materialEditor.ShaderProperty(Aberration_Quality, "Aberration Quality");
        _materialEditor.ShaderProperty(CA_Distorsion, "Aberration with Distortion");
        _materialEditor.ShaderProperty(_CA_amplitude, "Offset");
        _materialEditor.ShaderProperty(_CA_iterations, "Samples");
        _materialEditor.ShaderProperty(_CA_speed, "Animation Speed");
        _materialEditor.ShaderProperty(_CA_direction, "Vector Direction");
        _materialEditor.ShaderProperty(_CA_factor, "Aberration Effect");
        _materialEditor.ShaderProperty(_CA_centerOffset, "Radial Center Offset");
        _materialEditor.ShaderProperty(_CA_mask, "Aberration Mask Effect");
        EditorGUIUtility.labelWidth = ofs;
        EditorGUI.indentLevel--;
    }

    void DrawNeon()
    {
        GUILayout.Space(-3);
        GUILayout.Label("Main Settings", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        var ofs = EditorGUIUtility.labelWidth;
        _materialEditor.SetDefaultGUIWidths();
        _materialEditor.ShaderProperty(Neon, "Neon Toggle");
        _materialEditor.ShaderProperty(_NeonColor, "Neon Tint (RGBA)");
        _materialEditor.ShaderProperty(_NeonOrigColor, "Background Colour (RGBA)");
        _materialEditor.ShaderProperty(_NeonBrightness, "Brightness");
        _materialEditor.ShaderProperty(_NeonPosterization, "Posterization");
        _materialEditor.ShaderProperty(_NeonWidth, "Width");
        _materialEditor.ShaderProperty(_NeonGlow, "Glow");
        EditorGUIUtility.labelWidth = ofs;
        EditorGUI.indentLevel--;
    }

    void DrawHSVColourSpace()
    {
        GUILayout.Space(-3);
        GUILayout.Label("Main Settings", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        var ofs = EditorGUIUtility.labelWidth;
        _materialEditor.SetDefaultGUIWidths();
        _materialEditor.ShaderProperty(HSV_Selection, "HSV Colour Selection Toggle");
        _materialEditor.ShaderProperty(_TargetColor, "Select Colour (RGB)");
        _materialEditor.ShaderProperty(_HueRange, "HUE Range");
        _materialEditor.ShaderProperty(_SaturationRange, "Saturation Range");
        _materialEditor.ShaderProperty(_LightnessRange, "Lightness Range");
        _materialEditor.ShaderProperty(_HueSmoothRange, "HUE Fade");
        _materialEditor.ShaderProperty(_SaturationSmoothRange, "Saturation Fade");
        _materialEditor.ShaderProperty(_LightnessSmoothRange, "Lightness Fade");
        _materialEditor.ShaderProperty(HSV_Desaturate_Selected, "Desaturate");
        EditorGUI.indentLevel--;
        GUILayout.Label("Extra Settings", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        _materialEditor.ShaderProperty(HSV_Transform, "HSV Colour Transform Toggle");
        _materialEditor.ShaderProperty(_TransformColor, "Transform Colour (RGB)");
        _materialEditor.ShaderProperty(_Hue, "HUE Value");
        _materialEditor.ShaderProperty(_HueAnimationSpeed, "HUE Animation Speed");
        _materialEditor.ShaderProperty(_Saturation, "Saturation Value");
        _materialEditor.ShaderProperty(_Lightness, "Lightness Value");
        EditorGUIUtility.labelWidth = ofs;
        EditorGUI.indentLevel--;
    }

    void DrawColourCorrection()
    {
        GUILayout.Space(-3);
        GUILayout.Label("Main Settings", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        var ofs = EditorGUIUtility.labelWidth;
        _materialEditor.SetDefaultGUIWidths();
        _materialEditor.ShaderProperty(Color_Tint, "Colour Correction Toggle");
        _materialEditor.ShaderProperty(ACES_Tonemapping, "ACES Tonemapping");
        _materialEditor.ShaderProperty(_EmissionColor, "Emission Colour (RGBA)");
        _materialEditor.ShaderProperty(_Color, "Mix Colour (RGBA)");
        _materialEditor.ShaderProperty(_Grayscale, "Grayscale");
        _materialEditor.ShaderProperty(_Contrast, "Contrast");
        _materialEditor.ShaderProperty(_Gamma, "Gamma");
        _materialEditor.ShaderProperty(_Brightness, "Brightness");
        _materialEditor.ShaderProperty(_RedInvert, "Red Invert");
        _materialEditor.ShaderProperty(_GreenInvert, "Green Invert");
        _materialEditor.ShaderProperty(_BlueInvert, "Blue Invert");
        EditorGUIUtility.labelWidth = ofs;
        EditorGUI.indentLevel--;
    }

    void DrawPosterization()
    {
        GUILayout.Space(-3);
        GUILayout.Label("Main Settings", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        var ofs = EditorGUIUtility.labelWidth;
        _materialEditor.SetDefaultGUIWidths();
        _materialEditor.ShaderProperty(Posterization, "Posterization Toggle");
        _materialEditor.ShaderProperty(_PosterizationSteps, "Gradient Steps");
        EditorGUIUtility.labelWidth = ofs;
        EditorGUI.indentLevel--;
    }

    void DrawDithering()
    {
        GUILayout.Space(-3);
        GUILayout.Label("Main Settings", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        var ofs = EditorGUIUtility.labelWidth;
        _materialEditor.SetDefaultGUIWidths();
        _materialEditor.ShaderProperty(Dithering, "Dithering Toggle");
        _materialEditor.ShaderProperty(_DitheringMask, "Dithering Mask");
        EditorGUIUtility.labelWidth = ofs;
        EditorGUI.indentLevel--;
    }

    void DrawOverlayTexture()
    {
        GUILayout.Space(-3);
        GUILayout.Label("Main Settings", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        var ofs = EditorGUIUtility.labelWidth;
        _materialEditor.SetDefaultGUIWidths();
        _materialEditor.ShaderProperty(Overlay_Texture, "Overlay Toggle");
        _materialEditor.ShaderProperty(_OverlayTex, "Texture");
        _materialEditor.ShaderProperty(_OverlayTint, "Tint (RGBA)");
        _materialEditor.ShaderProperty(_OverlayScroll, "Overlay Scroll Vector");
        EditorGUIUtility.labelWidth = ofs;
        EditorGUI.indentLevel--;
    }

    void DrawStatic()
    {
        GUILayout.Space(-3);
        GUILayout.Label("Main Settings", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        var ofs = EditorGUIUtility.labelWidth;
        _materialEditor.SetDefaultGUIWidths();
        _materialEditor.ShaderProperty(Static_Noise, "Toggle Static");
        _materialEditor.ShaderProperty(_StaticColour, "Static Colour");
        _materialEditor.ShaderProperty(_StaticIntensity, "Static Intensity");
        EditorGUI.indentLevel--;
        GUILayout.Label("Extra Settings", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        _materialEditor.ShaderProperty(_StaticAlpha, "Static Alpha");
        _materialEditor.ShaderProperty(_StaticBrightness, "Static Brightness");
        GUILayout.Label("Looks best if you put Static Colour to white, put Static Alpha to 0.83, put Static Brightness to 4.2, and put Static Intensity to -0.6.", EditorStyles.helpBox);
        GUILayout.Label("Static Added by: Aidan.ogg#0001", EditorStyles.miniBoldLabel);
        EditorGUIUtility.labelWidth = ofs;
        EditorGUI.indentLevel--;
    }

    void DrawVignette()
    {
        GUILayout.Space(-3);
        GUILayout.Label("Main Settings", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        var ofs = EditorGUIUtility.labelWidth;
        _materialEditor.SetDefaultGUIWidths();
        _materialEditor.ShaderProperty(Vignette, "Vignette Toggle");
        _materialEditor.ShaderProperty(_VignetteColor, "Vignette Colour (RGBA)");
        _materialEditor.ShaderProperty(_VignetteWidth, "Vignette Width");
        EditorGUIUtility.labelWidth = ofs;
        EditorGUI.indentLevel--;
    }

    void DrawMaskTexture()
    {
        GUILayout.Space(-3);
        GUILayout.Label("Main Settings", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;
        var ofs = EditorGUIUtility.labelWidth;
        _materialEditor.SetDefaultGUIWidths();
        _materialEditor.ShaderProperty(Mask_Texture, "Mask Toggle");
        _materialEditor.ShaderProperty(Mask_Multisampling, "Multisampling");
        _materialEditor.ShaderProperty(Mask_Noise, "Generate Noise");
        _materialEditor.ShaderProperty(_MaskTex, "Mask");
        _materialEditor.ShaderProperty(_MaskColor, "Mask Mix Colour (RGBA)");
        _materialEditor.ShaderProperty(_MaskScroll, "Mask Scroll Vector");
        EditorGUIUtility.labelWidth = ofs;
        EditorGUI.indentLevel--;
    }

    void DrawHELP()
    {
        GUILayout.Space(-3);
        EditorGUI.indentLevel++;
        GUILayout.Label("-If you have any questions DM us on Discord: Leviant#8796 & Aidan.ogg#0001                                                                                           -Version 1.5", EditorStyles.helpBox);
        var ofs = EditorGUIUtility.labelWidth;
        _materialEditor.SetDefaultGUIWidths();
        EditorGUIUtility.labelWidth = ofs;
        EditorGUI.indentLevel--;
    }

    void DrawCredits()
    {
        GUILayout.Space(-3);
        EditorGUI.indentLevel++;
        GUILayout.Label("-Made By: Leviant#8796                                                                               -Edited by: Aidan.ogg#0001                                                                              -Editor Created by: Aidan.ogg#0001", EditorStyles.helpBox);
        var ofs = EditorGUIUtility.labelWidth;
        _materialEditor.SetDefaultGUIWidths();
        EditorGUIUtility.labelWidth = ofs;
        EditorGUI.indentLevel--;
    }

    //Draws Buttons
    void DrawLeviantPayPal()
    {
        if (leviantPayPal == null)
            leviantPayPal = Resources.Load<Texture2D>("LeviantPayPal");

        if (rateTxt == null)
        {

            rateTxt = new GUIStyle();
            rateTxt.alignment = TextAnchor.LowerRight;
            rateTxt.normal.textColor = new Color(0, 1, 1, 1);
            rateTxt.fontSize = 9;
            rateTxt.padding = new RectOffset(0, 1, 0, 1);
        }

        if (title == null)
        {
            title = new GUIStyle(rateTxt);
            title.normal.textColor = new Color(0f, 0f, 0f);
            title.alignment = TextAnchor.MiddleCenter;
            title.fontSize = 19;
        }

        if (linkStyle == null) linkStyle = new GUIStyle();

        if (leviantPayPal != null)
        {
            GUILayout.Space(3);
            var rect = GUILayoutUtility.GetRect(0, int.MaxValue, 50, 50);
            EditorGUI.DrawPreviewTexture(rect, leviantPayPal, null, ScaleMode.ScaleAndCrop);
            rateTxt.alignment = TextAnchor.LowerRight;
            GUILayout.Space(3);

            if (GUI.Button(rect, "", linkStyle))
            {
                Application.OpenURL(paypalURL);
            }
            GUILayout.Space(3);
        }
    }
}
