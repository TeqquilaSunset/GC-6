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

namespace GC_6
{
    public partial class Form1 : Form
    {
        //координаты кубика
        readonly float[] cube = { 0,0,0, 0,1,0, 1,1,0, 1,0,0, 0,0,1, 0,1,1, 1,1,1, 1,0,1 };
        //соединение точек кубика
        readonly uint[] index = {0,1,2,3, 0,1,5,4, 4,5,6,7, 2,3,7,6, 1,2,6,5, 0,3,7,4, 1,5, 0,4, 3,7, 2,6 };
        //readonly uint[] index = {1,0,2,3, 1,0,5,4, 5,4,6,7, 6,7,2,3, 1,2,5,6, 0,3,4,7};
        //цвета для каждой точки
        readonly float[] colors = {1,0,0.7f, 1,0,0, 1,0,0, 1,0.75f,0, 0,1,0, 0.5f,0,1, 0,1,0, 1,0.5f,1,};
        //флаг запуска таймера 
        bool flag = false;
        public Form1()
        {
            InitializeComponent();
            holst.InitializeContexts();
            //прозрачность
            //Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            //Gl.glEnable(Gl.GL_BLEND);

            //буфер глубины для отсичения
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            //начальное и конечное значение для осей
            //Gl.glOrtho(-2, 2, -2, 2, -2, 2);
            Gl.glFrustum(-2, 2, -2, 2, 2, 20);

            Gl.glViewport(0, 0, holst.Width, holst.Height);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glTranslated(0, 0, -4);
            Draw();
            holst.Invalidate();
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
            Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY); //используем массив вершин
            //Gl.glEnableClientState(Gl.GL_COLOR_ARRAY);

            Gl.glVertexPointer(3, Gl.GL_FLOAT, 0, cube); //в качестве массива вершин используем
            Gl.glColorPointer(3, Gl.GL_FLOAT, 0, colors);
            Gl.glTranslated(-0.5, -0.5, 0);
            // массив вершин строится по индексам
            Gl.glColor3f(0.8f, 0.8f, 0.8f);
            Gl.glDrawArrays(Gl.GL_QUADS, 0, 4);
            Gl.glColor3f(1, 1, 1);
            Gl.glDrawElements(Gl.GL_QUADS, 24, Gl.GL_UNSIGNED_INT, index);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(4);
            Gl.glDrawElements(Gl.GL_LINES, 32, Gl.GL_UNSIGNED_INT, index);


            Gl.glPopMatrix();
            Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);
            //Gl.glDisableClientState(Gl.GL_COLOR_ARRAY);

            holst.Invalidate();
        }

        private void Rotate(float x, float y, float z)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glClear(Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glRotatef(2, x, y, z);
            Draw();
        }

        private void Translate(float z)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glClear(Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glTranslated(0, 0, z);
            Draw();
        }

        private void holst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
            if (e.KeyCode == Keys.Q)
            {
                Rotate(1f, 0, 0);
            }
            if (e.KeyCode == Keys.E)
            {
                Rotate(-1f, 0, 0);
            }
            if (e.KeyCode == Keys.W)
            {
                Rotate(0, 1f, 0);
            }
            if (e.KeyCode == Keys.S)
            {
                Rotate(0, -1f, 0);
            }
            if (e.KeyCode == Keys.A)
            {
                Rotate(0, 0, 1f);
            }
            if (e.KeyCode == Keys.D)
            {
                Rotate(0, 0, -1f);
            }
            if (e.KeyCode == Keys.Z)
            {
                Translate(-0.2f);
            }
            if (e.KeyCode == Keys.X)
            {
                Translate(0.2f);
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
            Rotate(1,0,0);
        }
    }
}
