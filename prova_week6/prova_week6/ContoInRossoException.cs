using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace prova_week6
{
    public class ContoInRossoException : Exception
    {

        public decimal SaldoContoCorrente { get; set; }
        public decimal ImportoPrelievo { get; set; }

        public ContoInRossoException()
        {
        }

        public ContoInRossoException(string message) : base(message)
        {
        }

        public ContoInRossoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ContoInRossoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
