using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Path = System.IO.Path;
using SPiApp2.Components.Settings;
using System.Diagnostics;

namespace SPiApp2.Tools
{
    public enum ImageFormat : uint
    {
        Invalid = ~0u,

        // Uncompressed (TGA)
        R8G8B8A8 = 1,
        R8G8B8 = 2,
        L8A8 = 3,
        L8 = 4,
        A8 = 5,

        // Compressed (NOTE: probably JPG)
        RGBA = 6,
        RGB = 7,
        LA = 8,
        Luminance = 9,
        Alpha = 10,

        // Compressed (DXTn)
        DXT1 = 11,
        DXT3 = 12,
        DXT5 = 13
    }

    /**
     * TODO: Change to: Texture2D, Texture3D, etc.
     */
    public enum ImageUsage : uint
    {
        Invalid = ~0u,

        // EXPECTED LIST
        //   0x00 - default
        //   0x01 - ?
        //   0x02 - built-in ($), ac130_overlay_grain
        //   0x04 - ?
        //   0x08 - ?
        //   0x10 - ?
        //   0x20 - Normal/Bump map
        //   0x40 - trim... decal
        //   0x80 - trim...

        //   0 - 0 - default
        //   1 - 1 - amraam_01_col
        //   3 - 2 - built-in image ($), ac130_overlay_grain
        //  32 - 1 - _nml _bump
        //  33 - 2 - impact_metal01_nml
        //  64 - 1 - ch_dec_wallwhitegreen01_left_col
        //  67 - 3 - compass_radarline
        //  96 - 2 - ch_ground_roadconcrete01_trim_nml
        // 128 - 1 - ch_church_rooftrim
        // 131 - 3 - facade_building_03
        // 192 - 2 - ac_hotspots_blob01
        // 193 - 3 - logo_cod2
        // 195 - 4 - cursor/ac130 (levelshot)/ac130_hud_target
        // 198 - 4 - Skybox/volume/Texture2D
    }

    /**
     * TOOD: Are we sure?
     */
    [Flags]
    public enum ImageFlags : uint
    {
        NoPicMip = 0,
        PicMip = 1
    }

    public class Image : Asset
    {
        public ImageFormat Format { get; private set; } = ImageFormat.Invalid;
        public uint Usage { get; private set; }

        public int Width { get; private set; }
        public int Height { get; private set; }

        private uint Flags { get; set; } = 0u;

        public Image(string name) :
            base(name)
        {
            ; // Do something...
        }

        public static string[] GetAvailable()
        {
            string directory = string.Format("{0}{1}main{1}images",
                Preferences.InstallPath, Path.DirectorySeparatorChar);

            string[] files = Directory.GetFiles(directory, "*.iwi", SearchOption.TopDirectoryOnly);

            // Drop the directory path
            for (int i = 0; i < files.Length; i++)
            {
                string filename = Path.GetFileName(files[i]);
                files[i] = filename.Substring(0, filename.Length - 4);
            }

            return files;
        }

        protected override string GetPath()
        {
            string name = Name;

            if (!name.EndsWith(".iwi"))
                name = string.Format("{0}.iwi", name);

            return string.Format("{0}{1}main{1}images{1}{2}",
                Preferences.InstallPath, Path.DirectorySeparatorChar, name);
        }

        protected override void _Load()
        {
            // Open the file stream for reading.
            OpenFile(FileMode.Open);

            // Read the IWI header
            Read(28, out byte[] header);

            // IWi version 6
            uint identifier = BitConverter.ToUInt32(header, 0);
            if (identifier != 0x06695749u)
            {
                throw new FormatException("The file does not have the proper IWI file format or version.");
            }

            // IWi data information
            Format = (ImageFormat)((uint)header[4]);
            Usage = ((uint)header[5]);
            Width = BitConverter.ToUInt16(header, 6);
            Height = BitConverter.ToUInt16(header, 8);
            Flags = BitConverter.ToUInt16(header, 10);

#if DEBUG

            // DEBUG ONLY
            Debug.Assert(Usage == 0 || Usage == 1 || Usage == 3 || Usage == 32 || Usage == 33 || Usage == 64 || Usage == 67 || Usage == 96 || Usage == 128 ||
                Usage == 131 || Usage == 192 || Usage == 193 || Usage == 195 || Usage == 198,
                string.Format("Usage value has not be specified.\n\t{0}\n\t==> {1}", Name, Usage));
            Debug.Assert(Flags == 0 || Flags == 1,
                string.Format("Flags value has not be specified.\n\t{0}\n\t==>{1}", Name, Flags));

#endif

            // Mip-Map data
            int[] offset = new int[4];
            offset[0] = BitConverter.ToInt32(header, 12);
            offset[1] = BitConverter.ToInt32(header, 16);
            offset[2] = BitConverter.ToInt32(header, 20);
            offset[3] = BitConverter.ToInt32(header, 24);

        }

        protected override string GetInfo()
        {
            Dictionary<string, object> items = new Dictionary<string, object>
            {
                { "Format", Format },
                { "Usage", Usage },
                { "Width", Width },
                { "Height", Height },
                { "Flags", Flags }
            };

            string output = Name;

            foreach (var pair in items)
            {
                output = string.Format("{0}\n  {1,-10} {2}", output, pair.Key, pair.Value);
            }

            return output;
        }
    }
}
