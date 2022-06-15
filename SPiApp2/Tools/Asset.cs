using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace SPiApp2.Tools
{
    public abstract class Asset : IDisposable
    {
        protected string Name
        {
            get;
            private set;
        }

        private Stream stream = null;

        public Asset(string name)
        {
            Name = name;
        }

        ~Asset()
        {
            Dispose();
        }

        public void Dispose()
        {
            Dispose(true);

            // NOTE: This is not how I use it for Asset objects, so we still need it!
            //GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (stream != null)
                {
                    stream.Dispose();
                    stream = null;
                }
            }
        }

        protected abstract string GetPath();        

        public bool Load()
        {
            try
            {
                Debug.Assert(stream == null);
                _Load();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                SPiApp2.Controls.Console.WriteLine(ex.Message);
                AppDialogMessage.Show("An error occured while loading the asset.",
                    "Asset load error", MessageButtons.OK, MessageIcon.Error);
            }

            return false;
        }

        protected abstract void _Load();

        public virtual bool Save()
        {
            try
            {
                _Save();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                AppDialogMessage.Show("An error occured while saving the asset.",
                    "Asset save error", MessageButtons.OK, MessageIcon.Error);
            }

            return false;
        }

        protected virtual void _Save()
        {
            throw new NotImplementedException("This feature is not currently supported for this type of asset.");
        }

        protected void OpenFile(FileMode mode)
        {
            stream = new FileStream(GetPath(), mode);
        }

        protected void Read(int count, out byte[] buffer)
        {
            buffer = new byte[count];
            int read = stream.Read(buffer, 0, count);
            Debug.Assert(read == count);
        }

        protected byte ReadByte()
        {
            Read(1, out byte[] buffer);
            return buffer[0];
        }

        protected char ReadChar()
        {
            Read(1, out byte[] buffer);

            string str = Encoding.ASCII.GetString(buffer, 0, 1);
            Debug.Assert(str.Length == 1);

            return str[0];
        }

        protected short ReadShort()
        {
            Read(2, out byte[] buffer);
            return BitConverter.ToInt16(buffer, 0);
        }

        protected ushort ReadUShort()
        {
            Read(2, out byte[] buffer);
            return BitConverter.ToUInt16(buffer, 0);
        }

        protected int ReadInt()
        {
            Read(4, out byte[] buffer);
            return BitConverter.ToInt32(buffer, 0);
        }

        protected uint ReadUInt()
        {
            Read(4, out byte[] buffer);
            return BitConverter.ToUInt32(buffer, 0);
        }

        protected float ReadFloat()
        {
            Read(4, out byte[] buffer);
            return BitConverter.ToSingle(buffer, 0);
        }

        public override string ToString()
        {
            return Name;
        }

        public string Info
        {
            get
            {
                return GetInfo();
            }
        }

        protected abstract string GetInfo();
    }
}
