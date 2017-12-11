using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Collections;

namespace POD_Bitmap
{
    class LSBAlghoritm
    {
        private Bitmap bmp;
        public int Width{ get; private set; }
        public int Height { get; private set; }
        private Int64 MaxSizeToHide;
        
        public LSBAlghoritm(string path)
        {
            bmp = new Bitmap(path);
            Width = bmp.Width;
            Height = bmp.Height;

            
        }

        public LSBAlghoritm(Bitmap bmpFile)
        {
            bmp = bmpFile;
            Width = bmp.Width;
            Height = bmp.Height;


        }



        public Bitmap HideMessage(byte[] message,bool twoBitsReserved=false)
        {
            if(!twoBitsReserved)
                MaxSizeToHide = Height * Width * 3;
            else
                MaxSizeToHide = Height * Width * 3*2;

            int messageLengthInBits = message.Length * 8;

            if (messageLengthInBits > MaxSizeToHide)
            {
                throw new ArgumentException("Message is too long.");
            }

            if(!twoBitsReserved)
            {
                int byteCounter = 0;
                int bitsCounter = 0;


                int mask0 = int.MaxValue - 1;
                int mask1 = 1;

                {
                    for (int i = 0; i < Height; i++)
                    {
                        for (int j = 0; j < Width; j++)
                        {
                            var c = bmp.GetPixel(j, i);

                            int R = c.R;
                            int G = c.G;
                            int B = c.B;

                            if (byteCounter >= message.Length)
                            {
                                bmp.SetPixel(j, i, Color.FromArgb(R, G, B));
                                break;
                            }
                                
                            string s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');

                            if (s[bitsCounter] == '1')
                            {
                                R |= mask1;
                            }
                            else
                            {
                                R &= mask0;
                            }
                            bitsCounter++;
                            if (bitsCounter >= 8)
                            {
                                bitsCounter = 0;
                                byteCounter++;
                                if (byteCounter >= message.Length)
                                {
                                    bmp.SetPixel(j, i, Color.FromArgb(R, G, B));
                                    break;
                                }
                                s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');
                            }
                            if (s[bitsCounter] == '1')
                            {
                                G |= mask1;
                            }
                            else
                            {
                                G &= mask0;
                            }
                            bitsCounter++;
                            if (bitsCounter >= 8)
                            {
                                bitsCounter = 0;
                                byteCounter++;
                                if (byteCounter >= message.Length)
                                {
                                    bmp.SetPixel(j, i, Color.FromArgb(R, G, B));
                                    break;
                                }
                                s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');
                            }
                            if (s[bitsCounter] == '1')
                            {
                                B |= mask1;
                            }
                            else
                            {
                                B &= mask0;
                            }
                            bitsCounter++;
                            if (bitsCounter >= 8)
                            {
                                bitsCounter = 0;
                                byteCounter++;
                                if (byteCounter >= message.Length)
                                    break;
                                s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');
                            }

                            bmp.SetPixel(j, i, Color.FromArgb(R, G, B));

                        }
                    }



                }


                return bmp;
            }else
            {
                int byteCounter = 0;
                int bitsCounter = 0;


                for (int C = 0; C < 2; C++)
                {
                    int mask0 = int.MaxValue - 1;
                    int mask1 = 1;

                    if (C == 1)
                    {
                        mask0 = int.MaxValue - 2;
                        mask1 = 2;
                    }

                        for (int i = 0; i < Height; i++)
                        {
                            for (int j = 0; j < Width; j++)
                            {
                                var c = bmp.GetPixel(j, i);

                                int R = c.R;
                                int G = c.G;
                                int B = c.B;


                            if (byteCounter >= message.Length)
                            {
                                bmp.SetPixel(j, i, Color.FromArgb(R, G, B));
                                break;
                            }


                            string s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');

                                if (s[bitsCounter] == '1')
                                {
                                    R |= mask1;
                                }
                                else
                                {
                                    R &= mask0;
                                }
                            bitsCounter++;
                            if (bitsCounter >= 8)
                            {
                                bitsCounter = 0;
                                byteCounter++;
                                if (byteCounter >= message.Length)
                                {
                                    bmp.SetPixel(j, i, Color.FromArgb(R, G, B));
                                    break;
                                }
                                s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');
                            }
                                if (s[bitsCounter] == '1')
                                {
                                    G |= mask1;
                                }
                                else
                                {
                                    G &= mask0;
                                }
                            bitsCounter++;
                            if (bitsCounter >= 8)
                            {
                                bitsCounter = 0;
                                byteCounter++;
                                if (byteCounter >= message.Length)
                                {
                                    bmp.SetPixel(j, i, Color.FromArgb(R, G, B));
                                    break;
                                }
                                s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');
                            }
                            if (s[bitsCounter] == '1')
                                {
                                    B |= mask1;
                                }
                                else
                                {
                                    B &= mask0;
                                }
                            bitsCounter++;
                            if (bitsCounter >= 8)
                            {
                                bitsCounter = 0;
                                byteCounter++;
                                if (byteCounter >= message.Length)
                                {
                                    bmp.SetPixel(j, i, Color.FromArgb(R, G, B));
                                    break;
                                }
                                s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');
                            }

                            bmp.SetPixel(j, i, Color.FromArgb(R, G, B));

                            }
                        }

                }

                return bmp;
            }

            
        }

