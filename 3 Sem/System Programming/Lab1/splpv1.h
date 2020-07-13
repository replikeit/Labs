/* 
 * SPLPv1.c
 * The file is part of practical task for System programming course. 
 * This file contains definitions of the data structures and forward
 * declaration of handle_message() function
 */


enum test_status 
{ 
    MESSAGE_INVALID, 
    MESSAGE_VALID 
};


enum Direction 
{ 
    A_TO_B, 
    B_TO_A 
};


struct Message /* message */
{
	enum Direction	direction;        
	char			*text_message;
};

enum _ProtocolStatus
{
	INIT = 1,
	CONNECTING = 2,
	CONNECTED = 3,
	WAITING_VER = 4,
	WAITING_DATA = 5,
	WAITING_B64_DATA = 6,
	DISCONNECTING = 7
}typedef ProtocolStatus;


enum _bool
{
	false = 0,
	true = 1
}typedef bool;

extern enum test_status validate_message( struct Message* pMessage ); 
