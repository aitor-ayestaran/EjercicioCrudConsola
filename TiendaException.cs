using System;
using System.Runtime.Serialization;

namespace EjercicioCrudConsola.Entidades
{
    [Serializable]
    internal class TiendaException : Exception
    {
        public TiendaException()
        {
        }

        public TiendaException(string message) : base(message)
        {
        }

        public TiendaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TiendaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}