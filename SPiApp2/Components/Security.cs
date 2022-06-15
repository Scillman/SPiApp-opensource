using SPiApp2.Components.Common;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;

namespace SPiApp2.Components
{
    public static class Security
    {
        /// <summary>
        /// Get an indicator whether a hash has to be generated.
        /// </summary>
        private static bool NoHashing
        {
            get
            {
                if (noHashing == null)
                {
                    noHashing = Utility.IsParameterSet("nohash");
                    Debug.Assert(noHashing.HasValue);

                    if (noHashing.Value == true)
                    {
                        SPiApp2.Controls.Console.WriteLine("Hash verification of mod tool binaries has been disabled.");
                    }
                }
                
                return noHashing.Value;
            }
        }
        private static bool? noHashing = null;

        /// <summary>
        /// Generates a MD5 of the file at the given path.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="hash">The hash of the file.</param>
        /// <returns>true if a hash is generated; otherwise, false.</returns>
        public static bool CreateMD5(string path, out byte[] hash)
        {
            if (NoHashing == false)
            {
                try
                {
                    // Use input string to calculate MD5 hash
                    using (MD5 md5 = MD5.Create())
                    {
                        byte[] data = File.ReadAllBytes(path);
                        hash = md5.ComputeHash(data);

#if DEBUG
                        // Convert the byte array to hexadecimal string
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        for (int i = 0; i < hash.Length; i++)
                        {
                            //sb.Append(hash[i].ToString("X2"));
                            sb.Append(string.Format("{0}, ", hash[i]));
                        }
                        System.Diagnostics.Debug.WriteLine(string.Format("{1} == {0}", path, sb.ToString()));
#endif

                        Debug.Assert(hash.Length == 16);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            hash = null;
            return false;
        }

        /// <summary>
        /// The MD5 hash of the 7za.exe of the Call of Duty 4 mod tools.
        /// </summary>
        public static readonly byte[] ZIPPER_HASH = { 136, 94, 158, 180, 40, 137, 202, 84, 127, 78, 53, 21, 220, 222, 93, 61 };


        /**
         * Tool hashes
         */
        public static readonly byte[] HASH_SP_TOOL = { 87, 90, 189, 229, 7, 194, 155, 137, 133, 163, 140, 178, 255, 132, 55, 111 };
        public static readonly byte[] HASH_MP_TOOL = { 201, 132, 26, 52, 92, 113, 54, 216, 108, 152, 138, 102, 18, 82, 47, 183 };
        public static readonly byte[] HASH_ASSET_MANAGER = { 118, 113, 243, 176, 2, 115, 165, 207, 143, 23, 102, 221, 137, 2, 19, 209 };
        public static readonly byte[] HASH_EFFECTS_ED = { 236, 167, 25, 68, 232, 87, 48, 71, 92, 169, 212, 74, 151, 173, 12, 74 };
        public static readonly byte[] HASH_RADIANT = { 223, 159, 12, 131, 22, 33, 40, 59, 60, 144, 43, 234, 87, 114, 91, 233 };
        public static readonly byte[] HASH_COD4MAP = { 17, 109, 120, 182, 199, 100, 69, 232, 78, 193, 96, 187, 109, 87, 151, 59 };
        public static readonly byte[] HASH_COD4RAD = { 106, 50, 242, 203, 154, 57, 46, 225, 113, 220, 226, 235, 46, 46, 218, 13 };
        public static readonly byte[] HASH_CONVERTER = { 236, 70, 143, 181, 227, 13, 57, 119, 188, 45, 31, 190, 28, 224, 12, 1 };
        public static readonly byte[] HASH_LINKER_PC = { 228, 82, 104, 133, 65, 1, 117, 172, 164, 68, 100, 93, 93, 166, 220, 219 };
    }
}
