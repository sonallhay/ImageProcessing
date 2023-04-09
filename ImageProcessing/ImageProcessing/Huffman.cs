using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    class Huffman
    {
        public string code = ""; // store 0 or 1
        public int frequency = 0; // store frequency of intensity
        public int intensity;
        public Huffman leftNode = null;
        public Huffman rightNode = null;
        public bool isleaf = true;

        public Huffman(int intensity, int frequency)   
        {
            this.intensity = intensity;
            this.frequency = frequency;
        }
    }
}
