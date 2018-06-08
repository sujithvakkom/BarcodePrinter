/****************************************************************************
  File:  C128FONT.CPP
  Module:  Code 128

  Prototype:  BYTE SymbolToFont(BYTE symbol)

  Revision History:
    03May00  J R Slack  Merged Beta2 code for Beta3 release.
    30Mar00  C R King   Removed the const from the constant start/stop char's
						this was generating a few linker errors
	03Feb00  J R Slack  additional comments
    20Jan00  J R Slack  File created
    
  Description:  Performs Code 128 Symbol value to Azalea Font value conversion.
        Correct for Version 4.0 fonts; can be used with prior font versions by
        #define-ing OLD_FONTS.

        The table maps Decimal value and corresponding ASCII character
        for Codesets A and B, and Symbol Value ( == packed digit pair value
        for digit pairs 00 to 99) for Codeset C, to Azalea Font value.

  Copyright © Azalea Software, Inc. 2000.  All rights reserved.
****************************************************************************/
#include "platform.h"

// Uncomment the next line if you're using Azalea Fonts prior to Version 4.0:
//#define OLD_FONTS

const BYTE C128FONT[] = {

// Codeset A, B    32  33  34  35  36  37  38  39  40  41
// ASCII char      SP   !   "   #   $   %   &   '   (   )
// Symbol Value:   00  01  02  03  04  05  06  07  08  09
//#ifndef OLD_FONTS
/* Font Value */  206, 33, 34, 35, 36, 37, 38, 39, 40, 41,
//#else
/* Font Value */ // 194, 33, 34, 35, 36, 37, 38, 39, 40, 41,
//#endif

// Codeset A, B    42  43  44  45  46  47
// ASCII char       *   +   ,   -   ,   /
// Symbol Value:   10  11  12  13  14  15
/* Font Value */   42, 43, 44, 45, 46, 47,

// Codeset A, B    48  49  50  51  52  53  54  55  56  57
// ASCII char       0   1   2   3   4   5   6   7   8   9
// Symbol Value:   16  17  18  19  20  21  22  23  24  25
/* Font Value */   48, 49, 50, 51, 52, 53, 54, 55, 56, 57,

// Codeset A, B    58  59  60  61  62  63  64
// ASCII char       :   ;   <   =   >   ?   @
// Symbol Value:   26  27  28  29  30  31  32
/* Font Value */   58, 59, 60, 61, 62, 63, 64,

// Codeset A, B    65  66  67  68  69  70  71  72  73
// ASCII char       A   B   C   D   E   F   G   H   I
// Symbol Value:   33  34  35  36  37  38  39  40  41
/* Font Value */   65, 66, 67, 68, 69, 70, 71, 72, 73,

// Codeset A, B    74  75  76  77  78  79  80  81  82
// ASCII char       J   K   L   M   N   O   P   Q   R
// Symbol Value:   42  43  44  45  46  47  48  49  50
/* Font Value */   74, 75, 76, 77, 78, 79, 80, 81, 82,

// Codeset A, B    83  84  85  86  87  88  89  90
// ASCII char       S   T   U   V   W   X   Y   Z
// Symbol Value:   51  52  53  54  55  56  57  58
/* Font Value */   83, 84, 85, 86, 87, 88, 89, 90,

// Codeset A, B    91  92  93  94  95
// ASCII char       [   \   ]   ^   _
// Symbol Value:   59  60  61  62  63
/* Font Value */   91, 92, 93, 94, 95,

// Codeset A        0
// ASCII char      NUL
// Codeset B       96
// ASCII char       `
// Symbol Value:   64
/* Font Value */   96,

// Codeset A        1    2   3    4    5    6    7    8    9
// ASCII char      SOH STX ETX  EOT  ENQ  ACK  BEL   BS   HT
// Codeset B       97   98  99  100  101  102  103  104  105
// ASCII char       a   b    c    d    e    f    g    h   i
// Symbol Value:   65   66  67   68   69   70   71   72   73
/* Font Value */   97,  98, 99, 100, 101, 102, 103, 104, 105,

// Codeset A       10   11   12   13   14   15   16   17   18
// ASCII char      LF   VT   FF   CR  SOH   SI  DLE  DC1  DC2
// Codeset B      106  107  108  109  110  111  112  113  114
// ASCII char       j    k    l    m    n    o    p    q    r
// Symbol Value:   74   75   76   77   78   79   80   81   82
/* Font Value */  106, 107, 108, 109, 110, 111, 112, 113, 114,

// Codeset A       19   20   21   22   23   24   25   26
// ASCII char     DC3  DC4  NAK  SYN  ETB  CAN   EM  SUB
// Codeset B      115  116  117  118  119  120  121  122
// ASCII char       s    t    u    v    w    x    y    z
// Symbol Value:   83   84   85   86   87   88   89   90
/* Font Value */  115, 116, 117, 118, 119, 120, 121, 122,

// Codeset A       27   28   29   30   31
// ASCII char     ESC   FS   GS   RS   US
// Codeset B      123  124  125  126  127
// ASCII char       {    |    }    ~  DEL
// Symbol Value:   91   92   93   94   95
//#ifndef OLD_FONTS
/* Font Value */  123, 124, 125, 197, 198,
//#else
/* Font Value */ // 123, 124, 125, 185, 186,
//#endif

/****************************************************************************
Note: Escaped Function codes in the input stream are not currently supported;
    escaped char values are preliminary.
****************************************************************************/

// Codeset A, B   FNC3 FNC2  SHIFT CODE_C
// escaped char    %3   %2    %S     %C
// Symbol Value:   96   97    98     99
//#ifndef OLD_FONTS
/* Font Value */  199, 200,  201,   202,
//#else
/* Font Value */ // 187, 188,  189,   190,
//#endif

// Codeset A   CODE_B   FNC4
// escaped char    %B     %4
// Codeset B     FNC4 CODE_A
// escaped char    %4     %A
// Codeset C   CODE_B CODE_A
// Symbol Value:  100    101
//#ifndef OLD_FONTS
/* Font Value */  203,   204,
//#else
/* Font Value */ // 191,   192,
//#endif

// Codeset A,B,C FNC1
// escaped char    %1
// Symbol Value:  102
//#ifndef OLD_FONTS
/* Font Value */  205,
//#else
/* Font Value */ // 193,
//#endif

// Codeset A     START_A
// escaped char       %W
// Codeset B             START_B
// escaped char               %X
// Codeset C                     START_C
// escaped char                       %Y
// Symbol Value:     103     104     105
//#ifndef OLD_FONTS
/* Font Value */     181,    182,    183,
//#else
//* Font Value */     161,    162,    163,
//#endif

// Codeset A,B,C  STOP
// escaped char     %Z
// Symbol Value:   106
//#ifndef OLD_FONTS
/* Font Value */   196,
//#else
/* Font Value */  // 184,
//#endif

}; /* end C128FONT[] */

// Special Symbol Characters
char C128_START_A = 103;
char C128_START_B = 104;
char C128_START_C = 105;
char C128_START_C_FNC1 = 107;
char C128_STOP    = 106;

BYTE SymbolToFont(BYTE symbol)
{
    return C128FONT[symbol];
}

// for debug/test only: reveal table size for reverse lookup
short table_size = sizeof(C128FONT) / sizeof(C128FONT[0]);

/* end C128FONT.CPP */

