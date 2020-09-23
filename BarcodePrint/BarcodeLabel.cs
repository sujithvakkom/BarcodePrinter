using BarcodePrinter.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BarcodePrinter
{
    public class BarcodeLabel
    {
        static readonly Regex re = new Regex(@"\$(\w+)\$", RegexOptions.Compiled);

        static string ELNFormat = Resources.SampleCode128ELN; // "\nN\nOD\nq344\nQ192,24\nD15\nS1\nA30,20,0,2,1,1,N,\"{DESCRIPTION}\"\nB50,50,0,E30,2,5,80,B,\"{BARCODE}\"\nA30,150,0,4,1,1,N,\"{CURRENCY}.\"\nA90,150,0,4,1,1,N,\"{PRICE}\"\nA140,175,0,1,1,1,N,\nP{END}\n";
        static string ELNFormatEAN13 = Resources.SampleEAN13ELN; // "\nN\nOD\nq344\nQ192,24\nD15\nS1\nA30,20,0,2,1,1,N,\"{DESCRIPTION}\"\nB50,50,0,E30,2,5,80,B,\"{BARCODE}\"\nA30,150,0,4,1,1,N,\"{CURRENCY}.\"\nA90,150,0,4,1,1,N,\"{PRICE}\"\nA140,175,0,1,1,1,N,\nP{END}\n";
        static string ELNFormatCode128 = Resources.SampleCode128ELN; // "\nN\nOD\nq344\nQ192,24\nD15\nS1\nA30,20,0,2,1,1,N,\"{DESCRIPTION}\"\nB50,50,0,1,2,2,70,B,\"{BARCODE}\"\nA30,150,0,4,1,1,N,\"{CURRENCY}.\"\nA90,150,0,4,1,1,N,\"{PRICE}\"\nA140,175,0,1,1,1,N,\nP{END}\n";

        static Dictionary<string, string> CurrancyDefaultFormat = new Dictionary<string, string>()
        {
#region Currancy_Formats
            {"AED","2"},           //United Arab Emirates dirham
            {"AFN","2"},           //Afghanistan afghani
            {"AMD","2"},           //Armenian dram
            {"ANG","2"},           //Netherlands Antillean guilder
            {"AOA","2"},           //Angola kwanza
            {"ARS","2"},           //Argentine peso
            {"AUD","2"},           //Australian dollar
            {"AWG","2"},           //Aruban guilder
            {"AZN","2"},           //Azerbaijanian manat
            {"BAM","2"},           //Bosnia and Herzegovina convertible mark
            {"BBD","2"},           //Barbados dollar
            {"BDT","2"},           //Bangladeshi taka
            {"BGN","2"},           //Bulgarian lev
            {"BHD","3"},           //Bahraini dinar
            {"BIF","0"},           //Burundian franc
            {"BMD","2"},           //Bermuda dollar
            {"BND","2"},           //Brunei dollar
            {"BOB","2"},           //Bolivian boliviano
            {"BRL","2"},           //Brazilian real
            {"BSD","2"},           //Bahamian dollar
            {"BWP","2"},           //Botswana pula
            {"BYR","0"},           //Belarussian ruble
            {"BYN","2"},           //Belarussian ruble
            {"BZD","2"},           //Belize dollar
            {"CAD","2"},           //Canadian dollar
            {"CDF","2"},           //Congolese franc
            {"CHF","2"},           //Swiss franc
            {"CLP","0"},           //Chilean peso
            {"CNY","2"},           //Chinese yuan renminbi
            {"COP","2"},           //Columbian peso
            {"CRC","2"},           //Costa Rican colon
            {"CSK","2"},           //Czech koruna
            {"CVE","2"},           //Cape Verde escudo
            {"CZK","2"},           //Czech koruna
            {"DJF","0"},           //Djiboutian franc
            {"DKK","2"},           //Danish krone
            {"DOP","2"},           //Dominican peso
            {"DZD","2"},           //Algerian dinar
            {"EGP","2"},           //Egyptian pound
            {"ERN","2"},           //Eritrean nakfa
            {"ETB","2"},           //Ethiopian birr
            {"EUR","2"},           //Euro
            {"FJD","2"},           //Fiji dollar
            {"FKP","2"},           //Falkland Islands pound
            {"GBP","2"},           //British pound sterling
            {"GEL","2"},           //Georgian lari
            {"GHS","2"},           //Ghana cedi
            {"GIP","2"},           //Gibraltar pound
            {"GMD","2"},           //Gambian dalasi
            {"GNF","0"},           //Guinean franc
            {"GTQ","2"},           //Guatemalan quetzal
            {"GWP","0"},           //Guinea-Bissau peso
            {"GYD","2"},           //Guyanese dollar
            {"HKD","2"},           //Hong Kong dollar
            {"HNL","2"},           //Hunduran Lempira
            {"HRK","2"},           //Croatian kuna
            {"HTG","2"},           //Haitian gourde
            {"HUF","2"},           //Hungarian forint
            {"IDR","2"},           //Indonesian rupiah
            {"ILS","2"},           //Israeli sheqel
            {"INR","2"},           //Indian rupee
            {"IQD","3"},           //Iraqi dinar
            {"ISK","2"},           //Icelandic krona
            {"JMD","2"},           //Jamaican dollar
            {"JOD","3"},           //Jordanian dinar
            {"JPY","0"},           //Japanese yen
            {"KES","2"},           //Kenyan shilling
            {"KGS","2"},           //Kyrgyzstani som
            {"KHR","2"},           //Cambodian riel
            {"KMF","0"},           //Comoro franc
            {"KRW","0"},           //South Korean won
            {"KWD","3"},           //Kuwaiti dinar
            {"KYD","2"},           //Cayman Islands dollar
            {"KZT","2"},           //Kazakhstani tenge
            {"LAK","2"},           //Lao kip
            {"LBP","2"},           //Lebanese pound
            {"LKR","2"},           //Sri Lanka rupee
            {"LRD","2"},           //Liberian dollar
            {"LSL","2"},           //Lesotho loti
            {"LTL","2"},           //Lithuanian litas
            {"LVL","2"},           //Latvian lats
            {"MAD","2"},           //Moroccan dirham
            {"MDL","2"},           //Moldovan leu
            {"MGA","0"},           //Malagasy ariary
            {"MKD","2"},           //Macedonian denar
            {"MMK","2"},           //Myanmar kyat
            {"MNT","2"},           //Mongolian tugrik
            {"MOP","2"},           //Macanese pataca
            {"MRO","2"},           //Mauritanian ouguiya
            {"MUR","2"},           //Mauritius rupee
            {"MVR","2"},           //Maldivian rufiyaa
            {"MWK","2"},           //Malawian kwacha
            {"MXN","2"},           //Mexican peso
            {"MYR","2"},           //Malaysian ringgit
            {"MZN","2"},           //Mozambican metical
            {"NAD","2"},           //Namibian dollar
            {"NGN","2"},           //Nigerian naira
            {"NIO","2"},           //Cordoba oro
            {"NOK","2"},           //Norwegian krone
            {"NPR","2"},           //Nepalese rupee
            {"NZD","2"},           //New Zealand dollar
            {"OMR","3"},           //Omani rial
            {"PAB","2"},           //Panamanian balboa
            {"PEN","2"},           //Peruvian nuevo sol
            {"PGK","2"},           //Papua New Guinean kina
            {"PHP","2"},           //Philippine peso
            {"PKR","2"},           //Pakistan rupee
            {"PLN","2"},           //Polish zloty
            {"PYG","0"},           //Paraguayan guarani
            {"QAR","2"},           //Qatari rial
            {"RON","2"},           //Romanian leu
            {"RSD","2"},           //Serbian dinar
            {"RUB","2"},           //Russian ruble
            {"RWF","0"},           //Rwanda franc
            {"SAR","2"},           //Saudi Arabian riyal
            {"SBD","2"},           //Solomon Islands dollar
            {"SCR","2"},           //Seychelles rupee
            {"SEK","2"},           //Swedish krona
            {"SGD","2"},           //Singapore dollar
            {"SHP","2"},           //Saint Helena pound
            {"SLL","2"},           //Sierra Leonean leone
            {"SOS","2"},           //Somali shilling
            {"SRD","2"},           //Surinamese dollar
            {"SSP","2"},           //South Sudanese pound
            {"STD","2"},           //Sao Tome and Principe dobra
            {"SYP","2"},           //Syrian pound
            {"SZL","2"},           //Swaziland lilangeni
            {"THB","2"},           //Thai baht
            {"TJS","2"},           //Tajikistani somoni
            {"TND","3"},           //Tunisian dinar
            {"TOP","2"},           //Tongan pa’anga
            {"TRY","2"},           //Turkish lira
            {"TTD","2"},           //Trinidad and Tobago dollar
            {"TWD","2"},           //Taiwan dollar
            {"TZS","2"},           //Tanzanian shilling
            {"UAH","2"},           //Ukrainian hryvnia
            {"UGX","2"},           //Ugandan shilling
            {"USD","2"},           //United States dollar
            {"UYU","2"},           //Uruguayan peso
            {"UZS","2"},           //Uzbekistan som
            {"VEF","2"},           //Venezuelan bolivar fuerte
            {"VND","0"},           //Vietnamese dong
            {"VUV","0"},           //Vanuatu vatu
            {"WST","2"},           //Samoan tala
            {"XAF","0"},           //CFA franc BEAC
            {"XCD","2"},           //East Caribbean dollar
            {"XOF","0"},           //CFA Franc BCEAO
            {"XPF","0"},           //CFP franc
            {"YER","2"},           //Yemeni rial
            {"ZAR","2"},           //South African rand
            {"ZMK","2"},           //Zambian kwacha
            {"ZMW","2"},           //Zambian kwacha
            {"ZWD","2"}            //Zimbabwean dollar
#endregion
        };

        public BarcodeLabel()
        {
            ELNFormatEAN13 = String.IsNullOrEmpty(
                Properties.Settings.Default.ELNFormatEAN13) ? ELNFormatEAN13 : Settings.Default.ELNFormatEAN13;
            ELNFormatCode128 = String.IsNullOrEmpty(
                Properties.Settings.Default.ELNFormatCode128) ? ELNFormatCode128 : Settings.Default.ELNFormatCode128;
            Count = 1;
        }

        public string _Barcode { get; set; }
        public string Barcode
        {
            get { return _Barcode; }
            set
            {
                if (NeedMasing)
                    _Barcode = value.PadLeft(13, '0');
                else _Barcode = value;
                if (Properties.Settings.Default.BarcodeMode == Properties.Resources.AutoEAN13Code128)
                { ELNFormat = IsValidGtin(_Barcode) ? ELNFormatEAN13 : ELNFormatCode128; }
                else
                if (Properties.Settings.Default.BarcodeMode == Properties.Resources.EAN13)
                { ELNFormat = ELNFormatEAN13; }
                else
                if (Properties.Settings.Default.BarcodeMode == Properties.Resources.Code128)
                { ELNFormat = ELNFormatCode128; }
            }
        }

        public bool IsValidGtin(string code)
        {
            try
            {
                if (code != (new Regex("[^0-9]")).Replace(code, ""))
                {
                    // is not numeric
                    return false;
                }
                // pad with zeros to lengthen to 14 digits
                switch (code.Length)
                {
                    case 8:
                        code = "000000" + code;
                        break;
                    case 12:
                        code = "00" + code;
                        break;
                    case 13:
                        code = "0" + code;
                        break;
                    case 14:
                        break;
                    default:
                        // wrong number of digits
                        return false;
                }
                // calculate check digit
                int[] a = new int[13];
                a[0] = int.Parse(code[0].ToString()) * 3;
                a[1] = int.Parse(code[1].ToString());
                a[2] = int.Parse(code[2].ToString()) * 3;
                a[3] = int.Parse(code[3].ToString());
                a[4] = int.Parse(code[4].ToString()) * 3;
                a[5] = int.Parse(code[5].ToString());
                a[6] = int.Parse(code[6].ToString()) * 3;
                a[7] = int.Parse(code[7].ToString());
                a[8] = int.Parse(code[8].ToString()) * 3;
                a[9] = int.Parse(code[9].ToString());
                a[10] = int.Parse(code[10].ToString()) * 3;
                a[11] = int.Parse(code[11].ToString());
                a[12] = int.Parse(code[12].ToString()) * 3;
                int sum = a[0] + a[1] + a[2] + a[3] + a[4] + a[5] + a[6] + a[7] + a[8] + a[9] + a[10] + a[11] + a[12];
                int check = (10 - (sum % 10)) % 10;
                // evaluate check digit
                int last = int.Parse(code[13].ToString());
                return check == last;
            }
            catch (Exception) { return false; }
        }

        public string ItemId { get; set; }
        public string Description { get; set; }
        private string _Currency;
        public string Currency
        {
            get { return _Currency; }
            set
            {
                _Currency = value;
            }
        }
        public decimal PriceWithTax { get; set; }
        private string PriceWithTaxText
        {
            get
            {
                return GetFormatedCurrency(this.Currency, PriceWithTax);
            }
        }
        private string Liscence
        {
            get
            {
                return Properties.Settings.Default.FSSAI;
            }
        }
        public string NumLabels { get; set; }
        public Dictionary<string, string> Formate
        {

            get
            {
                return new Dictionary<string, string>(
                        StringComparer.Ordinal) {
                    {"itemid", ItemId},
                    {"description1", Description.StringWrap(23)[0]},
                    {"description2", Description.Length>23? Description.StringWrap(23)[1]:""},
                    {"barcode", Barcode},
                    {"currency", Currency},
                    {"price", PriceWithTaxText},
                    {"liscence", Liscence},
                    {"packdate", PackingDate},
                    {"expirydate", ExpairyDate},
                    {"count", Count.ToString()}
                };
            }
        }
        public string ELN
        {
            get
            {
                return re.Replace(ELNFormat, match => Formate[match.Groups[1].Value]);
            }
        }

        public int Count { get; internal set; }
        public string PackingDate { get; internal set; }
        public string ExpairyDate { get; internal set; }
        public bool NeedMasing { get; internal set; }

        public static string GetFormatedCurrency(string currancy, decimal value)
        {
            string Format = "F";
            try
            {
                Format = "F" + CurrancyDefaultFormat[currancy];
            }
            catch (KeyNotFoundException) { }
            return value.ToString(Format);
        }

        public static string GetFormat(string currancy)
        {
            string Format = "F";
            try
            {
                Format = "F" + CurrancyDefaultFormat[currancy];
            }
            catch (KeyNotFoundException) { }
            return Format;
        }
    }

    internal static class BarcodeExtentions
    {
        public static List<string> StringWrap(this string input, int length)
        {
            List<string> result = new List<string>();
            string temp = "";
            int tempIndex = 0;
            if (input.Length > length)
            {
                do
                {
                    temp = input.Substring(0, length);
                    tempIndex = temp.LastIndexOf(' ') + 1;
                    try
                    {
                        tempIndex = tempIndex == 0 ? tempIndex = temp.Length : tempIndex;
                        result.Add(temp.Length > tempIndex ? temp.Substring(0, tempIndex) : temp);
                    }
                    catch (Exception) { tempIndex = temp.Length; result.Add(temp); }
                    input = input.Length > length ? input.Substring(tempIndex) : input;
                } while (input.Length > length);
                if (input.Length > 0) result.Add(input);
            }
            else
            {
                result.Add(input);
            }
            return result;
        }
    }

}