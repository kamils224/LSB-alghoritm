using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POD_Bitmap
{
    class LSBAlghoritmEncrypter
    {

        private byte ConvertBoolArrayToByte(bool[] source)
        {
            byte result = 0;
            int index = 8 - source.Length;

            foreach (bool b in source)
            {
                if (b)
                    result |= (byte)(1 << (7 - index));

                index++;
            }

            return result;
        }



        public byte[] GetHiddenFile(Bitmap bmpFile,int range,bool twoBitsReserved=false)
        {
            if(!twoBitsReserved)
            {
                int bitsCounter = 0;
                int bytesCounter = 0;
                bool[] list = new bool[range * 8];

                for (int i = 0; i < bmpFile.Height; i++)
                {
                    for (int j = 0; j < bmpFile.Width; j++)
                    {
                        Color c = bmpFile.GetPixel(j, i);

                        int res = c.R % 2;
                        int res2 = c.G % 2;
                        int res3 = c.B % 2;

                        if (bitsCounter >= range * 8)
                            break;


                        list[bitsCounter]=(Convert.ToBoolean(res));
                        bitsCounter++;
                        if(bitsCounter%8==0)
                        {
                            bytesCounter++;
                        }
                        if(bitsCounter >= range * 8)
                        {
                            break;
                        }
                        list[bitsCounter] = (Convert.ToBoolean(res2));
                        bitsCounter++;
                        if (bitsCounter % 8 == 0)
                        {
                            bytesCounter++;
                        }
                        if (bitsCounter >= range * 8)
                        {
                            break;
                        }
                        list[bitsCounter] = (Convert.ToBoolean(res3));
                        bitsCounter++;
                        if (bitsCounter % 8 == 0)
                        {
                            bytesCounter++;
                        }
                        if (bitsCounter >= range * 8)
                        {
                            break;
                        }
                    }
                }

                byte[] resultarray = new byte[list.Length/8];

                int arrayCounter = 0;

                for (int i = 0; i < list.Length; i += 8)
                {
                    bool[] tempBool = new bool[8];
                    for (int j = 0; j < 8; j++)
                    {
                        tempBool[j] = list[i + j];
                    }
                    resultarray[arrayCounter] = ConvertBoolArrayToByte(tempBool);
                    arrayCounter++;
                    if (arrayCounter >= range)
                        break;
                }

                return resultarray;
            }else
            {
                int bitsCounter = 0;
                int bytesCounter = 0;
                bool[] list = new bool[range * 8];

                for (int C = 0; C < 2; C++)
                {
                    for (int i = 0; i < bmpFile.Height; i++)
                    {
                        for (int j = 0; j < bmpFile.Width; j++)
                        {
                            Color c = bmpFile.GetPixel(j, i);

                            if(C==1)
                            {
                                if (bitsCounter >= range * 8)
                                    break;


                                var bit1 = (c.R & (1 << 2 - 1)) != 0;
                                var bit2 = (c.G & (1 << 2 - 1)) != 0;
                                var bit3 = (c.B & (1 << 2 - 1)) != 0;



                                list[bitsCounter] =bit1;
                                bitsCounter++;
                                if (bitsCounter % 8 == 0)
                                {
                                    bytesCounter++;
                                }
                                if (bytesCounter >= range)
                                {
                                    break;
                                }
                                list[bitsCounter] = bit2;
                                bitsCounter++;
                                if (bitsCounter % 8 == 0)
                                {
                                    bytesCounter++;
                                }
                                if (bytesCounter >= range)
                                {
                                    break;
                                }
                                list[bitsCounter] = bit3;
                                bitsCounter++;
                                if (bitsCounter % 8 == 0)
                                {
                                    bytesCounter++;
                                }
                                if (bytesCounter >= range)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                if (bitsCounter >= range * 8)
                                    break;


                                int res = c.R % 2;
                                int res2 = c.G % 2;
                                int res3 = c.B % 2;


                                list[bitsCounter] = Convert.ToBoolean(res);
                                bitsCounter++;
                                if (bitsCounter % 8 == 0)
                                {
                                    bytesCounter++;
                                }
                                if (bytesCounter >= range)
                                {
                                    break;
                                }
                                list[bitsCounter] = Convert.ToBoolean(res2);
                                bitsCounter++;
                                if (bitsCounter % 8 == 0)
                                {
                                    bytesCounter++;
                                }
                                if (bytesCounter >= range)
                                {
                                    break;
                                }
                                list[bitsCounter] = Convert.ToBoolean(res3);
                                bitsCounter++;
                                if (bitsCounter % 8 == 0)
                                {
                                    bytesCounter++;
                                }
                                if (bytesCounter >= range)
                                {
                                    break;
                                }
                            }

                        }
                    }
                }

                

                byte[] resultarray = new byte[list.Length / 8];

                int arrayCounter = 0;

                for (int i = 0; i < list.Length; i += 8)
                {
                    bool[] tempBool = new bool[8];
                    for (int j = 0; j < 8; j++)
                    {
                        tempBool[j] = list[i + j];
                    }
                    resultarray[arrayCounter] = ConvertBoolArrayToByte(tempBool);
                    arrayCounter++;
                    if (arrayCounter >= range)
                        break;
                }

                return resultarray;
            }
            
        }

        public byte[] GetHiddenFileColumnMode(Bitmap bmpFile, int range, bool twoBitsReserved = false)
        {
            if (!twoBitsReserved)
            {
                int bitsCounter = 0;
                int bytesCounter = 0;
                bool[] list = new bool[range * 8];

                for (int i = 0; i < bmpFile.Width; i++)
                {
                    for (int j = 0; j < bmpFile.Height; j++)
                    {
                        Color c = bmpFile.GetPixel(i, j);

                        int res = c.R % 2;
                        int res2 = c.G % 2;
                        int res3 = c.B % 2;

                        if (bitsCounter >= range * 8)
                            break;


                        list[bitsCounter] = (Convert.ToBoolean(res));
                        bitsCounter++;
                        if (bitsCounter % 8 == 0)
                        {
                            bytesCounter++;
                        }
                        if (bitsCounter >= range * 8)
                        {
                            break;
                        }
                        list[bitsCounter] = (Convert.ToBoolean(res2));
                        bitsCounter++;
                        if (bitsCounter % 8 == 0)
                        {
                            bytesCounter++;
                        }
                        if (bitsCounter >= range * 8)
                        {
                            break;
                        }
                        list[bitsCounter] = (Convert.ToBoolean(res3));
                        bitsCounter++;
                        if (bitsCounter % 8 == 0)
                        {
                            bytesCounter++;
                        }
                        if (bitsCounter >= range * 8)
                        {
                            break;
                        }
                    }
                }

                byte[] resultarray = new byte[list.Length / 8];

                int arrayCounter = 0;

                for (int i = 0; i < list.Length; i += 8)
                {
                    bool[] tempBool = new bool[8];
                    for (int j = 0; j < 8; j++)
                    {
                        tempBool[j] = list[i + j];
                    }
                    resultarray[arrayCounter] = ConvertBoolArrayToByte(tempBool);
                    arrayCounter++;
                    if (arrayCounter >= range)
                        break;
                }

                return resultarray;
            }
            else
            {
                int bitsCounter = 0;
                int bytesCounter = 0;
                bool[] list = new bool[range * 8];

                for (int C = 0; C < 2; C++)
                {
                    for (int i = 0; i < bmpFile.Width; i++)
                    {
                        for (int j = 0; j < bmpFile.Height; j++)
                        {
                            Color c = bmpFile.GetPixel(i, j);

                            if (C == 1)
                            {
                                if (bitsCounter >= range * 8)
                                    break;


                                var bit1 = (c.R & (1 << 2 - 1)) != 0;
                                var bit2 = (c.G & (1 << 2 - 1)) != 0;
                                var bit3 = (c.B & (1 << 2 - 1)) != 0;



                                list[bitsCounter] = bit1;
                                bitsCounter++;
                                if (bitsCounter % 8 == 0)
                                {
                                    bytesCounter++;
                                }
                                if (bytesCounter >= range)
                                {
                                    break;
                                }
                                list[bitsCounter] = bit2;
                                bitsCounter++;
                                if (bitsCounter % 8 == 0)
                                {
                                    bytesCounter++;
                                }
                                if (bytesCounter >= range)
                                {
                                    break;
                                }
                                list[bitsCounter] = bit3;
                                bitsCounter++;
                                if (bitsCounter % 8 == 0)
                                {
                                    bytesCounter++;
                                }
                                if (bytesCounter >= range)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                if (bitsCounter >= range * 8)
                                    break;


                                int res = c.R % 2;
                                int res2 = c.G % 2;
                                int res3 = c.B % 2;


                                list[bitsCounter] = Convert.ToBoolean(res);
                                bitsCounter++;
                                if (bitsCounter % 8 == 0)
                                {
                                    bytesCounter++;
                                }
                                if (bytesCounter >= range)
                                {
                                    break;
                                }
                                list[bitsCounter] = Convert.ToBoolean(res2);
                                bitsCounter++;
                                if (bitsCounter % 8 == 0)
                                {
                                    bytesCounter++;
                                }
                                if (bytesCounter >= range)
                                {
                                    break;
                                }
                                list[bitsCounter] = Convert.ToBoolean(res3);
                                bitsCounter++;
                                if (bitsCounter % 8 == 0)
                                {
                                    bytesCounter++;
                                }
                                if (bytesCounter >= range)
                                {
                                    break;
                                }
                            }

                        }
                    }
                }



                byte[] resultarray = new byte[list.Length / 8];

                int arrayCounter = 0;

                for (int i = 0; i < list.Length; i += 8)
                {
                    bool[] tempBool = new bool[8];
                    for (int j = 0; j < 8; j++)
                    {
                        tempBool[j] = list[i + j];
                    }
                    resultarray[arrayCounter] = ConvertBoolArrayToByte(tempBool);
                    arrayCounter++;
                    if (arrayCounter >= range)
                        break;
                }

                return resultarray;
            }

        }

        public byte[] GetHiddenFileWithSizeInfo(Bitmap bmpFile, bool twoBitsReserved = false)
        {
            int newI = 0;
            int newJ = 0;

            int range = 0;
            int sizeCounter = 0;

            bool[] listSize = new bool[32];

            for (int i = 0; i < bmpFile.Height; i++)
            {
                for (int j = 0; j < bmpFile.Width; j++)
                {
                    Color c = bmpFile.GetPixel(j, i);

                    int res = c.R % 2;
                    int res2 = c.G % 2;
                    int res3 = c.B % 2;

                    if (sizeCounter >= 32)
                        break;


                    listSize[sizeCounter] = (Convert.ToBoolean(res));
                    sizeCounter++;
                    if (sizeCounter >= 32)
                    {
                        newI = i;
                        newJ = j;
                             break;
                    }
                       

                    listSize[sizeCounter] = (Convert.ToBoolean(res2));
                    sizeCounter++;
                    if (sizeCounter >= 32)
                    {
                        newI = i;
                        newJ = j;
                        break;
                    }


                    listSize[sizeCounter] = (Convert.ToBoolean(res3));
                    sizeCounter++;
                    if (sizeCounter >= 32)
                    {
                        newI = i;
                        newJ = j;
                        break;
                    }

                }
            }
            int arrcnt = 0;
            byte[] bytestoint = new byte[4];
            for (int i = 0; i < listSize.Length; i += 8)
            {
                bool[] tempBool = new bool[8];
                for (int j = 0; j < 8; j++)
                {
                    tempBool[j] = listSize[i + j];
                }
                bytestoint[arrcnt] = ConvertBoolArrayToByte(tempBool);
                arrcnt++;
                if (arrcnt >= 4)
                    break;
            }
            range=BitConverter.ToInt32(bytestoint,0);


            if (!twoBitsReserved)
            {
                int bitsCounter = 0;
                int bytesCounter = 0;
                bool[] list = new bool[range * 8];

                Color ccc = bmpFile.GetPixel(newI, newJ-1);
                int blue = ccc.B%2;

                list[bitsCounter] = Convert.ToBoolean(blue);
                bitsCounter++;

                for (int i = newI; i < bmpFile.Height; i++)
                {
                    for (int j = newJ; j < bmpFile.Width; j++)
                    {
                        Color c = bmpFile.GetPixel(j, i);

                        int res = c.R % 2;
                        int res2 = c.G % 2;
                        int res3 = c.B % 2;

                        if (bitsCounter >= range * 8)
                            break;


                        list[bitsCounter] = (Convert.ToBoolean(res));
                        bitsCounter++;
                        if (bitsCounter % 8 == 0)
                        {
                            bytesCounter++;
                        }
                        if (bytesCounter >= range)
                        {
                            break;
                        }
                        list[bitsCounter] = (Convert.ToBoolean(res2));
                        bitsCounter++;
                        if (bitsCounter % 8 == 0)
                        {
                            bytesCounter++;
                        }
                        if (bytesCounter >= range)
                        {
                            break;
                        }
                        list[bitsCounter] = (Convert.ToBoolean(res3));
                        bitsCounter++;
                        if (bitsCounter % 8 == 0)
                        {
                            bytesCounter++;
                        }
                        if (bytesCounter >= range)
                        {
                            break;
                        }
                    }
                }

                byte[] resultarray = new byte[list.Length / 8];

                int arrayCounter = 0;

                for (int i = 0; i < list.Length; i += 8)
                {
                    bool[] tempBool = new bool[8];
                    for (int j = 0; j < 8; j++)
                    {
                        tempBool[j] = list[i + j];
                    }
                    resultarray[arrayCounter] = ConvertBoolArrayToByte(tempBool);
                    arrayCounter++;
                    if (arrayCounter >= range)
                        break;
                }


                int change = resultarray[resultarray.Length - 1] ^ 1;
                resultarray[resultarray.Length - 1] ^= (byte)change;

                return resultarray;
            }
            else
            {
                int bitsCounter = 0;
                int bytesCounter = 0;
                bool[] list = new bool[range * 8];

                for (int C = 0; C < 2; C++)
                {
                    for (int i = 0; i < bmpFile.Height; i++)
                    {
                        for (int j = 0; j < bmpFile.Width; j++)
                        {
                            Color c = bmpFile.GetPixel(j, i);

                            if (C == 1)
                            {
                                if (bitsCounter >= range * 8)
                                    break;


                                var bit1 = (c.R & (1 << 2 - 1)) != 0;
                                var bit2 = (c.G & (1 << 2 - 1)) != 0;
                                var bit3 = (c.B & (1 << 2 - 1)) != 0;



                                list[bitsCounter] = bit1;
                                bitsCounter++;
                                if (bitsCounter % 8 == 0)
                                {
                                    bytesCounter++;
                                }
                                if (bytesCounter >= range)
                                {
                                    break;
                                }
                                list[bitsCounter] = bit2;
                                bitsCounter++;
                                if (bitsCounter % 8 == 0)
                                {
                                    bytesCounter++;
                                }
                                if (bytesCounter >= range)
                                {
                                    break;
                                }
                                list[bitsCounter] = bit3;
                                bitsCounter++;
                                if (bitsCounter % 8 == 0)
                                {
                                    bytesCounter++;
                                }
                                if (bytesCounter >= range)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                if (bitsCounter >= range * 8)
                                    break;


                                int res = c.R % 2;
                                int res2 = c.G % 2;
                                int res3 = c.B % 2;


                                list[bitsCounter] = Convert.ToBoolean(res);
                                bitsCounter++;
                                if (bitsCounter % 8 == 0)
                                {
                                    bytesCounter++;
                                }
                                if (bytesCounter >= range)
                                {
                                    break;
                                }
                                list[bitsCounter] = Convert.ToBoolean(res2);
                                bitsCounter++;
                                if (bitsCounter % 8 == 0)
                                {
                                    bytesCounter++;
                                }
                                if (bytesCounter >= range)
                                {
                                    break;
                                }
                                list[bitsCounter] = Convert.ToBoolean(res3);
                                bitsCounter++;
                                if (bitsCounter % 8 == 0)
                                {
                                    bytesCounter++;
                                }
                                if (bytesCounter >= range)
                                {
                                    break;
                                }
                            }

                        }
                    }
                }



                byte[] resultarray = new byte[list.Length / 8];

                int arrayCounter = 0;

                for (int i = 0; i < list.Length; i += 8)
                {
                    bool[] tempBool = new bool[8];
                    for (int j = 0; j < 8; j++)
                    {
                        tempBool[j] = list[i + j];
                    }
                    resultarray[arrayCounter] = ConvertBoolArrayToByte(tempBool);
                    arrayCounter++;
                    if (arrayCounter >= range)
                        break;
                }

                int change = resultarray[resultarray.Length - 1] ^ 1;
                resultarray[resultarray.Length - 1] ^= (byte)change;


                return resultarray;
            }

        }

    }
}
