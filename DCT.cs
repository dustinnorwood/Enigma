using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
	class DCT
	{
		private static int DCTSIZE = 8, DCTSIZE2 = 64;

		private static Matrix _D = new Matrix(new double[,]{
			{0.35355339059327, 0.35355339059327, 0.35355339059327, 0.35355339059327, 0.35355339059327, 0.35355339059327, 0.35355339059327, 0.35355339059327},

			{0.49039264020162, 0.41573480615127, 0.27778511650980, 0.09754516100806, -0.09754516100806, -0.27778511650980, -0.41573480615127, -0.49039264020162},

			{0.46193976625564, 0.19134171618254, -0.19134171618254, -0.46193976625564, -0.46193976625564, -0.19134171618255, 0.19134171618255, 0.46193976625564},

			{0.41573480615127, -0.09754516100806, -0.49039264020162, -0.27778511650980, 0.27778511650980, 0.49039264020162, 0.09754516100806, -0.41573480615127},

			{0.35355339059327, -0.35355339059327, -0.35355339059327, 0.35355339059327, 0.35355339059327, -0.35355339059327, -0.35355339059327, 0.35355339059327},

			{0.27778511650980, -0.49039264020162, 0.09754516100806, 0.41573480615127, -0.41573480615127, -0.09754516100806, 0.49039264020162, -0.27778511650980},

			{0.19134171618254, -0.46193976625564, 0.46193976625564, -0.19134171618254, -0.19134171618255, 0.46193976625564, -0.46193976625564, 0.19134171618254},

			{0.09754516100806, -0.27778511650980, 0.41573480615127, -0.49039264020162, 0.49039264020162, -0.41573480615127, 0.27778511650980, -0.09754516100806}
		});

		private static void dcttomat(Matrix mat, double[] dct)
		{
			for (int i = 0; i < DCTSIZE2; i++)
			{
				mat[i >> 3, i & 7] = dct[i];
			}
		}

		private static void mattodct(double[] dct, Matrix mat)
		{
			int i;

			for (i = 0; i < DCTSIZE2; i++)
			{
				dct[i] = mat[i >> 3, i & 7];
			}
		}

		public static void Reverse(double[] out_mat, double[] in_mat)
		{
			Matrix _Dt = _D.Transpose();
			Matrix tmp1 = new Matrix(DCTSIZE);
			/* Convert to internal matrix representation */
			dcttomat(tmp1, in_mat);
			/* Do D' * A * D */

			Matrix tmp2 = _Dt * tmp1;
			tmp1 = tmp2 * _D;

			/* Convert back to dct representation */
			mattodct(out_mat, tmp1);
		}

		public static void Forward(double[] out_mat, double[] in_mat)
		{
			Matrix _Dt = _D.Transpose();
			Matrix tmp1 = new Matrix(DCTSIZE);
			/* Convert to internal matrix representation */
			dcttomat(tmp1, in_mat);
			/* Do D' * A * D */

			Matrix tmp2 = _D * tmp1;
			tmp1 = tmp2 * _Dt;

			/* Convert back to dct representation */
			mattodct(out_mat, tmp1);
		}

		public static double[][] BlockMatrix(Matrix m, out int numBlockRows, out int numBlockCols)
		{
			numBlockCols = ((m.NumCols + DCTSIZE-1) / DCTSIZE);
			numBlockRows = ((m.NumRows + DCTSIZE - 1) / DCTSIZE);
			double[][] ret_mat = new double[numBlockCols * numBlockRows][];
			for (int k = 0; k < numBlockCols * numBlockRows; k++) ret_mat[k] = new double[DCTSIZE2];
				for (int i = 0; i < m.NumRows; i++)
				{
					for (int j = 0; j < m.NumCols; j++)
					{
						ret_mat[numBlockCols * (i / DCTSIZE) + j / DCTSIZE][(i % DCTSIZE) * DCTSIZE + j % DCTSIZE] = m[i, j];
					}
				}

			return ret_mat;

		}

		public static Matrix UnblockMatrix(double[][] s, int numBlockRows, int numBlockCols)
		{
			Matrix m = new Matrix(numBlockRows * DCTSIZE, numBlockCols * DCTSIZE);

			for (int i = 0; i < m.NumRows; i++)
			{
				for (int j = 0; j < m.NumCols; j++)
				{
					m[i, j] = s[numBlockCols * (i / DCTSIZE) + j / DCTSIZE][(i % DCTSIZE) * DCTSIZE + j % DCTSIZE];
				}
			}

			return m;

		}

		public static Matrix BlockedForward(Matrix m)
		{
			int nBr,nBc;
			double[][] s_in = BlockMatrix(m, out nBr, out nBc);
			double[][] s_out = new double[s_in.GetLength(0)][];
			for(int k = 0;k<s_in.GetLength(0);k++)
			{
				s_out[k] = new double[s_in[k].Length];
				Forward(s_out[k],s_in[k]);
			}
			return UnblockMatrix(s_out, nBr, nBc);
		}

		public static Matrix BlockedReverse(Matrix m)
		{
			int nBr, nBc;
			double[][] s_in = BlockMatrix(m, out nBr, out nBc);
			double[][] s_out = new double[s_in.GetLength(0)][];
			for (int k = 0; k < s_in.GetLength(0); k++)
			{
				s_out[k] = new double[s_in[k].Length];
				Reverse(s_out[k], s_in[k]);
			}
			return UnblockMatrix(s_out, nBr, nBc);
		}

	}
}
