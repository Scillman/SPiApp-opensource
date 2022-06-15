using System;
using System.Diagnostics;

namespace SPiApp2.Components
{
    public class HashFile : IEquatable<HashFile>, IComparable, IComparable<HashFile>, IComparable<byte[]>
    {
        public string FileName { get; set; }

        public byte[] Hash
        {
            get
            {
                return _hash;
            }
            set
            {
                Debug.Assert(value.Length == 16);
                _hash = value;
            }
        }
        private byte[] _hash;

        public HashFile(byte[] hash)
        {
            Hash = hash;
        }

        public HashFile(string fileName, byte[] hash)
        {
            FileName = fileName;
            Hash = hash;
        }

        public static bool operator ==(HashFile a, HashFile b)
        {
            return a.CompareTo(b) == 0;
        }

        public static bool operator !=(HashFile a, HashFile b)
        {
            return a.CompareTo(b) != 0;
        }

        public override string ToString()
        {
            return FileName;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as HashFile);
        }

        public bool Equals(HashFile other)
        {
            if (other == null)
            {
                return false;
            }

            return CompareTo(other) == 0;
        }

        public override int GetHashCode()
        {
            return _hash.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            return CompareTo(obj as HashFile);
        }

        public int CompareTo(HashFile other)
        {
            if (other == null)
            {
                return -1;
            }

            return CompareTo(other._hash);
        }

        public int CompareTo(byte[] other)
        {
            if (other == null)
            {
                return -1;
            }

            Debug.Assert(other.Length == 16);

            for (int i = 0; i < 16; i++)
            {
                int result = _hash[i].CompareTo(other[i]);
                if (result != 0)
                {
                    return result;
                }
            }

            return 0;
        }
    }
}
