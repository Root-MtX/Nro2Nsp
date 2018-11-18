using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;



namespace MtX.Control
{
    // Makes .nacp from entered information
    public class Nacp
    {
        public string AppName { get; set; }
        public string TitleId { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }

        public void Build()
        { 
            long[] patch_name = { 0x0000, 0x0300, 0x0600, 0x0900, 0x0c00, 0x0f00, 0x1200, 0x1500,
                                  0x1800, 0x1b00, 0x1e00, 0x2100, 0x2400, 0x2700, 0x2a00, 0x2d00 };
            long[] patch_auth = { 0x0200, 0x0500, 0x0800, 0x0b00, 0x0e00, 0x1100, 0x1400, 0x1700,
                                  0x1a00, 0x1d00, 0x2000, 0x2300, 0x2600, 0x2900, 0x2c00, 0x2f00 };
            long[] patch_id =   { 0x3038, 0x3070, 0x3078, 0x30b0, 0x30b8, 0x30f8 };

            byte[] name_bytes = Encoding.ASCII.GetBytes(AppName);
            byte[] author_bytes = Encoding.ASCII.GetBytes(Author);
            byte[] version_bytes = Encoding.ASCII.GetBytes(Version);
            List<byte> fill0 = new List<byte>();
            List<byte> fillf = new List<byte>();
            for (int i = 0; i <= 0x3FFF; i++) fill0.Add(0);
            for (int i = 0; i < 32; i++) fillf.Add(0xff);
            File.WriteAllBytes(MtX.Control.DircControl.buildpath + MtX.Control.DircControl.controlpath + @"/control.nacp", fill0.ToArray());

            char[] idArray = TitleId.ToCharArray();
            char[] Arraydi = { idArray[14], idArray[15], idArray[12], idArray[13], idArray[10], idArray[11], idArray[8], idArray[9],
                               idArray[6], idArray[7], idArray[4], idArray[5], idArray[2], idArray[3], idArray[0], idArray[1] };
            string ProperId = new string(Arraydi);
             
            if (ProperId.Length % 2 != 0)
            { 
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", ProperId));
            }

            byte[] id_data = new byte[ProperId.Length / 2];
            for (int index = 0; index < id_data.Length; index++)
            {
                string byteValue = ProperId.Substring(index * 2, 2);
                id_data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            } 
            BinaryWriter bw = new BinaryWriter(
            File.Open(MtX.Control.DircControl.buildpath + MtX.Control.DircControl.controlpath + @"/control.nacp", (System.IO.FileMode)FileAccess.ReadWrite));
            for (int i = 0; i < patch_name.Length; i++)
            {
                bw.BaseStream.Seek(patch_name[i], SeekOrigin.Begin);
                bw.Write(name_bytes);
                bw.BaseStream.Seek(patch_auth[i], SeekOrigin.Begin);
                bw.Write(author_bytes);
            }
            for (int x = 0; x < patch_id.Length; x++ )
            {
                    bw.BaseStream.Seek(patch_id[x], SeekOrigin.Begin);
                    bw.Write(id_data);
            }
            bw.BaseStream.Seek(0x3040, SeekOrigin.Begin);
            bw.Write(fillf.ToArray());
            bw.BaseStream.Seek(0x3060, SeekOrigin.Begin);
            bw.Write(version_bytes);
            bw.Close();
        }
    }
}
