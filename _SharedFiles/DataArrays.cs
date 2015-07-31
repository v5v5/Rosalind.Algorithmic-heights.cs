using System;

namespace _SharedFiles
{

    class DataArrays
    {
        public int _count;
        public int _lenght;
        public int[][] _arrays;

        public DataArrays(string fileName)
        {
            string fileContent = Utils.GetFileContent(fileName);
            string[] integerStrings = fileContent.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            _count = int.Parse(integerStrings[0]);
            _lenght = int.Parse(integerStrings[1]);

            _arrays = new int[_count][];
            for (int i = 0; i < _arrays.Length; i++)
            {
                _arrays[i] = new int[_lenght];
                for (int j = 0; j < _arrays[i].Length; j++)
                {
                    _arrays[i][j] = int.Parse(integerStrings[i * _lenght + j + 2]);
                }
            }
        }


    }
}