        public Bitmap HideMessageColumnMode(byte[] message, bool twoBitsReserved = false)
        {
            if (!twoBitsReserved)
                MaxSizeToHide = Height * Width * 3;
            else
                MaxSizeToHide = Height * Width * 3 * 2;

            int messageLengthInBits = message.Length * 8;

            if (messageLengthInBits > MaxSizeToHide)
            {
                throw new ArgumentException("Message is too long.");
            }

            if (!twoBitsReserved)
            {
                int byteCounter = 0;
                int bitsCounter = 0;


                int mask0 = int.MaxValue - 1;
                int mask1 = 1;

                {
                    for (int i = 0; i < Width; i++)
                    {
                        for (int j = 0; j < Height; j++)
                        {
                            var c = bmp.GetPixel(i, j);

                            int R = c.R;
                            int G = c.G;
                            int B = c.B;

                            if (byteCounter >= message.Length)
                            {
                                bmp.SetPixel(i, j, Color.FromArgb(R, G, B));
                                break;
                            }

                            string s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');

                            if (s[bitsCounter] == '1')
                            {
                                R |= mask1;
                            }
                            else
                            {
                                R &= mask0;
                            }
                            bitsCounter++;
                            if (bitsCounter >= 8)
                            {
                                bitsCounter = 0;
                                byteCounter++;
                                if (byteCounter >= message.Length)
                                {
                                    bmp.SetPixel(i, j, Color.FromArgb(R, G, B));
                                    break;
                                }
                                s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');
                            }
                            if (s[bitsCounter] == '1')
                            {
                                G |= mask1;
                            }
                            else
                            {
                                G &= mask0;
                            }
                            bitsCounter++;
                            if (bitsCounter >= 8)
                            {
                                bitsCounter = 0;
                                byteCounter++;
                                if (byteCounter >= message.Length)
                                {
                                    bmp.SetPixel(i, j, Color.FromArgb(R, G, B));
                                    break;
                                }
                                s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');
                            }
                            if (s[bitsCounter] == '1')
                            {
                                B |= mask1;
                            }
                            else
                            {
                                B &= mask0;
                            }
                            bitsCounter++;
                            if (bitsCounter >= 8)
                            {
                                bitsCounter = 0;
                                byteCounter++;
                                if (byteCounter >= message.Length)
                                    break;
                                s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');
                            }

                            bmp.SetPixel(i, j, Color.FromArgb(R, G, B));

                        }
                    }



                }


                return bmp;
            }
            else
            {
                int byteCounter = 0;
                int bitsCounter = 0;


                for (int C = 0; C < 2; C++)
                {
                    int mask0 = int.MaxValue - 1;
                    int mask1 = 1;

                    if (C == 1)
                    {
                        mask0 = int.MaxValue - 2;
                        mask1 = 2;
                    }

                    try
                    {
                        for (int i = 0; i < Width; i++)
                        {
                            for (int j = 0; j < Height; j++)
                            {
                                var c = bmp.GetPixel(i, j);

                                int R = c.R;
                                int G = c.G;
                                int B = c.B;

                                string s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');

                                if (s[bitsCounter] == '1')
                                {
                                    R |= mask1;
                                }
                                else
                                {
                                    R &= mask0;
                                }
                                bitsCounter++;
                                if (bitsCounter >= 8)
                                {
                                    bitsCounter = 0;
                                    byteCounter++;
                                    if (byteCounter >= message.Length)
                                        break;
                                    s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');
                                }
                                if (s[bitsCounter] == '1')
                                {
                                    G |= mask1;
                                }
                                else
                                {
                                    G &= mask0;
                                }
                                bitsCounter++;
                                if (bitsCounter >= 8)
                                {
                                    bitsCounter = 0;
                                    byteCounter++;
                                    if (byteCounter >= message.Length)
                                        break;
                                    s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');
                                }
                                if (s[bitsCounter] == '1')
                                {
                                    B |= mask1;
                                }
                                else
                                {
                                    B &= mask0;
                                }
                                bitsCounter++;
                                if (bitsCounter >= 8)
                                {
                                    bitsCounter = 0;
                                    byteCounter++;
                                    if (byteCounter >= message.Length)
                                        break;
                                    s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');
                                }

                                bmp.SetPixel(i, j, Color.FromArgb(R, G, B));

                            }
                        }
                    }

                    catch (IndexOutOfRangeException)
                    {
                        return bmp;
                    }
                }

                return bmp;
            }


        }

