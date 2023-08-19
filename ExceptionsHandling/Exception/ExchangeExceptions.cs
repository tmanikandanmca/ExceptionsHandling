using System;
namespace ExceptionsHandling.Exception;

public class ExchangeExceptions:System.Exception
{

	public ExchangeExceptions()
	{			
	}

	public ExchangeExceptions(string Message):base(Message)
	{			
	}

	public ExchangeExceptions(string Message, System.Exception Ex):base(Message, Ex) 
	{
			
	}

}
