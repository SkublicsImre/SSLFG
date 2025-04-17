using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractal_rendering
{

    private double[,] RenderFrame(double[,] frameArray)
    {
       
        //Planning for 3 rendering modes 0, 3, 4
        //grayscale, RGB, and RGBA respectively

        int frameWidth = frameArray.GetLength(0);
        int frameHeigth = frameArray.GetLength(1);
        int renderMode = frameArray.GetLength(2); //0, 3, 4

        double pixel = 0.0;
        double fMax = Double.MinValue;
        double fMin = Double.MaxValue;

        //normalise frameArray
        switch (renderMode)
        {
            case 0:

                //normalise to 0-gscale lenght for grayscale display  
                for(int i = 0; i < frameWidth; i++)
                {
                    for (int j = 0; j < frameHeigth; j++)
                    {
                        if (fMax>frameArray[i, j])
                        {
                            fMax = frameArray[i, j];
                        }

                        if (fMin > frameArray[i, j])
                        {
                            fMin = frameArray[i, j];
                        }
                    }
                }
                for (int i = 0; i < frameWidth; i++)
                {
                    for (int j = 0; j < frameHeigth; j++)
                    {
                        pixel = (frameArray[i, j] - fMin) / (fMax - fMin);
                        frameArray[i, j] = pixel; //*Grayscale lenght;
                    }
                }

                break;
            case 3:

                //normalise RGB channels separately, and apply gain
                for (int i = 0; i < frameWidth; i++)
                {
                    for (int j = 0; j < frameHeigth; j++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            if (fMax > frameArray[i, j, c])
                            {
                                fMax = frameArray[i, j, c];
                            }
                            if (fMin > frameArray[i, j, c])
                            {
                                fMin = frameArray[i, j, c];
                            }
                        }
                    }
                }


                break;
        }

        return frameArray;

    }

}
