/*
  Фамилия, Имя, Отчество
Приходько Егор Андреевич
  № группы 13
*/
#include "splpv1.h"
#include <string.h>
char s = '*';
ProtocolStatus _protocolStatus = INIT;
unsigned int arrBase64[] = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1,
	1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
	1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1,
	1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
unsigned int arrDataFile[] = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
	1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1,
	1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
unsigned int arrData[] = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
	1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1,
	1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
unsigned int arrVer[] = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
	1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };


// Функции проверки



bool checkVER(const char* message)// проверка правильности WAITING_VER
{
	const char* tmpStr = "VERSION ";
	unsigned int mesLen = 0;
	for (int i = 0; i < 8; i++)
	{
		if (message[i] != tmpStr[i])
			return false;
		mesLen++;
	}
		
	for (int i = 8; message[i] != '\0' ;i++)
	{
		if (arrVer[(int)message[i]] != 1)
			return false;
		mesLen++;
	}
	return true;
}

bool checkDATA(const char* message) // проверка правильности DATA
{
	const char* tmpStr1 = "GET_DATA ";
	const char* tmpStr2 = " GET_DATA";
	int checkErrorCount = 0;
	int i;
	for (i = 0; i < 9; i++)
	{
		if (message[i] != tmpStr1[i])
			return false;
	}
	for (i = 9; message[i] != '\0'; i++)
	{
		if (arrData[(int)message[i]] != 1)
			checkErrorCount++;
	}
	int size = i - 9;
	for (i = 0; i < 9; i++)
	{
		if (message[size + i] != tmpStr2[i])
			return false;
		else
			checkErrorCount--;
	}
	if (checkErrorCount != 0)
		return false;
	return true;
}


bool checkCOMMAND(const char* message) // проверка правильности COMMAND
{
	
	const char* tmpStr1 = "GET_COMMAND ";
	const char* tmpStr2 = " GET_COMMAND";
	int checkErrorCount = 0;
	int i;
	for (i = 0;i < 12;i++)
	{
		if (message[i] != tmpStr1[i])
			return false;
	}
	for (i = 12; message[i] != '\0';i++)
	{
		if (arrData[(int)message[i]] != 1)
			checkErrorCount++;
	}
	int size = i - 12;
	for(i = 0;i < 12 ; i++)
	{
		if (message[size + i] != tmpStr2[i])
			return false;
		else
			checkErrorCount--;
	}
	if (checkErrorCount != 0)
		return false;
	return true;
}


bool checkFILE(const char* message) // проверка правильности FILE
{
	const char* tmpStr1 = "GET_FILE ";
	const char* tmpStr2 = " GET_FILE";
	int checkErrorCount = 0;
	int i;
	for (i = 0; i < 9; i++)
	{
		if (message[i] != tmpStr1[i])
			return false;
	}
	for (i = 9; message[i] != '\0'; i++)
	{
		if (arrData[(int)message[i]] != 1)
			checkErrorCount++;
	}
	int size = i - 9;
	for (i = 0; i < 9; i++)
	{
		if (message[size + i] != tmpStr2[i])
			return false;
		else
			checkErrorCount--;
	}
	if (checkErrorCount != 0)
		return false;
	return true;
}



bool checkB64(const char* message) // проверка правильности B64
{
	const char* tmpStr = "B64: ";
	int check  = 0;
	int i = 0;
	for (int i = 0;i < 5;i++)
	{
		if (message[i] != tmpStr[i])
			return false;
	}
	for (i = 5;message[i] != '\0';i++)
	{
		if (arrBase64[(int)message[i]] != 1)
		{
			if (message[i] == '=')
				check++;
			else
				return false;
		}
			
	}
	int size = i;
	if(check > 0)
		for (unsigned int i = size - 2;i < size;i++)
		{
			if (arrBase64[(int)message[i]] != 1 && message[i] != '=')
				return false;
			if (message[i] == '=')
				check--;
		}
	if (check != 0)
	{
		return false;
	}
	if ((size - 5) % 4 != 0)
		return false;
	return true;
}


enum test_status validate_message(struct Message* msg)
{
	if (msg->direction == A_TO_B)
	{
		if (_protocolStatus == INIT)
		{
			if (strcmp("CONNECT", msg->text_message) == 0)
				_protocolStatus = CONNECTING;
			
			else
			{
				_protocolStatus = INIT;
				return MESSAGE_INVALID;
			}				
		}

		else if (_protocolStatus == CONNECTED)
		{
				if (strcmp("GET_VER", msg->text_message) == 0)
					_protocolStatus = WAITING_VER;

				else if (strcmp("GET_DATA", msg->text_message) == 0 ||
					strcmp("GET_COMMAND", msg->text_message) == 0 ||
					strcmp("GET_FILE", msg->text_message) == 0)
					_protocolStatus = WAITING_DATA;

				else if (strcmp("GET_B64", msg->text_message) == 0)
					_protocolStatus = WAITING_B64_DATA;

				else if(strcmp("DISCONNECT", msg->text_message) == 0)
					_protocolStatus = DISCONNECTING;

				else
				{
					_protocolStatus = INIT;
					return MESSAGE_INVALID;
				}
		}
		else
		{
			_protocolStatus = INIT;
			return MESSAGE_INVALID;
		}
	}
	//B_TO_A
	else
	{
		if (_protocolStatus == CONNECTING)
		{
			if (strcmp("CONNECT_OK", msg->text_message) == 0)
				_protocolStatus = CONNECTED;
			else
			{
				_protocolStatus = INIT;
				return MESSAGE_INVALID;
			}
		}

		else if (_protocolStatus == DISCONNECTING)
		{
			if (strcmp("DISCONNECT_OK", msg->text_message) == 0)
				_protocolStatus = INIT;
			else
			{
				_protocolStatus = INIT;
				return MESSAGE_INVALID;
			}
		}

		else if (_protocolStatus == WAITING_VER)
		{
			if (checkVER(msg->text_message) == true)
			{
				_protocolStatus = CONNECTED;
			}
			else
			{
				_protocolStatus = INIT;
				return MESSAGE_INVALID;
			}
				
		}

		else if (_protocolStatus == WAITING_DATA)
		{
			if(msg->text_message[4] == 'D')
			{
				if (checkDATA(msg->text_message) == true)
				{
					_protocolStatus = CONNECTED;
				}
				else
				{
					_protocolStatus = INIT;
					return MESSAGE_INVALID;
				}
			}	
			else if (msg->text_message[4] == 'C')
			{
				if (checkCOMMAND(msg->text_message) == true)
				{
					_protocolStatus = CONNECTED;
				}
				else
				{
					_protocolStatus = INIT;
					return MESSAGE_INVALID;
				}
			}
			else if (msg->text_message[4] == 'F')
			{
				if (checkFILE(msg->text_message) == true)
				{
					_protocolStatus = CONNECTED;
				}
				else
				{
					_protocolStatus = INIT;
					return MESSAGE_INVALID;
				}
			}
				
		}

		else if (_protocolStatus == WAITING_B64_DATA)
		{
			if (checkB64(msg->text_message) == true)
			{
				_protocolStatus = CONNECTED;
			}
			else
			{
				_protocolStatus = INIT;
				return MESSAGE_INVALID;
			}
		}

		else
		{
			_protocolStatus = INIT;
			return MESSAGE_INVALID;
		}
	}


	return MESSAGE_VALID;
};



