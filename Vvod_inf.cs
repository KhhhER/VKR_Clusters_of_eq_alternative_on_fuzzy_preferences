using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
    public partial class Vvod_inf : Form
    {
        List<double[][]> Matrix;

        TextBox[] level3;
        TextBox[] level4;
        TextBox[] level5;
        TextBox[] level6;
        TextBox[] level7;

        TextBox[][] str;

        public Vvod_inf()
        {
            InitializeComponent();

            level3 = new[]{ num13, num23, num33, num32, num31 };
            level4 = new[]{ num14, num24, num34, num44, num41, num42, num43 };
            level5 = new[]{ num15, num25, num35, num45, num55, num51, num52, num53, num54 };
            level6 = new[]{ num16, num26, num36, num46, num56, num66, num61, num62, num63, num64, num65 };
            level7 = new[]{ num17, num27, num37, num47, num57, num67, num77, num71, num72, num73, num74, num75, num76 };

            str = new TextBox[7][];
            str[0] = new[] { num11, num12, num13, num14, num15, num16, num17 };
            str[1] = new[] { num21, num22, num23, num24, num25, num26, num27 };
            str[2] = new[] { num31, num32, num33, num34, num35, num36, num37 };
            str[3] = new[] { num41, num42, num43, num44, num45, num46, num47 };
            str[4] = new[] { num51, num52, num53, num54, num55, num56, num57 };
            str[5] = new[] { num61, num62, num63, num64, num65, num66, num67 };
            str[6] = new[] { num71, num72, num73, num74, num75, num76, num77 };

            Matrix = new List<double[][]>();
        }

        private void Vvod_inf_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            switch (numericUpDown1.Value)
            {
                case 2:
                    foreach (TextBox num in level3)
                        visible_false(num);
                    foreach (TextBox num in level4)
                        visible_false(num);
                    foreach (TextBox num in level5)
                        visible_false(num);
                    foreach (TextBox num in level6)
                        visible_false(num);
                    foreach (TextBox num in level7)
                        visible_false(num);
                    break;
                case 3:
                    foreach (TextBox num in level3)
                        visible_true(num);
                    foreach (TextBox num in level4)
                        visible_false(num);
                    foreach (TextBox num in level5)
                        visible_false(num);
                    foreach (TextBox num in level6)
                        visible_false(num);
                    foreach (TextBox num in level7)
                        visible_false(num);
                    break;
                case 4:
                    foreach (TextBox num in level3)
                        visible_true(num);
                    foreach (TextBox num in level4)
                        visible_true(num);
                    foreach (TextBox num in level5)
                        visible_false(num);
                    foreach (TextBox num in level6)
                        visible_false(num);
                    foreach (TextBox num in level7)
                        visible_false(num);
                    break;
                case 5:
                    foreach (TextBox num in level3)
                        visible_true(num);
                    foreach (TextBox num in level4)
                        visible_true(num);
                    foreach (TextBox num in level5)
                        visible_true(num);
                    foreach (TextBox num in level6)
                        visible_false(num);
                    foreach (TextBox num in level7)
                        visible_false(num);
                    break;
                case 6:
                    foreach (TextBox num in level3)
                        visible_true(num);
                    foreach (TextBox num in level4)
                        visible_true(num);
                    foreach (TextBox num in level5)
                        visible_true(num);
                    foreach (TextBox num in level6)
                        visible_true(num);
                    foreach (TextBox num in level7)
                        visible_false(num);
                    break;
                default:
                    foreach (TextBox num in level3)
                        visible_true(num);
                    foreach (TextBox num in level4)
                        visible_true(num);
                    foreach (TextBox num in level5)
                        visible_true(num);
                    foreach (TextBox num in level6)
                        visible_true(num);
                    foreach (TextBox num in level7)
                        visible_true(num);
                    break;
            }
        }

        private void visible_true(TextBox num)
        {
            num.Visible = true;
        }

        private void visible_false(TextBox num)
        {
            num.Visible = false;
            num.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int mat_number = Convert.ToInt32(numericUpDown2.Value) - 1;
            int mat_size = Convert.ToInt32(numericUpDown1.Value);
            numericUpDown1.Maximum = numericUpDown1.Minimum = numericUpDown1.Value;
            if (numericUpDown2.Maximum == numericUpDown2.Value)
            {
                numericUpDown2.Maximum++;
                Matrix.Add(new double[mat_size][]);
            }
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                Matrix[mat_number][i] = new double[mat_size];
                for (int j = 0; j < numericUpDown1.Value; j++)
                {
                    try
                    {
                        Matrix[mat_number][i][j] = Convert.ToDouble(str[i][j].Text);
                        if ((Matrix[mat_number][i][j] < 0) || (Matrix[mat_number][i][j] > 1))
                            throw new FormatException();
                    }
                    catch(FormatException a)
                    {
                        if (i != j)
                        {
                            Matrix[mat_number][i][j] = 0;
                            str[i][j].Text = "0";
                        } else
                        {
                            Matrix[mat_number][i][j] = 1;
                            str[i][j].Text = "1";
                        }
                    }
                }
            }
        }
        private string mat_write(double[][] mat)
        {
            string result = "";
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                {
                    result += Convert.ToString(mat[i][j]) + " ";
                }
                result += "\n";
            }
            return result;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            int mat_number = Convert.ToInt32(numericUpDown2.Value) - 1;
            try
            {
                for (int i = 0; i < Matrix[0].Length; i++)
                    for (int j = 0; j < Matrix[0].Length; j++)
                        str[i][j].Text = Convert.ToString(Matrix[Convert.ToInt32(numericUpDown2.Value) - 1][i][j]);
            }
            catch (ArgumentOutOfRangeException a)
            {
                foreach (TextBox[] num_str in str)
                    foreach (TextBox tb in num_str)
                        tb.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Matrix.Clear();
            numericUpDown1.Maximum = 7;
            numericUpDown1.Minimum = 2;
            numericUpDown2.Maximum = 1;
            label3.Text = "";
            foreach (TextBox[] num_str in str)
                foreach (TextBox tb in num_str)
                    tb.Text = "";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        double[][] NotConMatrix(double[][] matrix) //получение матрицы без контуров
        {
            double[][] result = new double[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                result[i] = new double[matrix.Length];
                for (int j = 0; j < matrix.Length; j++)
                    result[i][j] = matrix[i][j];
            }

            for (int i = 0; i < result.Length - 1; i++)
            {
                List<int> cont = new List<int>();
                if (ContFinder(result, i, cont))
                {
                    if (cont.Count > 0)
                    {
                        double min = MyMin(cont, result);
                        for (int j = 0; j < cont.Count - 1; j++)
                        {
                            if (result[cont[j]][cont[j + 1]] == min)
                            {
                                result[cont[j]][cont[j + 1]] = 0;
                            }
                        }
                        if (result[cont[cont.Count - 1]][cont[0]] == min)
                            result[cont[cont.Count - 1]][cont[0]] = 0;
                        i--;
                    }
                }
            }

            return result;
        }

        bool ContFinder(double[][] matrix, int start, List<int> cont) //получение контуров 
        {
            int j = 0;
            bool result = false;
            while (j < matrix.Length)
            {
                if (matrix[start][j] != 0)
                {
                    if (cont.Contains(j))
                    {
                        string s = "";
                        for (int i = 0; i < cont.Count; i++)
                            s += Convert.ToString(cont[i]);

                        return true;
                    }
                    else
                    {
                        cont.Add(j);
                        result = ContFinder(matrix, j, cont);
                        if (result)
                            return result;
                    }
                }
                j++;
            }
            try
            {
                cont.RemoveAt(cont.Count - 1);
            }
            catch
            {

            }
            return result;
        }

        double MyMin(List<int> cont, double[][] matrix) //минимальные дуги в контуре
        {
            double min = 1;
            for (int i = 0; i < cont.Count - 1; i++)
            {
                if (matrix[cont[i]][cont[i + 1]] < min)
                {
                    min = matrix[cont[i]][cont[i + 1]];
                }
            }
            if (matrix[cont[cont.Count - 1]][cont[0]] < min)
                min = matrix[cont[cont.Count - 1]][cont[0]];
            return min;
        }

        double MyMax(List<double> list) //максимальный элемент в списке
        {
            double result = 0;
            for (int i = 0; i < list.Count; i++)
                if (list[i] > result)
                    result = list[i];
            return result;
        }

        double[][] Matrix_Avg(List<double[][]> matrix) //матрица с усредненными значениями
        {
            double[][] result = new double[matrix[0].Length][];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new double[matrix[0].Length];
                for (int j = 0; j < result.Length; j++)
                {
                    result[i][j] = 0;
                    for (int k = 0; k < matrix.Count; k++)
                        result[i][j] += matrix[k][i][j] / matrix.Count;
                }
            }

            return result;
        }

        double[][] Matrix_To_Graf(double[][] matrix) //нагруженный граф матрицы
        {
            double[][] result = new double[matrix.Length][];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new double[matrix.Length];
                for (int j = 0; j < result.Length; j++)
                {
                    if (matrix[i][j] == 0)
                        result[i][j] = 0;
                    else
                        result[i][j] = 1;
                }
            }

            return result;
        }

        double[][] Mat_Mult(double[][] matrix1, double[][] matrix2) //перемножение квадратных матриц
        {
            double[][] result = new double[matrix1.Length][];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new double[matrix1.Length];
                for (int j = 0; j < result.Length; j++)
                {
                    result[i][j] = 0;
                    for (int k = 0; k < matrix1.Length; k++)
                        result[i][j] += matrix1[i][k] * matrix2[k][j];
                }
            }

            return result;
        }

        double[][] Mat_Connect(List<double[][]> matrix) //дизъюнкция матриц
        {
            double[][] result = new double[matrix[0].Length][];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new double[matrix[0].Length];
                for (int j = 0; j < result.Length; j++)
                {
                    List<double> values = new List<double>();
                    for (int k = 0; k < matrix.Count; k++)
                        values.Add(matrix[k][i][j]);
                    result[i][j] = MyMax(values);
                }
            }

            return result;
        }

        double[][] Transit(double[][] matrix1, double[][] matrix2) //транзитивное отношение для двух матриц
        {
            double[][] result = Mat_Mult(matrix1, matrix2);
            for (int i = 0; i < result.Length; i++)
                for (int j = 0; j < result.Length; j++)
                    if (result[i][j] != 0)
                    {
                        List<double> values = new List<double>();
                        for (int k = 0; k < result.Length; k++)
                            values.Add(Math.Min(matrix1[i][k], matrix2[k][j]));
                        result[i][j] = MyMax(values);
                    }
            return result;
        }

        string[] dominate1(double[][] matrix) //упорядочивание альтернатив по матрице
        {
            List<double[]> mat = new List<double[]>();
            for (int count = 0; count < matrix.Length; count++)
            {
                mat.Add(new double[matrix.Length]);
                for (int j = 0; j < matrix.Length; j++)
                    mat[count][j] = matrix[count][j];
            }
            string[] result = new string[matrix.Length];
            int position = matrix.Length - 1;

            double[] counter = new double[matrix.Length];
            while (result[0] == null)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    counter[j] = 0;
                    for (int k = 0; k < matrix.Length; k++)
                    {
                        if (mat[j][k] != 0)
                            counter[j]++;
                    }
                }
                for (int k = 0; k < matrix.Length; k++)
                {
                    if (counter[k] == 0)
                    {
                        string s = "";
                        for (int j = 0; j < matrix.Length; j++)
                        {
                            s += "<" + matrix[k][j] + "> ";
                            try
                            {
                                mat[j][k] = 0;
                            }
                            catch { }
                            mat[k][j] = 1;
                        }
                        result[position] = "Альтернатива №" + (k + 1) + ":" + s;
                        position--;
                    }
                }

            }

            return result;
        }

        List<object> clasters(double[][] matrix, double[][] symm, double[][] asymm) //выделение кластеров
        {
            List<object> end_result = new List<object>();

            int counter = matrix.Length;
            int level = 0;
            while (counter > 0)
            {
                List<int> null_alts = new List<int>();
                for (int j = 0; j < matrix.Length; j++)
                {
                    bool check = true;
                    for (int k = 0; k < matrix.Length; k++)
                    {
                        if (asymm[j][k] != 0)
                            check = false;
                    }
                    if (check)
                    {
                        null_alts.Add(j);
                        counter--;
                    }
                }
                while (null_alts.Count != 0)
                {
                    string result = "Уровень " + Convert.ToString(level) + ":\n";
                    result += "{" + Convert.ToString(null_alts[0] + 1);
                    for (int i = null_alts.Count - 1; i > 0; i--)
                    {
                        for (int k = 0; k < matrix.Length; k++)
                        {
                            asymm[k][null_alts[i]] = 0;
                            asymm[null_alts[i]][k] = -1;
                        }
                        if (symm[null_alts[0]][null_alts[i]] != 0)
                        {
                            result += ", " + Convert.ToString(null_alts[i] + 1);
                            null_alts.RemoveAt(i);
                        }
                    }
                    for (int k = 0; k < matrix.Length; k++)
                    {
                        asymm[k][null_alts[0]] = 0;
                        asymm[null_alts[0]][k] = -1;
                    }
                    null_alts.RemoveAt(0);
                    result += "};\n";
                    end_result.Add(result);
                }
                level++;
            }

            return end_result;
        }

        public double[][] Asym(double[][] matrix) //Ассимметричная часть отношения
        {
            double[][] result = new double[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
                result[i] = new double[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = i; j < matrix.Length; j++)
                {
                    result[i][j] = Math.Max(matrix[i][j] - matrix[j][i], 0);
                    result[j][i] = Math.Max(matrix[j][i] - matrix[i][j], 0);
                }
            }
            return result;
        }

        public double[][] Sym(double[][] matrix) //Симметричная часть отношения
        {
            double[][] result = new double[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
                result[i] = new double[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = i; j < matrix.Length; j++)
                {
                    result[i][j] = Math.Min(matrix[i][j], matrix[j][i]);
                    result[j][i] = result[i][j];
                }
            }
            return result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Matrix.Count == 0)
            {
                MessageBox.Show("Входные данные отсутствуют");
                return;
            }
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    double[][] mat = Matrix_Avg(Matrix);
                    try
                    {
                        for (int i = 0; i < Matrix[0].Length; i++)
                            for (int j = 0; j < Matrix[0].Length; j++)
                                str[i][j].Text = Convert.ToString(mat[i][j]);
                    }
                    catch (ArgumentOutOfRangeException a)
                    {
                        foreach (TextBox[] num_str in str)
                            foreach (TextBox tb in num_str)
                                tb.Text = "";
                    }
                    break;
                case 1:
                    List<double[][]> d = new List<double[][]>();  
                    d.Add(Matrix_Avg(Matrix));
                    for (int i = 1; i < Matrix[0].Length; i++)
                    {
                        d.Add(Transit(d[i - 1], d[0]));
                    }
                    double[][] c = Asym(Mat_Connect(d));
                    try
                    {
                        for (int i = 0; i < Matrix[0].Length; i++)
                            for (int j = 0; j < Matrix[0].Length; j++)
                                str[i][j].Text = Convert.ToString(c[i][j]);
                    }
                    catch (ArgumentOutOfRangeException a)
                    {
                        foreach (TextBox[] num_str in str)
                            foreach (TextBox tb in num_str)
                                tb.Text = "";
                    }
                    break;
                case 2:
                    List<double[][]> d2 = new List<double[][]>();  
                    d2.Add(Matrix_Avg(Matrix));
                    for (int i = 1; i < Matrix[0].Length; i++)
                    {
                        d2.Add(Transit(d2[i - 1], d2[0]));
                    }
                    double[][] c2 = Sym(Mat_Connect(d2));
                    try
                    {
                        for (int i = 0; i < Matrix[0].Length; i++)
                            for (int j = 0; j < Matrix[0].Length; j++)
                                str[i][j].Text = Convert.ToString(c2[i][j]);
                    }
                    catch (ArgumentOutOfRangeException a)
                    {
                        foreach (TextBox[] num_str in str)
                            foreach (TextBox tb in num_str)
                                tb.Text = "";
                    }
                    break;
                case 3:
                    List<double[][]> d3 = new List<double[][]>();  
                    d3.Add(Matrix_Avg(Matrix));
                    for (int i = 1; i < Matrix[0].Length; i++)
                    {
                        d3.Add(Transit(d3[i - 1], d3[0]));
                    }
                    double[][] m = Mat_Connect(d3);
                    try
                    {
                        for (int i = 0; i < Matrix[0].Length; i++)
                            for (int j = 0; j < Matrix[0].Length; j++)
                                str[i][j].Text = Convert.ToString(m[i][j]);
                    }
                    catch (ArgumentOutOfRangeException a)
                    {
                        foreach (TextBox[] num_str in str)
                            foreach (TextBox tb in num_str)
                                tb.Text = "";
                    }
                    break;
                case 4:
                    List<double[][]> d1 = new List<double[][]>();  
                    d1.Add(Matrix_Avg(Matrix));
                    for (int i = 1; i < Matrix[0].Length; i++)
                    {
                        d1.Add(Transit(d1[i - 1], d1[0]));
                    }
                    double[][] m1 = Mat_Connect(d1);
                    double[][] symm = Sym(m1);
                    double[][] asymm = Asym(m1);
                    listBox2.Items.AddRange(clasters(m1, symm, asymm).ToArray());
                    break;
                default:
                    MessageBox.Show("Необходимо выбрать метод");
                    break;
            }
        }
    }
}
