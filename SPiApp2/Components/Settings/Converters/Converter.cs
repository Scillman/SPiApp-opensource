using System;
using System.Diagnostics;

namespace SPiApp2.Components.Settings.Converters
{
    /// <summary>
    /// The global converter functions.
    /// </summary>
    public interface IConverter
    {
        /// <summary>
        /// Get the type of the converter.
        /// </summary>
        Type Type
        {
            get;
        }

        /// <summary>
        /// Get or set the ambiguous value.
        /// </summary>
        string Ambiguous
        {
            get;
            set;
        }

        /// <summary>
        /// Clears the object to its default value.
        /// </summary>
        void Default();
    }

    /// <summary>
    /// Converter functions for specific types only.
    /// </summary>
    /// <typeparam name="V">The <see cref="System.Type"/> of the value.</typeparam>
    public interface IConverter<V>
    {
        /// <summary>
        /// Get or set the value explicitly.
        /// </summary>
        V Value
        {
            get;
            set;
        }

        /// <summary>
        /// Set the default value.
        /// </summary>
        /// <param name="value">The default value.</param>
        void SetDefault(V value);
    }

    /// <summary>
    /// A converter object.
    /// </summary>
    /// <typeparam name="T">The type of the control object.</typeparam>
    /// <typeparam name="V">The type of the explicit value.</typeparam>
    public abstract class Converter<T, V> : IConverter, IConverter<V>
    {
        /// <summary>
        /// The object as passed to the converter.
        /// </summary>
        protected T obj;

        /// <summary>
        /// Creates a new converter for the object.
        /// </summary>
        /// <param name="control">The object to create a converter for.</param>
        public Converter(ref T obj)
        {
            Debug.Assert(obj != null, "Converter does not accept NULL objects.");
            this.obj = obj;
        }

        /// <summary>
        /// Creates a new converter for the object.
        /// </summary>
        /// <param name="obj">The object to create a converter for.</param>
        protected Converter(T obj)
        {
            Debug.Assert(obj != null, "Converter does not accept NULL objects.");
            this.obj = obj;
        }

        /// <summary>
        /// Get the type of the converter.
        /// </summary>
        public Type Type
        {
            get
            {
                return typeof(T);
            }
        }

        /// <summary>
        /// Get or set the value explicitly.
        /// </summary>
        public abstract V Value
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set the ambiguous value.
        /// </summary>
        public abstract string Ambiguous
        {
            get;
            set;
        }

        /// <summary>
        /// Clears the object to its default value.
        /// </summary>
        public abstract void Default();

        /// <summary>
        /// Set the default value.
        /// </summary>
        /// <param name="value">The default value.</param>
        public abstract void SetDefault(V value);
    }
}
