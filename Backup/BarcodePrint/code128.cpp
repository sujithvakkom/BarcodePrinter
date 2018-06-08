/****************************************************************************
  File:  CODE128.CPP
  Module:  Code 128

  Prototypes:
    void BarcodeC128CodesetA (BYTE *outbuf, BYTE *inbuf, WORD insize);
    void BarcodeC128CodesetB (BYTE *outbuf, BYTE *inbuf, WORD insize);
    void BarcodeC128CodesetC (BYTE *outbuf, BYTE *inbuf, WORD insize);
    void BarcodeC128FNC1C (BYTE *outbuf, BYTE *inbuf, WORD insize)

  Revision History:
    02Jul02  Yazel      Add function Code C with leading FNC1
    03May00  J R Slack  Merged with Beta2 code for Beta3 release.
    30Mar00  C R King   Removed the const from the constant start/stop char's
						this was generating a few linker errors
    03Feb00  J R Slack  Cleanup for Sample code release
    20Jan00  J R Slack  File created

  Description:  Creates generic Code 128 Symbol font strings in outbuf,
        for use with Azalea Software's Code128 Font, given a Null-terminated
        ASCII string in inbuf, and the count of bytes in inbuf, in insize.

        Note that for BarcodeC128CodesetC(), insize must be even; an empty
        string (0-length) will be returned if insize is odd.

  Constraints:  Does not enforce valid data. It's the caller's responsibility
        to select the correct code set for the data to be encoded.

        Valid data sets are:
            Code set A: NUL-US, 0-9, A-Z, most punct'n (ASCII 00..95)
            Code set B: 0-9, A-Z, a-z, misc. punct'n   (ASCII 32..127)
            Code set C: encodes pairs of numbers, 00..99 (ASCII 48,48..57,57)

  Note: This release does not support embedded Function codes (FNC1, ...).

  Copyright © Azalea Software, Inc. 2000.  All rights reserved.
****************************************************************************/
#include "platform.h"

// Prototype the 'general purpose' routine:
void FormatC128(BYTE *outbuf, BYTE *inbuf, WORD insize, BYTE start_char);

/************************************************************
Public Functions
************************************************************/
void LIB_PROC
BarcodeC128CodesetA (BYTE *outbuf, BYTE *inbuf, WORD insize)
{
    extern char C128_START_A;

    FormatC128(outbuf, inbuf, insize, C128_START_A);
}

void LIB_PROC
BarcodeC128CodesetB (BYTE *outbuf, BYTE *inbuf, WORD insize)
{   extern char C128_START_B;

    FormatC128(outbuf, inbuf, insize, C128_START_B);
}

void LIB_PROC
BarcodeC128CodesetC (BYTE *outbuf, BYTE *inbuf, WORD insize)
{
    extern char C128_START_C;

    // assume all-numeric (caller's responsibility), but ensure even length
    if ((insize % 2) != 0)
		*outbuf = '\0';

    else
         FormatC128(outbuf, inbuf, insize, C128_START_C);
}

void LIB_PROC
BarcodeC128FNC1C(BYTE *outbuf, BYTE *inbuf, WORD insize)
{
    extern char C128_START_C;
	extern char C128_START_C_FNC1;
// assume all-numeric (caller's responsibility), but ensure even length
    if ((insize % 2) != 0)
        *outbuf = '\0';
    else
		FormatC128(outbuf, inbuf, insize, C128_START_C_FNC1);
}

/****************************************************************************
Low-level formatter.
****************************************************************************/
// ASCII char offsets
#define SPACE    32
#define RUBOUT  127
#define ATSIGN   64

void FormatC128(BYTE *outbuf, BYTE *inbuf, WORD insize, BYTE start_char)
{
    extern BYTE SymbolToFont(BYTE symbol);
    extern char C128_START_C;
	extern char C128_START_C_FNC1;

    extern char C128_STOP;

    BYTE    symbol;         // input char work buffer
    BYTE    next_digit;     // temp for codeset C
    WORD    count;          // of input chars processed
    long    checkdigit;     // accumulator; can get very big, very fast
    WORD    weight;         // weighted input position, for check digit calc.

    // map the start char and output it
    
	 // initialize the checkdigit

	if (start_char == C128_START_C_FNC1)
	{
		*outbuf++ = 183;//start C
		checkdigit = 105;//start C
		weight = 1;
	}
	else
	{
		*outbuf++ = SymbolToFont(start_char);
		checkdigit = start_char;
		weight = 1;
	}


	if (start_char == C128_START_C_FNC1)
	{	
		*outbuf++ = 205;
		checkdigit += 102;//fnc1 rank in c128 table
        weight+=1;
	}

    // process the input stream
    for (count = 0; count < insize; )
    {
        // get the raw input char
        symbol = *inbuf;

        // a bit costly, but cheaper than lots of function calls/string scans:
        if ((start_char != C128_START_C)&&(start_char != C128_START_C_FNC1))  {
            // convert input char to Symbol char
            if (symbol >= SPACE && symbol <= RUBOUT) // Codeset B?
                
				symbol -= SPACE;     // 0-base the alfa set
            
			else   
				
				symbol += ATSIGN;    // map controls set into the alfa set

            inbuf++;
            count++;

        } else if((start_char == C128_START_C)||(start_char == C128_START_C_FNC1)){
            // compress two input digits to one Symbol char
            symbol -= '0';
            next_digit = *(inbuf +1) - '0';
            // pack 'em
            symbol = (symbol * 10) + next_digit;

            // process next pair
            inbuf += 2;
            count += 2;
        }
		

        // map Symbol char to Font char and output it
        *outbuf++ = SymbolToFont(symbol);

        // update the checkdigit
        checkdigit += symbol * weight;
        weight++;

    }

    // done processing; now finalize the MOD 103 checkdigit
    *outbuf++ = SymbolToFont((BYTE)(checkdigit % 103));

    // place the stop bar and terminate the string
    *outbuf++ = SymbolToFont(C128_STOP);
    *outbuf   = '\0';

}

/* end CODE128.CPP */

