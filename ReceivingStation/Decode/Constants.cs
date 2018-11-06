namespace ReceivingStation.Decode
{
    class Constants
    {
        public const int WDT = 1568; // Ширина рисунка.
        public const int HGT = 400; // Высота рисунка. (50 строчек)

        public const int DL_JPEG = 1000; // Длина буфера jpeg с запасом - полос + на шапку.
        public const int DL_VIDEO = 896; // Длина видеобуфера.

        public const int DL_IN_BUF = 32768; // Длина входного буфера, должно делиться на 2048.

        public const int DL_INTRL_BUF = 2654208; // Длина буфера интерл. в битах 2048*36*36.

        public const int DL_IN_VIT_BUF = 16384; // Длина входного буф.для Витерби 2048 байт.
        public const int DL_VIT_BUF = 1024; // Длина буфера после Витарби, должно делиться на 1024.

        public static byte[] zag_tk_bit = { 
            0, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0, 0, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1,
            1, 1, 0, 1 };  // транспортный заголовок в битах

        //Константы по транспортному кадру
        public const int NOM_VER = 1; //2 бита - номер версии структуры пакета по CCSDS
        public const int IDENT_KA = 0; //8 бит - идент. КА     
        public const int KADR_INFO = 5; //6 бит - идент. информац. кадра
        public const int KADR_LOOSE = 63; //6 бит - идент. холостого кадра

        //Константы по парц. пакетам
        public const int APID_1 = 64;	//АПИД 1-го канала
        public const int APID_6 = 69;	//АПИД 6-го канала
        public const int APID_c = 70;	//АПИД служебного пакета
        public const int DELTA_T = 1;   //временная разница между полосами
        public const int MAX_MSU = 182;	//макс. номер МСУ
        public const int MAX_Q = 100; //макс. коэф. качества

        public const int slugLength = 112; //Байт на служебную информацию.

        public static byte[] psp = { 2, 24, 167, 163, 146, 221, 154, 191 }; //ПСП - начало кадра БРЛК

        public const int KOL_OUT_BUF = WDT * 16 + slugLength;   // Длина выходного буфера.   
   
        public const int PMEM = 128;
    }
}