        public Bitmap HideMessageWithSizeInfo(byte[] message, bool twoBitsReserved = false)
        {
            if (!twoBitsReserved)
                MaxSizeToHide = Height * Width * 3;
            else
                MaxSizeToHide = Height * Width * 3 * 2;

            int messageLengthInBits = message.Length * 8+32;

            int messageSize = message.Length;

            if (messageLengthInBits > MaxSizeToHide)
            {
                throw new ArgumentException("Message is too long.");
            }

            int sizeCounter = 0;

            int newI = 0;
            int newJ = 0;


            int Smask0 = int.MaxValue - 1;
            int Smask1 = 1;

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    var c = bmp.GetPixel(j, i);

                    int R = c.R;
                    int G = c.G;
                    int B = c.B;

                    string s = Convert.ToString(messageSize, 2).PadLeft(8, '0');

                    if (s[sizeCounter] == '1')
                    {
                        R |= Smask1;
                    }
                    else
                    {
                        R &= Smask0;
                    }
                    sizeCounter++;
                    if(sizeCounter>=32)
                    {
                        newI = i;
                        newJ = j;
                        break;
                    }

                    if (s[sizeCounter] == '1')
                    {
                        G |= Smask1;
                    }
                    else
                    {
                        G &= Smask0;
                    }
                    sizeCounter++;
                    if (sizeCounter >= 32)
                    {
                        newI = i;
                        newJ = j;
                        break;
                    }
                    
                    if (s[sizeCounter] == '1')
                    {
                        B |= Smask1;
                    }
                    else
                    {
                        B &= Smask0;
                    }
                    sizeCounter++;
                    if (sizeCounter >= 32)
                    {
                        newI = i;
                        newJ = j;
                        break;
                    }
                    

                    bmp.SetPixel(j, i, Color.FromArgb(R, G, B));
                }
            }




