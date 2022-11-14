using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FrozenCandy
{
    class Matrix
    {
        int  c, r, High, Width;
        int[,] mat;

        public static int dx, dy;
        
        public int C
        {
            get
            {
                return c;
            }            
        }
        public int R
        {
            get
            {
                return r;
            }            
        }


        
        void Init()
        {
            dx = 0;
            dy = 0;
            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                    mat[i, j] = 0;
        }

        public Matrix()
        {
            r = 0;
            c = 0;
            High = 0;
            Width = 0;
            mat = new int[r, c];
        }
        public Matrix(int x, int y, int h, int w)
        {
            r = x;
            c = y;
            High = h;
            Width = w;
            mat = new int[r, c];
            Init();
        }

        public Matrix(int x, int y, int h, int w, int dx, int dy)
        {
            r = x;
            c = y;
            High = h;
            Width = w;
            mat = new int[r, c];
            Init();
            Move(dx, dy);
        }

        public Matrix(int[,] m, int x, int y, int h, int w)
        {
            int i, j;

            r = x;
            c = y;
            High = h;
            Width = w;
            mat = new int[r, c];

            Move(dx, dy);

            for (i = 0; i < r; i++)
                for (j = 0; j < c; j++)
                    mat[i, j] = m[j, i];
        }

        public Matrix(Matrix mtx)
        {
            int i, j;

            r = mtx.r;
            c = mtx.c;
            High = mtx.High;
            Width = mtx.Width;
            mat = new int[r, c];

            for (i = 0; i < r; i++)
                for (j = 0; j < c; j++)
                    mat[i, j] = mtx.GetValue(i, j) ;
        }


        public Matrix(int[,] m, int x, int y, int h, int w, int dx, int dy)
        {
            int i, j;

            r = x;
            c = y;
            High = h;
            Width = w;
            mat = new int[r, c];

            Move(dx, dy);

            for (i = 0; i < r; i++)
                for (j = 0; j < c; j++)
                    mat[i, j] = m[j, i];
        }

        public int GetValue(int x, int y)
        {
            if (x >= 0 && x < r && y >= 0 && y < c)
                return mat[x, y];
            else
                return -1;
        }

        public void SetValue(int x, int y, int value)
        {
            if (x >= 0 && x < r && y >= 0 && y < c)
                mat[x, y] = value;
        }

        public void Move(int dx, int dy)
        {
            Matrix.dx = dx;
            Matrix.dy = dy;
        }

        public void Draw(Graphics g)
        {
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    switch (mat[i, j])
                    {
                        case 1: g.DrawImage(Resource1.b1, dx + i * High, dy + j * Width, High, Width); break;
                        case 2: g.DrawImage(Resource1.b2, dx + i * High, dy + j * Width, High, Width); break;
                        case 3: g.DrawImage(Resource1.b3, dx + i * High, dy + j * Width, High, Width); break;
                        case 4: g.DrawImage(Resource1.b4, dx + i * High, dy + j * Width, High, Width); break;
                        case 5: g.DrawImage(Resource1.b5, dx + i * High, dy + j * Width, High, Width); break;
                        case 6: g.DrawImage(Resource1.b6, dx + i * High, dy + j * Width, High, Width); break;
                    }
                }
            }
        }
    }
}
