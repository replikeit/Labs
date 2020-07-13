
/*************************************************************************
   LAB 1                                                                

    Edit this file ONLY!

*************************************************************************/

#include <malloc.h>
#include "dns.h"
#include <vcruntime.h>
#include <stdio.h>
#include <string.h>

unsigned int size = 12837;
typedef struct _DnsObj // —труктура дл€ массива
{
	char* domain;
	IPADDRESS ip;
	struct _DnsObj* nextDns;
}DnsObj;
unsigned int getHash(const char* domainName)// машина дл€ создание индекса
{
	unsigned int hash = 0;
	size_t domainLen = strlen(domainName);
	for (size_t i = 0; i < domainLen;i++) {

		hash += domainName[i];
		hash += i + domainLen;

	}
	return hash % size;
}


void insert(DNSHandle hDNS, char* domainName, IPADDRESS ip)// ¬ставить в массив 
{
	int domainLen = strlen(domainName);
	int index = getHash(domainName);
	if (((DnsObj*)hDNS)[index].domain == NULL)
	{
		((DnsObj*)hDNS)[index].ip = ip;
		((DnsObj*)hDNS)[index].domain = (char*)malloc(domainLen+1);
		strcpy(((DnsObj*)hDNS)[index].domain, domainName);
		

	}
	else
	{
		DnsObj *tmpDns = &((DnsObj*)hDNS)[index];
		while(tmpDns->nextDns != NULL)
		{
			tmpDns = tmpDns->nextDns;
		}
		DnsObj *tmp2Dns = (DnsObj*)malloc(sizeof(DnsObj));
		tmp2Dns->ip = ip;
		tmp2Dns->domain = (char*)malloc(domainLen+1);
		strcpy(tmp2Dns->domain, domainName);
		tmp2Dns->nextDns = NULL;
		tmpDns->nextDns = tmp2Dns;
		int a = 02;
	}
}
IPADDRESS getIp(unsigned int* ar)// ip в int
{

	return (ar[0] * 256 * 256 * 256) + (ar[1] * 256 * 256) + (ar[2] * 256) + (ar[3]);
}

DNSHandle InitDNS()
{
	DNSHandle hDNS = (unsigned int)(DnsObj*)calloc(size, sizeof(DnsObj));// создание массива
	if ((DnsObj*)hDNS != NULL)
		return hDNS;
	return INVALID_DNS_HANDLE;
}


void LoadHostsFile( DNSHandle hDNS, const char* hostsFilePath )
{
	FILE* file = NULL;
	char* domainName = (char*)malloc(300);
	file = fopen(hostsFilePath, "r");
	unsigned int *ipAr = (unsigned int*)calloc(4, sizeof(unsigned int));
	while (fscanf(file, "%d.%d.%d.%d %s", &ipAr[0], &ipAr[1], &ipAr[2], &ipAr[3], domainName) != EOF)
	{
		IPADDRESS ip = getIp(ipAr);
		insert(hDNS,domainName,ip);
	}
	free(domainName);
	fclose(file);
}


void ShutdownDNS( DNSHandle hDNS )
{
	DnsObj* tmp1;
	DnsObj* tmp2;
	for (int i = 0; i < size; i++) {
		tmp2 = &(((DnsObj*)hDNS)[i]);
		while (tmp2 != NULL)
		{
			tmp1 = tmp2;
			tmp2 = tmp2->nextDns;
			free(tmp1->domain);
		}
	}
	if ((DnsObj*)hDNS != NULL)
		free((DnsObj*)hDNS);
}




IPADDRESS DnsLookUp( DNSHandle hDNS, const char* hostName )
{	
	int index = getHash(hostName);
	DnsObj *tmpDns = &((DnsObj*)hDNS)[index];	
	while (tmpDns != NULL && strcmp(tmpDns->domain, hostName) != 0)
	{
		tmpDns = tmpDns->nextDns;
	}
	if (tmpDns != NULL)
		return tmpDns->ip;
    return INVALID_IP_ADDRESS;
}



