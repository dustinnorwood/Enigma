using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{

	public struct SHA512_DATA
	{
		public uint inputLen;
		public ulong A, B, C, D, E, F, G, H;
		public ulong totalLen;
		public byte[] input;
	}

	class Sha512
	{

		private SHA512_DATA m_Data;

		public string HashString
		{
			get
			{
				return m_Data.A.ToString("X8")
					+ m_Data.B.ToString("X8")
					+ m_Data.C.ToString("X8")
					+ m_Data.D.ToString("X8")
					+ m_Data.E.ToString("X8")
					+ m_Data.F.ToString("X8")
					+ m_Data.G.ToString("X8")
					+ m_Data.H.ToString("X8");
			}
		}

		private ulong[] K = new ulong[80]{
		(ulong)(0x428a2f98d728ae22), (ulong)(0x7137449123ef65cd),
		(ulong)(0xb5c0fbcfec4d3b2f), (ulong)(0xe9b5dba58189dbbc),
		(ulong)(0x3956c25bf348b538), (ulong)(0x59f111f1b605d019),
		(ulong)(0x923f82a4af194f9b), (ulong)(0xab1c5ed5da6d8118),
		(ulong)(0xd807aa98a3030242), (ulong)(0x12835b0145706fbe),
		(ulong)(0x243185be4ee4b28c), (ulong)(0x550c7dc3d5ffb4e2),
		(ulong)(0x72be5d74f27b896f), (ulong)(0x80deb1fe3b1696b1),
		(ulong)(0x9bdc06a725c71235), (ulong)(0xc19bf174cf692694),
		(ulong)(0xe49b69c19ef14ad2), (ulong)(0xefbe4786384f25e3),
		(ulong)(0x0fc19dc68b8cd5b5), (ulong)(0x240ca1cc77ac9c65),
		(ulong)(0x2de92c6f592b0275), (ulong)(0x4a7484aa6ea6e483),
		(ulong)(0x5cb0a9dcbd41fbd4), (ulong)(0x76f988da831153b5),
		(ulong)(0x983e5152ee66dfab), (ulong)(0xa831c66d2db43210),
		(ulong)(0xb00327c898fb213f), (ulong)(0xbf597fc7beef0ee4),
		(ulong)(0xc6e00bf33da88fc2), (ulong)(0xd5a79147930aa725),
		(ulong)(0x06ca6351e003826f), (ulong)(0x142929670a0e6e70),
		(ulong)(0x27b70a8546d22ffc), (ulong)(0x2e1b21385c26c926),
		(ulong)(0x4d2c6dfc5ac42aed), (ulong)(0x53380d139d95b3df),
		(ulong)(0x650a73548baf63de), (ulong)(0x766a0abb3c77b2a8),
		(ulong)(0x81c2c92e47edaee6), (ulong)(0x92722c851482353b),
		(ulong)(0xa2bfe8a14cf10364), (ulong)(0xa81a664bbc423001),
		(ulong)(0xc24b8b70d0f89791), (ulong)(0xc76c51a30654be30),
		(ulong)(0xd192e819d6ef5218), (ulong)(0xd69906245565a910),
		(ulong)(0xf40e35855771202a), (ulong)(0x106aa07032bbd1b8),
		(ulong)(0x19a4c116b8d2d0c8), (ulong)(0x1e376c085141ab53),
		(ulong)(0x2748774cdf8eeb99), (ulong)(0x34b0bcb5e19b48a8),
		(ulong)(0x391c0cb3c5c95a63), (ulong)(0x4ed8aa4ae3418acb),
		(ulong)(0x5b9cca4f7763e373), (ulong)(0x682e6ff3d6b2b8a3),
		(ulong)(0x748f82ee5defb2fc), (ulong)(0x78a5636f43172f60),
		(ulong)(0x84c87814a1f0ab72), (ulong)(0x8cc702081a6439ec),
		(ulong)(0x90befffa23631e28), (ulong)(0xa4506cebde82bde9),
		(ulong)(0xbef9a3f7b2c67915), (ulong)(0xc67178f2e372532b),
		(ulong)(0xca273eceea26619c), (ulong)(0xd186b8c721c0c207),
		(ulong)(0xeada7dd6cde0eb1e), (ulong)(0xf57d4f7fee6ed178),
		(ulong)(0x06f067aa72176fba), (ulong)(0x0a637dc5a2c898a6),
		(ulong)(0x113f9804bef90dae), (ulong)(0x1b710b35131c471b),
		(ulong)(0x28db77f523047d84), (ulong)(0x32caab7b40c72493),
		(ulong)(0x3c9ebe0a15c9bebc), (ulong)(0x431d67c49c100d4c),
		(ulong)(0x4cc5d4becb3e42b6), (ulong)(0x597f299cfc657e2a),
		(ulong)(0x5fcb6fab3ad6faec), (ulong)(0x6c44198c4a475817)
		};

		private ulong ROTATE(ulong x, int n)
		{
			return (((x) >> (n)) | ((x) << (64 - (n))));
		}

		private ulong SHIFT(ulong x, int n)
		{
			return ((x) >> (n));
		}

		private ulong CH(ulong x, ulong y, ulong z)
		{
			return (((x) & (y)) ^ ((~(x)) & (z)));
		}

		private ulong MAJ(ulong x, ulong y, ulong z)
		{
			return (((x) & (y)) ^ ((x) & (z)) ^ ((y) & (z)));
		}

		private ulong SUM0(ulong x)
		{
			return (ROTATE((x), 28) ^ ROTATE((x), 34) ^ ROTATE((x), 39));
		}

		private ulong SUM1(ulong x)
		{
			return (ROTATE((x), 14) ^ ROTATE((x), 18) ^ ROTATE((x), 41));
		}

		private ulong RHO0(ulong x)
		{
			return (ROTATE((x), 1) ^ ROTATE((x), 8) ^ SHIFT((x), 7));
		}

		private ulong RHO1(ulong x)
		{
			return (ROTATE((x), 19) ^ ROTATE((x), 61) ^ SHIFT((x), 6));
		}

		public Sha512()
		{
			Sha512_init(ref m_Data);
		}

		public Sha512(string str)
		{
			Sha512_init(ref m_Data);
			//if(str.Length < 128)
			//{
			//	str = str.PadRight(128, '\0');
			//}
			byte[] buf = Encoding.UTF8.GetBytes(str);
			Sha512_data(ref m_Data, ref buf, (uint)buf.Length);
			Sha512_finalize(ref m_Data, null);

		}

		private void Sha512_init(ref SHA512_DATA sha)
		{
			sha.input = new byte[128];
			sha.inputLen = 0;
			sha.A = (ulong)(0x6a09e667f3bcc908);
			sha.B = (ulong)(0xbb67ae8584caa73b);
			sha.C = (ulong)(0x3c6ef372fe94f82b);
			sha.D = (ulong)(0xa54ff53a5f1d36f1);
			sha.E = (ulong)(0x510e527fade682d1);
			sha.F = (ulong)(0x9b05688c2b3e6c1f);
			sha.G = (ulong)(0x1f83d9abfb41bd6b);
			sha.H = (ulong)(0x5be0cd19137e2179);
			sha.totalLen = 0;
		}

		private void ProcessBlock(ref SHA512_DATA sha, byte[] block)
		{
			ulong[] W = new ulong[80];
			ulong a, b, c, d, e, f, g, h;
			ulong temp, temp2;
			int t;

			/* Unpack the block into 80 64-bit words */
			for (t = 0; t < 16; ++t)
			{
				W[t] = (((ulong)(block[t * 8 + 0])) << 56) |
					   (((ulong)(block[t * 8 + 1])) << 48) |
					   (((ulong)(block[t * 8 + 2])) << 40) |
					   (((ulong)(block[t * 8 + 3])) << 32) |
					   (((ulong)(block[t * 8 + 4])) << 24) |
					   (((ulong)(block[t * 8 + 5])) << 16) |
					   (((ulong)(block[t * 8 + 6])) << 8) |
						((ulong)(block[t * 8 + 7]));
			}
			for (t = 16; t < 80; ++t)
			{
				W[t] = RHO1(W[t - 2]) + W[t - 7] +
					   RHO0(W[t - 15]) + W[t - 16];
			}

			/* Load the SHA-512 state into local variables */
			a = sha.A;
			b = sha.B;
			c = sha.C;
			d = sha.D;
			e = sha.E;
			f = sha.F;
			g = sha.G;
			h = sha.H;

			/* Perform 80 rounds of hash computations */
			for (t = 0; t < 80; ++t)
			{
				temp = h + SUM1(e) + CH(e, f, g) + K[t] + W[t];
				temp2 = SUM0(a) + MAJ(a, b, c);
				h = g;
				g = f;
				f = e;
				e = d + temp;
				d = c;
				c = b;
				b = a;
				a = temp + temp2;
			}

			/* Combine the previous SHA-512 state with the new state */
			sha.A += a;
			sha.B += b;
			sha.C += c;
			sha.D += d;
			sha.E += e;
			sha.F += f;
			sha.G += g;
			sha.H += h;
		}

		public void Sha512_data(ref SHA512_DATA sha, ref byte[] buffer, uint len)
		{
			uint templen;

			/* Add to the total length of the input stream */
			sha.totalLen += (ulong)len;

			/* Copy the blocks into the input buffer and process them */
			while (len > 0)
			{
				if ((sha.inputLen == 0) && len >= 128)
				{
					/* Short cut: no point copying the data twice */
					ProcessBlock(ref sha, buffer);
					buffer = ChangeBufPointer(buffer, 128);
					len -= 128;
				}
				else
				{
					templen = len;
					if (templen > (128 - sha.inputLen))
					{
						templen = 128 - sha.inputLen;
					}
					BufCopy(ref sha.input, sha.inputLen, buffer, 0, templen);
					if ((sha.inputLen += templen) >= 128)
					{
						ProcessBlock(ref sha, sha.input);
						sha.inputLen = 0;
					}
					buffer = ChangeBufPointer(buffer, templen);
					len -= templen;
				}
			}
		}

		private void WriteLong(byte[] buf, uint offset, ulong value)
		{
			buf[offset] = (byte)(value >> 56);
			buf[offset + 1] = (byte)(value >> 48);
			buf[offset + 2] = (byte)(value >> 40);
			buf[offset + 3] = (byte)(value >> 32);
			buf[offset + 4] = (byte)(value >> 24);
			buf[offset + 5] = (byte)(value >> 16);
			buf[offset + 6] = (byte)(value >> 8);
			buf[offset + 7] = (byte)value;
		}

		public void Sha512_finalize(ref SHA512_DATA sha, byte[] hash)
		{
			ulong totalBits;

			/* Compute the final hash if necessary */
				/* Pad the input data to a multiple of 1024 bits */
				if (sha.inputLen >= (128 - 16))
				{
					/* Need two blocks worth of padding */
					sha.input[(sha.inputLen)++] = (byte)0x80;
					while (sha.inputLen < 128)
					{
						sha.input[(sha.inputLen)++] = (byte)0x00;
					}
					ProcessBlock(ref sha, sha.input);
					sha.inputLen = 0;
				}
				else
				{
					/* Need one block worth of padding */
					sha.input[(sha.inputLen)++] = (byte)0x80;
				}
				while (sha.inputLen < (128 - 16))
				{
					sha.input[(sha.inputLen)++] = (byte)0x00;
				}
				totalBits = (sha.totalLen << 3);
				BufSet(ref sha.input, (128 - 16), 0, 8);
				WriteLong(sha.input, 128 - 8, totalBits);
				ProcessBlock(ref sha, sha.input);

				/* Write the final hash value to the supplied buffer */
				if (hash != null)
				{
					WriteLong(hash, 0, sha.A);
					WriteLong(hash, 8, sha.B);
					WriteLong(hash, 16, sha.C);
					WriteLong(hash, 24, sha.D);
					WriteLong(hash, 32, sha.E);
					WriteLong(hash, 40, sha.F);
					WriteLong(hash, 48, sha.G);
					WriteLong(hash, 56, sha.H);
				}
		}

		private byte[] ChangeBufPointer(byte[] buffer, uint index)
		{
			if (buffer.Length > index)
			{
				byte[] buf = new byte[buffer.Length - index];
				BufCopy(ref buf, 0, buffer, (uint)index,(uint)( buffer.Length - index));
				buffer = new byte[buf.Length];
				BufCopy(ref buffer, 0, buf, 0, (uint)buf.Length);
			}
			return buffer;
		}

		private void BufCopy(ref byte[] outBuf, uint outIndex, byte[] inBuf, uint inIndex, uint inLen)
		{
			for (int j = 0; j < inLen; j++)
			{
				if (j + inIndex < inBuf.Length && outIndex + j < outBuf.Length)
					outBuf[outIndex + j] = inBuf[inIndex + j];
				else break;
			}
		}

		private void BufSet(ref byte[] outBuf, uint outIndex, byte val, uint inLen)
		{
			for (int j = 0; j < inLen; j++)
			{
				if (outIndex + j < outBuf.Length)
					outBuf[outIndex + j] = val;
				else break;
			}
		}
	}
}
