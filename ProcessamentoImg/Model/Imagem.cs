using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessamentoImg.Model
{
    class Imagem
    {
        public int width;
        public int height;
        public int maxVal;
        public int[][] pixels;


        public Imagem(int width, int height, int maxVal, int[][] pixels)
        {
            this.width = width;
            this.height = height;
            this.maxVal = maxVal;
            this.pixels = new int[width][];
            for (int i = 0; i < width; i++)
            {
                this.pixels[i] = new int[height];
                for (int j = 0; j < height; j++)
                {
                    this.pixels[i][j] = pixels[i][j];
                }
            }

        }
    }
}
