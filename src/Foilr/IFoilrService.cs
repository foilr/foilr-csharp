using System;

namespace Foilr
{
	public interface IFoilrService
	{
		void LogException(Exception exception);
		void LogException(ExceptionRecord record);
	}
}