using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{

	//public delegate

	public class Matrix
	{
		private double[,] mat;

		public double this[int i, int j]
		{
			get{
				return mat[i, j];
			}
			set
			{
				mat[i, j] = value;
			}
		}

		public static Matrix operator +(Matrix m1, Matrix m2)
		{
			return mat_add(m1, m2);
		}
		public static Matrix operator +(Matrix m, double c)
		{
			return mat_add(m, c);
		}

		public static Matrix operator +(double c, Matrix m)
		{
			return mat_add(m, c);
		}

		public static Matrix operator -(Matrix m1, Matrix m2)
		{
			return mat_add(m1, -1 * m2);
		}
		public static Matrix operator -(Matrix m, double c)
		{
			return mat_add(m, -c);
		}

		public static Matrix operator -(double c, Matrix m)
		{
			return mat_add(-1 * m, c);
		}

		public static Matrix operator *(Matrix m1, Matrix m2)
		{
			return mat_mul(m1, m2);
		}
		public static Matrix operator *(Matrix m, double c)
		{
			return mat_mul(m, c);
		}

		public static Matrix operator *(double c, Matrix m)
		{
			return mat_mul(m, c);
		}

		public static Matrix operator /(Matrix m1, Matrix m2)
		{
			Matrix out_mat;
			if(TryInverse(m2, out out_mat))
				return mat_mul(m1, out_mat);
			else throw new DivideByZeroException();
		}
		public static Matrix operator /(Matrix m, double c)
		{
			return mat_mul(m, 1/c);
		}

		public static Matrix operator /(double c, Matrix m)
		{
			Matrix out_mat;
			if (TryInverse(m, out out_mat))
				return mat_mul(out_mat, c);
			else throw new DivideByZeroException();
		}

		public int NumRows
		{
			get { return mat.GetLength(0); }
		}

		public int NumCols
		{
			get { return mat.GetLength(1); }
		}

		public Matrix(int size)
		{
			mat = new double[size, size];
		}

		public Matrix(int rows, int cols)
		{
			mat = new double[rows, cols];
		}

		public Matrix(double[,] m)
		{
			mat = m;
		}

		public Matrix(System.Drawing.Bitmap b)
		{
			mat = new double[b.Height, b.Width];
			for(int i = 0; i < b.Height; i++)
			{
				for(int j = 0; j < b.Width; j++)
				{
					System.Drawing.Color c = b.GetPixel(j,i);
					mat[i, j] = (0.2989 * c.R + 0.5870 * c.G + 0.1140 * c.B);
				}
			}
		}

		public Matrix(string s)
		{
			if(System.IO.File.Exists(s))
			{
				System.Drawing.Bitmap b = new System.Drawing.Bitmap(s);
				mat = new double[b.Height, b.Width];
				for(int i = 0; i < b.Height; i++)
				{
					for(int j = 0; j < b.Width; j++)
					{
						System.Drawing.Color c = b.GetPixel(j,i);
						mat[i, j] = (0.2989 * c.R + 0.5870 * c.G + 0.1140 * c.B);
					}
				}
			}
			else mat = null;
		}

		public System.Drawing.Bitmap ToBitmap()
		{
			System.Drawing.Bitmap b = new System.Drawing.Bitmap(this.NumCols, this.NumRows);
			for(int i = 0; i < b.Height; i++)
				{
					for(int j = 0; j < b.Width; j++)
					{
						if (mat[i, j] < 0) b.SetPixel(j, i, System.Drawing.Color.FromArgb(0,0,0));
						else if (mat[i, j] > 255) b.SetPixel(j, i, System.Drawing.Color.FromArgb(255,255,255));
						else b.SetPixel(j, i, System.Drawing.Color.FromArgb((int) mat[i, j], (int)mat[i, j], (int)mat[i, j]));
					}
				}
			return b;
		}

		public Matrix Transpose()
		{
			return mat_transpose(this);
		}

		public Matrix Inverse()
		{
			return matrix_invert(this);
		}

		public static bool TryInverse(Matrix in_mat, out Matrix out_mat)
		{
			out_mat = matrix_invert(in_mat);
			if (out_mat == null)
				return false;
			else
				return true;
		}

		private static Matrix mat_transpose(Matrix in_mat)
		{
			int r = in_mat.NumRows, c = in_mat.NumCols;
			Matrix out_mat = new Matrix(r,c);

			for (int i = 0; i < r; i++)
				for (int j = 0; j < c; j++)
					out_mat[i, j] = in_mat[j, i];

			return out_mat;
		}

		public double[,] ToDoubleArray()
		{
			return mat;
		}

		private static Matrix mat_mul(Matrix a, Matrix b)
		{
			if (a.NumCols != b.NumRows)
				throw new FormatException("Width of A does not match Height of B");

			int a_h = a.NumRows, a_w = a.NumCols, b_w = b.NumCols;
			Matrix out_mat = new Matrix(a_h, b_w);

			for (int i = 0; i < a_h; i++)
				for (int j = 0; j < b_w; j++)
					for (int k = 0; k < a_w; k++)
					{
						out_mat[i, j] += a[i, k] * b[k, j];
					}

			return out_mat;
		}

		private static Matrix mat_mul(Matrix a, double c)
		{
			int a_h = a.NumRows, a_w = a.NumCols;

			Matrix out_mat = new Matrix(a_h, a_w);

			for (int i = 0; i < a_h; i++)
				for (int j = 0; j < a_w; j++)
					out_mat[i, j] = a[i, j]*c;

			return out_mat;
		}

		private static Matrix mat_add(Matrix a, Matrix b)
		{
			int a_h = a.NumRows, a_w = a.NumCols, b_h = b.NumRows, b_w = b.NumCols;
			if (a_h != b_h || a_w != b_w)
				throw new FormatException("Dimensions of A do not match Height of B");

			Matrix out_mat = new Matrix(a_h, a_w);

			for (int i = 0; i < a_h; i++)
				for (int j = 0; j < a_w; j++)
					out_mat[i, j] = a[i, j] + b[i, j];

			return out_mat;
		}

		private static Matrix mat_add(Matrix a, double c)
		{
			int a_h = a.NumRows, a_w = a.NumCols;

			Matrix out_mat = new Matrix(a_h, a_w);

			for (int i = 0; i < a_h; i++)
				for (int j = 0; j < a_w; j++)
					out_mat[i, j] = a[i, j] + c;

			return out_mat;
		}

		private static void SWAP(ref double a, ref double b)
		{
			double tmp;
			tmp = a; 
			a = b; 
			b = tmp;
		}

		private static Matrix matrix_invert(Matrix in_mat)
		{
			if (in_mat.NumRows != in_mat.NumCols)
				throw new FormatException();
			Matrix a = new Matrix(in_mat.ToDoubleArray());
			double big, pivinv, tmp;
			int i, icol = 0, irow = 0, j, k, l, ll;
			int n = a.NumRows;
			int[] indxc, indxr, ipiv;
			//in_mat.mat = new double[1, 1];
			indxc = new int[n];
			indxr = new int[n];
			ipiv = new int[n];

			for (i = 0; i < n; i++)
			{
				big = 0.0;
				for (j = 0; j < n; j++)
				{
					if (ipiv[j] == 1)
						continue;

					for (k = 0; k < n; k++)
					{
						if (ipiv[k] == 0)
						{
							if (Math.Abs(a[j, k]) >= big)
							{
								big = Math.Abs(a[j, k]);
								irow = j;
								icol = k;
							}
						}
						else if (ipiv[k] > 1)
							return null;
					}
				}
				++ipiv[icol];
				if (irow != icol)
				{
					for (l = 0; l < n; l++)
					{
						double temp = a[irow, l];
						a[irow, l] = a[icol, l];
						a[icol, l] = temp;
					}
				}
				indxr[i] = irow;
				indxc[i] = icol;
				if (a[icol, icol] == 0.0)
					return null;
				pivinv = 1.0 / a[icol, icol];
				a[icol, icol] = 1.0;
				for (l = 0; l < n; l++)
					a[icol, l] *= pivinv;
				for (ll = 0; ll < n; ll++)
					if (ll != icol)
					{
						tmp = a[ll, icol];
						a[ll, icol] = 0.0;
						for (l = 0; l < n; l++)
							a[ll, l] -= a[icol, l] * tmp;
					}
			}
			for (l = n - 1; l >= 0; l--)
			{
				if (indxr[l] != indxc[l])
					for (k = 0; k < n; k++)
					{
						double temp = a[k, indxr[l]];
						a[k, indxr[l]] = a[k, indxc[l]];
						a[k, indxc[l]] = temp;
					}
			}

			return a;
		}
	}
}
