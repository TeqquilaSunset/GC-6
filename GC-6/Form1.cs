using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;
using static System.Windows.Forms.AxHost;

namespace GC_6
{
    public partial class Form1 : Form
    {
        //координаты кубика
        readonly float[] cube = { 0,0,0, 0,1,0, 1,1,0, 1,0,0, 0,0,1, 0,1,1, 1,1,1, 1,0,1 };
        //соединение точек кубика
        readonly uint[] index = {0,1,2,3, 0,1,5,4, 4,5,6,7, 2,3,7,6, 1,2,6,5, 0,3,7,4, 1,5, 0,4, 3,7, 2,6 };

        //цвета для каждой точки
        readonly float[] colors = {1,0,0, 1,0,0, 1,0,0, 0,0,0, 0,0,0, 0,0,0,};

        readonly uint[] indexPyramid1 = { 0,1,2,3,4 };
        // костыль для разных цветов
        readonly uint[] indexPyramid2 = { 0,1,5 };
        readonly uint[] indexPyramid3 = { 1,2,5 };
        readonly uint[] indexPyramid4 = { 2,3,5 };
        readonly uint[] indexPyramid5 = { 3,4,5 };
        readonly uint[] indexPyramid6 = { 4,0,5 };

        //флаг запуска таймера 
        bool flag = false;

        float anglc = 0;
        float anglp = 0;
        public Form1()
        {
            InitializeComponent();
            holst.InitializeContexts();
            //прозрачность
            //Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            //Gl.glEnable(Gl.GL_BLEND);

            //буфер глубины для отсечения
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            //начальное и конечное значение для осей
            Gl.glOrtho(-2, 2, -2, 2, -2, 2);

            Gl.glViewport(0, 0, holst.Width, holst.Height);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Draw();
            holst.Invalidate();
        }

        private float[] Polygon(int n, float r)
        {
            float[] array = new float[18];
            int angel = 360 / (n * 2);

            for (int i = 0; i < n*3; i+=3)
            {
                array[i] = r * (float)Math.Cos((angel * Math.PI) / 180);
                array[i+1] = r * (float)Math.Sin((angel * Math.PI) / 180);
                array[i+2] = 0;
                angel += 360 / n;
            }
            //array[17] = 0.75f;
            array[17] = 0.5f;
            return array;
        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            Draw();
        }

        private void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glClear(Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glPushMatrix();
            DrawCube();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            DrawPyramid();
            Gl.glPopMatrix();
        }

        private void DrawCube()
        {
            Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY); //используем массив вершин
            Gl.glVertexPointer(3, Gl.GL_FLOAT, 0, cube); //в качестве массива вершин используем
            Gl.glTranslated(-0.5, -0.5, 0);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(4);
            Gl.glRotatef(anglc, 1, 1, 1);
            Gl.glDrawElements(Gl.GL_LINES, 32, Gl.GL_UNSIGNED_INT, index);
            Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);

            holst.Invalidate();
        }

        private void DrawPyramid()
        {
            Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glVertexPointer(3, Gl.GL_FLOAT, 0, Polygon(5, 0.45f));
            Gl.glRotatef(-90, 1, 0, 0);
            Gl.glTranslatef(0, -0.5f, -0.20f);
            Gl.glRotatef(anglp, -1, 0, 0);
            Gl.glColor3f(1, 0, 1);
            Gl.glDrawElements(Gl.GL_POLYGON, 5, Gl.GL_UNSIGNED_INT, indexPyramid1);


            Gl.glColor3f(1, 0, 0);
            Gl.glDrawElements(Gl.GL_TRIANGLES, 3, Gl.GL_UNSIGNED_INT, indexPyramid2);
            Gl.glColor3f(0, 1, 0);
            Gl.glDrawElements(Gl.GL_TRIANGLES, 3, Gl.GL_UNSIGNED_INT, indexPyramid3);
            Gl.glColor3f(0, 0, 1);
            Gl.glDrawElements(Gl.GL_TRIANGLES, 3, Gl.GL_UNSIGNED_INT, indexPyramid4);
            Gl.glColor3f(0.5f, 0, 0.75f);
            Gl.glDrawElements(Gl.GL_TRIANGLES, 3, Gl.GL_UNSIGNED_INT, indexPyramid5);
            Gl.glColor3f(0, 0.6f, 1);
            Gl.glDrawElements(Gl.GL_TRIANGLES, 3, Gl.GL_UNSIGNED_INT, indexPyramid6);

            Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);

            holst.Invalidate();
        }

        private void holst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
            if (e.KeyCode == Keys.Q)
            {
                Draw();
            }
            if (e.KeyCode == Keys.E)
            {
                Draw();
            }
            if (e.KeyCode == Keys.W)
            {
                Draw();
            }
            if (e.KeyCode == Keys.S)
            {
                Draw();
            }
            if (e.KeyCode == Keys.A)
            {
                Draw();
            }
            if (e.KeyCode == Keys.D)
            {
                Draw();
            }
            if (e.KeyCode == Keys.Space)
            {
                if (flag == true)
                {
                    flag = false;
                    timer1.Stop();
                }
                else if (flag == false)
                {
                    flag = true;
                    timer1.Start();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            anglc++;
            anglp += 2;
            Draw();
        }
    }
}
