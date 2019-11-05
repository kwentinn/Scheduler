using System;
using System.Runtime.Serialization;

namespace Scheduler.Reporting.Data
{
	[Serializable]
	internal class ReadModelException : Exception
	{
		public ReadModelException()
		{
		}

		public ReadModelException(string message) : base(message)
		{
		}

		public ReadModelException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected ReadModelException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}