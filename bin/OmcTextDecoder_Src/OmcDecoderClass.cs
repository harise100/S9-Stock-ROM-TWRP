using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmcTextDecoder
{
    public class OmcDecoderClass
    {
        private sbyte[] salts = new sbyte[] { 65, -59, 33, -34, 107, 28, -107, 55, 78, 17, -81, 6, -80, -121, -35, -23, 72, 122, -63, -43, 68, 119, -78, -111, -60, 31, 60, 57, 92, -88, -100, -69, -106, 91, 69, 93, 110, 23, 93, 53, -44, -51, 64, -80, 46, 2, -4, 12, -45, 80, -44, -35, -111, -28, -66, -116, 39, 2, -27, -45, -52, 125, 39, 66, -90, 63, -105, -67, 84, -57, -4, -4, 101, -90, 81, 10, -33, 1, 67, -57, -71, 18, -74, 102, 96, -89, 64, -17, 54, -94, -84, -66, 14, 119, 121, 2, -78, -79, 89, 63, 93, 109, -78, -51, 66, -36, 32, 86, 3, -58, -15, 92, 58, 2, -89, -80, -13, -1, 122, -4, 48, 63, -44, 59, 100, -42, -45, 59, -7, -17, -54, 34, -54, 71, -64, -26, -87, -80, -17, -44, -38, -112, 70, 10, -106, 95, -24, -4, -118, 45, -85, -13, 85, 25, -102, -119, 13, -37, 116, 46, -69, 59, 42, -90, -38, -105, 101, -119, -36, 97, -3, -62, -91, -97, -125, 17, 14, 106, -72, -119, 99, 111, 20, 18, -27, 113, 64, -24, 74, -60, -100, 26, 56, -44, -70, 12, -51, -100, -32, -11, 26, 48, -117, 98, -93, 51, -25, -79, -31, 97, 87, -105, -64, 7, -13, -101, 33, -122, 5, -104, 89, -44, -117, 63, -80, -6, -71, -110, -29, -105, 116, 107, -93, 91, -41, -13, 20, -115, -78, 43, 79, -122, 6, 102, -32, 52, -118, -51, 72, -104, 41, -38, 124, 72, -126, -35 };

        private sbyte[] shifts;

        public OmcDecoderClass()
        {
            sbyte[] bArr = new sbyte[256];
            bArr[0] = 1;
            bArr[1] = 1;
            bArr[3] = 2;
            bArr[4] = 2;
            bArr[5] = 4;
            bArr[6] = 5;
            bArr[8] = 4;
            bArr[9] = 7;
            bArr[10] = 1;
            bArr[11] = 6;
            bArr[12] = 5;
            bArr[13] = 3;
            bArr[14] = 3;
            bArr[15] = 1;
            bArr[16] = 2;
            bArr[17] = 5;
            bArr[19] = 6;
            bArr[20] = 2;
            bArr[21] = 2;
            bArr[22] = 4;
            bArr[23] = 2;
            bArr[24] = 2;
            bArr[25] = 3;
            bArr[27] = 2;
            bArr[28] = 1;
            bArr[29] = 2;
            bArr[30] = 4;
            bArr[31] = 3;
            bArr[32] = 4;
            bArr[36] = 3;
            bArr[37] = 5;
            bArr[38] = 3;
            bArr[39] = 1;
            bArr[40] = 6;
            bArr[41] = 5;
            bArr[42] = 6;
            bArr[43] = 1;
            bArr[44] = 1;
            bArr[45] = 1;
            bArr[48] = 3;
            bArr[49] = 2;
            bArr[50] = 7;
            bArr[51] = 7;
            bArr[52] = 5;
            bArr[53] = 6;
            bArr[54] = 7;
            bArr[55] = 3;
            bArr[56] = 5;
            bArr[57] = 1;
            bArr[59] = 7;
            bArr[60] = 6;
            bArr[61] = 3;
            bArr[62] = 6;
            bArr[63] = 5;
            bArr[64] = 4;
            bArr[65] = 5;
            bArr[66] = 3;
            bArr[67] = 5;
            bArr[68] = 1;
            bArr[69] = 3;
            bArr[70] = 3;
            bArr[71] = 1;
            bArr[72] = 5;
            bArr[73] = 4;
            bArr[74] = 1;
            bArr[77] = 2;
            bArr[78] = 6;
            bArr[79] = 6;
            bArr[80] = 6;
            bArr[81] = 6;
            bArr[82] = 4;
            bArr[84] = 1;
            bArr[85] = 1;
            bArr[87] = 5;
            bArr[88] = 5;
            bArr[89] = 4;
            bArr[90] = 2;
            bArr[91] = 4;
            bArr[92] = 6;
            bArr[93] = 1;
            bArr[94] = 7;
            bArr[95] = 1;
            bArr[96] = 2;
            bArr[97] = 1;
            bArr[98] = 1;
            bArr[99] = 6;
            bArr[100] = 5;
            bArr[101] = 4;
            bArr[102] = 7;
            bArr[103] = 6;
            bArr[104] = 5;
            bArr[105] = 1;
            bArr[106] = 6;
            bArr[107] = 7;
            bArr[109] = 2;
            bArr[110] = 6;
            bArr[111] = 3;
            bArr[112] = 1;
            bArr[113] = 7;
            bArr[114] = 1;
            bArr[115] = 1;
            bArr[116] = 7;
            bArr[117] = 4;
            bArr[119] = 4;
            bArr[120] = 2;
            bArr[121] = 5;
            bArr[122] = 3;
            bArr[123] = 1;
            bArr[124] = 1;
            bArr[125] = 5;
            bArr[126] = 6;
            bArr[128] = 3;
            bArr[129] = 5;
            bArr[130] = 3;
            bArr[131] = 6;
            bArr[132] = 5;
            bArr[133] = 7;
            bArr[134] = 2;
            bArr[135] = 5;
            bArr[136] = 6;
            bArr[137] = 6;
            bArr[138] = 2;
            bArr[139] = 2;
            bArr[140] = 3;
            bArr[141] = 6;
            bArr[143] = 4;
            bArr[144] = 3;
            bArr[145] = 2;
            bArr[147] = 2;
            bArr[148] = 2;
            bArr[149] = 3;
            bArr[150] = 5;
            bArr[151] = 3;
            bArr[152] = 3;
            bArr[153] = 2;
            bArr[154] = 5;
            bArr[155] = 5;
            bArr[156] = 5;
            bArr[157] = 1;
            bArr[158] = 3;
            bArr[159] = 1;
            bArr[160] = 1;
            bArr[161] = 1;
            bArr[162] = 4;
            bArr[163] = 5;
            bArr[164] = 1;
            bArr[165] = 6;
            bArr[166] = 2;
            bArr[167] = 4;
            bArr[168] = 7;
            bArr[169] = 1;
            bArr[170] = 4;
            bArr[171] = 6;
            bArr[173] = 6;
            bArr[174] = 4;
            bArr[175] = 3;
            bArr[176] = 2;
            bArr[177] = 6;
            bArr[178] = 1;
            bArr[179] = 6;
            bArr[180] = 3;
            bArr[181] = 2;
            bArr[182] = 1;
            bArr[183] = 6;
            bArr[184] = 7;
            bArr[185] = 3;
            bArr[186] = 2;
            bArr[187] = 1;
            bArr[188] = 1;
            bArr[189] = 5;
            bArr[190] = 6;
            bArr[191] = 7;
            bArr[192] = 2;
            bArr[193] = 2;
            bArr[194] = 2;
            bArr[195] = 7;
            bArr[196] = 4;
            bArr[197] = 6;
            bArr[198] = 7;
            bArr[199] = 5;
            bArr[200] = 3;
            bArr[201] = 1;
            bArr[202] = 4;
            bArr[203] = 2;
            bArr[204] = 7;
            bArr[205] = 1;
            bArr[206] = 6;
            bArr[207] = 2;
            bArr[208] = 4;
            bArr[209] = 1;
            bArr[210] = 5;
            bArr[211] = 6;
            bArr[212] = 5;
            bArr[213] = 4;
            bArr[214] = 5;
            bArr[216] = 1;
            bArr[217] = 1;
            bArr[218] = 6;
            bArr[219] = 3;
            bArr[220] = 7;
            bArr[221] = 2;
            bArr[223] = 2;
            bArr[224] = 5;
            bArr[226] = 1;
            bArr[227] = 3;
            bArr[228] = 3;
            bArr[229] = 2;
            bArr[230] = 6;
            bArr[231] = 7;
            bArr[232] = 7;
            bArr[233] = 2;
            bArr[234] = 5;
            bArr[235] = 6;
            bArr[237] = 4;
            bArr[238] = 1;
            bArr[239] = 2;
            bArr[240] = 5;
            bArr[241] = 3;
            bArr[242] = 7;
            bArr[243] = 6;
            bArr[244] = 5;
            bArr[245] = 2;
            bArr[246] = 5;
            bArr[247] = 2;
            bArr[249] = 1;
            bArr[250] = 3;
            bArr[251] = 1;
            bArr[252] = 4;
            bArr[253] = 3;
            bArr[254] = 4;
            bArr[255] = 2;
            this.shifts = bArr;
        }

        private byte[] _decode(byte[] source)
        {
            byte[] results = new byte[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                results[i] = (byte)(((source[i] & 255) << this.shifts[i % 256]) | ((source[i] & 255) >> (8 - this.shifts[i % 256])));
                results[i] = (byte)(results[i] ^ this.salts[i % 256]);
            }
            return results;
        }

        private byte[] _encode(byte[] source)
        {
            byte[] results = new byte[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                results[i] = (byte)(source[i] ^ this.salts[i % 256]);
                results[i] = (byte)(((results[i] & 255) >> this.shifts[i % 256]) | ((results[i] & 255) << (8 - this.shifts[i % 256])));
            }
            return results;
        }

        private byte[] _decompressGzip(byte[] sourceGz)
        {
            using (var compressedStream = new MemoryStream(sourceGz))
            using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
            using (var resultStream = new MemoryStream())
            {
                zipStream.CopyTo(resultStream);
                return resultStream.ToArray();
            }
        }

        private byte[] _compressGzip(byte[] data)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(memory,
                    CompressionMode.Compress, true))
                {
                    gzip.Write(data, 0, data.Length);
                }
                return memory.ToArray();
            }
        }

        public byte[] decode(string fileName)
        {
            return _decompressGzip(_decode(File.ReadAllBytes(fileName)));
        }

        public byte[] encode(string fileName)
        {
            return _encode(_compressGzip(File.ReadAllBytes(fileName)));
        }
    }
}