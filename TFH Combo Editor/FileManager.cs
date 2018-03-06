using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TFH_Combo_Editor
{
	/// <summary>
	/// Handles the reading and writing of bytes to and from a file.
	/// TODO: This is gonna be super hacky to start with. Make sure to abstract later.
	/// </summary>
	class FileManager
	{	
		//byte arrays for each chunk of the file
		byte[] ba1, ba2, ba3, ba4, ba5;
		byte[] byteArray;
		public FileManager()
		{

		}

		public void SaveFile(List<InputFrame> inputList)
		{
			ConstructArray(inputList);
			WriteBytesToDisk();
		}

		public void ConstructArray(List<InputFrame> inputList)
		{
			ConstructHeader();
			ConstructCharNames();
			ConstructSeeds();
			ConstructInputs(inputList);
			ConstructTrainingComboOptions();

			byteArray = new byte[ba1.Length + ba2.Length + ba3.Length + ba4.Length + ba5.Length];
			System.Buffer.BlockCopy(ba1, 0, byteArray, 0, ba1.Length);
			System.Buffer.BlockCopy(ba2, 0, byteArray, ba1.Length, ba2.Length);
			System.Buffer.BlockCopy(ba3, 0, byteArray, ba1.Length + ba2.Length, ba3.Length);
			System.Buffer.BlockCopy(ba4, 0, byteArray, ba1.Length + ba2.Length + ba3.Length, ba4.Length);
			System.Buffer.BlockCopy(ba5, 0, byteArray, ba1.Length + ba2.Length + ba3.Length + ba4.Length, ba5.Length);
		}

		public void ConstructHeader()
		{
			//Big fat temp byte array placeholder
			string hexString = "54 46 48 43 03 00 00 00 54 46 48 52 05 00 00 00 59 06 00 00 40 00 00 00 4D 08 00 00 40 00 00 00 D0 07 00 00 10 0E 00 00 0D 02 00 00 77 01 00 00";
			ba1 = HexStringToBytes(hexString);
		}

		public void ConstructCharNames()
		{
			//Some placeholder byte array names
			string hexString = "07 54 69 61 6E 68 75 6F 06 56 65 6C 76 65 74";
			ba2 = HexStringToBytes(hexString);
		}

		public void ConstructSeeds()
		{
			//Some placeholder seed bytes
			string hexString = "81 8D 62 A8 81 8D 62 A8 00";
			ba3 = HexStringToBytes(hexString);
		}

		public void ConstructInputs(List<InputFrame> inputList)
		{
			//This is the real magic
			//ba4 = new byte[] { 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xFF };
			ba4 = new byte[inputList.Count * 5]; //change later
			List<InputFrame> uniqueInputs = new List<InputFrame>();

			//construct unique inputs list
			InputFrame lastInput = inputList[0];
			for (int index = 0; index < inputList.Count; index++)
			{
				InputFrame input = inputList[index];

				//if any raw input has changed, or if the last frame was a one-off special case
				bool inputChanged = ((input.direction != lastInput.direction) || (input.a != lastInput.a) || (input.b != lastInput.b) || (input.c != lastInput.c) || (input.d != lastInput.d) || lastInput.isSpecialFrame);
				if (inputChanged)
				{
					input.aState = GetButtonState(input.a, lastInput.a);
					input.bState = GetButtonState(input.b, lastInput.b);
					input.cState = GetButtonState(input.c, lastInput.c);
					input.dState = GetButtonState(input.d, lastInput.d);

					uniqueInputs.Add(input);
					lastInput = input;
				}
			}


			//convert unique inputs into bytes

			for (int index = 0; index < uniqueInputs.Count; index++)
			{
				int offset = index * 6;
				InputFrame input = uniqueInputs[index];
				ba4[offset + 0] = Convert.ToByte(input.counter);
				ba4[offset + 1] = Convert.ToByte(input.direction);
				ba4[offset + 2] = Convert.ToByte(input.aState);
				ba4[offset + 3] = Convert.ToByte(input.bState);
				ba4[offset + 4] = Convert.ToByte(input.cState);
				ba4[offset + 5] = Convert.ToByte(input.dState);
			}
		}

		public void ConstructTrainingComboOptions()
		{
			//This is pretty blackbox still. Just use a copy-pasted byte chunk.
			string hexString = "07 00 00 00 10 00 00 00 0C 44 65 61 74 68 41 6C 6C 6F 77 65 64 05 66 61 6C 73 65 0D 48 65 61 6C 74 68 52 65 73 74 6F 72 65 03 31 30 30 14 53 75 70 65 72 4D 65 74 65 72 52 65 73 74 6F 72 65 4C 76 6C 01 33 14 4D 61 67 69 63 4D 65 74 65 72 52 65 73 74 6F 72 65 4C 76 6C 01 36 0B 44 75 6D 6D 79 41 63 74 69 6F 6E 06 4D 61 6E 75 61 6C 0E 44 75 6D 6D 79 42 6C 6F 63 6B 57 68 65 6E 05 4E 65 76 65 72 0E 44 75 6D 6D 79 42 6C 6F 63 6B 54 79 70 65 03 41 6C 6C 0E 44 75 6D 6D 79 50 75 73 68 62 6C 6F 63 6B 05 4E 65 76 65 72 10 4B 65 65 70 50 75 73 68 62 6C 6F 63 6B 69 6E 67 05 66 61 6C 73 65 0E 44 75 6D 6D 79 54 68 72 6F 77 54 65 63 68 05 4E 65 76 65 72 0F 44 75 6D 6D 79 47 72 6F 75 6E 64 54 65 63 68 05 4E 65 76 65 72 0C 44 75 6D 6D 79 41 69 72 54 65 63 68 05 4E 65 76 65 72 10 53 74 75 6E 41 63 63 75 6D 75 6C 61 74 69 6F 6E 04 74 72 75 65 04 53 74 75 6E 01 30 0F 46 6F 72 63 65 43 6F 75 6E 74 65 72 48 69 74 05 66 61 6C 73 65 16 41 69 54 72 61 69 6E 69 6E 67 4D 6F 76 65 6D 65 6E 74 4D 6F 64 65 06 52 61 6E 64 6F 6D";
			ba5 = HexStringToBytes(hexString);
		}

		public void WriteBytesToDisk()
		{
			string fileName = "testFileName.tfhc";
			int blockLength = byteArray.Length;
			FileStream FS = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);

			FS.Write(byteArray, 0, blockLength);
		}

		public byte[] HexStringToBytes(string hexString)
		{
			hexString = hexString.Replace(" ", "");
			byte[] bytes = new byte[hexString.Length / 2];

			for (int index = 0; index < ba1.Length; index++)
			{
				string byteValue = hexString.Substring(index * 2, 2);
				bytes[index] = byte.Parse(byteValue, System.Globalization.NumberStyles.HexNumber);
			}
			return bytes;
		}

		public int GetButtonState(InputFrame inputFrame, bool input, bool lastInput)
		{
			int buttonState;

			if(input)
			{
				if(lastInput)
				{
					buttonState = 3; //held
				}
				else
				{
					buttonState = 0; //pressed
					inputFrame.isSpecialFrame = true;
				}
			}
			else
			{
				if(lastInput)
				{
					buttonState = 1; //released
					inputFrame.isSpecialFrame = true;
				}
				else
				{
					buttonState = 4; //up
				}
			}

			return buttonState;
		}

	}
}
