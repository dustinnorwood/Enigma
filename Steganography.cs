using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Collections.Generic;

namespace Enigma
{
    public class Steganography
	{
		
		public static Bitmap EmbedToDCT(Bitmap b_in, Bitmap b_hide)
		{
			//if(b_in.Size != b_hide.Size)
			//	return null;

			Matrix m_in = new Matrix(b_in);
			Matrix m_hide = new Matrix(b_hide);

			Matrix m_dct = DCT.BlockedForward(m_in);

			m_dct += m_hide;

			Matrix m_out = DCT.BlockedReverse(m_dct);

			return m_out.ToBitmap();
		}

		public static bool EmbedToLSB(Bitmap img_in, string s, int direction, params int[] in_params)
		{
            if (img_in == null) return false;
            byte[] s_hide = Encoding.Default.GetBytes(s + "\0");
            BitmapData bmd_in = img_in.LockBits(new Rectangle(0, 0, img_in.Width, img_in.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            switch (direction)
            {
                default:
                    EmbedLR_UD(bmd_in, s_hide);
                    break;
                case 1:
                    EmbedRL_UD(bmd_in, s_hide);
                    break;
                case 2:
                    EmbedLR_DU(bmd_in, s_hide);
                    break;
                case 3:
                    EmbedLR_DU(bmd_in, s_hide);
                    break;
                case 4:
                    EmbedUD_LR(bmd_in, s_hide);
                    break;
                case 5:
                    EmbedUD_RL(bmd_in, s_hide);
                    break;
                case 6:
                    EmbedDU_LR(bmd_in, s_hide);
                    break;
                case 7:
                    EmbedDU_RL(bmd_in, s_hide);
                    break;
                case 8:
                    EmbedLRRL_UD(bmd_in, s_hide);
                    break;
                case 9:
                    EmbedRLLR_UD(bmd_in, s_hide);
                    break;
                case 10:
                    EmbedLRRL_DU(bmd_in, s_hide);
                    break;
                case 11:
                    EmbedRLLR_DU(bmd_in, s_hide);
                    break;
                case 12:
                    EmbedUDDU_LR(bmd_in, s_hide);
                    break;
                case 13:
                    EmbedUDDU_RL(bmd_in, s_hide);
                    break;
                case 14:
                    EmbedDUUD_LR(bmd_in, s_hide);
                    break;
                case 15:
                    EmbedDUUD_RL(bmd_in, s_hide);
                    break;
                case 16:
                    EmbedSpiralLCW(bmd_in, s_hide, in_params[0], in_params[1]);
                    break;
                case 17:
                    EmbedSpiralLCCW(bmd_in, s_hide, in_params[0], in_params[1]);
                    break;
                case 18:
                    EmbedSpiralRCW(bmd_in, s_hide, in_params[0], in_params[1]);
                    break;
                case 19:
                    EmbedSpiralRCCW(bmd_in, s_hide, in_params[0], in_params[1]);
                    break;
                case 20:
                    EmbedSpiralUCW(bmd_in, s_hide, in_params[0], in_params[1]);
                    break;
                case 21:
                    EmbedSpiralUCCW(bmd_in, s_hide, in_params[0], in_params[1]);
                    break;
                case 22:
                    EmbedSpiralDCW(bmd_in, s_hide, in_params[0], in_params[1]);
                    break;
                case 23:
                    EmbedSpiralDCCW(bmd_in, s_hide, in_params[0], in_params[1]);
                    break;
            }
            img_in.UnlockBits(bmd_in);
            return true;
        }

        public static unsafe string ExtractFromLSB(Bitmap img_in, int direction, params int[] in_params)
        {
            if (img_in == null) return null;
            System.Collections.Generic.List<byte> s_hide = new System.Collections.Generic.List<byte>();
            BitmapData bmd_in = img_in.LockBits(new Rectangle(0, 0, img_in.Width, img_in.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            switch (direction)
            {
                default:
                    ExtractLR_UD(bmd_in, s_hide);
                    break;
                case 1:
                    ExtractRL_UD(bmd_in, s_hide);
                    break;
                case 2:
                    ExtractLR_DU(bmd_in, s_hide);
                    break;
                case 3:
                    ExtractLR_DU(bmd_in, s_hide);
                    break;
                case 4:
                    ExtractUD_LR(bmd_in, s_hide);
                    break;
                case 5:
                    ExtractUD_RL(bmd_in, s_hide);
                    break;
                case 6:
                    ExtractDU_LR(bmd_in, s_hide);
                    break;
                case 7:
                    ExtractDU_RL(bmd_in, s_hide);
                    break;
                case 8:
                    ExtractLRRL_UD(bmd_in, s_hide);
                    break;
                case 9:
                    ExtractRLLR_UD(bmd_in, s_hide);
                    break;
                case 10:
                    ExtractLRRL_DU(bmd_in, s_hide);
                    break;
                case 11:
                    ExtractRLLR_DU(bmd_in, s_hide);
                    break;
                case 12:
                    ExtractUDDU_LR(bmd_in, s_hide);
                    break;
                case 13:
                    ExtractUDDU_RL(bmd_in, s_hide);
                    break;
                case 14:
                    ExtractDUUD_LR(bmd_in, s_hide);
                    break;
                case 15:
                    ExtractDUUD_RL(bmd_in, s_hide);
                    break;
                case 16:
                    ExtractSpiralLCW(bmd_in, s_hide, in_params[0], in_params[1]);
                    break;
                case 17:
                    ExtractSpiralLCCW(bmd_in, s_hide, in_params[0], in_params[1]);
                    break;
                case 18:
                    ExtractSpiralRCW(bmd_in, s_hide, in_params[0], in_params[1]);
                    break;
                case 19:
                    ExtractSpiralRCCW(bmd_in, s_hide, in_params[0], in_params[1]);
                    break;
                case 20:
                    ExtractSpiralUCW(bmd_in, s_hide, in_params[0], in_params[1]);
                    break;
                case 21:
                    ExtractSpiralUCCW(bmd_in, s_hide, in_params[0], in_params[1]);
                    break;
                case 22:
                    ExtractSpiralDCW(bmd_in, s_hide, in_params[0], in_params[1]);
                    break;
                case 23:
                    ExtractSpiralDCCW(bmd_in, s_hide, in_params[0], in_params[1]);
                    break;
            }
            img_in.UnlockBits(bmd_in);
            return Encoding.Default.GetString(s_hide.ToArray());
        }

        private static unsafe void EmbedLR_UD(BitmapData bmd_in, byte[] s_hide)
        {
            int s_index = 0, s_bit = 0;
            int rows = 0;
            while (s_index < s_hide.Length && rows < bmd_in.Height)
            {
                if (EmbedRowLR(bmd_in, rows, ref s_hide, ref s_index, ref s_bit)) break;
                rows++;
            }
        }

        private static unsafe void EmbedLR_DU(BitmapData bmd_in, byte[] s_hide)
        {
            int s_index = 0, s_bit = 0;
            int rows = bmd_in.Height - 1;
            while (s_index < s_hide.Length && rows >= 0)
            {
                if (EmbedRowLR(bmd_in, rows, ref s_hide, ref s_index, ref s_bit)) break;
                rows--;
            }
        }

        private static unsafe void EmbedRL_UD(BitmapData bmd_in, byte[] s_hide)
        {
            int s_index = 0, s_bit = 0;
            int rows = 0;
            while (s_index < s_hide.Length && rows < bmd_in.Height)
            {
                if (EmbedRowRL(bmd_in, rows, ref s_hide, ref s_index, ref s_bit)) break;
                rows++;
            }
        }

        private static unsafe void EmbedRL_DU(BitmapData bmd_in, byte[] s_hide)
        {
            int s_index = 0, s_bit = 0;
            int rows = 0;
            while (s_index < s_hide.Length && rows >= 0)
            {
                if (EmbedRowRL(bmd_in, rows, ref s_hide, ref s_index, ref s_bit)) break;
                rows++;
            }
        }

        private static unsafe void EmbedUD_LR(BitmapData bmd_in, byte[] s_hide)
        {
            int s_index = 0, s_bit = 0;
            int cols = 0;
            while (s_index < s_hide.Length && cols < bmd_in.Stride)
            {
                if (EmbedColUD(bmd_in, cols, ref s_hide, ref s_index, ref s_bit)) break;
                cols++;
            }
        }

        private static unsafe void EmbedUD_RL(BitmapData bmd_in, byte[] s_hide)
        {
            int s_index = 0, s_bit = 0;
            int cols = bmd_in.Stride - 1;
            while (s_index < s_hide.Length && cols >= 0)
            {
                if (EmbedColUD(bmd_in, cols, ref s_hide, ref s_index, ref s_bit)) break;
                cols--;
            }
        }

        private static unsafe void EmbedDU_LR(BitmapData bmd_in, byte[] s_hide)
        {
            int s_index = 0, s_bit = 0;
            int cols = 0;
            while (s_index < s_hide.Length && cols < bmd_in.Stride)
            {
                if (EmbedColDU(bmd_in, cols, ref s_hide, ref s_index, ref s_bit)) break;
                cols++;
            }
        }

        private static unsafe void EmbedDU_RL(BitmapData bmd_in, byte[] s_hide)
        {
            int s_index = 0, s_bit = 0;
            int cols = bmd_in.Stride - 1;
            while (s_index < s_hide.Length && cols >= 0)
            {
                if (EmbedColDU(bmd_in, cols, ref s_hide, ref s_index, ref s_bit)) break;
                cols--;
            }
        }

        private static unsafe void EmbedLRRL_UD(BitmapData bmd_in, byte[] s_hide)
        {
            int s_index = 0, s_bit = 0;
            int rows = 0;
            while (s_index < s_hide.Length && rows < bmd_in.Height)
            {
                if (EmbedRowLR(bmd_in, rows, ref s_hide, ref s_index, ref s_bit)) break;
                rows++;
                if (rows >= bmd_in.Height || EmbedRowRL(bmd_in, rows, ref s_hide, ref s_index, ref s_bit)) break;
                rows++;
            }
        }

        private static unsafe void EmbedLRRL_DU(BitmapData bmd_in, byte[] s_hide)
        {
            int s_index = 0, s_bit = 0;
            int rows = bmd_in.Height-1;
            while (s_index < s_hide.Length && rows >= 0)
            {
                if (EmbedRowLR(bmd_in, rows, ref s_hide, ref s_index, ref s_bit)) break;
                rows--;
                if (rows < 0 || EmbedRowRL(bmd_in, rows, ref s_hide, ref s_index, ref s_bit)) break;
                rows--;
            }
        }

        private static unsafe void EmbedRLLR_UD(BitmapData bmd_in, byte[] s_hide)
        {
            int s_index = 0, s_bit = 0;
            int rows = 0;
            while (s_index < s_hide.Length && rows < bmd_in.Height)
            {
                if (EmbedRowRL(bmd_in, rows, ref s_hide, ref s_index, ref s_bit)) break;
                rows++;
                if (rows >= bmd_in.Height || EmbedRowLR(bmd_in, rows, ref s_hide, ref s_index, ref s_bit)) break;
                rows++;
            }
        }

        private static unsafe void EmbedRLLR_DU(BitmapData bmd_in, byte[] s_hide)
        {
            int s_index = 0, s_bit = 0;
            int rows = bmd_in.Height-1;
            while (s_index < s_hide.Length && rows >= 0)
            {
                if (EmbedRowRL(bmd_in, rows, ref s_hide, ref s_index, ref s_bit)) break;
                rows--;
                if (rows < 0 || EmbedRowLR(bmd_in, rows, ref s_hide, ref s_index, ref s_bit)) break;
                rows--;
            }
        }

        private static unsafe void EmbedUDDU_LR(BitmapData bmd_in, byte[] s_hide)
        {
            int s_index = 0, s_bit = 0;
            int cols = 0;
            while (s_index < s_hide.Length && cols < bmd_in.Stride)
            {
                if (EmbedColUD(bmd_in, cols, ref s_hide, ref s_index, ref s_bit)) break;
                cols++;
                if (cols >= bmd_in.Stride || EmbedColDU(bmd_in, cols, ref s_hide, ref s_index, ref s_bit)) break;
                cols++;
            }
        }

        private static unsafe void EmbedUDDU_RL(BitmapData bmd_in, byte[] s_hide)
        {
            int s_index = 0, s_bit = 0;
            int cols = bmd_in.Stride - 1;
            while (s_index < s_hide.Length && cols >= 0)
            {
                if (EmbedColUD(bmd_in, cols, ref s_hide, ref s_index, ref s_bit)) break;
                cols--;
                if (cols < 0 || EmbedColDU(bmd_in, cols, ref s_hide, ref s_index, ref s_bit)) break;
                cols--;
            }
        }

        private static unsafe void EmbedDUUD_LR(BitmapData bmd_in, byte[] s_hide)
        {
            int s_index = 0, s_bit = 0;
            int cols = 0;
            while (s_index < s_hide.Length && cols < bmd_in.Stride)
            {
                if (EmbedColDU(bmd_in, cols, ref s_hide, ref s_index, ref s_bit)) break;
                cols++;
                if (cols >= bmd_in.Stride || EmbedColUD(bmd_in, cols, ref s_hide, ref s_index, ref s_bit)) break;
                cols++;
            }
        }

        private static unsafe void EmbedDUUD_RL(BitmapData bmd_in, byte[] s_hide)
        {
            int s_index = 0, s_bit = 0;
            int cols = bmd_in.Stride - 1;
            while (s_index < s_hide.Length && cols >= 0)
            {
                if (EmbedColDU(bmd_in, cols, ref s_hide, ref s_index, ref s_bit)) break;
                cols--;
                if (cols < 0 || EmbedColUD(bmd_in, cols, ref s_hide, ref s_index, ref s_bit)) break;
                cols--;
            }
        }

        private static unsafe void EmbedSpiralLCW(BitmapData bmd_in, byte[] s_hide, int start_col, int start_row)
        {
            int s_index = 0, s_bit = 0;
            int r_min = start_row, r_max = start_row, c_min = start_col - 1, c_max = start_col;
            if (EmbedColsOnRow(bmd_in, r_max, c_max, c_max, ref s_hide, ref s_index, ref s_bit)) return; 
            while (s_index < s_hide.Length)
            {
                if (c_min < 0 || EmbedColsOnRow(bmd_in, r_max, c_max-1, c_min, ref s_hide, ref s_index, ref s_bit)) break;
                r_min--;
                if (r_min < 0 || EmbedRowsOnCol(bmd_in, c_min, r_max-1, r_min, ref s_hide, ref s_index, ref s_bit)) break;
                c_max++;
                if (c_max >= bmd_in.Stride || EmbedColsOnRow(bmd_in, r_min, c_min+1, c_max, ref s_hide, ref s_index, ref s_bit)) break;
                r_max++;
                if (r_max >= bmd_in.Height || EmbedRowsOnCol(bmd_in, c_max, r_min+1, r_max, ref s_hide, ref s_index, ref s_bit)) break;
                c_min--;
            }
        }

        private static unsafe void EmbedSpiralLCCW(BitmapData bmd_in, byte[] s_hide, int start_col, int start_row)
        {
            int s_index = 0, s_bit = 0;
            int r_min = start_row, r_max = start_row, c_min = start_col - 1, c_max = start_col;
            if (EmbedColsOnRow(bmd_in, r_max, c_max, c_max, ref s_hide, ref s_index, ref s_bit)) return;
            while (s_index < s_hide.Length)
            {
                if (c_max >= bmd_in.Stride || EmbedColsOnRow(bmd_in, r_min, c_max-1, c_min, ref s_hide, ref s_index, ref s_bit)) break;
                r_max++;
                if (r_max >= bmd_in.Height || EmbedRowsOnCol(bmd_in, c_min, r_min+1, r_max, ref s_hide, ref s_index, ref s_bit)) break;
                c_max++;
                if (c_min < 0 || EmbedColsOnRow(bmd_in, r_max, c_min + 1, c_max, ref s_hide, ref s_index, ref s_bit)) break;
                r_min--;
                if (r_min < 0 || EmbedRowsOnCol(bmd_in, c_max, r_max - 1, r_min, ref s_hide, ref s_index, ref s_bit)) break;
                c_min--;
            }
        }

        private static unsafe void EmbedSpiralRCW(BitmapData bmd_in, byte[] s_hide, int start_col, int start_row)
        {
            int s_index = 0, s_bit = 0;
            int r_min = start_row, r_max = start_row, c_min = start_col, c_max = start_col + 1;
            if (EmbedColsOnRow(bmd_in, r_max, c_min, c_min, ref s_hide, ref s_index, ref s_bit)) return;
            while (s_index < s_hide.Length)
            {
                if (c_min < 0 || EmbedColsOnRow(bmd_in, r_min, c_min + 1, c_max, ref s_hide, ref s_index, ref s_bit)) break;
                r_max++;
                if (r_min < 0 || EmbedRowsOnCol(bmd_in, c_max, r_min+1, r_max, ref s_hide, ref s_index, ref s_bit)) break;
                c_min--;
                if (c_max >= bmd_in.Stride || EmbedColsOnRow(bmd_in, r_max, c_max-1, c_min, ref s_hide, ref s_index, ref s_bit)) break;
                r_min--;
                if (r_max >= bmd_in.Height || EmbedRowsOnCol(bmd_in, c_min, r_max-1, r_min, ref s_hide, ref s_index, ref s_bit)) break;
                c_max++;
            }
        }

        private static unsafe void EmbedSpiralRCCW(BitmapData bmd_in, byte[] s_hide, int start_col, int start_row)
        {
            int s_index = 0, s_bit = 0;
            int r_min = start_row, r_max = start_row, c_min = start_col, c_max = start_col+1;
            if (EmbedColsOnRow(bmd_in, r_max, c_min, c_min, ref s_hide, ref s_index, ref s_bit)) return;
            while (s_index < s_hide.Length)
            {
                if (c_min < 0 || EmbedColsOnRow(bmd_in, r_max, c_min + 1, c_max, ref s_hide, ref s_index, ref s_bit)) break;
                r_min--;
                if (r_min < 0 || EmbedRowsOnCol(bmd_in, c_max, r_max - 1, r_min, ref s_hide, ref s_index, ref s_bit)) break;
                c_min--;
                if (c_max >= bmd_in.Stride || EmbedColsOnRow(bmd_in, r_min, c_max - 1, c_min, ref s_hide, ref s_index, ref s_bit)) break;
                r_max++;
                if (r_max >= bmd_in.Height || EmbedRowsOnCol(bmd_in, c_min, r_min + 1, r_max, ref s_hide, ref s_index, ref s_bit)) break;
                c_max++;
            }
        }

        private static unsafe void EmbedSpiralUCW(BitmapData bmd_in, byte[] s_hide, int start_col, int start_row)
        {
            int s_index = 0, s_bit = 0;
            int r_min = start_row -1, r_max = start_row, c_min = start_col, c_max = start_col;
            if (EmbedRowsOnCol(bmd_in, c_max, r_max, r_max, ref s_hide, ref s_index, ref s_bit)) return;
            while (s_index < s_hide.Length)
            {
                if (c_min < 0 || EmbedRowsOnCol(bmd_in, c_min, r_max - 1, r_min, ref s_hide, ref s_index, ref s_bit)) break;
                c_max++;
                if (r_min < 0 || EmbedColsOnRow(bmd_in, r_min, c_min+1, c_max, ref s_hide, ref s_index, ref s_bit)) break;
                r_max++;
                if (c_max >= bmd_in.Stride || EmbedRowsOnCol(bmd_in, c_max, r_min + 1, r_max, ref s_hide, ref s_index, ref s_bit)) break;
                c_min--;
                if (r_max >= bmd_in.Height || EmbedColsOnRow(bmd_in, r_max, c_max - 1, c_min, ref s_hide, ref s_index, ref s_bit)) break;
                r_min--;
            }
        }

        private static unsafe void EmbedSpiralUCCW(BitmapData bmd_in, byte[] s_hide, int start_col, int start_row)
        {
            int s_index = 0, s_bit = 0;
            int r_min = start_row - 1, r_max = start_row, c_min = start_col, c_max = start_col;
            if (EmbedRowsOnCol(bmd_in, c_max, r_max, r_max, ref s_hide, ref s_index, ref s_bit)) return;
            while (s_index < s_hide.Length)
            {
                if (c_min < 0 || EmbedRowsOnCol(bmd_in, c_max, r_max - 1, r_min, ref s_hide, ref s_index, ref s_bit)) break;
                c_min--;
                if (r_max >= bmd_in.Height || EmbedColsOnRow(bmd_in, r_min, c_max - 1, c_min, ref s_hide, ref s_index, ref s_bit)) break;
                r_max++;
                if (c_max >= bmd_in.Stride || EmbedRowsOnCol(bmd_in, c_min, r_min + 1, r_max, ref s_hide, ref s_index, ref s_bit)) break;
                c_max++;
                if (r_min < 0 || EmbedColsOnRow(bmd_in, r_max, c_min + 1, c_max, ref s_hide, ref s_index, ref s_bit)) break;
                r_min--;

            }
        }

        private static unsafe void EmbedSpiralDCW(BitmapData bmd_in, byte[] s_hide, int start_col, int start_row)
        {
            int s_index = 0, s_bit = 0;
            int r_min = start_row, r_max = start_row + 1, c_min = start_col, c_max = start_col;
            if (EmbedRowsOnCol(bmd_in, c_max, r_min, r_min, ref s_hide, ref s_index, ref s_bit)) return;
            while (s_index < s_hide.Length)
            {
                if (c_max >= bmd_in.Stride || EmbedRowsOnCol(bmd_in, c_max, r_min + 1, r_max, ref s_hide, ref s_index, ref s_bit)) break;
                c_min--;
                if (r_max >= bmd_in.Height || EmbedColsOnRow(bmd_in, r_max, c_max - 1, c_min, ref s_hide, ref s_index, ref s_bit)) break;
                r_min--;
                if (c_min < 0 || EmbedRowsOnCol(bmd_in, c_min, r_max - 1, r_min, ref s_hide, ref s_index, ref s_bit)) break;
                c_max++;
                if (r_min < 0 || EmbedColsOnRow(bmd_in, r_min, c_min + 1, c_max, ref s_hide, ref s_index, ref s_bit)) break;
                r_max++;
            }
        }

        private static unsafe void EmbedSpiralDCCW(BitmapData bmd_in, byte[] s_hide, int start_col, int start_row)
        {
            int s_index = 0, s_bit = 0;
            int r_min = start_row, r_max = start_row + 1, c_min = start_col, c_max = start_col;
            if (EmbedRowsOnCol(bmd_in, c_max, r_min, r_min, ref s_hide, ref s_index, ref s_bit)) return;
            while (s_index < s_hide.Length)
            {
                if (c_max >= bmd_in.Stride || EmbedRowsOnCol(bmd_in, c_min, r_min + 1, r_max, ref s_hide, ref s_index, ref s_bit)) break;
                c_max++;
                if (r_min < 0 || EmbedColsOnRow(bmd_in, r_max, c_min + 1, c_max, ref s_hide, ref s_index, ref s_bit)) break;
                r_min--;
                if (c_min < 0 || EmbedRowsOnCol(bmd_in, c_max, r_max - 1, r_min, ref s_hide, ref s_index, ref s_bit)) break;
                c_min--;
                if (r_max >= bmd_in.Height || EmbedColsOnRow(bmd_in, r_min, c_max - 1, c_min, ref s_hide, ref s_index, ref s_bit)) break;
                r_max++;

            }
        }

        private static unsafe void ExtractSpiralLCW(BitmapData bmd_in, List<byte> s_hide, int start_col, int start_row)
        {
            int s_bit = 0;
            byte val = 0;
            int r_min = start_row, r_max = start_row, c_min = start_col - 1, c_max = start_col;
            if (ExtractColsOnRow(bmd_in, r_max, c_max, c_max, s_hide, ref val, ref s_bit)) return;
            while (true)
            {
                if (c_min < 0 || ExtractColsOnRow(bmd_in, r_max, c_max - 1, c_min, s_hide, ref val, ref s_bit)) break;
                r_min--;
                if (r_min < 0 || ExtractRowsOnCol(bmd_in, c_min, r_max - 1, r_min, s_hide, ref val, ref s_bit)) break;
                c_max++;
                if (c_max >= bmd_in.Stride || ExtractColsOnRow(bmd_in, r_min, c_min + 1, c_max, s_hide, ref val, ref s_bit)) break;
                r_max++;
                if (r_max >= bmd_in.Height || ExtractRowsOnCol(bmd_in, c_max, r_min + 1, r_max, s_hide, ref val, ref s_bit)) break;
                c_min--;
            }
        }

        private static unsafe void ExtractSpiralLCCW(BitmapData bmd_in, List<byte> s_hide, int start_col, int start_row)
        {
            int s_bit = 0;
            byte val = 0;
            int r_min = start_row, r_max = start_row, c_min = start_col - 1, c_max = start_col;
            if (ExtractColsOnRow(bmd_in, r_max, c_max, c_max, s_hide, ref val, ref s_bit)) return;
            while (true)
            {
                if (c_max >= bmd_in.Stride || ExtractColsOnRow(bmd_in, r_min, c_max - 1, c_min, s_hide, ref val, ref s_bit)) break;
                r_max++;
                if (r_max >= bmd_in.Height || ExtractRowsOnCol(bmd_in, c_min, r_min + 1, r_max, s_hide, ref val, ref s_bit)) break;
                c_max++;
                if (c_min < 0 || ExtractColsOnRow(bmd_in, r_max, c_min + 1, c_max, s_hide, ref val, ref s_bit)) break;
                r_min--;
                if (r_min < 0 || ExtractRowsOnCol(bmd_in, c_max, r_max - 1, r_min, s_hide, ref val, ref s_bit)) break;
                c_min--;
            }
        }

        private static unsafe void ExtractSpiralRCW(BitmapData bmd_in, List<byte> s_hide, int start_col, int start_row)
        {
            int s_bit = 0;
            byte val = 0;
            int r_min = start_row, r_max = start_row, c_min = start_col, c_max = start_col + 1;
            if (ExtractColsOnRow(bmd_in, r_max, c_min, c_min, s_hide, ref val, ref s_bit)) return;
            while (true)
            {
                if (c_min < 0 || ExtractColsOnRow(bmd_in, r_min, c_min + 1, c_max, s_hide, ref val, ref s_bit)) break;
                r_max++;
                if (r_min < 0 || ExtractRowsOnCol(bmd_in, c_max, r_min + 1, r_max, s_hide, ref val, ref s_bit)) break;
                c_min--;
                if (c_max >= bmd_in.Stride || ExtractColsOnRow(bmd_in, r_max, c_max - 1, c_min, s_hide, ref val, ref s_bit)) break;
                r_min--;
                if (r_max >= bmd_in.Height || ExtractRowsOnCol(bmd_in, c_min, r_max - 1, r_min, s_hide, ref val, ref s_bit)) break;
                c_max++;
            }
        }

        private static unsafe void ExtractSpiralRCCW(BitmapData bmd_in, List<byte> s_hide, int start_col, int start_row)
        {
            int s_bit = 0;
            byte val = 0;
            int r_min = start_row, r_max = start_row, c_min = start_col, c_max = start_col + 1;
            if (ExtractColsOnRow(bmd_in, r_max, c_min, c_min, s_hide, ref val, ref s_bit)) return;
            while (true)
            {
                if (c_min < 0 || ExtractColsOnRow(bmd_in, r_max, c_min + 1, c_max, s_hide, ref val, ref s_bit)) break;
                r_min--;
                if (r_min < 0 || ExtractRowsOnCol(bmd_in, c_max, r_max - 1, r_min, s_hide, ref val, ref s_bit)) break;
                c_min--;
                if (c_max >= bmd_in.Stride || ExtractColsOnRow(bmd_in, r_min, c_max - 1, c_min, s_hide, ref val, ref s_bit)) break;
                r_max++;
                if (r_max >= bmd_in.Height || ExtractRowsOnCol(bmd_in, c_min, r_min + 1, r_max, s_hide, ref val, ref s_bit)) break;
                c_max++;
            }
        }

        private static unsafe void ExtractSpiralUCW(BitmapData bmd_in, List<byte> s_hide, int start_col, int start_row)
        {
            int s_bit = 0;
            byte val = 0;
            int r_min = start_row - 1, r_max = start_row, c_min = start_col, c_max = start_col;
            if (ExtractRowsOnCol(bmd_in, c_max, r_max, r_max, s_hide, ref val, ref s_bit)) return;
            while (true)
            {
                if (c_min < 0 || ExtractRowsOnCol(bmd_in, c_min, r_max - 1, r_min, s_hide, ref val, ref s_bit)) break;
                c_max++;
                if (r_min < 0 || ExtractColsOnRow(bmd_in, r_min, c_min + 1, c_max, s_hide, ref val, ref s_bit)) break;
                r_max++;
                if (c_max >= bmd_in.Stride || ExtractRowsOnCol(bmd_in, c_max, r_min + 1, r_max, s_hide, ref val, ref s_bit)) break;
                c_min--;
                if (r_max >= bmd_in.Height || ExtractColsOnRow(bmd_in, r_max, c_max - 1, c_min, s_hide, ref val, ref s_bit)) break;
                r_min--;
            }
        }

        private static unsafe void ExtractSpiralUCCW(BitmapData bmd_in, List<byte> s_hide, int start_col, int start_row)
        {
            int s_bit = 0;
            byte val = 0;
            int r_min = start_row - 1, r_max = start_row, c_min = start_col, c_max = start_col;
            if (ExtractRowsOnCol(bmd_in, c_max, r_max, r_max, s_hide, ref val, ref s_bit)) return;
            while (true)
            {
                if (c_min < 0 || ExtractRowsOnCol(bmd_in, c_max, r_max - 1, r_min, s_hide, ref val, ref s_bit)) break;
                c_min--;
                if (r_max >= bmd_in.Height || ExtractColsOnRow(bmd_in, r_min, c_max - 1, c_min, s_hide, ref val, ref s_bit)) break;
                r_max++;
                if (c_max >= bmd_in.Stride || ExtractRowsOnCol(bmd_in, c_min, r_min + 1, r_max, s_hide, ref val, ref s_bit)) break;
                c_max++;
                if (r_min < 0 || ExtractColsOnRow(bmd_in, r_max, c_min + 1, c_max, s_hide, ref val, ref s_bit)) break;
                r_min--;

            }
        }

        private static unsafe void ExtractSpiralDCW(BitmapData bmd_in, List<byte> s_hide, int start_col, int start_row)
        {
            int s_bit = 0;
            byte val = 0;
            int r_min = start_row, r_max = start_row + 1, c_min = start_col, c_max = start_col;
            if (ExtractRowsOnCol(bmd_in, c_max, r_min, r_min, s_hide, ref val, ref s_bit)) return;
            while (true)
            {
                if (c_max >= bmd_in.Stride || ExtractRowsOnCol(bmd_in, c_max, r_min + 1, r_max, s_hide, ref val, ref s_bit)) break;
                c_min--;
                if (r_max >= bmd_in.Height || ExtractColsOnRow(bmd_in, r_max, c_max - 1, c_min, s_hide, ref val, ref s_bit)) break;
                r_min--;
                if (c_min < 0 || ExtractRowsOnCol(bmd_in, c_min, r_max - 1, r_min, s_hide, ref val, ref s_bit)) break;
                c_max++;
                if (r_min < 0 || ExtractColsOnRow(bmd_in, r_min, c_min + 1, c_max, s_hide, ref val, ref s_bit)) break;
                r_max++;
            }
        }

        private static unsafe void ExtractSpiralDCCW(BitmapData bmd_in, List<byte> s_hide, int start_col, int start_row)
        {
            int s_bit = 0;
            byte val = 0;
            int r_min = start_row, r_max = start_row + 1, c_min = start_col, c_max = start_col;
            if (ExtractRowsOnCol(bmd_in, c_max, r_min, r_min, s_hide, ref val, ref s_bit)) return;
            while (true)
            {
                if (c_max >= bmd_in.Stride || ExtractRowsOnCol(bmd_in, c_min, r_min + 1, r_max, s_hide, ref val, ref s_bit)) break;
                c_max++;
                if (r_min < 0 || ExtractColsOnRow(bmd_in, r_max, c_min + 1, c_max, s_hide, ref val, ref s_bit)) break;
                r_min--;
                if (c_min < 0 || ExtractRowsOnCol(bmd_in, c_max, r_max - 1, r_min, s_hide, ref val, ref s_bit)) break;
                c_min--;
                if (r_max >= bmd_in.Height || ExtractColsOnRow(bmd_in, r_min, c_max - 1, c_min, s_hide, ref val, ref s_bit)) break;
                r_max++;

            }
        }

        private static unsafe void ExtractLR_UD(BitmapData bmd_in, List<byte> s_hide)
        {
            int s_bit = 0;
            int rows = 0;
            byte val = 0;
            while (rows < bmd_in.Height)
            {
                if (ExtractRowLR(bmd_in, rows, s_hide, ref val, ref s_bit)) break;
                rows++;
            }
        }

        private static unsafe void ExtractLR_DU(BitmapData bmd_in, List<byte> s_hide)
        {
            int s_bit = 0;
            int rows = bmd_in.Height -1;
            byte val = 0;
            while (rows >= 0)
            {
                if (ExtractRowLR(bmd_in, rows, s_hide, ref val, ref s_bit)) break;
                rows--;
            }
        }

        private static unsafe void ExtractRL_UD(BitmapData bmd_in, List<byte> s_hide)
        {
            int s_bit = 0;
            int rows = 0;
            byte val = 0;
            while (rows < bmd_in.Height)
            {
                if (ExtractRowRL(bmd_in, rows, s_hide, ref val, ref s_bit)) break;
                rows++;
            }
        }

        private static unsafe void ExtractRL_DU(BitmapData bmd_in, List<byte> s_hide)
        {
            int s_bit = 0;
            int rows = bmd_in.Height - 1;
            byte val = 0;
            while (rows >= 0)
            {
                if (ExtractRowRL(bmd_in, rows, s_hide, ref val, ref s_bit)) break;
                rows--;
            }
        }

        private static unsafe void ExtractUD_LR(BitmapData bmd_in, List<byte> s_hide)
        {
            int s_bit = 0;
            int cols = 0;
            byte val = 0;
            while (cols < bmd_in.Stride)
            {
                if (ExtractColUD(bmd_in, cols, s_hide, ref val, ref s_bit)) break;
                cols++;
            }
        }

        private static unsafe void ExtractUD_RL(BitmapData bmd_in, List<byte> s_hide)
        {
            int s_bit = 0;
            int cols = bmd_in.Stride - 1;
            byte val = 0;
            while (cols >= 0)
            {
                if (ExtractColUD(bmd_in, cols, s_hide, ref val, ref s_bit)) break;
                cols--;
            }
        }

        private static unsafe void ExtractDU_LR(BitmapData bmd_in, List<byte> s_hide)
        {
            int s_bit = 0;
            int cols = 0;
            byte val = 0;
            while (cols < bmd_in.Stride)
            {
                if (ExtractColDU(bmd_in, cols, s_hide, ref val, ref s_bit)) break;
                cols++;
            }
        }

        private static unsafe void ExtractDU_RL(BitmapData bmd_in, List<byte> s_hide)
        {
            int s_bit = 0;
            int cols = bmd_in.Stride - 1;
            byte val = 0;
            while (cols >= 0)
            {
                if (ExtractColDU(bmd_in, cols, s_hide, ref val, ref s_bit)) break;
                cols--;
            }
        }

        private static unsafe void ExtractLRRL_UD(BitmapData bmd_in, List<byte> s_hide)
        {
            int s_bit = 0;
            int rows = 0;
            byte val = 0;
            while (rows < bmd_in.Height)
            {
                if (ExtractRowLR(bmd_in, rows, s_hide, ref val, ref s_bit)) break;
                rows++;
                if (rows >= bmd_in.Height || ExtractRowRL(bmd_in, rows, s_hide, ref val, ref s_bit)) break;
                rows++;
            }
        }

        private static unsafe void ExtractLRRL_DU(BitmapData bmd_in, List<byte> s_hide)
        {
            int s_bit = 0;
            int rows = bmd_in.Height - 1;
            byte val = 0;
            while (rows >= 0)
            {
                if (ExtractRowLR(bmd_in, rows, s_hide, ref val, ref s_bit)) break;
                rows--;
                if (rows < 0 || ExtractRowRL(bmd_in, rows, s_hide, ref val, ref s_bit)) break;
                rows--;
            }
        }

        private static unsafe void ExtractRLLR_UD(BitmapData bmd_in, List<byte> s_hide)
        {
            int s_bit = 0;
            int rows = 0;
            byte val = 0;
            while (rows < bmd_in.Height)
            {
                if (ExtractRowRL(bmd_in, rows, s_hide, ref val, ref s_bit)) break;
                rows++;
                if (rows >= bmd_in.Height || ExtractRowLR(bmd_in, rows, s_hide, ref val, ref s_bit)) break;
                rows++;
            }
        }

        private static unsafe void ExtractRLLR_DU(BitmapData bmd_in, List<byte> s_hide)
        {
            int s_bit = 0;
            int rows = bmd_in.Height-1;
            byte val = 0;
            while (rows >= 0)
            {
                if (ExtractRowRL(bmd_in, rows, s_hide, ref val, ref s_bit)) break;
                rows--;
                if (rows < 0 || ExtractRowLR(bmd_in, rows, s_hide, ref val, ref s_bit)) break;
                rows--;
            }
        }

        private static unsafe void ExtractUDDU_LR(BitmapData bmd_in, List<byte> s_hide)
        {
            int s_bit = 0;
            int cols = 0;
            byte val = 0;
            while (cols < bmd_in.Stride)
            {
                if (ExtractColUD(bmd_in, cols, s_hide, ref val, ref s_bit)) break;
                cols++;
                if (cols >= bmd_in.Stride || ExtractColDU(bmd_in, cols, s_hide, ref val, ref s_bit)) break;
                cols++;
            }
        }

        private static unsafe void ExtractUDDU_RL(BitmapData bmd_in, List<byte> s_hide)
        {
            int s_bit = 0;
            int cols = bmd_in.Stride - 1;
            byte val = 0;
            while (cols >= 0)
            {
                if (ExtractColUD(bmd_in, cols, s_hide, ref val, ref s_bit)) break;
                cols--;
                if (cols < 0 || ExtractColDU(bmd_in, cols, s_hide, ref val, ref s_bit)) break;
                cols--;
            }
        }

        private static unsafe void ExtractDUUD_LR(BitmapData bmd_in, List<byte> s_hide)
        {
            int s_bit = 0;
            int cols = 0;
            byte val = 0;
            while (cols < bmd_in.Stride)
            {
                if (ExtractColDU(bmd_in, cols, s_hide, ref val, ref s_bit)) break;
                cols++;
                if (cols >= bmd_in.Stride || ExtractColUD(bmd_in, cols, s_hide, ref val, ref s_bit)) break;
                cols++;
            }
        }

        private static unsafe void ExtractDUUD_RL(BitmapData bmd_in, List<byte> s_hide)
        {
            int s_bit = 0;
            int cols = bmd_in.Stride - 1;
            byte val = 0;
            while (cols >= 0)
            {
                if (ExtractColDU(bmd_in, cols, s_hide, ref val, ref s_bit)) break;
                cols--;
                if (cols < 0 || ExtractColUD(bmd_in, cols, s_hide, ref val, ref s_bit)) break;
                cols--;
            }
        }

        private static bool EmbedRowLR(BitmapData bmd_in, int row, ref byte[] s_hide, ref int s_index, ref int s_bit)
        {
            return EmbedColsOnRow(bmd_in, row, 0, bmd_in.Stride - 1, ref s_hide, ref s_index, ref s_bit);
        }

        private static bool EmbedRowRL(BitmapData bmd_in, int row, ref byte[] s_hide, ref int s_index, ref int s_bit)
        {
            return EmbedColsOnRow(bmd_in, row, bmd_in.Stride - 1, 0, ref s_hide, ref s_index, ref s_bit);
        }

        private static bool EmbedColUD(BitmapData bmd_in, int col, ref byte[] s_hide, ref int s_index, ref int s_bit)
        {
            return EmbedRowsOnCol(bmd_in, col, 0, bmd_in.Height - 1, ref s_hide, ref s_index, ref s_bit);
        }

        private static bool EmbedColDU(BitmapData bmd_in, int col, ref byte[] s_hide, ref int s_index, ref int s_bit)
        {
            return EmbedRowsOnCol(bmd_in, col, bmd_in.Height - 1, 0, ref s_hide, ref s_index, ref s_bit);
        }

        private static unsafe bool EmbedColsOnRow(BitmapData bmd_in, int row, int start_col, int end_col, ref byte[] s_hide, ref int s_index, ref int s_bit)
        {
            byte* r = (byte*)bmd_in.Scan0 + bmd_in.Stride * (row) + start_col;
            if(start_col < end_col)
            {
                while (r <= (byte*)bmd_in.Scan0 + bmd_in.Stride * (row) + end_col)
                {
                    EmbedBit(r, ref s_hide, ref s_index, ref s_bit);
                    r++;
                    if (s_index >= s_hide.Length) return true;
                }
            }
            else
            {
                while (r >= (byte*)bmd_in.Scan0 + bmd_in.Stride * (row) + end_col)
                {
                    EmbedBit(r, ref s_hide, ref s_index, ref s_bit);
                    r--;
                    if (s_index >= s_hide.Length) return true;
                }
            }
            return false;
        }

        private static unsafe bool EmbedRowsOnCol(BitmapData bmd_in, int col, int start_row, int end_row, ref byte[] s_hide, ref int s_index, ref int s_bit)
        {
            byte* r = (byte*)bmd_in.Scan0 + bmd_in.Stride * (start_row) + col;
            if (start_row < end_row)
            {
                while (r <= (byte*)bmd_in.Scan0 + bmd_in.Stride * (end_row) + col)
                {
                    EmbedBit(r, ref s_hide, ref s_index, ref s_bit);
                    r+=bmd_in.Stride;
                    if (s_index >= s_hide.Length) return true;
                }
            }
            else
            {
                while (r >= (byte*)bmd_in.Scan0 + bmd_in.Stride * (end_row) + col)
                {
                    EmbedBit(r, ref s_hide, ref s_index, ref s_bit);
                    r-=bmd_in.Stride;
                    if (s_index >= s_hide.Length) return true;
                }
            }
            return false;
        }

        private static bool ExtractRowLR(BitmapData bmd_in, int row, List<byte> s_hide, ref byte val, ref int s_bit)
        {
            return ExtractColsOnRow(bmd_in, row, 0, bmd_in.Stride - 1, s_hide, ref val, ref s_bit);
        }

        private static bool ExtractRowRL(BitmapData bmd_in, int row, List<byte> s_hide, ref byte val, ref int s_bit)
        {
            return ExtractColsOnRow(bmd_in, row, bmd_in.Stride - 1, 0, s_hide, ref val, ref s_bit);
        }

        private static bool ExtractColUD(BitmapData bmd_in, int col, List<byte> s_hide, ref byte val, ref int s_bit)
        {
            return ExtractRowsOnCol(bmd_in, col, 0, bmd_in.Height - 1, s_hide, ref val, ref s_bit);
        }

        private static bool ExtractColDU(BitmapData bmd_in, int col, List<byte> s_hide, ref byte val, ref int s_bit)
        {
            return ExtractRowsOnCol(bmd_in, col, bmd_in.Height - 1, 0, s_hide, ref val, ref s_bit);
        }

        private static unsafe bool ExtractColsOnRow(BitmapData bmd_in, int row, int start_col, int end_col, List<byte> s_hide, ref byte val, ref int s_bit)
        {
            byte* r = (byte*)bmd_in.Scan0 + bmd_in.Stride * (row) + start_col;
            if (start_col < end_col)
            {
                while (r <= (byte*)bmd_in.Scan0 + bmd_in.Stride * (row) + end_col)
                {
                    if (ExtractBit(r, s_hide, ref val, ref s_bit)) return true;
                    r++;
                }
            }
            else
            {
                while (r >= (byte*)bmd_in.Scan0 + bmd_in.Stride * (row) + end_col)
                {
                    if (ExtractBit(r, s_hide, ref val, ref s_bit)) return true;
                    r--;
                }
            }
            return false;
        }

        private static unsafe bool ExtractRowsOnCol(BitmapData bmd_in, int col, int start_row, int end_row, List<byte> s_hide, ref byte val, ref int s_bit)
        {
            byte* r = (byte*)bmd_in.Scan0 + bmd_in.Stride * (start_row) + col;
            if (start_row < end_row)
            {
                while (r <= (byte*)bmd_in.Scan0 + bmd_in.Stride * (end_row) + col)
                {
                    if (ExtractBit(r, s_hide, ref val, ref s_bit)) return true;
                    r+=bmd_in.Stride;
                }
            }
            else
            {
                while (r >= (byte*)bmd_in.Scan0 + bmd_in.Stride * (end_row) + col)
                {
                    if (ExtractBit(r, s_hide, ref val, ref s_bit)) return true;
                    r -= bmd_in.Stride;
                }
            }
            return false;
        }

        private static unsafe void EmbedBit(byte* row, ref byte[] s, ref int index, ref int bit)
        {
            *row &= 0x7f;
            *row ^= (byte)((s[index] & 0x80) >> 0);
            s[index] <<= 1;

            if (++bit == 8)
            {
                index++;
                bit = 0;
            }
        }

        private static unsafe bool ExtractBit(byte* row, List<byte> hide, ref byte val, ref int bit)
        {
            val <<= 1;
            val |= (byte)((*row & 0x80) >> 7);
            if (++bit == 8)
            {
                if (val == 0)
                    return true;
                hide.Add(val);
                bit = 0;
            }
            return false;
        }
    }
}