            if (!twoBitsReserved)
            {
                int byteCounter = 0;
                int bitsCounter = 0;

                int mask0 = int.MaxValue - 1;
                int mask1 = 1;
                
                string temp = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');
                var tempc = bmp.GetPixel(newI, newJ-1);
                int tempB = tempc.B;
                if (temp[bitsCounter] == '1')
                {
                    tempB |= mask1;
                }
                else
                {
                    tempB &= mask0;
                }
                bitsCounter++;

                bmp.SetPixel(newI,newJ-1,Color.FromArgb(tempc.R, tempc.G, tempB));

                try
                {
                    for (int i = newI; i < Height; i++)
                    {
                        for (int j = newJ; j < Width; j++)
                        {
                            var c = bmp.GetPixel(j, i);

                            int R = c.R;
                            int G = c.G;
                            int B = c.B;

                            string s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');

                            if (s[bitsCounter] == '1')
                            {
                                R |= mask1;
                            }
                            else
                            {
                                R &= mask0;
                            }
                            bitsCounter++;
                            if (bitsCounter >= 8)
                            {
                                bitsCounter = 0;
                                byteCounter++;
                                s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');
                            }
                            if (s[bitsCounter] == '1')
                            {
                                G |= mask1;
                            }
                            else
                            {
                                G &= mask0;
                            }
                            bitsCounter++;
                            if (bitsCounter >= 8)
                            {
                                bitsCounter = 0;
                                byteCounter++;
                                s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');
                            }
                            if (s[bitsCounter] == '1')
                            {
                                B |= mask1;
                            }
                            else
                            {
                                B &= mask0;
                            }
                            bitsCounter++;
                            if (bitsCounter >= 8)
                            {
                                bitsCounter = 0;
                                byteCounter++;
                                s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');
                            }

                            bmp.SetPixel(j, i, Color.FromArgb(R, G, B));

                        }
                    }



                }
                catch (IndexOutOfRangeException)
                {
                    return bmp;
                }


                return bmp;
            }
            else
            {
                int byteCounter = 0;
                int bitsCounter = 0;


                for (int C = 0; C < 2; C++)
                {
                    int mask0 = int.MaxValue - 1;
                    int mask1 = 1;

                    if (C == 1)
                    {
                        mask0 = int.MaxValue - 2;
                        mask1 = 2;
                    }

                    try
                    {
                        for (int i = 0; i < Height; i++)
                        {
                            for (int j = 0; j < Width; j++)
                            {
                                var c = bmp.GetPixel(j, i);

                                int R = c.R;
                                int G = c.G;
                                int B = c.B;

                                string s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');

                                if (s[bitsCounter] == '1')
                                {
                                    R |= mask1;
                                }
                                else
                                {
                                    R &= mask0;
                                }
                                bitsCounter++;
                                if (bitsCounter >= 8)
                                {
                                    bitsCounter = 0;
                                    byteCounter++;
                                    s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');
                                }
                                if (s[bitsCounter] == '1')
                                {
                                    G |= mask1;
                                }
                                else
                                {
                                    G &= mask0;
                                }
                                bitsCounter++;
                                if (bitsCounter >= 8)
                                {
                                    bitsCounter = 0;
                                    byteCounter++;
                                    s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');
                                }
                                if (s[bitsCounter] == '1')
                                {
                                    B |= mask1;
                                }
                                else
                                {
                                    B &= mask0;
                                }
                                bitsCounter++;
                                if (bitsCounter >= 8)
                                {
                                    bitsCounter = 0;
                                    byteCounter++;
                                    s = Convert.ToString(message[byteCounter], 2).PadLeft(8, '0');
                                }

                                bmp.SetPixel(j, i, Color.FromArgb(R, G, B));

                            }
                        }
                    }

                    catch (IndexOutOfRangeException)
                    {
                        return bmp;
                    }
                }

                return bmp;
            }


        }

    }
}
