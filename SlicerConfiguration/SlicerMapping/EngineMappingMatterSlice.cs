﻿/*
Copyright (c) 2014, Lars Brubaker
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met: 

1. Redistributions of source code must retain the above copyright notice, this
   list of conditions and the following disclaimer. 
2. Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution. 

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

The views and conclusions contained in the software and documentation are those
of the authors and should not be interpreted as representing official policies, 
either expressed or implied, of the FreeBSD Project.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MatterHackers.VectorMath;
using MatterHackers.Agg;

namespace MatterHackers.MatterControl.SlicerConfiguration
{
    public class EngineMappingsMatterSlice : SliceEngineMaping
    {
        // private so that this class is a sigleton
        EngineMappingsMatterSlice()
        {
        }

        static EngineMappingsMatterSlice instance = null;
        public static EngineMappingsMatterSlice Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EngineMappingsMatterSlice();
                }
                return instance;
            }
        }

        public override bool MapContains(string originalKey)
        {
            foreach (MapItem mapItem in matterSliceToDefaultMapping)
            {
                if (mapItem.OriginalKey == originalKey)
                {
                    return true;
                }
            }

            return false;
        }

        static MapItem[] matterSliceToDefaultMapping = 
        {
#if true
            //avoidCrossingPerimeters=True # Avoid crossing any of the perimeters of a shape while printing its parts.
            new MapItemToBool("avoidCrossingPerimeters", "avoid_crossing_perimeters"),
             
            //bottomClipAmount=0 # The amount to clip off the bottom of the part, in millimeters.
            new MapItem("bottomClipAmount", "bottom_clip_amount"),
            
            //centerObjectInXy=True # Describes if 'positionToPlaceObjectCenter' should be used.
            new MapItemToBool("centerObjectInXy", "center_part_on_bed"),
            
            //continuousSpiralOuterPerimeter=False # This will cause the z height to raise continuously while on the outer perimeter.
            new MapItemToBool("continuousSpiralOuterPerimeter", "spiral_vase"),
            
            //doCoolHeadLift=False # Will cause the head to be raised in z until the min layer time is reached.
            new MapItemToBool("doCoolHeadLift", "cool_extruder_lift"),
            
            //endCode=M104 S0
            new MapEndGCode("endCode", "end_gcode"),

            //extruderOffsets=[[0,0],[0,0],[0,0],[0,0],[0,0],[0,0],[0,0],[0,0],[0,0],[0,0],[0,0],[0,0],[0,0],[0,0],[0,0],[0,0]]

            //extrusionWidth=0.4 # The width of the line to extrude.
            new MapItem("extrusionWidth", "nozzle_diameter"),
            
            //fanSpeedMaxPercent=100
            new MapItem("fanSpeedMaxPercent", "max_fan_speed"),

            //fanSpeedMinPercent=100
            new MapItem("fanSpeedMinPercent", "min_fan_speed"),

            //filamentDiameter=2.89 # The width of the filament being fed into the extruder, in millimeters.
            new MapItem("filamentDiameter", "filament_diameter"),
            
            //extrusionMultiplier=1 # Lets you adjust how much material to extrude.
            new MapItem("extrusionMultiplier", "extrusion_multiplier"),

            //firstLayerExtrusionWidth=0.8 # The width of the line to extrude for the first layer.
            new AsPercentOfReferenceOrDirect("firstLayerExtrusionWidth", "first_layer_extrusion_width", "nozzle_diameter"),

            //firstLayerSpeed=20 # mm/s.
            new AsPercentOfReferenceOrDirect("firstLayerSpeed", "first_layer_speed", "infill_speed"),

            //firstLayerThickness=0.3 # The height of the first layer to print, in millimeters.
            new AsPercentOfReferenceOrDirect("firstLayerThickness", "first_layer_height", "layer_height", 1),

            //firstLayerToAllowFan=2 # The fan will be force to stay off below this layer.
            new MapItem("firstLayerToAllowFan", "disable_fan_first_layers"),

            //outputType=REPRAP # Available Values: REPRAP, ULTIGCODE, MAKERBOT, BFB, MACH3
            new MapItem("outputType", "gcode_output_type"),
            
            //generateInternalSupport=True # If True, support will be generated within the part as well as from the bed.
            new MapItemToBool("generateInternalSupport", "support_material_create_internal_support"),
            
            //infillOverlapPerimeter=0.06 # The amount the infill extends into the perimeter in millimeters.
            new MapItem("infillOverlapPerimeter", "infill_overlap_perimeter"),
            
            //infillPercent=20 # The percent of filled space to open space while infilling.
            new ScaledSingleNumber("infillPercent", "fill_density", 100),

            //infillSpeed=50 # mm/s.
            new MapItem("infillSpeed", "infill_speed"),
            
            //infillStartingAngle=45
            new MapItem("infillStartingAngle", "fill_angle"),            

            //insidePerimetersSpeed=50 # The speed of all perimeters but the outside one. mm/s.
            new MapItem("insidePerimetersSpeed", "perimeter_speed"),

            //layerThickness=0.1
            new MapItem("layerThickness", "layer_height"),

            //minimumExtrusionBeforeRetraction=0.1 # mm.
            new MapItem("minimumExtrusionBeforeRetraction", "min_extrusion_before_retract"),

            //minimumFeedrate=10 # mm/s.
            
            //minimumLayerTimeSeconds=5
            new MapItem("minimumLayerTimeSeconds", "slowdown_below_layer_time"),

            //minimumTravelToCauseRetraction=1.5 # The minimum travel distance that will require a retraction
            //modelRotationMatrix=[[1,0,0],[0,1,0],[0,0,1]]
            //multiVolumeOverlapPercent=0

            //numberOfBottomLayers=6
            new MapItem("numberOfBottomLayers", "bottom_solid_layers"),
            
            //numberOfSkirtLoops=1 # The number of loops to draw around objects. Can be used to help hold them down.
            new MapItem("numberOfSkirtLoops", "skirts"),

            //numberOfTopLayers=6
            new MapItem("numberOfTopLayers", "top_solid_layers"),

            //outsidePerimeterSpeed=50 # The speed of the first perimeter. mm/s.
            new AsPercentOfReferenceOrDirect("outsidePerimeterSpeed", "external_perimeter_speed", "perimeter_speed"),
            
            //numberOfPerimeters=2
            new MapItem("numberOfPerimeters", "perimeters"),

            //positionToPlaceObjectCenter=[102.5,102.5]
            new MapPositionToPlaceObjectCenter("positionToPlaceObjectCenter", "print_center"),

            //raftBaseLinewidth=0
            //raftBaseThickness=0
            //raftExtraDistanceAroundPart=5 # mm.
            //raftInterfaceLinewidth=0
            //raftInterfaceThicknes=0
            //raftLineSpacing=1

            //repairOutlines=NONE # Available Values: NONE, EXTENSIVE_STITCHING, KEEP_NON_CLOSED # You can or them together using '|'.
            //repairOverlaps=NONE # Available Values: NONE, REVERSE_ORIENTATION, UNION_ALL_TOGETHER # You can or them together using '|'.
            
            //retractionOnExtruderSwitch=14.5
            new MapItem("retractionOnExtruderSwitch", "retract_length_tool_change"),
            
            //retractionOnTravel=4.5
            new MapItem("retractionOnTravel", "retract_before_travel"),

            //retractionSpeed=45 # mm/s.
            new MapItem("retractionSpeed", "retract_speed"),
            
            //retractionZHop=0 # The amount to move the extruder up in z after retracting (before a move). mm.
            new MapItem("retract_lift", "retractionZHop"),
            
            //skirtDistanceFromObject=6 # How far from objects the first skirt loop should be, in millimeters.
            new MapItem("skirtDistanceFromObject", "skirt_distance"),

            //skirtMinLength=0 # The minimum length of the skirt line, in millimeters.
            new SkirtLengthMaping("skirtMinLength", "min_skirt_length"),

            //startCode=M109 S210
            new MapStartGCode("startCode", "start_gcode"),

            //supportExtruder=-1
            //supportLineSpacing=2
            //supportMaterialSpeed=50 # mm/s.
            
            //supportStartingAngleDegrees=0
            new MapItem("supportStartingAngleDegrees", "support_material_angle"),            

            //supportType=NONE # Available Values: NONE, GRID, LINES
            new MapItem("supportType", "support_type"),
            
            //supportXYDistanceFromObject=0.7 # The closest xy distance that support will be to the object. mm/s.
            new MapItem("supportXYDistanceFromObject", "support_material_xy_distance"),
            
            //supportZDistanceFromObject=0.15 # The closest z distance that support will be to the object. mm/s.
            new MapItem("supportZDistanceFromObject", "support_material_z_distance"),

            //travelSpeed=200 # The speed to move when not extruding material. mm/s.
            new MapItem("travelSpeed", "travel_speed"),
            
            //wipeShieldDistanceFromObject=2 # mm.
            //new MapItem("wipeShieldDistanceFromObject", ""),

            //wipeTowerSize=0 # Unlike the wipe shield this is a square of size X size in the lower left corner for wiping during extruder changing.

            new NotPassedItem("", "pause_gcode"),
            new NotPassedItem("", "resume_gcode"),
            new NotPassedItem("", "cancel_gcode"),

            new NotPassedItem("", "build_height"),

            new NotPassedItem("", "temperature"),
            new NotPassedItem("", "bed_temperature"),
            new NotPassedItem("", "bed_shape"),
#else
            new MapItem("layerThickness", "layer_height"),
            new AsPercentOfReferenceOrDirect("initialLayerThickness", "first_layer_height", "layer_height", 1),
            new ScaledSingleNumber("filamentDiameter", "filament_diameter", 1000),
            new ScaledSingleNumber("extrusionWidth", "nozzle_diameter", 1000),

            new MapItem("printSpeed", "perimeter_speed"),
            new MapItem("infillSpeed", "infill_speed"),
            new MapItem("moveSpeed", "travel_speed"),
            new AsPercentOfReferenceOrDirect("initialLayerSpeed", "first_layer_speed", "infill_speed"),

            new MapItem("insetCount", "perimeters"),

            new MapItem("skirtLineCount", "skirts"),
            new SkirtLengthMaping("skirtMinLength", "min_skirt_length"),
            new ScaledSingleNumber("skirtDistance", "skirt_distance", 1000),

            new FanTranslator("fanFullOnLayerNr", "disable_fan_first_layers"),
            new MapItemToBool("coolHeadLift", "cool_extruder_lift"),

            new ScaledSingleNumber("retractionAmount", "retract_length", 1000),
            new MapItem("retractionSpeed", "retract_speed"),
            new ScaledSingleNumber("retractionMinimalDistance", "retract_before_travel", 1000),
            new ScaledSingleNumber("minimalExtrusionBeforeRetraction", "min_extrusion_before_retract", 1000),

            new MapItemToBool("spiralizeMode", "spiral_vase"),

            new NotPassedItem("", "bed_size"),

            new PrintCenterX("objectPosition.X", "print_center"),
            new PrintCenterY("objectPosition.Y", "print_center"),

            // needs testing, not working
            new ScaledSingleNumber("supportLineDistance", "support_material_spacing", 1000),
            new SupportMatterial("supportAngleDegrees", "support_material"),
            new NotPassedItem("", "support_material_threshold"),
            new MapItem("supportEverywhere", "support_material_create_internal_support"),
            new ScaledSingleNumber("supportXYDistance", "support_material_xy_distance", 1000),
            new ScaledSingleNumber("supportZDistance", "support_material_z_distance", 1000),

            new MapItem("minimalLayerTime", "slowdown_below_layer_time"),

            new InfillTranslator("sparseInfillLineDistance", "fill_density"),

            new MapStartGCode("startCode", "start_gcode"),
            new MapEndGCode("endCode", "end_gcode"),
            
            new NotPassedItem("", "pause_gcode"),
            new NotPassedItem("", "resume_gcode"),
            new NotPassedItem("", "cancel_gcode"),
#endif
        };

        public static string GetMatterSliceCommandLineSettings()
        {
            StringBuilder settings = new StringBuilder();
            for (int i = 0; i < matterSliceToDefaultMapping.Length; i++)
            {
                string matterSliceValue = matterSliceToDefaultMapping[i].MappedValue;
                if (matterSliceValue != null && matterSliceValue != "")
                {
                    settings.Append(string.Format("-s {0}=\"{1}\" ", matterSliceToDefaultMapping[i].MappedKey, matterSliceValue));
                }
            }

            return settings.ToString();
        }

        public class FanTranslator : MapItem
        {
            public override string MappedValue
            {
                get
                {
                    int numLayersFanIsDisabledOn = int.Parse(base.MappedValue);
                    int layerToEnableFanOn = numLayersFanIsDisabledOn + 1;
                    return layerToEnableFanOn.ToString();
                }
            }

            public FanTranslator(string mappedKey, string slicer)
                : base(mappedKey, slicer)
            {
            }
        }

        public class SupportMatterial : MapItem
        {
            public override string MappedValue
            {
                get
                {
                    string supportMaterial = ActiveSliceSettings.Instance.GetActiveValue("support_material");
                    if (supportMaterial == "0")
                    {
                        return "-1";
                    }

                    return (90 - double.Parse(ActiveSliceSettings.Instance.GetActiveValue("support_material_threshold"))).ToString();
                }
            }

            public SupportMatterial(string mappedKey, string slicer)
                : base(mappedKey, slicer)
            {
            }
        }

        public class InfillTranslator : MapItem
        {
            public override string MappedValue
            {
                get
                {
                    double infillRatio0To1 = Double.Parse(base.MappedValue);
                    // 400 = solid (extruder width)
                    double nozzle_diameter = double.Parse(ActiveSliceSettings.Instance.GetActiveValue("nozzle_diameter"));
                    double linespacing = 1000;
                    if (infillRatio0To1 > .01)
                    {
                        linespacing = nozzle_diameter / infillRatio0To1;
                    }

                    return ((int)(linespacing * 1000)).ToString();
                }
            }

            public InfillTranslator(string mappedKey, string slicer)
                : base(mappedKey, slicer)
            {
            }
        }

        public class MapStartGCode : InjectGCodeCommands
        {
            public override string MappedValue
            {
                get
                {
                    StringBuilder startGCode = new StringBuilder();
                    foreach (string line in PreStartGCode())
                    {
                        startGCode.Append(line + "\n");
                    }

                    startGCode.Append(base.MappedValue);

                    bool first = true;
                    foreach (string line in PostStartGCode())
                    {
                        if (!first)
                        {
                            startGCode.Append("\n");
                        }
                        startGCode.Append(line);
                        first = false;
                    }

                    return startGCode.ToString();
                }
            }

            public MapStartGCode(string mappedKey, string slicer)
                : base(mappedKey, slicer)
            {
            }

            public List<string> PreStartGCode()
            {
                string startGCode = ActiveSliceSettings.Instance.GetActiveValue("start_gcode");
                string[] preStartGCodeLines = startGCode.Split(new string[] { "\\n" }, StringSplitOptions.RemoveEmptyEntries);

                List<string> preStartGCode = new List<string>();
                preStartGCode.Add("; automatic settings before start_gcode");
                AddDefaultIfNotPresent(preStartGCode, "G21", preStartGCodeLines, "set units to millimeters");
                AddDefaultIfNotPresent(preStartGCode, "M107", preStartGCodeLines, "fan off");
                double bed_temperature = double.Parse(ActiveSliceSettings.Instance.GetActiveValue("bed_temperature"));
                if (bed_temperature > 0)
                {
                    string setBedTempString = string.Format("M190 S{0}", bed_temperature);
                    AddDefaultIfNotPresent(preStartGCode, setBedTempString, preStartGCodeLines, "wait for bed temperature to be reached");
                }
                string setTempString = string.Format("M104 S{0}", ActiveSliceSettings.Instance.GetActiveValue("temperature"));
                AddDefaultIfNotPresent(preStartGCode, setTempString, preStartGCodeLines, "set temperature");
                preStartGCode.Add("; settings from start_gcode");

                return preStartGCode;
            }

            public List<string> PostStartGCode()
            {
                string startGCode = ActiveSliceSettings.Instance.GetActiveValue("start_gcode");
                string[] postStartGCodeLines = startGCode.Split(new string[] { "\\n" }, StringSplitOptions.RemoveEmptyEntries);

                List<string> postStartGCode = new List<string>();
                postStartGCode.Add("; automatic settings after start_gcode");
                string setTempString = string.Format("M109 S{0}", ActiveSliceSettings.Instance.GetActiveValue("temperature"));
                AddDefaultIfNotPresent(postStartGCode, setTempString, postStartGCodeLines, "wait for temperature");
                AddDefaultIfNotPresent(postStartGCode, "G90", postStartGCodeLines, "use absolute coordinates");
                postStartGCode.Add(string.Format("{0} ; {1}", "G92 E0", "reset the expected extruder position"));
                AddDefaultIfNotPresent(postStartGCode, "M82", postStartGCodeLines, "use absolute distance for extrusion");

                return postStartGCode;
            }
        }

        public class MapEndGCode : InjectGCodeCommands
        {
            public override string MappedValue
            {
                get
                {
                    StringBuilder endGCode = new StringBuilder();

                    endGCode.Append(base.MappedValue);

                    endGCode.Append("\n; filament used = filament_used_replace_mm (filament_used_replace_cm3)");

                    return endGCode.ToString();
                }
            }

            public MapEndGCode(string mappedKey, string slicer)
                : base(mappedKey, slicer)
            {
            }
        }

        public class MapPositionToPlaceObjectCenter : MapItem
        {
            public MapPositionToPlaceObjectCenter(string mappedKey, string originalKey)
                : base(mappedKey, originalKey)
            {
            }

            public override string MappedValue
            {
                get
                {
                    Vector2 PrinteCenter = ActiveSliceSettings.Instance.PrintCenter;

                    return "[{0},{1}]".FormatWith(PrinteCenter.x, PrinteCenter.y);
                }
            }
        }

        public class SkirtLengthMaping : MapItem
        {
            public SkirtLengthMaping(string mappedKey, string originalKey)
                : base(mappedKey, originalKey)
            {
            }

            public override string MappedValue
            {
                get
                {
                    double lengthToExtrudeMm = double.Parse(base.MappedValue);
                    // we need to convert mm of filament to mm of extrusion path
                    double amountOfFilamentCubicMms = ActiveSliceSettings.Instance.FilamentDiameter * MathHelper.Tau * lengthToExtrudeMm;
                    double extrusionSquareSize = ActiveSliceSettings.Instance.FirstLayerHeight * ActiveSliceSettings.Instance.NozzleDiameter;
                    double lineLength = amountOfFilamentCubicMms / extrusionSquareSize;

                    return lineLength.ToString();
                }
            }
        }
    }
}